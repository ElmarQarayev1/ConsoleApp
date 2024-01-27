using System;
namespace ConsoleAPP
{
	public class Course:IWarrantyManager,ICourseManager
	{
		

        public double WarrantyStudentPercent => throw new NotImplementedException();

        private Student[] _students = new Student[0];
        public Student[] Students => _students;

        public void AddStudent(Student st)
        {
            if (st is WarrantyStudent warranty)
            {
                Array.Resize(ref _students, _students.Length + 1);
                _students[_students.Length - 1] = st;
            }
            else
            {
                Array.Resize(ref _students, _students.Length + 1);
                _students[_students.Length - 1] = st;
            }
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
            Student[] warrantyStudents = new Student[0];

            for (int i = 0; i < _students.Length; i++)
            {
                if (_students[i] is WarrantyStudent warranty)
                {
                    Array.Resize(ref warrantyStudents, warrantyStudents.Length + 1);
                    warrantyStudents[warrantyStudents.Length - 1] = warranty;
                }
            }
            return warrantyStudents;
        }
        public Student[] GetNonWarrantyStudents()
        {
            Student[] nonWarranty = new Student[0];

            for (int i = 0; i < _students.Length; i++)
            {
                if (!(_students[i] is WarrantyStudent))
                {
                    Array.Resize(ref nonWarranty, nonWarranty.Length + 1);
                    nonWarranty[nonWarranty.Length - 1] = _students[i];
                }
            }
            return nonWarranty;
        }

        public void RemoveStudentByNo(int no)
        {
            throw new NotImplementedException();
        }
       
    }
}

