using OpenQA.Selenium;
using System;
using System.Linq;
using Xunit;

namespace SeleniumVSTS.UITests
{
    public class ProdutoTests
    {
        string url = Environment.GetEnvironmentVariable("appHost");
        public ProdutoTests()
        {

        }

        [Theory]
        [InlineData("Produto 1", 5.0)]
        [InlineData("Produto 2", 15.99)]
        [InlineData("Produto 3", 25.25)]
        [InlineData("Produto 4", 14.47)]
        [InlineData("Produto 5", 99.99)]
        public void CriarProduto(string produto, decimal preco)
        {
            var printPrefix = produto + " - ";

            using (var _driver = WebDriverFactory.CreateWebDriver())
            {
                _driver.CarregarPagina(TimeSpan.FromSeconds(30), url);
                _driver.SalvarScreenShot("CriarProduto", "Home", printPrefix);
                _driver.FindElement(By.LinkText("Produtos")).Click();
                Assert.True(_driver.ValidarUrl(url + "/Produto"));
                _driver.SalvarScreenShot("CriarProduto", "Pagina Produtos", printPrefix);
                _driver.FindElement(By.LinkText("Create New")).Click();
                Assert.True(_driver.ValidarUrl(url + "/Produto/Create"));
                _driver.SalvarScreenShot("CriarProduto", "Pagina Novo Produto", printPrefix);
                _driver.AtribuirTexto(By.Name("Produto"), produto);
                var txtNome = _driver.ObterValue(By.Name("Produto"));
                _driver.SalvarScreenShot("CriarProduto", "Setando Nome", printPrefix);
                Assert.Equal(produto, txtNome);

                _driver.AtribuirTexto(By.Name("Preco"), preco.ToString().Replace(",", "."));
                var txtPreco = _driver.ObterValue(By.Name("Preco"));
                _driver.SalvarScreenShot("CriarProduto", "Setando Preco", printPrefix);
                Assert.Equal(preco.ToString().Replace(",", "."), txtPreco);

                _driver.Submit(By.TagName("form"));
                Assert.True(_driver.ValidarUrl(url + "/Produto"));

                var table = _driver.FindElement(By.TagName("table"));
                var trProdutos = table.FindElements(By.TagName("tr"));
                Assert.NotEmpty(trProdutos);
                var nomesSalvos = table.FindElements(By.ClassName("produto")).Select(s => s.Text);
                Assert.Contains(nomesSalvos, x => x == produto);
                _driver.SalvarScreenShot("CriarProduto", "Produto Salvo", printPrefix);
                _driver.Quit();
            }
        }

    }
}
