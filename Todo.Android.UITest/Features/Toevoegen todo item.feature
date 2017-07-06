# language: nl-NL
Functionaliteit: 
  Om niets te vergeten wil ik als gebruiker een todo-item kunnen toevoegen
 
Scenario: Todo item toevoegen
    Stel ik heb de app gestart
    Als ik op de toevoegen knop druk
    En de volgende gegevens invul
	| Naam              | Beschrijving  |
	| Boodschappen doen | Voor vanavond |
    En ik sla deze gegevens op
	Dan moet de todo-item 'Boodschappen doen' zijn toegevoegd