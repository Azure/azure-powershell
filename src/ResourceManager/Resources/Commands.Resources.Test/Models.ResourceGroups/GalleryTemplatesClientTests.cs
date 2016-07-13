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

using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkClient;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Security;
using Microsoft.Azure.Commands.ScenarioTest;
using Newtonsoft.Json.Linq;
using Xunit;
using Xunit.Abstractions;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Resources.Test.Models
{
    public class GalleryTemplatesClientTests : RMTestBase
    {
        private ResourceManagerSdkClient resourceManagerSdkClient;

        private Mock<IResourceManagementClient> resourceManagementClientMock;

        private string templateFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\sampleTemplateFile.json");

        private string invalidTemplateFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\invalidTemplateFile.json");

        private string templateParameterFileSchema1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\sampleTemplateParameterFile.json");

        private string templateParameterFileSchema2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\sampleTemplateParameterFileSchema2.json");

        public GalleryTemplatesClientTests(ITestOutputHelper output)
        {
            resourceManagementClientMock = new Mock<IResourceManagementClient>();
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            resourceManagerSdkClient = new ResourceManagerSdkClient(resourceManagementClientMock.Object);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ConstructsDynamicParameter()
        {
            string[] parameters = { "Name", "Location", "Mode" };
            string[] parameterSetNames = { "__AllParameterSets" };
            string key = "computeMode";
            TemplateFileParameterV1 value = new TemplateFileParameterV1()
            {
                AllowedValues = new List<object>() { "Mode1", "Mode2", "Mode3" },
                DefaultValue = "Mode1",
                MaxLength = "5",
                MinLength = "1",
                Type = "string"
            };
            KeyValuePair<string, TemplateFileParameterV1> parameter = new KeyValuePair<string, TemplateFileParameterV1>(key, value);

            RuntimeDefinedParameter dynamicParameter = TemplateUtility.ConstructDynamicParameter(parameters, parameter);

            Assert.Equal("computeMode", dynamicParameter.Name);
            Assert.Equal(value.DefaultValue, dynamicParameter.Value);
            Assert.Equal(typeof(string), dynamicParameter.ParameterType);
            Assert.Equal(2, dynamicParameter.Attributes.Count);

            ParameterAttribute parameterAttribute = (ParameterAttribute)dynamicParameter.Attributes[0];
            Assert.False(parameterAttribute.Mandatory);
            Assert.True(parameterAttribute.ValueFromPipelineByPropertyName);
            Assert.Equal(parameterSetNames[0], parameterAttribute.ParameterSetName);

            ValidateLengthAttribute validateLengthAttribute = (ValidateLengthAttribute)dynamicParameter.Attributes[1];
            Assert.Equal(int.Parse(value.MinLength), validateLengthAttribute.MinLength);
            Assert.Equal(int.Parse(value.MaxLength), validateLengthAttribute.MaxLength);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ResolvesDuplicatedDynamicParameterName()
        {
            string[] parameters = { "Name", "Location", "Mode" };
            string[] parameterSetNames = { "__AllParameterSets" };
            string key = "Name";
            TemplateFileParameterV1 value = new TemplateFileParameterV1()
            {
                AllowedValues = new List<object>() { "Mode1", "Mode2", "Mode3" },
                MaxLength = "5",
                MinLength = "1",
                Type = "bool"
            };
            KeyValuePair<string, TemplateFileParameterV1> parameter = new KeyValuePair<string, TemplateFileParameterV1>(key, value);

            RuntimeDefinedParameter dynamicParameter = TemplateUtility.ConstructDynamicParameter(parameters, parameter);

            Assert.Equal(key + "FromTemplate", dynamicParameter.Name);
            Assert.Equal(value.DefaultValue, dynamicParameter.Value);
            Assert.Equal(typeof(bool), dynamicParameter.ParameterType);
            Assert.Equal(2, dynamicParameter.Attributes.Count);

            ParameterAttribute parameterAttribute = (ParameterAttribute)dynamicParameter.Attributes[0];
            Assert.True(parameterAttribute.Mandatory);
            Assert.True(parameterAttribute.ValueFromPipelineByPropertyName);
            Assert.Equal(parameterSetNames[0], parameterAttribute.ParameterSetName);

            ValidateLengthAttribute validateLengthAttribute = (ValidateLengthAttribute)dynamicParameter.Attributes[1];
            Assert.Equal(int.Parse(value.MinLength), validateLengthAttribute.MinLength);
            Assert.Equal(int.Parse(value.MaxLength), validateLengthAttribute.MaxLength);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ResolvesDuplicatedDynamicParameterNameSubstring()
        {
            string[] parameters = { "Username", "Location", "Mode" };
            string[] parameterSetNames = { "__AllParameterSets" };
            string key = "user";
            TemplateFileParameterV1 value = new TemplateFileParameterV1()
            {
                AllowedValues = new List<object>() { "Mode1", "Mode2", "Mode3" },
                MaxLength = "5",
                MinLength = "1",
                Type = "bool"
            };
            KeyValuePair<string, TemplateFileParameterV1> parameter = new KeyValuePair<string, TemplateFileParameterV1>(key, value);

            RuntimeDefinedParameter dynamicParameter = TemplateUtility.ConstructDynamicParameter(parameters, parameter);

            Assert.Equal(key + "FromTemplate", dynamicParameter.Name);
            Assert.Equal(value.DefaultValue, dynamicParameter.Value);
            Assert.Equal(typeof(bool), dynamicParameter.ParameterType);
            Assert.Equal(2, dynamicParameter.Attributes.Count);

            ParameterAttribute parameterAttribute = (ParameterAttribute)dynamicParameter.Attributes[0];
            Assert.True(parameterAttribute.Mandatory);
            Assert.True(parameterAttribute.ValueFromPipelineByPropertyName);
            Assert.Equal(parameterSetNames[0], parameterAttribute.ParameterSetName);

            ValidateLengthAttribute validateLengthAttribute = (ValidateLengthAttribute)dynamicParameter.Attributes[1];
            Assert.Equal(int.Parse(value.MinLength), validateLengthAttribute.MinLength);
            Assert.Equal(int.Parse(value.MaxLength), validateLengthAttribute.MaxLength);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ResolvesDuplicatedDynamicParameterNameCaseInsensitive()
        {
            string[] parameters = { "Name", "Location", "Mode" };
            string[] parameterSetNames = { "__AllParameterSets" };
            string key = "name";
            TemplateFileParameterV1 value = new TemplateFileParameterV1()
            {
                AllowedValues = new List<object>() { "Mode1", "Mode2", "Mode3" },
                MaxLength = "5",
                MinLength = "1",
                Type = "bool"
            };
            KeyValuePair<string, TemplateFileParameterV1> parameter = new KeyValuePair<string, TemplateFileParameterV1>(key, value);

            RuntimeDefinedParameter dynamicParameter = TemplateUtility.ConstructDynamicParameter(parameters, parameter);

            Assert.Equal(key + "FromTemplate", dynamicParameter.Name);
            Assert.Equal(value.DefaultValue, dynamicParameter.Value);
            Assert.Equal(typeof(bool), dynamicParameter.ParameterType);
            Assert.Equal(2, dynamicParameter.Attributes.Count);

            ParameterAttribute parameterAttribute = (ParameterAttribute)dynamicParameter.Attributes[0];
            Assert.True(parameterAttribute.Mandatory);
            Assert.True(parameterAttribute.ValueFromPipelineByPropertyName);
            Assert.Equal(parameterSetNames[0], parameterAttribute.ParameterSetName);

            ValidateLengthAttribute validateLengthAttribute = (ValidateLengthAttribute)dynamicParameter.Attributes[1];
            Assert.Equal(int.Parse(value.MinLength), validateLengthAttribute.MinLength);
            Assert.Equal(int.Parse(value.MaxLength), validateLengthAttribute.MaxLength);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ConstructsDynamicParameterNoValidation()
        {
            string[] parameters = { "Name", "Location", "Mode" };
            string[] parameterSetNames = { "__AllParameterSets" };
            string key = "computeMode";
            TemplateFileParameterV1 value = new TemplateFileParameterV1()
            {
                AllowedValues = new List<object>(),
                DefaultValue = "Mode1",
                Type = "securestring"
            };
            KeyValuePair<string, TemplateFileParameterV1> parameter = new KeyValuePair<string, TemplateFileParameterV1>(key, value);

            RuntimeDefinedParameter dynamicParameter = TemplateUtility.ConstructDynamicParameter(parameters, parameter);

            Assert.Equal("computeMode", dynamicParameter.Name);
            Assert.Equal(value.DefaultValue, dynamicParameter.Value);
            Assert.Equal(typeof(SecureString), dynamicParameter.ParameterType);
            Assert.Equal(1, dynamicParameter.Attributes.Count);

            ParameterAttribute parameterAttribute = (ParameterAttribute)dynamicParameter.Attributes[0];
            Assert.False(parameterAttribute.Mandatory);
            Assert.True(parameterAttribute.ValueFromPipelineByPropertyName);
            Assert.Equal(parameterSetNames[0], parameterAttribute.ParameterSetName);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ConstructsDynamicParameterWithNullAllowedValues()
        {
            string[] parameters = { "Name", "Location", "Mode" };
            string[] parameterSetNames = { "__AllParameterSets" };
            string key = "computeMode";
            TemplateFileParameterV1 value = new TemplateFileParameterV1()
            {
                AllowedValues = null,
                DefaultValue = "Mode1",
                Type = "securestring"
            };
            KeyValuePair<string, TemplateFileParameterV1> parameter = new KeyValuePair<string, TemplateFileParameterV1>(key, value);

            RuntimeDefinedParameter dynamicParameter = TemplateUtility.ConstructDynamicParameter(parameters, parameter);

            Assert.Equal("computeMode", dynamicParameter.Name);
            Assert.Equal(value.DefaultValue, dynamicParameter.Value);
            Assert.Equal(typeof(SecureString), dynamicParameter.ParameterType);
            Assert.Equal(1, dynamicParameter.Attributes.Count);

            ParameterAttribute parameterAttribute = (ParameterAttribute)dynamicParameter.Attributes[0];
            Assert.False(parameterAttribute.Mandatory);
            Assert.True(parameterAttribute.ValueFromPipelineByPropertyName);
            Assert.Equal(parameterSetNames[0], parameterAttribute.ParameterSetName);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ConstructsObjectTypeDynamicParameter()
        {
            string[] parameters = { "Name", "Location", "Mode" };
            string[] parameterSetNames = { "__AllParameterSets" };
            string key = "appSku";
            TemplateFileParameterV1 value = new TemplateFileParameterV1()
            {
                AllowedValues = new List<object>()
                {
                    JObject.Parse("{\"code\" : \"F1\", \"name\" : \"Free\"}"),
                    JObject.Parse("{\"code\" : \"F2\", \"name\" : \"Shared\"}"),
                },
                DefaultValue = JObject.Parse("{\"code\" : \"F1\", \"name\" : \"Free\"}"),
                Type = "object"
            };
            KeyValuePair<string, TemplateFileParameterV1> parameter = new KeyValuePair<string, TemplateFileParameterV1>(key, value);

            RuntimeDefinedParameter dynamicParameter = TemplateUtility.ConstructDynamicParameter(parameters, parameter);

            Assert.Equal("appSku", dynamicParameter.Name);
            Assert.Equal(value.DefaultValue, dynamicParameter.Value);
            Assert.Equal(typeof(Hashtable), dynamicParameter.ParameterType);
            Assert.Equal(1, dynamicParameter.Attributes.Count);

            ParameterAttribute parameterAttribute = (ParameterAttribute)dynamicParameter.Attributes[0];
            Assert.False(parameterAttribute.Mandatory);
            Assert.True(parameterAttribute.ValueFromPipelineByPropertyName);
            Assert.Equal(parameterSetNames[0], parameterAttribute.ParameterSetName);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ConstructsArrayTypeDynamicParameter()
        {
            string[] parameters = { "Name", "Location", "Mode" };
            string[] parameterSetNames = { "__AllParameterSets" };
            string key = "ranks";
            TemplateFileParameterV1 value = new TemplateFileParameterV1()
            {
                AllowedValues = new List<object>()
                {
                    JArray.Parse("[\"1\", \"3\", \"5\"]"),
                    JArray.Parse("[\"A\", \"D\", \"F\"]"),
                },
                DefaultValue = JArray.Parse("[\"A\", \"D\", \"F\"]"),
                Type = "array"
            };
            KeyValuePair<string, TemplateFileParameterV1> parameter = new KeyValuePair<string, TemplateFileParameterV1>(key, value);

            RuntimeDefinedParameter dynamicParameter = TemplateUtility.ConstructDynamicParameter(parameters, parameter);

            Assert.Equal("ranks", dynamicParameter.Name);
            Assert.Equal(value.DefaultValue, dynamicParameter.Value);
            Assert.Equal(typeof(object[]), dynamicParameter.ParameterType);
            Assert.Equal(1, dynamicParameter.Attributes.Count);

            ParameterAttribute parameterAttribute = (ParameterAttribute)dynamicParameter.Attributes[0];
            Assert.False(parameterAttribute.Mandatory);
            Assert.True(parameterAttribute.ValueFromPipelineByPropertyName);
            Assert.Equal(parameterSetNames[0], parameterAttribute.ParameterSetName);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetsDynamicParametersForTemplateFile()
        {
            RuntimeDefinedParameterDictionary result = TemplateUtility.GetTemplateParametersFromFile(
                templateFile,
                null,
                null,
                new[] { "TestPS" });

            Assert.Equal(7, result.Count);

            Assert.Equal("string", result["string"].Name);
            Assert.Equal(typeof(string), result["String"].ParameterType);

            Assert.Equal("int", result["int"].Name);
            Assert.Equal(typeof(int), result["int"].ParameterType);

            Assert.Equal("securestring", result["securestring"].Name);
            Assert.Equal(typeof(SecureString), result["securestring"].ParameterType);

            Assert.Equal("bool", result["bool"].Name);
            Assert.Equal(typeof(bool), result["bool"].ParameterType);

            Assert.Equal("object", result["object"].Name);
            Assert.Equal(typeof(Hashtable), result["object"].ParameterType);

            Assert.Equal("secureObject", result["secureObject"].Name);
            Assert.Equal(typeof(Hashtable), result["secureObject"].ParameterType);

            Assert.Equal("array", result["array"].Name);
            Assert.Equal(typeof(object[]), result["array"].ParameterType);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetTemplateParametersFromObject()
        {
            Hashtable templateParameterObject = new Hashtable();
            templateParameterObject["string"] = "myvalue";
            templateParameterObject["int"] = 12;
            templateParameterObject["bool"] = true;
            templateParameterObject["object"] = new Hashtable()
            {
                { "code", "F1" },
                { "name", "Free" }
            };
            templateParameterObject["array"] = new object[] {
                "A", "D", "F"
            };


            RuntimeDefinedParameterDictionary result = TemplateUtility.GetTemplateParametersFromFile(
                templateFile,
                templateParameterObject,
                null,
                new[] { "TestPS" });

            Assert.Equal(7, result.Count);

            Assert.Equal("string", result["string"].Name);
            Assert.Equal(typeof(string), result["string"].ParameterType);
            Assert.Equal("myvalue", result["string"].Value);

            Assert.Equal("int", result["int"].Name);
            Assert.Equal(typeof(int), result["int"].ParameterType);
            Assert.Equal(12, result["int"].Value);

            Assert.Equal("bool", result["bool"].Name);
            Assert.Equal(typeof(bool), result["bool"].ParameterType);
            Assert.Equal(true, result["bool"].Value);

            Assert.Equal("object", result["object"].Name);
            Assert.Equal(typeof(Hashtable), result["object"].ParameterType);
            Hashtable objectValue = result["object"].Value as Hashtable;
            Assert.Equal(2, objectValue.Count);
            Assert.Equal("F1", objectValue["code"]);
            Assert.Equal("Free", objectValue["name"]);

            Assert.Equal("array", result["array"].Name);
            Assert.Equal(typeof(object[]), result["array"].ParameterType);
            var arrayValue = result["array"].Value as object[];
            Assert.Equal(3, arrayValue.Length);
            Assert.Equal("A", arrayValue[0]);
            Assert.Equal("F", arrayValue[2]);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetTemplateParametersFromFileMergesObjects()
        {
            Hashtable hashtable = new Hashtable();
            hashtable["Bool"] = true;
            hashtable["Foo"] = "bar";
            RuntimeDefinedParameterDictionary result = TemplateUtility.GetTemplateParametersFromFile(
                templateFile,
                null,
                templateParameterFileSchema1,
                new[] { "TestPS" });

            Assert.Equal(7, result.Count);

            Assert.Equal("string", result["string"].Name);
            Assert.Equal(typeof(string), result["string"].ParameterType);
            Assert.Equal("myvalue", result["string"].Value);

            Assert.Equal("int", result["int"].Name);
            Assert.Equal(typeof(int), result["int"].ParameterType);
            Assert.Equal((System.Int64)12, result["int"].Value);

            Assert.Equal("bool", result["bool"].Name);
            Assert.Equal(typeof(bool), result["bool"].ParameterType);
            Assert.Equal(true, result["bool"].Value);

            Assert.Equal("object", result["object"].Name);
            Assert.Equal(typeof(Hashtable), result["object"].ParameterType);
            JObject objectValue = result["object"].Value as JObject;
            Assert.Equal(2, objectValue.Count);
            Assert.Equal("F1", objectValue["code"].ToObject<string>());
            Assert.Equal("Free", objectValue["name"].ToObject<string>());

            Assert.Equal("array", result["array"].Name);
            Assert.Equal(typeof(object[]), result["array"].ParameterType);
            var arrayValue = result["array"].Value as JArray;
            Assert.Equal(3, arrayValue.Count);
            Assert.Equal("A", arrayValue[0].ToObject<string>());
            Assert.Equal("F", arrayValue[2].ToObject<string>());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetTemplateParametersFromFileWithSchema2MergesObjects()
        {
            Hashtable hashtable = new Hashtable();
            hashtable["Bool"] = true;
            hashtable["Foo"] = "bar";
            RuntimeDefinedParameterDictionary result = TemplateUtility.GetTemplateParametersFromFile(
                templateFile,
                null,
                templateParameterFileSchema2,
                new[] { "TestPS" });

            Assert.Equal(7, result.Count);

            Assert.Equal("string", result["string"].Name);
            Assert.Equal(typeof(string), result["string"].ParameterType);
            Assert.Equal("myvalue", result["string"].Value);

            Assert.Equal("int", result["int"].Name);
            Assert.Equal(typeof(int), result["int"].ParameterType);
            Assert.Equal("12", result["int"].Value);

            Assert.Equal("bool", result["bool"].Name);
            Assert.Equal(typeof(bool), result["bool"].ParameterType);
            Assert.Equal("True", result["bool"].Value);

            Assert.Equal("object", result["object"].Name);
            Assert.Equal(typeof(Hashtable), result["object"].ParameterType);
            JObject objectValue = result["object"].Value as JObject;
            Assert.Equal(2, objectValue.Count);
            Assert.Equal("F1", objectValue["code"].ToObject<string>());
            Assert.Equal("Free", objectValue["name"].ToObject<string>());

            Assert.Equal("array", result["array"].Name);
            Assert.Equal(typeof(object[]), result["array"].ParameterType);
            var arrayValue = result["array"].Value as JArray;
            Assert.Equal(3, arrayValue.Count);
            Assert.Equal("A", arrayValue[0].ToObject<string>());
            Assert.Equal("F", arrayValue[2].ToObject<string>());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void HandlesInvalidTemplateFiles()
        {
            Hashtable hashtable = new Hashtable();
            hashtable["Bool"] = true;
            hashtable["Foo"] = "bar";
            RuntimeDefinedParameterDictionary result = TemplateUtility.GetTemplateParametersFromFile(
                invalidTemplateFile,
                null,
                templateParameterFileSchema1,
                new[] { "TestPS" });

            Assert.Equal(0, result.Count);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ParseTemplateParameterFileContents_DeserializeWithCorrectType()
        {
            // Add up to 3 retries for flaky test
            TestExecutionHelpers.RetryAction(() =>
            {
                Dictionary<string, TemplateFileParameterV1> result =
                    TemplateUtility.ParseTemplateParameterFileContents(@"Resources\WebSite.param.dev.json".AsAbsoluteLocation());
                Assert.Equal(true, result["isWorker"].Value);
                Assert.Equal((System.Int64) 1, result["numberOfWorker"].Value);
            });
        }
    }
}
