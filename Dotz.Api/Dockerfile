FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Dotz.Api/Dotz.Api.csproj", "Dotz.Api/"]
COPY ["Dotz.Domain/Dotz.Domain.csproj", "Dotz.Domain/"]
COPY ["Dotz.Infra.EF/Dotz.Infra.EF.csproj", "Dotz.Infra.EF/"]
COPY ["Dotz.Infra.Security/Dotz.Infra.Security.csproj", "Dotz.Infra.Security/"]
RUN dotnet restore "Dotz.Api/Dotz.Api.csproj"
COPY . .
WORKDIR "/src/Dotz.Api"
RUN dotnet build "Dotz.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Dotz.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Dotz.Api.dll"]