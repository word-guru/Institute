INSERT INTO tab_roles ([name]) VALUES (N'student')
INSERT INTO tab_roles ([name]) VALUES (N'teacher')
INSERT INTO tab_roles ([name]) VALUES (N'admin')

INSERT INTO tab_accounts ([login], [password], is_active) VALUES (N'student', N'123', 1)
INSERT INTO tab_accounts ([login], [password], is_active) VALUES (N'teacher', N'123', 1)
INSERT INTO tab_accounts ([login], [password], is_active) VALUES (N'admin', N'123', 1)

INSERT INTO tab_account_roles (account_id, role_id) VALUES (1, 1)
INSERT INTO tab_account_roles (account_id, role_id) VALUES (2, 2)
INSERT INTO tab_account_roles (account_id, role_id) VALUES (3, 3)

INSERT INTO tab_persons (first_name, last_name, date_of_birth, sex) VALUES (N'Stud', N'Student', N'2022-02-04', N'F')
INSERT INTO tab_persons (first_name, last_name, date_of_birth, sex) VALUES (N'Teach', N'Teacher', N'2022-02-01', N'M')
INSERT INTO tab_persons (first_name, last_name, date_of_birth, sex) VALUES (N'Admin', N'Administrator', N'2022-01-31', N'F')

INSERT INTO tab_groups ([name]) VALUES (N'F-55')

INSERT INTO tab_students (person_id, group_id, is_study) VALUES (1, 1, 1)

INSERT INTO tab_teachers (person_id, group_id) VALUES (2, 1)