INSERT INTO dbo.TM_DAILY_REPORT
(
 VISIT_STRAT_DATE,
 VISIT_END_DATE, 
 VISIT_TYPE,
 DETAILS,
 CUS_ID,
 APPROVAL_STATUS,
 AUTHOR_ID,
 AUTHOR_BOSS_ID,
 BOSS_COMMENT) 

VALUES 
('2017-12-01 12:00:00',
 '2017-12-01 14:00:00',
 '�����',
 '�ڋq�ɏ��i�����w�������������B',
 'c0001',
  3,
  'E002',
  'E001',
  '���̒��q�Ŋ撣��I'
),
  
('2017-12-14 17:00:00',
 '2017-12-14 17:15:00',
 '�d�b',
 '�z����̊m�F�����܂���',
 'c0005',
  1,
  'E003',
  'E002',
  ''
),
  
('2017-12-11 10:00:00',
 '2017-12-12 10:00:00',
 '���[��',
 '',
 'c0007',
  2,
  'E004',
  'E003',
  '���e�������Ă��������B'
);
