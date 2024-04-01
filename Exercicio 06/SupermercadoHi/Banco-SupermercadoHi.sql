-- --------------------------------------------------------
-- Servidor:                     127.0.0.1
-- Versão do servidor:           8.0.36 - MySQL Community Server - GPL
-- OS do Servidor:               Win64
-- HeidiSQL Versão:              12.6.0.6819
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Copiando estrutura do banco de dados para supermercadohi
DROP DATABASE IF EXISTS `supermercadohi`;
CREATE DATABASE IF NOT EXISTS `supermercadohi` /*!40100 DEFAULT CHARACTER SET utf8mb3 */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `supermercadohi`;

-- Copiando estrutura para tabela supermercadohi.alimento
DROP TABLE IF EXISTS `alimento`;
CREATE TABLE IF NOT EXISTS `alimento` (
  `id` int NOT NULL AUTO_INCREMENT,
  `data_validade` datetime NOT NULL,
  `nome` varchar(200) NOT NULL,
  `peso` decimal(10,2) DEFAULT NULL,
  `id_elemento_estoque` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_Alimento_Elemento_Estoque1_idx` (`id_elemento_estoque`),
  CONSTRAINT `fk_Alimento_Elemento_Estoque1` FOREIGN KEY (`id_elemento_estoque`) REFERENCES `elemento_estoque` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela supermercadohi.alimento: ~0 rows (aproximadamente)
INSERT INTO `alimento` (`id`, `data_validade`, `nome`, `peso`, `id_elemento_estoque`) VALUES
	(1, '2024-04-04 12:00:00', 'Feijão', 1.00, 1),
	(2, '2024-12-31 16:32:00', 'Arroz', 5.00, 2),
	(3, '2024-04-03 23:27:31', 'Açúcar', 5.00, 5),
	(4, '2024-04-06 16:17:18', 'Iogurte', 0.75, 6),
	(5, '2024-11-10 00:01:02', 'Macarrão', 0.50, 8),
	(6, '2024-06-19 13:03:24', 'Sal', 1.00, 11),
	(7, '2025-04-12 16:15:28', 'Farofa', 0.35, 13),
	(8, '2024-08-31 22:10:21', 'Café', 0.50, 15);

-- Copiando estrutura para tabela supermercadohi.elemento_estoque
DROP TABLE IF EXISTS `elemento_estoque`;
CREATE TABLE IF NOT EXISTS `elemento_estoque` (
  `id` int NOT NULL AUTO_INCREMENT,
  `preco` decimal(10,2) NOT NULL,
  `cnpj_fabricante` varchar(50) NOT NULL,
  `custo` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela supermercadohi.elemento_estoque: ~0 rows (aproximadamente)
INSERT INTO `elemento_estoque` (`id`, `preco`, `cnpj_fabricante`, `custo`) VALUES
	(1, 12.00, '12.345.678/0001-90', 8.22),
	(2, 25.99, '23.456.789/0001-81', 15.80),
	(3, 22.99, '34.567.890/0001-72', 15.00),
	(4, 5.99, '45.678.901/0001-63', 3.09),
	(5, 19.99, '56.789.012/0001-54', 16.00),
	(6, 8.99, '67.890.123/0001-45', 6.78),
	(7, 22.99, '78.901.234/0001-36', 14.18),
	(8, 10.29, '89.012.345/0001-27', 8.90),
	(9, 18.99, '90.123.456/0001-18', 10.50),
	(10, 7.99, '01.234.567/0001-09', 5.98),
	(11, 6.78, '11.345.678/0001-90', 1.99),
	(12, 15.00, '22.456.789/0001-81', 11.81),
	(13, 13.00, '55.789.012/0001-54', 10.00),
	(14, 2.25, '44.678.901/0001-63', 1.19),
	(15, 14.99, '33.567.890/0001-72', 7.98);

-- Copiando estrutura para tabela supermercadohi.estoque
DROP TABLE IF EXISTS `estoque`;
CREATE TABLE IF NOT EXISTS `estoque` (
  `id` int NOT NULL AUTO_INCREMENT,
  `quantidade` int NOT NULL,
  `id_elemento_Estoque` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_Estoque_Elemento_Estoque_idx` (`id_elemento_Estoque`),
  CONSTRAINT `fk_Estoque_Elemento_Estoque` FOREIGN KEY (`id_elemento_Estoque`) REFERENCES `elemento_estoque` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela supermercadohi.estoque: ~0 rows (aproximadamente)
INSERT INTO `estoque` (`id`, `quantidade`, `id_elemento_Estoque`) VALUES
	(1, 100, 1),
	(2, 19, 2),
	(3, 89, 3),
	(4, 45, 4),
	(5, 50, 5),
	(6, 108, 6),
	(7, 18, 7),
	(8, 12, 8),
	(9, 78, 9),
	(10, 41, 10),
	(11, 85, 11),
	(12, 49, 12),
	(13, 130, 13),
	(14, 41, 14),
	(15, 50, 15);

-- Copiando estrutura para tabela supermercadohi.pesquisa_mercado
DROP TABLE IF EXISTS `pesquisa_mercado`;
CREATE TABLE IF NOT EXISTS `pesquisa_mercado` (
  `id` int NOT NULL AUTO_INCREMENT,
  `satisfacao` int NOT NULL,
  `instituto_pesquisa` varchar(200) DEFAULT NULL,
  `id_produto_limpeza` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_Pesquisa_Mercado_Produto_Limpeza1_idx` (`id_produto_limpeza`),
  CONSTRAINT `fk_Pesquisa_Mercado_Produto_Limpeza1` FOREIGN KEY (`id_produto_limpeza`) REFERENCES `produto_limpeza` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela supermercadohi.pesquisa_mercado: ~0 rows (aproximadamente)
INSERT INTO `pesquisa_mercado` (`id`, `satisfacao`, `instituto_pesquisa`, `id_produto_limpeza`) VALUES
	(1, 85, 'Instituto Boa Pesquisa', 3),
	(2, 89, 'Avaliando Sua Compra', 4),
	(3, 93, 'Instituto de Pesquisa Certa', 7),
	(5, 68, 'De Olho na Nota ', 5),
	(6, 71, 'Compre bem Avaliações', 6),
	(7, 82, 'Instituto Boa Pesquisa', 2),
	(8, 65, 'De Acordo Notas e Avaliações', 1);

-- Copiando estrutura para tabela supermercadohi.produto_limpeza
DROP TABLE IF EXISTS `produto_limpeza`;
CREATE TABLE IF NOT EXISTS `produto_limpeza` (
  `id` int NOT NULL AUTO_INCREMENT,
  `data_validade` datetime NOT NULL,
  `nome` varchar(200) NOT NULL,
  `volume` decimal(10,3) NOT NULL DEFAULT (0),
  `id_elemento_estoque` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_Alimento_Elemento_Estoque1_idx` (`id_elemento_estoque`),
  CONSTRAINT `fk_Alimento_Elemento_Estoque10` FOREIGN KEY (`id_elemento_estoque`) REFERENCES `elemento_estoque` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela supermercadohi.produto_limpeza: ~0 rows (aproximadamente)
INSERT INTO `produto_limpeza` (`id`, `data_validade`, `nome`, `volume`, `id_elemento_estoque`) VALUES
	(1, '2025-12-31 12:22:32', 'Desinfetante', 1.000, 3),
	(2, '2024-12-31 23:37:48', 'Desengordurante', 0.350, 4),
	(3, '2026-03-31 23:37:00', 'Amaciante', 1.500, 7),
	(4, '2024-06-19 10:00:00', 'Shampoo', 0.350, 9),
	(5, '2029-08-31 00:00:00', 'Limpa Vidros', 0.250, 10),
	(6, '2024-11-18 23:59:59', 'Creme de Pentear', 0.800, 12),
	(7, '2024-04-12 00:30:50', 'Detergente', 0.150, 14);

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
