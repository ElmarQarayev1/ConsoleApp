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

            int sameGroupCount = 0;
            int warrantyStudentCount = 0;

            for (int i = 0; i < _students.Length; i++)
            {
                
                if (_students[i].GroupNo == st.GroupNo)
                {

                    sameGroupCount++;

                    if (_students[i] is WarrantyStudent)
                    {
                        warrantyStudentCount++;
                    }
                }
            }
            
            if (sameGroupCount >= 16)
            {
                throw new GroupLimitException();
            }

            if (st is WarrantyStudent && warrantyStudentCount >= 2)
            {
                throw new WarrantyStudentLimit();
            }
      
            Array.Resize(ref _students, _students.Length + 1);
            _students[_students.Length - 1] = st;
        }
       
        public bool CheckEmail(string email)
        {
            for (int i = 0; i < _students.Length; i++)
            {
                if (_students[i].Email == email)
                {
                    return true;
                }
            }
            return false;
        }
        public bool CheckDate(DateTime dateTime)
        {
            var diff = DateTime.Now - dateTime;
            if (diff.TotalDays >=1)
            {
                return true;
            }
            return false;
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

                int count = 0;
                double avaragePoint = 0;
                for (int i = 0; i < _students.Length; i++)
                {
                    if (_students[i].GroupNo == groupNo)
                    {
                        count++;
                        avaragePoint += _students[i].Point;
                    }

                }
            
                return count == 0 ? 0 : (avaragePoint / count);
            
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
        public void GetSelectedGroupInfo(string groupNo)
        { 
            int warrantyCount = 0;
            int totalCount = 0;
            int nonWarrantyCount = 0;
            for (int i = 0; i < _students.Length; i++)
            {
                if (_students[i].GroupNo == groupNo)
                {
                    totalCount++;

                    if (_students[i] is WarrantyStudent)
                    {
                        warrantyCount++;
                    }

                    else
                    {
                        nonWarrantyCount++;
                    }
                }
                              
            }
            Console.WriteLine($"{groupNo} groupunda {totalCount} adam var");
            Console.WriteLine($"{groupNo} groupunda {nonWarrantyCount} sayda zemanetsiz oxuyan telebe var");
            Console.WriteLine($"{groupNo} groupunda {warrantyCount} sayda zemanetli oxuyan telebe var");

        }
        public Student[] GetStudentsByPointRange(double point1, double point2)
        {
            
            Student[] students = new Student[0];

            for (int i = 0; i < _students.Length; i++)
            {
                if ((_students[i].Point >= point1 && _students[i].Point <= point2) || (_students[i].Point <= point1 && _students[i].Point >= point2 ))
                {
                    Array.Resize(ref students, students.Length + 1);
                    students[students.Length - 1] = _students[i];
                }
            }
            return students;
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
        public int GetWarrantyStudentCount()
        {
            int count = 0;
            for (int i = 0; i < _students.Length; i++)
            {
                if (_students[i] is WarrantyStudent)
                {
                    count++;
                }
            }
            return count;
        }

        public int GetNonWarrantyStudentCount()
        {
            int count = 0;
            for (int i = 0; i < _students.Length; i++)
            {
                if (!(_students[i] is WarrantyStudent))
                {
                    count++;
                }
            }
            return count;
        }
        public Student[] SearchWithDate(DateTime dateTime1, DateTime dateTime2)
        {
            Student[] students = new Student[0];

            for (int i = 0; i <_students.Length ; i++)
            {
                if ((_students[i].StartDate>=dateTime1 && _students[i].StartDate <= dateTime2) || (_students[i].StartDate <= dateTime1 && _students[i].StartDate >= dateTime2))
                {
                    Array.Resize(ref students, students.Length + 1);
                    students[students.Length - 1] = _students[i];
                }
            }

            return students;
        }
        public void GetAllGroupsInfo()
        {
            if (CheckHas())
            {
                Console.WriteLine("hal hazirda hec bir telebe daxil edilmeyib!");
                return;
            }
            for (int i = 0; i < _students.Length; i++)
            {
                string grupNo = _students[i].GroupNo;

                if (!checkGroupProses(grupNo, i))
                {
                    int allStudent = 0;
                    int nonWarrantyStudentCount = 0;
                    int warrantyStudentCount = 0;

                    for (int j = 0; j < _students.Length; j++)
                    {
                        if (_students[j].GroupNo == grupNo)
                        {
                            allStudent++;

                            if (_students[j] is WarrantyStudent)
                            {
                                warrantyStudentCount++;
                            }
                            else
                            {
                                nonWarrantyStudentCount++;
                            }
                        }
                    }
                    Console.WriteLine($"Qrup {grupNo} melumatlari:");
                    Console.WriteLine($"Cemi {allStudent} telebe var.");
                    Console.WriteLine($"{nonWarrantyStudentCount} sayda zemanetli olmayan telebe var.");
                    Console.WriteLine($"{warrantyStudentCount} sayda zemanetli telebe var.");
                    
                }
            }
        }

        
        private bool checkGroupProses(string groupNo, int currentIndex)
        {
            for (int i = 0; i < currentIndex; i++)
            {
                if (_students[i].GroupNo == groupNo)
                {
                    return true; 
                }
            }
            return false; 
        }
        private bool CheckHas()
        {
            return _students.Length == 0;
        }
    }
}

