FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY first-dotnet-project.csproj .
RUN dotnet restore first-dotnet-project.csproj
COPY . .
RUN dotnet publish first-dotnet-project.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "first-dotnet-project.dll"]
