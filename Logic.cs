﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SpeechToTextWPFSample
{
    class Logic
    {
        public static String message = null, player1=null, player2=null;
        public static char currentToken;
        public static Boolean justSpoke = false;
        public void DoWork()
        {

            //*********************** LOGIC STARTS

            const int numPlayers = 2; // default number of players is 2

            // print a welcome message
            Console.Write("\t\t\t======================\n\n");
            Console.Write("\t\t\tWelcome to Tic-Tac-Toe\n\n");
            Console.Write("\t\t\t======================\n\n");
            TTSSample.Program.sayThis("Welcome to Tic Tac Talk!");
            justSpoke = true;
            int size; // declare a variable to hold the board size
            Game g; // declare a game object
            Player[] players; // declare array of players
            bool winner; // declare a bool variable to keep indicate if there is a winner or not

            // to start the game, assume the user answer is YES (ie. 'Y')
            // This loop corresponds to the whole program running
                        
            size = 3;

            // create a game with the size given by the user
            g = new Game(size);

            // initialize and array of players using the default number of players
            players = new Player[numPlayers];


            TTSSample.Program.sayThis("who is Player One?");
            justSpoke = true;
            while(player1==null)
            {

            }
            TTSSample.Program.sayThis("who is Player Two?");
            justSpoke = true;
            while (player2 == null)
            {

            }
            // a bool variable to keep indicate if there is a winner or not
            winner = false;
            char[] tokens = { 'X', 'O' };
            string[] names = { "Player One", "Player Two" };
            //for (int i = 0; i < players.Length; i++)
            //{
            //    Console.Write("Enter player " + (i + 1) + " name: ");
            //    //TTSSample.Program.sayThis("Enter player " + (i + 1) + " name");
                    
            //    String name = names[i];

            //    Console.Write("Enter player " + (i + 1) + " token: ");
            //    char token = tokens[i];
            //    players[i] = new Player(name, token);

            //    Console.Write("\n");
            //}
            players[0] = new Player(player1, tokens[0]);
            players[1] = new Player(player2, tokens[1]);
            Console.Write("\n\n\t\t\tLet the game start...\n\n");
              
            TTSSample.Program.sayThis("Let the battle commence!");
            // Loop the game as long as the board is not full, and there is no winner yet
            // This loop corresponds to one game
            while (!g.isFull() && !winner)
            {
                    
                // loop through the array of players to give turns
                for (int i = 0; i < players.Length; i++)
                {
                    currentToken = players[i].gettoken();
                    if (g.isFull())
                        break;
                    message = null;
                    Console.WriteLine(g);

                    Console.Write("\nEnter spot to mark: ");
                    TTSSample.Program.sayThis(players[i].getName()+"\'s turn");
                    justSpoke = true;
                    //listen to tha talk
                    while (message==null)
                    {

                    }

                    string location = ""; // ********** entry via mic

                    //Console.Write("\n");



                    bool isMarked = players[i].mark(g, message);

                    // While the spot is not marked due to a pre-existing token
                    while (!isMarked)
                    {
                        // Console.Write("\nEnter spot to mark: ");

                        location = ""; // ********** entry via mic

                        //Console.Write("\n");

                        isMarked = players[i].mark(g, "A1");

                        // Console.Write("\n");
                    }

                    // Once the player has marked a spot, check if they won
                    if (g.didWin(players[i].gettoken()))
                    {
                        //Console.WriteLine(g);
                        // Console.WriteLine(players[i].getName() + " is the winner!");
                        TTSSample.Program.sayThis(players[i].getName() + " is the winner!");

                        //call pop-up from here
                        if (Application.Current.Dispatcher.CheckAccess())
                        {
                            MessageBox.Show("Congratulations " + players[i].getName().Replace(".", "") + " !!", "AWWWWW YEAHHHHHH");
                        }
                        else {
                            Application.Current.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(() => {
                                MessageBox.Show("Congratulations " + players[i].getName().Replace(".", "") + " !!", "AWWWWW YEAHHHHHH");
                            }));
                        }

                        winner = true;
                        break;
                    }
                }
            }
            if (g.isFull() && !winner)
            {
                // Console.Write("It's a draw! Intense competition\n\n");
                TTSSample.Program.sayThis("It's a draw! Intense competition.");
            }
            // Console.Write("Would you like to play again (Y/N)?");

            winner = false;
            TTSSample.Program.sayThis("Hope to see you again...");
            Environment.Exit(0);
        //*********************** LOGIC ENDS
        }

        public static void setMessage(String s)
        {
            message = s;
        }
    }
}
