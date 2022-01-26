using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Program
    {
        static int size, numofran, count;
        static string str;
        static bool success = false;
        static int menu()
        {
            int choice;
            Console.WriteLine("1 - Task A ");
            Console.WriteLine("2 - Task B");
            Console.WriteLine("3 - Exist");
            Console.Write("Enter Your Choose : ");
            do
            {
                success = int.TryParse(Console.ReadLine(), out choice);
                if (!success) Console.WriteLine(" Please try again");
            }while(!success);
                switch (choice)
                {
                    case 1:
                        TaskA();
                        break;
                    case 2:
                        TaskB();
                        break;
                    case 3:
                        return 0;
                    default:
                        Console.WriteLine("Your choose not correct Please try again");
                        menu();
                        break;
                }
            return 0;
        }
        static void TaskA()
        {
            int cho1 = MenuTaskA();
            int[] arr = new int[size];
            if (cho1 == 1)
            {
                int subcho1;
                subcho1 = MenuCreateArrTaskA();
                if (subcho1 == 1)
                {
                    arr = createarronedimansionalbyrandom();
                    cho1 = MenuTaskA();
                }
                else if (subcho1 == 2)
                {
                    arr = createonedimensionalbyuser();
                    cho1 = MenuTaskA();
                }
            }
            if (cho1 == 2)
            {
                printarr(ref arr);
                arr = SortEvenTaskA(ref arr);
                Console.WriteLine("Array after sorting");
                printarr(ref arr);
                cho1 = MenuTaskA();

            }
            if (cho1 == 3) menu();
        }
        static int MenuTaskA()
        {
            int choiceone;
            Console.WriteLine("1 - Create array");
            Console.WriteLine("2 - Sort all even numbers and stay all odd numbersin their Places");
            Console.WriteLine("3 - Back");
            Console.Write("Please enter your choose : ");
            do
            {
                success = int.TryParse(Console.ReadLine(), out choiceone);
                if (!success) Console.WriteLine(" Please try again");
            } while (!success);
            return choiceone;
        }
        static int MenuCreateArrTaskA()
        {
            int choicecreate;
            Console.WriteLine("1 - Create an array by Random ");
            Console.WriteLine("2 - Create an array by user ");
            Console.Write("Please enter your choose : ");
            do
            {
                success = int.TryParse(Console.ReadLine(), out choicecreate);
                if (!success) Console.WriteLine(" Please try again");
            } while (!success);
            return choicecreate;
        }
        static int[] createarronedimansionalbyrandom()
        {
            Console.Write("Please enter size of array : ");
            size = int.Parse(Console.ReadLine());
            Random rndele = new Random();
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
                arr[i] = rndele.Next(1, 1000);
            foreach (int j in arr)
                Console.Write(" " + j + " ");
            Console.WriteLine();
            return arr;
        }
        static int[] createonedimensionalbyuser()
        {
            Console.Write("Please enter size of array : ");
            size = int.Parse(Console.ReadLine());
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                Console.Write("Enter an element number  " + i);
                arr[i] = int.Parse(Console.ReadLine());
            }
            foreach (int j in arr)
                Console.Write(" " + j + " ");
            Console.WriteLine();
            return arr;
        }
        static int[] SortEvenTaskA(ref int[] arr)
        {
            int[] temparr = new int[size];
            int count = 0 , key, j;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    temparr[i] = arr[i];
                    count++;
                }
                else continue;
            }
            for (int k = 1; k < temparr.Length; k++)
            {
                key = temparr[k];
                j = k - 1;
                while (j >= 0 && temparr[j] > key)
                {
                    temparr[j + 1] = temparr[j];
                    j = j - 1;
                }
                temparr[j + 1] = key;
            }
            int index = size - count;
            for (int x = 0; x < size; x++)
            {
                if (arr[x] % 2 == 0)
                {
                    arr[x] = temparr[index];
                }
                else continue;
                index++;
            }
            return arr;
        }
        static void printarr(ref int[] arr)
        {
            Console.Write("array  : ");
            foreach (int a in arr)
                Console.Write(" " + a + " ");
            Console.WriteLine();
            Array.Sort(arr);
        }
        //============================================================================================================================
        static int TaskB()
        {
            int chotaskb, chocreate, choflip;
            Console.WriteLine("1 - Create string ");
            Console.WriteLine("2 - Flip string ");
            Console.WriteLine("3 - Back");
            Console.Write("Enter Your Choose : ");
            do
            {
                success = int.TryParse(Console.ReadLine(), out chotaskb);
                if (!success) Console.WriteLine(" Please try again");
            } while (!success);
            if (chotaskb == 1)
            {
                chocreate = MenuCreateString();
                if (chocreate == 1)
                {
                    str = CreateStringByRandom();
                    Console.WriteLine("Str : " + str);
                }
                else if (chocreate == 2)
                {
                    str = createStringByUser();
                    Console.WriteLine("Str : " + str);
                }
                chotaskb = TaskB();
            }
            if (chotaskb == 2)
            {
                choflip = menuflip();
                if (choflip == 1)
                    flipwordstowords(ref str);
                else
                    fliptochars(ref str);
                chotaskb = TaskB();
            }
            if (chotaskb == 3) menu();
            return 0;
        }
        static int MenuCreateString()
        {
            int chocreate;
            Console.WriteLine("1 - Create By Random");
            Console.WriteLine("2 - Create By user ");
            Console.Write("Enter Your Choose : ");
            do
            {
                success = int.TryParse(Console.ReadLine(), out chocreate);
                if (!success) Console.WriteLine(" Please try again");
            } while (!success);
            return chocreate;
        }
        static string CreateStringByRandom()
        {
            int numofwords;
            Console.WriteLine("Enter numbers of Words you need Create them");
            do
            {
                success = int.TryParse(Console.ReadLine(), out numofwords);
                if (!success) Console.WriteLine(" Please try again");
            } while (!success);
            Random ran = new Random();
            int lenword;
            char letter;
            for (int i = 0; i < numofwords; i++)
            {
                Console.WriteLine("Enter length for word number  : ", i + 1);
                lenword = int.Parse(Console.ReadLine());
                for (int j = 0; j < lenword; j++)
                {
                    numofran = ran.Next(0, 26);
                    letter = Convert.ToChar(numofran + 65);
                    str += letter;
                }
                str += " ";
            }
            count = numofwords;
            return str;
        }
        static string createStringByUser()
        {
            Console.WriteLine("Enter your string ");
            str = Console.ReadLine();
            count = str.Split(' ', ',').Length;
            return str;
        }
        static int menuflip()
        {
            Console.WriteLine("1 - Flip string Words to Words");
            Console.WriteLine("2 - Flip string Words to Characters");
            int choflip;
            do
            {
                success = int.TryParse(Console.ReadLine(), out choflip);
                if (!success) Console.WriteLine(" Please try again");
            } while (!success);
            return choflip;
        }
        static void flipwordstowords(ref string strflip)
        {

            if (string.IsNullOrEmpty(strflip))
            {
                Console.WriteLine("String empty..., please create string ");
                MenuCreateString();
            }
            else
                for (int i = 0; i < count; i++)
                    Console.WriteLine(strflip.Split(' ', ',')[count - (i + 1)] + " ");
        }
        static void fliptochars(ref string strflip)
        {

            if (string.IsNullOrEmpty(strflip))
            {
                Console.WriteLine("Please create string ");
                MenuCreateString();
            }
            else
            {
                char[] arrstr = new char[strflip.Length];
                for (int i = 0; i < strflip.Length; i++)
                    arrstr[i] = strflip[strflip.Length - (i + 1)];
                for (int i = 0; i < arrstr.Length; i++)
                    strflip += arrstr[i] + " ";
                Console.WriteLine("Str after fliping : " + strflip);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("\t\tLab 6");
            menu();
        }
    }
}

