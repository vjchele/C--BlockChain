using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainDemo
{
    class Block
    {
        public string data;
        public int blockHash;
        public int previousHash;
        public string timeStamp;
        public Block(string data, int previousHash)
        {
            this.data = data;
            this.previousHash = previousHash;
        }

        public void AddBlockHash()
        {
            

            this.blockHash = (this.data + this.previousHash.ToString()).GetHashCode();
            this.timeStamp = DateTime.UtcNow.ToString();
        }

        public string GetData()
        {
            return this.data;
        }

        public int GetPreviousHash()
        {
            return this.previousHash;
        }

        public int GetCurrentBlockHash()
        {
            return this.blockHash;
        }
    }
}
