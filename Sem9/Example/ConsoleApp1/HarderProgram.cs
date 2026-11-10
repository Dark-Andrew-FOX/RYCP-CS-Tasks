using System.Text.Json;

namespace HarderProgram
{
    public static class Program
    {
        public static void Main()
        {
            // Сериализация -------------------------
            Monster monster = new(
                "Bob",
                new Stats(0.1f, 2, 12)
            );

            monster.TakeDamage(3);

            JsonSerializerOptions options = new()
            {
                IncludeFields = true,
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(monster, options);
            Console.WriteLine(json);

            // Десериализация -------------------------
            Monster restored = JsonSerializer.Deserialize<Monster>(json, options)!;

            Console.WriteLine(restored.HP);
            Console.WriteLine(
                ReferenceEquals(monster, restored)
            );

            // Запись файла -------------------------
            Console.WriteLine("\nНажмите для сохранения строки в файл...");
            Console.ReadLine();

            string path = Path.Combine(AppContext.BaseDirectory, "save.json");

            File.WriteAllText(path, json);

            // Чтение файла -------------------------
            Console.WriteLine("\nНажмите для чтения файла...");
            Console.ReadLine();

            string savedJson = File.ReadAllText(path);

            Monster loaded = JsonSerializer.Deserialize<Monster>(
                savedJson, options
            )!;

            Console.WriteLine(loaded.HP);
        }
    }
}