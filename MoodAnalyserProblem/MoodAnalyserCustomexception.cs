using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalysers
{
    public class MoodAnalyserCustomException : Exception
    {
        ExceptionType type;
        public enum ExceptionType
        {
            EmptyMood,
            NullMood,
            No_Such_Class,
            No_Such_Constructor,
            No_Such_Field,
            No_such_Method,
        }

        public MoodAnalyserCustomException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}