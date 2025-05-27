using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddLinkedList
{
    internal class Products
    {
        private LinkedList<string> products = new LinkedList<string>();
        private LinkedList<int> productQuantity = new LinkedList<int>();
        private LinkedList<int> productCost = new LinkedList<int>();
        private int pages = 1, itemCounter = 0, displayCounter = 10, productCounter = 0;
        private char userChoice;
        private Random rand = new Random();
        public Products()
        {
            products.AddFirst("Shampoo");
            products.AddFirst("Soap");
            products.AddFirst("Conditioner");
            products.AddFirst("Blanket");
            products.AddFirst("PH Care");
            products.AddFirst("Computer");
            products.AddFirst("Mouse");
            products.AddFirst("Internet");
            products.AddFirst("Intel i5-10500 4hertz");
            products.AddFirst("Graphics Card");
            products.AddFirst("Perfume");
            


            for (int i = 0; i < products.Count; i++)
            {
                productQuantity.AddLast(rand.Next(5, 20));
                productCost.AddLast(rand.Next(500, 1200));
            }




        }
        public string addProduct(string productName, int cost)
        {
            products.AddLast(productName);
            productQuantity.AddLast(0);
            productCost.AddLast(cost);
            return productName;
        }
        public void removeDisplay()
        {
            int counter = 0;
            //Display the header of the table
            Console.WriteLine(new string('=', 57));
            Console.WriteLine("| # ".PadRight(8) + "Product Name ".PadRight(25) + "Quantity".PadRight(10) + "Product Cost".PadLeft(10) + " |");
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
            foreach (string prod in products)
            {
                if (counter == itemCounter)
                {
                    if (itemCounter < displayCounter)
                    {

                        Console.Write($"| {itemCounter + 1}".PadRight(8) + $"{prod}".PadRight(25));
                        Console.Write($"{productQuantity.ElementAt(itemCounter)}".PadRight(10).PadLeft(12) + $"P{productCost.ElementAt(itemCounter):n}".PadLeft(10) + " |\n");
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
            if (itemCounter != products.Count)
            {
                productCounter = itemCounter;

            }
            //Display footer of the table
            Console.WriteLine(new string('=', 57));

            //Displays the text Next/Prev and pages of the table
            if (products.Count > 10)
            {
                if (itemCounter == 10)
                {
                    Console.WriteLine("\t\t\t\t\t\t[E] Next");
                }
                else if (itemCounter != 10 && itemCounter > 10 && itemCounter != products.Count)
                {
                    Console.WriteLine("[Q] Prev\t\t\t\t\t[E] Next");
                }
                else if (itemCounter == products.Count)
                {
                    Console.WriteLine("[Q] Prev");
                }
            }
            Console.WriteLine($"\n{productCounter}/{products.Count} \t\t\t\t\t\tpage {pages}");
            ConsoleKeyInfo key;
            Console.SetCursorPosition(0, 3);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"| {Console.CursorTop - 2}".PadRight(8) + $"{products.ElementAt(Console.CursorTop - 3)}".PadRight(25));
            Console.Write($"{productQuantity.ElementAt(Console.CursorTop - 3)}".PadRight(10).PadLeft(12) + $"P{productCost.ElementAt(Console.CursorTop - 3):n}".PadLeft(10) + " | <--");
            do
            {
                key = Console.ReadKey(true);
                if(key.Key == ConsoleKey.DownArrow)
                {
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"| {Console.CursorTop - 2}".PadRight(8) + $"{products.ElementAt(Console.CursorTop - 3)}".PadRight(25));
                    Console.Write($"{productQuantity.ElementAt(Console.CursorTop - 3)}".PadRight(10).PadLeft(12) + $"P{productCost.ElementAt(Console.CursorTop - 3):n}".PadLeft(10) + " |    ");
                    Console.SetCursorPosition(0, Console.CursorTop+1);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"| {Console.CursorTop - 2}".PadRight(8) + $"{products.ElementAt(Console.CursorTop - 3)}".PadRight(25));
                    Console.Write($"{productQuantity.ElementAt(Console.CursorTop - 3)}".PadRight(10).PadLeft(12) + $"P{productCost.ElementAt(Console.CursorTop - 3):n}".PadLeft(10) + " | <--");
                }
            } while (key.Key != ConsoleKey.Enter);
            /*products.Remove(products.ElementAt(removeItemNo - 1));
            productQuantity.Remove(productQuantity.ElementAt(removeItemNo - 1));
            productCost.Remove(productCost.ElementAt(removeItemNo - 1));*/

        }
        public void editProduct(int editItemNo)
        {
            Console.Write("Product name: ");
            SendKeys.SendWait(products.ElementAt(editItemNo-1));
            products.Find(products.ElementAt(editItemNo-1)).Value = Console.ReadLine();
            Console.Write("Product Cost: ");
            SendKeys.SendWait(productCost.ElementAt(editItemNo - 1).ToString());
            productCost.Find(productCost.ElementAt(editItemNo - 1)).Value = Convert.ToInt32(Console.ReadLine());
        }
        public char setUserChoice { get { return userChoice; } set { userChoice = value; } }
        public int getItemCounter { get { return itemCounter; } set { itemCounter = value; } }
        public int setDisplayCounter { set { displayCounter = value; } }
        public int getProductCount { get { return products.Count; } }
        public void Display()
        {
            int counter = 0;
            //Display the header of the table
            Console.WriteLine(new string('=', 57));
            Console.WriteLine("| # ".PadRight(8) + "Product Name ".PadRight(25) + "Quantity".PadRight(10) + "Product Cost".PadLeft(10) + " |");
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
            foreach (string prod in products)
            {
                if (counter == itemCounter)
                {
                    if (itemCounter < displayCounter)
                    {

                        Console.Write($"| {itemCounter + 1}".PadRight(8) + $"{prod}".PadRight(25));
                        Console.Write($"{productQuantity.ElementAt(itemCounter)}".PadRight(10).PadLeft(12) + $"P{productCost.ElementAt(itemCounter):n}".PadLeft(10) + " |\n");
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
            if (itemCounter != products.Count)
            {
                productCounter = itemCounter;
               
            }
            //Display footer of the table
            Console.WriteLine(new string('=', 57));
           
            //Displays the text Next/Prev and pages of the table
            if (products.Count > 10)
            {            
                if(itemCounter == 10)
                {
                    Console.WriteLine("\t\t\t\t\t\t[E] Next");
                }else if(itemCounter != 10 && itemCounter > 10 && itemCounter != products.Count)
                {
                    Console.WriteLine("[Q] Prev\t\t\t\t\t[E] Next");
                }else if(itemCounter == products.Count)
                {
                    Console.WriteLine("[Q] Prev");
                }
            }
            Console.WriteLine($"\n{productCounter}/{products.Count} \t\t\t\t\t\tpage {pages}");
        }
        
        //logic algorithmn of prev and next
        public void PrevPage()
        {
            if (itemCounter != 9)
            {
                if (itemCounter == products.Count)
                {
                    displayCounter = itemCounter - products.Count % 10;
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
            if (itemCounter == products.Count)
            {
                displayCounter += 10;
                productCounter = products.Count % 10;
                pages++;
                Console.WriteLine(itemCounter + "wew");
               
            }else
            {
                Console.WriteLine(itemCounter + "fff");
                displayCounter += 10;
                pages++;
            }
        }
      
    }
}
