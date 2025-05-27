using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddLinkedList
{
    public class Products
    {
        public static ArrayList products = new ArrayList();
        public static ArrayList productQuantity = new ArrayList();
        public static ArrayList productCost = new ArrayList();
        private int pages = 1, itemCounter = 0, displayCounter = 10, productCounter = 0;
        private int productTotalCount;
        private int cursorPoint = 6;
        private char userChoice;
        private bool gobackToMenu = false;
        private Random rand = new Random();
        public Products(){
            productTotalCount = products.Count;
            products.Add("Shampoo");
            products.Add("Soap");
            products.Add("Conditioner");
            products.Add("Blanket");
            products.Add("PH Care");
            products.Add("Computer");
            products.Add("Mouse");
            products.Add("Internet");
            products.Add("Intel i5-10500 4hertz");
            products.Add("Graphics Card");
            products.Add("Perfume");
           


            for (int i = 0; i < products.Count; i++)
            {
                productQuantity.Add(rand.Next(10,15));
                productCost.Add(rand.Next(500, 1200));
            }

        }
        //getter and setters for privated attributes
        public char setUserChoice { get { return userChoice; } set { userChoice = value; } }
        public int getItemCounter { get { return itemCounter; } set { itemCounter = value; } }
        public int setDisplayCounter { set { displayCounter = value; } }
        public int getProductCount { get { return productTotalCount; } }
        public int getPages { get { return pages; } set { pages = value; } }
        public bool getKey {  get { return gobackToMenu; } set { gobackToMenu = value; } }
        public int setCursorPoint { set { cursorPoint = value; } }
        public string addProduct(string productName, int cost)
        {

            products.Add(productName);
            productQuantity.Add(0);
            productCost.Add(cost);
            
            return productName;
        }
        public void removeDisplay()
        {
            //Display the header of the remove system
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t--=[Remove Product]=--\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Instructions: Press 'Delete' to remove the highlighted product and 'N' to return to the menu.");

            productTotalCount = products.Count;
            //Display the header of the table
            Console.WriteLine(new string('=', 57));
            Console.WriteLine("| # ".PadRight(8) + "Product Name ".PadRight(35) + "Product Cost".PadRight(10) + " |");
            Console.WriteLine();

            //condition statement navigation of products
            if (userChoice == 'E')
            {
                NextPage();

            }
            else if (userChoice == 'Q')
            {
                PrevPage();
            }

            //Display products table code          
            for (int i = 0; i < products.Count; i++)
            {
                if (i >= itemCounter)
                {
                    if (itemCounter < displayCounter)
                    {
                        Console.Write($"| {itemCounter + 1}".PadRight(8) + $"{products[i]}".PadRight(35));
                        Console.Write($"P{productCost[i]:n}".PadLeft(12).PadRight(10) + " |\n");
                        itemCounter++;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (itemCounter == productTotalCount && itemCounter > 10)
            {
                productCounter = productTotalCount % 10;
            }
            else if (itemCounter < 10)
            {
                productCounter = itemCounter;
            }
            else
            {
                productCounter = 10;
            }
            //Display footer of the table
            Console.WriteLine(new string('=', 57));

            //Displays the text Next/Prev and pages of the table
            if (productTotalCount > 10)
            {
                if (itemCounter == 10)
                {
                    Console.WriteLine("\t\t\t\t\t\t[E] Next");
                }
                else if (itemCounter != 10 && itemCounter > 10 && itemCounter != productTotalCount)
                {
                    Console.WriteLine("[Q] Prev\t\t\t\t\t[E] Next");
                }
                else if (itemCounter == productTotalCount)
                {
                    Console.WriteLine("[Q] Prev");
                }
            }
            Console.WriteLine($"\n{productCounter}/{productTotalCount} \t\t\t\t\t\tpage {pages}");

            if (productTotalCount > 0)
            {
                //this highlights the first product for remove
                Console.SetCursorPosition(0, cursorPoint);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                int getNodeFormula = (((displayCounter / 10) - 1) * 10) + Console.CursorTop - 6;
                Console.Write($"| {getNodeFormula + 1}".PadRight(8) + $"{products[getNodeFormula]}".PadRight(35));
                Console.Write($"P{productCost[getNodeFormula]:n}".PadLeft(12).PadRight(10) + " | X");
                ConsoleKeyInfo key;

                //this is the logic algorithmn for moving up, down, next and previous
                do
                {
                    key = Console.ReadKey(true);
                    //logic algoritmn for movnig down
                    if (key.Key == ConsoleKey.DownArrow && Console.CursorTop != productCounter + 5)
                    {
                        Console.SetCursorPosition(0, Console.CursorTop);
                        getNodeFormula = (((displayCounter / 10) - 1) * 10) + Console.CursorTop - 6;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($"| {getNodeFormula + 1}".PadRight(8) + $"{products[getNodeFormula]}".PadRight(35));
                        Console.Write($"P{productCost[getNodeFormula]:n}".PadLeft(12).PadRight(10) + " |  ");
                        Console.SetCursorPosition(0, Console.CursorTop + 1);
                        getNodeFormula = (((displayCounter / 10) - 1) * 10) + Console.CursorTop - 6;
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write($"| {getNodeFormula + 1}".PadRight(8) + $"{products[getNodeFormula]}".PadRight(35));
                        Console.Write($"P{productCost[getNodeFormula]:n}".PadLeft(12).PadRight(10) + " | X");
                        if (productTotalCount == 10 || itemCounter == productTotalCount && Console.CursorTop == productTotalCount % 10 + 5)
                        {
                            cursorPoint = Console.CursorTop - 1;

                        }
                        else
                        {
                            cursorPoint = Console.CursorTop;
                        }
                    }
                    //logic algoritmn for moving up
                    else if (key.Key == ConsoleKey.UpArrow && Console.CursorTop != 6)
                    {
                        Console.SetCursorPosition(0, Console.CursorTop);
                        getNodeFormula = (((displayCounter / 10) - 1) * 10) + Console.CursorTop - 6;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($"| {getNodeFormula + 1}".PadRight(8) + $"{products[getNodeFormula]}".PadRight(35));
                        Console.Write($"P{productCost[getNodeFormula]:n}".PadLeft(12).PadRight(10) + " |  ");
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        getNodeFormula = (((displayCounter / 10) - 1) * 10) + Console.CursorTop - 6;
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write($"| {getNodeFormula + 1}".PadRight(8) + $"{products[getNodeFormula]}".PadRight(35));
                        Console.Write($"P{productCost[getNodeFormula]:n}".PadLeft(12).PadRight(10) + " | X");
                        cursorPoint = Console.CursorTop;
                    }
                    //logic algoritmn for next page
                    else if (key.Key == ConsoleKey.E)
                    {
                        if (itemCounter == productTotalCount)
                        {
                            Console.SetCursorPosition(0, 21);
                            Console.Write("You're currently on the first page. Please press 'Enter' to navigate back.", Console.ForegroundColor = ConsoleColor.Red);
                            while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                            itemCounter = productTotalCount - (productTotalCount % 10);

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
                        //go backs to product menu
                    }
                    else if (key.Key == ConsoleKey.N)
                    {
                        Console.SetCursorPosition(0, 21);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Kindly confirm your decision by pressing 'Enter' to proceed. If you wish to reconsider, please press 'ESC'.");
                        //confirm to go product menu
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
                } while (key.Key != ConsoleKey.Delete);

                //this the algorithnn for deleting the selected product
                if (key.Key == ConsoleKey.Delete)
                {

                    Console.SetCursorPosition(0, 21);
                    Console.ForegroundColor = ConsoleColor.Green;
                    //preventing users errors/validation
                    Console.WriteLine("Kindly confirm your decision by pressing 'Enter' to proceed. If you wish to reconsider, please press 'ESC'.");
                    do
                    {
                        key = Console.ReadKey(true);
                    } while (!(key.Key == ConsoleKey.Enter || key.Key == ConsoleKey.Escape));
                    if (key.Key == ConsoleKey.Enter)
                    {
                        Console.SetCursorPosition(0, cursorPoint);
                        getNodeFormula = (((displayCounter / 10) - 1) * 10) + Console.CursorTop - 6;
                        if (itemCounter == productTotalCount && itemCounter % 10 != 0)
                        {
                            itemCounter = itemCounter - productTotalCount % 10;

                        }
                        else if (itemCounter != 10)
                        {
                            itemCounter -= 10;
                        }
                        else if (itemCounter == 10 || itemCounter == productTotalCount)
                        {
                            itemCounter -= 10;
                        }
                        //removes the selected product from the arrayList
                        products.RemoveAt(getNodeFormula);
                        productQuantity.RemoveAt(getNodeFormula);
                        productCost.RemoveAt(getNodeFormula);
                        Trace.Write(getNodeFormula);
                        cursorPoint = 6;

                    }
                    //cancels the user deletion
                    else if (key.Key == ConsoleKey.Escape)
                    {
                        itemCounter = 0;
                        displayCounter = 10;
                    }
                }
            }

        }
        public void editDisplay()
        {
            //Display the header of the edit system
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\t\t--=[Edit Product]=--\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Instructions: Press 'Enter' to remove the highlighted product and 'N' to return to the menu.");
            productTotalCount = products.Count;    
            //Display the header of the table
            Console.WriteLine(new string('=', 57));
            Console.WriteLine("| # ".PadRight(8) + "Product Name ".PadRight(35) + "Product Cost".PadRight(10) + " |");
            Console.WriteLine();

            //condition statement navigation of products
            if (userChoice == 'E')
            {
                NextPage();

            }
            else if (userChoice == 'Q')
            {
                PrevPage();
            }

            //Display products table code          
            for (int i = 0; i < products.Count; i++)
            {
                if (i >= itemCounter)
                {
                    if (itemCounter < displayCounter)
                    {
                        Console.Write($"| {itemCounter + 1}".PadRight(8) + $"{products[i]}".PadRight(35));
                        Console.Write($"P{productCost[i]:n}".PadLeft(12).PadRight(10) + " |\n");
                        itemCounter++;
                    }
                    else
                    {
                        break;
                    } 
                }
            }

            if (itemCounter == productTotalCount && itemCounter > 10)
            {
                productCounter = productTotalCount % 10;
            }
            else if (itemCounter < 10)
            {
                productCounter = itemCounter;
            }
            else
            {
                productCounter = 10;
            }
            //Display footer of the table
            Console.WriteLine(new string('=', 57));

            //Displays the text Next/Prev and pages of the table
            if (productTotalCount > 10)
            {
                if (itemCounter == 10)
                {
                    Console.WriteLine("\t\t\t\t\t\t[E] Next");
                }
                else if (itemCounter != 10 && itemCounter > 10 && itemCounter != productTotalCount)
                {
                    Console.WriteLine("[Q] Prev\t\t\t\t\t[E] Next");
                }
                else if (itemCounter == productTotalCount)
                {
                    Console.WriteLine("[Q] Prev");
                }
            }
            Console.WriteLine($"\n{productCounter}/{productTotalCount} \t\t\t\t\t\tpage {pages}");
            if (productTotalCount > 0)
            {
                //this highlights the first product for edit
                Console.SetCursorPosition(0, cursorPoint);
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                int getNodeFormula = (((displayCounter / 10) - 1) * 10) + Console.CursorTop - 6;
                Console.Write($"| {getNodeFormula + 1}".PadRight(8) + $"{products[getNodeFormula]}".PadRight(35));
                Console.Write($"P{productCost[getNodeFormula]:n}".PadLeft(12).PadRight(10) + " | <+-");
                ConsoleKeyInfo key;

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
                        Console.Write($"| {getNodeFormula + 1}".PadRight(8) + $"{products[getNodeFormula]}".PadRight(35));
                        Console.Write($"P{productCost[getNodeFormula]:n}".PadLeft(12).PadRight(10) + " |    ");
                        Console.SetCursorPosition(0, Console.CursorTop + 1);
                        getNodeFormula = (((displayCounter / 10) - 1) * 10) + Console.CursorTop - 6;
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write($"| {getNodeFormula + 1}".PadRight(8) + $"{products[getNodeFormula]}".PadRight(35));
                        Console.Write($"P{productCost[getNodeFormula]:n}".PadLeft(12).PadRight(10) + " | <+-");
                        cursorPoint = Console.CursorTop;
                    }
                    //logic algoritmn for moving up
                    else if (key.Key == ConsoleKey.UpArrow && Console.CursorTop != 6)
                    {
                        Console.SetCursorPosition(0, Console.CursorTop);
                        getNodeFormula = (((displayCounter / 10) - 1) * 10) + Console.CursorTop - 6;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($"| {getNodeFormula + 1}".PadRight(8) + $"{products[getNodeFormula]}".PadRight(35));
                        Console.Write($"P{productCost[getNodeFormula]:n}".PadLeft(12).PadRight(10) + " |    ");
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        getNodeFormula = (((displayCounter / 10) - 1) * 10) + Console.CursorTop - 6;
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write($"| {getNodeFormula + 1}".PadRight(8) + $"{products[getNodeFormula]}".PadRight(35));
                        Console.Write($"P{productCost[getNodeFormula]:n}".PadLeft(12).PadRight(10) + " | <+-");
                        cursorPoint = Console.CursorTop;
                    }
                    //logic algoritmn for next page
                    else if (key.Key == ConsoleKey.E)
                    {
                        if (itemCounter == productTotalCount)
                        {
                            Console.SetCursorPosition(0, 21);
                            Console.Write("You're currently on the first page. Please press 'Enter' to navigate back.", Console.ForegroundColor = ConsoleColor.Red);
                            while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                            itemCounter = productTotalCount - (productTotalCount % 10);

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
                    //go to product menu
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

                //this the algorithnn for editing the selected product
                if (key.Key == ConsoleKey.Enter && gobackToMenu == false)
                {
                    Console.SetCursorPosition(0, 21);
                    Console.ForegroundColor = ConsoleColor.Green;
                    //preventing users errors/validation
                    Console.WriteLine("Kindly confirm your decision by pressing 'Enter' to proceed. If you wish to reconsider, please press 'ESC'.");
                    do
                    {
                        key = Console.ReadKey(true);
                    } while (!(key.Key == ConsoleKey.Enter || key.Key == ConsoleKey.Escape));
                    //algorithmn for editing the selected product
                    if (key.Key == ConsoleKey.Enter)
                    {
                        Console.SetCursorPosition(0, 21);
                        Console.WriteLine(new string(' ', 120));
                        Console.SetCursorPosition(0, cursorPoint);
                        getNodeFormula = (((displayCounter / 10) - 1) * 10) + Console.CursorTop - 6;
                        Console.SetCursorPosition(0, 21);
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("\t    --=[Edit]=--");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(new string('=', 40));
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.CursorVisible = true;
                        Console.Write("Product name: ");
                        SendKeys.SendWait(products[getNodeFormula].ToString());
                        products[getNodeFormula] = Console.ReadLine();
                        Console.Write("Product Cost: ");
                        SendKeys.SendWait(productCost[getNodeFormula].ToString());
                        productCost[getNodeFormula] = Convert.ToInt32(Console.ReadLine());
                        if (itemCounter == productTotalCount && itemCounter % 10 != 0)
                        {
                            itemCounter = itemCounter - productTotalCount % 10;

                        }
                        else if (itemCounter != 10)
                        {
                            itemCounter -= 10;

                        }
                        else if (itemCounter == 10 || itemCounter == productTotalCount)
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
        }

        public void Display()
        {            
            int minusCount = 0;
            //total count with qty > 0
            productTotalCount = products.Count;
            //count products with qty = 0
            for (int i = 0; i < productQuantity.Count; i++)
            {
                if ((int)productQuantity[i] <= 0)
                {
                    minusCount++;
                }
            }
            productTotalCount -= minusCount;
            //Display the header of the table
            Console.WriteLine(new string('=', 57));
            Console.WriteLine("| # ".PadRight(8) + "Product Name ".PadRight(35)+ "Product Cost".PadRight(10) + " |");
            Console.WriteLine();
          
            //condition statement navigation of products
            if (userChoice == 'E')
            {
                NextPage();
                                
            }
            else if (userChoice == 'Q')
            {
                PrevPage();
            }

            //Display products table code          
            for (int i = 0; i < products.Count; i++)
            {
                if (i >= itemCounter)
                {
                    if ((int)productQuantity[i] > 0)
                    {
                        if (itemCounter < displayCounter)
                        {
                            Console.Write($"| {itemCounter + 1}".PadRight(8) + $"{products[i]}".PadRight(35));
                            Console.Write($"P{productCost[i]:n}".PadLeft(12).PadRight(10) + " |\n");
                            itemCounter++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            if (itemCounter == productTotalCount && itemCounter > 10)
            {
                productCounter = productTotalCount % 10;
            }else if(itemCounter < 10)
            {
                productCounter = itemCounter;
            }
            else
            {
                productCounter = 10;
            }
            //Display footer of the table
            Console.WriteLine(new string('=', 57));
           
            //Displays the text Next/Prev and pages of the table
            if (productTotalCount > 10)
            {            
                if(itemCounter == 10)
                {
                    Console.WriteLine("\t\t\t\t\t\t[E] Next");
                }else if(itemCounter != 10 && itemCounter > 10 && itemCounter != productTotalCount)
                {
                    Console.WriteLine("[Q] Prev\t\t\t\t\t[E] Next");
                }else if(itemCounter == productTotalCount)
                {
                    Console.WriteLine("[Q] Prev");
                }
            }
            Console.WriteLine($"\n{productCounter}/{productTotalCount} \t\t\t\t\t\tpage {pages}");
        }
        
        //logic algorithmn of prev and next
        public void PrevPage()
        {
            if (itemCounter != 10)
            {
                if (itemCounter == productTotalCount)
                {
                    displayCounter = itemCounter - productTotalCount % 10;
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
