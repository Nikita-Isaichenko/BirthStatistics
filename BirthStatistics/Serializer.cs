using System.Text.Json;
using System.IO;
using System.Threading.Tasks;

namespace BirthStatistics
{
    static class Serializer
    {
        public static void SaveToFile(string nameFile, object obj, string path)
        {
            using (StreamWriter sw = new StreamWriter(path + nameFile))
            {
                sw.Write(JsonSerializer.Serialize(obj));
            }
        }

        public static double[] LoadFromFile(string nameFile)
        {
            using (StreamReader sr = new StreamReader(@"..\..\DataSet\" + nameFile))
            {
                return JsonSerializer.Deserialize<double[]>(sr.ReadToEnd());
            }
        }
    }
}
