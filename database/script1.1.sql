----------------------------- Create Script ----------------------------------------
DROP DATABASE StudentData
CREATE DATABASE StudentData;
use [StudentData]

CREATE TABLE Admin (AdminID nvarchar(50) NOT NULL, Password nvarchar(50) NOT NULL,AdminName nvarchar(50), PRIMARY KEY (AdminID));
CREATE TABLE PrequisiteManager (PrequisiteID int IDENTITY NOT NULL, SubjectRepresented nvarchar(20) NOT NULL, PrequisiteSubject nvarchar(20) NOT NULL, PRIMARY KEY (PrequisiteID));
CREATE TABLE Professor (ProfessorCode nvarchar(20) NOT NULL, ProfessorName nvarchar(255) NOT NULL, DepartmentID int NOT NULL, Title nvarchar(50) NULL, Salary decimal(19, 3) NULL, Phone nvarchar(15) NOT NULL, Address nvarchar(255) NOT NULL, Password nvarchar(50) NOT NULL, PRIMARY KEY (ProfessorCode));
CREATE TABLE Schedule (SemesterID int IDENTITY NOT NULL, StartDate datetime NOT NULL, EndDate datetime NOT NULL, SemesterName nvarchar(50) NULL, PRIMARY KEY (SemesterID));
CREATE TABLE Section (SectionNo nvarchar(20) NOT NULL, SeatingCapacity int NOT NULL, StartDate datetime NULL, EndDate datetime NULL, ProfessorCode nvarchar(20) NOT NULL, RepresentedSubject nvarchar(20) NOT NULL, SemesterBelong int NOT NULL, PRIMARY KEY (SectionNo));
CREATE TABLE SectionSchedule (SectionScheduleID int IDENTITY NOT NULL, SectionID nvarchar(20) NOT NULL, [Date] datetime NULL, Slot int NULL, Duration int NULL, Room nvarchar(20) NULL, PRIMARY KEY (SectionScheduleID));
CREATE TABLE Student (StudentID nvarchar(20) NOT NULL, StudentName nvarchar(50) NOT NULL, Major nvarchar(10) NOT NULL, Address nvarchar(255) NOT NULL, Sex int NOT NULL, BirthDay datetime NOT NULL, Country nvarchar(255) NOT NULL, Email nvarchar(255) NOT NULL, Phone nvarchar(15) NOT NULL, Password nvarchar(50) NOT NULL, PRIMARY KEY (StudentID));
CREATE TABLE StudentTranscript (TranscriptID int IDENTITY NOT NULL, StudentCode nvarchar(20) NOT NULL, SectionID nvarchar(20) NOT NULL, AverageGrade float(10) NULL,LearningStatus nvarchar(20) NOT NULL, PRIMARY KEY (TranscriptID));
CREATE TABLE Subject (SubjectCode nvarchar(20) NOT NULL, SubjectName nvarchar(50) NULL, Credit int NULL, PRIMARY KEY (SubjectCode));
CREATE TABLE SubjectTeamplate (ID int IDENTITY NOT NULL, SubjectID nvarchar(20) NOT NULL, MarkTitle nvarchar(50) NULL, Percentage decimal(19, 3) NULL, IsCurrent bit NULL, PRIMARY KEY (ID));
CREATE TABLE TranscriptAttendaceEntry (EntryID int IDENTITY NOT NULL, TranscriptID int NOT NULL, AttendanceStatus int NULL, SectionScheduleID int NOT NULL, PRIMARY KEY (EntryID));
CREATE TABLE TranscriptMarkEntry (EntryID int IDENTITY NOT NULL, TranscriptID int NOT NULL, SubjectTeamplateID int null, Grade decimal(19, 3) NULL, PRIMARY KEY (EntryID));
ALTER TABLE SubjectTeamplate ADD CONSTRAINT FKSubjectTea437859 FOREIGN KEY (SubjectID) REFERENCES Subject (SubjectCode);
ALTER TABLE TranscriptMarkEntry ADD CONSTRAINT FKTranscript687421 FOREIGN KEY (TranscriptID) REFERENCES StudentTranscript (TranscriptID);
ALTER TABLE TranscriptAttendaceEntry ADD CONSTRAINT FKTranscript584403 FOREIGN KEY (TranscriptID) REFERENCES StudentTranscript (TranscriptID);
ALTER TABLE StudentTranscript ADD CONSTRAINT FKStudentTra94815 FOREIGN KEY (StudentCode) REFERENCES Student (StudentID);
ALTER TABLE Section ADD CONSTRAINT FKSection711879 FOREIGN KEY (ProfessorCode) REFERENCES Professor (ProfessorCode);
ALTER TABLE StudentTranscript ADD CONSTRAINT FKStudentTra257209 FOREIGN KEY (SectionID) REFERENCES Section (SectionNo);
ALTER TABLE SectionSchedule ADD CONSTRAINT FKSectionSch330560 FOREIGN KEY (SectionID) REFERENCES Section (SectionNo);
ALTER TABLE TranscriptAttendaceEntry ADD CONSTRAINT FKTranscript458878 FOREIGN KEY (SectionScheduleID) REFERENCES SectionSchedule (SectionScheduleID);
ALTER TABLE PrequisiteManager ADD CONSTRAINT FKPrequisite888716 FOREIGN KEY (SubjectRepresented) REFERENCES Subject (SubjectCode);
ALTER TABLE PrequisiteManager ADD CONSTRAINT FKPrequisite187664 FOREIGN KEY (PrequisiteSubject) REFERENCES Subject (SubjectCode);
ALTER TABLE Section ADD CONSTRAINT FKSection411369 FOREIGN KEY (SemesterBelong) REFERENCES Schedule (SemesterID);
ALTER TABLE Section ADD CONSTRAINT FKSection411370 FOREIGN KEY (RepresentedSubject) REFERENCES Subject (SubjectCode);
ALTER TABLE TranscriptMarkEntry ADD CONSTRAINT FKTranscript687423 FOREIGN KEY (TranscriptID) REFERENCES SubjectTeamplate (ID);



