# Net9ApiOdev

Bu proje .NET 9 API dersi için hazırladığım e-ticaret ödev projesidir.

## Projede Neler Var?
Projede Katmanlı Mimari (Entities, Services, Controllers) yapısını kullandım. Veritabanı olarak SQLite ve Entity Framework Core kullandım.

Şu işlemler yapılabiliyor:
* Kullanıcı ekleme ve listeleme
* Kategori ekleme
* Kategoriye bağlı ürün ekleme ve listeleme

## Nasıl Çalıştırılır?
Projeyi indirdikten sonra veritabanının oluşması için "Package Manager Console" ekranında şu komutu çalıştırmanız yeterlidir:

Update-Database

Proje çalıştığında /api/users, /api/categories ve /api/products adreslerine istek atılabilir.