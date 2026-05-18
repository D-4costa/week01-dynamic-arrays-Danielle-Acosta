public class FeatureCollection
{
    public List<FeatureData> Features { get; set; }
}

public class FeatureData
{
    public EarthquakeInfo Properties { get; set; }
}

public class EarthquakeInfo
{
    public string Place { get; set; }
    public double? Mag { get; set; }
}