---------------------- Insert script -----------------------------------------------

/* 1. Admin */
INSERT INTO Admin (AdminID ,Password)
VALUES (N'admin01',N'admin01');

INSERT INTO Admin (AdminID ,Password)
VALUES (N'admin02',N'admin02');

INSERT INTO Admin (AdminID ,Password)
VALUES (N'admin03',N'admin03');


/* 2. Student */
INSERT INTO Student (StudentID,StudentName , Major,Address ,Sex ,BirthDay,Country,Email,Phone,Password)
VALUES (N'SE61769',N'Le Cong Danh',N'SE',N'262/2A, KP 2, đường Phạm Văn Thuận, P Thống Nhất,TP Biên Hòa',1
,'1996/9/2',N'Viet Nam',N'danhlcse61769@fpt.edu.vn',N'0934123123',N'123456');

INSERT INTO Student (StudentID,StudentName , Major,Address ,Sex ,BirthDay,Country,Email,Phone,Password)
VALUES (N'SE61770',N'Vu Hoang Nam',N'SE',N'70/8A Tô Ký, P Trung Mỹ Tây, Q12, TPHCM',1
,'1996/1/13',N'Viet Nam',N'namevhse61770@fpt.edu.vn',N'0934123123',N'123456');

INSERT INTO Student (StudentID,StudentName , Major,Address ,Sex ,BirthDay,Country,Email,Phone,Password)
VALUES (N'SE61771',N'Le Minh Hy',N'SE',N'8A Quang Trung, Q. Gò Vấp, TPHCM',1
,'1996/5/30',N'Viet Nam',N'hylmse61770@fpt.edu.vn',N'0934333444',N'123456');

INSERT INTO Student (StudentID,StudentName , Major,Address ,Sex ,BirthDay,Country,Email,Phone,Password)
VALUES (N'SE61772',N'Nguyen Thi Lan Huong',N'SE',N'667 Bàu cát, Q. Tân Bình, TPHCM',2
,'1996/10/7',N'Viet Nam',N'huongntlse61772@fpt.edu.vn',N'0934333555',N'123456');

INSERT INTO Student (StudentID,StudentName , Major,Address ,Sex ,BirthDay,Country,Email,Phone,Password)
VALUES (N'SE61010',N'Nguyen Nhat Linh',N'SB',N'667 Quang Trung, Q. Gò Vấp, TPHCM',2
,'1996/8/7',N'Viet Nam',N'linhnnsb61010@fpt.edu.vn',N'0934333777',N'123456');

/* 3. Professor */
INSERT INTO Professor (ProfessorCode,ProfessorName,DepartmentID,Salary,Phone ,Address ,Password)
VALUES (N'PRO10000',N'Nguyen Thi Lan',2,1000,N'0934888555',N'77 Dương Tử Hàm, Q1, TPHCM',N'123456');

INSERT INTO Professor (ProfessorCode,ProfessorName,DepartmentID,Salary,Phone ,Address ,Password)
VALUES (N'PRO10001',N'Nguyen Van Quy',1,1000,N'0934888777',N'77 Man Thien, Q9, TPHCM',N'123456');

