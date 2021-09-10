using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleHangmanApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool keepLooping = true; 
            string menu = "";
            while (keepLooping)
            {
                Console.Clear();

                Console.WriteLine("\n------------------HANGMAN-------------------------");

                Console.WriteLine("\n-------------------Menu --------------------------"
                                  + "\n1. Game Rules"
                                  + "\n2. Play the Hangman game"
                                  + "\n3. Exit");

                menu = Console.ReadLine();

                switch (menu)
                {
                    case "1":
                        GameRules();
                        break;
                    case "2":
                        RunGame();
                        break;
                    case "3":
                        keepLooping = false;
                        Console.WriteLine(" Thanks for your time and we hope you would liked the Hangman");
                        break;
                 
                    default:
                        Console.WriteLine(" Incorrect Menu Selection!");
                        break;
                }
                PressToContinue();
            }


        }// End of main

        static void GameRules()// Method for Game rules
        {
            Console.WriteLine(" In this game you are guessing a word.\n You type a letter (no numbers).\n You have only 10 times to guess the wrong letter");
        }
        static void RunGame() // Method to run the game
        {
            string playerName = "";
            Random random = new Random((int)DateTime.Now.Ticks);

            string[] fruitWords = { "Kiwi", "Orange", "Apple", "Grapes", "Bluebarry", "Banana", "Strawbarry" };

            string wordToGuess = fruitWords[random.Next(0, fruitWords.Length)];
            string wordToGuessUppercase = wordToGuess.ToUpper();

            StringBuilder displayToPlayer = new StringBuilder(wordToGuess.Length);
            for (int i = 0; i < wordToGuess.Length; i++)
                displayToPlayer.Append('_');


            List<char> correctGuesses = new List<char>();
            List<char> incorrectGuesses = new List<char>();


            Console.WriteLine($" The word { wordToGuess}");  // debugging random word display
            Console.WriteLine("\nEnter your name:\n");
            playerName = Console.ReadLine();
            Console.WriteLine($"\nHello and Welcome {playerName} for playing the HANGMAN");

            int guessCount = 10;
            bool won = false;
            int lettersRevealed = 0;

            string input;
            char guess;

            while (!won && guessCount > 0) // condition
            {
                Console.Write("\nGuess a letter: ");

                input = Console.ReadLine().ToUpper();
                guess = input[0];

                if (correctGuesses.Contains(guess)) 
                {
                    Console.WriteLine("You have guessed and it was correct!" + guess);
                    continue;
                }
                else if (incorrectGuesses.Contains(guess))
                {
                    Console.WriteLine("You have already tried and it was WRONG!" + guess);
                    continue;
                }
                if (wordToGuessUppercase.Contains(guess))
                {
                    correctGuesses.Add(guess);

                    for (int i = 0; i < wordToGuess.Length; i++)
                    {
                        if (wordToGuessUppercase[i] == guess)
                        {
                            displayToPlayer[i] = wordToGuess[i];
                            lettersRevealed++;
                        }
                    }

                    if (lettersRevealed == wordToGuess.Length)
                        won = true;
                }
                else
                {
                    incorrectGuesses.Add(guess);

                    Console.WriteLine("Sorry there is no " + guess + " in this word!");
                    guessCount--;
                    Console.WriteLine(" You have " + guessCount + " guesses left");
                }

                Console.WriteLine(displayToPlayer.ToString());
            }

            if (won)
            {
                Console.WriteLine("----You won!-----");
                Console.Write("Press ENTER to exit...");
            }

            else
            {
                Console.WriteLine(" We are so sorry!\n You lost! The word was "+ wordToGuess);
                Console.Write("Press ENTER to exit...");
            }

            Console.ReadKey();
            

        }
        static void PressToContinue()
        {
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey(true);
        }

     }// End of Class
}// End of namespace
