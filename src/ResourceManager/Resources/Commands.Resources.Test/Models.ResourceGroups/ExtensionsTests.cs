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
using Microsoft.Azure.Gallery;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Resources.Test.Models
{
    public class ExtensionsTests
    {
        public ExtensionsTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToPSGalleryItemCreatesANewItem()
        {
            var item = new GalleryItem()
            {
                Name = "Name",
                Publisher = "Microsoft",
                DefinitionTemplates = new DefinitionTemplates()
                {
                    DefaultDeploymentTemplateId = "DefaultUri",
                    DeploymentTemplateFileUrls = new Dictionary<string, string>()
                                {
                                    {"DefaultUri", "fakeurl"}
                                }
                }
            };

            var psitem = item.ToPSGalleryItem();

            Assert.Equal(item.Name, psitem.Name);
            Assert.Equal(item.Publisher, psitem.Publisher);
            Assert.Equal(item.DefinitionTemplates.DefaultDeploymentTemplateId, psitem.DefinitionTemplates.DefaultDeploymentTemplateId);
            Assert.Equal(item.DefinitionTemplates.DeploymentTemplateFileUrls["DefaultUri"], psitem.DefinitionTemplates.DeploymentTemplateFileUrls["DefaultUri"]);
            Assert.Equal("fakeurl", psitem.DefinitionTemplatesText);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToPSGalleryItemCreatesANewItemWithNullDeploymentTemplates()
        {
            var item = new GalleryItem()
            {
                Name = "Name",
                Publisher = "Microsoft",
            };

            var psitem = item.ToPSGalleryItem();

            Assert.Equal(item.Name, psitem.Name);
            Assert.Equal(item.Publisher, psitem.Publisher);
            Assert.Null(psitem.DefinitionTemplatesText);
        }
    }
}
