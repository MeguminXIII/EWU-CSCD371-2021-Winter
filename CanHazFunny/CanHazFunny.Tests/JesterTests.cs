using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JesterTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Jester_AssignNullJokeService_ThrowsNullError()
        {
            Jester jester = new Jester(new JokeOutput(), null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Jester_AssignNullJokeOutput_ThrowsNullError()
        {
            Jester jester = new Jester(null, new JokeService());
        }

        [TestMethod]
        public void Jester_ValidJesterService()
        {
            IJokeService jokeService = new JokeService();

            Jester jester = new Jester(new JokeOutput(), jokeService);

            Assert.AreEqual(jokeService, jester.JokeService);
        }

        [TestMethod]
        public void Jester_ValidJesterOutput()
        {
            IJokeOutput jokeOutput = new JokeOutput();

            Jester jester = new Jester(jokeOutput, new JokeService());

            Assert.AreEqual(jokeOutput, jester.JokeOutput);
        }

        [TestMethod]
        public void TellJoke_RetryingUntilNoChuckNorrisJokes()
        {
            Mock<IJokeService> mock = new Mock<IJokeService>();
            mock.SetupSequence(JokeService => JokeService.GetJoke())
                .Returns("Chuck Norris Joke")
                .Returns("chuck norris joke")
                .Returns("Knock Knock Joke")
                .Returns("knock knock joke");
            Jester jester = new Jester(new JokeOutput(), mock.Object);
            jester.TellJoke();
            mock.Verify(JokeService => JokeService.GetJoke(), Times.Exactly(3));
        }

        [TestMethod]
        public void PrintJoke_JokeOutputIsSentToConsole()
        {
            Mock<IJokeService> mockService = new Mock<IJokeService>();
            mockService.SetupSequence(JokeService => JokeService.GetJoke())
                .Returns("Knock Knock Joke");

            Mock<IJokeOutput> mockOutput = new Mock<IJokeOutput>();
            mockOutput.SetupSequence(JokeOutput => JokeOutput.PrintJoke("Knock Knock Joke"));
            Jester jester = new Jester(mockOutput.Object, mockService.Object);

            jester.TellJoke();
            mockOutput.VerifyAll();
        }

        [TestMethod]
        public void Jester_CheckNotNull()
        {
            Jester jester = new Jester(new JokeOutput(), new JokeService());

            Assert.IsNotNull(jester.JokeService);
            Assert.IsNotNull(jester.JokeOutput);
        }
    }
}
