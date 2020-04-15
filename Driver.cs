/*Name: Andrew Wood
 *Date: 3/25/19
 *Purpose: This is essentially the Driver class that uses the methods and runs the MainCode Class
 * 
 */

using System;
using static System.Console;




namespace MorseCode

{

   

    class Morse

    {

        public static void Main(string[] args)
        {

            MainCode.Creation();//This calls the creation method from the MainCode class in order to set up the dictionary
            // get the user input through thr GetUserInput() method
            // store these input in variable
            WriteLine("Enter string for translation");//Prompt asking the user for input
            string received = MainCode.Input();//Obtain the input through the Input()method from the MainCode Class
            //value is stored in this string variable
            WriteLine("Translation: \n" + MainCode.Work(received));//Obtains the morse code by calling the Work() method from the MainCode class
            //Prints out the information
            WriteLine("\nPress enter to quit");
            ReadLine();//Quits the program
        }
    }
}