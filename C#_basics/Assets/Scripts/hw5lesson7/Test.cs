using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hw5Lesson7
{
    public class Test : MonoBehaviour
    {
        private void Start()
        {
            string str = "Реализовать метод расширения для поиска количество символов в строке.";
            Debug.Log(str.CountChar());
            Task3a();
            Task3b();
            Task4a();
        }

        static void Task3a()
        {
            //Дана коллекция List<T>. Требуется подсчитать, сколько раз каждый элемент встречается в данной коллекции:
            //а.для целых чисел

            List<int> list = new List<int>() { 2, 4, 6, 6, 4, 6 };
            
            for (int i = 0; i < list.Count(); i++)
            {
                int index = 1;

                for (int j = 0; j < list.Count(); j++)
                {
                    if (list[i].Equals(list[j]))
                    {
                        if (j == i)
                        {
                            continue;
                        }
                        else
                        {
                            index++;
                        }

                        list.RemoveAt(j);
                        j = 0;
                    }
                }
                Debug.Log($"Элемент {list[i]} встречается {index} раз(а).");
            }            

        }

        static void Task3b()
        {
            //b. *для обобщенной коллекции;

            List<ExampleListClass> list2 = new List<ExampleListClass>();

            list2.Add(new ExampleListClass() { exName = "ex4", exId = 4 });
            list2.Add(new ExampleListClass() { exName = "ex2", exId = 2 });
            list2.Add(new ExampleListClass() { exName = "ex3", exId = 3 });
            list2.Add(new ExampleListClass() { exName = "ex1", exId = 1 });
            list2.Add(new ExampleListClass() { exName = "ex2", exId = 2 });
            list2.Add(new ExampleListClass() { exName = "ex3", exId = 3 });

            foreach (ExampleListClass el in list2)
            {                
                Debug.Log(el);
            }            

            list2.Sort(); 
            
            for (int i = 0; i < list2.Count(); i++)
            {
                int index = 1;

                for (int j = 0; j < list2.Count(); j++)
                {
                    if (list2[i].Equals(list2[j]))
                    {
                        if (j == i)
                        {
                            continue;
                        }
                        else
                        {
                            index++;
                        }

                        list2.RemoveAt(j);
                        j = 0;
                    }
                }
                Debug.Log($"Элемент {list2[i]} встречается {index} раз(а).");
            }
        }     
        
        static void Task4a()
        {
            /*
             * 4. В методичке дан фрагмент программы, необходимо:
               а. Свернуть обращение к OrderBy с использованием лямбда-выражения =>.

             Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"four",4 },            
                {"two",2 },
                { "one",1 },
                {"three",3 },
            };
            var d = dict.OrderBy(delegate(KeyValuePair<string,int> pair) { return pair.Value; });
            foreach (var pair in d)
            {
                Debug.Log($"{pair.Key} - {pair.Value}");
            }
             */

            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                { "four",4 },
                { "two",2 },
                { "one",1 },
                { "three",3 },
            };

            var a = dict.OrderBy(x => x.Value);
            foreach (var pair in a)
            {
                Debug.Log($"{pair.Key} - {pair.Value}");
            }

        }

    }
}    
