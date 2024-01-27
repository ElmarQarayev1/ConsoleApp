﻿using System;
namespace ConsoleAPP
{
	public class WarrantyStudent:Student
	{
		public WarrantyStudent()
		{

		}

		public WarrantyStudent(string fullName,string email, string groupNo,DateTime startDate,double point,string prevGroupNo):base(fullName,email,groupNo,startDate,point)
		{
			this.PrevGroupNo = prevGroupNo;
		}

		public string PrevGroupNo { get; set; }

        public override string ToString()
        {
            return base.ToString() + " - PrevGroupNo: " + PrevGroupNo;
        }
    }
}

