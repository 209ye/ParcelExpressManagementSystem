/*
 Navicat Premium Data Transfer

 Source Server         : test_mysql
 Source Server Type    : MySQL
 Source Server Version : 50610
 Source Host           : localhost:3306
 Source Schema         : logistics_management

 Target Server Type    : MySQL
 Target Server Version : 50610
 File Encoding         : 65001

 Date: 14/06/2020 20:45:10
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for fact_mail_status
-- ----------------------------
DROP TABLE IF EXISTS `fact_mail_status`;
CREATE TABLE `fact_mail_status`  (
  `mail_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '包裹运单号',
  `courier_company` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '快递公司名',
  `org_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '寄件人姓名',
  `org_address` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '寄件人地址',
  `send_date` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '发货时间',
  `send_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '收件人姓名',
  `send_address` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '收件人地址',
  `send_contact` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '收件人联系方式',
  `stats` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '货物状态',
  `remarks` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '货物备注',
  PRIMARY KEY (`mail_id`, `courier_company`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Records of fact_mail_status
-- ----------------------------
INSERT INTO `fact_mail_status` VALUES ('75336716286009', '中通快递', '建华的店', '河北 保定', '2020/6/2 11:21:19', '冯卓君', '广东省广州市黄埔区荔园小区', '16925748829', '待签收', '当面签收');
INSERT INTO `fact_mail_status` VALUES ('773028339402549', '申通快递', '确邦旗舰店', '深圳市南图公司', '2020/6/2 11:21:19', '简自豪', '广东省深圳市宝安区', '15925866829', '已签收', '无');
INSERT INTO `fact_mail_status` VALUES ('SF1033338721140', '顺丰速运', '小米有品', '杭州小米科技园', '2020/6/2 11:21:19', '小明', '广东省珠海市香洲区北京师范大学粤华苑', '13901388938', '待签收', '可放蜂巢');
INSERT INTO `fact_mail_status` VALUES ('SN2Q00176730966', '苏宁快递', '威莱官方旗舰店', '一田天津贸易公司', '2020/6/2 11:21:19', '高学成', '北京市海淀区', '13826060111', '派送中', '无');

-- ----------------------------
-- Table structure for logistics_company
-- ----------------------------
DROP TABLE IF EXISTS `logistics_company`;
CREATE TABLE `logistics_company`  (
  `Company_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '快递公司名',
  `Contact` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '联系方式',
  INDEX `Company_name`(`Company_name`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Records of logistics_company
-- ----------------------------
INSERT INTO `logistics_company` VALUES ('申通快递', '95543');
INSERT INTO `logistics_company` VALUES ('顺丰快递', '95338');
INSERT INTO `logistics_company` VALUES ('圆通速递', '95554');
INSERT INTO `logistics_company` VALUES ('中通速递', '95311/4008-270-270');
INSERT INTO `logistics_company` VALUES ('韵达快递', '95546');
INSERT INTO `logistics_company` VALUES ('EMS快递', '11183');
INSERT INTO `logistics_company` VALUES ('百世快递', '95320');
INSERT INTO `logistics_company` VALUES ('邮政包裹', '11183');
INSERT INTO `logistics_company` VALUES ('天天快递', '4001-888-888');
INSERT INTO `logistics_company` VALUES ('苏宁快递', '95315');
INSERT INTO `logistics_company` VALUES ('申通快递', '95543');

-- ----------------------------
-- Table structure for order_list
-- ----------------------------
DROP TABLE IF EXISTS `order_list`;
CREATE TABLE `order_list`  (
  `order_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '订单号',
  `mail_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '运单号',
  `logistics_company` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '快递公司',
  PRIMARY KEY (`order_id`, `mail_id`) USING BTREE,
  INDEX `mail_id`(`mail_id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Records of order_list
-- ----------------------------
INSERT INTO `order_list` VALUES ('1010279488402528705', 'SF1033338721140', '顺丰快递');
INSERT INTO `order_list` VALUES ('901216896355169875', '75336716286009', '中通快递');
INSERT INTO `order_list` VALUES ('901595201074169875', 'SN2Q00176730966', '苏宁快递');
INSERT INTO `order_list` VALUES ('903001667570169875', '773028339402549', '申通快递');

-- ----------------------------
-- Table structure for sales_performance
-- ----------------------------
DROP TABLE IF EXISTS `sales_performance`;
CREATE TABLE `sales_performance`  (
  `month` int(20) NOT NULL COMMENT '月份',
  `sales` int(20) NOT NULL COMMENT '销售业绩',
  PRIMARY KEY (`month`, `sales`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Records of sales_performance
-- ----------------------------
INSERT INTO `sales_performance` VALUES (1, 8);
INSERT INTO `sales_performance` VALUES (2, 7);
INSERT INTO `sales_performance` VALUES (3, 6);
INSERT INTO `sales_performance` VALUES (4, 7);
INSERT INTO `sales_performance` VALUES (5, 9);
INSERT INTO `sales_performance` VALUES (6, 10);
INSERT INTO `sales_performance` VALUES (7, 12);
INSERT INTO `sales_performance` VALUES (8, 16);
INSERT INTO `sales_performance` VALUES (9, 11);
INSERT INTO `sales_performance` VALUES (10, 8);
INSERT INTO `sales_performance` VALUES (11, 9);
INSERT INTO `sales_performance` VALUES (12, 13);

-- ----------------------------
-- Table structure for user_info
-- ----------------------------
DROP TABLE IF EXISTS `user_info`;
CREATE TABLE `user_info`  (
  `user_id` int(10) NOT NULL AUTO_INCREMENT COMMENT '用户编号',
  `user_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '用户姓名',
  `user_pwd` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '用户密码',
  PRIMARY KEY (`user_id`, `user_name`, `user_pwd`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 5 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Records of user_info
-- ----------------------------
INSERT INTO `user_info` VALUES (1, 'admin', '123456');
INSERT INTO `user_info` VALUES (2, 'CJH', '123456');
INSERT INTO `user_info` VALUES (3, 'FZJ', '123456');
INSERT INTO `user_info` VALUES (4, 'YYP', '1');

SET FOREIGN_KEY_CHECKS = 1;
