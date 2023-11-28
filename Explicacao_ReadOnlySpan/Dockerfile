FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Explicacao_ReadOnlySpan/Explicacao_ReadOnlySpan.csproj", "Explicacao_ReadOnlySpan/"]
RUN dotnet restore "Explicacao_ReadOnlySpan/Explicacao_ReadOnlySpan.csproj"
COPY . .
WORKDIR "/src/Explicacao_ReadOnlySpan"
RUN dotnet build "Explicacao_ReadOnlySpan.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Explicacao_ReadOnlySpan.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Explicacao_ReadOnlySpan.dll"]
