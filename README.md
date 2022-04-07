Kasper Ruys S097156 2EACL2

# Onderwerp API

## Eigen API
Voor de eigen gemaakte API ga ik informatie over het spel League of Legends weergeven. De informatie van de "champions" die je kan spelen. Dit zal al de namen van speelbare champions zijn en wat meer informatie over hun. Als er uitbreiding nodig is kunnen de stats op level 1 hierbij toegevoegd worden. De "factions" waar deze champions deel van zijn en het verhaal van deze facties. De rol van deze champions (locatie, tank, support, ...). Voor veel-op-veel relatie worden de items die gebruikt. Normaal gezien kan iedereen alle items kopen, maar ik ga als een "hulpmiddel" enkel de items die het best zijn om te kopen. Een champion kan meerdere items hebben en een item kan dus ook gebruikt worden door meerdere champions. Als laatste tabel ga ik om het makkelijker te maken een 1-1 relatie maken met champions en het achtergrond verhaal. Dit zorgt ervoor dat je het verhaal van enkel 1 champion kan aanvragen en deze makkelijk kan lezen ipv deze mee te sturen in de Champion tabel.

## Externe API
Als externe API bekijken we de dnd5eapi:  http://www.dnd5eapi.co/

• Welke resources kan je opvragen? Classes, Races, Equipmet, Spells, ...

• welke representaties worden ondersteunt ? JSON

• wat is de default representatie ? JSON

• welke paging mogelijkheden? Er zijn geen paging mogelijkheden.

• welke opzoek/filtermogelijkheden zijn er? URL via query strings.

• Is er hypermedia aanwezig ? Ja

• welke verbs worden ondersteund ? Enkel GET voor de API te beschermen.

• hoe navigeer ik naar relationships ? Via hypermedia

• Welke status codes worden gebruikt ? 200 en 404

• Hoe gaat men om met verschillende versies van interface ? Er worden geen gegeven.

De API maakt gebruik van zelfstandige naamwoorden om de entiteiten te weergeven en gebruikt meervouden wanneer het gaat over collecties. Bijvoorbeeld: Spells, Features & Classes. De resources van de API blijken geen ID te hebben of de mogelijkheid te geven om op ID op te zoeken. Wanneer je bijvoorbeeld Classes opzoekt krijg je een array van alles classes met als index de naam en de url voor de class. Als je de API aanspreekt krijg je de info terug in JSON formaat en stuurt media type terug met de request die je doet naar de API. 
![alt text](https://github.com/AP-Elektronica-ICT/cloud-api-2020-2021-KasperRuys/blob/main/Screenshots/Foto2.PNG "REST")
Aangezien de API enkel GET request toelaat is er niet veel om op te zoeken in verband met werkwoorden en in het geval van de GET request worden er geen werkwoorden in de url of ergens anders gebruikt. De API maakt gebruik van HATEOAS. Je krijgt de url links van de relevant informatie te zien. Als voorbeeld wanneer je naar een Class gaat "Barbarian", zie je alle spells en skills deze class heeft met een url link naar de informatie over deze spells en skills.
![alt text](https://github.com/AP-Elektronica-ICT/cloud-api-2020-2021-KasperRuys/blob/main/Screenshots/foto3.PNG "List")




### Update log

27/02: Opstarten van het project. Nieuwe API gemaakt en de weather controller verwijdert.

18/03: Heb een paar Nuget packages moeten instaleren nadat ik visual studio heb herinstalleerd. Champion en Faction tabellen toegevoegd met wat test data om te zien of de tabellen worden aangemaakt met de juiste data. In de appsetting mijn aangemaakte database een eigen naam gegeven zodat die makelijker te vinden is in de lijst.

19/03: Begonnen aan de readme file. Heb het snel in word geschreven en gekopieerd dus dit moet nog naar Markdown veranderd worden.

28/03: Controller voor Champion aangemaakt. Ik kan nu alle HTTP verbs doen met champions. Heb aanpassingen gemaakt in de launchsetting.json zodat wanneer ik de API opstart die automatisch naar mijn eigen gemaakte controller gaat en wat meer test data in de Database initializer gestoken om duidelijker verschillen te zien met de HTTP request.

12/04: Ik heb de Readme file geupdate naar markdown omdat er door eerst word te gebruiken vreemde overbodige ASCII code in stak. Ik heb de tabellen aangepast. Champion had ROL als informatie, maar dit zou beter een andere tabel zijn dus ik heb dit aangepast in het Champion script en Role toegevoegd. De Faction van de champions is nu ook toegevoegd en de controller heeft dezelfde requests als champion. De rollen controller is momenteel nog leeg. De dummydata van de tabel is aangepast naar een 4-tal echte data. Ik probeer de faction mee te tonen als ik champion weergeef, maar krijg null te zien ondanks ik Include, Where en SingleOrDefault heb toegevoegd bij de get request. (Iets om te vragen)

18/04: Research van externe API afgerond en de markdown ook af en mooi gemaakt. De laatste tabellen gekozen voor de API en ook aangemaakt. De request voor deze tabellen moeten nog worden toegevoegd. 

25/04: Tabellen aangemaakt en minsten Getrequests gegeven en ID get requests. Proberen het .Include => null probleem op te lossen zonder success momenteel. De veel op veel relatie tabel aangemaakt en code klaargezet om communicatie toe te laten in het contextscriptje met onmodelcreating. Ook de Readme aangepast omdat de bulletpoints niet mooi onder elkaar waren.


Startup aangepast om authenticatie toe te kunnen laten.

02/05: Client aangemaakt. Communicatie met de online API toegevoegd en het begin van communicatie mij eigen API. Momenteel enkel get request naar de Champion tabel. Andere Httprequest staan klaar maar moeten nog bij de html code worden bijgewerkt

