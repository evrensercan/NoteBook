# 1. ADIM: Mutfak Tezgahını Kur (Build Stage)
# Microsoft'un sitesinden .NET SDK (yazılım geliştirme kiti) yüklü bir bilgisayar görüntüsü istiyoruz.
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# 2. ADIM: Malzemeleri İçeri Al
# Proje dosyanı (.csproj) içeri kopyalıyoruz ki eksik kütüphane var mı bakalım.
COPY ["NoteBook.csproj", "./"]
RUN dotnet restore

# 3. ADIM: Kodları Kopyala ve Pişir
# Tüm kodlarını içeri atıyoruz ve projeyi "Publish" (yayınlanmaya hazır hale getir) yapıyoruz.
COPY . .
RUN dotnet publish -c Release -o out

# 4. ADIM: Servis Et (Runtime Stage)
# Artık SDK'ya (ağır araçlara) gerek yok. Sadece çalıştırmak için hafif bir .NET Runtime yeterli.
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# 5. ADIM: Kapıyı Aç ve Başlat
# Uygulama 8080 portundan (kapısından) yayın yapacak.
EXPOSE 8080
ENTRYPOINT ["dotnet", "NoteBook.dll"]