FROM microsoft/dotnet:2.1-aspnetcore-runtime-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk-alpine AS build
WORKDIR /src
COPY SeleniumVSTS.UI/SeleniumVSTS.UI.csproj SeleniumVSTS.UI/
RUN dotnet restore SeleniumVSTS.UI/SeleniumVSTS.UI.csproj
COPY . .
WORKDIR /src/SeleniumVSTS.UI
RUN dotnet build SeleniumVSTS.UI.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish SeleniumVSTS.UI.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SeleniumVSTS.UI.dll"]