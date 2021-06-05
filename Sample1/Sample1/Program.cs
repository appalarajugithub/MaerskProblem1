using System;
using System.Collections.Generic;
using System.Linq;

namespace Sample1
{
    static class UnitPrice
    {
        //Unit Price
        public const int SKU_A = 50;
        public const int SKU_B = 30;
        public const int SKU_C = 20;
        public const int SKU_D = 15;

    }

    static class ActivePromotions
    {
        //Active Promotions
        public const int AP_3A = 130;
        public const int AP_2B = 45;
        public const int AP_CD = 30;
    }
    abstract public class PromotionEngine
    {
       public abstract int Checkout(Dictionary<string, int> Product);
       protected int RuleEngine(Dictionary <string,int> Product)
        {
          int A_Product= int.Parse( Product.FirstOrDefault(x => x.Key == "A").Value.ToString());
            int B_Product = int.Parse(Product.FirstOrDefault(x => x.Key == "B").Value.ToString());
            int C_Product = int.Parse(Product.FirstOrDefault(x => x.Key == "C").Value.ToString());
            int D_Product = int.Parse(Product.FirstOrDefault(x => x.Key == "D").Value.ToString());


            int totalCost = 0;
            int A_Product_Cost = 0;
            //A_Product cost
            if (A_Product >= 3)
            {
                int Number_of_3A_Set = A_Product / 3;
                int Remainder_Number_of_3A_Set = A_Product % 3;

                A_Product_Cost = ActivePromotions.AP_3A * Number_of_3A_Set;
                A_Product_Cost = A_Product_Cost + (UnitPrice.SKU_A * Remainder_Number_of_3A_Set);
            }
            else
            {
                A_Product_Cost = (UnitPrice.SKU_A * A_Product);
            }

            int B_Product_Cost = 0;
            //A_Product cost
            if (B_Product >= 2)
            {
                int Number_of_2B_Set = B_Product / 2;
                int Remainder_Number_of_2B_Set = B_Product % 2;

                B_Product_Cost = ActivePromotions.AP_2B * Number_of_2B_Set;
                B_Product_Cost = B_Product_Cost + (UnitPrice.SKU_B * Remainder_Number_of_2B_Set);
            }
            else
            {
                B_Product_Cost = (UnitPrice.SKU_B * B_Product);
            }

            int CD_Product_Cost = 0;
            int C_Product_Cost = 0;
            int D_Product_Cost = 0;
            //A_Product cost
            if (C_Product >= 1 && D_Product >= 1)
            {
                if (C_Product > D_Product)
                {
                    int Number_of_CD_Set = C_Product / D_Product;
                    int Remainder_Number_of_CD_Set = C_Product % D_Product;

                    CD_Product_Cost = (ActivePromotions.AP_CD * Number_of_CD_Set);
                    CD_Product_Cost = CD_Product_Cost + (UnitPrice.SKU_C * Remainder_Number_of_CD_Set);
                }
                else if (C_Product < D_Product)
                {
                    int Number_of_CD_Set = D_Product / C_Product;
                    int Remainder_Number_of_CD_Set = D_Product % C_Product;

                    CD_Product_Cost = (ActivePromotions.AP_CD * Number_of_CD_Set);
                    CD_Product_Cost = CD_Product_Cost + (UnitPrice.SKU_D * Remainder_Number_of_CD_Set);
                }
                else if (C_Product == D_Product)
                {
                    CD_Product_Cost = (ActivePromotions.AP_CD * C_Product);
                }
            }
            else
            {


                if (C_Product != 0)
                {
                    C_Product_Cost = (UnitPrice.SKU_C * C_Product);
                }


                if (D_Product != 0)
                {
                    D_Product_Cost = (UnitPrice.SKU_D * D_Product);
                }
            }

            totalCost = A_Product_Cost + B_Product_Cost + CD_Product_Cost + C_Product_Cost + D_Product_Cost;
            return totalCost;
        }
    }

    public class User : PromotionEngine
    {
        public override int Checkout(Dictionary<string, int> Product)
        {
           return RuleEngine(Product);
        }

    }
    class Program
    {
        static void Main()
        {
            GetUserInput();
           
        }

        private static void GetUserInput()
        {
            Console.WriteLine("Enter number for the number of products you want.if you do not want any product then enter 0.");
            while (true)
            {
                string proceed = "Y";
                if (proceed.ToLower() == "Y".ToLower())
                {
                    try
                    {
                        //User Order
                        int A_Product;
                        Console.WriteLine("How many A product you want? ");
                        A_Product = int.Parse(Console.ReadLine());
                        int B_Product;
                        Console.WriteLine("How many B product you want? ");
                        B_Product = int.Parse(Console.ReadLine());
                        int C_Product;
                        Console.WriteLine("How many C product you want? ");
                        C_Product = int.Parse(Console.ReadLine());
                        int D_Product;
                        Console.WriteLine("How many D product you want? ");
                        D_Product = int.Parse(Console.ReadLine());

                        Dictionary<string, int> Product = new Dictionary<string, int>();
                        Product.Add("A", A_Product);
                        Product.Add("B", B_Product);
                        Product.Add("C", C_Product);
                        Product.Add("D", D_Product);

                        PromotionEngine obj = new User();
                        int totalCost = obj.Checkout(Product);

                        Console.WriteLine("Total Cost=" + totalCost);
                        Console.ReadLine();
                    }
                    catch { Console.WriteLine("Incorrect input."); break; }
                }
                else
                {
                    break;
                }
                Console.WriteLine("If You want to proceed then type 'Y' else type 'N'");

                // Create a string variable and get user input from the keyboard and store it in the variable
                proceed = Console.ReadLine();
            }
        }
    }
}
