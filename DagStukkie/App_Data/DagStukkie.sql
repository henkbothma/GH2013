-- MySQL Script generated by MySQL Workbench
-- 08/25/15 19:45:33
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema DagStukkie
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema DagStukkie
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `DagStukkie` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `DagStukkie` ;

-- -----------------------------------------------------
-- Table `DagStukkie`.`Gedagte`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `DagStukkie`.`Gedagte` (
  `idGedagte` INT NOT NULL AUTO_INCREMENT,
  `GedagteTeks` TEXT(200) NOT NULL,
  `ChangeOperator` VARCHAR(45) NOT NULL,
  `ChangeDate` DATETIME NOT NULL,
  `Status` VARCHAR(1) NOT NULL,
  PRIMARY KEY (`idGedagte`),
  UNIQUE INDEX `idGedagte_UNIQUE` (`idGedagte` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `DagStukkie`.`Gebed`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `DagStukkie`.`Gebed` (
  `idGebed` INT NOT NULL AUTO_INCREMENT,
  `GebedTeks` TEXT(500) NOT NULL,
  `ChangeOperator` VARCHAR(45) NOT NULL,
  `ChangeDate` DATETIME NOT NULL,
  `Status` VARCHAR(1) NOT NULL,
  PRIMARY KEY (`idGebed`),
  UNIQUE INDEX `idGebed_UNIQUE` (`idGebed` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `DagStukkie`.`Boodskap`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `DagStukkie`.`Boodskap` (
  `idBoodskap` INT NOT NULL AUTO_INCREMENT,
  `BoodskapTeks` MEDIUMTEXT NOT NULL,
  `ChangeOperator` VARCHAR(45) NOT NULL,
  `ChangeDate` DATETIME NOT NULL,
  `Status` VARCHAR(1) NOT NULL,
  PRIMARY KEY (`idBoodskap`),
  UNIQUE INDEX `idBoodskap_UNIQUE` (`idBoodskap` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `DagStukkie`.`Titel`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `DagStukkie`.`Titel` (
  `idTitel` INT NOT NULL AUTO_INCREMENT,
  `TitelTeks` TEXT(100) NOT NULL,
  `ChangeOperator` VARCHAR(45) NOT NULL,
  `ChangeDate` DATETIME NOT NULL,
  `Status` VARCHAR(1) NOT NULL,
  PRIMARY KEY (`idTitel`),
  UNIQUE INDEX `idTitel_UNIQUE` (`idTitel` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `DagStukkie`.`Skrif`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `DagStukkie`.`Skrif` (
  `idSkrif` INT NOT NULL AUTO_INCREMENT,
  `SkrifTeks` TEXT(50) NOT NULL,
  `BybelTeks` MEDIUMTEXT NOT NULL,
  `ChangeOperator` VARCHAR(45) NOT NULL,
  `ChangeDate` DATETIME NOT NULL,
  `Status` VARCHAR(1) NOT NULL,
  PRIMARY KEY (`idSkrif`),
  UNIQUE INDEX `idSkrif_UNIQUE` (`idSkrif` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `DagStukkie`.`TeksVers`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `DagStukkie`.`TeksVers` (
  `idTeksVers` INT NOT NULL AUTO_INCREMENT,
  `TeksVersNommer` TEXT(50) NOT NULL,
  `TeksVersTeks` TEXT(500) NOT NULL,
  `ChangeOperator` VARCHAR(45) NOT NULL,
  `ChangeDate` DATETIME NOT NULL,
  `Status` VARCHAR(1) NOT NULL,
  PRIMARY KEY (`idTeksVers`),
  UNIQUE INDEX `idTeksVers_UNIQUE` (`idTeksVers` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `DagStukkie`.`Master`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `DagStukkie`.`Master` (
  `idMaster` INT NOT NULL AUTO_INCREMENT,
  `DateToday` DATE NOT NULL,
  `BoodskapUID` INT NOT NULL,
  `GebedUID` INT NOT NULL,
  `GedagteUID` INT NOT NULL,
  `SkrifUID` INT NOT NULL,
  `TeksVersUID` INT NOT NULL,
  `TitelUID` INT NOT NULL,
  `ChangeOperator` VARCHAR(45) NOT NULL,
  `ChangeDate` DATETIME NOT NULL,
  `Status` VARCHAR(1) NOT NULL,
  PRIMARY KEY (`idMaster`),
  UNIQUE INDEX `idMaster_UNIQUE` (`idMaster` ASC),
  INDEX `fk_Boodskap_idx` (`BoodskapUID` ASC),
  INDEX `fk_Gebed_idx` (`GebedUID` ASC),
  INDEX `fk_Gedagte_idx` (`GedagteUID` ASC),
  INDEX `fk_Skrif_idx` (`SkrifUID` ASC),
  INDEX `fk_TeksVers_idx` (`TeksVersUID` ASC),
  INDEX `fk_Titel_idx` (`TitelUID` ASC),
  CONSTRAINT `fk_Boodskap`
    FOREIGN KEY (`BoodskapUID`)
    REFERENCES `DagStukkie`.`Boodskap` (`idBoodskap`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Gebed`
    FOREIGN KEY (`GebedUID`)
    REFERENCES `DagStukkie`.`Gebed` (`idGebed`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Gedagte`
    FOREIGN KEY (`GedagteUID`)
    REFERENCES `DagStukkie`.`Gedagte` (`idGedagte`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Skrif`
    FOREIGN KEY (`SkrifUID`)
    REFERENCES `DagStukkie`.`Skrif` (`idSkrif`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_TeksVers`
    FOREIGN KEY (`TeksVersUID`)
    REFERENCES `DagStukkie`.`TeksVers` (`idTeksVers`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Titel`
    FOREIGN KEY (`TitelUID`)
    REFERENCES `DagStukkie`.`Titel` (`idTitel`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
