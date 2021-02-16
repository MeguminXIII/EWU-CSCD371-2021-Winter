using System;
using System.Collections.Generic;
using System.Text;

namespace GenericStuff.Tests
{
    class SampleCanDoDescription : IDescription
    {
        public string Description => typeof(SampleCanDoDescription).ToString();
    }
}
