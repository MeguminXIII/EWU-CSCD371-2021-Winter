namespace CanHazFunny
{
    class Program
    {
        static void Main()
        {
            Jester jester = new Jester(new JokeOutput(), new JokeService());
            jester.TellJoke();
        }
    }
}
