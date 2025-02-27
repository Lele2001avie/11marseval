# Utiliser l'image officielle .NET SDK pour construire l'application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copier les fichiers .csproj et restaurer les dépendances
COPY *.csproj ./
RUN dotnet restore

# Copier le reste des fichiers et construire l'application
COPY . ./
RUN dotnet publish -c Release -o out

# Utiliser l'image officielle .NET Runtime pour exécuter l'application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Exposer le port sur lequel l'application écoute
EXPOSE 80
EXPOSE 443

# Démarrer l'application
ENTRYPOINT ["dotnet", "Eval_11_mars.dll"]
