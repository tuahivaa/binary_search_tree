using System;
namespace BST
{
    public class Node
    {


        public int key;
        public Node left;
        public Node right;
        //public string data = "Node: " + key + "; L: "  + "; R: " ;

        public Node(int n)
        {
            key = n;
            left = null;
            right = null;
        }


    }
}
