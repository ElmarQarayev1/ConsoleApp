using ConsoleAPP;
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
        case "11":
            Console.WriteLine("programdan cixildi");
            break;
        default:
            Console.WriteLine("Secim yanlisdir!");
            break;
    }

} while (secim != "11");

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
    FullName:
    Console.WriteLine("Fullnameyi daxil edin:");
    string fullname = Console.ReadLine();
    if (CheckFullName(fullname))
    {
        Console.WriteLine("zehmet olmasa fullnameyi duzgun daxil edin!");
        goto FullName;
    }
    Email:
    Console.WriteLine("Emaili daxil edin:");
    string email = Console.ReadLine();
    if (CheckEmaill(email))
    {
        Console.WriteLine("zehmet olmasa emaili duzgun daxil edin!");
        goto Email;
    }
    if (course.CheckEmail(email))
    {
        Console.WriteLine("eyni adli email daxil etmek mumkun deyil!");
        goto Email;
    }
    GroupNo:
    Console.WriteLine("group no daxil edin:");
    string groupNo = Console.ReadLine();
    if (CheckGroupNo(groupNo))
    {
        Console.WriteLine("zehmet olmasa duzgun group no daxil edin!");
        goto GroupNo;
    }
    DataTimee:
    Console.WriteLine("DateTime daxil edin:");
    string strDateTime = Console.ReadLine();
    DateTime startTime;
    if(!DateTime.TryParse(strDateTime,out startTime))
    {
        Console.WriteLine("zehmet olmasa duzgun daxil edin!");
        goto DataTimee;
    }
    if (course.CheckDate(startTime))
    {
        Console.WriteLine("kecmis tarix olmaz!");
        goto DataTimee;
    }
    Point:
    Console.WriteLine("Pointi daxil edin:");
    string strPoint = Console.ReadLine();
    double point;
    if(!double.TryParse(strPoint,out point))
    {
        Console.WriteLine("zehmet olmasa duzgun daxil edin!");
        goto Point;
    }
    if(point<0 || point > 100)
    {
        Console.WriteLine("0 ve 100 araliginda olmalidir!");
        goto Point;
    }
    checkIsWarranty:
    Console.WriteLine("Zemanetli telebedirmi? y/n");
    string StrIsWarranty = Console.ReadLine();

    Student student;
      
    if (StrIsWarranty == "y")
    {
   
        PrevGroupNo:
        Console.WriteLine("Prev groupNo daxil edin:");
        string prevGroupNo = Console.ReadLine();
        if (CheckGroupNo(prevGroupNo))
        {
            Console.WriteLine("zehmet olmasa duzgun daxil edin!");
            goto PrevGroupNo;

        }
        if (prevGroupNo == groupNo)
        {
            Console.WriteLine("evvelki groupNo ile eyni ola bilmez!");
            goto PrevGroupNo;
        }
        
        student = new WarrantyStudent(fullname, email, groupNo, startTime, point, prevGroupNo);
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
        goto GroupNo;


    }


    catch (Exception)
    {
        Console.WriteLine("bilinmeyen xeta bas verdi(:");
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
bool CheckFullName(string fullname)
{
    if (String.IsNullOrWhiteSpace(fullname)) return true;
    if (!fullname.CheckFullname()) return true;

    return false;
}
bool CheckEmaill(string email)
{
    if (String.IsNullOrWhiteSpace(email)) return true;
    if (!email.IsEmailValid()) return true;

    return false;

}
bool CheckGroupNo(string groupNo)
{
    if (String.IsNullOrWhiteSpace(groupNo)) return true;
    if (groupNo.Length != 4) return true;

    return false;

}



