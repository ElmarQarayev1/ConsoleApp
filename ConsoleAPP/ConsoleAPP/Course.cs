using System;
namespace ConsoleAPP
{
	public class Course:IWarrantyManager,ICourseManager
	{
		

        public double WarrantyStudentPercent => throw new NotImplementedException();

        public Student[] Students => throw new NotImplementedException();

        public void AddStudent(Student st)
        {
            throw new NotImplementedException();
        }

        public Student FindStudentByNo(int no)
        {
            throw new NotImplementedException();
        }

        public int FindStudentIndexByNo(int no)
        {
            throw new NotImplementedException();
        }

        public double GetGroupAvg(string groupNo)
        {
            throw new NotImplementedException();
        }

        public Student[] GetStudentsByGroupNo(string groupNo)
        {
            throw new NotImplementedException();
        }

        public Student[] GetStudentsByPointRange(double min, double max)
        {
            throw new NotImplementedException();
        }

        public Student[] GetWarrantyStudents()
        {
            throw new NotImplementedException();
        }

        public void RemoveStudentByNo(int no)
        {
            throw new NotImplementedException();
        }
    }
}

