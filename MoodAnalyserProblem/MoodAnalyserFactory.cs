using MoodAnalyserSpace;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace MoodAnalysers
{
    public class MoodAnalyserFactory
    {
        public static object CreateMoodAnalyser(string className, string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            Match result = Regex.Match(className, pattern);

            if (result.Success)
            {
                try
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    Type moodAnalyser = assembly.GetType(className);
                    return Activator.CreateInstance(moodAnalyser);
                }
                catch (ArgumentNullException)
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.No_Such_Class, "Class not found");
                }
            }
            else
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.No_Such_Constructor, "Constructor not found");
            }
        }
        public static object CreateMoodAnalyserParameterisedConstructor(string className, string constructorName)
        {
            Type type = typeof(MoodAnalyser);
            if (type.FullName.Equals(className) || type.Name.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ParaConstructor paraconstructor = type.GetConstructor(new[] { typeof(string) });
                    object obj = paraconstructor.Invoke(new[] { "Happy" });
                    return obj;
                }
                else
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.No_Such_Constructor, "Constructor not found");
                }
            }
            else
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.No_Such_Class, "Class not found");
            }
        }
    }
}