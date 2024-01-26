using System;
namespace ConsoleAPP
{
	public class WarrantyStudent:Student
	{
		public WarrantyStudent()
		{

		}

		public WarrantyStudent(int no,string fullName,string email, string groupNo,DateTime startDate,double point,string prevGroupNo):base(no,fullName,email,groupNo,startDate,point)
		{
			this.PrevGroupNo = prevGroupNo;
		}

		public string PrevGroupNo;
	}
}

