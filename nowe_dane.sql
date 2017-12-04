EXEC DodajPracownika 45630359871, 'Paweł', 'Urnak', 'Nope';
EXEC DodajPracownika 70958434100, 'Paweł', 'Niecik', 'Nope';
EXEC DodajPracownika 24330335234, 'Mikołaj', 'Miałczek', 'Nope';
EXEC DodajPracownika 82064823079, 'Natalia', 'Mokrowiec', 'Nope';
EXEC DodajPracownika 48333035732, 'Zdzisław', 'Jawczyk', 'Nope';
EXEC DodajPracownika 70001598425, 'Agnieszka', 'Miałczek', 'Nope';
EXEC DodajPracownika 35114395122, 'Jerzy', 'Niecik', 'Nope';
EXEC DodajPracownika 39814255797, 'Jan', 'Urnak', 'Nope';
EXEC DodajPracownika 49842862166, 'Mikołaj', 'Motrow', 'Nope';
EXEC DodajPracownika 98029076089, 'Natalia', 'Rikiel', 'Nope';
EXEC DodajPracownika 62274606743, 'Agnieszka', 'Kacik', 'Nope';
EXEC DodajPracownika 22775604967, 'Anna', 'Korczak', 'Nope';
EXEC DodajPracownika 25975169586, 'Adam', 'Motrow', 'Nope';
EXEC DodajPracownika 31118142389, 'Ryszard', 'Nowak', 'Nope';
EXEC DodajPracownika 40379439467, 'Natalia', 'Urban', 'Nope';
EXEC DodajPracownika 83882011376, 'Joanna', 'Miszczak', 'Nope';
EXEC DodajPracownika 73304406659, 'Zdzisław', 'Nowak', 'Nope';
EXEC DodajPracownika 88883368914, 'Michał', 'Ordawka', 'Nope';
EXEC DodajPracownika 27021623699, 'Paweł', 'Mokrowiec', 'Nope';
EXEC DodajPracownika 86542903289, 'Natalia', 'Miszczak', 'Nope';
EXEC DodajPracownika 52544019894, 'Marta', 'Mokrowiec', 'Nope';
EXEC DodajPracownika 93823696986, 'Agnieszka', 'Motrow', 'Nope';
EXEC DodajPracownika 99207779191, 'Jan', 'Urnak', 'Nope';
EXEC DodajPracownika 95966563543, 'Natalia', 'Miszczak', 'Nope';
EXEC DodajPracownika 64344295397, 'Piotr', 'Okrasa', 'Nope';
EXEC DodajPracownika 30894384069, 'Piotr', 'Ordawka', 'Nope';
EXEC DodajPracownika 21090500201, 'Adam', 'Nowak', 'Nope';
EXEC DodajPracownika 33552971430, 'Michał', 'Mokrowiec', 'Nope';
EXEC DodajPracownika 84187563291, 'Piotr', 'Ordawka', 'Nope';
EXEC DodajPracownika 72479595468, 'Ryszard', 'Kacik', 'Nope';
EXEC DodajPracownika 67268286457, 'Anna', 'Okrasa', 'Nope';
EXEC DodajPracownika 25620288764, 'Mikołaj', 'Mokrowiec', 'Nope';
EXEC DodajPracownika 48517249581, 'Michał', 'Jawczyk', 'Nope';
EXEC DodajPracownika 84188647794, 'Ryszard', 'Urban', 'Nope';
EXEC DodajPracownika 31025192551, 'Natalia', 'Rikiel', 'Nope';
EXEC DodajPracownika 74586329831, 'Michał', 'Niecik', 'Nope';
EXEC DodajPracownika 98719279903, 'Ryszard', 'Okrasa', 'Nope';
EXEC DodajPracownika 30287450943, 'Piotr', 'Ordawka', 'Nope';
EXEC DodajPracownika 56645370367, 'Jerzy', 'Motrow', 'Nope';
EXEC DodajPracownika 81263400305, 'Zdzisław', 'Ordawka', 'Nope';
EXEC DodajPracownika 19345743706, 'Jan', 'Miałczek', 'Nope';
EXEC DodajPracownika 89923051889, 'Jan', 'Motrow', 'Nope';
EXEC DodajPracownika 98624240848, 'Agnieszka', 'Mokrowiec', 'Nope';
EXEC DodajPracownika 10434488933, 'Jerzy', 'Ordawka', 'Nope';
EXEC DodajPracownika 40306975989, 'Zdzisław', 'Okrasa', 'Nope';
EXEC DodajPracownika 74958210551, 'Agnieszka', 'Motrow', 'Nope';
EXEC DodajPracownika 73792304173, 'Piotr', 'Okrasa', 'Nope';
EXEC DodajPracownika 40504413746, 'Jan', 'Miałczek', 'Nope';
EXEC DodajPracownika 97383789805, 'Agnieszka', 'Mokrowiec', 'Nope';
EXEC DodajPracownika 30934786517, 'Piotr', 'Miszczak', 'Nope';

EXEC NowaAmunicja '9mm', 1500000;
EXEC NowaAmunicja '7.72', 56784;
EXEC NowaAmunicja '5.56', 345266;
EXEC NowaAmunicja '.45ACP', 4534535;
EXEC NowaAmunicja '.357SIG', 8696354;
EXEC NowaAmunicja '.44 MAG', 7878679;
EXEC NowaAmunicja '.308 Win', 6794323;
EXEC NowaAmunicja '.300 MAG', 2356356;

EXEC NowaBron 'AK-47';
EXEC NowaBron 'AK-74';
EXEC NowaBron 'M-16';
EXEC NowaBron 'MP5';
EXEC NowaBron 'Peacemaker';
EXEC NowaBron 'SPAS-12';
EXEC NowaBron 'Glock 19';

DECLARE @bron BronArr;
DECLARE @amunicja AmmoArr;

INSERT INTO @bron
VALUES (1,15),(2,1000),(3,5);

INSERT INTO @amunicja
VALUES (1,2222),(2,1000000),(4,20000);

EXEC NoweZamowienie '06-01-2018',@amunicja,@bron,'Jaki certyfikat?',0,'Ma być wysłane w 1 kontenerze';