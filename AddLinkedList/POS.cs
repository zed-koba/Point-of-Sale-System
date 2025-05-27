using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddLinkedList
{
    internal class POS
    {
        private ArrayList userCartName = new ArrayList();
        private ArrayList userCartQty = new ArrayList();
        private ArrayList userCartCost = new ArrayList();
        private int pages = 1, itemCounter = 0, displayCounter = 10, productCounter = 0;
        private int cursorPoint = 6;
        private int productTotalCount;
        private int userTotalCost = 0;
        private bool gobackToMenu = false;

        public POS()
        {
           
        }
        //getters and setters
        public int setGetCounter { get { return itemCounter; } set { itemCounter = value; } }
        public int getsetDisplayCount { get { return displayCounter; } set { displayCounter = value; } }
        public bool getKey { get { return gobackToMenu; } set { gobackToMenu = value; } }

        public void Display()
        {
            //variable declarations
            var arrayProductName = Products.products; // variable for product name array
            var arrayProductCost = Products.productCost;  // variable for product cost array 
            var arrayProductQty = Products.productQuantity;  // variable for product quantity array
            int minusCount = 0;
            int padRight = 10, padRight2 = 35;
            productTotalCount = arrayProductName.Count;
            //subtracts the products total count by products that has 0 quantity
            for (int i = 0; i < arrayProductQty.Count; i++)
            {
                if ((int)arrayProductQty[i] <= 0)
                {
                    minusCount++;
                }
            }
            productTotalCount -= minusCount;
            Console.CursorVisible = false;
            ConsoleKeyInfo key;
            //Display the header of the table
            Console.WriteLine(new string('=', 72));
            Console.WriteLine("| ID ".PadRight(8) + "Product Name ".PadRight(padRight2) + "Qty".PadRight(padRight+5) + "Product Cost".PadRight(padRight) + " |");
            Console.WriteLine();

            //Display products table code
            for (int i = 0; i < arrayProductName.Count; i++)
            {
                if (i >= itemCounter)
                {
                    
                        if (itemCounter < displayCounter)
                        {
                            Console.Write($"| {itemCounter + 1}".PadRight(8) + $"{arrayProductName[i]}".PadRight(35));
                            Console.Write($"{arrayProductQty[i]}".PadRight(padRight + 6) + $"P{arrayProductCost[i]:n}".PadLeft(11).PadRight(10) + " |\n");
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
            }else if(itemCounter < 10)
            {
                productCounter = itemCounter;
            }
            else
            {
                productCounter = 10;
            }
            //Display footer of the table
            Console.WriteLine(new string('=', 72));

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
            Console.WriteLine($"\n{itemCounter}/{productTotalCount} \t\t\t\t\t\tpage {pages}");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n\t    --=[Menu]=--");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(new string('=', 40));
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("[1] View your cart\t[N] <- Main Menu");
            //this highlights the first product for edit
            Console.SetCursorPosition(0, cursorPoint);
            Console.ForegroundColor = ConsoleColor.Blue;
            int getNodeFormula = (((displayCounter / 10) - 1) * 10) + Console.CursorTop - 6;
            Console.Write($"| {getNodeFormula + 1}".PadRight(8) + $"{arrayProductName[getNodeFormula]}".PadRight(padRight2));
            Console.Write($"{arrayProductQty[getNodeFormula]}".PadRight(padRight + 6) + $"P{arrayProductCost[getNodeFormula]:n}".PadLeft(11).PadRight(10) + " | <==");


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
                    Console.Write($"| {getNodeFormula + 1}".PadRight(8) + $"{arrayProductName[getNodeFormula]}".PadRight(padRight2));
                    Console.Write($"{arrayProductQty[getNodeFormula]}".PadRight(padRight + 6) + $"P{arrayProductCost[getNodeFormula]:n}".PadLeft(11).PadRight(10) + " |    ");
                    Console.SetCursorPosition(0, Console.CursorTop + 1);
                    getNodeFormula = (((displayCounter / 10) - 1) * 10) + Console.CursorTop - 6;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"| {getNodeFormula + 1}".PadRight(8) + $"{arrayProductName[getNodeFormula]}".PadRight(padRight2));
                    Console.Write($"{arrayProductQty[getNodeFormula]}".PadRight(padRight + 6) + $"P{arrayProductCost[getNodeFormula]:n}".PadLeft(11).PadRight(10) + " | <==");
                    cursorPoint = Console.CursorTop;
                }
                //logic algoritmn for moving up
                else if (key.Key == ConsoleKey.UpArrow && Console.CursorTop != 6)
                {
                    Console.SetCursorPosition(0, Console.CursorTop);
                    getNodeFormula = (((displayCounter / 10) - 1) * 10) + Console.CursorTop - 6;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"| {getNodeFormula + 1}".PadRight(8) + $"{arrayProductName[getNodeFormula]}".PadRight(padRight2));
                    Console.Write($"{arrayProductQty[getNodeFormula]}".PadRight(padRight + 6) + $"P{arrayProductCost[getNodeFormula]:n}".PadLeft(11).PadRight(10) + " |    ");
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    getNodeFormula = (((displayCounter / 10) - 1) * 10) + Console.CursorTop - 6;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"| {getNodeFormula + 1}".PadRight(8) + $"{arrayProductName[getNodeFormula]}".PadRight(padRight2));
                    Console.Write($"{arrayProductQty[getNodeFormula]}".PadRight(padRight + 6) + $"P{arrayProductCost[getNodeFormula]:n}".PadLeft(11).PadRight(10) + " | <==");
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
                        Console.SetCursorPosition(0, 26);
                        Console.Write("You're currently on the first page. Please press 'Enter' to navigate back.", Console.ForegroundColor = ConsoleColor.Red);
                        while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                        itemCounter = 0;
                    }
                    break;
                }
                //logic algorithmn for going back main menu
                else if (key.Key == ConsoleKey.N)
                {
                    Console.SetCursorPosition(0, 22);
                    Console.Write(new string(' ', 60));
                    Console.SetCursorPosition(0, 23);
                    Console.Write(new string(' ', 60));
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
            } while (!(key.Key == ConsoleKey.Enter && (int)arrayProductQty[getNodeFormula] != 0 || key.KeyChar == '1'));

            //this the algorithnn for adding products to the cart
            if (key.Key == ConsoleKey.Enter && gobackToMenu == false)
            {
                int qty = 1;
                
                //show the function that sets the quantity of the selected product      
                Console.SetCursorPosition(0, Console.CursorTop);
                if (userCartQty.Count != 0)
                {
                    if ((int)arrayProductQty[getNodeFormula] == 0)
                    {
                        qty = 0;    
                    }
                    else
                    {
                        qty = 1;
                    }
                }
                else
                {
                    qty = 1;
                }
                Console.Write($"| {getNodeFormula + 1}".PadRight(8) + $"{arrayProductName[getNodeFormula]}".PadRight(padRight2));
                Console.Write($"{arrayProductQty[getNodeFormula]}".PadRight(padRight + 6) + $"P{arrayProductCost[getNodeFormula]:n}".PadLeft(11).PadRight(10) + $" | <- Qty: {qty}  ->");
                
                //algorithmn for left and right arrow for increase and decrease the product
                do
                {
                    key = Console.ReadKey(true);
                    if(key.Key == ConsoleKey.RightArrow && qty < (int)arrayProductQty[getNodeFormula])
                    {
                        Console.SetCursorPosition(81, Console.CursorTop);
                        qty++;
                        Console.Write(qty);
                    }else if(key.Key == ConsoleKey.LeftArrow && qty > 1)
                    {
                        Console.SetCursorPosition(81, Console.CursorTop);
                        qty--;
                        if (qty < 10)
                        {
                            Console.Write(qty + " ");
                        }else
                        {
                            Console.Write(qty);
                        }
                    }
                } while (!(key.Key == ConsoleKey.Enter || key.Key == ConsoleKey.Escape));
                //shows the products details and add to cart/cancel
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.SetCursorPosition(0, cursorPoint);
                    getNodeFormula = (((displayCounter / 10) - 1) * 10) + Console.CursorTop - 6;
                    Console.SetCursorPosition(0, 20);
                    Console.Write(new string(' ', 60));
                    Console.SetCursorPosition(0, 22);
                    Console.Write(new string(' ', 60));
                    Console.SetCursorPosition(0, 21);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("\t --=[Product Details]=--           ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(new string('=', 40));
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Product Name: {arrayProductName[getNodeFormula]}                             \nQuantity: {qty}\nTotal Cost: P{(int)arrayProductCost[getNodeFormula]*qty:n}\n");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("[C] Add to Cart   [ESC] Cancel");
                    do
                    {
                        key = Console.ReadKey(true);
                    } while (!(key.Key == ConsoleKey.C || key.Key == ConsoleKey.Escape));
                    //add the product to cart
                    if (key.Key == ConsoleKey.C)
                    {
                        if (userCartName.Contains(arrayProductName[getNodeFormula]))
                        {
                            userCartQty[userCartName.IndexOf(arrayProductName[getNodeFormula])] = (int)userCartQty[userCartName.IndexOf(arrayProductName[getNodeFormula])] + qty;
                            userCartCost[userCartName.IndexOf(arrayProductName[getNodeFormula])] = (int)arrayProductCost[getNodeFormula] * (int)userCartQty[userCartName.IndexOf(arrayProductName[getNodeFormula])];
                        }
                        else
                        {
                            userCartName.Add(arrayProductName[getNodeFormula]);
                            userCartQty.Add(qty);
                            userCartCost.Add((int)arrayProductCost[getNodeFormula] * qty);
                        }
                        arrayProductQty[getNodeFormula] = (int)arrayProductQty[getNodeFormula] - qty;
                        cursorPoint = 6;
                    }
                    
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
                //cancels the product to be add on cart
                else if (key.Key == ConsoleKey.Escape)
                {
                    itemCounter = 0;
                    displayCounter = 10;
                }
                //view the products on the cart
            }else if(key.KeyChar == '1')
            {
                if(userCartName.Count == 0)
                {
                    Console.SetCursorPosition(0, 25);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Please add at least one product to the cart to proceed. Press 'Enter' to return.");
                    while (Console.ReadKey(true).Key != ConsoleKey.Enter);
                    itemCounter = 0;
                    displayCounter = 10;
                    getKey = false;

                }
                else
                {
                   viewCart();
                }
                
            }
            
        }
        //method of view products on the cart
        private void viewCart()
        {
            //variable declarations
            var arrayProductName = Products.products;
            var arrayProductCost = Products.productCost;
            var arrayProductQty = Products.productQuantity;
            int cursorPoint2 = 5;
            int padLeft = 12, padRight = 10, padRight2 = 30;
            int padLeft2 = 5, padRight3 = 20;
            int qty = 0;
            ConsoleKeyInfo key;
            choose:
            userTotalCost = 0;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\t\t    --=[View your cart]=--");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Instruction: Press 'Enter' to update the product quantity.");
            Console.WriteLine(new string('=', 72));
            Console.WriteLine("| # ".PadRight(8) + "Product Name ".PadRight(30) + "Product Qty".PadRight(20) + "Product Cost".PadLeft(12).PadRight(10) + " |");
            Console.WriteLine();
            //Display the products on the cart
            for (int i = 0; i < userCartName.Count; i++)
            {
                Console.Write($"| {i + 1} ".PadRight(8) + $"{userCartName[i]} ".PadRight(30) + $"{userCartQty[i]}".PadLeft(5).PadRight(20) + $"P{userCartCost[i]:n}".PadLeft(12).PadRight(10) + " |\n");
            }
            //Display footer of the table
            Console.WriteLine(new string('=', 72));
            //calculates the total cost of the products on the cart
            foreach(int cost in userCartCost)
            {
                userTotalCost += cost;
            }
            Console.WriteLine($"| Total Cost: \t\t\t\t\t\t     P{userTotalCost:n}");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n\t    --=[Menu]=--");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(new string('=', 45));
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("[C] Proceed to Checkout\t      [N] <- Products");
            //this highlights the first product
            Console.SetCursorPosition(0, cursorPoint2);
            Console.ForegroundColor = ConsoleColor.Blue;
            int getNodeFormula = Console.CursorTop - 5;
            Console.Write($"| {getNodeFormula + 1} ".PadRight(8) + $"{userCartName[getNodeFormula]} ".PadRight(30) + $"{userCartQty[getNodeFormula]}".PadLeft(5).PadRight(20)
                         + $"P{userCartCost[getNodeFormula]:n}".PadLeft(12).PadRight(10) + " | <--");
            //this is the logic algorithmn for moving up, down, next and previous
            do
            {
                key = Console.ReadKey(true);
                //logic algoritmn for moving down
                if (key.Key == ConsoleKey.DownArrow && Console.CursorTop != 5 + userCartName.Count-1)
                {
                    Console.SetCursorPosition(0, Console.CursorTop);
                    getNodeFormula = Console.CursorTop - 5;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"| {getNodeFormula + 1} ".PadRight(8) + $"{userCartName[getNodeFormula]} ".PadRight(30) + $"{userCartQty[getNodeFormula]}".PadLeft(5).PadRight(20) 
                        + $"P{userCartCost[getNodeFormula]:n}".PadLeft(12).PadRight(10) + " |    ");
                    Console.SetCursorPosition(0, Console.CursorTop + 1);
                    getNodeFormula =  Console.CursorTop - 5;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"| {getNodeFormula + 1} ".PadRight(8) + $"{userCartName[getNodeFormula]} ".PadRight(30) + $"{userCartQty[getNodeFormula]}".PadLeft(5).PadRight(20)
                        + $"P{userCartCost[getNodeFormula]:n}".PadLeft(12).PadRight(10) + " | <--");
                    cursorPoint2 = Console.CursorTop;
                }
                //logic algoritmn for moving up
                else if (key.Key == ConsoleKey.UpArrow && Console.CursorTop != 5)
                {
                    Console.SetCursorPosition(0, Console.CursorTop);
                    getNodeFormula = Console.CursorTop - 5;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"| {getNodeFormula + 1} ".PadRight(8) + $"{userCartName[getNodeFormula]} ".PadRight(30) + $"{userCartQty[getNodeFormula]}".PadLeft(5).PadRight(20)
                        + $"P{userCartCost[getNodeFormula]:n}".PadLeft(12).PadRight(10) + " |    ");
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    getNodeFormula = Console.CursorTop - 5;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"| {getNodeFormula + 1} ".PadRight(8) + $"{userCartName[getNodeFormula]} ".PadRight(30) + $"{userCartQty[getNodeFormula]}".PadLeft(5).PadRight(20)
                        + $"P{userCartCost[getNodeFormula]:n}".PadLeft(12).PadRight(10) + " | <--");
                    cursorPoint2 = Console.CursorTop;
                }
            } while (!(key.Key == ConsoleKey.Enter || key.Key == ConsoleKey.N || key.Key == ConsoleKey.C));
            //logic algorithmn if users updates product quantity
            qty = (int)userCartQty[getNodeFormula];
            int qtyToReturn = 0;
            if (key.Key == ConsoleKey.Enter)
            {
                do
                {
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.Write($"| {getNodeFormula + 1}".PadRight(8) + $"{userCartName[getNodeFormula]}".PadRight(padRight2));
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"<- {qty}  ->".PadLeft(padLeft2).PadRight(padRight3));
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"P{userCartCost[getNodeFormula]:n}".PadLeft(padLeft).PadRight(padRight) + " |");
                    key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.LeftArrow && qty != 0)
                    {
                        Console.SetCursorPosition(40, Console.CursorTop);
                        qty--;
                        qtyToReturn++;
                        Console.Write(qty);
                    }
                    else if (key.Key == ConsoleKey.RightArrow && qty != (int)arrayProductQty[arrayProductName.IndexOf(userCartName[getNodeFormula])])
                    {
                        Console.SetCursorPosition(40, Console.CursorTop);
                        qty++;
                        qtyToReturn--;
                        Console.Write(qty);
                    }

                } while (!(key.Key == ConsoleKey.Escape || key.Key == ConsoleKey.Enter));
                //updates the product quantity
                if (key.Key == ConsoleKey.Enter)
                {
                    if (qty != 0)
                    {
                        userCartQty[getNodeFormula] = qty;
                        userCartCost[getNodeFormula] = (int)arrayProductCost[arrayProductName.IndexOf(userCartName[getNodeFormula])] * qty;
                    }
                    else
                    {
                        userCartName.RemoveAt(getNodeFormula);
                        userCartQty.RemoveAt(getNodeFormula);
                        userCartCost.RemoveAt(getNodeFormula);
                        cursorPoint2 = 5;
                    }
                    
                    if (userCartName.Count == 0)
                    {
                        itemCounter = 0;
                        displayCounter = 10;
                        getKey = false;
                    }
                    else
                    {
                        goto choose;
                    }

                }
                else
                {
                    goto choose;
                }
             //go to product menu
            }else if(key.Key == ConsoleKey.N)
            {
                itemCounter = 0;
                displayCounter = 10;
                getKey = false;

            //go to checkout
            }else if(key.Key == ConsoleKey.C)
            {
                checkOut();
            }
            
        }
        private void checkOut()
        {
            var arrayProductName = Products.products; // variable for product name array
            var arrayProductCost = Products.productCost;  // variable for product cost array 
            var arrayProductQty = Products.productQuantity;  // variable for product quantity array
            int userMoney = 0;
            ConsoleKeyInfo key;
            Console.CursorVisible = true;
            enterMoney:
            //users input for available funds
            Console.SetCursorPosition(0, 14);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n\t    --=[Checkout]=--");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(new string('=', 45));
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Enter the amount of funds available for the transaction: ");
            //if users have sufficient funds proceeds to receipt
            if (int.TryParse(Console.ReadLine(), out userMoney))
            {
                if (userMoney > userTotalCost)
                {
                    //prevent errors/validation
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\nPlease confirm your funds by pressing 'Enter' and place the order. Press 'ESC' to revise your funds.");
                    do
                    {
                        key = Console.ReadKey(true);
                    } while (!(key.Key == ConsoleKey.Enter || key.Key == ConsoleKey.Escape));
                    if (key.Key == ConsoleKey.Enter)
                    {
                        //prints receipts
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("\t\t    --=[Receipt]=--");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();
                        Console.WriteLine("Transaction ID: 000001");
                        Console.WriteLine("Date: " + DateTime.Today);
                        Console.WriteLine(new string('=', 72));
                        Console.WriteLine("| # ".PadRight(8) + "Product Name ".PadRight(30) + "Product Qty".PadRight(20) + "Product Cost".PadLeft(12).PadRight(10) + " |");
                        Console.WriteLine();
                        for (int i = 0; i < userCartName.Count; i++)
                        {
                            Console.Write($"| {i + 1} ".PadRight(8) + $"{userCartName[i]} ".PadRight(30) + $"{userCartQty[i]}".PadLeft(5).PadRight(20) + $"P{userCartCost[i]:n}".PadLeft(12).PadRight(10) + " |\n");
                        }
                        Console.WriteLine(new string('=', 72));
                        Console.WriteLine($"| Total Cost: ".PadRight(61) + $"P{userTotalCost:n}");
                        Console.WriteLine($"| Amount/Funds: ".PadRight(61) + $"P{userMoney:n}");
                        Console.WriteLine($"| Change: ".PadRight(61) + $"P{userMoney - userTotalCost:n}");

                        Console.Write("\nPress 'Enter' to make another purcharse! ");
                        while (Console.ReadKey(true).Key != ConsoleKey.Enter) ; 
                        userCartName.Clear();
                        userCartCost.Clear();
                        userCartQty.Clear();
                        cursorPoint = 6;
                        itemCounter = 0;
                        displayCounter = 10;

                    }
                    else if (key.Key == ConsoleKey.Escape)
                    {
                        goto enterMoney;
                    }
                }
                else
                {
                    //error handling for funds less than total cost
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Error: Insufficient Funds!, press 'Enter' to try again.!");
                    while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.Write(new string(' ', 60));
                    Console.SetCursorPosition(0, Console.CursorTop-1);
                    Console.Write(new string(' ', 60));
                    goto enterMoney;
                }
            }
            else
            {
                //error handling for input that is not numerical value
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Must enter a numerical value, press 'Enter' to try again.!");
                while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(new string(' ', 60));
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.Write(new string(' ', 60));
                goto enterMoney;
            }

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
