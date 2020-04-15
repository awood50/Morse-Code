/*Name: Andrew Wood
 *Date: 3/25/19
 *Purpose: This is the MainCode class which calculates the translation string to morse code and its methods are used in the Driver class
 * 
 */

using System;
using static System.Console;
using System.IO;
using System.Text;



namespace MorseCode

{

   

    class MainCode
    {

        public static System.Collections.Generic.Dictionary<char, string> morDictionary;//Used a dictionary to store the values
               //I used intellisense and it added the "System.Collections.Generic" because it could not find the dictionary tool without it




        public static string Input()//This input method is used in order to get the input for the user for translation
        {
            string input = ReadLine();//this string accepts the input from the user

            if (!string.IsNullOrEmpty(input))//Here I used the IsNullOrEmpty method in order to determine if the input is valid.
                {
                    input = input.ToLower();//Converts input to lowercase if it is valid
                }

            return input; //returns the user input
        }


        public static void Creation()//this method will initialize and create the dictionary and give it more meaning
        {

            morDictionary = new System.Collections.Generic.Dictionary<char, string>();//Setting the dictionary equal to the dictionary object
            StreamReader morseRead = new StreamReader(File.OpenRead("Morse.txt")); //used a stream reader in order to read the Morse.txt file. It is placed in the project folder


            string[] info; //this string array will hold the value line by line


            string lne = ""; //this string variable holds the value of the current line
           
            while ((lne = morseRead.ReadLine()) != null)//this while loop will read the text file using the stream reader line by line, as long as it is not empty
            {

                info = lne.Split(' ');//this Split method takes the information from the string array and splits the delimited strings into different substrings, differentiation between line and line
                //for this we will split the lines by commas

                string sentence = info[0].ToLower();//this ToLower string method makes sure that everything is lowercase and stores the value into this string variable

                char character = Convert.ToChar(sentence);//I used the Convert method that is already a part of C# in order to convert whatever string is held into just one character for easier translation

                string code = info[1]; //stores the value at that spot in the array
              
                morDictionary.Add(character, code);//this code adds whatever is being held into the dictionary that I created


            }

        }


      


        public static string Work(string input)//this method seperates the input and turns it into morse code, it accepts a string as a parameter
        {

            StringBuilder morseStringB = new StringBuilder();//I decided to use a StringBuilder because it is easier to add and append things to it. I've used stirngbuilders with other programming languages so I already knew how to use it


            foreach (char character in input)//This is a for each loop in order to loop through every character that is inputted by the user
            {
                // if character found it build a string a append to stringbuilder
                if (morDictionary.ContainsKey(character))//Used the ContainsKey statement in order to find the correct character
                    {
                        morseStringB.Append(morDictionary[character] + " ");//If the character from user is found then it adds that character to the string builder
                    }
                else if (character == ' ')//If there is a space character typed
                    {
                        morseStringB.Append("/ ");//Adds a forward slash if there is a space added in order to show that in the results
                    }
                else
                    {
                        morseStringB.Append(character + " ");//else it just adds a space in between each translated letter
                    }
            }

            return morseStringB.ToString();//the stringbuilder is turned into a string and returned from this method.
        }

    }
}