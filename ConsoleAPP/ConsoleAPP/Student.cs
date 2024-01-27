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
        private string _fullName;
        private string _email;
        private string _groupNo;
        private DateTime _startDate;
        private double _point;

        public string FullName {
            get
            {
                return _fullName;
            }
            set
            {
                if (value.CheckFullname())
                {
                    _fullName =value.ChangeToCaptalize();
                }
            }
        }
        
        public string Email {
            get
            {
                return _email;
            }
            set
            {
                if (value.IsEmailValid())
                {
                    _email = value;
                }

            }
            }
       
        public string GroupNo {
            get
            {
                return _groupNo;
            }
            set
            {
                if (value.Length == 4)
                {
                    _groupNo = value;

                }
            }
        }
        
        public DateTime StartDate
        {
            get
            {
                return _startDate;

            }
            set
            {
                if (value >= DateTime.Now)
                {
                    _startDate = value;
                }
                
            }
        }
        
        public double Point
        {
            get
            {
                return _point;
            }
            set
            {
                if(value>=0 && value <= 100)
                {
                    _point = value;
                }
            }
        }
        public static int _staticId;
     

        public override string ToString()
        {
            return $"No: {No} - Fullname: {FullName} - email: {Email} - GroupNo:{GroupNo}- StartDate:{StartDate.ToString("dd.MM.yyyy")}- point: {Point}";
        }
    }
  
}

