using UnityEngine;

public class Example
{
    public int Test;
}

namespace Geekbrains
{
    public class Example
    {
        public string Test;
    }
    
    namespace MyNamespace.Geekbrains
    {
        public class Example
        {
            public float Test;
        }
    }
    
    public class Test : MonoBehaviour
    {
        private void Start()
        { 
            Geekbrains.MyNamespace.Geekbrains.Example example1 = new MyNamespace.Geekbrains.Example();
            
            Geekbrains.Example example2 = new Example();
            
            global::Example example3 = new global::Example();
        }
    }
}
