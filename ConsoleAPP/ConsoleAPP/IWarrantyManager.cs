using System;
namespace ConsoleAPP
{
	public interface IWarrantyManager
	{
		public Student[] GetWarrantyStudents();

	    public double WarrantyStudentPercent{get;}

    }
}

