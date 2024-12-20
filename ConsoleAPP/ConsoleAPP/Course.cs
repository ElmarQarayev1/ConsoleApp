﻿using System;
using ConsoleAPP.Exceptions;

namespace ConsoleAPP
{
	public class Course:IWarrantyManager,ICourseManager
	{
        private double _warrantyStudentPercent ;
        public double WarrantyStudentPercent =>  _warrantyStudentPercent;
        
        private Student[] _students = new Student[0];
        public Student[] Students => _students;
        private const int maxGroupCount = 16;
        private const int maxWarrantyStudentCount = 2;

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
            if (sameGroupCount >= maxGroupCount)
            {
                throw new GroupLimitException();
            }

            if (st is WarrantyStudent && warrantyStudentCount >= maxWarrantyStudentCount)
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
            if (diff.TotalDays >= 1)
            {
                return true;
            }
            return false;
        }
        
        public Student FindStudentByNo(int no)
        {
         
          for (int i = 0; i < _students.Length; i++)
          {
              if(_students[i].No == no)
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
                
                return count == 0 ? -1 : (avaragePoint / count);
            
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
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{groupNo} groupunda {totalCount} adam var");
            Console.WriteLine($"{groupNo} groupunda {nonWarrantyCount} sayda zemanetsiz oxuyan telebe var");
            Console.WriteLine($"{groupNo} groupunda {warrantyCount} sayda zemanetli oxuyan telebe var");
            Console.ForegroundColor = ConsoleColor.White;
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
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("hal hazirda hec bir telebe daxil edilmeyib!");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            for (int i = 0; i < _students.Length; i++)
            {
                string groupNo = _students[i].GroupNo;

                if (!checkGroupProses(groupNo, i))
                {
                    int allStudent = 0;
                    int nonWarrantyStudentCount = 0;
                    int warrantyStudentCount = 0;

                    for (int j = 0; j < _students.Length; j++)
                    {
                        if (_students[j].GroupNo == groupNo)
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
                    _warrantyStudentPercent = ((double)warrantyStudentCount / allStudent) * 100;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Qrup {groupNo} melumatlari:");
                    Console.WriteLine($"Cemi {allStudent} telebe var.");
                    Console.WriteLine($"Zemanetden gelmeyen telebelerin sayi: {nonWarrantyStudentCount}");
                    Console.WriteLine($"Zemanetden gelen telebelerin sayi: {warrantyStudentCount}");
                    Console.WriteLine($"zemanetli telebelerin faizi: {_warrantyStudentPercent}");
                    Console.ForegroundColor = ConsoleColor.White;

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

