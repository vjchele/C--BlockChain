using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Web.Script.Serialization;
using System.IO;


namespace BlockChainDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            SHA256 mySHA256 = SHA256Managed.Create();

            List<Block> blockChain = new List<Block>();
            Console.WriteLine("Welcome to BlockChain Demo");
            Console.WriteLine("-------------------------------------");

            Console.WriteLine("Do you want to create a new BlockChain? [Y/N]");
            if (Console.ReadLine().ToUpper() == "Y" )
            {
                Block genesisBlock = new Block("genesis data", "root".GetHashCode());

                genesisBlock.AddBlockHash();

                blockChain.Add(genesisBlock);
            }

            Console.WriteLine("Intial Block Created");

            while(true)
            {
                Console.WriteLine("Do you want to create a new Block? [Y/N]");
                if (Console.ReadLine().ToUpper() != "Y")
                    break;
                Console.WriteLine("Please Enter the transaction data");
                Block blk = new Block(Console.ReadLine(), blockChain[blockChain.Count - 1].GetCurrentBlockHash());
                blk.AddBlockHash();
                blockChain.Add(blk);
            }

         
                   

            string json = new JavaScriptSerializer().Serialize(blockChain);

            Console.WriteLine("Here is the BlockChain");
            Console.WriteLine(json);
            using (StreamWriter file = File.CreateText("BlockChain.txt"))
            {
                file.Write(json);
            }
             //   System.IO.File.WriteAllText(@"blockchain.txt", json);


            Console.Read();
        }
    }
}
