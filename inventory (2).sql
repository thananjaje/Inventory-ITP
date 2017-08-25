-- phpMyAdmin SQL Dump
-- version 4.2.11
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Aug 26, 2017 at 12:26 AM
-- Server version: 5.6.21
-- PHP Version: 5.6.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `inventory`
--

-- --------------------------------------------------------

--
-- Table structure for table `batch`
--

CREATE TABLE IF NOT EXISTS `batch` (
`batchNo` int(11) NOT NULL,
  `currentJob` varchar(30) NOT NULL,
  `noOfEmp` int(11) NOT NULL,
  `workingHrs` int(11) NOT NULL,
  `costPerUnit` int(11) NOT NULL,
  `units` int(11) NOT NULL,
  `total` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `jobs`
--

CREATE TABLE IF NOT EXISTS `jobs` (
`jobId` int(11) NOT NULL,
  `jobName` varchar(50) NOT NULL,
  `description` varchar(50) NOT NULL,
  `duration` int(11) NOT NULL,
  `noOfEmp` int(11) NOT NULL,
  `startingDate` date NOT NULL,
  `status` tinyint(1) NOT NULL DEFAULT '0'
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `jobs`
--

INSERT INTO `jobs` (`jobId`, `jobName`, `description`, `duration`, `noOfEmp`, `startingDate`, `status`) VALUES
(1, 'Design / Sketch', '', 20, 4, '2017-08-09', 1),
(2, 'Pattern Design', '', 20, 5, '2017-08-16', 1),
(3, 'Sample Making', '', 20, 0, '0000-00-00', 0),
(4, 'Production Pattern', '', 40, 0, '0000-00-00', 0),
(5, 'Grading', '', 0, 0, '0000-00-00', 0),
(6, 'Spreading', '', 80, 12, '0000-00-00', 1),
(7, 'Cutting', '', 40, 10, '0000-00-00', 1),
(8, 'Sorting/Bundling', '', 20, 10, '0000-00-00', 1),
(9, 'Sewing/Assembling', '', 100, 50, '0000-00-00', 1),
(10, 'Packing', '', 40, 15, '0000-00-00', 1),
(11, 'Despatch', '', 10, 5, '0000-00-00', 1),
(12, 'Inspection', '', 45, 15, '0000-00-00', 1),
(13, 'Pressing/ Finishing', '', 50, 10, '0000-00-00', 1),
(14, 'Final Inspection', '', 30, 10, '0000-00-00', 1),
(15, 'Marker Making', '', 20, 10, '0000-00-00', 1);

-- --------------------------------------------------------

--
-- Table structure for table `manemp`
--

CREATE TABLE IF NOT EXISTS `manemp` (
`empId` int(11) NOT NULL,
  `type` text NOT NULL,
  `noOfEmp` int(11) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `manemp`
--

INSERT INTO `manemp` (`empId`, `type`, `noOfEmp`) VALUES
(1, 'Designer', 3),
(2, 'Spreader', 10),
(3, 'Cutter', 15),
(4, 'Sewer', 25),
(5, 'Packing', 20),
(6, 'Supervisor', 5);

-- --------------------------------------------------------

--
-- Table structure for table `manufactraw`
--

CREATE TABLE IF NOT EXISTS `manufactraw` (
  `rawMaterialID` int(11) NOT NULL,
  `rawMaterialName` varchar(30) NOT NULL,
  `availableNow` int(11) NOT NULL,
  `reorderLevel` int(11) NOT NULL,
  `orderAmount` int(11) NOT NULL,
  `toOrder` tinyint(1) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `manufactraw`
--

INSERT INTO `manufactraw` (`rawMaterialID`, `rawMaterialName`, `availableNow`, `reorderLevel`, `orderAmount`, `toOrder`) VALUES
(1000, 'CLOTH', 100, 50, 200, 1),
(2000, 'THREAD', 75, 25, 100, 0),
(3000, 'YARN', 125, 100, 250, 1),
(4000, 'COTTON', 200, 100, 500, 1),
(5000, 'BUTTONS', 1000, 250, 0, 0),
(6000, 'RIBBON', 100, 50, 300, 1),
(7000, 'LACE', 400, 100, 0, 0),
(8000, 'FABRIC', 200, 50, 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `staff`
--

CREATE TABLE IF NOT EXISTS `staff` (
`id` int(3) NOT NULL,
  `username` varchar(10) NOT NULL,
  `password` varchar(20) NOT NULL,
  `fName` varchar(20) NOT NULL,
  `lName` varchar(20) NOT NULL,
  `address1` varchar(50) NOT NULL,
  `address2` varchar(50) NOT NULL,
  `email` varchar(50) NOT NULL,
  `dob` date NOT NULL,
  `nic` varchar(12) NOT NULL,
  `mobile` int(10) NOT NULL,
  `priv` tinyint(1) NOT NULL,
  `joined` date NOT NULL,
  `bSal` double NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `staff`
--

INSERT INTO `staff` (`id`, `username`, `password`, `fName`, `lName`, `address1`, `address2`, `email`, `dob`, `nic`, `mobile`, `priv`, `joined`, `bSal`) VALUES
(1, 'ADMIN', 'admin', '', '', '', '', '', '0000-00-00', '', 777777777, 1, '0000-00-00', 0),
(2, 'GOWSHI', 'gowshi', 'Gowshalini', 'Rajalingam', '', '', '', '1995-01-01', '955013063V', 777777777, 0, '2016-09-05', 13500),
(3, 'NUSHRA', 'nushra', 'Fathima', 'Fawmy', '', '', '', '1995-02-05', '955378542V', 777777777, 0, '2017-01-02', 13500),
(4, 'JAJE', 'jaje', 'Jajeththanan', 'Sabapathipillai', '', '', '', '1995-05-05', '951566908V', 777777777, 0, '2016-06-01', 13500),
(5, 'SHAFAN', 'shafan', 'Mohamed', 'Nazim', '', '', '', '1995-05-22', '199514303063', 777777777, 0, '2016-01-01', 13500),
(6, 'FAIZAAN', 'faizaan', 'Aamirul', 'Yakoob', '', '', '', '1995-03-05', '195868986V', 777777777, 0, '2017-06-18', 13500),
(7, 'MARK', 'mark', 'Shehan', 'Fernando', '', '', '', '1996-05-08', '199613803016', 777777777, 0, '2017-09-01', 13500),
(8, 'KAVISHA', 'kavisha', 'Kaviesha', 'Suriyarachchi', '', '', '', '1996-08-08', '199608680254', 777777777, 0, '2017-09-03', 13500),
(9, 'SAHI', 'sahi', 'sahinthini', 'N', '', '', '', '1994-06-08', '199428685928', 777777777, 0, '2016-03-09', 13500);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `batch`
--
ALTER TABLE `batch`
 ADD PRIMARY KEY (`batchNo`), ADD UNIQUE KEY `batchNo` (`batchNo`);

--
-- Indexes for table `jobs`
--
ALTER TABLE `jobs`
 ADD PRIMARY KEY (`jobId`);

--
-- Indexes for table `manemp`
--
ALTER TABLE `manemp`
 ADD PRIMARY KEY (`empId`), ADD UNIQUE KEY `empId` (`empId`);

--
-- Indexes for table `manufactraw`
--
ALTER TABLE `manufactraw`
 ADD PRIMARY KEY (`rawMaterialID`), ADD UNIQUE KEY `rawMaterialID` (`rawMaterialID`);

--
-- Indexes for table `staff`
--
ALTER TABLE `staff`
 ADD PRIMARY KEY (`id`), ADD UNIQUE KEY `nic` (`nic`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `batch`
--
ALTER TABLE `batch`
MODIFY `batchNo` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `jobs`
--
ALTER TABLE `jobs`
MODIFY `jobId` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=16;
--
-- AUTO_INCREMENT for table `manemp`
--
ALTER TABLE `manemp`
MODIFY `empId` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=7;
--
-- AUTO_INCREMENT for table `staff`
--
ALTER TABLE `staff`
MODIFY `id` int(3) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=10;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
