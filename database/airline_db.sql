-- MySQL dump 10.13  Distrib 8.0.41, for Win64 (x86_64)
--
-- Host: localhost    Database: reservation
-- ------------------------------------------------------
-- Server version	8.0.41

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `bookings`
--

DROP TABLE IF EXISTS `bookings`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `bookings` (
  `BookingID` int NOT NULL AUTO_INCREMENT,
  `CustomerID` int DEFAULT NULL,
  `FlightID` int DEFAULT NULL,
  `BookingDate` datetime DEFAULT NULL,
  `Status` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`BookingID`),
  KEY `CustomerID` (`CustomerID`),
  KEY `FlightID` (`FlightID`),
  CONSTRAINT `bookings_ibfk_1` FOREIGN KEY (`CustomerID`) REFERENCES `customers` (`CustomerID`),
  CONSTRAINT `bookings_ibfk_2` FOREIGN KEY (`FlightID`) REFERENCES `flights` (`FlightID`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bookings`
--

LOCK TABLES `bookings` WRITE;
/*!40000 ALTER TABLE `bookings` DISABLE KEYS */;
INSERT INTO `bookings` VALUES (1,1,1,'2025-11-08 22:02:45','Confirmed'),(2,2,2,'2025-11-08 22:02:45','Confirmed'),(3,3,3,'2025-11-08 22:02:45','Confirmed'),(4,1,2,'2025-11-14 20:05:52','Confirmed'),(5,1,1,'2025-11-14 20:10:15','Confirmed'),(6,2,1,'2025-11-14 20:10:29','Confirmed'),(7,3,3,'2025-12-07 18:07:52','Confirmed'),(8,1,2,'2025-12-14 18:25:10','Confirmed'),(9,1,2,'2025-12-14 18:56:32','Confirmed'),(10,1,1,'2025-12-15 20:52:30','Confirmed'),(11,1,1,'2025-12-15 21:31:17','Confirmed'),(12,1,21,'2025-12-17 21:18:03','Confirmed');
/*!40000 ALTER TABLE `bookings` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cancellations`
--

DROP TABLE IF EXISTS `cancellations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cancellations` (
  `CancellationID` int NOT NULL AUTO_INCREMENT,
  `BookingID` int DEFAULT NULL,
  `CancellationDate` datetime DEFAULT NULL,
  `Reason` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`CancellationID`),
  KEY `BookingID` (`BookingID`),
  CONSTRAINT `cancellations_ibfk_1` FOREIGN KEY (`BookingID`) REFERENCES `bookings` (`BookingID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cancellations`
--

LOCK TABLES `cancellations` WRITE;
/*!40000 ALTER TABLE `cancellations` DISABLE KEYS */;
INSERT INTO `cancellations` VALUES (1,2,'2025-11-08 22:02:45','Customer change of plans'),(2,2,'2025-12-17 20:11:57','Customer change of plans'),(3,2,'2025-12-17 20:12:06','Customer change of plans');
/*!40000 ALTER TABLE `cancellations` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customers`
--

DROP TABLE IF EXISTS `customers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `customers` (
  `CustomerID` int NOT NULL AUTO_INCREMENT,
  `Username` varchar(50) NOT NULL,
  `PasswordHash` varchar(256) NOT NULL,
  `FullName` varchar(100) DEFAULT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `Phone` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`CustomerID`),
  UNIQUE KEY `Username` (`Username`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customers`
--

LOCK TABLES `customers` WRITE;
/*!40000 ALTER TABLE `customers` DISABLE KEYS */;
INSERT INTO `customers` VALUES (1,'john_doe','test123','John Doe','john@example.com','9876543210'),(2,'sarah_smith','test123','Sarah Smith','sarah@example.com','9898989898'),(3,'ayush_kumar','test123','Ayush Kumar','ayush@example.com','9090909090'),(5,'johndoe','test1','John Doe','john@example.com','9876543210'),(6,'sarahsmith','test12','Sarah Smith','sarah@example.com','9898989898'),(7,'ayushkumar','test123','Ayush Kumar','ayush@example.com','9090909090');
/*!40000 ALTER TABLE `customers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `flights`
--

DROP TABLE IF EXISTS `flights`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `flights` (
  `FlightID` int NOT NULL AUTO_INCREMENT,
  `FlightNumber` varchar(20) NOT NULL,
  `Source` varchar(50) NOT NULL,
  `Destination` varchar(50) NOT NULL,
  `DepartureDate` date DEFAULT NULL,
  `DepartureTime` time DEFAULT NULL,
  `ArrivalDate` date DEFAULT NULL,
  `ArrivalTime` time DEFAULT NULL,
  `SeatsAvailable` int DEFAULT NULL,
  `TicketPrice` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`FlightID`),
  UNIQUE KEY `FlightNumber` (`FlightNumber`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `flights`
--

LOCK TABLES `flights` WRITE;
/*!40000 ALTER TABLE `flights` DISABLE KEYS */;
INSERT INTO `flights` VALUES (1,'AI101','Delhi','Mumbai','2025-11-10','09:00:00','2025-11-10','11:05:00',116,5500.00),(2,'AI205','Mumbai','Bangalore','2025-11-11','14:30:00','2025-11-11','16:15:00',92,4500.00),(3,'6E330','Kolkata','Chennai','2025-11-12','08:15:00','2025-11-12','10:55:00',149,6200.00),(16,'AI103','Delhi','Mumbai','2025-01-25','09:00:00','2025-01-25','11:00:00',50,4500.00),(17,'AI104','Mumbai','Delhi','2025-01-26','15:00:00','2025-01-26','17:00:00',40,4600.00),(18,'AI201','Delhi','Bangalore','2025-01-22','08:30:00','2025-01-22','11:15:00',60,5200.00),(19,'IG861','Chennai','Bangalore','2025-01-22','07:30:00','2025-01-22','08:15:00',60,2200.00),(20,'IG283','Mumbai','Bangalore','2025-01-24','17:30:00','2025-01-24','18:55:00',60,5200.00),(21,'AI367','Delhi','Kolkata','2025-01-23','08:30:00','2025-01-23','10:15:00',59,4900.00);
/*!40000 ALTER TABLE `flights` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-01-17 22:16:06
