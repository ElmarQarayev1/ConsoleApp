using System;
using ConsoleAPP.Exceptions;

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
            for (int i = 0; i < _students.Length; i++)
            {
                if (_students[i].No == no)
                {
                    return _students[i];
                }
            }
            return null;
        }

        public int FindStudentIndexByNo(int no)
        {
            for (int i = 0; i < _students.Length; i++)
            {
                if (_students[i].No == no)
                {
                    return i;
                }
            }
            return -1;
        }
        public void RemoveStudentByNo(int no)
        {
            var wantedStudent = FindStudentByNo(no);
            if (wantedStudent == null) throw new StudentNotFoundException();

            var wantedIndex = FindStudentIndexByNo(no);
            for (int i = wantedIndex; i < _students.Length - 1; i++)
            {
                var temp = _students[i];
                _students[i] = _students[i + 1];
                _students[i + 1] = temp;
            }
            Array.Resize(ref _students, _students.Length - 1);

        }

        public double GetGroupAvg(string groupNo)
        {
            throw new NotImplementedException();
        }

        public Student[] GetStudentsByGroupNo(string groupNo)
        {
            Student[] students = new Student[0];
            for (int i = 0; i < _students.Length; i++)
            {
                if (_students[i].GroupNo == groupNo)
                {
                    Array.Resize(ref students, students.Length + 1);
                    students[students.Length - 1] = _students[i];
                }
            }
            return students;
            
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

       
       
    }
}

