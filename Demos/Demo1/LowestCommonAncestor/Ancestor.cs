using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowestCommonAncestor
{
    // This class contains the algorithm for finding the lowest common ancestor.

    public class Ancestor
    {
        private string firstNode;
        private string secondNode;
        private string commonAncestor;

        public string FirstNode
        {
            get { return firstNode; }
            set { firstNode = value; }
        }

        public string SecondNode
        {
            get { return secondNode; }
            set { secondNode = value; }
        }

        public string CommonAncestor
        {
            get { return commonAncestor; }
            set { commonAncestor = value; }
        }

        public Ancestor(string firstNode, string secondNode, string commonAncestor)
        {
            this.firstNode = firstNode;
            this.secondNode = secondNode;
            this.commonAncestor = commonAncestor;
        }

        // The method where the lowest common ancestor algorithm is realized.

        public string FindLowestCommonAncestor(string firstNode, string secondNode, string commonAncestor)
        {
            firstNode = this.firstNode;
            secondNode = this.secondNode;
            commonAncestor = this.commonAncestor;

            if (firstNode == secondNode)
            {
                commonAncestor = firstNode;
                return commonAncestor;
            }
            else
            {
                return null;
            }
        }
    }
}