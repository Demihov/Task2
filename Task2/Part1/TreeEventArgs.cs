using System;

namespace Part1
{
    public class TreeEventArgs : EventArgs
    {
        public string Message { get; }

        public TreeEventArgs(string mes)
        {
            Message = mes;
        }
    }
}
