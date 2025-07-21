using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary
    // We are only interested in the features property in the JSON
    // so we can ignore the other properties for this problem.
    public List<Feature> Features { get; set; } = new();
}

public class Feature
{
    public FeatureProperties Properties { get; set; } = new();
}

public class FeatureProperties
{
    public decimal Mag { get; set; }
    public string Place { get; set; } = "";
}
