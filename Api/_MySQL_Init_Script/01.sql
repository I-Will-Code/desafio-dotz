CREATE DATABASE IF NOT EXISTS test_dotz_api;
USE test_dotz_api;

CREATE TABLE __efmigrationshistory (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
);
INSERT INTO `__efmigrationshistory` VALUES ('20220728123414_Initial','6.0.7'),('20220728130902_FixEntities','6.0.7'),('20220728173948_AddUserProduct','6.0.7'),('20220728184331_NewConfigs','6.0.7');

CREATE TABLE `Users` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `Email` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Password` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`)
); 
INSERT INTO `Users` VALUES (1,'marcos.bnu@gmail.com','123456'),(2,'williamf.werling@gmail.com','##2265');

CREATE TABLE `Addresses` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `UserId` bigint NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Addresses_UserId` (`UserId`),
  CONSTRAINT `FK_Addresses_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `Users` (`Id`) ON DELETE CASCADE
);
INSERT INTO `Addresses` VALUES (1,'Rua 7 de Setembro, Velha, Blumenau/SC',2),(2,'Rua XV de Novembro, centro, Blumenau/SC',1);

CREATE TABLE `Orders` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `UserId` bigint NOT NULL,
  `Delivered` tinyint(1) NOT NULL,
  `CreatedAt` datetime(6) NOT NULL DEFAULT '2022-07-28 15:43:30.980983',
  PRIMARY KEY (`Id`),
  KEY `IX_Orders_UserId` (`UserId`),
  CONSTRAINT `FK_Orders_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `Users` (`Id`) ON DELETE CASCADE
);
INSERT INTO `Orders` VALUES (1,2,0,'0001-01-01 00:00:00.000000'),(2,1,1,'2022-07-28 15:43:30.980983');

CREATE TABLE `Products` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`)
);
INSERT INTO `Products` VALUES (1,'Margarina Doriana 200g'),(2,'Shampoo Elseve 300ml'),(3,'Barbeador Gillete');

CREATE TABLE `Scores` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `UserId` bigint NOT NULL,
  `Total` bigint NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Scores_UserId` (`UserId`),
  CONSTRAINT `FK_Scores_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `Users` (`Id`) ON DELETE CASCADE
) ;
INSERT INTO `Scores` VALUES (8,2,2000),(10,2,3800);

CREATE TABLE `ScoreExtracts` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `ScoreId` bigint NOT NULL,
  `CreatedAt` datetime(6) NOT NULL,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_ScoreExtracts_ScoreId` (`ScoreId`),
  CONSTRAINT `FK_ScoreExtracts_Scores_ScoreId` FOREIGN KEY (`ScoreId`) REFERENCES `Scores` (`Id`) ON DELETE CASCADE
);
INSERT INTO `ScoreExtracts` VALUES (7,8,'2022-07-28 11:20:15.720077','Saldo: 1800'),(8,8,'2022-07-28 11:21:01.493565','Saldo: 1900'),(9,8,'2022-07-28 11:21:37.778185','Saldo: 2000'),(10,10,'2022-07-28 16:05:42.169917','Saldo: 1800'),(11,10,'2022-07-28 16:05:52.107324','Saldo: 3800');

CREATE TABLE `UsersProducts` (
  `UserId` bigint NOT NULL,
  `ProductId` bigint NOT NULL,
  PRIMARY KEY (`UserId`,`ProductId`),
  KEY `IX_UsersProducts_ProductId` (`ProductId`),
  CONSTRAINT `FK_UsersProducts_Products_ProductId` FOREIGN KEY (`ProductId`) REFERENCES `Products` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_UsersProducts_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `Users` (`Id`) ON DELETE CASCADE
);

INSERT INTO `UsersProducts` VALUES (1,1),(1,2);
