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

using Microsoft.Azure.Commands.Resources.Models;
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.Commands.Test.Utilities.Common;
using Microsoft.Rest.Azure.OData;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.Commands.Resources.Test.Models
{
    public class GalleryTemplatesClientTests : RMTestBase
    {
        private NewAzureResourceGroupDeploymentCommand deploymentCmdlet;

        private string templateFile = @"Resources\sampleTemplateFile.json";

        private string invalidTemplateFile = @"Resources\invalidTemplateFile.json";

        private string templateParameterFileSchema1 = @"Resources\sampleTemplateParameterFile.json";

        private string templateParameterFileSchema2 = @"Resources\sampleTemplateParameterFileSchema2.json";

        public GalleryTemplatesClientTests()
        {
            deploymentCmdlet = new NewAzureResourceGroupDeploymentCommand();
        }

        [Fact(Skip = "PowerShell runtime only")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ConstructsDynamicParameter()
        {
            string[] parameters = { "Name", "Location", "Mode" };
            string[] parameterSetNames = { "__AllParameterSets" };
            string key = "computeMode";
            TemplateFileParameterV1 value = new TemplateFileParameterV1()
            {
                AllowedValues = new List<string>() { "Mode1", "Mode2", "Mode3" },
                DefaultValue = "Mode1",
                MaxLength = "5",
                MinLength = "1",
                Type = "string"
            };
            KeyValuePair<string, TemplateFileParameterV1> parameter = new KeyValuePair<string, TemplateFileParameterV1>(key, value);

            RuntimeDefinedParameter dynamicParameter = deploymentCmdlet.ConstructDynamicParameter(parameters, parameter);

            Assert.Equal("computeMode", dynamicParameter.Name);
            Assert.Equal(value.DefaultValue, dynamicParameter.Value);
            Assert.Equal(typeof(string), dynamicParameter.ParameterType);
            Assert.Equal(3, dynamicParameter.Attributes.Count);

            ParameterAttribute parameterAttribute = (ParameterAttribute)dynamicParameter.Attributes[0];
            Assert.False(parameterAttribute.Mandatory);
            Assert.True(parameterAttribute.ValueFromPipelineByPropertyName);
            Assert.Equal(parameterSetNames[0], parameterAttribute.ParameterSetName);

            ValidateSetAttribute validateSetAttribute = (ValidateSetAttribute)dynamicParameter.Attributes[1];
            Assert.Equal(3, validateSetAttribute.ValidValues.Count);
            Assert.True(validateSetAttribute.IgnoreCase);
            Assert.True(value.AllowedValues.Contains(validateSetAttribute.ValidValues[0]));
            Assert.True(value.AllowedValues.Contains(validateSetAttribute.ValidValues[1]));
            Assert.True(value.AllowedValues.Contains(validateSetAttribute.ValidValues[2]));
            Assert.False(validateSetAttribute.ValidValues[0].Contains(' '));
            Assert.False(validateSetAttribute.ValidValues[1].Contains(' '));
            Assert.False(validateSetAttribute.ValidValues[2].Contains(' '));

            ValidateLengthAttribute validateLengthAttribute = (ValidateLengthAttribute)dynamicParameter.Attributes[2];
            Assert.Equal(int.Parse(value.MinLength), validateLengthAttribute.MinLength);
            Assert.Equal(int.Parse(value.MaxLength), validateLengthAttribute.MaxLength);
        }

        [Fact(Skip = "PowerShell runtime only")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ResolvesDuplicatedDynamicParameterName()
        {
            string[] parameters = { "Name", "Location", "Mode" };
            string[] parameterSetNames = { "__AllParameterSets" };
            string key = "Name";
            TemplateFileParameterV1 value = new TemplateFileParameterV1()
            {
                AllowedValues = new List<string>() { "Mode1", "Mode2", "Mode3" },
                MaxLength = "5",
                MinLength = "1",
                Type = "bool"
            };
            KeyValuePair<string, TemplateFileParameterV1> parameter = new KeyValuePair<string, TemplateFileParameterV1>(key, value);

            RuntimeDefinedParameter dynamicParameter = deploymentCmdlet.ConstructDynamicParameter(parameters, parameter);

            Assert.Equal(key + "FromTemplate", dynamicParameter.Name);
            Assert.Equal(value.DefaultValue, dynamicParameter.Value);
            Assert.Equal(typeof(bool), dynamicParameter.ParameterType);
            Assert.Equal(3, dynamicParameter.Attributes.Count);

            ParameterAttribute parameterAttribute = (ParameterAttribute)dynamicParameter.Attributes[0];
            Assert.True(parameterAttribute.Mandatory);
            Assert.True(parameterAttribute.ValueFromPipelineByPropertyName);
            Assert.Equal(parameterSetNames[0], parameterAttribute.ParameterSetName);

            ValidateSetAttribute validateSetAttribute = (ValidateSetAttribute)dynamicParameter.Attributes[1];
            Assert.Equal(3, validateSetAttribute.ValidValues.Count);
            Assert.True(validateSetAttribute.IgnoreCase);
            Assert.True(value.AllowedValues.Contains(validateSetAttribute.ValidValues[0]));
            Assert.True(value.AllowedValues.Contains(validateSetAttribute.ValidValues[1]));
            Assert.True(value.AllowedValues.Contains(validateSetAttribute.ValidValues[2]));
            Assert.False(validateSetAttribute.ValidValues[0].Contains(' '));
            Assert.False(validateSetAttribute.ValidValues[1].Contains(' '));
            Assert.False(validateSetAttribute.ValidValues[2].Contains(' '));

            ValidateLengthAttribute validateLengthAttribute = (ValidateLengthAttribute)dynamicParameter.Attributes[2];
            Assert.Equal(int.Parse(value.MinLength), validateLengthAttribute.MinLength);
            Assert.Equal(int.Parse(value.MaxLength), validateLengthAttribute.MaxLength);
        }

        [Fact(Skip="PowerShell runtime only")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ResolvesDuplicatedDynamicParameterNameSubstring()
        {
            string[] parameters = { "Username", "Location", "Mode" };
            string[] parameterSetNames = { "__AllParameterSets" };
            string key = "user";
            TemplateFileParameterV1 value = new TemplateFileParameterV1()
            {
                AllowedValues = new List<string>() { "Mode1", "Mode2", "Mode3" },
                MaxLength = "5",
                MinLength = "1",
                Type = "bool"
            };
            KeyValuePair<string, TemplateFileParameterV1> parameter = new KeyValuePair<string, TemplateFileParameterV1>(key, value);

            RuntimeDefinedParameter dynamicParameter = deploymentCmdlet.ConstructDynamicParameter(parameters, parameter);

            Assert.Equal(key + "FromTemplate", dynamicParameter.Name);
            Assert.Equal(value.DefaultValue, dynamicParameter.Value);
            Assert.Equal(typeof(bool), dynamicParameter.ParameterType);
            Assert.Equal(3, dynamicParameter.Attributes.Count);

            ParameterAttribute parameterAttribute = (ParameterAttribute)dynamicParameter.Attributes[0];
            Assert.True(parameterAttribute.Mandatory);
            Assert.True(parameterAttribute.ValueFromPipelineByPropertyName);
            Assert.Equal(parameterSetNames[0], parameterAttribute.ParameterSetName);

            ValidateSetAttribute validateSetAttribute = (ValidateSetAttribute)dynamicParameter.Attributes[1];
            Assert.Equal(3, validateSetAttribute.ValidValues.Count);
            Assert.True(validateSetAttribute.IgnoreCase);
            Assert.True(value.AllowedValues.Contains(validateSetAttribute.ValidValues[0]));
            Assert.True(value.AllowedValues.Contains(validateSetAttribute.ValidValues[1]));
            Assert.True(value.AllowedValues.Contains(validateSetAttribute.ValidValues[2]));
            Assert.False(validateSetAttribute.ValidValues[0].Contains(' '));
            Assert.False(validateSetAttribute.ValidValues[1].Contains(' '));
            Assert.False(validateSetAttribute.ValidValues[2].Contains(' '));

            ValidateLengthAttribute validateLengthAttribute = (ValidateLengthAttribute)dynamicParameter.Attributes[2];
            Assert.Equal(int.Parse(value.MinLength), validateLengthAttribute.MinLength);
            Assert.Equal(int.Parse(value.MaxLength), validateLengthAttribute.MaxLength);
        }

        [Fact(Skip = "PowerShell runtime only")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ResolvesDuplicatedDynamicParameterNameCaseInsensitive()
        {
            string[] parameters = { "Name", "Location", "Mode" };
            string[] parameterSetNames = { "__AllParameterSets" };
            string key = "name";
            TemplateFileParameterV1 value = new TemplateFileParameterV1()
            {
                AllowedValues = new List<string>() { "Mode1", "Mode2", "Mode3" },
                MaxLength = "5",
                MinLength = "1",
                Type = "bool"
            };
            KeyValuePair<string, TemplateFileParameterV1> parameter = new KeyValuePair<string, TemplateFileParameterV1>(key, value);

            RuntimeDefinedParameter dynamicParameter = deploymentCmdlet.ConstructDynamicParameter(parameters, parameter);

            Assert.Equal(key + "FromTemplate", dynamicParameter.Name);
            Assert.Equal(value.DefaultValue, dynamicParameter.Value);
            Assert.Equal(typeof(bool), dynamicParameter.ParameterType);
            Assert.Equal(3, dynamicParameter.Attributes.Count);

            ParameterAttribute parameterAttribute = (ParameterAttribute)dynamicParameter.Attributes[0];
            Assert.True(parameterAttribute.Mandatory);
            Assert.True(parameterAttribute.ValueFromPipelineByPropertyName);
            Assert.Equal(parameterSetNames[0], parameterAttribute.ParameterSetName);

            ValidateSetAttribute validateSetAttribute = (ValidateSetAttribute)dynamicParameter.Attributes[1];
            Assert.Equal(3, validateSetAttribute.ValidValues.Count);
            Assert.True(validateSetAttribute.IgnoreCase);
            Assert.True(value.AllowedValues.Contains(validateSetAttribute.ValidValues[0]));
            Assert.True(value.AllowedValues.Contains(validateSetAttribute.ValidValues[1]));
            Assert.True(value.AllowedValues.Contains(validateSetAttribute.ValidValues[2]));
            Assert.False(validateSetAttribute.ValidValues[0].Contains(' '));
            Assert.False(validateSetAttribute.ValidValues[1].Contains(' '));
            Assert.False(validateSetAttribute.ValidValues[2].Contains(' '));

            ValidateLengthAttribute validateLengthAttribute = (ValidateLengthAttribute)dynamicParameter.Attributes[2];
            Assert.Equal(int.Parse(value.MinLength), validateLengthAttribute.MinLength);
            Assert.Equal(int.Parse(value.MaxLength), validateLengthAttribute.MaxLength);
        }

        [Fact(Skip = "PowerShell runtime only")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ConstructsDynamicParameterNoValidation()
        {
            string[] parameters = { "Name", "Location", "Mode" };
            string[] parameterSetNames = { "__AllParameterSets" };
            string key = "computeMode";
            TemplateFileParameterV1 value = new TemplateFileParameterV1()
            {
                AllowedValues = new List<string>(),
                DefaultValue = "Mode1",
                Type = "securestring"
            };
            KeyValuePair<string, TemplateFileParameterV1> parameter = new KeyValuePair<string, TemplateFileParameterV1>(key, value);

            RuntimeDefinedParameter dynamicParameter = deploymentCmdlet.ConstructDynamicParameter(parameters, parameter);

            Assert.Equal("computeMode", dynamicParameter.Name);
            Assert.Equal(value.DefaultValue, dynamicParameter.Value);
            Assert.Equal(typeof(string), dynamicParameter.ParameterType);
            Assert.Equal(1, dynamicParameter.Attributes.Count);

            ParameterAttribute parameterAttribute = (ParameterAttribute)dynamicParameter.Attributes[0];
            Assert.False(parameterAttribute.Mandatory);
            Assert.True(parameterAttribute.ValueFromPipelineByPropertyName);
            Assert.Equal(parameterSetNames[0], parameterAttribute.ParameterSetName);
        }

        [Fact(Skip = "PowerShell runtime only")]
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

            RuntimeDefinedParameter dynamicParameter = deploymentCmdlet.ConstructDynamicParameter(parameters, parameter);

            Assert.Equal("computeMode", dynamicParameter.Name);
            Assert.Equal(value.DefaultValue, dynamicParameter.Value);
            Assert.Equal(typeof(string), dynamicParameter.ParameterType);
            Assert.Equal(1, dynamicParameter.Attributes.Count);

            ParameterAttribute parameterAttribute = (ParameterAttribute)dynamicParameter.Attributes[0];
            Assert.False(parameterAttribute.Mandatory);
            Assert.True(parameterAttribute.ValueFromPipelineByPropertyName);
            Assert.Equal(parameterSetNames[0], parameterAttribute.ParameterSetName);
        }

        [Fact]
        public void GetsDynamicParametersForTemplateFile()
        {
            RuntimeDefinedParameterDictionary result = deploymentCmdlet.GetTemplateParametersFromFile(
                templateFile,
                null,
                null,
                new[] { "TestPS" });

            Assert.Equal(4, result.Count);

            Assert.Equal("string", result["string"].Name);
            Assert.Equal(typeof(string), result["String"].ParameterType);

            Assert.Equal("int", result["int"].Name);
            Assert.Equal(typeof(int), result["int"].ParameterType);

            Assert.Equal("securestring", result["securestring"].Name);
            Assert.Equal(typeof(string), result["securestring"].ParameterType);

            Assert.Equal("bool", result["bool"].Name);
            Assert.Equal(typeof(bool), result["bool"].ParameterType);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetTemplateParametersFromFileMergesObjects()
        {
            Hashtable hashtable = new Hashtable();
            hashtable["Bool"] = true;
            hashtable["Foo"] = "bar";
            RuntimeDefinedParameterDictionary result = deploymentCmdlet.GetTemplateParametersFromFile(
                templateFile,
                null,
                templateParameterFileSchema1,
                new[] { "TestPS" });

            Assert.Equal(4, result.Count);

            Assert.Equal("string", result["string"].Name);
            Assert.Equal(typeof(string), result["string"].ParameterType);
            Assert.Equal("myvalue", result["string"].Value);


            Assert.Equal("int", result["int"].Name);
            Assert.Equal(typeof(int), result["int"].ParameterType);
            Assert.Equal((System.Int64)12, result["int"].Value);

            Assert.Equal("bool", result["bool"].Name);
            Assert.Equal(typeof(bool), result["bool"].ParameterType);
            Assert.Equal(true, result["bool"].Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetTemplateParametersFromFileWithSchema2MergesObjects()
        {
            Hashtable hashtable = new Hashtable();
            hashtable["Bool"] = true;
            hashtable["Foo"] = "bar";
            RuntimeDefinedParameterDictionary result = deploymentCmdlet.GetTemplateParametersFromFile(
                templateFile,
                null,
                templateParameterFileSchema2,
                new[] { "TestPS" });

            Assert.Equal(4, result.Count);

            Assert.Equal("string", result["string"].Name);
            Assert.Equal(typeof(string), result["string"].ParameterType);
            Assert.Equal("myvalue", result["string"].Value);


            Assert.Equal("int", result["int"].Name);
            Assert.Equal(typeof(int), result["int"].ParameterType);
            Assert.Equal("12", result["int"].Value);

            Assert.Equal("bool", result["bool"].Name);
            Assert.Equal(typeof(bool), result["bool"].ParameterType);
            Assert.Equal("True", result["bool"].Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void HandlesInvalidTemplateFiles()
        {
            Hashtable hashtable = new Hashtable();
            hashtable["Bool"] = true;
            hashtable["Foo"] = "bar";
            RuntimeDefinedParameterDictionary result = deploymentCmdlet.GetTemplateParametersFromFile(
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
            Dictionary<string, TemplateFileParameterV1> result =
                deploymentCmdlet.ParseTemplateParameterFileContents(@"Resources\WebSite.param.dev.json");
            Assert.Equal(true, result["isWorker"].Value);
            Assert.Equal((System.Int64)1, result["numberOfWorker"].Value);
        }
    }
}
