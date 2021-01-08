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
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Resources.Test.ScenarioTests
{
    public class TemplateSpecTests : ResourceTestRunner
    {
        public TemplateSpecTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestTemplateSpecGet()
        {
            TestRunner.RunTestScript("Test-GetTemplateSpec");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestTemplateSpecCreate()
        {
            TestRunner.RunTestScript("Test-CreateTemplateSpec");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestTemplateSpecSet()
        {
            TestRunner.RunTestScript("Test-SetTemplateSpec");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestTemplateSpecRemoval()
        {
            TestRunner.RunTestScript("Test-RemoveTemplateSpec");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewTemplateSpec_Tags_AppliesTagsToBothTemplateSpecAndVersionIfNotExist()
        {
            TestRunner.RunTestScript("Test-NewAppliesTagsToBothTemplateSpecAndVersionIfNotExist");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewTemplateSpec_Tags_AppliesTagsToOnlyVersionIfTemplateSpecExists()
        {
            TestRunner.RunTestScript("Test-NewAppliesTagsToOnlyVersionIfTemplateSpecExists");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewTemplateSpec_Tags_AppliesInheritedTagsIfNoTagsSuppliedAndSpecExists()
        {
            TestRunner.RunTestScript("Test-NewAppliesInheritedTagsIfNoTagsSuppliedAndSpecExists");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewTemplateSpec_Tags_RemovesTagsFromExistingVersionIfTagsExplicityEmpty()
        {
            TestRunner.RunTestScript("Test-NewRemovesTagsFromExistingVersionIfTagsExplicitlyEmpty");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetTemplateSpec_Tags_AppliesTagsToBothTemplateSpecAndVersionIfNotExist()
        {
            TestRunner.RunTestScript("Test-SetAppliesTagsToBothTemplateSpecAndVersionIfNotExist");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetTemplateSpec_Tags_AppliesTagsOnlyToVersionIfVersionSpecified()
        {
            TestRunner.RunTestScript("Test-SetAppliesTagsOnlyToVersionIfVersionSpecified");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetTemplateSpec_Tags_AppliesTagsToTemplateSpecIfNoVersionSpecified()
        {
            TestRunner.RunTestScript("Test-SetAppliesTagsToTemplateSpecIfNoVersionSpecified");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetTemplateSpec_Tags_AppliesInheritedTagsIfNewVersionAndNoTagsProvidedAndSpecExists()
        {
            TestRunner.RunTestScript("Test-SetAppliesInheritedTagsIfNewVersionAndNoTagsProvidedAndSpecExists");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetTemplateSpec_Tags_RemovesTagsIfTagsExplicitlyEmpty()
        {
            TestRunner.RunTestScript("Test-SetRemovesTagsIfTagsExplicitlyEmpty");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetTemplateSpec_TestErrorType()
        {
            TestRunner.RunTestScript("Test-TemplateSpecErrorType");
        }

    }
}
