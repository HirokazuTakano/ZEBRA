USE zebradb;

-- 日報テーブルがある場合削除する
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.TM_DAILY_REPORT') AND
   OBJECTPROPERTY(id, N'IsUserTable') = 1)
      DROP TABLE dbo.TM_DAILY_REPORT

-- システムテーブルがある場合削除する
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.TS_STATUS') AND
   OBJECTPROPERTY(id, N'IsUserTable') = 1)
      DROP TABLE dbo.TS_STATUS

-- 顧客テーブルがある場合削除する
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.TM_CUSTOMER') AND
   OBJECTPROPERTY(id, N'IsUserTable') = 1)
      DROP TABLE dbo.TM_CUSTOMER

-- 従業員テーブルがある場合削除する
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.TM_EMPLOYEE') AND
   OBJECTPROPERTY(id, N'IsUserTable') = 1)
      DROP TABLE dbo.TM_EMPLOYEE

--部署テーブルがある場合削除する
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.TM_SECTION') AND
   OBJECTPROPERTY(id, N'IsUserTable') = 1)
      DROP TABLE dbo.TM_SECTION

	  





-- 部署テーブル作成
CREATE TABLE dbo.TM_SECTION
(
	SECTION_ID varchar(6) NOT NULL,
	SECTION_NAME varchar(100) NOT NULL,
 CONSTRAINT PK_TM_SECTION PRIMARY KEY CLUSTERED (SECTION_ID)
 ) ON [PRIMARY]
;



-- 従業員テーブル作成
CREATE TABLE dbo.TM_EMPLOYEE
(
	EMP_ID varchar(8) NOT NULL,
	EMP_PASSWORD varchar(8) NOT NULL,
	NAME_SEI varchar(100) NOT NULL,
	NAME_MEI varchar(100) NOT NULL,
	BOSS_ID varchar(8) NOT NULL,
	EMP_SEC_ID varchar(6) NOT NULL,
	EMP_TEL varchar(15) NOT NULL,
 CONSTRAINT PK_TM_EMPLOYEE PRIMARY KEY CLUSTERED (EMP_ID),
 FOREIGN KEY (EMP_SEC_ID) REFERENCES TM_SECTION (SECTION_ID),
 FOREIGN KEY (BOSS_ID) REFERENCES TM_EMPLOYEE (EMP_ID)
 )ON [PRIMARY]
;




-- 顧客テーブル作成
CREATE TABLE dbo.TM_CUSTOMER
(
	CUS_ID varchar(8) NOT NULL,
	COMPANY_NAME varchar(100) NOT NULL,
	CUS_NAME varchar(100) NOT NULL,
	CUS_TEL varchar(15) NOT NULL,
 CONSTRAINT PK_TM_CUSTOMER PRIMARY KEY CLUSTERED (CUS_ID)
 )ON [PRIMARY]
;




-- システムテーブル作成(認証待ちのステータス)
CREATE TABLE TS_STATUS
(
  STATUS INT,
  STATUS_NAME NVARCHAR(4) NOT NULL,
  CONSTRAINT PM_TS_STATUS PRIMARY KEY CLUSTERED (STATUS)
 ) ON [PRIMARY]
;
INSERT INTO TS_STATUS
VALUES(1, '認証待ち'),(2, '修正依頼'),(3, '認証済み');



-- 日報テーブル作成
CREATE TABLE dbo.TM_DAILY_REPORT(
	REPORT_ID int IDENTITY(1,1) NOT NULL,
	CREATE_DATE datetime NOT NULL DEFAULT GETDATE(),
	UPDATE_DATE datetime NOT NULL DEFAULT GETDATE(),
	VISIT_STRAT_DATE datetime NOT NULL,
	VISIT_END_DATE datetime NOT NULL,
	VISIT_TYPE varchar(50) NOT NULL,
	DETAILS varchar(max) NOT NULL,
	CUS_ID varchar(8) NOT NULL,
	APPROVAL_STATUS int NOT NULL,
	AUTHOR_ID varchar(8) NOT NULL,
	AUTHOR_BOSS_ID varchar(8) ,
	BOSS_COMMENT varchar(max) NOT NULL,
 CONSTRAINT PK_TM_DAILY_REPORT PRIMARY KEY CLUSTERED ([REPORT_ID]),
 FOREIGN KEY (AUTHOR_ID) REFERENCES TM_EMPLOYEE (EMP_ID),
 FOREIGN KEY (CUS_ID) REFERENCES TM_CUSTOMER (CUS_ID),
 FOREIGN KEY (AUTHOR_BOSS_ID) REFERENCES TM_EMPLOYEE (EMP_ID),
 FOREIGN KEY (APPROVAL_STATUS) REFERENCES TS_STATUS (STATUS),
 ) ON [PRIMARY]
