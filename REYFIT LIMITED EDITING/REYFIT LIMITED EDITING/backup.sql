-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Jun 23, 2021 at 06:06 AM
-- Server version: 5.7.26
-- PHP Version: 7.2.18

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `bottle_sales_pos`
--
CREATE DATABASE `bottle_sales_pos` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `bottle_sales_pos`;
-- --------------------------------------------------------

--
-- Table structure for table `acct_category`
--

DROP TABLE IF EXISTS `acct_category`;
CREATE TABLE IF NOT EXISTS `acct_category` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `category` text NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `bank`
--

DROP TABLE IF EXISTS `bank`;
CREATE TABLE IF NOT EXISTS `bank` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `code` text NOT NULL,
  `name` text NOT NULL,
  `add1` text NOT NULL,
  `add2` text NOT NULL,
  `phone` text NOT NULL,
  `email` text NOT NULL,
  `acct_type` text NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `cash_account`
--

DROP TABLE IF EXISTS `cash_account`;
CREATE TABLE IF NOT EXISTS `cash_account` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `pdate` text NOT NULL,
  `reference_no` text,
  `description` text NOT NULL,
  `inflow` varchar(100) NOT NULL DEFAULT '0.00',
  `outflow` varchar(100) NOT NULL DEFAULT '0.00',
  `postedby` text NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `customer_account`
--

