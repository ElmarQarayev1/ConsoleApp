using System;
namespace ConsoleAPP
{
	public interface ICourseManager
	{
		public Student[] Students { get;  }

		public void AddStudent(Student st);

		public void RemoveStudentByNo(int no);

		public Student[] GetStudentsByGroupNo(string groupNo);

		public Student FindStudentByNo(int no);

		public int FindStudentIndexByNo(int no);

		public Student[] GetStudentsByPointRange(double min,double max);

		public double GetGroupAvg(string groupNo);


    }
}