;


-- 顧客データ
INSERT INTO TM_CUSTOMER
(CUS_ID, COMPANY_NAME, CUS_NAME, CUS_TEL)
VALUES
 ('c0001', 'リコージャパンジャパン', '犬山舞', '0369695454'),
 ('c0002', 'リコー', '理工太郎', '0357893322'),
 ('c0003', 'RITS', 'FucchiRachel', '0389895353'),
 ('c0004', 'ジェーソン', '綾波玲', '0389895454'),
 ('c0005', 'ヤオコー', '犬山舞', '0389895454'),
 ('c0006', '伊藤園', '山本太郎', '0389895454'),
 ('c0007', 'イオン', '島田浩一', '0389895454')
 ;

-- 部署データ
INSERT INTO dbo.TM_SECTION
(SECTION_ID, SECTION_NAME) 
VALUES
 ('S0001','営業部'), 
 ('S0002','人事部'),
 ('S0003','経理部'),
 ('S0004','ICT事業部')
 ;



-- 従業員データ(上司に該当する従業員)
INSERT  INTO dbo.TM_EMPLOYEE
(EMP_ID,EMP_PASSWORD,NAME_SEI,NAME_MEI,BOSS_ID,EMP_SEC_ID,EMP_TEL)
VALUES
('E001','password','犬伏','萌々子','E001','S0001','08011112222'),
('E002','password','高野','浩一','E002','S0002','08033334444'),
('E003','password','藤本','麻菜','E003','S0003','08055556666'),
('E004','password','石塚','玲','E004','S0004','08077778888')
;

-- 従業員データ(部下に該当する従業員)
INSERT  INTO dbo.TM_EMPLOYEE
(EMP_ID,EMP_PASSWORD,NAME_SEI,NAME_MEI,BOSS_ID,EMP_SEC_ID,EMP_TEL)
VALUES
('E005','password','山田','太郎','E001','S0001','09054546969'),
('E006','password','沢谷','舞','E001','S0001','09056597845'),
('E007','password','島袋','凌','E001','S0001','08065784201'),

('E008','password','鈴木','四郎','E002','S0002','08065996301'),
('E009','password','木下','花子','E002','S0002','07045632166'),
('E010','password','佐藤','一郎','E002','S0002','09065485201'),

('E011','password','田中','次郎','E003','S0003','07020002546'),
('E012','password','安藤','三郎','E003','S0003','09065301456'),
('E013','password','飯島','四郎','E003','S0003','08000215452'),

('E014','password','上田','五郎','E004','S0004','09054521021'),
('E015','password','新藤','六郎','E004','S0004','09067478235'),
('E016','password','柴田','恭兵','E004','S0004','09063486480')
;



-- 日報データ
INSERT INTO dbo.TM_DAILY_REPORT
(CREATE_DATE, UPDATE_DATE, VISIT_STRAT_DATE, VISIT_END_DATE, 
 VISIT_TYPE, DETAILS, CUS_ID, APPROVAL_STATUS, AUTHOR_ID, AUTHOR_BOSS_ID, BOSS_COMMENT) 
VALUES 
('2017/12/01 15:00:00','2017/12/01 18:00:00','2017/12/01 12:00:00','2017/12/01 14:00:00',
 '相手宅','顧客に商品をご購入いただいた。','c0001',3,'E005','E001','この調子で頑張れ！'),
