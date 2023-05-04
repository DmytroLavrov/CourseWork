using Newtonsoft.Json;
using System;
using System.IO;

namespace iYolo
{
    public class SphereJsonService
    {
        private static readonly string _path = Path.Combine(Environment.CurrentDirectory, "spheres.json");

        public static SphereInputDTO[] Load()
        {
            if (!File.Exists(_path))
            {
                throw new FileNotFoundException();
            }

            using (var reader = new StreamReader(_path))
            {
                var jsonContent = reader.ReadToEnd();
                var spheres = JsonConvert.DeserializeObject<SphereInputDTO[]>(jsonContent);

                if (spheres == null)
                {
                    throw new FileLoadException();
                }

                return spheres;
            }
        }

        public static void Save(SphereInputDTO[] dtos)
        {
            if (!File.Exists(_path))
            {
                throw new FileNotFoundException();
            }

            using (var writer = new StreamWriter(_path))
            {
                var jsonContent = JsonConvert.SerializeObject(dtos);

                writer.Write(jsonContent);
            };
        }
    }
}