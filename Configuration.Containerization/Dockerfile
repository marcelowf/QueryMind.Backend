FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Directory.Packages.props", "."]
COPY ["Directory.Build.props", "."]
COPY ["nuget.config", "."]
COPY ["QueryMind.Presentation/QueryMind.Presentation.csproj", "QueryMind.Presentation/"]
COPY ["QueryMind.Service/QueryMind.Service.csproj", "QueryMind.Service/"]
COPY ["QueryMind.Infrastructure/QueryMind.Infrastructure.csproj", "QueryMind.Infrastructure/"]
COPY ["QueryMind.Domain/QueryMind.Domain.csproj", "QueryMind.Domain/"]
RUN dotnet restore "./QueryMind.Presentation/QueryMind.Presentation.csproj"
COPY . .
WORKDIR "/src/QueryMind.Presentation"
RUN dotnet build "./QueryMind.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./QueryMind.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "QueryMind.Presentation.dll"]