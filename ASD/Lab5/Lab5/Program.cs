using System;
using System.Dynamic;
using System.IO.MemoryMappedFiles;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Lab5
{
    class Program
    {

        public class TreeNode
        {
            public TreeNode(){
            
            }

            public TreeNode(int value)
            {
                Value = value;
            }
            public TreeNode Left { get; set; }
            public TreeNode Right { get; set; }
            public int Value { get; set; }
        }

        public static TreeNode tree = new TreeNode();//1

        static void create_tree()
        {
            Random random = new Random();
            tree.Value = 1;
            
            tree.Left = new TreeNode(2);//2
            tree.Left.Left = new TreeNode(4);//4
            tree.Left.Left.Left = new TreeNode(7);//7
            tree.Left.Left.Right = new TreeNode(8);//8
            tree.Left.Right = new TreeNode(5);//5
            tree.Left.Right.Right = new TreeNode(9);//9
            tree.Left.Right.Right.Right = new TreeNode(12);//12
            tree.Right = new TreeNode(3);//3
            tree.Right.Left = new TreeNode(6);//6
            tree.Right.Left.Left = new TreeNode(10);//10
            tree.Right.Left.Right = new TreeNode(11);//11
            
            
            /*tree.Value = random.Next(100);
            tree.Left = new TreeNode(random.Next(100));//2
            tree.Left.Left = new TreeNode(random.Next(100));//7
            tree.Left.Left.Left = new TreeNode(random.Next(100));//9
            tree.Left.Left.Right = new TreeNode(random.Next(100));//10
            tree.Left.Right = new TreeNode(random.Next(100));//8
            tree.Left.Right.Right = new TreeNode(random.Next(100));//11
            tree.Left.Right.Right.Right = new TreeNode(random.Next(100));//12
            tree.Right = new TreeNode(random.Next(100));//3
            tree.Right.Left = new TreeNode(random.Next(100));//4
            tree.Right.Left.Left = new TreeNode(random.Next(100));//5
            tree.Right.Left.Right = new TreeNode(random.Next(100));//6*/
        }

        static void pr_obhid(TreeNode node)
        {
            Console.WriteLine(node.Value.ToString());
            if(node.Left != null)
            {
                pr_obhid(node.Left);
            }
            if(node.Right != null)
            {
                pr_obhid(node.Right);
            }
        }
        
        static void zv_obhid(TreeNode node)
        {
            if (node.Left != null)
            {
                zv_obhid(node.Left);
            }
            if (node.Right != null)
            {
                zv_obhid(node.Right);
            }
            Console.WriteLine(node.Value.ToString());
        }

        static void symm_obhid(TreeNode node)
        {
            if (node.Left != null)
            {
                symm_obhid(node.Left);
            }
            Console.WriteLine(node.Value.ToString());
            if (node.Right != null)
            {
                symm_obhid(node.Right);
            }
        }
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            create_tree();
            Console.WriteLine("Прямий Обхід");
            pr_obhid(tree);
            Console.WriteLine("\nЗворотний Обхід");
            zv_obhid(tree);
            Console.WriteLine("\nСиметричний Обхід");
            symm_obhid(tree);
        }



        //static Node 
    }
}

/*string pattern = @"^\w+[\w\.]*\w+[@]+\w*[.]+\w";
            string email = Console.ReadLine();
            if(Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase))
            {
                Console.WriteLine("Email is fine!");
            }
            else
            {
                Console.WriteLine("Email is wrong!");
            }*/