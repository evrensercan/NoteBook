# 📝 NooteBook - Full Stack Not Uygulaması

Bu proje, modern web teknolojileri kullanılarak geliştirilmiş, konteyner mimarisine sahip bir not defteri uygulamasıdır. Kullanıcıların not eklemesine, listelemesine ve silmesine olanak tanır.

![.NET](https://img.shields.io/badge/.NET-8.0-purple)
![Docker](https://img.shields.io/badge/Docker-Enabled-blue)
![SQL Server](https://img.shields.io/badge/Database-SQL_Server-red)

## 🚀 Proje Hakkında

Bu projenin temel amacı; **Backend** (.NET API), **Frontend** (HTML/JS) ve **Veritabanı** (SQL Server) katmanlarını **Docker** üzerinde birleştirerek tam kapsamlı (Full Stack) bir mimari kurmaktır.

## 🛠 Kullanılan Teknolojiler

| Kategori | Teknoloji | Amaç |
|----------|-----------|------|
| **Backend** | .NET 8 Web API | Not ekleme, silme ve listeleme mantığı. |
| **Frontend** | HTML5, JavaScript | Kullanıcı arayüzü ve API iletişimi. |
| **Veritabanı** | MS SQL Server | Verilerin kalıcı olarak saklanması. |
| **Altyapı** | Docker & Compose | Tüm servislerin tek komutla yönetilmesi. |
| **Sunucu** | Nginx | Frontend sunucusu ve Reverse Proxy. |

## ⚙️ Kurulum (Nasıl Çalıştırılır?)

Bu projeyi bilgisayarınızda çalıştırmak için **Docker Desktop** yüklü olması yeterlidir.

1. **Projeyi İndirin:**
   ```bash
   git clone [https://github.com/evrensercan/NooteBook.git](https://github.com/evrensercan/NooteBook.git)