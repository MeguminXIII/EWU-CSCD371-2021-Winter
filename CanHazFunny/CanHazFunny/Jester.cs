using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny
{
    public class Jester
    {
        private IJokeOutput jokeOutput;
        private IJokeService jokeService;

        public IJokeOutput JokeOutput { 
            get => jokeOutput; 
            private set => jokeOutput = value ?? throw new ArgumentNullException(jokeOutput + "is null");
        }

        public IJokeService JokeService
        {
            get => jokeService;
            private set => jokeService = value ?? throw new ArgumentNullException(jokeService + "is null");
        }

        public Jester(IJokeOutput jokeOutput, IJokeService jokeService)
        {
            if(jokeOutput == null || jokeService == null)
            {
                throw new ArgumentNullException(jokeOutput + " or " + jokeService + " is null");
            }
            else
            {
                this.JokeOutput = jokeOutput;
                this.JokeService = jokeService;
            }
        }

        public void TellJoke()
        {
            string joke = this.JokeService.GetJoke();
            while(joke.Contains("Chuck") 
                || joke.Contains("Norris") 
                || joke.Contains("chuck")
                || joke.Contains("norris"))
            {
                joke = this.JokeService.GetJoke();
            }
            this.JokeOutput.PrintJoke(joke);
        }

    }
}
