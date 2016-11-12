using System;

namespace SortAlgsTimes
{
    public partial class MainWindow
    {
        private bool validateInput(string input)
        {
            if (input == "")
            {
                return true;
            }

            if (!containsOnlyDigits(input))
            {
                return false;
            }

            return true;
        }
        
        private bool containsOnlyDigits(string s)
        {
            for (short i = 0; i < s.Length; i++)
            {
                if (!char.IsDigit(s[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
