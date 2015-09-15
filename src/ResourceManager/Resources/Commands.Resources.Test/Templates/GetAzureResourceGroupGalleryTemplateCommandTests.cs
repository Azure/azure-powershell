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

using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Resources.Models;
using Microsoft.Azure.Commands.Resources.Templates;
using Moq;
using Xunit;

namespace Microsoft.Azure.Commands.Resources.Test.Resources
{
    public class GetAzureResourceGroupGalleryTemplateCommandTests
    {
        private GetAzureResourceGroupGalleryTemplateCommand cmdlet;

        private Mock<GalleryTemplatesClient> galleryTemplatesClientMock;

        private Mock<ICommandRuntime> commandRuntimeMock;

        public GetAzureResourceGroupGalleryTemplateCommandTests()
        {
            galleryTemplatesClientMock = new Mock<GalleryTemplatesClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetAzureResourceGroupGalleryTemplateCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                GalleryTemplatesClient = galleryTemplatesClientMock.Object
            };
        }

        [Fact]
        public void GetsGalleryTemplates()
        {
            FilterGalleryTemplatesOptions options = new FilterGalleryTemplatesOptions()
            {
                Category = "category",
                Identity = "hobba",
                Publisher = "Microsoft"
            };
            FilterGalleryTemplatesOptions actual = new FilterGalleryTemplatesOptions();
            List<PSGalleryItem> result = new List<PSGalleryItem>()
            {
                new PSGalleryItem()
                {
                    Publisher = "Microsoft",
                    Identity = "T1"
                },
                new PSGalleryItem()
                {
                    Publisher = "Microsoft",
                    Identity = "T2"
                },
            };
            galleryTemplatesClientMock.Setup(f => f.FilterGalleryTemplates(It.IsAny<FilterGalleryTemplatesOptions>()))
                .Returns(result)
                .Callback((FilterGalleryTemplatesOptions o) => actual = o);

            cmdlet.Category = options.Category;
            cmdlet.Identity = options.Identity;
            cmdlet.Publisher = options.Publisher;

            cmdlet.ExecuteCmdlet();

            Assert.Equal(2, result.Count);
            Assert.True(result.All(g => g.Publisher == "Microsoft"));

            commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<List<PSObject>>(), true), Times.Once());
        }
    }
}
