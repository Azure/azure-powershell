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

namespace Microsoft.Azure.Commands.Resources.Test.Formatters
{
    using FluentAssertions;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Formatters;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class PSResourceManagerErrorFormatterTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Format_NullError_ReturnsEmptyString()
        {
            // Arrange & Act.
            PSResourceManagerError error = null;

            // Act.
            string result = PSResourceManagerErrorFormatter.Format(error);

            // Assert.
            result.Should().Be(string.Empty);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Format_NestedErrors_ReturnsFlattenedErrorString()
        {
            // Arrange & Act.
            PSResourceManagerError error = new PSResourceManagerError
            {
                Code = "TopLevelError",
                Message = "Top level error message.",
                Details = new List<PSResourceManagerError>
                {
                    new PSResourceManagerError
                    {
                        Code = "SecondLevelError",
                        Message = "Second level error message.",
                        Details = new List<PSResourceManagerError>
                        {
                            new PSResourceManagerError
                            {
                                Code = "ThirdLevelError",
                                Message = "Third level error message."
                            }
                        }
                    },
                    new PSResourceManagerError
                    {
                        Code = "AnotherSecondLevelError",
                        Message = "Another second level error message."
                    }
                }
            };

            // Act.
            string result = PSResourceManagerErrorFormatter.Format(error);

            // Assert.
            result.Should().Be(@"TopLevelError - Top level error message.
SecondLevelError - Second level error message.
ThirdLevelError - Third level error message.
AnotherSecondLevelError - Another second level error message.".Replace("\r\n", Environment.NewLine));
        }
    }
}
