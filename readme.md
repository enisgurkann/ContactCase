### Contact Case


##### Contact API
�leti�im bilgileri saklan�r.<br>
Ekle/g�ncelle/sil ve listele i�lemleri yap�l�r.<br>
Rapor isteklerini dinler.<br>
Rapor olu�turup "olu�turuldu" mesaj� iletir.

#### Report API
Rapor verileri saklan�r.<br>
Mevcut raporlar� listeler.<br>
Rapor olu�turuldu mesaj�n� dinler.<br>
Rapor mesajlar�n� veritaban�na kaydeder.

#### Web Application
�leti�im bilgisi ekle/g�ncelle/sil yapabilir.<br>
Mevcut ileti�im bilgileri listesini g�rebilir.<br>
Rapor talebinde bulunabilir.<br>
Kay�tl� raporlar� g�rebilir.

### Projenin �al��t�r�lmas� hakk�nda
* Apileri ve Web Projesini start ederk projeyi �al��t�rabilirsiniz
* Her API kendisi i�in ayr� veritaban�na sahiptir.
* Web application herhangi bir veritaban� ile haberle�mez. RabbitMQ gelen mesajlar� dinleyebilir veya API'lara http iste�i yapabilir.
* API'lar birbirlerinin veritabanlar�na eri�mezler. Arada ileti�im gerekli olmas� durumunda RabbitMQ �zerinden mesajlar�n� iletirler.

** Projede loglama i�in <strong>Serilog</strong> kulland�m fakat herhangi bir da��t�k yap�ya ba�l� de�il. Sadece <strong>Development</strong> modunda <strong>Information</strong> seviyesinde console loglama yap�yor.

WebHost: https://localhost:5001<br>
Contact API: https://localhost:5011<br>
Report API: https://localhost:5021

#### Teknolojiler
* .Net 5.0
* EntityFramework Core 5.0
* Swagger(OpenAPI v3 UI)
* RabbitMQ
* PostgreSQL 12.5
