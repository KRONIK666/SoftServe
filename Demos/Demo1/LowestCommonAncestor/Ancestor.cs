using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowestCommonAncestor
{
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
    }
}