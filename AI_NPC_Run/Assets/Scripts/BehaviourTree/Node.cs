using System.Collections.Generic;

namespace QRun.BehaviorTree
{
    public enum NodeState
    {
        Running,
        Success,
        Failure
    }

    public class Node 
    {
        protected NodeState state;

        public Node parent;

        //protected Node child = new Node();
        protected List<Node> children = new List<Node>();
        private Dictionary<string, object> _dataContext = new Dictionary<string, object>();


        public Node() 
        {
            parent = null;
        }

        public Node(List<Node> children)
        {
            foreach(Node child in children)
            {
                Attach(child);
            }
        }

        public Node(Node child)
        {
            Attach(child);
        }

        private void Attach(Node child)
        {
            parent = this;
            children.Add(child);
        }

        public virtual NodeState Evaluate() => NodeState.Failure;

        public void SetData(string key, object value)
        {
            _dataContext[key] = value;
        }

        public object GetData(string key)
        {
            object value = null;
            if(_dataContext.TryGetValue(key, out value))
            {
                return value;
            }

            Node node = parent;
            if(node != null)
            {
                value= node.GetData(key);
            }
            return value;
        }

        public bool ClearData(string key)
        {
            bool cleared = false;
            if(_dataContext.ContainsKey(key))
            {
                _dataContext.Remove(key);
                return true;
            }

            Node node = parent;
            if(node != null)
            {
                cleared = node.ClearData(key);
            }

            return cleared;
        }
    }
}

