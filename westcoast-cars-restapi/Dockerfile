# Skapa instruktioner för hur vår image/avbild ska byggas...
# Vilken bas avbild ska vi använda...
# -----------------------------------------------------------------
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

# Skapa arbetskatalog...
WORKDIR /app

# Kopiera från projektet till avbilden
# <src> <dest>
COPY *.csproj .

# Kör återställ av alla beroende som finns i vår *.csproj fil...
RUN dotnet restore

# Kopiera alla filer ifrån vårt projekt över till arbetskatalogen...
COPY . .

# Skapa ett publicerings paket...
RUN dotnet publish -c Release -o out

# Slut på konfigurering av avbilden
# ----------------------------------------------------------------------
FROM mcr.microsoft.com/dotnet/aspnet:6.0

# Kopiera katalogen out till app katalogen
COPY --from=build-env /app/out .

ENTRYPOINT [ "dotnet", "westcoast-cars-restapi.dll" ]
