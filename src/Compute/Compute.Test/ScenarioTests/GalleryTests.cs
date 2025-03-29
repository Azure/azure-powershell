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

using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Compute.Test.ScenarioTests
{
    public class GalleryTests : ComputeTestRunner
    {
        public GalleryTests(Xunit.Abstractions.ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGallery()
        {
            TestRunner.RunTestScript("Test-Gallery");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGalleryCrossTenant()
        {
            TestRunner.RunTestScript("Test-GalleryCrossTenant");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GalleryImageVersion()
        {
            TestRunner.RunTestScript("Test-GalleryImageVersion");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGalleryImageVersionDiskImage()
        {
            TestRunner.RunTestScript("Test-GalleryImageVersionDiskImage");
        }
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGalleryDirectSharing()
        {
            TestRunner.RunTestScript("Test-GalleryDirectSharing");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGalleryVersionWithSourceImageVMId()
        {
            TestRunner.RunTestScript("Test-GalleryVersionWithSourceImageVMId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGalleryImageDefinitionDefaults()
        {
            TestRunner.RunTestScript("Test-GalleryImageDefinitionDefaults");
        }
    }
}