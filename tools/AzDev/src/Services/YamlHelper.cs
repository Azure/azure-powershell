using System;
using YamlDotNet.Serialization;

internal static class YamlHelper
{
    private static IDeserializer Deserializer => _lazyDeserializer.Value;
    private static Lazy<IDeserializer> _lazyDeserializer = new Lazy<IDeserializer>(BuildDeserializer);

    private static IDeserializer BuildDeserializer()
    {
        return new DeserializerBuilder()
            .IgnoreUnmatchedProperties()
            .Build();
    }

    public static T Deserialize<T>(string yaml)
    {
        return Deserializer.Deserialize<T>(yaml);
    }

    public static string Serialize<T>(T obj)
    {
        throw new NotImplementedException();
    }
}