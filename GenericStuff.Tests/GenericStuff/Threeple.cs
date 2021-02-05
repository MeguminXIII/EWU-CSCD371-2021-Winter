using System;

namespace GenericStuff
{
    public class Threeple<TFirst, TSecond, TThird>
    {
        public TFirst First { get; }
        public TSecond Second { get; }
        public TThird Third { get; }
        public string Description 
        {
            get
            {
                return $"First: {First.ToString()}; Second: {Second.ToString()}; Third:";
            } 
        }

        public Threeple(TFirst first, TSecond second, TThird third)
        {
            First = first;
            Second = second;
            Third = third;
        }

        public static (TOne, TTwo, TThree) Deconstruct<TOne, TTwo, TThree>(Threeple<TOne, TTwo, TThree> threeple)
        {
            return (threeple.First, threeple.Second, threeple.Third);
        }
    }

    public class ThreepleDescription<TFirst, TSecond, TThird>
        where TFirst : IDescription, new()
    {
        public TFirst First { get; }
        public TSecond Second { get; }
        public TThird Third { get; }
        public string Description
        {
            get
            {
                bool boolean = First == First;
                return $"First: {First.Description}; Second: {Second.ToString()}; Third:";
            }
        }

        public ThreepleDescription(TFirst first, TSecond second, TThird third)
        {
            First = first;
            Second = second;
            Third = third;
        }
    }

    public interface Serializer<T>
    {
        public void Serialize(T thing);

    }

    public interface Deserializer<out T>
    {
        public T Deserialize(int id);
    }
}