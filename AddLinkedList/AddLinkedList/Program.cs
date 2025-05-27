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

            Products product = new Products();
            string cashierUsername = "cashier", username = "admin", password = "123";
            string userInput, userPassInput;
            bool adminAccess;
        loginInput:
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter username: ");
            userInput = Console.ReadLine();
            Console.Write("Enter password: ");
            userPassInput = Console.ReadLine();
            if (userInput == username && userPassInput == password || userInput == cashierUsername && userPassInput == password)
            {
            firstOption:
                Console.Clear();
                int userChoice;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\tMenu");
                Console.WriteLine(new string('=', 30));
                Console.WriteLine("[1] Products\t[2] POS\n[3] Logout");
                Console.WriteLine();
                Console.WriteLine("Instruction: \nPlease select an option from the menu above by entering a number between 1 and 3.\nFor example, to choose option 2, simply type '2' and press Enter.\n");
                Console.Write("Type the option you would like to choose: ");
                if (int.TryParse(Console.ReadLine(), out userChoice))
                {
                    switch (userChoice)
                    {
                        case 1:
                        productOptions:
                            Console.ForegroundColor = ConsoleColor.White;
                            char userProductChoice = ' ';
                            Console.Clear();
                            product.Display();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("\t\tMenu");
                            Console.WriteLine(new string('=', 40));
                            Console.WriteLine("[1] Add\t     [2] Edit     [3] Remove\n[4] Search");
                            Console.WriteLine();
                            Console.WriteLine("Instruction: Choose an option from the menu by pressing the key located on the left side of the available options.");
                            Console.CursorVisible = false;
                            ConsoleKeyInfo keyInfo;
                            do
                            {
                                keyInfo = Console.ReadKey(true);
                                userProductChoice = Char.ToUpper(keyInfo.KeyChar);
                            } while (!(keyInfo.KeyChar == '1' || keyInfo.KeyChar == '2' || keyInfo.KeyChar == '3' || keyInfo.KeyChar == '4' || keyInfo.KeyChar == '5' || keyInfo.KeyChar == 'e' || keyInfo.KeyChar == 'q'));
                            switch (userProductChoice)
                            {
                                case '1':
                                    Console.CursorVisible = true;
                                    string productName = "";
                                    int cost;
                                    product.setUserChoice = '1';
                                    product.getItemCounter = 0;
                                    product.setDisplayCounter = 10;
                                addInput:
                                    Console.Clear();
                                    product.Display();
                                    Console.WriteLine("\n\t--[Add Product]--");
                                    Console.WriteLine("\nInstruction: \nType 'n' if you want to choose another option");
                                    Console.Write("Enter the product name: ");
                                    productName = Console.ReadLine();
                                    if (productName == "n")
                                    {
                                        product.getItemCounter = 0;
                                        product.setDisplayCounter = 10;
                                        goto productOptions;
                                    }
                                    else
                                    {
                                        Console.Write("Set the product cost: ");
                                        cost = Convert.ToInt32(Console.ReadLine());
                                        product.addProduct(productName, cost);
                                        Console.Write("Successfully Added...Press Enter to continue....");
                                        product.getItemCounter = product.getItemCounter % product.getProductCount == 0 ? product.getProductCount - 10 : (product.getProductCount / 10) * 10;
                                        Console.ReadLine();
                                        product.setDisplayCounter = product.getItemCounter + 10;
                                        Console.WriteLine();
                                        goto addInput;
                                    }
                                case '2':
                                edit:
                                    string editProductItem;
                                    Console.CursorVisible = true;
                                    product.setUserChoice = '2';
                                    product.getItemCounter = 0;
                                    product.setDisplayCounter = 10;
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Clear();
                                    product.Display();
                                    Console.WriteLine("\n\t--[Edit Product]--");
                                    Console.WriteLine("\nInstruction: \nType 'n' if you want to choose another option");
                                    Console.Write("Enter the product item number: ");
                                    editProductItem = Console.ReadLine();
                                    if (editProductItem != "n")
                                    {
                                        int editItemNo = 0;
                                        if (int.TryParse(editProductItem, out editItemNo))
                                        {
                                            product.editProduct(editItemNo);
                                            Console.Write("Successfully updated. Press 'Enter' to proceed.", Console.ForegroundColor = ConsoleColor.Green);
                                            while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                                            goto edit;
                                        }
                                        else
                                        {
                                            Console.Write("Invalid submission. Please enter a valid product item number and press 'Enter' to proceed", Console.ForegroundColor = ConsoleColor.Red);
                                            while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                                        }
                                    }
                                    else
                                    {
                                        product.getItemCounter = 0;
                                        product.setDisplayCounter = 10;
                                        goto productOptions;
                                    }
                                    goto edit;
                                case '3':
                                    removeProduct:
                                    product.setUserChoice = '3';
                                    product.getItemCounter = 0;
                                    product.setDisplayCounter = 10;
                                    Console.CursorVisible = true;
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Clear();
                                    product.removeDisplay();
                                    /*Console.WriteLine("\n\t--[Remove Product]--");
                                    Console.WriteLine("\nInstruction: \nType 'n' if you want to choose another option");
                                    Console.Write("Enter the product item number: ");
                                    removeProductName = Console.ReadLine();
                                    if (removeProductName != "n")
                                    {
                                        int removeItemNo = 0;
                                        if (int.TryParse(removeProductName, out removeItemNo))
                                        {
                                            product.removeProduct(removeItemNo);
                                            Console.Write("Removal successful. Press 'Enter' to proceed.", Console.ForegroundColor = ConsoleColor.Green);
                                            while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                                        }
                                        else
                                        {
                                            Console.Write("Invalid submission. Please enter a valid product item number and press 'Enter' to proceed", Console.ForegroundColor = ConsoleColor.Red);
                                            while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                                        }
                                    }
                                    else
                                    {
                                        product.getItemCounter = 0;
                                        product.setDisplayCounter = 10;
                                        goto productOptions;
                                    }
*/
                                    goto removeProduct;
                                case '4':
                                    Console.WriteLine("\tProducts");
                                    Console.WriteLine(new string('=', 30));
                                    product.Display();
                                    break;
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
                                case 'E':
                                case 'e':
                                    if (product.getItemCounter == product.getProductCount)
                                    {
                                        Console.Write("You're currently on the last page. Please press 'Enter' to navigate back.", Console.ForegroundColor = ConsoleColor.Red);
                                        while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                                        product.getItemCounter = product.getProductCount - (product.getProductCount % 10);
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
                        case 2:

                            break;
                        case 3:

                            break;

                        default:
                            Console.Write("Invalid option! please retry with the correct option. Press 'Enter' to retry again.", Console.ForegroundColor = ConsoleColor.Red);
                            while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                            goto firstOption;
                    }
                }
                else
                {
                    Console.Write("Invalid submission! please enter a numerical value. Press 'Enter' to retry.", Console.ForegroundColor = ConsoleColor.Red);
                    while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                    goto firstOption;
                }
            }
            else
            {
                Console.Write("Invalid credentials. Please retry with the correct information. Press 'Enter' to attempt again.", Console.ForegroundColor = ConsoleColor.Red);
                while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                Console.Clear();
                goto loginInput;
            }
            Console.ReadLine();
        }

    }
}

