# Personalregister
Detta �r �vning 1 i kursen C# hos Lexicon

## Vilka klasser b�r ing� i projektet? ( skriven innan jag b�rjade koda )
Person, PersonRegister

## Vilka attribut och metoder b�r ing� i dessa klasser?
Person: F�rnamn, Efternamn, Personnummer, Telefonnummer, Adress, Postnummer, Postort

PersonRegister: Lista med personer, L�ggTillPerson(), TaBortPerson(), VisaPersoner(), LaddaRegister(), SparaRegister()

## Det jag hann med under uppgiftens tid av ca 1 timme 45 minuter
Person klassen

PersonRegister klassen

Consolecommand klassen

grundl�ggande programm fl�de

## Det jag lade till efter�t
LaddaRegister() och SparaRegister() i PersonRegister klassen

exekvering av kommandon

spara och ladda fr�n fil

v�lja person att tex ta bort (Remove kommandet)

## Det som beh�ver f�rb�ttras/l�ggas till

Separera UI fr�n logik, med andra ord separera Console write och read fr�n logiken i Person och PersonRegister klassen

G�r klart Edit kommandot

G�r om PersonRegister klassen Fr�n att �rva fr�n ``List<Person>`` till att ha en ``List<Person>`` som attribut occh enbart exponera de metoder som beh�vs
