# Name
Capo AB - Anställningsprov
.NET utvecklare
I detta prov kommer du att skapa ett kodbibliotek som konsumerar ett externt API och en
MVC webbapplikation i .NET som använder ditt kodbibliotek för att hämta och presentera
datan.
Uppgift
Det API du kommer att konsumera är
http://www.namnapi.se/ på den sidan hittar du
all dokumentation du behöver. Det är enbart
“v2” och JSON du behöver bygga stöd för.
I katalogen “Name” hittar du en Visual Studio
solution som grund för ditt projekt.
NameAPI
1. Fyll i metoderna som finns i
NameService filen. Du får inte ändra
några returvärden, befintliga klasser
eller metoder.
2. Validera indatan och hantera fel.
3. Kommentera koden i hela API
projektet.
Webbapplikation
1. Skapa ett Web Application (MVC) projekt i samma solution och lägg in en referens till
ditt kodbibliotek.
2. Skapa en ny MVC kontroller som konsumerar ditt kodbibliotek.
a. Hämta 10 namn med NameType=Both och NameGender=Both när man först
laddar sidan.
b. Lägg till stöd för att välja namntyp, kön samt antal och en knapp som laddar
om sidan med dina val.
c. Lägg in stöd för att hämta flera namn till listan med hjälp av Ajax enligt de val
som är valda. Ajax anropet måste gå via din webbapplikation och inte direkt
emot namnapi.se.
3. Visa datan enligt wireframe nedan.
