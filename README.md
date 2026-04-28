# Heure pour assistant vocal

Seul ou en binôme, en adoptant une approche TDD, vous élaborez une classe qui traduit une heure en texte "user friendly" pour un assistant vocal. L'heure doit dont être exprimée de la façon la plus "humaine" possible.
Chacun des cas suivant SANS EXCEPTION doit être implémenté avec TDD.

**Important : L'absence de commit git pour chacune des 3 étapes (Red, green, refactor) de la majorité des itérations TDD de l'atelier rendra l'atelier hors-sujet (oublis ponctuels tolérés).**

## Énoncé
Concevez en TDD une méthode de classe (static) qui, à partir d'un DateTime, renvoie une chaîne de caractères contenant le texte de l'heure.
Les étapes recommandées sont :
* Traduire une heure "pile" du matin : ex 7:00 => "sept heures du matin", 1:00 => "une heure du matin"
* Traduire une heure "pile" de l'après-midi : ex 14:00 => "deux heures de l'après-midi"
* Traduire une heure "pile" spéciale : ex 12:00 => "midi", 00:00 => "minuit"
* Gérer les tranches normales de 5 minutes de la première demi-heure : ex 12:10 => "midi dix", 15:25 => "trois heures vingt-cinq de l'après-midi", 00:15 => "minuit et quart"
* Gérer les tranches spéciales de 5 minutes après la première demi-heure : ex 8:45 => "neuf heures moins le quart", 12:35 => "une heure moins vingt-cinq de l'après-midi"
* Gérer les minutes précises : ex 8:48 => "neuf heures moins dix du matin à deux minutes près", 12:04 => "Midi cinq à une minute prés"

## Rendu
Un lien github ou gitlab vers un dépôt consultable par mail à sylvain.labasse@mail-formateur.net avant le 04/05/26.