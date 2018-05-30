DELETE FROM Tuerschliesssysteme;
INSERT INTO Tuerschliesssysteme (Bezeichnung)
	VALUES	('T�r 1'),
			('T�r 2'),
			('T�r 3'),
			('T�r 4'),
			('T�r 5'),
			('T�r 6'),
			('T�r 7'),
			('T�r 8'),
			('T�r 9');

DELETE FROM Badge;
INSERT INTO Badge (BadgetypId, Vorname, Nachname, GueltigBis, PINCode)
	VALUES	(1, 'Serafino', 'Fornito', '2018-12-31', '456789'),
			(1, 'Donato', 'Fornito', '2018-12-31', '123456'),
			(2, 'Remo', 'M�ller', '2018-04-16', '010101'),
			(2, 'Sarah', 'Ziegenhagen', '2018-12-31', '943761'),
			(2, 'Rudolf', 'Hochstrasser', '2017-12-31', '098765'),
			(1, 'Valentino', 'Fornito', '2017-12-31', '000111');
SELECT * FROM Badge;

DELETE FROM Badge_Tuerschliesssysteme;
INSERT INTO Badge_Tuerschliesssysteme(BadgeId, ObjektId)
	VALUES	(1, 1),
			(1, 7),
			(3, 1),
			(3, 9),
			(3, 8),
			(3, 6),
			(4, 1),
			(4, 3),
			(5, 1),
			(5, 3),
			(6, 1),
			(6, 3),
			(6, 7);