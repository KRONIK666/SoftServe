using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowestCommonAncestor
{
    public class Ancestor
    {
        private Tree<string> firstNode;
        private Tree<string> secondNode;
        private Tree<string> commonAncestor;

        public Tree<string> FirstNode
        {
            get { return firstNode; }
            set { firstNode = value; }
        }

        public Tree<string> SecondNode
        {
            get { return secondNode; }
            set { secondNode = value; }
        }

        public Tree<string> CommonAncestor
        {
            get { return commonAncestor; }
            set { commonAncestor = value; }
        }

        public Ancestor(Tree<string> firstNode, Tree<string> secondNode, Tree<string> commonAncestor)
        {
            this.firstNode = firstNode;
            this.secondNode = secondNode;
            this.commonAncestor = commonAncestor;
        }

        public Tree<string> FindLowestCommonAncestor(Tree<string> firstNode, Tree<string> secondNode, Tree<string> commonAncestor)
        {
            firstNode = this.firstNode;
            secondNode = this.secondNode;

            if (firstNode == secondNode)
            {
                return firstNode;
            }
            else
            {
                return null;
            }
        }
    }
}