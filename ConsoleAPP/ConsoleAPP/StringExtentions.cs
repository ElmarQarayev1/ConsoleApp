using System;
namespace ConsoleAPP
{
	public static class StringExtentions
	{
        public static bool CheckFullname( this string fullname)
        {
            
            string[] namesArr = fullname.Split(' ');

            if (namesArr.Length == 2)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (String.IsNullOrWhiteSpace(namesArr[i]) || !CheckIsLetter(namesArr[i]) || namesArr[i].Length<3)
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
        public static bool CheckIsDigitOrLetter(this string name)
        {
            for (int i = 0; i < name.Length; i++)
            {
                if (!char.IsLetterOrDigit(name[i])) return false;
            }
            return true;
        }

        public static bool isEmailValid(this string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }
            if (email.StartsWith("@"))
            {
                return false;
            }
            string[] parts = email.Split('@');

            if (parts.Length != 2)
            {
                return false;
            }

            if (parts[0].StartsWith(".") || parts[0].EndsWith("."))
            {
                return false;
            }
            for (int i = 0; i < parts[0].Length; i++)
            {
                if (!char.IsLetterOrDigit(parts[0][i]))
                {
                    return false;
                }
            }
            if (char.IsDigit(parts[0][0]))
            {
                return false;
            }

            if (!parts[1].EndsWith(".az"))
            {
                return false;
            }

            if (email.StartsWith("@") || parts[1].StartsWith("."))
            {
                return false;
            }
            return true;
        }

        public static string ChangeToCaptalize(this string fullname)
        {
            
            string[] parts = fullname.Split(' ');
            string part0 = parts[0][0].ToString().ToUpper()+parts[0].Substring(1).ToLower();
            string part1 = parts[1][0].ToString().ToUpper()+parts[1].Substring(1).ToLower();
            return part0 + " " + part1;

        }
      
    }
}

