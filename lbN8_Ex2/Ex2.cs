using System.Text;
using System.Text.Json;
using System;
using System.IO;
using System.Text.Encodings;
using System.Text.Encodings.Web;



namespace lbN8_Ex2
{
    class Ex2
    {

        static void Main(string[] args)
        {
            string path = @"C:\Users\JOKlup.DESKTOP-NDKP1MJ\source\repos\lbN8\lbN8_Ex2\Table.csv";
            //string path = "Table.csv";
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding encoding = Encoding.GetEncoding(1251);
            var lines = File.ReadAllLines(path);
            Console.WriteLine(lines);
            var Kompanys = new Kompany[lines.Length - 1];

            for (int i = 1; i < lines.Length; i++)
            {
                var splits = lines[i].Split(';');
                var kompany = new Kompany();
                kompany.должность = splits[0];
                kompany.заработнаяплата = Convert.ToDouble(splits[1]);
                kompany.количествочеловек = Convert.ToDouble(splits[2]);
                Kompanys[i - 1] = kompany;
                //Console.WriteLine(kompany);
            }
            var result = "result.csv";
            using (StreamWriter streamWriter = new StreamWriter(result, false, encoding))
            {
                streamWriter.WriteLine($"Должность; Количествочеловек; Заработная плата; Всего");
                for (int i = 0; i < Kompanys.Length; i++)
                {
                    streamWriter.WriteLine(Kompanys[i].ToExcel());
                }
            }

            var jsonOptions = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Default
            };

            var json = JsonSerializer.Serialize(Kompanys, jsonOptions);
            File.WriteAllText("result.json", json);

            var stringJson = File.ReadAllText("result.json");
            var array = JsonSerializer.Deserialize<Kompany[]>(stringJson);
            foreach (var item in array)
            {
                Console.WriteLine(item.ToString());
            }

            string jsonNewtonsoft = Newtonsoft.Json.JsonConvert.SerializeObject(Kompanys, Newtonsoft.Json.Formatting.Indented);

            //Console.WriteLine(jsonNewtonsoft);
            File.WriteAllText("NewtonsoftResult.json", jsonNewtonsoft);

            //var readFile = File.ReadAllText("NewtonsoftResult.json");

        }
    }
}

