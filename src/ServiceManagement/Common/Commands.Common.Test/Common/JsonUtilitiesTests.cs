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
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit.Abstractions;
using Microsoft.WindowsAzure.ServiceManagemenet.Common.Models;

namespace Microsoft.WindowsAzure.Commands.Common.Test.Common
{
    public class JsonUtilitiesTests
    {
        public JsonUtilitiesTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PatchWorksWithStandardStructures()
        {
            var originalProperties = new Dictionary<string, object>
                {
                    {"name", "site1"},
                    {"siteMode", "Standard"},
                    {"computeMode", "Dedicated"},
                    {"list", new [] {1,2,3}},
                    {"misc", new Dictionary<string, object>
                        {
                            {"key1", "value1"},
                            {"key2", "value2"}
                        }}};

            var originalPropertiesSerialized = JsonConvert.SerializeObject(originalProperties, new JsonSerializerSettings
            {
                TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple,
                TypeNameHandling = TypeNameHandling.None
            });

            var patchProperties = new Dictionary<string, object>
                {
                    {"siteMode", "Dedicated"},
                    {"newMode", "NewValue"},
                    {"list", new [] {4,5,6}},
                    {"misc", new Dictionary<string, object>
                        {
                            {"key3", "value3"}
                        }}};

            var patchPropertiesSerialized = JsonConvert.SerializeObject(patchProperties, new JsonSerializerSettings
            {
                TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple,
                TypeNameHandling = TypeNameHandling.None
            });

            JToken actualJson = JToken.Parse(JsonUtilities.Patch(originalPropertiesSerialized, patchPropertiesSerialized));

            Assert.Equal("site1", actualJson["name"].ToObject<string>());
            Assert.Equal("Dedicated", actualJson["siteMode"].ToObject<string>());
            Assert.Equal("Dedicated", actualJson["computeMode"].ToObject<string>());
            Assert.Equal("NewValue", actualJson["newMode"].ToObject<string>());
            Assert.Equal("[4,5,6]", actualJson["list"].ToString(Formatting.None));
            Assert.Equal("value1", actualJson["misc"]["key1"].ToObject<string>());
            Assert.Equal("value2", actualJson["misc"]["key2"].ToObject<string>());
            Assert.Equal("value3", actualJson["misc"]["key3"].ToObject<string>());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PatchWorksWithListInRoot()
        {
            var originalProperties = new[] {1, 2, 3};

            var originalPropertiesSerialized = JsonConvert.SerializeObject(originalProperties, new JsonSerializerSettings
            {
                TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple,
                TypeNameHandling = TypeNameHandling.None
            });

            var patchProperties = new[] {4, 5, 6};

            var patchPropertiesSerialized = JsonConvert.SerializeObject(patchProperties, new JsonSerializerSettings
            {
                TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple,
                TypeNameHandling = TypeNameHandling.None
            });

            var actual = JsonUtilities.Patch(originalPropertiesSerialized, patchPropertiesSerialized);

            Assert.Equal("[4,5,6]", actual);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PatchWorksWithValueInRoot()
        {
            var originalProperties = "foo";

            var originalPropertiesSerialized = JsonConvert.SerializeObject(originalProperties, new JsonSerializerSettings
            {
                TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple,
                TypeNameHandling = TypeNameHandling.None
            });

            var patchProperties = "bar";

            var patchPropertiesSerialized = JsonConvert.SerializeObject(patchProperties, new JsonSerializerSettings
            {
                TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple,
                TypeNameHandling = TypeNameHandling.None
            });

            var actual = JsonUtilities.Patch(originalPropertiesSerialized, patchPropertiesSerialized);

            Assert.Equal("\"bar\"", actual);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PatchWorksWithMismatchInRoot()
        {
            var originalProperties = new Dictionary<string, object>
                {
                    {"name", "site1"},
                    {"siteMode", "Standard"},
                    {"computeMode", "Dedicated"},
                    {"list", new [] {1,2,3}},
                    {"misc", new Dictionary<string, object>
                        {
                            {"key1", "value1"},
                            {"key2", "value2"}
                        }}};

            var originalPropertiesSerialized = JsonConvert.SerializeObject(originalProperties, new JsonSerializerSettings
            {
                TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple,
                TypeNameHandling = TypeNameHandling.None
            });

            var patchProperties = "bar";

            var patchPropertiesSerialized = JsonConvert.SerializeObject(patchProperties, new JsonSerializerSettings
            {
                TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple,
                TypeNameHandling = TypeNameHandling.None
            });

            Assert.Throws<ArgumentException>(() => JsonUtilities.Patch(originalPropertiesSerialized, patchPropertiesSerialized));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PatchWorksWithMismatchInBody()
        {
            var originalProperties = new Dictionary<string, object>
                {
                    {"name", "site1"},
                    {"siteMode", "Standard"},
                    {"computeMode", "Dedicated"},
                    {"list", new [] {1,2,3}},
                    {"misc", new Dictionary<string, object>
                        {
                            {"key1", "value1"},
                            {"key2", "value2"}
                        }}};

            var originalPropertiesSerialized = JsonConvert.SerializeObject(originalProperties, new JsonSerializerSettings
            {
                TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple,
                TypeNameHandling = TypeNameHandling.None
            });

            var patchProperties = new Dictionary<string, object>
                {
                    {"siteMode", "Dedicated"},
                    {"list", "foo"},
                    {"misc", new Dictionary<string, object>
                        {
                            {"key3", "value3"}
                        }}};

            var patchPropertiesSerialized = JsonConvert.SerializeObject(patchProperties, new JsonSerializerSettings
            {
                TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple,
                TypeNameHandling = TypeNameHandling.None
            });

             Assert.Throws<ArgumentException>(() => JToken.Parse(JsonUtilities.Patch(originalPropertiesSerialized, patchPropertiesSerialized)));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PatchWorksWithEmptyPatchValue()
        {
            var originalProperties = new Dictionary<string, object>
                {
                    {"name", "site1"},
                    {"siteMode", "Standard"},
                    {"computeMode", "Dedicated"},
                    {"list", new [] {1,2,3}},
                    {"misc", new Dictionary<string, object>
                        {
                            {"key1", "value1"},
                            {"key2", "value2"}
                        }}};

            var originalPropertiesSerialized = JsonConvert.SerializeObject(originalProperties, new JsonSerializerSettings
            {
                TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple,
                TypeNameHandling = TypeNameHandling.None
            });

            var actual = JsonUtilities.Patch(originalPropertiesSerialized, "");

            Assert.Equal(originalPropertiesSerialized, actual);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PatchWorksWithNullPatchValue()
        {
            var originalProperties = new Dictionary<string, object>
                {
                    {"name", "site1"},
                    {"siteMode", "Standard"},
                    {"computeMode", "Dedicated"},
                    {"list", new [] {1,2,3}},
                    {"misc", new Dictionary<string, object>
                        {
                            {"key1", "value1"},
                            {"key2", "value2"}
                        }}};

            var originalPropertiesSerialized = JsonConvert.SerializeObject(originalProperties, new JsonSerializerSettings
            {
                TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple,
                TypeNameHandling = TypeNameHandling.None
            });

            var actual = JsonUtilities.Patch(originalPropertiesSerialized, null);

            Assert.Equal(originalPropertiesSerialized, actual);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PatchWorksWithEmptySourceValue()
        {
            var patchProperties = new Dictionary<string, object>
                {
                    {"siteMode", "Dedicated"},
                    {"newMode", "NewValue"},
                    {"list", new [] {4,5,6}},
                    {"misc", new Dictionary<string, object>
                        {
                            {"key3", "value3"}
                        }}};

            var patchPropertiesSerialized = JsonConvert.SerializeObject(patchProperties, new JsonSerializerSettings
            {
                TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple,
                TypeNameHandling = TypeNameHandling.None
            });

            var actual = JsonUtilities.Patch("", patchPropertiesSerialized);

            Assert.Equal(patchPropertiesSerialized, actual);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PatchWorksWithNullSourceValue()
        {
            var patchProperties = new Dictionary<string, object>
                {
                    {"siteMode", "Dedicated"},
                    {"newMode", "NewValue"},
                    {"list", new [] {4,5,6}},
                    {"misc", new Dictionary<string, object>
                        {
                            {"key3", "value3"}
                        }}};

            var patchPropertiesSerialized = JsonConvert.SerializeObject(patchProperties, new JsonSerializerSettings
            {
                TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple,
                TypeNameHandling = TypeNameHandling.None
            });

            var actual = JsonUtilities.Patch("", patchPropertiesSerialized);

            Assert.Equal(patchPropertiesSerialized, actual);
        }
    }
}
