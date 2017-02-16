# ElasticSearch dióhéjban
Az ElasticSearch dióhéjban című NetAcademia tanfolyam kódtár kiegészítése

A tanfolyam a [korábbi alkalom](https://github.com/gplesz/ELKFree201611) folytatása, az ott épített infrastruktúrát fogjuk kihasználni. A tanfolyam önállóan követhető, de tanácsoljuk az előző tanfolyam anyagainak és videóinak áttekintését.

## Bevezetés
Az ElasticSearch dióhéjban tanfolyamból már tartottunk egy alkalmat, amikoris az infrastruktúrát állítottuk fel Windows környezetben. Az infrastruktúra a következő lett:

![](https://github.com/gplesz/ELKFree201611/blob/master/images/attekintes.png?raw=true)

## Emlékeztető

 - Az **ELK** nevű gépen telepítettünk egy *ElasticSearch* szervert, 
 - egy *RabbitMQ* üzenetsort, 
 - és a kettőt összekötöttük egy megfelelő *Logstash* konfigurációval, annak érdekében, hogy az üzenetsorba beérkező csomagok az ElasticSearch adatbázisába kerüljenek a megfelelő konverziót követően. 

 - Az **APP** nevű gépre telepítettünk egy RabbitMQ postát (exchange) és üzenetsort (message queue), 
 - majd konfiguráltuk annak érdekében, hogy ami üzenet megérkezik a postára, az átkerüljön az üzenetsorba, onnan pedig **shovel** segítségével az **ELK** szerverünk üzenetsorába, ahonnan már megy a folyamat az ElasticSearch felé.

 - Végül az **ELK**-n telepítettünk egy *Kibana* webalkalmazást, hogy az ElasticSearch által tárolt adatokat meg tudjuk jeleníteni.
 
 - Mindezt elindítottuk, és az APP szerver RabbitMQ postájában egy-két üzenet generálásával kipróbáltuk a működést.
 
 

## Videók
A tanfolyam most készülő és a [megelőző tanfolyam](https://github.com/gplesz/ELKFree201611) videóit [itt lehet elérni](http://www.netacademia.hu/ELSfree-elastic-search--nutshell). 

- Az előző tanfolyamot követően telepítettem a Logstash és a Kibana szervizeket az NSSM segítségével, a következő módon:
- nssm install Kibana
  A megjelenő ablakban pedig a Path mezőbe: **C:\ProgramData\chocolatey\lib\kibana\kibana-4.5.4-windows\bin\kibana.bat**
  A Startup directory mezőbe: **C:\ProgramData\chocolatey\lib\kibana\kibana-4.5.4-windows\bin**

- nssm install Logstash
  Hasonlóan a Kibanához a Path mezőbe: **c:\logstash\bin\logstash.cmd**
  és **c:\logstash\bin\**

## Előkészületek

## Letöltések
- Az előző tanfolyamon elkészült virtuális gépeket innen lehet letölteni: [ELK szerver](https://vidibitstorage.blob.core.windows.net/elsfree/w2k12r2-elk.rar) és [APP szerver](https://vidibitstorage.blob.core.windows.net/elsfree/w2k12r2-app.rar)

- A használathoz a korábbi alkalomhoz hasonlóan VMWare ingyenes Player kell, amit [innen lehet letölteni](http://www.vmware.com/products/player/playerpro-evaluation.html)

- A VMWare Windows 10-re telepítéséhez lehet, hogy  [le kell tiltani a Credential Guard/Device Guard](https://kb.vmware.com/selfservice/microsites/search.do?language=en_US&cmd=displayKC&externalId=2146361) nevű szolgáltatást. Részletes leírás a linken.

A VMWare az első induláskor egy ingyenes regisztrációval indítható. Ehhez egy e-mail címet kér. Az ingyenes regisztrációhoz nyugodtan használjátok a saját e-mail címet, vagy az enyémet: gabor.plesz@gmail.com, vagy egyszerűen egy *@mailinator.com végű címet.

### Kicsomagolás, stb. 
A letöltött virtuális gépeket kicsomagoljuk. Belépés a windows szerverekbe: **Administrator** jelszó: **Windows2012**

- Készítünk egy tesztalkalmazást Visual Studio segítségével, amivel naplót fogunk tudni generálni. Ehhez telepíteni fogunk a tanfolyam elején egy Visual Studio 2015 Community változatot, de elő lehet készülni a telepítéssel.

### Visual Studio 2015 Community telepítése
A tanfolyamon **Windows** operációs rendszeren futó [Visual Studio 2015 Community](https://www.visualstudio.com/vs/community/) fejlesztői keretrendszert fogunk használni. Azt mondanám, hogy a tanfolyam valószínűleg majdnem minden Visual Studio változattal követhető (2008/2010/2012/2013/2015), de mivel ez elérhető, ingyenes és a legfrissebb, és majd ahogy látjuk, egy jó parancssorban két parancs kiadásával telepíthető, nem nagyon van értelme alternatívákat keresni.

A tanfolyamon ezt az alkalmazást fogjuk használni. Ingyenesen elérhető önálló fejlesztők, nyílt forráskódú projektek, akadémiai kutatók számára. Továbbá oktatási célokra és kis (max 5 fős) fejlesztőcsapatoknak.

Letölteni az előző linkről vagy [innen lehet](https://www.visualstudio.com/free-developer-offers/). Ehhez a tanfolyamhoz telepíteni az alapértelmezett beállításokkal elég.

Vagy, 

[ha valaki szeret újat kipróbálni](http://netacademia.blog.hu/2016/11/03/hogyan_keszitsunk_chocolatey_csomagot_az_alkalmazasunkhoz), akkor telepítheti [Chocolatey](https://chocolatey.org/) csomagkezelővel is. 

[Erről összefoglaló ezen a tanfolyamon az első videó](http://www.netacademia.hu/CsharpFree-programozasi-alapismeretek-c-nyelven)

[Telepítés](https://chocolatey.org/install): ehhez 

#### 1. lépés
indítsunk egy adminisztrátori parancssort ([elevated command prompt](http://www.computerhope.com/jargon/e/elevated.htm)), 

#### 2. lépés
tegyük vágólapra ezt (igen, az egészet!):

**@powershell -NoProfile -ExecutionPolicy Bypass -Command "iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))" && SET "PATH=%PATH%;%ALLUSERSPROFILE%\chocolatey\bin"**

#### 3. lépés
majd a parancssorunkba illesszük be és futtassuk le.

Ezzel telepítettünk egy csomagkezelőt, innentől kezdve nem kell letölteni és telepíteni kattintgatásokkal az alkalmazásainkat, hanem a csomagkezelőnkre bizhatjuk a dolgot, legalábbis [jelenleg már több, mint 4000 alkalmazás esetében](https://chocolatey.org/packages).

Ha van csomagkezelőnk, a Visual Studio Community telepítése [adminisztrátori parancssorból így megy](https://chocolatey.org/packages/VisualStudio2015Community): 

#### 4. lépés

**cinst visualstudio2015community**

Ezzel meg is vagyunk az előkészületekkel, a többit a tanfolyamon folytatjuk!

## tanfolyam
Elindítjuk mindkét virtuális gépet a vmx kiterjesztésű állományra kétszer kattintva. Mivel a virtuális gépek mozogtak, így át kell állítani az App szerveren a Shovel-t, hogy a megfelelő IP címre küldje a naplónkat (admin/shovel management menüpont a RabbitMQ webes kezelőfelületén, App szerver: http://localhost:15672/#/).

Ehhez az előző Shovel-t töröljük, majd az újat az ELK szerver IP címére állítjuk. Például:

- forrás url: **amqp://netacademia:neta@localhost**, forrás queue: **app-logging-queue**
- cél url: **amqp://netacademia:neta@192.168.23.129**, cél queue: **app-logging-queue-central**

Figyeljük meg, hogy az url-ben a @ előtt a felhasználó neve és jelszava megjelenik.

Mivel a Kibana és a Logstash már fut, elindítjuk az Elasticsearch szervert az ELK gépen a **C:\ProgramData\chocolatey\lib\elasticsearch\tools\elasticsearch-2.3.1\bin>** könyvtárból az **elasticsearch.bat** futtatásával parancssorból.

## Kibana elérése távolról
A Kibana portját (5601) megnyitottuk az ELK szerveren a következő parancssal:

**netsh advfirewall firewall add rule name="Open Port 5601" dir=in action=allow protocol=TCP localport=5601**
Figyeljünk arra, hogy a Kibana ingyenes csomagja nem autentikál, így aki látja a portot az mindenhez hozzáfér.

## Elasticsearch windows service telepítése
Az eddigiekktől eltérően nem nssm-et használunk, mivel az elasticsearch saját windows szervizt tud futtatni, a **C:\ProgramData\chocolatey\lib\elasticsearch\tools\elasticsearch-2.3.1\bin>** könytárban adjuk ki a **service install** parancsot parancssorból, és a processzorarchitektúrának megfelelő szerviz települ.

Ez alapértelmezetten manual-ra van állítva, állítsuk át automatikusan elindulóra. Ehhez az elasticsearch saját service managerét érdemes használni (**service manager** parancs ugyaninnen), mert itt még a java beállításokat is meg tudjuk adni.

## Szervizek indulási sorrendje:

A parancssorból **sc config "Logstash" depend="elasticsearch-service-x64/RabbitMQ"** paranccsal be tudjuk állítani, hogy a Logstash csak azután induljon el, miután az Elasticsearch ÉS a RabbitMQ szervizek már elindultak.

## Visual Studio projekt

Új projekt megnyitása (Installed\Templates\Visual C#\Windows, ezen belül konzol alkalmazás), majd a Package manager Console-ból [a megfelelő csomag](https://www.nuget.org/packages/rabbitmq.log4net.gelf.appender/) telepítése a következő parancssal:

PM> **Install-Package rabbitmq.log4net.gelf.appender**

Majd a csomag [weboldaláról](https://github.com/hancengiz/rabbitmq.log4net.gelf.appender) használjuk ezt a konfigurációt, módosítva az eredeti beállításokat:

IP cím, Exchange, Username, Password

```
<configSections>
    <section name="log4net" type="log4net.Config.Log4NetConfigurationSectionHandler,Log4net" />
  </configSections>

  <log4net>
    <appender name="rabbitmq.gelf.appender" type="rabbitmq.log4net.gelf.appender.GelfRabbitMqAppender, rabbitmq.log4net.gelf.appender">
      <HostName value="192.168.196.128" />
      <VirtualHost value="/" />
      <Port value="5672" />
      <Exchange value="app-logging-exchange" />
      <Username value="netacademia" />
      <Password value="neta" />
      <Facility value="sample-application" />
    </appender>

    <root>
      <level value="ERROR" />
      <appender-ref ref="rabbitmq.gelf.appender" />
    </root>
  
  </log4net>
```

Az APP szerveren kinyitjuk a RabbitMQ portját:

**netsh advfirewall firewall add rule name="Open Port 5672" dir=in action=allow protocol=TCP localport=5672**

Létrehozunk egy **topic** alapú exchange-et: **test-x** néven az app szerveren, a **Durability** lenyíló értéke legyen **Transient** (az alapértelmezett Durable helyett), minden más beállítás alapértelmezett. 

Illetve hozzunk létre egy Bindingot az Exchange-ből az **app-logging-queue** felé, a routing paraméter legyen #.

## Windows napló begyűjtése RabbitMQ-ba
A logstash képes windows naplót gyűjteni és ezt a RabbitMQ felé továbbküldeni így (ez egy példa, most nem próbáltuk ki):

```
input {
	eventlog {
	    type => "Win32-EventLog"
		logfile => ["System","Security","Application"]
	}
 
output {
 rabbitmq {
		host => "localhost"
		user     => "netacademia"
		password => "neta"
		exchange    => "app-logging-exchange"
  exchange_type => "direct"
	}
}
```

A Logstash a konfigurációját innen szedi: **C:\logstash\conf.d\neta.conf**, mivel a C:\logstash\bin\logstash.cmd-t indítja az NSSM.
