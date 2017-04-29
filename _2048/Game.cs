using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2048.Properties;

namespace _2048
{
    public class Game
    {
        private Random rnd = new Random();

        public int maxScore { get; set; } = 1024;

        public Numbers[,] NumbersArray;

        Numbers _00 = new Numbers(0, 0, 0);
        Numbers _01 = new Numbers(0, 0, 1);
        Numbers _02 = new Numbers(0, 0, 2);
        Numbers _03 = new Numbers(0, 0, 3);
        Numbers _10 = new Numbers(0, 1, 0);
        Numbers _11 = new Numbers(0, 1, 1);
        Numbers _12 = new Numbers(0, 1, 2);
        Numbers _13 = new Numbers(0, 1, 3);
        Numbers _20 = new Numbers(0, 2, 0);
        Numbers _21 = new Numbers(0, 2, 1);
        Numbers _22 = new Numbers(0, 2, 2);
        Numbers _23 = new Numbers(0, 2, 3);
        Numbers _30 = new Numbers(0, 3, 0);
        Numbers _31 = new Numbers(0, 3, 1);
        Numbers _32 = new Numbers(0, 3, 2);
        Numbers _33 = new Numbers(0, 3, 3);
        
        public void StartGame()
        {
            NumbersArray = new Numbers[4, 4]
          {
            {_00 , _01 , _02 , _03 },
            {_10 , _11 , _12 , _13 },
            {_20 , _21 , _22 , _23 },
            {_30 , _31 , _32 , _33 }
         };

            NumbersArray[rnd.Next(0, 3), rnd.Next(0, 3)].Number = 2;
            NumbersArray[rnd.Next(1, 2), rnd.Next(0, 3)].Number = 2;

            foreach (var numbers in NumbersArray)
            {
                if (numbers.Number != 0)
                {
                    Draw(numbers.PositionX, numbers.PositionY, numbers);
                }
            }

        }

        public void Draw(int x, int y, Numbers sNum)
        {
            Form1.Instanse.GetPictureBoxByName($"_{x}{y}").Image = (Image)sNum.GetImage();
        }
        
