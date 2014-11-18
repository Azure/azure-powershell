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

using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Security;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Resources.Models;
using Microsoft.Azure.Gallery;
using Microsoft.Azure.Gallery.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Common.OData;
using Moq;
using Xunit;

namespace Microsoft.Azure.Commands.Resources.Test.Models
{
    public class GalleryTemplatesClientTests : TestBase
    {
        private GalleryTemplatesClient galleryTemplatesClient;

        private Mock<IGalleryClient> galleryClientMock;

        private string templateFile = @"Resources\sampleTemplateFile.json";

        private string invalidTemplateFile = @"Resources\invalidTemplateFile.json";

        private string templateParameterFileSchema1 = @"Resources\sampleTemplateParameterFile.json";

        private string templateParameterFileSchema2 = @"Resources\sampleTemplateParameterFileSchema2.json";

        public GalleryTemplatesClientTests()
        {
            galleryClientMock = new Mock<IGalleryClient>();
            galleryTemplatesClient = new GalleryTemplatesClient(galleryClientMock.Object);
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
                AllowedValues = new List<string>() { "Mode1", "Mode2", "Mode3" },
                DefaultValue = "Mode1",
                MaxLength = "5",
                MinLength = "1",
                Type = "string"
            };
            KeyValuePair<string, TemplateFileParameterV1> parameter = new KeyValuePair<string, TemplateFileParameterV1>(key, value);

            RuntimeDefinedParameter dynamicParameter = galleryTemplatesClient.ConstructDynamicParameter(parameters, parameter);

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

        [Fact]
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

            RuntimeDefinedParameter dynamicParameter = galleryTemplatesClient.ConstructDynamicParameter(parameters, parameter);

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

        [Fact]
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

            RuntimeDefinedParameter dynamicParameter = galleryTemplatesClient.ConstructDynamicParameter(parameters, parameter);

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

        [Fact]
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

            RuntimeDefinedParameter dynamicParameter = galleryTemplatesClient.ConstructDynamicParameter(parameters, parameter);

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

        [Fact]
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

            RuntimeDefinedParameter dynamicParameter = galleryTemplatesClient.ConstructDynamicParameter(parameters, parameter);

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

