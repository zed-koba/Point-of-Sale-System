using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddLinkedList
{
    internal class Inventory
    {
        private int pages = 1, itemCounter = 0, displayCounter = 10, productCounter = 0;
        private int cursorPoint = 6;
        private bool gobackToMenu = false;
        public Inventory() {

            


        }
        //getters and setters of attributes/variables
        public int setGetCounter { get { return itemCounter; } set { itemCounter = value; } }
        public int getsetDisplayCount { get { return displayCounter; } set { displayCounter = value; } }
        public bool getKey { get { return gobackToMenu; } set {  gobackToMenu = value; } }

        public void Display()
        {
            var arrayProductName = Products.products;
            var arrayProductQty = Products.productQuantity;
            int counter = 0;
            
            Console.CursorVisible = false;
            ConsoleKeyInfo key;
            
            //Display the header of the table
            Console.WriteLine(new string('=', 51));
            Console.WriteLine("| ID ".PadRight(8) + "Product Name ".PadRight(30) + "Product Qty".PadRight(10) + " |");
            Console.WriteLine();
            
            //Display products table code
            foreach (string prod in arrayProductName)
            {
                if (counter == itemCounter)
                {

                    if (itemCounter < displayCounter)
                    {

                        Console.Write($"| {itemCounter + 1}".PadRight(8) + $"{prod}".PadRight(30));
                        Console.Write($"{arrayProductQty[itemCounter]}".PadLeft(6).PadRight(11) + " |\n");
                        itemCounter++;
                        counter++;
                    }
                    else
                    {

                        break;
                    }                    
                }
                else
                {
                    counter++;
                }
            }

            if (itemCounter == arrayProductName.Count && itemCounter > 10)
            {
                productCounter = arrayProductName.Count % 10;
            }else if(itemCounter < 10)
            {
                productCounter = itemCounter;
            }
            else
            {
                productCounter = 10;
            }
            //Display footer of the table
            Console.WriteLine(new string('=', 51));

            //Displays the text Next/Prev and pages of the table
            if (arrayProductName.Count > 10)
            {
                if (itemCounter == 10)
                {
                    Console.WriteLine("\t\t\t\t\t   [E] Next");
                }
                else if (itemCounter != 10 && itemCounter > 10 && itemCounter != arrayProductName.Count)
                {
                    Console.WriteLine("[Q] Prev\t\t\t\t   [E] Next");
                }
                else if (itemCounter == arrayProductName.Count)
                {
                    Console.WriteLine("[Q] Prev");
                }
            }
            Console.WriteLine($"\n{productCounter}/{arrayProductName.Count} \t\t\t\t\t\tpage {pages}");

            //this highlights the first product for edit
            Console.SetCursorPosition(0, cursorPoint);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            int getNodeFormula = (((displayCounter / 10) - 1) * 10) + Console.CursorTop - 6;
            Console.Write($"| {getNodeFormula + 1}".PadRight(8) + $"{arrayProductName[getNodeFormula]}".PadRight(30));
            Console.Write($"{arrayProductQty[getNodeFormula]}".PadLeft(6).PadRight(11) + " | <==");
            

            //this is the logic algorithmn for moving up, down, next and previous
            do
            {
                key = Console.ReadKey(true);
                //logic algoritmn for moving down
                if (key.Key == ConsoleKey.DownArrow && Console.CursorTop != productCounter + 5)
                {
                    Console.SetCursorPosition(0, Console.CursorTop);
                    getNodeFormula = (((displayCounter / 10) - 1) * 10) + Console.CursorTop - 6;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"| {getNodeFormula + 1}".PadRight(8) + $"{arrayProductName[getNodeFormula]}".PadRight(30));
                    Console.Write($"{arrayProductQty[getNodeFormula]}".PadLeft(6).PadRight(11) + " |    ");
                    Console.SetCursorPosition(0, Console.CursorTop + 1);
                    getNodeFormula = (((displayCounter / 10) - 1) * 10) + Console.CursorTop - 6;
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write($"| {getNodeFormula + 1}".PadRight(8) + $"{arrayProductName[getNodeFormula]}".PadRight(30));
                    Console.Write($"{arrayProductQty[getNodeFormula]}".PadLeft(6).PadRight(11) + " | <==");
                    cursorPoint = Console.CursorTop;
                }
                //logic algoritmn for moving up
                else if (key.Key == ConsoleKey.UpArrow && Console.CursorTop != 6)
                {
                    Console.SetCursorPosition(0, Console.CursorTop);
                    getNodeFormula = (((displayCounter / 10) - 1) * 10) + Console.CursorTop - 6;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"| {getNodeFormula + 1}".PadRight(8) + $"{arrayProductName[getNodeFormula]}".PadRight(30));
                    Console.Write($"{arrayProductQty[getNodeFormula]}".PadLeft(6).PadRight(11) + " |    ");
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    getNodeFormula = (((displayCounter / 10) - 1) * 10) + Console.CursorTop - 6;
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write($"| {getNodeFormula + 1}".PadRight(8) + $"{arrayProductName[getNodeFormula]}".PadRight(30));
                    Console.Write($"{arrayProductQty[getNodeFormula]}".PadLeft(6).PadRight(11) + " | <==");
                    cursorPoint = Console.CursorTop;
                }
                //logic algoritmn for next page
                else if (key.Key == ConsoleKey.E)
                {
                    if (itemCounter == arrayProductName.Count)
                    {
                        Console.SetCursorPosition(0, 21);
                        Console.Write("You're currently on the first page. Please press 'Enter' to navigate back.", Console.ForegroundColor = ConsoleColor.Red);
                        while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                        itemCounter = arrayProductName.Count - (arrayProductName.Count % 10);

                    }
                    else
                    {
                        cursorPoint = 6;
                        Console.SetCursorPosition(0, 6);
                        NextPage();
                    }
                    break;
                }
                //logic algoritmn for previous page
                else if (key.Key == ConsoleKey.Q)
                {
                    if (itemCounter != 10)
                    {
                        cursorPoint = 6;
                        PrevPage();
                    }
                    else
                    {
                        Console.SetCursorPosition(0, 21);
                        Console.Write("You're currently on the first page. Please press 'Enter' to navigate back.", Console.ForegroundColor = ConsoleColor.Red);
                        while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                        itemCounter = 0;
                    }
                    break;
                }
                //go to back main menu
                else if (key.Key == ConsoleKey.N)
                {
                    Console.SetCursorPosition(0, 21);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Kindly confirm your decision by pressing 'Enter' to proceed. If you wish to reconsider, please press 'ESC'.");
                    do
                    {
                        key = Console.ReadKey(true);

                    } while (!(key.Key == ConsoleKey.Enter || key.Key == ConsoleKey.Escape));
                    if (key.Key == ConsoleKey.Enter)
                    {
                        gobackToMenu = true;
                        itemCounter = 0;
                        displayCounter = 10;
                        break;
                    }
                    else if (key.Key == ConsoleKey.Escape)
                    {
                        gobackToMenu = false;
                        itemCounter = 0;
                        displayCounter = 10;
                        break;
                    }

                }
            } while (key.Key != ConsoleKey.Enter);

            //this the algorithnn for updating the quantity of the selected product
           if (key.Key == ConsoleKey.Enter && gobackToMenu == false)
            {
                Console.SetCursorPosition(0, 21);
                Console.ForegroundColor = ConsoleColor.Green;
                //preventing users errors/validation
                Console.WriteLine("Kindly confirm your decision by pressing 'Enter' to proceed. If you wish to reconsider, please press 'ESC'.");
                //algorithmn if users want to stock in and stock out
                do
                {
                    key = Console.ReadKey(true);
                } while (!(key.Key == ConsoleKey.Enter || key.Key == ConsoleKey.Escape));
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.SetCursorPosition(0, 21);
                    Console.WriteLine(new string(' ', 120));
                    Console.SetCursorPosition(0, cursorPoint);
                    getNodeFormula = (((displayCounter / 10) - 1) * 10) + Console.CursorTop - 6;
                    Console.SetCursorPosition(0, 21);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\t    --=[Menu]=--");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(new string('=', 40));
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("[1] Stock In\t[2]Stock Out");
                    //if user select between the two options
                    do
                    {
                        key = Console.ReadKey(true);
                        //stock in feature
                        if(key.KeyChar == '1')
                        {
                            enterQty:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            int qtyOfStockIn = 0;
                            Console.CursorVisible = true;
                            Console.SetCursorPosition(0, 25);
                            Console.WriteLine("\nProduct Id: " + (getNodeFormula+1));
                            Console.WriteLine("Product Name: " + arrayProductName[getNodeFormula]);
                            Console.Write("Qty to stock in:                                         ");
                            Console.SetCursorPosition(17, Console.CursorTop);
                            if(int.TryParse(Console.ReadLine(), out qtyOfStockIn))
                            {
                                qtyOfStockIn = qtyOfStockIn + (int)arrayProductQty[getNodeFormula];
                                arrayProductQty[getNodeFormula] = qtyOfStockIn;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("Product updated/stocked successfully. Press 'Enter' to proceed.");
                                while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("Must enter a numerical value, press 'Enter' to try again.!");
                                while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                                Console.SetCursorPosition(0, Console.CursorTop);
                                Console.Write(new string(' ', 60));
                                goto enterQty;
                            }
                            //stock out feature
                        }else if(key.KeyChar == '2')
                        {
                            enterQtyOut:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            int qtyOfStockOut = 0;
                            Console.CursorVisible = true;
                            Console.SetCursorPosition(0, 25);
                            Console.WriteLine("\nProduct Id: " + (getNodeFormula + 1));
                            Console.WriteLine("Product Name: " + arrayProductName[getNodeFormula]);
                            Console.Write("Qty to stock out: ");
                            if (int.TryParse(Console.ReadLine(), out qtyOfStockOut))
                            {
                                qtyOfStockOut = (int)arrayProductQty[getNodeFormula] - qtyOfStockOut;
                                arrayProductQty[getNodeFormula] = qtyOfStockOut;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("Product updated/stocked out successfully. Press 'Enter' to proceed.");
                                while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("Must enter a numerical value, press 'Enter' to try again.!");
                                while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                                Console.SetCursorPosition(0, Console.CursorTop);
                                Console.Write(new string(' ', 60));
                                goto enterQtyOut;
                            }
                        }
                    } while (!(key.KeyChar ==  '1' || key.KeyChar == '2'));
                    
                    if (itemCounter == arrayProductName.Count && itemCounter % 10 != 0)
                    {
                        itemCounter = itemCounter - arrayProductName.Count % 10;

                    }
                    else if (itemCounter != 10)
                    {
                        itemCounter -= 10;
                        
                    }
                    else if (itemCounter == 10 || itemCounter == arrayProductName.Count)
                    {
                        itemCounter -= 10;
                    }
                   
                   

                }
                //cancels the user deletion
                else if (key.Key == ConsoleKey.Escape)
                {
                    itemCounter = 0;
                    displayCounter = 10;
                }
            }
        }

        //logic algorithmn of prev and next
        public void PrevPage()
        {
            var arrayProductName = Products.products;
            if (itemCounter != 10)
            {
                if (itemCounter == arrayProductName.Count)
                {
                    displayCounter = itemCounter - arrayProductName.Count % 10;
                    itemCounter = displayCounter - 10;
                    pages--;
                }
                else
                {
                    displayCounter -= 10;
                    itemCounter -= 10 * 2;
                    pages--;
                }
            }
        }
        public void NextPage()
        {

            displayCounter += 10;
            pages++;

        }
    }
}
