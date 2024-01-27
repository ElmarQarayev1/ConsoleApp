﻿using ConsoleAPP;
using ConsoleAPP.Exceptions;

Course course = new Course();

string secim;
do
{
    secim = SecimEt();

    switch (secim)
    {
        case "1":
            AddStudent();          
            break;
        case "2":
            RemoveStudent();
            break;
        case "3":
            ShowStudents();
            break;
        case "4":
            GetStudentByGroupNo();
            break;
        case "5":
            GetSelectedGroupInfo();
            break;
        case "6":
            FindStudentByNo();
            break;
        case "7":
            SearchWithDate();
            break;
        case "8":
            SearchWithPointRange();
            break;
        case "9":
            AvaragePoint();
            break;
        case "10":
            ShowAllGroupInfo();
            break;
        default:
            Console.WriteLine("Secim yanlisdir!");
            break;
    }

} while (secim != "0");

string SecimEt()
{
    ShowMenu();
    Console.WriteLine("Emeliyyat secin: ");
    return Console.ReadLine();
}
void ShowMenu()
{
    Console.WriteLine("1.Telebe elave et:");
    Console.WriteLine("2.Telebe sil:");
    Console.WriteLine("3.Telebelere bax:");
    Console.WriteLine("4.Secilmis groupdaki telebelere bax:");
    Console.WriteLine("5.Secilmis groupa bax:");
    Console.WriteLine("6.No deyerine gore axtaris at:");
    Console.WriteLine("7.Tarix aralığına görə axtarış et:");
    Console.WriteLine("8.Point aralığına görə axtarış et:");
    Console.WriteLine("9.Qrup ortalamasına bax:");
    Console.WriteLine("10.Qrup və tələbə saylarına bax:");
    Console.WriteLine("11.Çıx:");
}
void AddStudent()
{
    
    string fullname;
    do
    {
        Console.WriteLine("FullName: ");
        fullname = Console.ReadLine();
    } while (String.IsNullOrWhiteSpace(fullname)|| !fullname.CheckFullname());

    string email="";
    bool check;
    do
    {
        try
        {
            
            check = false;            
            do
            {
                
                Console.WriteLine("Email: ");
                email = Console.ReadLine();

            } while (String.IsNullOrWhiteSpace(email) || !email.IsEmailValid());

            check = course.CheckEmail(email);
            if (check)
            {
                Console.WriteLine("eyni adli email daxil etmek olmaz!");
            }
            
        }
        catch
        {
            
            check = true;    
        }

    } while (check);
   
    
    string groupNo;
    do
    {
        Console.WriteLine("GroupNo: ");
         groupNo = Console.ReadLine();

    } while (String.IsNullOrWhiteSpace(groupNo) || groupNo.Length!=4);
    bool check1;
    string StrDateTime;
    DateTime startTime=DateTime.Now;
    do
    {
        try
        {
            check1 = false;
            do
            {
                Console.WriteLine("DateTime daxil edin:");
                StrDateTime = Console.ReadLine();
            } while (!DateTime.TryParse(StrDateTime, out startTime));
            check1 = course.CheckDate(startTime);
            if (check1)
            {
                Console.WriteLine("daxil etdiyiniz tarix indiki tarixden evveldir!");
            }

        }
        catch
        {

            check1 = true;
        }

    } while (check1);
   
  
    string StrPoint;
    double point;
    do
    {
        Console.WriteLine("point i daxil edin:");
        StrPoint = Console.ReadLine();

    } while (!double.TryParse(StrPoint,out point)||point>100||point<0);

     
checkIsWarranty:
    Console.WriteLine("Zemanetli telebedirmi? y/n");
    string StrIsWarranty = Console.ReadLine();

    Student student;
   
    if (StrIsWarranty == "y")
    {
        string PrevgroupNo;
        do
        {
            Console.WriteLine("Prev GroupNo: ");
            PrevgroupNo = Console.ReadLine();

        } while (String.IsNullOrWhiteSpace(PrevgroupNo));

     student = new WarrantyStudent(fullname,email,groupNo,startTime,point, PrevgroupNo);
    }
    else if (StrIsWarranty == "n")
    {
         student= new Student(fullname, email, groupNo, startTime,point);
    }
    else
        goto checkIsWarranty;

    try
    {
        course.AddStudent(student);
    }
    catch (WarrantyStudentLimit)
    {
        Console.WriteLine("2 den artiq warranty student ola bilmez!");
    }
    catch (GroupLimitException)
    {

        Console.WriteLine("bir grupda 16 dan artiq telebe ola bilmez!");
    }
    catch (Exception)
    {
        Console.WriteLine("bilinmedik bir xeta bas verdi:(");
    } 
}
void ShowStudents()
{
    Console.WriteLine("1.Butun telebeler");
    Console.WriteLine("2.zemanetli telebeler");
    Console.WriteLine("3.zamanetden gelmeyenler");
    Console.WriteLine("Secim:");
    string secimm = Console.ReadLine();

    switch (secimm)
    {
        case "1":
            for (int i = 0; i < course.Students.Length; i++)
                Console.WriteLine(course.Students[i]);
            break;
        case "2":
            var zemanetli = course.GetWarrantyStudents();
            for (int i = 0; i < zemanetli.Length; i++)
                Console.WriteLine(zemanetli[i]);
            break;
        case "3":
            var zemanetsiz = course.GetNonWarrantyStudents();
            for (int i = 0; i < zemanetsiz.Length; i++)
                Console.WriteLine(zemanetsiz[i]);
            break;
        default:
            Console.WriteLine("Secim yanlisdir!");
            break;
    }
}
void RemoveStudent()
{
    for (int i = 0; i < course.Students.Length; i++)
        Console.WriteLine(course.Students[i]);
    Console.WriteLine("Telebe Nomresi qeyd edin:");
    string noStr;
    int no;

    do
    {
         noStr = Console.ReadLine();
       
    } while (!int.TryParse(noStr,out no));
    
    try
    {
        course.RemoveStudentByNo(no);
    }
    catch (StudentNotFoundException)
    {
        Console.WriteLine($"qeyd etdiyiniz nomreli telebe yoxdur");
    }
    
    catch
    {
        Console.WriteLine("bilinmedik  bir xeta bas verdi");
    }
}
void GetStudentByGroupNo()
{
    string groupNo;
    do
    {
        Console.WriteLine("axaracaginiz qrupun nomresini daxil edin: ");
         groupNo = Console.ReadLine();

    } while (String.IsNullOrWhiteSpace(groupNo));

    var studentByGroupNo = course.GetStudentsByGroupNo(groupNo);
    for (int i = 0; i < studentByGroupNo.Length; i++)
    {
        Console.WriteLine(studentByGroupNo[i]);

    }  
    
}
void GetSelectedGroupInfo()
{
    string groupNo;
    do
    {
        Console.WriteLine("axaracaginiz qrupun nomresini daxil edin: ");
        groupNo = Console.ReadLine();

    } while (String.IsNullOrWhiteSpace(groupNo));

    course.GetSelectedGroupInfo(groupNo);

}
void FindStudentByNo()
{
   
    string StrNo;
    int no;
    do
    {
        Console.WriteLine("axtaracaginiz telebenin nomresini daxil edin:");
        StrNo = Console.ReadLine();

    } while (!int.TryParse(StrNo,out no));
    if(course.FindStudentByNo(no)!=null)
    Console.WriteLine(course.FindStudentByNo(no));
    else
    {
       Console.WriteLine($"{no} Telebe yoxdur!");
    }

}
void SearchWithDate()
{
    string StrDateTime1;
    DateTime FirstTime;
    do
    {
        Console.WriteLine("DateTime1 daxil edin:");
        StrDateTime1 = Console.ReadLine();
    } while (!DateTime.TryParse(StrDateTime1, out FirstTime));
    string StrDateTime2;
    DateTime SecondTime;
    do
    {
        Console.WriteLine("DateTime2 daxil edin:");
        StrDateTime2 = Console.ReadLine();
    } while (!DateTime.TryParse(StrDateTime2, out SecondTime));

   var search=course.SearchWithDate(FirstTime,SecondTime);
    for (int i = 0; i < search.Length; i++)
    {
        Console.WriteLine(search[i]);

    }
    
}
void SearchWithPointRange()
{
    string StrPoint1;
    double point1;
    do
    {
        Console.WriteLine("axtarmaq istediyiniz araligin ilk heddini yazin:");
        StrPoint1 = Console.ReadLine();


    } while (!double.TryParse(StrPoint1, out point1));

    string StrPoint2;
    double point2;
    do
    {
        Console.WriteLine("axtarmaq istediyiniz araligin son heddini yazin:");
        StrPoint2 = Console.ReadLine();


    } while (!double.TryParse(StrPoint2, out point2));

    var search = course.GetStudentsByPointRange(point1, point2);
    for (int i = 0; i < search.Length; i++)
    {
        Console.WriteLine(search[i]);

    }
}
void AvaragePoint()
{
    string groupNo;
    do
    {
        Console.WriteLine("axaracaginiz qrupun nomresini daxil edin: ");
        groupNo = Console.ReadLine();

    } while (String.IsNullOrWhiteSpace(groupNo));

    Console.WriteLine(course.GetGroupAvg(groupNo));
}
void ShowAllGroupInfo()
{
    course.GetAllGroupsInfo(); 
}


