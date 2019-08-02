/*
SQLyog 企业版 - MySQL GUI v8.14 
MySQL - 5.5.54 : Database - xinxingxiang
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`xinxingxiang` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `xinxingxiang`;

/*Table structure for table `project` */

DROP TABLE IF EXISTS `project`;

CREATE TABLE `project` (
  `ID` char(32) NOT NULL COMMENT '主键ID',
  `PROJECT_NAME` varchar(100) DEFAULT NULL COMMENT '项目名称',
  `PROJECT_E_NAME` varchar(100) DEFAULT NULL COMMENT '英文名',
  `REMARK` varchar(500) DEFAULT NULL COMMENT '备注',
  `ADD_TIME` date DEFAULT NULL COMMENT '添加时间',
  `ADD_USER_ID` char(32) DEFAULT NULL COMMENT '添加人ID',
  `ADD_USER_NAME` varchar(50) DEFAULT NULL COMMENT '添加人姓名',
  `PROJECT_JIANCHENG` varchar(100) DEFAULT NULL COMMENT '项目简称',
  `IS_DEL` int(11) DEFAULT '0' COMMENT '是否删除0否1是',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `project` */

insert  into `project`(`ID`,`PROJECT_NAME`,`PROJECT_E_NAME`,`REMARK`,`ADD_TIME`,`ADD_USER_ID`,`ADD_USER_NAME`,`PROJECT_JIANCHENG`,`IS_DEL`) values ('2d2f38e593e646758c5b4a5fba517da4','deeed',NULL,'sssss','2017-02-06','651b7b6fe9ed11e6a466a08cfd1d4922','系统管理员','dd',0),('620bb03055ce446ca38ba4be07774aad','剪发1',NULL,'剪发','2017-02-06','651b7b6fe9ed11e6a466a08cfd1d4922','系统管理员','剪发',0),('63b834fb0fbc4cc2b04e24bf3c3b85cd','ddd',NULL,'dd','2017-02-06','651b7b6fe9ed11e6a466a08cfd1d4922','系统管理员','dd',0),('7a4716138ae24812b61d63cccb510956','剪发',NULL,'剪发','2017-02-06','651b7b6fe9ed11e6a466a08cfd1d4922','系统管理员','剪',0),('cd01a5480d4f4f4f862d62fdeda06a44','222',NULL,'222','2017-02-06','651b7b6fe9ed11e6a466a08cfd1d4922','系统管理员','222',0),('f7da4cd07c06406bba068013802670ba','烫发',NULL,'烫发','2017-02-06','651b7b6fe9ed11e6a466a08cfd1d4922','系统管理员','烫',0);

/*Table structure for table `sys_user` */

DROP TABLE IF EXISTS `sys_user`;

CREATE TABLE `sys_user` (
  `ID` char(32) NOT NULL COMMENT '主键',
  `USER_NAME` varchar(50) DEFAULT NULL COMMENT '姓名',
  `USER_LOGIN_NAME` varchar(50) DEFAULT NULL COMMENT '登录名',
  `PASSWORD` varchar(50) DEFAULT NULL COMMENT '密码',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `sys_user` */

insert  into `sys_user`(`ID`,`USER_NAME`,`USER_LOGIN_NAME`,`PASSWORD`) values ('651b7b6fe9ed11e6a466a08cfd1d4922','系统管理员','admin','admin');

/*Table structure for table `vip_sale` */

DROP TABLE IF EXISTS `vip_sale`;

CREATE TABLE `vip_sale` (
  `ID` char(32) NOT NULL COMMENT '主键ID',
  `SALE_PROJECT` varchar(500) DEFAULT NULL COMMENT '消费项目',
  `SALE_MONEY` double DEFAULT NULL COMMENT '消费金额',
  `THIS_BLANCE_MONEY` double DEFAULT NULL COMMENT '本次消费后余额',
  `REMARK` varchar(500) DEFAULT NULL COMMENT '备注',
  `VIP_POINT` int(11) DEFAULT NULL COMMENT '积分',
  `ADD_USER_ID` char(32) DEFAULT NULL COMMENT '添加人',
  `ADD_USER_NAME` varchar(100) DEFAULT NULL COMMENT '添加人姓名',
  `ADD_TIME` date DEFAULT NULL COMMENT '添加时间',
  `SALE_DATE` date DEFAULT NULL COMMENT '消费时间',
  `VIP_ID` char(32) DEFAULT NULL COMMENT '会员ID',
  `VIP_SALE_NAME` varchar(200) DEFAULT NULL COMMENT '消费人员姓名',
  `VIP_NO` varchar(50) DEFAULT NULL COMMENT '会员编号',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `vip_sale` */

insert  into `vip_sale`(`ID`,`SALE_PROJECT`,`SALE_MONEY`,`THIS_BLANCE_MONEY`,`REMARK`,`VIP_POINT`,`ADD_USER_ID`,`ADD_USER_NAME`,`ADD_TIME`,`SALE_DATE`,`VIP_ID`,`VIP_SALE_NAME`,`VIP_NO`) values ('5147a6771ece4bb0b54219da5c271276','充值',-500,500,'',0,'651b7b6fe9ed11e6a466a08cfd1d4922','系统管理员','2017-02-06','2017-02-06','bde924e7ef174dd4be6b5b40a6e05000','李四',NULL),('8f24c3363eff45b9ac3b43b76b5de1dd','充值',-500,500,'',0,'651b7b6fe9ed11e6a466a08cfd1d4922','系统管理员','2017-02-06','2017-02-06','d4debd076513424395faa02cda449521','张三',NULL);

/*Table structure for table `vip_user` */

DROP TABLE IF EXISTS `vip_user`;

CREATE TABLE `vip_user` (
  `ID` char(32) NOT NULL COMMENT '主键ID',
  `VIP_NO` varchar(50) DEFAULT NULL COMMENT '卡号',
  `VIP_NAME` varchar(50) DEFAULT NULL COMMENT '会员姓名',
  `VIP_SEX` int(11) DEFAULT '0' COMMENT '性别0女1男',
  `VIP_PHONE` varchar(50) DEFAULT NULL COMMENT '会员电话',
  `VIP_ADDRESS` varchar(500) DEFAULT NULL COMMENT '会员地址',
  `VIP_DISC_RATE` double DEFAULT NULL COMMENT '折扣(%)',
  `VIP_TOTAL_MONEY` double DEFAULT NULL COMMENT '总金额',
  `VIP_BLAN_MONEY` double DEFAULT NULL COMMENT '余额',
  `ADD_USER_ID` char(32) DEFAULT NULL COMMENT '添加人ID',
  `ADD_USER_NAME` varchar(100) DEFAULT NULL COMMENT '添加人姓名',
  `ADD_TIME` date DEFAULT NULL COMMENT '添加时间',
  `IS_DEL` int(11) DEFAULT '0' COMMENT '是否删除0否1是',
  `REMARK` varchar(500) DEFAULT NULL COMMENT '备注',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AVG_ROW_LENGTH=1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Data for the table `vip_user` */

insert  into `vip_user`(`ID`,`VIP_NO`,`VIP_NAME`,`VIP_SEX`,`VIP_PHONE`,`VIP_ADDRESS`,`VIP_DISC_RATE`,`VIP_TOTAL_MONEY`,`VIP_BLAN_MONEY`,`ADD_USER_ID`,`ADD_USER_NAME`,`ADD_TIME`,`IS_DEL`,`REMARK`) values ('bde924e7ef174dd4be6b5b40a6e05000','201702060002','李四',1,'120','北京',6,0,500,'651b7b6fe9ed11e6a466a08cfd1d4922','系统管理员','2017-02-06',0,''),('d4debd076513424395faa02cda449521','201702060001','张三',1,'110','徐州马坡',8,0,500,'651b7b6fe9ed11e6a466a08cfd1d4922','系统管理员','2017-02-06',0,'');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
