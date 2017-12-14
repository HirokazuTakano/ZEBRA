USE zebradb;

--�����e�[�u��������ꍇ�폜����
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.TM_SECTION') AND
   OBJECTPROPERTY(id, N'IsUserTable') = 1)
      DROP TABLE dbo.TM_SECTION



-- �����e�[�u���쐬
CREATE TABLE dbo.TM_SECTION
(
	SECTION_ID varchar(6) NOT NULL,
	SECTION_NAME varchar(100) NOT NULL,
 CONSTRAINT PK_TM_SECTION PRIMARY KEY CLUSTERED (SECTION_ID)
 ) ON [PRIMARY]
;



-- �]�ƈ��e�[�u��������ꍇ�폜����
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.TM_EMPLOYEE') AND
   OBJECTPROPERTY(id, N'IsUserTable') = 1)
      DROP TABLE dbo.TM_EMPLOYEE


-- �]�ƈ��e�[�u���쐬
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


-- �ڋq�e�[�u��������ꍇ�폜����
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.TM_CUSTOMER') AND
   OBJECTPROPERTY(id, N'IsUserTable') = 1)
      DROP TABLE dbo.TM_CUSTOMER

-- �ڋq�e�[�u���쐬
CREATE TABLE dbo.TM_CUSTOMER
(
	CUS_ID varchar(8) NOT NULL,
	COMPANY_NAME varchar(100) NOT NULL,
	CUS_NAME varchar(100) NOT NULL,
	CUS_TEL varchar(15) NOT NULL,
 CONSTRAINT PK_TM_CUSTOMER PRIMARY KEY CLUSTERED (CUS_ID)
 )ON [PRIMARY]
;



-- �V�X�e���e�[�u��������ꍇ�폜����
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.TS_STATUS') AND
   OBJECTPROPERTY(id, N'IsUserTable') = 1)
      DROP TABLE dbo.TS_GENDER
-- �V�X�e���e�[�u���쐬(�F�ؑ҂��̃X�e�[�^�X)
CREATE TABLE TS_STATUS
(
  STATUS INT,
  STATUS_NAME NVARCHAR(4),
  CONSTRAINT PK_TS_GENDER PRIMARY KEY CLUSTERED (STATUS)
 ) ON [PRIMARY]
;
INSERT INTO TS_STATUS
VALUES(1, '�F�ؑ҂�'),(2, '�C���˗�'),(3, '�F�؍ς�');



-- ����e�[�u��������ꍇ�폜����
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.TM_DAILY_REPORT') AND
   OBJECTPROPERTY(id, N'IsUserTable') = 1)
      DROP TABLE dbo.TM_DAILY_REPORT


-- ����e�[�u���쐬
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
	AUTHOR_BOSS_ID varchar(8) NOT NULL,
	BOSS_COMMENT varchar(max) ,
 CONSTRAINT PK_TM_DAILY_REPORT PRIMARY KEY CLUSTERED ([REPORT_ID]),
 FOREIGN KEY (AUTHOR_ID) REFERENCES TM_EMPLOYEE (EMP_ID),
 FOREIGN KEY (CUS_ID) REFERENCES TM_CUSTOMER (CUS_ID),
 FOREIGN KEY (AUTHOR_BOSS_ID) REFERENCES TM_EMPLOYEE (EMP_ID),
 FOREIGN KEY (APPROVAL_STATUS) REFERENCES TS_STATUS (STATUS),
 ) ON [PRIMARY]
;