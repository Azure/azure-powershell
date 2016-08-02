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
using System.IO;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common.XmlSchema.ServiceDefinitionSchema;
using Microsoft.Azure.Commands.Common.Authentication;

namespace Microsoft.WindowsAzure.Commands.Test.CloudService.Utilities
{
    
    public class GeneralTests : SMTestBase
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SerializationTestWithGB18030()
        {
            // Setup
            string outputFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"outputFile.txt");
            ServiceDefinition serviceDefinition = XmlUtilities.DeserializeXmlFile<ServiceDefinition>(
                Testing.GetTestResourcePath("GB18030ServiceDefinition.csdef"));

            // Test
            File.Create(outputFileName).Close();
            XmlUtilities.SerializeXmlFile(serviceDefinition, outputFileName);

            // Assert
            // And check we are writing out with UTF encoding with a BOM
            byte[] data = System.IO.File.ReadAllBytes(outputFileName);
            Assert.True(data[0] == 0xff && data[1] == 0xfe);
        }
    }
}
