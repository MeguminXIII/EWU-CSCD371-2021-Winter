using System;
using System.Collections.Generic;

namespace Assignment4
{
    public class NumSet
    {
        private HashSet<int>? _Set;

        public HashSet<int>? Set { get => _Set; set => _Set = value ?? throw new ArgumentNullException("HashSet's set " + value + " in NumSet is Null"); }

        public NumSet(params int[] array)
        {
            if(array is null)
            {
                throw new ArgumentNullException(array + " is null inside NumSet constructor");
            }
            this.Set = new HashSet<int>(array);
        }

        public int[] ReturnArray()
        {
            if (Set is null)
                throw new ArgumentNullException(Set + " is null in ReturnArray");
            int[] copySet = new int[Set.Count];
            Set.CopyTo(copySet);
            return copySet;
               
        }

        public override bool Equals(Object? obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (obj is not NumSet) return false;
            return this.Set == ((NumSet)obj).Set;
        }

        public override int GetHashCode()
        {
            int num = 7;
            foreach (int i in Set!)
                num += i * 43;
            return num;
        }

        public static bool operator ==(NumSet one, NumSet two)
        {
            if (one is null && two is null) return true;
            if (one is null ^ two is null) return false;
            return one!.Equals(two);
        }

        public static bool operator !=(NumSet one, NumSet two) 
            => !(one == two);

        public override string ToString()
        {
            string res = "{";
            foreach (int i in Set!)
                res += i + ", ";
            res += "}";
            return res;
        }
    }
}