        public void GameControl(string str, string str2)
        {

            DialogResult dialogResult = MessageBox.Show(str, str2, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        NumbersArray[i, j].Number = 0;
                        Draw(i, j, NumbersArray[i, j]);
                    }
                }
                StartGame();
            }
            else
            {
                Application.Exit();
            }

        }

        public void MoveUp()
        {
            int i = 1;

            //isContinue = false;

            for (int step = 0; step < 7; step++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (NumbersArray[i, j].Number != 0)
                    {
                        if (NumbersArray[i - 1, j].Number == 0)
                        {
                            NumbersArray[i - 1, j] = NumbersArray[i, j];
                            NumbersArray[i, j].Number = 0;
                            Draw(i - 1, j, NumbersArray[i - 1, j]);
                            Draw(i, j, (Numbers)0);
                            //isContinue = false;
                        }
                        else if (NumbersArray[i - 1, j].Number == NumbersArray[i, j].Number)
                        {
                            NumbersArray[i - 1, j].Number *= 2;
                            NumbersArray[i, j].Number = 0;
                            Draw(i - 1, j, NumbersArray[i - 1, j]);
                            Draw(i, j, (Numbers)0);
                            //isContinue = true;
                        }

                    }

                }
                //if (isContinue)
                //{
                //    isContinue = false;
                //    continue;
                //}
                i++;
                if (i > 3)
                {
                    i = 1;
                }

            }
        }

        public void MoveRigth()
        {
            int j = 2;
            //isContinue = false;

            for (int step = 0; step < 7; step++)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (NumbersArray[i, j].Number != 0)
                    {
                        if (NumbersArray[i, j + 1].Number == 0)
                        {
                            NumbersArray[i, j + 1] = NumbersArray[i, j];
                            NumbersArray[i, j].Number = 0;
                            Draw(i, j + 1, NumbersArray[i, j + 1]);
                            Draw(i, j, (Numbers)0);
                            //isContinue = false;

                        }
                        else if (NumbersArray[i, j + 1].Number == NumbersArray[i, j].Number)
                        {
                            NumbersArray[i, j + 1].Number *= 2;
                            NumbersArray[i, j].Number = 0;
                            Draw(i, j + 1, NumbersArray[i, j + 1]);
                            Draw(i, j, (Numbers)0);
                            //isContinue = true;

                        }
                    }

                }

                //if (isContinue)
                //{
                //    isContinue = false;
                //    continue;
                //}

                j--;
                if (j < 0)
                {
                    j = 2;
                }
            }
        }

        public void MoveLeft()
        {
            int j = 1;
            //isContinue = false;

            for (int step = 0; step < 7; step++)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (NumbersArray[i, j].Number != 0)
                    {
                        if (NumbersArray[i, j - 1].Number == 0)
                        {
                            NumbersArray[i, j - 1] = NumbersArray[i, j];
                            NumbersArray[i, j].Number = 0;
                            Draw(i, j - 1, NumbersArray[i, j - 1]);
                            Draw(i, j, (Numbers)0);
                            //isContinue = false;
                        }
                        else if (NumbersArray[i, j - 1].Number == NumbersArray[i, j].Number)
                        {
                            NumbersArray[i, j - 1].Number *= 2;
                            NumbersArray[i, j].Number = 0;
                            Draw(i, j - 1, NumbersArray[i, j - 1]);
                            Draw(i, j, (Numbers)0);
                            //isContinue = true;
                        }
                    }

                }
                //if (isContinue)
                //{
                //    isContinue = false;
                //    continue;
                //}

                j++;
                if (j > 3)
                {
                    j = 1;
                }
            }
        }

        public void MoveDown()
        {
            int i = 2;
            //isContinue = false;

            for (int step = 0; step < 7; step++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (NumbersArray[i, j].Number != 0)
                    {
                        if (NumbersArray[i + 1, j].Number == 0)
                        {
                            NumbersArray[i + 1, j] = NumbersArray[i, j];
                            NumbersArray[i, j].Number = 0;
                            Draw(i + 1, j, NumbersArray[i + 1, j]);
                            Draw(i, j, (Numbers)0);
                            //isContinue = false;
                        }
                        else if (NumbersArray[i + 1, j].Number == NumbersArray[i, j].Number)
                        {
                            NumbersArray[i + 1, j].Number *= 2;
                            NumbersArray[i, j].Number = 0;
                            Draw(i + 1, j, NumbersArray[i + 1, j]);
                            Draw(i, j, (Numbers)0);
                            //isContinue = true;
                        }
                    }

                }
                //if (isContinue)
                //{
                //    isContinue = false;
                //    continue;
                //}

                i--;
                if (i < 0)
                {
                    i = 2;
                }
            }
        }


        public void NewNumber()
        {
            for (int i = 0; i < 16; i++)
            {

                //int number = rnd.Next(0, 10);
                //if (number == 5)
                //{
                //    number = 4;
                //}
                //else
                //{
                int number = 2;
                //}

                int x = rnd.Next(0, 3);
                int y = rnd.Next(0, 3);
                if (NumbersArray[x, y].Number == 0)
                {

                    NumbersArray[x, y].Number = number;
                    Draw(x, y, NumbersArray[x, y]);
                    break;
                }

            }
        }


        public bool CheckMoveUp()
        {
            int x = 1;
            int i = 1;

            for (int step = 0; step < 6; step++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (NumbersArray[i, j].Number != 0)
                    {
                        if (NumbersArray[i - 1, j].Number == 0 || NumbersArray[i - 1, j].Number == NumbersArray[i, j].Number)
                        {
                            return true;
                        }


                    }
                }
                i--;
                if (i < 1)
                {
                    x++;
                    i = x;
                }
            }
            return false;
        }

        public bool CheckMoveRigth()
        {
            int x = 0;
            int j = 0;

            for (int step = 0; step < 6; step++)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (NumbersArray[i, j].Number != 0)
                    {
                        if (NumbersArray[i, j + 1].Number == 0 || NumbersArray[i, j + 1].Number == NumbersArray[i, j].Number)
                        {
                            return true;
                        }

                    }
                }
                j++;
                if (j > 2)
                {
                    x++;
                    j = x;
                }
            }

            return false;
        }

        public bool CheckMoveLeft()
        {
            int x = 1;
            int j = 1;

            for (int step = 0; step < 6; step++)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (NumbersArray[i, j].Number != 0)
                    {
                        if (NumbersArray[i, j - 1].Number == 0 || NumbersArray[i, j - 1].Number == NumbersArray[i, j].Number)
                        {
                            return true;
                        }

                    }
                }
                j--;
                if (j < 1)
                {
                    x++;
                    j = x;
                }
            }
            return false;
        }

        public bool CheckMoveDown()
        {
            int x = 0;
            int i = 0;

            for (int step = 0; step < 6; step++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (NumbersArray[i, j].Number != 0)
                    {
                        if (NumbersArray[i + 1, j].Number == 0 || NumbersArray[i + 1, j].Number == NumbersArray[i, j].Number)
                        {
                            return true;
                        }

                    }
                }
                i++;
                if (i > 2)
                {
                    x++;
                    i = x;
                }
            }
            return false;
        }


        public void IsGameOver()
        {
            while (true)
            {
                if (!(CheckMoveDown() || CheckMoveLeft() || CheckMoveRigth() || CheckMoveUp()))
                {
                    GameControl("Game Over", "Are you want to play a new game");
                }
                else
                {
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (NumbersArray[i, j].Number == maxScore)
                            {
                                GameControl("You Win", "Are you want to play a new game");
                            }
                        }
                    }
                }
            }
        }
    }
}
