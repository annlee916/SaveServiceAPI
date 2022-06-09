namespace ServiceAPI
{
    public class SaveService
    {
        public static async Task SaveToFileAsync(string FileName, string saveContent)
        {
            await File.WriteAllTextAsync (FileName, saveContent);
        }

    }
}
