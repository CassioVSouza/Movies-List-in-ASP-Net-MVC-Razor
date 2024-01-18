namespace MoviesWebApp.Helper
{
    public class MyLogger : IMyLogger
    {
        public void MessageToLog(string message)
        {
            using(StreamWriter writer = new StreamWriter(GetLogPath())) 
            {
                writer.WriteLine(message);
            }
        }

        private string GetLogPath()
        {
            string directory = "LogErrors";
            string fileName = "Log.txt";
            string filePath = Path.Combine(directory, fileName);
            if(!File.Exists(filePath)) 
            {
                if(!Directory.Exists(directory))                
                {
                    Directory.CreateDirectory(directory);
                }
                File.Create(filePath).Close();
            }
            return filePath;
        }
    }
}
