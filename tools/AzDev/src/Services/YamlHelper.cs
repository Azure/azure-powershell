// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

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