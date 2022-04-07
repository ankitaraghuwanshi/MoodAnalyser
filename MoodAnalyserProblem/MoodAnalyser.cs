using MoodAnalysers;
using System;
namespace MoodAnalyserSpace
{
    public class MoodAnalyser
    {
        public string message;//variable
        public MoodAnalyser()//default constructor
        {

        }
        public MoodAnalyser(string message)//parameterized contructor
        {
            this.message = message;
        }

        public string AnalyseMood()//method for type of mood
        {
            try
            {
                if (message.Equals(string.Empty))
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.EmptyMood, "Mood should not be Empty");
                else if (message.Contains("sad"))
                    return "SAD";
                else
                    return "HAPPY";
            }
            catch (NullReferenceException)
            {
                //throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NullMood, "Mood should not be Null");
                return "HAPPY";
            }
        }

    }
}
