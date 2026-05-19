using System.Text.Json;

public static class SetsAndMaps
{
    public static string[] FindPairs(string[] words)
    {
        var seen = new HashSet<string>();
        var pairs = new List<string>();

        foreach (var word in words)
        {
            if (word[0] == word[1])
                continue;

            string reverse = $"{word[1]}{word[0]}";

            if (seen.Contains(reverse))
            {
                pairs.Add($"{word} & {reverse}");
            }

            seen.Add(word);
        }

        return pairs.ToArray();
    }

    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");

            string degree = fields[3].Trim();

            if (degrees.ContainsKey(degree))
            {
                degrees[degree]++;
            }
            else
            {
                degrees[degree] = 1;
            }
        }

        return degrees;
    }

    public static bool IsAnagram(string word1, string word2)
    {
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        if (word1.Length != word2.Length)
            return false;

        var letters = new Dictionary<char, int>();

        foreach (char c in word1)
        {
            if (letters.ContainsKey(c))
                letters[c]++;
            else
                letters[c] = 1;
        }

        foreach (char c in word2)
        {
            if (!letters.ContainsKey(c))
                return false;

            letters[c]--;

            if (letters[c] < 0)
                return false;
        }

        return true;
    }

    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);

        var json = reader.ReadToEnd();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var featureCollection =
            JsonSerializer.Deserialize<FeatureCollection>(json, options);

        var results = new List<string>();

        foreach (var earthquake in featureCollection.Features)
        {
            results.Add(
                $"{earthquake.Properties.Place} - Mag {earthquake.Properties.Mag}"
            );
        }

        return results.ToArray();
    }
}
