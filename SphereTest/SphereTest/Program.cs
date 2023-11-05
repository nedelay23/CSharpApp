using System;
using SphereTest;
using System.Threading;

namespace myApp
{

    class Program
    {

        static void Main(string[] args)
        {
            List<Thread> threads = new List<Thread>();

            for (int i = 0; i < 15; i++)
            {
                threads.Add(new Thread(() => generatePrism(5000)));
            }


            foreach (Thread th in threads)
            {
                th.Start();
            }

            Thread consoleTh = new Thread(() =>
            {

                while (true)

                {
                    if (threads.Count == 0)
                    {
                        break;
                    }
                    Thread.Sleep(1000);

                    Console.WriteLine(Tetrahedron.setOfTetrahedron.Count);

                }

            }

               );
            consoleTh.Start();



            foreach (Thread th in threads)
            {
                th.Join();
            }


            Console.WriteLine("Количество тетраэдров  " + Tetrahedron.setOfTetrahedron.Count);
            threads.Clear();

        }

        public static void generatePrism(int number)
        {

            for (int i = 0; i < number; i++)
            {
                Tetrahedron prism = new(0.00001, 0.001);

                        lock (Tetrahedron.setOfTetrahedron)
                        {
                            if (!CheckIntersectionService.IsIntersection(prism))
                            {
                                Tetrahedron.AddPrismToSortedSet(prism);
                            }
                        }

            }
        }
    }
}
