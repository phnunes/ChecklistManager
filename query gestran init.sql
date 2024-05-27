CREATE DATABASE dbchecklist;

CREATE TABLE Vehicle (
	  VehicleID INT IDENTITY(1,1) PRIMARY KEY,
	  Name NVARCHAR(50)
);

CREATE TABLE Checklist (
	  ChecklistID INT IDENTITY(1,1) PRIMARY KEY
	  ,VehicleID INT
      ,Tires BIT
      ,Lights BIT
      ,Breaks BIT
      ,Engine BIT
      ,Electric BIT
      ,Observation NVARCHAR(500)
	  ,FOREIGN KEY (VehicleID) REFERENCES Vehicle(VehicleID)
);

INSERT INTO Vehicle VALUES('Fiat Uno Mille');
INSERT INTO Vehicle VALUES('Volkswagem Gol G4');
INSERT INTO Vehicle VALUES('Chevrolet Astra 4P 2.0');
INSERT INTO Vehicle VALUES('Chevrolet Montana 2012');

INSERT INTO Checklist VALUES(1, 0,1,1,1,1, 'Observação - Pneus gastos');
INSERT INTO Checklist VALUES(2, 1,0,1,1,1, 'Observação - Falha no farol esquerdo');
INSERT INTO Checklist VALUES(3, 0,1,1,1,0, 'Observação - Falhas ao ligar a partida');

