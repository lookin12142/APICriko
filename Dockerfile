# Dockerfile para .NET 8
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["ApiRick.csproj", "./"]
RUN dotnet restore "./ApiRick.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "ApiRick.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiRick.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiRick.dll"]