INSERT INTO Professor (ProfessorCode,ProfessorName,DepartmentID,Salary,Phone ,Address ,Password)
VALUES (N'PRO10002',N'Le Van Ba',1,1000,N'0934888999',N'Duong D1, Q9, TPHCM',N'123456');

INSERT INTO Professor (ProfessorCode,ProfessorName,DepartmentID,Salary,Phone ,Address ,Password)
VALUES (N'PRO10003',N'Bui Huy',1,1000,N'0934888111',N'622 To ky, Q12, TPHCM',N'123456');

/* 4. Subject */

INSERT INTO Subject (SubjectCode,SubjectName,Credit)
VALUES (N'ACC101',N'Principle of accounting',3);

INSERT INTO Subject (SubjectCode,SubjectName,Credit)
VALUES (N'ISC301',N'E-Commerce',3);

INSERT INTO Subject (SubjectCode,SubjectName,Credit)
VALUES (N'PRM391',N'Mobile Programing',3);

INSERT INTO Subject (SubjectCode,SubjectName,Credit)
VALUES (N'PRJ311',N'Java Desktop',3);

INSERT INTO Subject (SubjectCode,SubjectName,Credit)
VALUES (N'PRJ321',N'Java Web',3);

INSERT INTO Subject (SubjectCode,SubjectName,Credit)
VALUES (N'PRO192',N'Java OOP',3);

/* 5. Schedule */

INSERT INTO Schedule (StartDate,EndDate,SemesterName)
VALUES ('2016/1/1','2016/4/1',N'Spring Semester 2016');

INSERT INTO Schedule (StartDate,EndDate,SemesterName)
VALUES ('2016/4/15','2016/9/10',N'Summer Semester 2016');

INSERT INTO Schedule (StartDate,EndDate,SemesterName)
VALUES ('2016/9/15','2016/12/15',N'Fall Semester 2016');

INSERT INTO Schedule (StartDate,EndDate,SemesterName)
VALUES ('2017/1/1','2017/4/1',N'Spring Semester 2017');

INSERT INTO Schedule (StartDate,EndDate,SemesterName)
VALUES ('2017/4/15','2017/9/10',N'Summer Semester 2017');

INSERT INTO Schedule (StartDate,EndDate,SemesterName)
VALUES ('2017/9/15','2017/12/15',N'Fall Semester 2017');

/* 6. PrequisiteManager */
INSERT INTO PrequisiteManager (SubjectRepresented,PrequisiteSubject)
VALUES (N'PRJ311',N'PRO192');

INSERT INTO PrequisiteManager (SubjectRepresented,PrequisiteSubject)
VALUES (N'PRJ321',N'PRO192');

/* 7. Section */

INSERT INTO Section (SectionNo,SeatingCapacity , StartDate,EndDate ,ProfessorCode ,RepresentedSubject,SemesterBelong)
VALUES (N'SEC00001',25,'2017/9/15','2017/12/15',N'PRO10001',N'PRO192',6);

INSERT INTO Section (SectionNo,SeatingCapacity , StartDate,EndDate ,ProfessorCode ,RepresentedSubject,SemesterBelong)
VALUES (N'SEC00002',25,'2017/9/15','2017/12/15',N'PRO10002',N'PRJ311',6);

INSERT INTO Section (SectionNo,SeatingCapacity , StartDate,EndDate ,ProfessorCode ,RepresentedSubject,SemesterBelong)
VALUES (N'SEC00003',25,'2017/9/15','2017/12/15',N'PRO10002',N'ISC301',6);

INSERT INTO Section (SectionNo,SeatingCapacity , StartDate,EndDate ,ProfessorCode ,RepresentedSubject,SemesterBelong)
VALUES (N'SEC00004',25,'2017/9/15','2017/12/15',N'PRO10001',N'PRJ321',6);

/*  8. SubjectTeamplate */
INSERT INTO SubjectTeamplate (SubjectID,MarkTitle,Percentage)
VALUES (N'PRO192','Quiz',0.3);

INSERT INTO SubjectTeamplate (SubjectID,MarkTitle,Percentage)
VALUES (N'PRO192','Assignment',0.3);

INSERT INTO SubjectTeamplate (SubjectID,MarkTitle,Percentage)
VALUES (N'PRO192','Final exam',0.4);

INSERT INTO SubjectTeamplate (SubjectID,MarkTitle,Percentage)
VALUES (N'PRJ321','Quiz',0.2);

INSERT INTO SubjectTeamplate (SubjectID,MarkTitle,Percentage)
VALUES (N'PRJ321','Practical',0.2);

