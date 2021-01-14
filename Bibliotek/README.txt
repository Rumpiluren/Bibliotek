====OM PROJEKTET====
Detta projektet �r ett webbaserat API byggt f�r Centrumbiblioteket. Det �r ett .NET Core-projekt version 3.1.
Projektet best�r av en databas f�r f�rfattare, b�cker och l�netagare och har funktionalitet som till�ter att b�cker l�nas och �terl�mnas,
samt skapande av nya b�cker och publiceringar. Detta kan g�ras genom en extern applikation eller via mjukvara som SQL Server Management Studio eller Postman.

Om projektet k�rs laddar den som standard en vy som �terger alla aktiva l�n, sorterade efter datum f�r �terl�mning.
B�cker vars l�netagare �verskridit datum f�r �terl�mning sorteras i toppen.

Den avsedda anv�ndningen f�r mjukvaran �r att den ska laddas upp till en server. Detta kan g�ras p� flera s�tt, f�rslagsvis genom att anv�nda sig av Azure.

====KOMMA IG�NG====
Azure kr�ver att du har ett konto, vilket du kan skapa genom att klicka in dig p� f�ljande l�nk:
https://azure.microsoft.com/sv-se/free/dotnet/

Du beh�ver ocks� skapa en serverinstans genom server. Detta g�rs p� f�ljande l�nk: https://portal.azure.com

Med detta gjort �r projektet redo att publiceras. H�gerklicka p� projektet i Visual Studio, v�lj Publish > Azure.
F�lj instruktionerna, och n�r detta �r klart b�r projektet ligga uppe p� https://(valt namn).azurewebsites.net/

F�r att detta API ska fungera kr�vs en databas;
https://docs.microsoft.com/sv-se/azure/azure-sql/database/single-database-create-quickstart?tabs=azure-portal 

====TESTNING====
D� det f�reslagna anv�ndningsomr�det f�r detta API �r att det ska anv�ndas med hj�lp av en extern applikation f�resl�s ett integrationstest.
APIet ska anropas f�r att dubbelkolla att applikationen funkar som den ska. Det viktigaste �r att se till att funktionerna i APIets controllers fungerar;
	� L�na bok
	� �terl�mna bok
	� Skapa f�rfattare
	� Skapa publikation
	� Skapa bok
	� Skapa l�netagare
