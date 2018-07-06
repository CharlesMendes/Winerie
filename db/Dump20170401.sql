-- MySQL dump 10.13  Distrib 5.7.12, for Win64 (x86_64)
--
-- Host: localhost    Database: dbwinerie
-- ------------------------------------------------------
-- Server version	5.7.14

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `TBD_PERFILUSUARIO`
--

DROP TABLE IF EXISTS `TBD_PERFILUSUARIO`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `TBD_PERFILUSUARIO` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nomePerfil` varchar(50) NOT NULL,
  `descricao` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `TBD_PERFILUSUARIO`
--

LOCK TABLES `TBD_PERFILUSUARIO` WRITE;
/*!40000 ALTER TABLE `TBD_PERFILUSUARIO` DISABLE KEYS */;
INSERT INTO `TBD_PERFILUSUARIO` VALUES 
(1,'ADMIN','Perfil que deve ter acesso a todas as funcionalidades da aplicacao.'),
(2,'USUARIO','Perfil que deve ter acesso as informacoes, importacoes e relatorios especificos.');
/*!40000 ALTER TABLE `TBD_PERFILUSUARIO` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `TBD_STATUS`
--

DROP TABLE IF EXISTS `TBD_STATUS`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `TBD_STATUS` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nomeStatus` varchar(50) NOT NULL,
  `descricao` varchar(250) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `UK_TBD_STATUS_Nome` (`nomeStatus`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `TBD_STATUS`
--

LOCK TABLES `TBD_STATUS` WRITE;
/*!40000 ALTER TABLE `TBD_STATUS` DISABLE KEYS */;
INSERT INTO `TBD_STATUS` VALUES 
(1,'API_DADOS_BUSCANDO','Buscando dados da API TINY'),
(2,'API_DADOS_CONCLUIDO','A busca de dados da API TINY foi concluida com sucesso'),
(3,'API_DADOS_ERRO','Ocorreu algum erro ao consumir a API TINY'),
(4,'ARQUIVO_PEDIDOS_GERANDO','Gerando arquivo de pedidos'),
(5,'ARQUIVO_PEDIDOS_CONCLUIDO','A geração do arquivo de pedidos foi concluída'),
(6,'ARQUIVO_PEDIDOS_ERRO','Ocorreu algum erro na geração do arquivo de pedido');
/*!40000 ALTER TABLE `TBD_STATUS` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `TBD_TIPOARQUIVO`
--

DROP TABLE IF EXISTS `TBD_TIPOARQUIVO`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `TBD_TIPOARQUIVO` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nomeTipoArquivo` varchar(50) NOT NULL,
  `padraoFormatoNomeArquivo` varchar(100) NOT NULL,
  `descricao` varchar(250) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `UK_TBD_TIPOARQUIVO_Nome` (`nomeTipoArquivo`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `TBD_TIPOARQUIVO`
--

LOCK TABLES `TBD_TIPOARQUIVO` WRITE;
/*!40000 ALTER TABLE `TBD_TIPOARQUIVO` DISABLE KEYS */;
INSERT INTO `TBD_TIPOARQUIVO` VALUES 
(1,'Arquivo de Pedidos','Pedido_{0}.txt','Layout do arquivo de pedidos.');
/*!40000 ALTER TABLE `TBD_TIPOARQUIVO` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `TBD_TIPORELATORIO`
--

DROP TABLE IF EXISTS `TBD_TIPORELATORIO`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `TBD_TIPORELATORIO` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nomeTipoRelatorio` varchar(50) NOT NULL,
  `versaoTipoRelatorio` int(11) NOT NULL,
  `descricao` varchar(250) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `UK_TBD_TIPORELATORIO_Nome` (`nomeTipoRelatorio`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `TBD_TIPORELATORIO`
--

-- LOCK TABLES `TBD_TIPORELATORIO` WRITE;
-- /*!40000 ALTER TABLE `TBD_TIPORELATORIO` DISABLE KEYS */;
-- INSERT INTO `TBD_TIPORELATORIO` VALUES 
-- (1,'Conciliação Geral',1,'Relatorio utilizado para listar de forma macro todos os registros que foram conciliados atraves da funcionalidade Conciliação de Pagamento'),
-- (2,'Conciliação Analítico',1,'Relatorio utilizado para listar de forma analitica todos os registros que foram conciliados atraves da funcionalidade Conciliação de Pagamento, e os registros que nao tiveram pagamentos correspondentes'),
-- (3,'Uso da Ferramenta',1,'Relatorio utilizado para visualizar o uso da ferramenta pelos usuarios cadastrados.');
-- /*!40000 ALTER TABLE `TBD_TIPORELATORIO` ENABLE KEYS */;
-- UNLOCK TABLES;

--
-- Table structure for table `TBN_USUARIO`
--

DROP TABLE IF EXISTS `TBN_USUARIO`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `TBN_USUARIO` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(50) NOT NULL,
  `login` varchar(20) NOT NULL,
  `senha` varchar(10) NOT NULL,
  `dataUltimoLogin` datetime DEFAULT NULL,
  `idPerfilUsuario` int(11) NOT NULL,
  `isAtivo` bit(1) NOT NULL,
  `email` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `UK_TBN_USUARIO_Login` (`login`),
  KEY `FK_TBN_USUARIO_TBD_PERFILUSUARIO` (`idPerfilUsuario`),
  CONSTRAINT `FK_TBN_USUARIO_TBD_PERFILUSUARIO` FOREIGN KEY (`idPerfilUsuario`) REFERENCES `TBD_PERFILUSUARIO` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `TBN_USUARIO`
--

LOCK TABLES `TBN_USUARIO` WRITE;
/*!40000 ALTER TABLE `TBN_USUARIO` DISABLE KEYS */;
INSERT INTO `TBN_USUARIO` VALUES 
(1,'Charles Mendes','charles.mendes','123','2017-01-31 04:03:56',1,'','contato@charlesmendes.com'),
(2,'João Matheus','joao.matheus','123',NULL,1,'','jma_ata@outlook.com'),
(3,'Carlos Almeida','carlos.almeida','123','2017-01-17 18:06:31',2,'','carlosalmeida@winerie.com');
/*!40000 ALTER TABLE `TBN_USUARIO` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `TBR_EXPORTACAO`
--

DROP TABLE IF EXISTS `TBR_EXPORTACAO`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `TBR_EXPORTACAO` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `idTipoArquivo` int(11) NOT NULL,
  `idUsuarioExportacao` int(11) NOT NULL,
  `dataInicioProcessamento` datetime NOT NULL,
  `dataFimProcessamento` datetime DEFAULT NULL,
  `idStatus` int(11) NOT NULL,
  `qtdSucesso` int(11) DEFAULT NULL,
  `qtdIgnorada` int(11) DEFAULT NULL,
  `nomeArquivoGerado` varchar(100) DEFAULT NULL,
  `nomeArquivoErro` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_TBR_EXPORTACAO_TBD_TIPOARQUIVO` (`idTipoArquivo`),
  KEY `FK_TBR_EXPORTACAO_TBN_USUARIO` (`idUsuarioExportacao`),
  KEY `FK_TBR_EXPORTACAO_TBD_STATUS` (`idStatus`),
  CONSTRAINT `FK_TBR_EXPORTACAO_TBD_STATUS` FOREIGN KEY (`idStatus`) REFERENCES `TBD_STATUS` (`id`),
  CONSTRAINT `FK_TBR_EXPORTACAO_TBD_TIPOARQUIVO` FOREIGN KEY (`idTipoArquivo`) REFERENCES `TBD_TIPOARQUIVO` (`id`),
  CONSTRAINT `FK_TBR_EXPORTACAO_TBN_USUARIO` FOREIGN KEY (`idUsuarioExportacao`) REFERENCES `TBN_USUARIO` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=38 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `TBR_EXPORTACAO`
--

LOCK TABLES `TBR_EXPORTACAO` WRITE;
/*!40000 ALTER TABLE `TBR_EXPORTACAO` DISABLE KEYS */;
/*!40000 ALTER TABLE `TBR_EXPORTACAO` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'dbwinerie'
--
/*!50003 DROP PROCEDURE IF EXISTS `ZerarBase` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`apl_userwinerie`@`%` PROCEDURE `ZerarBase`()
BEGIN
	DELETE FROM TBR_EXPORTACAO;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
