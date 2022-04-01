using MoodAnalyserSpace;
using NUnit.Framework;

namespace MoodAnalyserTesting
{
    public class Tests
    {
        MoodAnlyser moodAnlyser;
        [SetUp]
        public void Setup()
        {
            string result = "";
            //arrange
            moodAnlyser = new MoodAnlyser(result);
        }
        //summary//Refactor
        // TC-1.1 Given "I am in Sad mood" message should return SAD//

        [Test]
        public void Give_Msg_when_ShouldReturnSad()
        {
            moodAnlyser = new MoodAnlyser("I am in a SAD mood");
            //act
            string message = moodAnlyser.Analysemood();

            //assert
            Assert.AreEqual("SAD", message);
        }


        //summary//Refactor
        /// TC-1.2 Given "I am in Any mood" message should return HAPPY//
        [Test]
        public void Give_msg_When_SouldReturnHappy()
        {
            moodAnlyser = new MoodAnlyser("I am in ANY mood");
            //act
            string message = moodAnlyser.Analysemood();
            //assert
            Assert.AreEqual("HAPPY", message);
        }
    }
}