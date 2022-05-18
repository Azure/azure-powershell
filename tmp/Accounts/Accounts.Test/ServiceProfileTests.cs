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

using Microsoft.Azure.Commands.Profile.CommonModule;
using Microsoft.Azure.Commands.Profile.Properties;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Profile.Test
{
    public class ServiceProfileTests
    {
        [Theory]
        [InlineData("hybrid2019-03", "March", "2019")]
        [InlineData("prod2019-04-30", "April", "2019")]
        [InlineData("profile2018-06-30", "June", "2018")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDate(string profile, string month, string year)
        {
            var expectedDateString = $" This profile was defined in {month} {year}.";
            Assert.Equal(expectedDateString, PSAzureServiceProfile.GetDateString(profile));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDateNegative()
        {
            Assert.Equal(string.Empty, PSAzureServiceProfile.GetDateString("profile-foo"));
            Assert.Equal(string.Empty, PSAzureServiceProfile.GetDateString("profile2019-20"));
            Assert.Equal(string.Empty, PSAzureServiceProfile.GetDateString("profile-2019-20"));
            Assert.Equal(string.Empty, PSAzureServiceProfile.GetDateString("profile-20-30-40"));
            Assert.Equal(string.Empty, PSAzureServiceProfile.GetDateString("profile-20195-30-40"));
        }

        [Theory]
        [InlineData("hybrid2019-03", "Hybrid", "March", "2019")]
        [InlineData("prod2019-04-30", "Prod", "April", "2019")]
        [InlineData("profile2018-06-30", "Sovereign", "June", "2018")]
        [InlineData("2019-05-17", "Prod", "May", "2019")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDescription(string name, string profileType, string month, string year)
        {
            string expected = Resources.ProdProfileDescription; ;
            switch(profileType)
            {
                case "Hybrid":
                    expected = Resources.HybridProfileDescription;
                    break;
                case "Sovereign":
                    expected = Resources.SovereignProfileDescription;
                    break;
            }

            var expectedReturnValue = $"{expected} This profile was defined in {month} {year}.";
            Assert.Equal(expectedReturnValue, PSAzureServiceProfile.GetProfileDescription(name));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("prod-2019")]
        [InlineData("arandomstringofletters")]
        [InlineData("201956")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDescriptionNegative(string name)
        {
            Assert.Equal(Resources.ProdProfileDescription, PSAzureServiceProfile.GetProfileDescription(name));
        }
    }
}
