namespace MoodAnalyserSpace
{
    public class MoodAnlyser
    {
         string message;
        public MoodAnlyser(string message)
        {
            this.message = message;
        }
        public string Analysemood()
        {
            if (message.Contains("SAD"))
                return "SAD";
            else return "HAPPY";
        }
        static void Main(string[] args)
        {

        }
    }
}