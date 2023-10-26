# Personalregister
Detta är övning 1 i kursen C# hos Lexicon

## Vilka klasser bör ingå i projektet? ( skriven innan jag började koda )
Person, PersonRegister

## Vilka attribut och metoder bör ingå i dessa klasser?
Person: Förnamn, Efternamn, Personnummer, Telefonnummer, Adress, Postnummer, Postort

PersonRegister: Lista med personer, LäggTillPerson(), TaBortPerson(), VisaPersoner(), LaddaRegister(), SparaRegister()

## Det jag hann med under uppgiftens tid av ca 1 timme 45 minuter
Person klassen

PersonRegister klassen

Consolecommand klassen

grundläggande programm flöde

## Det jag lade till efteråt
LaddaRegister() och SparaRegister() i PersonRegister klassen

exekvering av kommandon

spara och ladda från fil

välja person att tex ta bort (Remove kommandet)

## Det som behöver förbättras/läggas till

Separera UI från logik, med andra ord separera Console write och read från logiken i Person och PersonRegister klassen

Gör klart Edit kommandot

Gör om PersonRegister klassen Från att ärva från ``List<Person>`` till att ha en ``List<Person>`` som attribut occh enbart exponera de metoder som behövs
