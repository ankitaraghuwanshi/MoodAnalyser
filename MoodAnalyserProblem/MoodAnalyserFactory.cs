using MoodAnalyserSpace;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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

        //UC5
        public static object CreateMoodAnalyserParameterisedConstructor(string className, string constructorName, string message)
        {
            Type type = typeof(MoodAnalyser);
            try
            {
                if (type.FullName.Equals(className) || type.Name.Equals(className))
                {
                    if (type.Name.Equals(constructorName))
                    {
                        ConstructorInfo paraconstructor = type.GetConstructor(new[] { typeof(string) });
                        object obj = paraconstructor.Invoke(new[] { message });
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
            catch(Exception ex)
            {
                return ex;
            }


        }

        // UC6
        public static string InvokeAnalyserMood(string message, string methodName)
        {
            try
            {
                Type type = Type.GetType(" MoodAnalyserSpace.MoodAnalyser");
                object moodAnalyseObject = MoodAnalyserFactory.CreateMoodAnalyserParameterisedConstructor(" MoodAnalyserSpace.MoodAnalyser", "MoodAnalyser", message);

                MethodInfo analyserMoodInfo = type.GetMethod(methodName);
                object mood = analyserMoodInfo.Invoke(moodAnalyseObject, null);
                return mood.ToString();

            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.No_such_Method, "constructor not found");


            }

            //public static string InvokeAnalyseMood(string message, string methodName)
            //{
            //    try
            //    {
            //        Type type = Type.GetType("MoodAnalyzer.AnalyzeMood");
            //        object moodAnalyseObject = MoodAnalyserFactory.CreateMoodAnalyserParameterisedConstructor("MoodAnalyzer.AnalyzeMood", "AnalyzeMood", message);
            //        MethodInfo methodInfo = type.GetMethod(methodName);
            //        object mood = methodInfo.Invoke(moodAnalyseObject, null);
            //        return mood.ToString();
            //    }
            //    catch (NullReferenceException)
            //    {
            //        throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.No_such_Method, "method not found");

            //    }
        }


    }
    
}