using System.IO;
using System.Text.Json;

namespace MonoGameLibrary.Utilities
{
    public static class JSONLiser
    {   
        public static void Save<T>(string path, T obj) {
            string json = JsonSerializer.Serialize(obj);
            File.WriteAllText(path, json);
        }

        public static T Load<T>(string path) {
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}