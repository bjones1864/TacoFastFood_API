--CREATE DATABASE FastFoodTacoDB;
--GO

--USE FastFoodTacoDB;
--GO

--CREATE TABLE Taco(
--    ID int Identity(1,1) Primary Key,
--    Name NVARCHAR(255),
--    Cost REAL,
--    SoftShell BIT,
--    Chips BIT
--);
--GO

--CREATE TABLE Drink(
--    ID int Identity(1,1) Primary Key,
--    Name NVARCHAR(255),
--    Cost REAL,
--    Slushie BIT
--);
--GO

--INSERT INTO Taco(Name, Cost, SoftShell, Chips)
--VALUES ('Double Layer Taco', 2.49, 0, 0),
--('Soft Taco', 1.69, 1, 0),
--('Potato Taco', 1.00, 1, 0),
--('Nacho Cheese Chips Tacos', 2.39, 0, 1),
--('Chicken Taco', 3.49, 1, 0);
--GO

--INSERT INTO Drink(Name, Cost, Slushie)
--VALUES ('Fiesta Blast', 2.00, 0),
--('Gamer Drink', 3.50, 0),
--('Fiesta Blast Freeze', 2.00, 1),
--('Blue Raspberry Strawberry Slushie', 2.50, 1),
--('Water', 0, 0);
--GO

--SELECT * FROM Taco;
--SELECT * FROM Drink;

--USE FastFoodTacoDB;
--GO

--CREATE TABLE Users(
--    ID int Identity(1,1) NOT NULL Primary Key,
--    Name NVARCHAR(255),
--    ApiKey NVARCHAR(10)
--);
--GO

--INSERT INTO Users(Name, ApiKey)
--VALUES ('Grant Chirpus', 'abcdefghij'),
--('Admin', '1234567890'),
--('Not a Hacker', 'hds87b4n2p');
--GO

--SELECT * FROM Users;