('2017/12/02 17:00:00','2017/12/02 17:15:00','2017/12/10 16:30:00','2017/12/10 16:40:00',
'電話','配送先の確認をしました','c0005',3,'E005','E001','確認しました'),
('2017/12/03 17:00:00','2017/12/03 17:15:00','2017/12/10 16:30:00','2017/12/10 16:50:00',
'電話','配送先の確認をしました','c0002',3,'E005','E001','確認しました'),
('2017/12/13 13:00:00','2017/12/13 13:15:00','2017/12/13 16:30:00','2017/12/13 16:40:00',
'電話','配送先の確認をしました','c0001',3,'E005','E001','確認しました'),
('2017/12/13 17:00:00','2017/12/13 17:15:00','2017/12/13 16:40:00','2017/12/13 17:00:00',
'電話','配送先の確認をしました','c0001',3,'E005','E001','確認しました'),
('2017/12/14 17:00:00','2017/12/14 17:15:00','2017/12/14 16:30:00','2017/12/14 16:40:00',
'電話','配送先の確認をしました','c0001',1,'E005','E001',''),
('2017/12/03 10:00:00','2017/12/03 11:15:00','2017/12/11 10:00:00','2017/12/12 10:00:00',
'メール','','c0007',2,'E005','E001','内容を書いてください。'),

('2017/12/01 15:30:00','2017/12/01 18:30:00','2017/12/01 12:30:00','2017/12/01 14:30:00',
 '相手宅','顧客に商品をご購入いただいた。','c0001',3,'E006','E001','この調子で頑張れ！'),
('2017/12/02 17:30:00','2017/12/02 17:30:00','2017/12/10 16:40:00','2017/12/10 16:50:00',
'電話','配送先の確認をしました','c0005',3,'E006','E001',''),
('2017/12/03 17:30:00','2017/12/03 17:45:00','2017/12/10 16:50:00','2017/12/10 17:00:00',
'電話','配送先の確認をしました','c0002',3,'E006','E001',''),
('2017/12/13 13:30:00','2017/12/13 13:15:00','2017/12/13 16:30:00','2017/12/13 16:50:00',
'電話','配送先の確認をしました','c0001',3,'E006','E001',''),
('2017/12/13 17:30:00','2017/12/13 17:15:00','2017/12/13 16:30:00','2017/12/13 16:50:00',
'電話','配送先の確認をしました','c0001',3,'E006','E001',''),
('2017/12/14 17:30:00','2017/12/14 17:15:00','2017/12/14 16:30:00','2017/12/14 16:50:00',
'電話','配送先の確認をしました','c0001',1,'E006','E001',''),
('2017/12/03 10:30:00','2017/12/03 11:20:00','2017/12/11 10:00:00','2017/12/12 10:00:00',
'メール','','c0007',2,'E006','E001','内容を書いてください。'),


('2017/11/10 15:30:00','2017/11/01 18:30:00','2017/11/01 12:30:00','2017/11/01 14:30:00',
 '自社','顧客と打ち合わせを行なった。','c0001',3,'E001',null,''),
('2017/11/11 15:30:00','2017/11/01 18:30:00','2017/11/01 12:30:00','2017/11/01 14:30:00',
 '自社','顧客と打ち合わせを行なった。','c0001',3,'E001',null,''),
('2017/11/11 15:30:00','2017/11/01 18:30:00','2017/11/01 12:30:00','2017/11/01 14:30:00',
 '自社','顧客と打ち合わせを行なった。','c0001',3,'E002',null,''),
('2017/11/11 15:30:00','2017/11/01 18:30:00','2017/11/01 12:30:00','2017/11/01 14:30:00',
 '自社','顧客と打ち合わせを行なった。','c0001',3,'E003',null,''),
('2017/11/11 15:30:00','2017/11/01 18:30:00','2017/11/01 12:30:00','2017/11/01 14:30:00',
 '自社','顧客と打ち合わせを行なった。','c0001',3,'E004',null,''),


('2017/12/11 15:30:00','2017/12/01 18:30:00','2017/12/01 12:30:00','2017/12/01 14:30:00',
 '自社','顧客と打ち合わせを行なった。','c0001',1,'E007','E001',''),
('2017/12/11 15:30:00','2017/12/01 18:30:00','2017/12/01 12:30:00','2017/12/01 14:30:00',
 '自社','顧客と打ち合わせを行なった。','c0001',1,'E008','E002','')








;


