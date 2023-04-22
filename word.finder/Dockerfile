FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["word.finder/word.finder.csproj", "word.finder/"]
RUN dotnet restore "word.finder/word.finder.csproj"
COPY . .
WORKDIR "/src/word.finder"
RUN dotnet build "word.finder.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "word.finder.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "word.finder.dll"]
