using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chernyak_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выполнила Черняк Оксана Александровна, АЭМ-111");
            string[] oneNExceptions = {"стекл", "олов", "дерев", "стар"}; //исключения стеклянный, оловянный, деревянный, старинный
            string[] twoNExceptions = {"ветр", "жар", "вял"}; // исключения ветреный, жареный, вяленый

            string debug = "стеклян*ый оловян*ый деревян*ый жарен*ый парен*ый старин*ый";

            Console.WriteLine("Введите строку для анализа, либо 'debug': ");
            string text = Console.ReadLine();
            if (text == "debug")
            {
                text = debug;
                Console.WriteLine("Обработка ввода: \n" + debug);
            }

            string[] tokens = text.Split(' ');
            for (int i = 0; i < tokens.Length; i++)
            {
                string[] pieces = tokens[i].Split('*');
                if (pieces.Length == 1)
                {
                    continue;
                }

                string suffix = pieces[0].Substring(pieces[0].Length - 2, 2);
                string root = pieces[0].Substring(0, pieces[0].Length - 2);
                if (suffix == "ен" || suffix == "он")
                {
                    int index = -1;
                    for (int j = 0; j < twoNExceptions.Length; j++)
                    {
                        if (root == twoNExceptions[j])
                        {
                            index = j;
                            break;
                        }
                    }

                    if (index == -1)
                    {
                        tokens[i] = root + suffix + "н" + pieces[1];
                    }
                    else
                    {
                        //исключение
                        tokens[i] = root + suffix + pieces[1];
                    }
                }
                else if (suffix == "ан" || suffix == "ян" || suffix == "ин")
                {
                    int index = -1;
                    for (int j = 0; j < oneNExceptions.Length; j++)
                    {
                        if (root == oneNExceptions[j])
                        {
                            index = j;
                            break;
                        }
                    }

                    if (index == -1)
                    {
                        tokens[i] = root + suffix + pieces[1];
                    }
                    else
                    {
                        // исключение
                        tokens[i] = root + suffix + "н" + pieces[1];
                    }
                }
            }

            for (int i = 0; i < tokens.Length; i++)
            {
                Console.Write(tokens[i] + " ");
            }

            Console.WriteLine();

            Console.ReadKey();
        }
    }
}