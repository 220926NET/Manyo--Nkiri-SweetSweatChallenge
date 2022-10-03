// See https://aka.ms/new-console-template for more information


/*
    
    
    You should be able guess a letter or a word
    You should know how many letters are in the word 
    you should know how many number of tries you have left, you have seven tries


    User story:
     User should be able to guess a word or letter
     User Should be able to know how may letters are in the word
     user should be informed if the word or letter they guessed is incorrect

     MVP
        Users should be able to see the remaining guesses
            hang man has 6 set a counter for 6 everytime you guess counter decreases by 1

        Users Should be able to quit game

        Users should be able to make a letter guess and see if it is in the word or not
        Users should see where the correct letters are in the word
        users should know how many letters in word 
        Users should be able to guess the word
        Answer should be a real world



*/

// Need array of letters that equal word
//Write guess a letter 
//Allow user in input
//Loop thru array of letter words if char user  

using System;
using System.Collections.Generic;

namespace Almostengr.CodingChallenge.Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hangman!");
            Console.WriteLine();

            string[] wordList = { "aardvark", "baboon", "camel", "dog", "elephant", "ferret", "giraffe" };

            // todo 1
            // randomly choose a word from the word list and assign it to a variable called chosenWord

            Random random = new Random();
            int wordListInt = random.Next(0, wordList.Length - 1);

            string chosenWord = wordList[wordListInt].ToLower();
            Console.WriteLine("The word has {0} characters", chosenWord.Length);

            int remainingAttempts = 7;
            List<string> alreadyGuessedLetters = new List<string>();
            string displayWord = "";

            while (remainingAttempts > 0 && displayWord != chosenWord)
            {
                Console.WriteLine("Remaining attempts: {0}", remainingAttempts);

                // todo 2
                // ask the user to guess a letter and assign their answer to a variable called
                // "guess". Make guess lowercase.

                Console.WriteLine("Enter a letter: ");
                char[] input = Console.ReadLine().ToCharArray();

                string guess = "";
                if (input.Length > 0)
                {
                    guess = input[0].ToString();
                    guess = guess.ToLower();
                }

                alreadyGuessedLetters.Add(guess);

                // todo 3
                // check if the letter the user guessed (guess) is one of the letters in the chosenWord

                displayWord = "";
                string containedMessage = "";
                if (chosenWord.Contains(guess))
                {
                    containedMessage = "{0} is contained in the word.";
                }
                else
                {
                    containedMessage = "{0} is NOT contained in the word.";
                    remainingAttempts--;
                }

                Console.WriteLine(containedMessage, guess);

                foreach (var letter in chosenWord)
                {
                    if (alreadyGuessedLetters.Contains(letter.ToString()))
                    {
                        displayWord += letter;
                    }
                    else
                    {
                        displayWord += "*";
                    }
                }

                Console.WriteLine(displayWord);
                Console.WriteLine();
            } // end while

            if (remainingAttempts == 0)
            {
                Console.WriteLine("You have ran out of attempts. You lose!");
                Console.WriteLine("The word was: {0}", chosenWord);
            }
            else
            {
                Console.WriteLine("You have won the game!");
            }
        }
    }
}




