using System;
namespace ConsoleAPP
{
	public class Student
	{
        public Student()
        {
            _staticId++;
            No = _staticId;

        }
        public Student(int no,string fullName, string email,string groupNo,DateTime startDate,double point)
        {
            this.No = no;
            this.FullName = FullName;
            this.Email = email;
            this.GroupNo = groupNo;
            this.StartDate = startDate;
            this.Point = point;
        }
        public readonly int No;
        public string FullName;
        public string Email;
        public string GroupNo;
        public DateTime StartDate;
        public double Point;
        public static int _staticId;
    }
}

