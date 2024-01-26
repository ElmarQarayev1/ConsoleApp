using ConsoleAPP;

Course course = new Course();

string secim;
do
{
    secim = SecimEt();

    switch (secim)
    {
        case "1":
            
            break;
        case "2":
           
            break;
        case "3":
           
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
