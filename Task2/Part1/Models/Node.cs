namespace Part1.Models
{
    public class Node<T>
    {
        public int Key { get; set; }
        public T Data { get; set; }
        public Node<T> Left { get; set; }
        public  Node<T> Right { get; set; }

        public Node(T _data)
        {
            this.Data = _data;
        }
        public Node(T _data, int _key) : this(_data)
        {
            this.Key = _key;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
