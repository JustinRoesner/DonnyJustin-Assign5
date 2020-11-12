﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;


namespace DonnyJustin_Assign5
{
    public partial class Form1 : Form
    {
        string[] current;

        string[] e1_start;
        string[] e2_start;
        string[] e3_start;
        string[] e4_start;
        string[] e1_progress;
        string[] e2_progress;
        string[] e3_progress;
        string[] e4_progress;
        string[] e1_end;
        string[] e2_end;
        string[] e3_end;
        string[] e4_end;

        string[] m1_start;
        string[] m2_start;
        string[] m3_start;
        string[] m4_start;
        string[] m1_progress;
        string[] m2_progress;
        string[] m3_progress;
        string[] m4_progress;
        string[] m1_end;
        string[] m2_end;
        string[] m3_end;
        string[] m4_end;

        string[] h1_start;
        string[] h2_start;
        string[] h3_start;
        string[] h4_start;
        string[] h1_progress;
        string[] h2_progress;
        string[] h3_progress;
        string[] h4_progress;
        string[] h1_end;
        string[] h2_end;
        string[] h3_end;
        string[] h4_end;

        int game;
        int previousGame = 0;
        string difficulty;
        string[] currentGame;
        Stopwatch timer;

        List<TextBox> boxes = new List<TextBox>();

        public Form1()
        {
            InitializeComponent();

            loadGames();
            loadBoxes();
        }

        private void loadBoxes()
        {
            boxes.Clear();
            
            boxes.Add(textBoxY1X1);
            boxes.Add(textBoxY1X2);
            boxes.Add(textBoxY1X3);
            boxes.Add(textBoxY1X4);
            boxes.Add(textBoxY1X5);
            boxes.Add(textBoxY1X6);
            boxes.Add(textBoxY1X7);
            boxes.Add(textBoxY1X8);
            boxes.Add(textBoxY1X9);

            boxes.Add(textBoxY2X1);
            boxes.Add(textBoxY2X2);
            boxes.Add(textBoxY2X3);
            boxes.Add(textBoxY2X4);
            boxes.Add(textBoxY2X5);
            boxes.Add(textBoxY2X6);
            boxes.Add(textBoxY2X7);
            boxes.Add(textBoxY2X8);
            boxes.Add(textBoxY2X9);

            boxes.Add(textBoxY3X1);
            boxes.Add(textBoxY3X2);
            boxes.Add(textBoxY3X3);
            boxes.Add(textBoxY3X4);
            boxes.Add(textBoxY3X5);
            boxes.Add(textBoxY3X6);
            boxes.Add(textBoxY3X7);
            boxes.Add(textBoxY3X8);
            boxes.Add(textBoxY3X9);

            boxes.Add(textBoxY4X1);
            boxes.Add(textBoxY4X2);
            boxes.Add(textBoxY4X3);
            boxes.Add(textBoxY4X4);
            boxes.Add(textBoxY4X5);
            boxes.Add(textBoxY4X6);
            boxes.Add(textBoxY4X7);
            boxes.Add(textBoxY4X8);
            boxes.Add(textBoxY4X9);

            boxes.Add(textBoxY5X1);
            boxes.Add(textBoxY5X2);
            boxes.Add(textBoxY5X3);
            boxes.Add(textBoxY5X4);
            boxes.Add(textBoxY5X5);
            boxes.Add(textBoxY5X6);
            boxes.Add(textBoxY5X7);
            boxes.Add(textBoxY5X8);
            boxes.Add(textBoxY5X9);

            boxes.Add(textBoxY6X1);
            boxes.Add(textBoxY6X2);
            boxes.Add(textBoxY6X3);
            boxes.Add(textBoxY6X4);
            boxes.Add(textBoxY6X5);
            boxes.Add(textBoxY6X6);
            boxes.Add(textBoxY6X7);
            boxes.Add(textBoxY6X8);
            boxes.Add(textBoxY6X9);

            boxes.Add(textBoxY7X1);
            boxes.Add(textBoxY7X2);
            boxes.Add(textBoxY7X3);
            boxes.Add(textBoxY7X4);
            boxes.Add(textBoxY7X5);
            boxes.Add(textBoxY7X6);
            boxes.Add(textBoxY7X7);
            boxes.Add(textBoxY7X8);
            boxes.Add(textBoxY7X9);

            boxes.Add(textBoxY8X1);
            boxes.Add(textBoxY8X2);
            boxes.Add(textBoxY8X3);
            boxes.Add(textBoxY8X4);
            boxes.Add(textBoxY8X5);
            boxes.Add(textBoxY8X6);
            boxes.Add(textBoxY8X7);
            boxes.Add(textBoxY8X8);
            boxes.Add(textBoxY8X9);

            boxes.Add(textBoxY9X1);
            boxes.Add(textBoxY9X2);
            boxes.Add(textBoxY9X3);
            boxes.Add(textBoxY9X4);
            boxes.Add(textBoxY9X5);
            boxes.Add(textBoxY9X6);
            boxes.Add(textBoxY9X7);
            boxes.Add(textBoxY9X8);
            boxes.Add(textBoxY9X9);
        }

