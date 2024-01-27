using System;
using System.Xml.Linq;

namespace ConsoleAPP
{
	public class Student
	{
        public Student()
        {
            _staticId++;
            No = _staticId;

        }
        public Student(string fullName, string email,string groupNo,DateTime startDate,double point):this()
        {           
            this.FullName =fullName;
            this.Email = email;
            this.GroupNo = groupNo;
            this.StartDate = startDate;
            this.Point = point;
        }
        public readonly int No;
        public string FullName { get; set; }
        public string Email { get; set; }
        public string GroupNo { get; set; }
        public DateTime StartDate { get; set; }
        public double Point { get; set; }
        public static int _staticId;
     

        public override string ToString()
        {
            return $"No: {No} - Fullname: {FullName} - email: {Email} - GroupNo:{GroupNo}- StartDate:{StartDate.ToString("dd.MM.yyyy")}- point: {Point}";
        }
    }
  
}

