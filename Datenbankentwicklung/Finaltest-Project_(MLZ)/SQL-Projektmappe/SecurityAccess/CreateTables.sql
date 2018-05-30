
USE SecurityAccess;

-- Tables creation

CREATE TABLE Badgetypen
(
	BadgetypId	INT IDENTITY(1,1)			not null,
	Title		VARCHAR(20)					null,
	CONSTRAINT PK_Badgetyp PRIMARY KEY (BadgetypId)
);

CREATE TABLE Badge
(
	BadgeId		INT IDENTITY(1,1)			not null,
	BadgetypId	INT							DEFAULT 2,
	Vorname		VARCHAR(20)					DEFAULT 'Gast',
	Nachname	VARCHAR(20)					DEFAULT '',
	GueltigBis	DATE						DEFAULT cast(DATEADD(year, 1, GETDATE()) AS DATE),
	PINCode		VARCHAR(6)					DEFAULT '000000',
	ErrorCounter INT						DEFAULT 0,
	CONSTRAINT PK_Badge PRIMARY KEY (BadgeId),
	CONSTRAINT FK_Badge_Badgetyp FOREIGN KEY(BadgetypId)
		REFERENCES Badgetypen(BadgetypId),
);

CREATE TABLE Statustypen
(
	StatusId	INT IDENTITY(1,1)			not null,
	Title		VARCHAR(20)					null,
	CONSTRAINT PK_Statustyp PRIMARY KEY (StatusId)
);

CREATE TABLE Tuerschliesssysteme
(
	ObjektId		INT	IDENTITY(1,1)			not null,
	Bezeichnung		VARCHAR(50)					null,
	StatusId		INT							DEFAULT 2,
	CONSTRAINT PK_Tuerschliesssysteme PRIMARY KEY (ObjektId),
	CONSTRAINT FK_Tuerschliesssysteme_Statustyp FOREIGN KEY(StatusId)
		REFERENCES Statustypen(StatusId),
);

CREATE TABLE Badge_Tuerschliesssysteme
(
	BadgeId		INT	not null,
	ObjektId	INT	not null,
	CONSTRAINT PK_RelationComb PRIMARY KEY (BadgeId, ObjektId)
);

CREATE TABLE Logtabelle
(
	LogId			INT	IDENTITY(1,1)	not null,
	BadgeId			INT					not null,
	ObjektId		INT					not null,
	Title			VARCHAR(255)		null,
	Erfolgsstatus	VARCHAR(50)			null,
	Zeitstempel		DATETIME			DEFAULT CURRENT_TIMESTAMP,
	CONSTRAINT PK_LogtabelleId PRIMARY KEY (LogId)
);

-- UNIQUE constraints
ALTER TABLE Badgetypen
	ADD CONSTRAINT uq_badgetyp UNIQUE(Title);

ALTER TABLE Statustypen
	ADD CONSTRAINT uq_statustyp UNIQUE(Title);

-- CHECK constraints
ALTER TABLE Badge
	ADD
		CONSTRAINT ck_firstName CHECK (Vorname NOT LIKE '%[^ A-Za-zäöü]%'),
		CONSTRAINT ck_lastName CHECK (Nachname NOT LIKE '%[^ A-Za-zäöü]%'),
		CONSTRAINT ck_pinCode CHECK (PINCode LIKE '[0-9][0-9][0-9][0-9][0-9][0-9]');

-- INSERT basic table values which are needed
INSERT INTO Badgetypen (Title)
	VALUES	('Admin'),
			('Standard');

INSERT INTO Statustypen (Title)
	VALUES	('frei'),
			('gesperrt');
