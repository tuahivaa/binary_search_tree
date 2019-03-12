using System;
using System.IO;

namespace BST
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            try
            {
                //keep repeating to enter only one paramter
                if (args.Length == 1)
                {
                    StreamReader file = new StreamReader(args[0]);
                    int lines = int.Parse( file.ReadLine() );

                    Node T = null;


                    for (int i =0; i<lines; i++)
                    {
                        string readingLine = file.ReadLine();
                        string[] read = readingLine.Split(' ');

                        if ( read[0]  == "ADD")
                        {
                            if (T == null)
                            {
                                //Console.WriteLine(read[1]);
                                T = new Node(int.Parse(read[1]));
                                Console.WriteLine("Adding " + read[1] );
                            }
                            else
                            {
                                treeInsert(T,new Node(int.Parse(read[1])));
                                Console.WriteLine("Adding " + read[1]);
                            }
                        }
                        else if (read[0] == "FIND")
                        {


                            Console.Write("Looking for " + read[1] + "... ");// + treeSearch(T, k: int.Parse(read[1])) ) ;
                            treeSearch(T, k: int.Parse(read[1]));


                        }
                        else if (read[0] == "CLEAR")
                        {
                            T = null;
                        }
                        else if (read[0] == "PRINT")
                        {
                            printDump(T);
                        }
                        else if (read[0] == "PREORDER")
                        {
                            Console.Write("PREORDER: ");
                            preorder(T);
                            Console.WriteLine();
                        }
                        else if (read[0] == "INORDER")
                        {
                            Console.Write("INORDER: ");
                            inorder(T);
                            Console.WriteLine();
                        }
                        else if (read[0] == "POSTORDER")
                        {
                            Console.Write("POSTORDER: ");
                            postorder(T);
                            Console.WriteLine();
                        }
                    }




                }
                else
                {
                    Console.WriteLine("please enter only one parameter.");
                }
                

            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File not found.");



            }
        }

        public static void treeInsert(Node T, Node z)
        {
            Node y = null;
            Node x = T;

            while ( x != null )
            {
                y = x;
                if ( z.key < x.key )
               {
                    x = x.left;
                }
                else
                {
                    x = x.right;
                }



            }
            if (y == null)
            {
                T = z;
            }
            else if (z.key < y.key)
            {
                y.left = z;
            }
            else
            {
                y.right = z;
            }


        }

        public static void preorder( Node n )
        {
            if ( n != null )
            {
                //Console.WriteLine("DATA preorder " + n.key);
                //printTree(n);
                Console.Write(n.key + " ");
                preorder(n.left);
                preorder(n.right);
            }
        }

        public static void inorder(Node n)
        {

            if ( n != null )
            {
                inorder(n.left);
                //Console.WriteLine("DATA inorder " + n.key);
                //printTree(n);
                Console.Write(n.key + " ");
                inorder(n.right);
            }
        }

        public static void postorder( Node n)
        {
            if ( n != null )
            {
                postorder(n.left);
                postorder(n.right);
                //Console.WriteLine("DATA postorder " + n.key);
                //printTree(n);
                Console.Write(n.key + " ");
            }
        }

        public static void clear(Node T)
        {
            T = null;
        }



        public static void treeSearch( Node x, int k )
        {
            if ( x == null)
            {
                Console.WriteLine("NOT FOUND");
            }
            else
            {
                Console.Write(x.key + " ");
                if ( x.key == k )
                {
                    Console.WriteLine("FOUND");
                }else if ( k < x.key )
                {
                    treeSearch(x.left, k);
                }
                else
                {
                    treeSearch( x.right, k );
                }

            }

        }

        public static void printTree(Node n)
        {
            Console.Write("NODE: " + n.key);
            Console.Write(" L: ");
            if ( n.left == null)
            {
                Console.Write("NULL ");
            }
            else
            {
                Console.Write(n.left.key);
            }
            Console.Write(" R: ");
            if (n.right == null)
            {
                Console.Write("NULL ");
            }
            else
            {
                Console.Write(n.right.key);
            }
            Console.WriteLine();
        }

        public static void printDump(Node n)
        {
            if (n != null)
            {
                //Console.WriteLine("DATA preorder " + n.key);
                printTree(n);
                printDump(n.left);
                printDump(n.right);
            }
        }
    }
}
