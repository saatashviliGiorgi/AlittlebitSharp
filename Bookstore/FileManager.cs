using System.IO;


namespace Bookstore
{
    public class FileManager
    {
        public static void WriteFile(string path, string content)
        {
            using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                using (var sw = new StreamWriter(fs))
                {
                    sw.WriteLine(content);
                }
            }
        }
        public static string ReadFile(string path)
        {
            using(var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using(var sr = new StreamReader(path))
                {
                    return sr.ReadToEnd();
                }
            }
        }
    }

}