        // load the selected game onto the screen
        private void setGame()
        {
            // reset readonly 
            foreach (var i in boxes)
                i.ReadOnly = false;


            char[] temp;
            int j = 0;
            int w = 0;
            temp = tokenize(currentGame[0]);
            foreach (var i in boxes)
            {
                if (j > 8)
                {
                    j = 0;
                    temp = tokenize(currentGame[w+1]);
                    w++;
                }
                i.Text = temp[j].ToString();
                // pre-filled boxes cannot be changed
                if (i.Text != " ")
                    i.ReadOnly = true;
                j++;
            }

            timer = Stopwatch.StartNew();
            textBoxTimer.Text = "0.00";
        }

        private char[] tokenize(string game)
        {
            char[] numbers = game.ToCharArray();
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == '0')
                    numbers[i] = ' ';
            }
            return numbers;
        }

        // read and store each possible game
        private void loadGames()
        {
            // initialize each game
            string[] directory = File.ReadAllLines("directory.txt");

            e1_start = setStart(directory[0]);
            e1_end = setEnd(directory[0]);

            e2_start = setStart(directory[1]);
            e2_end = setEnd(directory[1]);

            e3_start = setStart(directory[2]);
            e3_end = setEnd(directory[2]);

            e4_start = setStart(directory[3]);
            e4_end = setEnd(directory[3]);

            m1_start = setStart(directory[4]);
            m1_end = setEnd(directory[4]);

            m2_start = setStart(directory[5]);
            m2_end = setEnd(directory[5]);

            m3_start = setStart(directory[6]);
            m3_end = setEnd(directory[6]);

            m4_start = setStart(directory[7]);
            m4_end = setEnd(directory[7]);

            h1_start = setStart(directory[8]);
            h1_end = setEnd(directory[8]);

            h2_start = setStart(directory[9]);
            h2_end = setEnd(directory[9]);

            h3_start = setStart(directory[10]);
            h3_end = setEnd(directory[10]);

            h4_start = setStart(directory[11]);
            h4_end = setEnd(directory[11]);
        }

        // read and store the initial state of the game
        private string[] setStart(string path)
        {
            string[] startState = File.ReadLines(path).Take(9).ToArray();
            return startState;
        }

        // read and store the completed state of the game
        private string[] setEnd(string path)
        {
            string[] endState = File.ReadLines(path).Skip(10).Take(9).ToArray();
            return endState;
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            var temp = new StringBuilder();
            foreach (var i in boxes)
            {
                temp.Append(i.Text);
            }

            // filter whitespace
            var attempt = new StringBuilder();
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] != ' ')
                    attempt.Append(temp[i]);
            }

            var answer = getFinal();

            if (attempt.ToString() == answer)
            {
                // Puzzle solved correnctly
                timer.Stop();
                MessageBox.Show("Puzzle Complete!");
                textBoxTimer.Text = timer.Elapsed.TotalSeconds.ToString();      // display total seconds
            }
            else
            {
                // Unsolved
                MessageBox.Show("Not Quite");
            }
        }

        private string getFinal()
        {
            string[] temp = new string[81];
            if (difficulty == "easy")
            {
                switch (game)
                {
                    case 1:
                        temp = e1_end;
                        break;
                    case 2:
                        temp = e2_end;
                        break;
                    case 3:
                        temp = e3_end;
                        break;
                    case 4:
                        temp = e4_end;
                        break;
                    default:
                        break;
                }
            }
            else if (difficulty == "medium")
            {
                switch (game)
                {
                    case 1:
                        temp = m1_end;
                        break;
                    case 2:
                        temp = m2_end;
                        break;
                    case 3:
                        temp = m3_end;
                        break;
                    case 4:
                        temp = m4_end;
                        break;
                    default:
                        break;
                }
            }
            else if (difficulty == "hard")
            {
                switch (game)
                {
                    case 1:
                        temp = h1_end;
                        break;
                    case 2:
                        temp = h2_end;
                        break;
                    case 3:
                        temp = h3_end;
                        break;
                    case 4:
                        temp = h4_end;
                        break;
                    default:
                        break;
                }
            }

            var builder = new StringBuilder();
            foreach (var i in temp)
            {
                builder.Append(i);
            }

            return builder.ToString();
        }

        // load easy game
        private void buttonDiffEasy_Click(object sender, EventArgs e)
        {
            difficulty = "easy";
            // random number [1, 4] to pick a game file
            Random rnd = new Random();
            game = rnd.Next(1, 4);

            // to ensure the same game doesn't load consecutively
            while (game == previousGame)
                game = rnd.Next(1, 4);

            switch (game)
            {
                case 1:
                    currentGame = e1_start;
                    setGame();
                    break;
                case 2:
                    currentGame = e2_start;
                    setGame();
                    break;
                case 3:
                    currentGame = e3_start;
                    setGame();
                    break;
                case 4:
                    currentGame = e4_start;
                    setGame();
                    break;
                default:
                    break;
            }

            previousGame = game;
        }

        // load medium game
        private void buttonDiffMedium_Click(object sender, EventArgs e)
        {
            difficulty = "medium";
            // random number [1, 4] to pick a game file
            Random rnd = new Random();
            game = rnd.Next(1, 4);

            // to ensure the same game doesn't load consecutively
            while (game == previousGame)
                game = rnd.Next(1, 4);

            switch (game)
            {
                case 1:
                    currentGame = m1_start;
                    setGame();
                    break;
                case 2:
                    currentGame = m2_start;
                    setGame();
                    break;
                case 3:
                    currentGame = m3_start;
                    setGame();
                    break;
                case 4:
                    currentGame = m4_start;
                    setGame();
                    break;
                default:
                    break;
            }

            previousGame = game;
        }

        // load hard game
        private void buttonDiffHard_Click(object sender, EventArgs e)
        {
            difficulty = "hard";
            // random number [1, 4] to pick a game file
            Random rnd = new Random();
            game = rnd.Next(1, 4);

            // to ensure the same game doesn't load consecutively
            while (game == previousGame)
                game = rnd.Next(1, 4);

            switch (game)
            {
                case 1:
                    currentGame = h1_start;
                    setGame();
                    break;
                case 2:
                    currentGame = h2_start;
                    setGame();
                    break;
                case 3:
                    currentGame = h3_start;
                    setGame();
                    break;
                case 4:
                    currentGame = h4_start;
                    setGame();
                    break;
                default:
                    break;
            }

            previousGame = game;
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            int parsedValue = 0;
            if (!int.TryParse(sender.ToString(), out parsedValue))
            {
                if (sender.ToString() == " ")
                {
                    //MessageBox.Show(sender.ToString());
                    return;
                }
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            setGame();
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            if (buttonPause.Text == "pause")
            {
                timer.Stop();
                foreach (var i in boxes)
                    i.Visible = false;
                buttonPause.Text = "play";
            }
            else if (buttonPause.Text == "play")
            {
                timer.Start();
                foreach (var i in boxes)
                    i.Visible = true;
                buttonPause.Text = "pause";
            }
        }

        private void buttonCheat_Click(object sender, EventArgs e)
        {
            /*var temp = new StringBuilder();
            foreach (var i in boxes)
            {
                temp.Append(i.Text);
            }

            // filter whitespace
            var attempt = new StringBuilder();
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] != ' ')
                    attempt.Append(temp[i]);
            }

            var answer = getFinal();

            for (int i = 0; i < attempt.Length; i++)
            {
                if (attempt[i] != answer[i])
                {
                    attempt[i] = answer[i];
                    
                    break;
                }
            }

            MessageBox.Show("You have used a cheat, smh");*/
        }
    }
}
