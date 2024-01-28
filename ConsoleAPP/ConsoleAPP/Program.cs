using ConsoleAPP;
using ConsoleAPP.Exceptions;

Console.ForegroundColor = ConsoleColor.White;
Console.BackgroundColor = ConsoleColor.Black;
Console.Clear();
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
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.Write("Emeliyyat secin: ");
    Console.ForegroundColor = ConsoleColor.White;
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
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("zehmet olmasa fullnameyi duzgun daxil edin!");
        Console.ForegroundColor = ConsoleColor.White;

        goto FullName;
    }
    Email:
    Console.WriteLine("Emaili daxil edin:");
    string email = Console.ReadLine();
    if (CheckEmaill(email))
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("zehmet olmasa emaili duzgun daxil edin!");
        Console.ForegroundColor = ConsoleColor.White;
        goto Email;

    }
    if (course.CheckEmail(email))
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("eyni adli email daxil etmek mumkun deyil!");
        Console.ForegroundColor = ConsoleColor.White;

        goto Email;
    }
    GroupNo:
    Console.WriteLine("groupNo daxil edin:");
    string groupNo = Console.ReadLine();
    if (CheckGroupNo(groupNo))
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("zehmet olmasa duzgun groupNo daxil edin!");
        Console.ForegroundColor = ConsoleColor.White;
        goto GroupNo;
    }
    DataTimee:
    Console.WriteLine("DateTime daxil edin:");
    string strDateTime = Console.ReadLine();
    DateTime startTime;
    if(!DateTime.TryParse(strDateTime,out startTime))
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("zehmet olmasa Datetime i duzgun daxil edin!");
        Console.ForegroundColor = ConsoleColor.White;
        goto DataTimee;
    }
    if (course.CheckDate(startTime))
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("kecmis tarix olmaz!");
        Console.ForegroundColor = ConsoleColor.White;
        goto DataTimee;
    }
    Point:
    Console.WriteLine("Pointi daxil edin:");
    string strPoint = Console.ReadLine();
    double point;
    if(!double.TryParse(strPoint,out point))
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("zehmet olmasa duzgun daxil edin!");
        Console.ForegroundColor = ConsoleColor.White;
        goto Point;
    }
    if(point<0 || point > 100)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("0 ve 100 araliginda olmalidir!");
        Console.ForegroundColor = ConsoleColor.White;
        goto Point;
    }
