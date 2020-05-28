/*
 Navicat Premium Data Transfer

 Source Server         : 192.168.204.128
 Source Server Type    : MySQL
 Source Server Version : 80020
 Source Host           : 192.168.204.128:3306
 Source Schema         : school

 Target Server Type    : MySQL
 Target Server Version : 80020
 File Encoding         : 65001

 Date: 27/05/2020 18:18:34
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for course
-- ----------------------------
DROP TABLE IF EXISTS `course`;
CREATE TABLE `course`  (
  `cid` int(0) NOT NULL,
  `cname` varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `tid` int(0) NOT NULL,
  PRIMARY KEY (`cid`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of course
-- ----------------------------
INSERT INTO `course` VALUES (1, '语文', 1);
INSERT INTO `course` VALUES (2, '数学', 2);
INSERT INTO `course` VALUES (3, '英语', 3);
INSERT INTO `course` VALUES (4, '物理', 4);

-- ----------------------------
-- Table structure for sc
-- ----------------------------
DROP TABLE IF EXISTS `sc`;
CREATE TABLE `sc`  (
  `sid` int(0) NOT NULL,
  `cid` int(0) NOT NULL,
  `score` int(0) NOT NULL,
  PRIMARY KEY (`sid`, `cid`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sc
-- ----------------------------
INSERT INTO `sc` VALUES (1, 1, 56);
INSERT INTO `sc` VALUES (1, 2, 78);
INSERT INTO `sc` VALUES (1, 3, 67);
INSERT INTO `sc` VALUES (1, 4, 58);
INSERT INTO `sc` VALUES (2, 1, 79);
INSERT INTO `sc` VALUES (2, 2, 81);
INSERT INTO `sc` VALUES (2, 3, 92);
INSERT INTO `sc` VALUES (2, 4, 68);
INSERT INTO `sc` VALUES (3, 1, 91);
INSERT INTO `sc` VALUES (3, 2, 47);
INSERT INTO `sc` VALUES (3, 3, 88);
INSERT INTO `sc` VALUES (3, 4, 56);
INSERT INTO `sc` VALUES (4, 2, 88);
INSERT INTO `sc` VALUES (4, 3, 90);
INSERT INTO `sc` VALUES (4, 4, 93);
INSERT INTO `sc` VALUES (5, 1, 46);
INSERT INTO `sc` VALUES (5, 3, 78);
INSERT INTO `sc` VALUES (5, 4, 53);
INSERT INTO `sc` VALUES (6, 1, 35);
INSERT INTO `sc` VALUES (6, 2, 68);
INSERT INTO `sc` VALUES (6, 4, 71);

-- ----------------------------
-- Table structure for student
-- ----------------------------
DROP TABLE IF EXISTS `student`;
CREATE TABLE `student`  (
  `sid` int(0) NOT NULL,
  `sname` varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `sage` int(0) NOT NULL,
  `ssex` varchar(8) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`sid`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of student
-- ----------------------------
INSERT INTO `student` VALUES (1, '刘一', 18, '男');
INSERT INTO `student` VALUES (2, '钱二', 19, '女');
INSERT INTO `student` VALUES (3, '张三', 17, '男');
INSERT INTO `student` VALUES (4, '李四', 18, '女');
INSERT INTO `student` VALUES (5, '王五', 17, '男');
INSERT INTO `student` VALUES (6, '赵六', 19, '女');

-- ----------------------------
-- Table structure for teacher
-- ----------------------------
DROP TABLE IF EXISTS `teacher`;
CREATE TABLE `teacher`  (
  `tid` int(0) NOT NULL,
  `tname` varchar(16) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`tid`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of teacher
-- ----------------------------
INSERT INTO `teacher` VALUES (1, '叶平');
INSERT INTO `teacher` VALUES (2, '贺高');
INSERT INTO `teacher` VALUES (3, '杨艳');
INSERT INTO `teacher` VALUES (4, '周磊');

SET FOREIGN_KEY_CHECKS = 1;
