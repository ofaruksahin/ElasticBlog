# ElasticBlog'un Amacı

.Net 7 kullanılarak Domain Driven Design (DDD) ve Command Query Responsibility Segregation (CQRS) uyumlu proje geliştirilmesi.

# ElasticBlog'un Senaryosu

Bir Web API oluşturulacak ve bu api üzerinden blog yazıları oluşturulacak ve oluşturulan blog yazıları MySQL'de kaydediltiken sonra ElasticSearch'e senkronize edilecektir.
ElasticSearch'te indekslendikten sonra elasticsearch üzerinde fulltext search algoritmaları çalıştırılacaktır.

# Proje içeriğinde yapılacaklar
* ElasticSearch tabanlı bir loglama mimarisi kurulmalıdır. Fakat .net içerisinde bulunan mevcut ILogger interfacesini kullanmak istemiyorum. Kendi yazdığım sınıfla aylık veya günlük kendi istediğim formatta loglayarak metrikler çıkarmak istiyorum.
* Web API gelen tüm istekleri ve responseları elasticsearch'te information log olacak şekilde saklamak istiyorum.
* CQRS Pattern'e uygun ilerlenecek, okuma ve yazmalar farklı veritabanları üzerinde yapılacaktır. Yazma işlemlerini MySQL'den, okuma işlemlerini ElasticSearch'den yapılacaktır.
