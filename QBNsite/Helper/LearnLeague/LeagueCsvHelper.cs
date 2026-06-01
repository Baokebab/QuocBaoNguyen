namespace QBNsite.Helper
{
    public class LeagueCsvHelper
    {
        public async static Task<Dictionary<string, List<SpellAttribute>>> LoadCsvAttributes(HttpClient http, string path)
        {
            var result = new Dictionary<string, List<SpellAttribute>>();
            
            var csv = await http.GetStringAsync(path);
            var lines = csv.Split('\n');
            var headers = lines[0].Split(',');

            for (int i = 1; i < lines.Length; i++)
            {
                if (String.IsNullOrEmpty(lines[i]))
                    continue;

                var cols = lines[i].Split(',');
                string spellId = cols[1];
                var attributes = new List<SpellAttribute>();

                for (int c = 4; c < cols.Length; c++)
                {
                    if (Enum.TryParse(headers[c], out SpellAttribute attribute) && !String.IsNullOrEmpty(cols[c]))
                    {
                        attributes.Add(attribute);
                    }
                }
                result[spellId] = attributes;
            }
            return result;
        }
    }
}

