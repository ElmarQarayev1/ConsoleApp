using ConsoleAPP;

Course course = new Course();

string secim;
do
{
    secim = SecimEt();

    switch (secim)
    {
        case "1":

            AddProduct();
            
            break;
        case "2":
           
            break;
        case "3":
            ShowProducts();
            break;
        case "4":
            
            break;
        case "5":
          
            break;
        case "6":
           
            
            break;
        default:
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
void AddProduct()
{
    Console.WriteLine("FullName: ");
    string fullname;
    do
    {

        fullname = Console.ReadLine();
    } while (String.IsNullOrWhiteSpace(fullname));

    string email;
    do
    {
        Console.WriteLine("Email: ");

        email = Console.ReadLine();

    } while (String.IsNullOrWhiteSpace(email));

    string groupNo;
    do
    {
        Console.WriteLine("GroupNo: ");
         groupNo = Console.ReadLine();

    } while (String.IsNullOrWhiteSpace(groupNo));

    string StrDateTime;
    DateTime startTime;
    do
    {
        Console.WriteLine("DateTime daxil edin:");
        StrDateTime = Console.ReadLine();
    } while (!DateTime.TryParse(StrDateTime,out startTime));

    string StrPoint;
    double point;
    do
    {
        Console.WriteLine("point i daxil edin:");
        StrPoint = Console.ReadLine();

    } while (!double.TryParse(StrPoint,out point));

     
checkIsWarranty:
    Console.WriteLine("Zemanetli telebedirmi?? y/n");
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

    course.AddStudent(student);
}
void ShowProducts()
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

