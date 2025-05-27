using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace AddLinkedList
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //instantiating classes
            Products product = new Products();
            Inventory inventory = new Inventory();
            POS pointOfSale = new POS();

            //setting attributes
            string cashierUsername = "cashier", username = "admin", password = "123";
            string userInput, userPassInput;
            bool adminaccess;
            var arrayOfProduct = Products.products;
            var arrayOfProductCost = Products.productCost;

            //loop
            loginInput:
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter username: ");
            userInput = Console.ReadLine();
            Console.Write("Enter password: ");
            userPassInput = Console.ReadLine();

            //user access conditional statement
            if (userInput == username && userPassInput == password || userInput == cashierUsername && userPassInput == password)
            {
            firstOption:

                //Display Main Menu Selection
                Console.Clear();
                int userChoice;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\t    --=[Menu]=--");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(new string('=', 40));
                Console.WriteLine("[1] Products\t[2] Inventory Management\n[3] POS\t\t[4] Logout");
                Console.WriteLine();
                Console.WriteLine("Instruction: \nPlease select an option from the menu above by entering a number between 1 and 4.\nFor example, to choose option 2, simply type '2' and press Enter.\n");
                Console.Write("Type the option you would like to choose: ");

                //main menu selection conditional statement
                if (int.TryParse(Console.ReadLine(), out userChoice))
                {

                    switch (userChoice)
                    {
                        //Product Menu Selection
                        case 1:
                            product.setUserChoice = '1';
                            product.getItemCounter = 0;
                            product.setDisplayCounter = 10;
                            productOptions:
                            Console.ForegroundColor = ConsoleColor.White;
                            char userProductChoice = ' ';

                            //Diplay Product Menu
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\t\t    --=[Products]=--\n");
                            Console.ForegroundColor = ConsoleColor.White;
                            product.Display();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("\t    --=[Menu]=--");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(new string('=', 40));
                            Console.WriteLine("[1] Add\t     [2] Edit     [3] Remove\n[4] Search   [N] <-Main Menu");
                            Console.WriteLine();
                            Console.WriteLine("Instruction: Choose an option from the menu by pressing the key located on the left side of the available options.");
                            Console.CursorVisible = false;
                            ConsoleKeyInfo keyInfo;

                            //constant reading user input for system navigation
                            do
                            {
                                keyInfo = Console.ReadKey(true);
                                userProductChoice = Char.ToUpper(keyInfo.KeyChar);
                            } while (!(keyInfo.KeyChar == '1' || keyInfo.KeyChar == '2' || keyInfo.KeyChar == '3' || keyInfo.KeyChar == '4' || keyInfo.Key == ConsoleKey.N || keyInfo.KeyChar == 'e' || keyInfo.KeyChar == 'q'));
                            
                            //system navigation conditional statement
                            switch (userProductChoice)
                            {

                                //Function: Add product
                                case '1':
                                    Console.CursorVisible = true;
                                    string productName = "";
                                    int cost;
                                    product.setUserChoice = '1';
                                    product.getItemCounter = 0;
                                    product.setDisplayCounter = 10;
                                    addInput:
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine("\t\t--=[Add Product]=--\n");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("Instruction: Enter 'n' to return to the main menu.");
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    Console.WriteLine("\n--=[Add]=--");
                                    Console.Write("\nEnter the product name: ");
                                    productName = Console.ReadLine();
                                    if (productName == "n")
                                    {
                                        product.getItemCounter = 0;
                                        product.setDisplayCounter = 10;
                                        goto productOptions;
                                    } else if (arrayOfProduct.Contains(productName) == true)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("The product already exists. Kindly add a new product and press 'Enter' to retry.");
                                        while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                                        product.getItemCounter = 0;
                                        product.setDisplayCounter = 10;
                                        goto addInput;

                                    }
                                    else
                                    {
                                        setProductCost:
                                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                                        Console.SetCursorPosition(0, 7);
                                        Console.Write("Set the product cost:                                                   ");
                                        Console.SetCursorPosition(22, Console.CursorTop);
                                        if (int.TryParse(Console.ReadLine(), out cost)){
                                            product.addProduct(productName, cost);
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.Write("Successfully Added...Press Enter to continue....");
                                            Console.ReadLine();
                                            product.setDisplayCounter = product.getItemCounter + 10;
                                            Console.WriteLine();
                                            goto addInput;
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.Write("Must enter a numerical value, press 'Enter' to try again.!");
                                            while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                                            Console.SetCursorPosition(0, Console.CursorTop);
                                            Console.Write(new string(' ', 60));
                                            goto setProductCost;
                                        }
                                    }

                                //Function: Edit product
                                case '2':
                                    product.setUserChoice = '2';
                                    product.getItemCounter = 0;
                                    product.setDisplayCounter = 10;
                                    product.getPages = 1;
                                    product.getKey = false;
                                    product.setCursorPoint = 6;
                                edit:
                                    Console.CursorVisible = false;
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Clear();
                                    if (product.getProductCount == 0)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Unable to locate any product listed, please add a product and set the quantity to proceed. Press 'Enter' to go back;");
                                        while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                                        product.getItemCounter = 0;
                                        product.setDisplayCounter = 10;
                                        product.getPages = 1;
                                        product.getKey = false;
                                        goto productOptions;
                                    }
                                    else
                                    {
                                        product.editDisplay();
                                    }
                                    if (product.getKey == true)
                                    {
                                        goto productOptions;
                                    }
                                    else
                                    {
                                        goto edit;
                                    }

                                //Function: Remove product
                                case '3':
                                    product.setUserChoice = '3';
                                    product.getItemCounter = 0;
                                    product.setDisplayCounter = 10;
                                    product.getPages = 1;
                                    product.getKey = false;
                                    product.setCursorPoint = 6;
                                    removeProduct:
                                    Console.CursorVisible = false;
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Clear();
                                    if (product.getProductCount == 0)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Unable to locate any product listed, please add a product and set the quantity to proceed. Press 'Enter' to go back;");
                                        while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                                        product.getItemCounter = 0;
                                        product.setDisplayCounter = 10;
                                        product.getPages = 1;
                                        product.getKey = false;
                                        goto productOptions;
                                    }else
                                    { 
                                        product.removeDisplay();
                                    }
                                    if (product.getKey == true)
                                    {
                                        goto productOptions;
                                    }
                                    else
                                    {
                                        goto removeProduct;
                                    }

                                //Function: Search product
                                case '4':
                                search:
                                    Console.Clear();
                                    //Display the header of the remove system
                                    int searchProductID = 0;
                                    string searchProductName = "";

                                    Console.CursorVisible = true;
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("\t\t--=[Search a Product]=--\n");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("Instruction:\nPlease input the product ID or product name to initiate a search. Enter 'n' to return to the main menu.");
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("\n--=[Search]=--");
                                    Console.Write("Type the product id or product name: ");
                                    searchProductName = Console.ReadLine();
                                    if (searchProductName == "n" || searchProductName == "N")
                                    {
                                        product.getItemCounter = 0;
                                        product.setDisplayCounter = 10;
                                        goto productOptions;
                                    }
                                    if (int.TryParse(searchProductName, out searchProductID))
                                    {
                                        if (searchProductID <= arrayOfProduct.Count)
                                        {
                                            Console.WriteLine("\nProduct ID: " + searchProductID);
                                            Console.WriteLine("Product Name: " + arrayOfProduct[searchProductID - 1]);
                                            Console.WriteLine($"Product Cost: P{arrayOfProductCost[searchProductID - 1]:n}");
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.Write("Product found successfully. Press 'Enter' to search for another product.");
                                            while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                                            goto search;
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.Write("Unable to locate the product ID. It may not exist or an incorrect ID was provided. Press 'Enter' to retry.");
                                            while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                                            goto search;
                                        }
                                    }
                                    else
                                    {
                                        if (arrayOfProduct.Contains(searchProductName) == true)
                                        {
                                            int findProduct = arrayOfProduct.IndexOf(searchProductName);
                                            if ((string)arrayOfProduct[findProduct] == searchProductName)
                                            {
                                                Console.WriteLine("\nProduct ID: " + (findProduct + 1));
                                                Console.WriteLine("Product Name: " + arrayOfProduct[findProduct]);
                                                Console.WriteLine($"Product Cost: P{arrayOfProductCost[findProduct]:n}\n");
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.Write("Product found successfully. Press 'Enter' to search for another product.");
                                                while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                                                goto search;
                                            }
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.Write("Unable to locate the product. It may not exist or an incorrect product name was provided. Press 'Enter' to retry.");
                                            while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                                            goto search;
                                        }
                                    }
                                    break;

                                //Navigation: Return to main menu
                                case 'N':
                                    goto firstOption;

                                //Navigation: Previous page 
                                case 'Q':
                                case 'q':
                                    if (product.getItemCounter != 10)
                                    {
                                        product.setUserChoice = Char.ToUpper(userProductChoice);
                                        goto productOptions;
                                    }
                                    else
                                    {
                                        Console.Write("You're currently on the first page. Please press 'Enter' to navigate back.", Console.ForegroundColor = ConsoleColor.Red);
                                        while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                                        product.getItemCounter = 0;
                                        product.setUserChoice = ' ';
                                        goto productOptions;
                                    }

                                //Navigation: Next page 
                                case 'E':
                                case 'e':
                                    if (product.getItemCounter == product.getProductCount)
                                    {
                                        Console.Write("You're currently on the last page. Please press 'Enter' to navigate back.", Console.ForegroundColor = ConsoleColor.Red);
                                        while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                                        if (product.getProductCount > 10)
                                        {
                                            product.getItemCounter = product.getProductCount - (product.getProductCount % 10);
                                        }
                                        else
                                        {
                                            product.getItemCounter = 0;
                                        }
                                        product.setUserChoice = ' ';
                                        goto productOptions;
                                    }
                                    else
                                    {
                                        product.setUserChoice = Char.ToUpper(userProductChoice);
                                        goto productOptions;
                                    }

                            }
                            break;

                        //Inventory Management 
                        case 2:
                            inventory.setGetCounter = 0;
                            inventory.getsetDisplayCount = 10;
                            inventory.getKey = false;
                            Console.CursorVisible = false;
                            inventoryreset:

                            //Display Inventory Menu
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\t\t    --=[Inventory Management]=--\n");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Instruction: To adjust stock (in/out) for the highlighted product, press 'Enter'; for the main menu, press 'N'.");
                            inventory.Display();
                            if (inventory.getKey == true)
                            {
                                goto firstOption;
                            }
                            else
                            {
                                goto inventoryreset;
                            }

                        //POS System
                        case 3:
                            pointOfSale.setGetCounter = 0;
                            pointOfSale.getsetDisplayCount = 10;
                            pointOfSale.getKey = false;
                            Console.CursorVisible = false;
                            posreset:

                            //Display POS Menu
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("\t\t    --=[Point of Sale]=--");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Instruction: Choose a product for purchase, press 'Enter' to specify the quantity, \n\t     and then press 'Enter' again to add it to your cart");
                            pointOfSale.Display();
                            if (pointOfSale.getKey == true)
                            {
                                goto firstOption;
                               
                            }
                            else
                            {
                                goto posreset;
                            }
                            
                        //Error handler if selection does not match from the main menu
                        default:
                            Console.Write("Invalid option! please retry with the correct option. Press 'Enter' to retry again.", Console.ForegroundColor = ConsoleColor.Red);
                            while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                            goto firstOption;
                    }
                }
                else
                {
                    //Error handler if selection is not numerical
                    Console.Write("Invalid submission! please enter a numerical value. Press 'Enter' to retry.", Console.ForegroundColor = ConsoleColor.Red);
                    while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                    goto firstOption;
                }
            }
            else
            {
                //Error handler if user inputs wrong credentials
                Console.Write("Invalid credentials. Please retry with the correct information. Press 'Enter' to attempt again.", Console.ForegroundColor = ConsoleColor.Red);
                while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                Console.Clear();
                goto loginInput;
            }
            Console.ReadLine();
        }

    }
}

