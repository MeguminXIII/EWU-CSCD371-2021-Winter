using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericStuff.Tests
{
    [TestClass]
    public class VarianceTests
    {
        public interface IReadOnlySetting<out TValue>
        {
            string Name { get; }
            TValue Value { get; }

            //T GetValue(string name);
        }

        public interface IWriteOnlySetting<in T>
        {
            string Name { set; }
            T Value { set; }

            //void SetValue(string name, T value);
        }

        public class Setting<T> : IReadOnlySetting<T>, IWriteOnlySetting<T>
        {
            public string Name
            {
                get => throw new NotImplementedException();
                set => throw new NotImplementedException();
            }

            public T Value
            {
                get => throw new NotImplementedException();
                set => throw new NotImplementedException();
            }
        }

        interface ICompare<T>
        {
            int Compare(T first, T second);
        }

        public class FileSetting<T> : IReadOnlySetting<T>
        {
            public string Name => "Inigo Montoya";

            public T Value => default;
        }

        [TestMethod]
        public void Covariance()
        {
            Setting<int> intSetting = new();
            Setting<object> objSetting = new();
            IWriteOnlySetting<object> writeOnlySetting = (IWriteOnlySetting<object>)intSetting;
            writeOnlySetting.Value = 42;
            IReadOnlySetting<int> readOnlySetting = (IReadOnlySetting<int>)objSetting;
            int number = readOnlySetting.Value;
        }
    }
}
