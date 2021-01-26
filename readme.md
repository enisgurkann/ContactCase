### Contact Case


## Build Status
| Build server    | Platform       | Status      |
|-----------------|----------------|-------------|
| Github Actions  | ubuntu |![](https://github.com/enisgurkann/ContactCase/workflows/.NET%20CI/badge.svg) |


##### Contact API
Ýletiþim bilgileri saklanýr.<br>
Ekle/güncelle/sil ve listele iþlemleri yapýlýr.<br>
Rapor isteklerini dinler.<br>
Rapor oluþturup "oluþturuldu" mesajý iletir.

#### Report API
Rapor verileri saklanýr.<br>
Mevcut raporlarý listeler.<br>
Rapor oluþturuldu mesajýný dinler.<br>
Rapor mesajlarýný veritabanýna kaydeder.

#### Web Application
Ýletiþim bilgisi ekle/güncelle/sil yapabilir.<br>
Mevcut iletiþim bilgileri listesini görebilir.<br>
Rapor talebinde bulunabilir.<br>
Kayýtlý raporlarý görebilir.

### Projenin çalýþtýrýlmasý hakkýnda
* Proje ana dizininde `docker-compose up -d` diyerek projeyi ayaða kaldýrabilirsiniz.
* Her API kendisi için ayrý veritabanýna sahiptir.
* Web application herhangi bir veritabaný ile haberleþmez. Kafkadan gelen mesajlarý dinleyebilir veya API'lara http isteði yapabilir.
* API'lar birbirlerinin veritabanlarýna eriþmezler. Arada iletiþim gerekli olmasý durumunda Kafka üzerinden mesajlarýný iletirler.

** Projede loglama için <strong>Serilog</strong> kullandým fakat herhangi bir daðýtýk yapýya baðlý deðil. Sadece <strong>Development</strong> modunda <strong>Information</strong> seviyesinde console loglama yapýyor.

WebHost: https://localhost:5001<br>
Contact API: https://localhost:5011<br>
Report API: https://localhost:5021

#### Teknolojiler
* .Net 5.0
* EntityFramework Core 5.0
* Swagger(OpenAPI v3 UI)
* Mediator(CQRS)
* AutoMapper
* FluentValidation
* Serilog
* xUnit
* Kafka
* Docker
* Docker Compose
* PostgreSQL 12.5
