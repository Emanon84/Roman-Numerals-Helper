using System;


namespace Roman_Numerals_Helper
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine(ToRoman(666));

            //Console.WriteLine(FromRoman("XVI"));


        }


        public static string ToRoman(int n)
        {
            if(n < 1 || n > 3999)
            {
                Console.WriteLine("Out of range");
                return null;
            }

            string RomanVal = "";

            do
            {
                // Handle the 1000-4000
                while (n >= 1000)
                {
                    RomanVal += "M";
                    n -= 1000;
                }

                // Handle 999 to 900
                while (n <= 999 && n >= 900)
                {
                    //Add CM for 900
                    RomanVal += "CM";
                    n -= 900;
                }

                //Handle 899 to 500 (working down to 99) 
                while (n <= 899 && n >= 500)
                {

                    //Add D for the 500
                    RomanVal += "D";
                    n -= 500;

                     while (n >= 100)
                    {
                        //Add C for each 100 between 500 and 899
                        RomanVal += "C";
                        n -= 100;
                    }

                }

                //Handle 499 - 400 (working down to 99)
                while (n <= 499 && n >= 400)
                {

                    //Add CD for 400
                    RomanVal += "CD";
                    n -= 400;

                }

                //Handle 399 - 100
                while (n <= 399 && n >= 100)
                {

                    while (n >= 100)
                    {
                        //Add C for each 100 between 399 and 99
                        RomanVal += "C";
                        n -= 100;
                    }

                }

                // Handle 99 to 90
                while (n <= 99 && n >= 90)
                {
                    //Add XC for 90
                    RomanVal += "XC";
                    n -= 90;
                }

                // Handle 89 to 50
                while (n <= 89 && n >= 50)
                {
                    //Add L for the 50
                    RomanVal += "L";
                    n -= 50;

                    while (n >= 10)
                    {
                        //Add X for each 10 between 50 and 89
                        RomanVal += "X";
                        n -= 10;
                    }
                }

                // Handle 49 to 40
                while (n <= 49 && n >= 40)
                {
                    //Add XL for 40
                    RomanVal += "XL";
                    n -= 40;
                }

                //Handle 39 - 10
                while (n <= 39 && n >= 10)
                {

                    //while (n >= 10)
                    //{
                        //Add X for each 10 between 39 and 9
                        RomanVal += "X";
                        n -= 10;
                    //}

                }

                // Handle 9
                while (n == 9)
                {
                    //Add IX for 9
                    RomanVal += "IX";
                    n -= 9;
                }

                // Handle 8 to 5
                while (n <= 8 && n >= 5)
                {
                    //Add V for the 5
                    RomanVal += "V";
                    n -= 5;

                    while (n >= 1)
                    {
                        //Add I for each 1 between 5 and 8
                        RomanVal += "I";
                        n -= 1;
                    }
                }

                // Handle 4
                while (n == 4)
                {
                    //Add IV for 4
                    RomanVal += "IV";
                    n -= 4;
                }

                //Handle 3 - 1
                while (n <= 3 && n >= 1)
                {

                        //Add I for each 1 between 3 and 1
                        RomanVal += "I";
                        n -= 1;
                    

                }


                Console.WriteLine(RomanVal);

            }while(n < 0);



            return RomanVal;
        }

        public static int FromRoman(string romanNumeral)
        {
            romanNumeral = romanNumeral.ToUpper();
            Console.WriteLine("Input är: " + romanNumeral);


            foreach (char c in romanNumeral)
            {
                if(c != 'M' && c != 'D' && c != 'C' && c != 'L' && c != 'X' && c != 'V' &&  c != 'I' && c != 'D')
                {
                    Console.WriteLine("String contains non-roman characters");
                    return 0;
                }
            }

            string temp = "";
            int singleDigits = 0;
            int doubleDigits = 0; 
            int tripleDigits = 0;
            int quadDigits = 0;


            //Create charArray of the value
            char[] charArray = romanNumeral.ToCharArray();


            // ----------------------- START -- Handle  1-9 - Will never loop beyond the fourth character. ------------
            for (int i = charArray.Length - 1; i >= 0 && i >= charArray.Length - 4; i--)
            {
                temp += charArray[i];            
            }
            //Console.WriteLine(temp);

            //Create an array of the first (up to) 4 digits
            char[] tempCharArray = temp.ToCharArray();

                //Reverse the string
                Array.Reverse(tempCharArray);
                temp = new string(tempCharArray);
            //Console.WriteLine("Temp is now reversed:: " + temp);

            //Console.WriteLine(tempCharArray[0]);

                // If the leftmost numeral is not I or V, we remove it. we don't want to handle double digits right now
                while(!tempCharArray[0].Equals('I') && !tempCharArray[0].Equals('V') && tempCharArray.Length >1)
                {
                    
                    //Console.WriteLine("!!!!! First characters is neither I nor V! - Removing it!");
                    temp = "";
                    for (int i = 1; i <= tempCharArray.Length - 1; i++)
                    {
                        //Console.WriteLine(tempCharArray[i]);
                        temp += tempCharArray[i];
                    }
                    //Console.WriteLine("Temp is now reversed and X is removed: " + temp);
                    //Console.WriteLine("Updating tempCharArray");
                    tempCharArray = temp.ToCharArray();

                }

                //Set single digit value and remove single digit numerals from original string
                switch (temp)
                {
                    case "I":
                        singleDigits = 1;
                        romanNumeral = romanNumeral.Remove(romanNumeral.Length - temp.Length, temp.Length);
                        break;
                    case "II":
                        singleDigits = 2;
                        romanNumeral = romanNumeral.Remove(romanNumeral.Length - temp.Length, temp.Length);
                        break;
                    case "III":
                        singleDigits = 3;
                        romanNumeral = romanNumeral.Remove(romanNumeral.Length - temp.Length, temp.Length);
                        break;
                    case "IV":
                        singleDigits = 4;
                        romanNumeral = romanNumeral.Remove(romanNumeral.Length - temp.Length, temp.Length);
                        break;
                    case "V":
                        singleDigits = 5;
                        romanNumeral = romanNumeral.Remove(romanNumeral.Length - temp.Length, temp.Length);
                        break;
                    case "VI":
                        singleDigits = 6;
                        romanNumeral = romanNumeral.Remove(romanNumeral.Length - temp.Length, temp.Length);
                        break;
                    case "VII":
                        singleDigits = 7;
                        romanNumeral = romanNumeral.Remove(romanNumeral.Length - temp.Length, temp.Length);
                        break;
                    case "VIII":
                        singleDigits = 8;
                        romanNumeral = romanNumeral.Remove(romanNumeral.Length - temp.Length, temp.Length);
                        break;
                    case "IX":
                        singleDigits = 9;
                        romanNumeral = romanNumeral.Remove(romanNumeral.Length - temp.Length, temp.Length);
                        break;
                    default:
                        //Console.WriteLine("No match at all! " + temp );
                        singleDigits = 0;
                        break;
                }

            ////}
            ///

            // ----------------------- END -- Handle  1-9 - Will never loop beyond the fourth character. ------------

            if(romanNumeral.Length == 0)
            {
                return singleDigits;
            }

           // Console.WriteLine("The single digit is: " + singleDigits);
           //  Console.WriteLine("Remaining string is: " + romanNumeral);

            // ----------------------- START -- Handle  10-90 - Will never loop beyond the fourth character. ------------

            temp = "";

            //Create charArray of the value
            charArray = romanNumeral.ToCharArray();


            for (int i = charArray.Length - 1; i >= 0 && i >= charArray.Length - 4; i--)
            {
                temp += charArray[i];
            }
            //Console.WriteLine(temp);

            tempCharArray = temp.ToCharArray();

            //Reverse the string
            Array.Reverse(tempCharArray);
            temp = new string(tempCharArray);
            //Console.WriteLine("Temp is now reversed:: " + temp);

            // If the leftmost numeral is neither L nor X, we remove it. we don't want to handle double digits right now
            while (!tempCharArray[0].Equals('L') && !tempCharArray[0].Equals('X') && tempCharArray.Length > 1)
            {

                //Console.WriteLine("First characters is neither M nor C! - Removing it!");
                temp = "";
                for (int i = 1; i <= tempCharArray.Length - 1; i++)
                {
                    //Console.WriteLine(tempCharArray[i]);
                    temp += tempCharArray[i];
                }
                //Console.WriteLine("Temp is now reversed and M or C is removed: " + temp);
                //Console.WriteLine("Updating tempCharArray");
                tempCharArray = temp.ToCharArray();

            }

            //Set double digit value and remove double digit numerals from original string
            switch (temp)
            {
                case "X":
                    doubleDigits = 10;
                    romanNumeral = romanNumeral.Remove(romanNumeral.Length - temp.Length, temp.Length);
                    break;
                case "XX":
                    doubleDigits = 20;
                    romanNumeral = romanNumeral.Remove(romanNumeral.Length - temp.Length, temp.Length);
                    break;
                case "XXX":
                    doubleDigits = 30;
                    romanNumeral = romanNumeral.Remove(romanNumeral.Length - temp.Length, temp.Length);
                    break;
                case "XL":
                    doubleDigits = 40;
                    romanNumeral = romanNumeral.Remove(romanNumeral.Length - temp.Length, temp.Length);
                    break;
                case "L":
                    doubleDigits = 50;
                    romanNumeral = romanNumeral.Remove(romanNumeral.Length - temp.Length, temp.Length);
                    break;
                case "LX":
                    doubleDigits = 60;
                    romanNumeral = romanNumeral.Remove(romanNumeral.Length - temp.Length, temp.Length);
                    break;
                case "LXX":
                    doubleDigits = 70;
                    romanNumeral = romanNumeral.Remove(romanNumeral.Length - temp.Length, temp.Length);
                    break;
                case "LXXX":
                    doubleDigits = 80;
                    romanNumeral = romanNumeral.Remove(romanNumeral.Length - temp.Length, temp.Length);
                    break;
                case "XC":
                    doubleDigits = 90;
                    romanNumeral = romanNumeral.Remove(romanNumeral.Length - temp.Length, temp.Length);
                    break;
                default:
                    //Console.WriteLine("No match at all! " + temp);
                    doubleDigits = 0;
                    break;
            }

            // ----------------------- END -- Handle  10-90 - Will never loop beyond the fourth character. ------------

            if (romanNumeral.Length == 0)
            {
                return singleDigits + doubleDigits;
            }

            //Console.WriteLine("Doubledigits is: " + doubleDigits);
            //Console.WriteLine("Remaining string is: " + romanNumeral);

            // ----------------------- START -- Handle  100-900 - Will never loop beyond the fourth character. ------------

            temp = "";

            //Create charArray of the value
            charArray = romanNumeral.ToCharArray();

            for (int i = charArray.Length - 1; i >= 0 && i >= charArray.Length - 4; i--)
            {
                temp += charArray[i];
            }
            //Console.WriteLine(temp);

            tempCharArray = temp.ToCharArray();

            //Reverse the string
            Array.Reverse(tempCharArray);
            temp = new string(tempCharArray);
            //Console.WriteLine("Temp is now reversed:: " + temp);

            // If the leftmost numeral is not C or D, we remove it. we don't want to handle quadruple digits right now
            while (!tempCharArray[0].Equals('C') && !tempCharArray[0].Equals('D') && tempCharArray.Length > 1)
            {

                //Console.WriteLine("!!!!! First characters is neither C nor D! - Removing it!");
                temp = "";
                for (int i = 1; i <= tempCharArray.Length - 1; i++)
                {
                    //Console.WriteLine(tempCharArray[i]);
                    temp += tempCharArray[i];
                }
                //Console.WriteLine("Temp is now reversed and M is removed: " + temp);
                //Console.WriteLine("Updating tempCharArray");
                tempCharArray = temp.ToCharArray();

            }

            switch (temp)
            {
                case "C":
                    tripleDigits = 100;
                    romanNumeral = romanNumeral.Remove(romanNumeral.Length - temp.Length, temp.Length);
                    break;
                case "CC":
                    tripleDigits = 200;
                    romanNumeral = romanNumeral.Remove(romanNumeral.Length - temp.Length, temp.Length);
                    break;
                case "CCC":
                    tripleDigits = 300;
                    romanNumeral = romanNumeral.Remove(romanNumeral.Length - temp.Length, temp.Length);
                    break;
                case "CD":
                    tripleDigits = 400;
                    romanNumeral = romanNumeral.Remove(romanNumeral.Length - temp.Length, temp.Length);
                    break;
                case "D":
                    tripleDigits = 500;
                    romanNumeral = romanNumeral.Remove(romanNumeral.Length - temp.Length, temp.Length);
                    break;
                case "DC":
                    tripleDigits = 600;
                    romanNumeral = romanNumeral.Remove(romanNumeral.Length - temp.Length, temp.Length);
                    break;
                case "DCC":
                    tripleDigits = 700;
                    romanNumeral = romanNumeral.Remove(romanNumeral.Length - temp.Length, temp.Length);
                    break;
                case "DCCC":
                    tripleDigits = 800;
                    romanNumeral = romanNumeral.Remove(romanNumeral.Length - temp.Length, temp.Length);
                    break;
                case "CM":
                    tripleDigits = 900;
                    romanNumeral = romanNumeral.Remove(romanNumeral.Length - temp.Length, temp.Length);
                    break;
                default:
                    //Console.WriteLine("No match at all! " + temp);
                    tripleDigits = 0;
                    break;
            }

            // ----------------------- END -- Handle  100-900 - Will never loop beyond the fourth character. ------------

            if (romanNumeral.Length == 0)
            {
                return singleDigits + doubleDigits + tripleDigits;
            }


            // Console.WriteLine("Doubledigits is: " + tripleDigits);
            // Console.WriteLine("Remaining string is: " + romanNumeral);

            // ----------------------- START -- Handle  1000-4000 - Will never loop beyond the fourth character. ------------


            //Console.WriteLine(romanNumeral.Length);

            //temp = "";
            charArray = romanNumeral.ToCharArray();

            if (romanNumeral.Length > 3)
            {
                Console.WriteLine("Invalid amount of numerals left");
                return 0;
            }

            for (int i = 0; i <= charArray.Length - 1; i++)
            {
                //Console.WriteLine(charArray[i]);
                if (!charArray[i].Equals('M'))
                {
                    Console.WriteLine("Invalid roman numeral syntax");
                    return 0;
                }
                
            }

            switch (romanNumeral)
            {
                case "M":
                    quadDigits = 1000;
                    break;
                case "MM":
                    quadDigits = 2000;
                    break;
                case "MMM":
                    quadDigits = 3000;
                    break;
                default:
                    //Console.WriteLine("No match at all! " + temp);
                    quadDigits = 0;
                    break;
            }

               return singleDigits + doubleDigits + tripleDigits + quadDigits;

        }

    }
}
