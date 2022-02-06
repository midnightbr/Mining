FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Mining/Mining.csproj", "Mining/"]
RUN dotnet restore "Mining/Mining.csproj"
COPY . .
WORKDIR "/src/Mining"
RUN dotnet build "Mining.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Mining.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mining.dll"]
