# Build aşaması
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY ["NoteBook.csproj", "./"]
RUN dotnet restore

COPY . .
RUN dotnet publish -c Release -o out

# Çalışma aşaması
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

EXPOSE 8080
ENTRYPOINT ["dotnet", "NoteBook.dll"]
