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
            string playerName = "";
            Random random = new Random((int)DateTime.Now.Ticks);

            string[] fruitWords = { "Kiwi", "Orange", "Appel", "Grapes", "Bluebarry" };

            string wordToGuess = fruitWords[random.Next(0, fruitWords.Length)];
            string wordToGuessUppercase = wordToGuess.ToUpper();

            StringBuilder displayToPlayer = new StringBuilder(wordToGuess.Length);
            for (int i = 0; i < wordToGuess.Length; i++)
                displayToPlayer.Append('_');


            List<char> correctGuesses = new List<char>();
            List<char> incorrectGuesses = new List<char>();

            Console.WriteLine("\n------------------HANGMAN-------------------------");
            Console.WriteLine($" The word { wordToGuess}");  // debugging random word display
            Console.WriteLine("\nEnter your name:");
            playerName = Console.ReadLine();
            Console.WriteLine($"\nHello and Welcome {playerName} to play the HANGMAN");

            int guessCount = 10;
            bool won = false;
            int lettersRevealed = 0;

            string input;
            char guess;

            while (!won && guessCount > 0)
            {
                Console.Write("Guess a letter: ");

                input = Console.ReadLine().ToUpper();
                guess = input[0];

                if (correctGuesses.Contains(guess))
                {
                    Console.WriteLine("You have already tried '{0}', and it was correct!" + guess);
                    continue;
                }
                else if (incorrectGuesses.Contains(guess))
                {
                    Console.WriteLine("You have already tried '{0}', and it was WRONG!" + guess);
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

                    Console.WriteLine("Sorry there is no " +guess + " in this word!");
                    guessCount--;
                    Console.WriteLine(" You have " + guessCount + " guesses left");
                }

                Console.WriteLine(displayToPlayer.ToString());
            }

            if (won)
                Console.WriteLine("----You won!-----");
            else
                Console.WriteLine(" We ar so sorry!You lost! It was '{0}'", wordToGuess);

            Console.Write("Press ENTER to exit...");
            Console.WriteLine(" End of line");

        }// End of main
    }// End of Main
 }//  End of namespace
