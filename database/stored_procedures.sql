use [StudentData]
/* 1. tinh total credit cua 1 hoc sinh */

create proc spCalculateTotalCreditByStudentID
@StudentID nvarchar(20)
as
begin
    select  SUM(Credit) AS totalCredit from Subject
	where SubjectCode  IN (SELECT s.RepresentedSubject
	                       FROM StudentTranscript st JOIN Section s ON st.SectionID = s.SectionNo
	                       where st.StudentCode = @StudentID AND st.LearningStatus = N'pass')
end

/* using out */
create proc spCalculateTotalCreditByStudentID1
@StudentID nvarchar(20),
@totalCredit int output
as
begin
    select  @totalCredit = SUM(Credit) from Subject
	where SubjectCode  IN (SELECT s.RepresentedSubject
	                       FROM StudentTranscript st JOIN Section s ON st.SectionID = s.SectionNo
	                       where st.StudentCode = @StudentID AND st.LearningStatus = N'pass')
end

spCalculateTotalCreditByStudentID N'SE61744'

/* drop proc spCalculateTotalCreditByStudentID*/ 
/* see text sp_helptext spCalculateTotalCreditByStudentID */

/* 2. tinh average mark cua 1 hoc sinh trong 1 khoa hoc */
create proc spCalculateAverageGradeByTranscriptID
@TranscriptID int,
@AverageGrade float output
as
begin
	SELECT @AverageGrade = SUM((st.Percentage * tme.Grade))
	FROM TranscriptMarkEntry tme JOIN SubjectTeamplate st ON tme.SubjectTeamplateID = st.ID
	WHERE tme.TranscriptID = @TranscriptID
end
------------------
create proc spCalculateAverageGradeByTranscriptID
@TranscriptID int,
@AverageGrade float output
as
begin
	SELECT @AverageGrade = SUM((st.Percentage * tme.Grade))
	FROM TranscriptMarkEntry tme JOIN SubjectTeamplate st ON tme.SectionTemplateID = st.ID
	WHERE tme.TranscriptID = @TranscriptID
end

/* 3. tim ra top 10 sv trong hoc 1 hoc ki */

create proc spFindTop10Student
@Semester int
as
begin
	SELECT top 10 st.StudentCode as StudentCode , SUM(st.AverageGrade  * sub.Credit) / SUM(sub.Credit) as SemesterAverageGrade
	FROM StudentTranscript st JOIN Section sec ON st.SectionID = sec.SectionNo
	                             JOIN Subject sub ON sec.RepresentedSubject = sub.SubjectCode 
	WHERE sec.SemesterBelong = @Semester
	group by st.StudentCode
	order by SemesterAverageGrade desc
end

spFindTop10Student 6

/* 4. liet ke tat ca khoa hoc cua 1 sv*/

create proc spFindAllCourseByStudentID
@StudentID nvarchar(20)
as
begin
	Select * from StudentTranscript where StudentCode = @StudentID
end

/* 5. liệt kê tất cả slot lấy sectionID, room, professorID, từ ngày "25/9/2017 - 29/9/2017" của hoc sinh SE61769 */
create proc spListWeeklyScheduleOfSpecificStudent
@StudentID nvarchar(20),
@FromDate Date,
@ToDate Date
as
begin
	select  * from SectionSchedule 
	where SectionID IN (
					Select st.SectionID from StudentTranscript st join Section sec on st.SectionID = sec.SectionNo
							  where st.StudentCode = @StudentID and sec.SemesterBelong=6)
							  and Date >= @FromDate and Date <= @ToDate 
end
/* 6. liet ke tat ca khoa hoc lay tat ca sectionID; status; credit; GPA;semesterID; semesterName; where studenID = se61769 */
create proc spGetAllSectionOfSpecificStudent
@StudentID nvarchar(20)
as
begin
	select  * from 
			Section sec join StudentTranscript st on sec.SectionNo = st.SectionID
						JOIN Subject sub ON sec.RepresentedSubject = sub.SubjectCode 
						JOIN Schedule sche ON sche.SemesterID = sec.SemesterBelong
	where st.StudentCode = @StudentID
end