checkIsWarranty:

    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("Zemanetli telebedirmi? y/n");
    Console.ForegroundColor = ConsoleColor.White;
    string StrIsWarranty = Console.ReadLine();

    Student student;
      
    if (StrIsWarranty == "y")
    {
   
        PrevGroupNo:
        Console.WriteLine("Prev groupNo daxil edin:");
        string prevGroupNo = Console.ReadLine();
        if (CheckGroupNo(prevGroupNo))
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("zehmet olmasa duzgun daxil edin!");
            Console.ForegroundColor = ConsoleColor.White;

            goto PrevGroupNo;

        }
        if (prevGroupNo == groupNo)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("evvelki groupNo ile eyni ola bilmez!");
            Console.ForegroundColor = ConsoleColor.White;
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
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("2 den artiq warranty student ola bilmez!");
        Console.ForegroundColor = ConsoleColor.White;

    }

    catch (GroupLimitException)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("bir grupda 16 dan artiq telebe ola bilmez!");
        Console.ForegroundColor = ConsoleColor.White;
        goto GroupNo;


    }
    catch (Exception)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("bilinmeyen xeta bas verdi(:");
        Console.ForegroundColor = ConsoleColor.White;

    }
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.WriteLine("Student elave edildi!");
    Console.ForegroundColor = ConsoleColor.White;

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
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < course.Students.Length; i++)
            Console.WriteLine(course.Students[i]);
            Console.ForegroundColor = ConsoleColor.White;
            break;
        case "2":
            Console.ForegroundColor = ConsoleColor.Blue;
            var zemanetli = course.GetWarrantyStudents();
            for (int i = 0; i < zemanetli.Length; i++)
                Console.WriteLine(zemanetli[i]);
            Console.ForegroundColor = ConsoleColor.White;
            break;
        case "3":
            Console.ForegroundColor = ConsoleColor.Blue;
            var zemanetsiz = course.GetNonWarrantyStudents();
            for (int i = 0; i < zemanetsiz.Length; i++)
                Console.WriteLine(zemanetsiz[i]);
            Console.ForegroundColor = ConsoleColor.White;
            break;
        default:
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Secim yanlisdir!");
            Console.ForegroundColor = ConsoleColor.White;
            break;
    }
}
void RemoveStudent()
{
    for (int i = 0; i < course.Students.Length; i++)
        Console.WriteLine(course.Students[i]);

    RemoveStudent:
    Console.WriteLine("Telebe Nomresi qeyd edin:");
    string noStr = Console.ReadLine();
    int no;
    if (!int.TryParse(noStr, out no))
    {

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("zehmet olmasa duzgun daxil edin!");
        Console.ForegroundColor = ConsoleColor.White;
        goto RemoveStudent;

    }
    
    try
    {
        course.RemoveStudentByNo(no);
    }
    catch (StudentNotFoundException)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine($"qeyd etdiyiniz nomreli telebe yoxdur");
        Console.ForegroundColor = ConsoleColor.White;

    }
    
    catch
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("bilinmedik bir xeta bas verdi");
        Console.ForegroundColor = ConsoleColor.White;
    }
}
void GetStudentByGroupNo()
{
      GetGroupNo:
    Console.WriteLine("axtaracaginiz qrupun nomresini daxil edin: ");
    string groupNo = Console.ReadLine();

    if (String.IsNullOrWhiteSpace(groupNo))
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("zehmet olmasa duzgun daxil edin!");
        Console.ForegroundColor = ConsoleColor.White;
        goto GetGroupNo;
    }

    var studentByGroupNo = course.GetStudentsByGroupNo(groupNo);
    for (int i = 0; i < studentByGroupNo.Length; i++)
    {
        Console.WriteLine(studentByGroupNo[i]);
    }     
}
void GetSelectedGroupInfo()
{
    GetSelectedGroupNo:
    Console.WriteLine("axtaracaginiz qrupun nomresini daxil edin: ");
    string groupNo = Console.ReadLine();

    if (String.IsNullOrWhiteSpace(groupNo))
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("zehmet olmasa duzgun daxil edin!");
        Console.ForegroundColor = ConsoleColor.White;
        goto GetSelectedGroupNo;
    }

    course.GetSelectedGroupInfo(groupNo);

}
void FindStudentByNo()
{
    StrNo:
    Console.WriteLine("axtaracaginiz telebenin nomresini daxil edin:");
    string StrNo = Console.ReadLine();
    int no;
    if(!int.TryParse(StrNo, out no))
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("zehmet olmasa duzgun daxil edin!");
        Console.ForegroundColor = ConsoleColor.White;
        goto StrNo;
    }
    if(course.FindStudentByNo(no)!=null)
    Console.WriteLine(course.FindStudentByNo(no));
    else
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine($"{no} Telebe yoxdur!");
        Console.ForegroundColor = ConsoleColor.White;
    }

}
void SearchWithDate()
{
    DataTimee1:
    Console.WriteLine("DateTime1 daxil edin:");
    string strFirstTime = Console.ReadLine();
    DateTime FirstTime;
    if (!DateTime.TryParse(strFirstTime, out FirstTime))
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("zehmet olmasa duzgun daxil edin!");
        Console.ForegroundColor = ConsoleColor.White;
        goto DataTimee1;
    }
    DataTimee2:
    Console.WriteLine("DateTime2 daxil edin:");
    string strSecondTime = Console.ReadLine();
    DateTime SecondTime;
    if (!DateTime.TryParse(strSecondTime, out SecondTime))
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("zehmet olmasa duzgun daxil edin!");
        Console.ForegroundColor = ConsoleColor.White;
        goto DataTimee2;
    }

    var search=course.SearchWithDate(FirstTime,SecondTime);
    for (int i = 0; i < search.Length; i++)
    {
        Console.WriteLine(search[i]);

    }    
}
void SearchWithPointRange()
{
    StrPointt1:
    Console.WriteLine("axtarmaq istediyiniz araligin ilk heddini yazin:");
    string StrPoint1 = Console.ReadLine();
    double point1;
    if(!double.TryParse(StrPoint1, out point1))
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("zehmet olmasa duzgun daxil edin:");
        Console.ForegroundColor = ConsoleColor.White;
        goto StrPointt1;
    }
    if(point1<0 || point1 > 100)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("daxil etdiyiniz eded 0 la 100 arasinda olmalidir!");
        Console.ForegroundColor = ConsoleColor.White;
        goto StrPointt1;
    }

    StrPointt2:
    Console.WriteLine("axtarmaq istediyiniz araligin ilk heddini yazin:");
    string StrPoint2 = Console.ReadLine();
    double point2;
    if (!double.TryParse(StrPoint2, out point2))
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("zehmet olmasa duzgun daxil edin:");
        Console.ForegroundColor = ConsoleColor.White;
        goto StrPointt2;
    }
    if (point2 < 0 || point2 > 100)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("daxil etdiyiniz eded 0 la 100 arasinda olmalidir!");
        Console.ForegroundColor = ConsoleColor.White;
        goto StrPointt2;
    }


    var search = course.GetStudentsByPointRange(point1, point2);
    for (int i = 0; i < search.Length; i++)
    {
        Console.WriteLine(search[i]);

    }
}
void AvaragePoint()
{
    GroupNoo:
    Console.WriteLine(" axtaracaginiz groupNo daxil edin:");
    string groupNo = Console.ReadLine();
    if (CheckGroupNo(groupNo))
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("zehmet olmasa duzgun groupNo daxil edin!");
        Console.ForegroundColor = ConsoleColor.White;
        goto GroupNoo;
    }
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



