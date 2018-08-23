FROM microsoft/dotnet:2.1-sdk-alpine AS build
WORKDIR /src
COPY SeleniumVSTS.sln ./
COPY . .
WORKDIR /src/SeleniumVSTS.UITests/
RUN dotnet restore -nowarn:msb3202,nu1503