            RuntimeDefinedParameter dynamicParameter = galleryTemplatesClient.ConstructDynamicParameter(parameters, parameter);

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
        public void GetsDynamicParametersForTemplateFile()
        {
            RuntimeDefinedParameterDictionary result = galleryTemplatesClient.GetTemplateParametersFromFile(
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
            Assert.Equal(typeof(SecureString), result["securestring"].ParameterType);

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
            RuntimeDefinedParameterDictionary result = galleryTemplatesClient.GetTemplateParametersFromFile(
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
            RuntimeDefinedParameterDictionary result = galleryTemplatesClient.GetTemplateParametersFromFile(
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
            RuntimeDefinedParameterDictionary result = galleryTemplatesClient.GetTemplateParametersFromFile(
                invalidTemplateFile,
                null,
                templateParameterFileSchema1,
                new[] { "TestPS" });

            Assert.Equal(0, result.Count);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FiltersGalleryTemplates()
        {
            string filterString = FilterString.Generate<ItemListFilter>(f => f.Publisher == "Microsoft");
            ItemListParameters actual = new ItemListParameters();
            galleryClientMock.Setup(f => f.Items.ListAsync(It.IsAny<ItemListParameters>(), new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => new ItemListResult
                {
                    Items = new List<GalleryItem>()
                    {
                        new GalleryItem()
                        {
                            Name = "Template1",
                            Publisher = "Microsoft"
                        },
                        new GalleryItem()
                        {
                            Name = "Template2",
                            Publisher = "Microsoft"
                        }
                    }
                }))
                .Callback((ItemListParameters p, CancellationToken c) => actual = p);

            FilterGalleryTemplatesOptions options = new FilterGalleryTemplatesOptions()
            {
                Publisher = "Microsoft",
                AllVersions = true
            };

            List<PSGalleryItem> result = galleryTemplatesClient.FilterGalleryTemplates(options);

            Assert.Equal(2, result.Count);
            Assert.True(result.All(g => g.Publisher == "Microsoft"));
            Assert.Equal(filterString, actual.Filter);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FiltersGalleryTemplatesUsingComplexQuery()
        {
            string filterString = "Publisher eq 'Microsoft' and CategoryIds/any(c: c eq 'awesome')";
            ItemListParameters actual = new ItemListParameters();
            galleryClientMock.Setup(f => f.Items.ListAsync(It.IsAny<ItemListParameters>(), new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => new ItemListResult
                {
                    Items = new List<GalleryItem>()
                    {
                        new GalleryItem()
                        {
                            Name = "Template1",
                            Publisher = "Microsoft"
                        },
                        new GalleryItem()
                        {
                            Name = "Template2",
                            Publisher = "Microsoft"
                        }
                    }
                }))
                .Callback((ItemListParameters p, CancellationToken c) => actual = p);

            FilterGalleryTemplatesOptions options = new FilterGalleryTemplatesOptions()
            {
                Publisher = "Microsoft",
                Category = "awesome",
                AllVersions = true
            };

            List<PSGalleryItem> result = galleryTemplatesClient.FilterGalleryTemplates(options);

            Assert.Equal(2, result.Count);
            Assert.Equal(filterString, actual.Filter);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DownloadsGalleryTemplateFile()
        {
            string galleryTemplateFileName = "myFile";
            string expectedFilePath = Path.Combine(Path.GetTempPath(), galleryTemplateFileName + ".json");
            try
            {
                galleryClientMock.Setup(f => f.Items.GetAsync(galleryTemplateFileName, new CancellationToken()))
                                 .Returns(Task.Factory.StartNew(() => new ItemGetParameters()
                                 {
                                     Item = new GalleryItem()
                                     {
                                         Name = galleryTemplateFileName,
                                         Publisher = "Microsoft",
                                         DefinitionTemplates = new DefinitionTemplates()
                                         {
                                             DefaultDeploymentTemplateId = "DefaultUri",
                                             DeploymentTemplateFileUrls = new Dictionary<string, string>()
                                            {
                                                {"DefaultUri", "fakeurl"}
                                            }
                                         }
                                     }
                                 }));

                galleryTemplatesClient.DownloadGalleryTemplateFile(
                    galleryTemplateFileName,
                    expectedFilePath,
                    true,
                    null);

                Assert.Equal(string.Empty, File.ReadAllText(expectedFilePath));
            }
            finally
            {
                File.Delete(expectedFilePath);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DownloadsGalleryTemplateFileFromDirectoryName()
        {
            string galleryTemplateFileName = "myFile";
            string expectedFilePath = Path.Combine(Path.GetTempPath(), galleryTemplateFileName + ".json");
            try
            {
                galleryClientMock.Setup(f => f.Items.GetAsync(galleryTemplateFileName, new CancellationToken()))
                    .Returns(Task.Factory.StartNew(() => new ItemGetParameters()
                    {
                        Item = new GalleryItem()
                        {
                            Name = galleryTemplateFileName,
                            Publisher = "Microsoft",
                            DefinitionTemplates = new DefinitionTemplates()
                            {
                                DefaultDeploymentTemplateId = "DefaultUri",
                                DeploymentTemplateFileUrls = new Dictionary<string, string>()
                                {
                                    { "DefaultUri", "fakeurl" }
                                }
                            }
                        }
                    }));

                galleryTemplatesClient.DownloadGalleryTemplateFile(
                    galleryTemplateFileName,
                    Path.GetTempPath(),
                    true,
                    null);

                Assert.Equal(string.Empty, File.ReadAllText(expectedFilePath));
            }
            finally
            {
                File.Delete(expectedFilePath);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DownloadsGalleryTemplateFileFromFileName()
        {
            string galleryTemplateFileName = "myFile.adeek";
            string expectedFilePath = Path.Combine(Path.GetTempPath(), galleryTemplateFileName + ".json");
            try
            {
                galleryClientMock.Setup(f => f.Items.GetAsync(galleryTemplateFileName, new CancellationToken()))
                    .Returns(Task.Factory.StartNew(() => new ItemGetParameters()
                    {
                        Item = new GalleryItem()
                        {
                            Name = galleryTemplateFileName,
                            Publisher = "Microsoft",
                            DefinitionTemplates = new DefinitionTemplates()
                            {
                                DefaultDeploymentTemplateId = "DefaultUri",
                                DeploymentTemplateFileUrls = new Dictionary<string, string>()
                                {
                                    {"DefaultUri", "http://onesdkauremustinvalid-uri12"}
                                }
                            }
                        }
                    }));

                galleryTemplatesClient.DownloadGalleryTemplateFile(
                    galleryTemplateFileName,
                    expectedFilePath,
                    true,
                    null);

                Assert.Equal(string.Empty, File.ReadAllText(expectedFilePath));
            }
            finally
            {
                File.Delete(expectedFilePath);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ParseTemplateParameterFileContents_DeserializeWithCorrectType()
        {
            Dictionary<string, TemplateFileParameterV1> result =
                galleryTemplatesClient.ParseTemplateParameterFileContents(@"Resources\WebSite.param.dev.json");
            Assert.Equal(true, result["isWorker"].Value);
            Assert.Equal((System.Int64)1, result["numberOfWorker"].Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FiltersGalleryTemplatesLatestVersion()
        {
            string filterString = FilterString.Generate<ItemListFilter>(f => f.Publisher == "Microsoft");
            ItemListParameters actual = new ItemListParameters();
            galleryClientMock.Setup(f => f.Items.ListAsync(It.IsAny<ItemListParameters>(), new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => new ItemListResult
                {
                    Items = new List<GalleryItem>()
                    {
                        new GalleryItem()
                        {
                            Name = "Template0",
                            Publisher = "Microsoft",
                            Version = "0.0.0.0"
                        },
                        new GalleryItem()
                        {
                            Name = "Template0",
                            Publisher = "Microsoft",
                            Version = "0.0.0.1"
                        },
                        new GalleryItem()
                        {
                            Name = "Template0",
                            Publisher = "Microsoft",
                            Version = "0.0.0.2"
                        }
                    }
                }))
                .Callback((ItemListParameters p, CancellationToken c) => actual = p);

            FilterGalleryTemplatesOptions options = new FilterGalleryTemplatesOptions()
            {
                ApplicationName = "Template0"
            };

            List<PSGalleryItem> result = galleryTemplatesClient.FilterGalleryTemplates(options);

            Assert.Equal(1, result.Count);
            Assert.Equal("Template0", result[0].Name);
            Assert.Equal("0.0.0.2", result[0].Version);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FiltersGalleryTemplatesByPublisherLatestVersion()
        {
            string filterString = FilterString.Generate<ItemListFilter>(f => f.Publisher == "Microsoft");
            ItemListParameters actual = new ItemListParameters();
            galleryClientMock.Setup(f => f.Items.ListAsync(It.IsAny<ItemListParameters>(), new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => new ItemListResult
                {
                    Items = new List<GalleryItem>()
                    {
                        new GalleryItem()
                        {
                            Name = "Template0",
                            Publisher = "Microsoft",
                            Version = "0.0.0.0"
                        },
                        new GalleryItem()
                        {
                            Name = "Template0",
                            Publisher = "Microsoft",
                            Version = "0.0.0.2"
                        },
                        new GalleryItem()
                        {
                            Name = "Template1",
                            Publisher = "Microsoft",
                            Version = "0.0.0.0"
                        },
                        new GalleryItem()
                        {
                            Name = "Template1",
                            Publisher = "Microsoft",
                            Version = "0.0.0.1"
                        }
                    }
                }))
                .Callback((ItemListParameters p, CancellationToken c) => actual = p);

            FilterGalleryTemplatesOptions options = new FilterGalleryTemplatesOptions()
            {
                Publisher = "Microsoft"
            };

            List<PSGalleryItem> result = galleryTemplatesClient.FilterGalleryTemplates(options);

            Assert.Equal(2, result.Count);
            Assert.True(result.Count(x => x.Name.Equals("Template0")) == 1);
            Assert.True(result.Count(x => x.Name.Equals("Template1")) == 1);
            Assert.Equal(result.First(x => x.Name.Equals("Template0")).Version, "0.0.0.2");
            Assert.Equal(result.First(x => x.Name.Equals("Template1")).Version, "0.0.0.1");
        }
    }
}
