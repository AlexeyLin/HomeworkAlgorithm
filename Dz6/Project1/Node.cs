using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    public class Node
    {
		public int Value { get; set; }

		public bool Visited { get; set; }

		public List<Node> Nodes { get; set; }

		public Node()
		{
			Visited = false;
		}
	}
}