INSERT INTO SubjectTeamplate (SubjectID,MarkTitle,Percentage)
VALUES (N'PRJ321','Assignment',0.2);

INSERT INTO SubjectTeamplate (SubjectID,MarkTitle,Percentage)
VALUES (N'PRJ321','Final exam',0.4);

INSERT INTO SubjectTeamplate (SubjectID,MarkTitle,Percentage)
VALUES (N'PRJ311','Quiz',0.3);

INSERT INTO SubjectTeamplate (SubjectID,MarkTitle,Percentage)
VALUES (N'PRJ311','Assignment',0.3);

INSERT INTO SubjectTeamplate (SubjectID,MarkTitle,Percentage)
VALUES (N'PRJ311','Final exam',0.4);

INSERT INTO SubjectTeamplate (SubjectID,MarkTitle,Percentage)
VALUES (N'ISC301','Quiz',0.3);

INSERT INTO SubjectTeamplate (SubjectID,MarkTitle,Percentage)
VALUES (N'ISC301','Assignment',0.3);

INSERT INTO SubjectTeamplate (SubjectID,MarkTitle,Percentage)
VALUES (N'ISC301','Final exam',0.4);

INSERT INTO SubjectTeamplate (SubjectID,MarkTitle,Percentage)
VALUES (N'PRM391','Quiz',0.3);

INSERT INTO SubjectTeamplate (SubjectID,MarkTitle,Percentage)
VALUES (N'PRM391','Assignment',0.3);

INSERT INTO SubjectTeamplate (SubjectID,MarkTitle,Percentage)
VALUES (N'PRM391','Final exam',0.4);

INSERT INTO SubjectTeamplate (SubjectID,MarkTitle,Percentage)
VALUES (N'ACC101','Quiz',0.3);

INSERT INTO SubjectTeamplate (SubjectID,MarkTitle,Percentage)
VALUES (N'ACC101','Assignment',0.3);

INSERT INTO SubjectTeamplate (SubjectID,MarkTitle,Percentage)
VALUES (N'ACC101','Final exam',0.4);

 /*  9. SectionSchedule */
INSERT INTO SectionSchedule (SectionID,[Date],Slot,Duration,Room)
VALUES (N'SEC00001','2017/9/15',1,90,N'P209');

INSERT INTO SectionSchedule (SectionID,[Date],Slot,Duration,Room)
VALUES (N'SEC00001','2017/9/15',2,90,N'P209');

INSERT INTO SectionSchedule (SectionID,[Date],Slot,Duration,Room)
VALUES (N'SEC00001','2017/9/16',1,90,N'P209');

INSERT INTO SectionSchedule (SectionID,[Date],Slot,Duration,Room)
VALUES (N'SEC00001','2017/9/16',2,90,N'P209');

INSERT INTO SectionSchedule (SectionID,[Date],Slot,Duration,Room)
VALUES (N'SEC00001','2017/9/17',1,90,N'P209');

INSERT INTO SectionSchedule (SectionID,[Date],Slot,Duration,Room)
VALUES (N'SEC00001','2017/9/17',2,90,N'P209');

INSERT INTO SectionSchedule (SectionID,[Date],Slot,Duration,Room)
VALUES (N'SEC00001','2017/9/18',1,90,N'P209');

INSERT INTO SectionSchedule (SectionID,[Date],Slot,Duration,Room)
VALUES (N'SEC00001','2017/9/18',2,90,N'P209');

/* 10. StudentTranscript */
INSERT INTO StudentTranscript (StudentCode,SectionID)
VALUES (N'SE61769','SEC00001');

INSERT INTO StudentTranscript (StudentCode,SectionID)
VALUES (N'SE61770','SEC00001');

INSERT INTO StudentTranscript (StudentCode,SectionID)
VALUES (N'SE61771','SEC00001');

INSERT INTO StudentTranscript (StudentCode,SectionID)
VALUES (N'SE61772','SEC00001');

INSERT INTO StudentTranscript (StudentCode,SectionID)
VALUES (N'SE61769','SEC00002');

INSERT INTO StudentTranscript (StudentCode,SectionID)
VALUES (N'SE61770','SEC00002');

INSERT INTO StudentTranscript (StudentCode,SectionID)
VALUES (N'SE61771','SEC00002');
 
/* Transcript Mark Entry */

/* Transcript Attendance Entry */

ALTER TABLE SubjectTeamplate
ADD Percentage decimal(19,3)

ALTER TABLE SubjectTeamplate
DROP COLUMN  Percentage

 


