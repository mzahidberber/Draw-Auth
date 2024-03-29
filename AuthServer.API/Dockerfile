#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AuthServer.API/AuthServer.API.csproj", "AuthServer.API/"]
COPY ["AuthServer.Business/AuthServer.Business.csproj", "AuthServer.Business/"]
COPY ["AuthServer.Core/AuthServer.Core.csproj", "AuthServer.Core/"]
COPY ["AuthServer.DataAccess/AuthServer.DataAccess.csproj", "AuthServer.DataAccess/"]
RUN dotnet restore "AuthServer.API/AuthServer.API.csproj"
COPY . .
WORKDIR "/src/AuthServer.API"
RUN dotnet build "AuthServer.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AuthServer.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AuthServer.API.dll"]