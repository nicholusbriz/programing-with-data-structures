public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary

    // The top level has a "features" array
    public Feature[] Features { get; set; }
}

public class Feature
{
    // Each feature has a "properties" object
    public Properties Properties { get; set; }
}

public class Properties
{
    // Magnitude can be null in the JSON, so use double?
    public double? Mag { get; set; }

    // Place is a string like "1km NE of Pahala, Hawaii"
    public string Place { get; set; }
}