DROP TABLE IF EXISTS `customer_account`;
CREATE TABLE IF NOT EXISTS `customer_account` (
  `id` int(100) NOT NULL AUTO_INCREMENT,
  `customerid` text NOT NULL,
  `customer_name` text,
  `pdate` text,
  `recieptno` text,
  `paymentno` text,
  `entry_type` text,
  `debit` varchar(100) DEFAULT '0.00',
  `credit` varchar(100) DEFAULT '0.00',
  `discount` varchar(100) DEFAULT '0.00',
  `balance` varchar(50) DEFAULT '0.00',
  `postedby` text,
  `mode` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `customer_card`
--

DROP TABLE IF EXISTS `customer_card`;
CREATE TABLE IF NOT EXISTS `customer_card` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `customerid` text NOT NULL,
  `full_name` text NOT NULL,
  `phone` text NOT NULL,
  `add1` text NOT NULL,
  `balance` text NOT NULL,
  `status` text,
  `balance_limit` text NOT NULL,
  `postedby` text NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `discount_markup`
--

DROP TABLE IF EXISTS `discount_markup`;
CREATE TABLE IF NOT EXISTS `discount_markup` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `code` text NOT NULL,
  `category` text NOT NULL,
  `minimum_qty` varchar(100) NOT NULL,
  `discount` varchar(100) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `dispose_detail`
--

DROP TABLE IF EXISTS `dispose_detail`;
CREATE TABLE IF NOT EXISTS `dispose_detail` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `doc_no` text NOT NULL,
  `entry_type` text NOT NULL,
  `code` text NOT NULL,
  `description` text NOT NULL,
  `current_stock` text NOT NULL,
  `qty` text NOT NULL,
  `purpose` text NOT NULL,
  `postedby` text NOT NULL,
  `cp` text NOT NULL,
  `total` text NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `dispose_summary`
--

DROP TABLE IF EXISTS `dispose_summary`;
CREATE TABLE IF NOT EXISTS `dispose_summary` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `doc_no` text NOT NULL,
  `p_date` text NOT NULL,
  `purpose` text NOT NULL,
  `total` text NOT NULL,
  `postedby` text NOT NULL,
  `entry_type` text NOT NULL,
  `other_no` text NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `empty_bottles`
--

DROP TABLE IF EXISTS `empty_bottles`;
CREATE TABLE IF NOT EXISTS `empty_bottles` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `pdate` text NOT NULL,
  `mode` text NOT NULL,
  `recieptno` text NOT NULL,
  `prod_code` text NOT NULL,
  `description` text NOT NULL,
  `category` varchar(100) NOT NULL,
  `stock` text NOT NULL,
  `stock_empty` varchar(100) NOT NULL,
  `qty` text NOT NULL,
  `unit` text NOT NULL,
  `total` text NOT NULL,
  `bottle` text NOT NULL,
  `empty_bottle_price` text NOT NULL,
  `postedby` text NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `expenditure`
--

DROP TABLE IF EXISTS `expenditure`;
CREATE TABLE IF NOT EXISTS `expenditure` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `pdate` text NOT NULL,
  `category` text NOT NULL,
  `reference_no` text,
  `description` text NOT NULL,
  `amount` text NOT NULL,
  `comment` text NOT NULL,
  `postedby` text NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `expense_cat`
--

DROP TABLE IF EXISTS `expense_cat`;
CREATE TABLE IF NOT EXISTS `expense_cat` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `code` text NOT NULL,
  `name` text NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `fifo_order`
--

DROP TABLE IF EXISTS `fifo_order`;
CREATE TABLE IF NOT EXISTS `fifo_order` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `pdate` varchar(100) NOT NULL,
  `code` varchar(100) NOT NULL,
  `description` varchar(100) NOT NULL,
  `fifo_qty` varchar(100) NOT NULL DEFAULT '0',
  `fifo_cp` varchar(100) NOT NULL DEFAULT '0.00',
  `qty_sold` varchar(100) NOT NULL DEFAULT '0',
  `current_cp` varchar(100) NOT NULL DEFAULT '0.00',
  `category` varchar(100) NOT NULL,
  `status` varchar(100) NOT NULL DEFAULT 'ACTIVE',
  `postedby` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `general_parameter`
--

DROP TABLE IF EXISTS `general_parameter`;
CREATE TABLE IF NOT EXISTS `general_parameter` (
  `id` int(12) NOT NULL AUTO_INCREMENT,
  `dtype` text NOT NULL,
  `dpercentage` text NOT NULL,
  `dminimum` text NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `income_expenses`
--

DROP TABLE IF EXISTS `income_expenses`;
CREATE TABLE IF NOT EXISTS `income_expenses` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `pdate` text NOT NULL,
  `category` text NOT NULL,
  `description` text NOT NULL,
  `comment` text NOT NULL,
  `expenses` text NOT NULL,
  `postedby` text NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `invoice_detail`
--

DROP TABLE IF EXISTS `invoice_detail`;
CREATE TABLE IF NOT EXISTS `invoice_detail` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `purcase_id` text NOT NULL,
  `pdate` text NOT NULL,
  `code` text NOT NULL,
  `description` text NOT NULL,
  `stock` text NOT NULL,
  `lpc` text NOT NULL,
  `cp` text NOT NULL,
  `qty` text NOT NULL,
  `total` text NOT NULL,
  `invoice_date` text NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `pending_sales`
--

DROP TABLE IF EXISTS `pending_sales`;
CREATE TABLE IF NOT EXISTS `pending_sales` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `pdate` text NOT NULL,
  `rcpn` text NOT NULL,
  `category` text NOT NULL,
  `qty` text NOT NULL,
  `postedby` text NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `pending_sales2`
--

DROP TABLE IF EXISTS `pending_sales2`;
CREATE TABLE IF NOT EXISTS `pending_sales2` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `pdate` text NOT NULL,
  `rcpn` text NOT NULL,
  `category` text NOT NULL,
  `qty` text NOT NULL,
  `price` text NOT NULL,
  `amount` text NOT NULL,
  `postedby` text NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `pending_sales_summary`
--

DROP TABLE IF EXISTS `pending_sales_summary`;
CREATE TABLE IF NOT EXISTS `pending_sales_summary` (
  `id` int(12) NOT NULL AUTO_INCREMENT,
  `pdate` text NOT NULL,
  `rcpn` text NOT NULL,
  `postedby` text NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `post_empty_stock`
--

DROP TABLE IF EXISTS `post_empty_stock`;
CREATE TABLE IF NOT EXISTS `post_empty_stock` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `pdate` text NOT NULL,
  `category` text NOT NULL,
  `post1` varchar(100) NOT NULL DEFAULT '0',
  `post2` varchar(100) NOT NULL DEFAULT '0',
  `post3` varchar(100) NOT NULL DEFAULT '0',
  `post4` varchar(100) NOT NULL DEFAULT '0',
  `post5` varchar(100) NOT NULL DEFAULT '0',
  `post6` varchar(100) NOT NULL DEFAULT '0',
  `post7` varchar(100) NOT NULL DEFAULT '0',
  `post8` varchar(100) NOT NULL DEFAULT '0',
  `post9` varchar(100) NOT NULL DEFAULT '0',
  `post10` varchar(100) NOT NULL DEFAULT '0',
  `total_empties` varchar(100) NOT NULL DEFAULT '0',
  `postedby` text NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `product`
--

DROP TABLE IF EXISTS `product`;
CREATE TABLE IF NOT EXISTS `product` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `code` text NOT NULL,
  `description` text NOT NULL,
  `container` varchar(100) NOT NULL,
  `dept` text NOT NULL,
  `ivpg` text NOT NULL,
  `cp` text NOT NULL,
  `ws` text NOT NULL,
  `s_p` text NOT NULL,
  `stk` text NOT NULL,
  `wp` text NOT NULL,
  `lpc` text NOT NULL,
  `lpd` text NOT NULL,
  `status` text NOT NULL,
  `barcode` text NOT NULL,
  `wp_qty` text NOT NULL,
  `exp_date` text NOT NULL,
  `odr_limit` text NOT NULL,
  `stk_empty` varchar(100) NOT NULL DEFAULT '0',
  `minimum_qty` varchar(100) NOT NULL DEFAULT '0',
  `discount` varchar(100) NOT NULL DEFAULT '0',
  `fifo_qty` varchar(100) NOT NULL DEFAULT '0',
  `fifo_cp` varchar(100) NOT NULL DEFAULT '0.00',
  `qty_sold` varchar(100) NOT NULL DEFAULT '0',
  `qty_sold_projection` varchar(100) NOT NULL DEFAULT '0',
  `ncp` varchar(100) NOT NULL DEFAULT '0.00',
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `product_discount`
--

DROP TABLE IF EXISTS `product_discount`;
CREATE TABLE IF NOT EXISTS `product_discount` (
  `id` int(12) NOT NULL AUTO_INCREMENT,
  `pdc` text NOT NULL,
  `discount` text NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `product_profile`
--

DROP TABLE IF EXISTS `product_profile`;
CREATE TABLE IF NOT EXISTS `product_profile` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `pdate` text NOT NULL,
  `entry_type` text NOT NULL,
  `code` text NOT NULL,
  `description` text NOT NULL,
  `current_stock` text NOT NULL,
  `qty` text NOT NULL,
  `purpose` text NOT NULL,
  `postedby` text NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `product_profile_empties`
--

DROP TABLE IF EXISTS `product_profile_empties`;
CREATE TABLE IF NOT EXISTS `product_profile_empties` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `pdate` text NOT NULL,
  `entry_type` text NOT NULL,
  `code` text NOT NULL,
  `description` text NOT NULL,
  `current_stock` text NOT NULL,
  `qty` text NOT NULL,
  `purpose` text NOT NULL,
  `postedby` text NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `prod_category`
--

DROP TABLE IF EXISTS `prod_category`;
CREATE TABLE IF NOT EXISTS `prod_category` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `code` text NOT NULL,
  `category` text NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `profit_product`
--

DROP TABLE IF EXISTS `profit_product`;
CREATE TABLE IF NOT EXISTS `profit_product` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `pdate` varchar(100) NOT NULL,
  `mode` text NOT NULL,
  `recieptno` varchar(100) NOT NULL,
  `product_code` varchar(100) NOT NULL,
  `description` varchar(100) NOT NULL,
  `category` varchar(100) NOT NULL,
  `qty` varchar(100) NOT NULL,
  `cp` varchar(100) NOT NULL,
  `sp` varchar(100) NOT NULL,
  `tot_cp` varchar(100) NOT NULL DEFAULT '0.00',
  `tot_sp` varchar(100) NOT NULL DEFAULT '0.00',
  `discount` varchar(100) NOT NULL DEFAULT '0..00',
  `discount_amount` varchar(100) NOT NULL DEFAULT '0.00',
  `profit` varchar(100) NOT NULL,
  `postedby` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `purchase_invoice`
--

DROP TABLE IF EXISTS `purchase_invoice`;
CREATE TABLE IF NOT EXISTS `purchase_invoice` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `code` text NOT NULL,
  `p_date` text NOT NULL,
  `odrn` text NOT NULL,
  `vendor_code` text NOT NULL,
  `vendor_name` text NOT NULL,
  `vendor_add` text NOT NULL,
  `post_grp` text NOT NULL,
  `total` text NOT NULL,
  `discount` text NOT NULL,
  `amt_less_discount` text NOT NULL,
  `postedby` text NOT NULL,
  `invoice_date` text NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `return_detail`
--

DROP TABLE IF EXISTS `return_detail`;
CREATE TABLE IF NOT EXISTS `return_detail` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `purcase_id` text NOT NULL,
  `pdate` text NOT NULL,
  `code` text NOT NULL,
  `description` text NOT NULL,
  `stock` text NOT NULL,
  `lpc` text NOT NULL,
  `cp` text NOT NULL,
  `qty` text NOT NULL,
  `total` text NOT NULL,
  `invoice_date` text NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `return_invoice`
--

DROP TABLE IF EXISTS `return_invoice`;
CREATE TABLE IF NOT EXISTS `return_invoice` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `code` text NOT NULL,
  `p_date` text NOT NULL,
  `odrn` text NOT NULL,
  `vendor_code` text NOT NULL,
  `vendor_name` text NOT NULL,
  `vendor_add` text NOT NULL,
  `post_grp` text NOT NULL,
  `total` text NOT NULL,
  `discount` text NOT NULL,
  `amt_less_discount` text NOT NULL,
  `postedby` text NOT NULL,
  `invoice_date` text NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `sales_detail`
--

DROP TABLE IF EXISTS `sales_detail`;
CREATE TABLE IF NOT EXISTS `sales_detail` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `pdate` text NOT NULL,
  `mode` text NOT NULL,
  `recieptno` text NOT NULL,
  `prod_code` text NOT NULL,
  `description` text NOT NULL,
  `stock` text NOT NULL,
  `qty` text NOT NULL,
  `unit` text NOT NULL,
  `total` text NOT NULL,
  `pack` text NOT NULL,
  `pack_price` text NOT NULL,
  `qty_pack_db` text NOT NULL,
  `cppl` text NOT NULL,
  `qty_pack` text NOT NULL,
  `cp` text NOT NULL,
  `discount` varchar(100) NOT NULL DEFAULT '0.00',
  `net_amt` varchar(100) NOT NULL DEFAULT '0.00',
  `postedby` text NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `sales_detail_empties`
--

DROP TABLE IF EXISTS `sales_detail_empties`;
CREATE TABLE IF NOT EXISTS `sales_detail_empties` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `pdate` text NOT NULL,
  `mode` text NOT NULL,
  `recieptno` text NOT NULL,
  `prod_code` text NOT NULL,
  `description` text NOT NULL,
  `stock` text NOT NULL,
  `qty` text NOT NULL,
  `unit` text NOT NULL,
  `total` text NOT NULL,
  `pack` text NOT NULL,
  `pack_price` text NOT NULL,
  `qty_pack_db` text NOT NULL,
  `cppl` text NOT NULL,
  `qty_pack` text NOT NULL,
  `cp` text NOT NULL,
  `postedby` text NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `sales_detail_purchase_empties`
--

DROP TABLE IF EXISTS `sales_detail_purchase_empties`;
CREATE TABLE IF NOT EXISTS `sales_detail_purchase_empties` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `pdate` text NOT NULL,
  `mode` text NOT NULL,
  `recieptno` text NOT NULL,
  `prod_code` text NOT NULL,
  `description` text NOT NULL,
  `stock` text NOT NULL,
  `qty` text NOT NULL,
  `unit` text NOT NULL,
  `total` text NOT NULL,
  `pack` text NOT NULL,
  `pack_price` text NOT NULL,
  `qty_pack_db` text NOT NULL,
  `cppl` text NOT NULL,
  `qty_pack` text NOT NULL,
  `cp` text NOT NULL,
  `postedby` text NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `sales_detail_qty`
--

DROP TABLE IF EXISTS `sales_detail_qty`;
CREATE TABLE IF NOT EXISTS `sales_detail_qty` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `pdate` text NOT NULL,
  `mode` text NOT NULL,
  `recieptno` text NOT NULL,
  `prod_code` text NOT NULL,
  `description` text NOT NULL,
  `stock` text NOT NULL,
  `qty` text NOT NULL,
  `pack` text NOT NULL,
  `qty_pack_db` text NOT NULL,
  `qty_pack` text NOT NULL,
  `tot_qty_sold` text NOT NULL,
  `cp` varchar(100) NOT NULL DEFAULT '0.00',
  `sp` varchar(100) NOT NULL DEFAULT '0.00',
  `category` varchar(100) NOT NULL,
  `postedby` text NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `sales_detail_qty_total`
--

DROP TABLE IF EXISTS `sales_detail_qty_total`;
CREATE TABLE IF NOT EXISTS `sales_detail_qty_total` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `pdate` text NOT NULL,
  `mode` text NOT NULL,
  `recieptno` text NOT NULL,
  `prod_code` text NOT NULL,
  `description` text NOT NULL,
  `stock` text NOT NULL,
  `qty` text NOT NULL,
  `pack` text NOT NULL,
  `qty_pack_db` text NOT NULL,
  `qty_pack` text NOT NULL,
  `tot_qty_sold` text NOT NULL,
  `unit` text NOT NULL,
  `postedby` text NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `sales_invoice_detail`
--

DROP TABLE IF EXISTS `sales_invoice_detail`;
CREATE TABLE IF NOT EXISTS `sales_invoice_detail` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `pdate` text NOT NULL,
  `mode` text NOT NULL,
  `recieptno` text NOT NULL,
  `prod_code` text NOT NULL,
  `description` text NOT NULL,
  `stock` text NOT NULL,
  `qty` text NOT NULL,
  `unit` text NOT NULL,
  `total` text NOT NULL,
  `pack` text NOT NULL,
  `pack_price` text NOT NULL,
  `qty_pack_db` text NOT NULL,
  `cppl` text NOT NULL,
  `qty_pack` text NOT NULL,
  `cp` text NOT NULL,
  `postedby` text NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `sales_invoice_detail_qty`
--

DROP TABLE IF EXISTS `sales_invoice_detail_qty`;
CREATE TABLE IF NOT EXISTS `sales_invoice_detail_qty` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `pdate` text NOT NULL,
  `mode` text NOT NULL,
  `recieptno` text NOT NULL,
  `prod_code` text NOT NULL,
  `description` text NOT NULL,
  `stock` text NOT NULL,
  `qty` text NOT NULL,
  `pack` text NOT NULL,
  `qty_pack_db` text NOT NULL,
  `qty_pack` text NOT NULL,
  `tot_qty_sold` text NOT NULL,
  `postedby` text NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `sales_invoice_summary`
--

DROP TABLE IF EXISTS `sales_invoice_summary`;
CREATE TABLE IF NOT EXISTS `sales_invoice_summary` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `pdate` text NOT NULL,
  `mode` text NOT NULL,
  `bank` text NOT NULL,
  `refno` text NOT NULL,
  `recieptno` text NOT NULL,
  `total` text NOT NULL,
  `discount` text NOT NULL,
  `amt_less_discount` text NOT NULL,
  `amt_tender` text NOT NULL,
  `change_due` text NOT NULL,
  `net_pay` text NOT NULL,
  `postedby` text NOT NULL,
  `customer` text NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `sales_return_detail`
--

DROP TABLE IF EXISTS `sales_return_detail`;
CREATE TABLE IF NOT EXISTS `sales_return_detail` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `doc_no` text NOT NULL,
  `entry_type` text NOT NULL,
  `code` text NOT NULL,
  `description` text NOT NULL,
  `stock` text NOT NULL,
  `qty` text NOT NULL,
  `amount` text NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `sales_return_summary`
--

DROP TABLE IF EXISTS `sales_return_summary`;
CREATE TABLE IF NOT EXISTS `sales_return_summary` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `doc_no` text NOT NULL,
  `pdate` text NOT NULL,
  `entry_type` text NOT NULL,
  `total` text NOT NULL,
  `customer` text NOT NULL,
  `recieptno` text NOT NULL,
  `cashier` text NOT NULL,
  `postedby` text NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `sales_summary`
--

DROP TABLE IF EXISTS `sales_summary`;
CREATE TABLE IF NOT EXISTS `sales_summary` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `pdate` text NOT NULL,
  `mode` text NOT NULL,
  `bank` text NOT NULL,
  `refno` text NOT NULL,
  `recieptno` text NOT NULL,
  `total` text NOT NULL,
  `discount` text NOT NULL,
  `amt_less_discount` text NOT NULL,
  `amt_tender` text NOT NULL,
  `change_due` text NOT NULL,
  `net_pay` text NOT NULL,
  `postedby` text NOT NULL,
  `customer` text NOT NULL,
  `bottle_purchased` text NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `sales_summary2`
--

DROP TABLE IF EXISTS `sales_summary2`;
CREATE TABLE IF NOT EXISTS `sales_summary2` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `pdate` text NOT NULL,
  `mode` text NOT NULL,
  `cash` varchar(100) NOT NULL DEFAULT '0.00',
  `pos` varchar(100) NOT NULL DEFAULT '0.00',
  `transfer` varchar(100) NOT NULL DEFAULT '0.00',
  `credit` varchar(100) NOT NULL DEFAULT '0.00',
  `bank` text NOT NULL,
  `refno` text NOT NULL,
  `recieptno` text NOT NULL,
  `total` text NOT NULL,
  `discount` text NOT NULL,
  `amt_less_discount` text NOT NULL,
  `amt_tender` text NOT NULL,
  `change_due` text NOT NULL,
  `net_pay` text NOT NULL,
  `postedby` text NOT NULL,
  `customer` text NOT NULL,
  `bottle_purchased` text NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `sales_summary3`
--

DROP TABLE IF EXISTS `sales_summary3`;
CREATE TABLE IF NOT EXISTS `sales_summary3` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `pdate` varchar(100) NOT NULL,
  `cash` varchar(100) NOT NULL DEFAULT '0.00',
  `pos` varchar(100) NOT NULL DEFAULT '0.00',
  `transfer` varchar(100) NOT NULL DEFAULT '0.00',
  `credit` varchar(100) NOT NULL DEFAULT '0.00',
  `total` text NOT NULL,
  `postedby` text NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `pdate` (`pdate`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `supplier_account`
--

DROP TABLE IF EXISTS `supplier_account`;
CREATE TABLE IF NOT EXISTS `supplier_account` (
  `id` int(100) NOT NULL AUTO_INCREMENT,
  `supplierid` text NOT NULL,
  `supplier_name` text,
  `pdate` text,
  `recieptno` text,
  `paymentno` text,
  `entry_type` text,
  `debit` varchar(100) DEFAULT '0.00',
  `credit` varchar(100) DEFAULT '0.00',
  `discount` varchar(100) DEFAULT '0.00',
  `balance` varchar(50) DEFAULT '0.00',
  `postedby` text,
  `mode` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_greeting`
--

DROP TABLE IF EXISTS `tbl_greeting`;
CREATE TABLE IF NOT EXISTS `tbl_greeting` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `pdate` text NOT NULL,
  `message1` text NOT NULL,
  `message2` text NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_stock_code`
--

DROP TABLE IF EXISTS `tbl_stock_code`;
CREATE TABLE IF NOT EXISTS `tbl_stock_code` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `code` text NOT NULL,
  `status` text NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_stock_list`
--

DROP TABLE IF EXISTS `tbl_stock_list`;
CREATE TABLE IF NOT EXISTS `tbl_stock_list` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `code` text NOT NULL,
  `description` text NOT NULL,
  `stk` text NOT NULL,
  `Listcode` text,
  `status` text,
  `qty` text,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_subject_allocation`
--

DROP TABLE IF EXISTS `tbl_subject_allocation`;
CREATE TABLE IF NOT EXISTS `tbl_subject_allocation` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `staff_id` text NOT NULL,
  `subject_id` text NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `user_reg`
--

DROP TABLE IF EXISTS `user_reg`;
CREATE TABLE IF NOT EXISTS `user_reg` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `fn` text NOT NULL,
  `add1` text NOT NULL,
  `add2` text NOT NULL,
  `phone` text NOT NULL,
  `email` text NOT NULL,
  `role` text NOT NULL,
  `username` text NOT NULL,
  `password` text NOT NULL,
  `status` text NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `vendor`
--

DROP TABLE IF EXISTS `vendor`;
CREATE TABLE IF NOT EXISTS `vendor` (
  `id` int(9) NOT NULL AUTO_INCREMENT,
  `vn` text NOT NULL,
  `add1` text NOT NULL,
  `add2` text NOT NULL,
  `phone` text NOT NULL,
  `email` text NOT NULL,
  `bal` text NOT NULL,
  `status` text NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
