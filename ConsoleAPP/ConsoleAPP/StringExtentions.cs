using System;
namespace ConsoleAPP
{
	public static class StringExtentions
	{
        public static bool CheckFullname( this string fullname)
        {
          
            string[] nameParts = fullname.Split(' ');

            if (nameParts.Length == 2)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (String.IsNullOrWhiteSpace(nameParts[i]) || !CheckIsLetter(nameParts[i]) || nameParts[i].Length<3)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
        public static bool CheckIsLetter( this string name)
        {
            for (int i = 0; i < name.Length; i++)
            {
                if (!char.IsLetter(name[i])) return false;

            }
            return true;

        }

        public static bool IsEmailValid(this string email)
        {

            if (!email.StartsWith("@") && email.Contains("@") && email.EndsWith(".az")&&!email.StartsWith("."))
            {
                string[] parts = email.Split('@');

                if (parts.Length == 2 && !parts[1].StartsWith("."))
                {
                    return true;
                }
            }
            return false;
        }
        public static string ChangeToCaptalize(this string fullname)
        {

            string[] parts = fullname.Split(' ');
            string part0 = parts[0][0].ToString().ToUpper()+""+parts[0].Substring(1).ToLower();
            string part1 = parts[1][0].ToString().ToUpper() + "" + parts[1].Substring(1).ToLower();
            return part0 + " " + part1;

        }
      
    }
}

