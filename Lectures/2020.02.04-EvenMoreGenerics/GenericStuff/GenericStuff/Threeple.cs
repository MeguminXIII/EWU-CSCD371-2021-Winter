using System;

namespace GenericStuff
{
    public class Threeple<TFirst, TSecond, TThird>
    {
        public TFirst First { get; }
        public TSecond Second { get; }
        public TThird Third { get; }
        public string Description {
            get 
            {
                return $"First: {First.ToString()}; Second: {Second.ToString()}; Third: ;";
            } 
        }

        public Threeple(TFirst first, TSecond second, TThird third)
        {
            First = first;
            Second = second;
            Third = third;
        }
    }

    public class ThreepleDescription<TFirst, TSecond, TThird>
        where TFirst : IDescription
    {
        public TFirst First { get; }
        public TSecond Second { get; }
        public TThird Third { get; }
        public string Description
        {
            get
            {
                return $"First: {First.Description}; Second: {Second.ToString()}; Third: ;";
            }
        }

        public ThreepleDescription(TFirst first, TSecond second, TThird third)
        {
            First = first;
            Second = second;
            Third = third;
        }
    }
}