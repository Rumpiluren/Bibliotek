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

====TESTPLAN====
Då det föreslagna användningsområdet för detta API är att det ska användas med hjälp av en extern applikation föreslås ett regressionstest.
APIet ska anropas för att dubbelkolla att applikationen funkar som den ska.
Det viktigaste är att se till att funktionerna i APIets controllers fungerar. Gör detta med hjälp av Postman;
	• Låna bok
		• Om du matar in id korrekt: stämmer datumen? Är boken satt som lånad?
		• Skriv in fel värden: låna en bok som inte existerar, låna en bok som redan är lånad, låna via en lånetagare som inte existerar.
	• Återlämna bok
		• Om du matar in id korrekt: är boken satt som återlämnad? Kan du låna den igen?
	• Skapa författare
		• Har författaren fått alla värden korrekt?
	• Skapa publikation
		• Har publikationen fått alla värden korrekt? Stämmer authorId överrens med en existerande författare?
	• Skapa bok
		• Testa mata in inkorrekt publicationId.
		• Stämmer publicationId överrens med rätt publikation?
	• Skapa lånetagare
		• Testa skapa lånetagare som redan finns
		• Stämmer all data som matats in?

====GITHUB====
Hela projektet ligger på Github:
https://github.com/Rumpiluren/Bibliotek
