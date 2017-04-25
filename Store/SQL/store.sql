/*
Navicat MySQL Data Transfer

Source Server         : Local
Source Server Version : 50628
Source Host           : localhost:3306
Source Database       : store

Target Server Type    : MYSQL
Target Server Version : 50628
File Encoding         : 65001

Date: 2017-04-25 11:57:58
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for t_product
-- ----------------------------
DROP TABLE IF EXISTS `t_product`;
CREATE TABLE `t_product` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) NOT NULL,
  `category` varchar(100) NOT NULL,
  `price` decimal(8,2) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_product
-- ----------------------------
INSERT INTO `t_product` VALUES ('1', 'Tomato Soup', 'Groceries', '1.00');
INSERT INTO `t_product` VALUES ('2', 'Yo-yo', 'Toys', '3.75');
