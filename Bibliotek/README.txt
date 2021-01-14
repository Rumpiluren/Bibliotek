====OM PROJEKTET====
Detta projektet är ett webbaserat API byggt för Centrumbiblioteket. Det är ett .NET Core-projekt version 3.1.
Projektet består av en databas för författare, böcker och lånetagare och har funktionalitet som tillåter att böcker lånas och återlämnas,
samt skapande av nya böcker och publiceringar. Detta kan göras genom en extern applikation eller via mjukvara som SQL Server Management Studio eller Postman.

Om projektet körs laddar den som standard en vy som återger alla aktiva lån, sorterade efter datum för återlämning.
Böcker vars lånetagare överskridit datum för återlämning sorteras i toppen.

Den avsedda användningen för mjukvaran är att den ska laddas upp till en server. Detta kan göras på flera sätt, förslagsvis genom att använda sig av Azure.

====KOMMA IGÅNG====
Azure kräver att du har ett konto, vilket du kan skapa genom att klicka in dig på följande länk:
https://azure.microsoft.com/sv-se/free/dotnet/

Du behöver också skapa en serverinstans genom server. Detta görs på följande länk: https://portal.azure.com

Med detta gjort är projektet redo att publiceras. Högerklicka på projektet i Visual Studio, välj Publish > Azure.
Följ instruktionerna, och när detta är klart bör projektet ligga uppe på https://(valt namn).azurewebsites.net/

För att detta API ska fungera krävs en databas;
https://docs.microsoft.com/sv-se/azure/azure-sql/database/single-database-create-quickstart?tabs=azure-portal 

====TESTNING====
Då det föreslagna användningsområdet för detta API är att det ska användas med hjälp av en extern applikation föreslås ett integrationstest.
APIet ska anropas för att dubbelkolla att applikationen funkar som den ska. Det viktigaste är att se till att funktionerna i APIets controllers fungerar;
	• Låna bok
	• Återlämna bok
	• Skapa författare
	• Skapa publikation
	• Skapa bok
	• Skapa lånetagare
