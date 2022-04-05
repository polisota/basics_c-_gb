using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hw5Lesson7
{
    public class ExampleListClass : IEquatable<ExampleListClass>, IComparable<ExampleListClass>
    {
        public string exName { get; set; }

        public int exId { get; set; }
       
        public override string ToString()
        {
            return "ID: " + exId + " Name: " + exName;
        } 

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            ExampleListClass objAsExampleListClass = obj as ExampleListClass;
            if (objAsExampleListClass == null) return false;
            else return Equals(objAsExampleListClass);
        }

        public int SortByNameAscending(string name1, string name2) => name1?.CompareTo(name2) ?? 1;
        
        public int CompareTo(ExampleListClass compareEx) => compareEx == null ? 1 : exId.CompareTo(compareEx.exId);

        public override int GetHashCode()
        {
            return exId;
        }

        public bool Equals(ExampleListClass other)
        {
            if (other == null) return false;
            return (this.exId.Equals(other.exId));
        }
    }
}    
