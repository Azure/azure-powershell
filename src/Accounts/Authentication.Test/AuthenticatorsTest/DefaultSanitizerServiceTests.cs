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


using Microsoft.Azure.Commands.Common.Authentication.Sanitizer.Services;
using Microsoft.Security.Utilities;
using Microsoft.WindowsAzure.Commands.ScenarioTest;

using Xunit;

namespace Microsoft.Azure.Commands.Common.Authentication.Test.AuthenticatorsTest
{
    public class DefaultSanitizerServiceTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DefaultSanitizerService_HighConfidenceSecurityModels()
        {
            var service = new DefaultSanitizerService();

            foreach (var regexPattern in WellKnownRegexPatterns.HighConfidenceMicrosoftSecurityModels)
            {
                foreach (string testExample in regexPattern.GenerateTestExamples())
                {
                    string sanitized;
                    string toSanitize = testExample;
                    string moniker = regexPattern.GetMatchMoniker(toSanitize);
                    bool result = service.TrySanitizeData(toSanitize, out sanitized);
                    Assert.True(result, $"Test data for '{moniker}' was not sanitized.");

                    // This pattern detects secrets embedded in connection strings. We will
                    // test this class of pattern in future by evaluating a new property
                    // that specifically provides the correlating id (which is currently
                    // only persisted within the redaction token).
                    if (regexPattern.Id == "SEC101/105")
                    {
                        continue;
                    }

                    if ((regexPattern.DetectionMetadata & DetectionMetadata.HighEntropy) != 0)
                    {
                        string correlatingId = RegexPattern.GenerateCrossCompanyCorrelatingId(testExample);
                        Assert.Equal($"{regexPattern.Id}:{correlatingId}", sanitized);
                    }

                    // Naively, we will just chop the leading character off the test data and
                    // run it through the sanitizer again. This data should never fire. We
                    // could perform more sophisticated test data mutation, even altering a
                    // single character should break checksum-validating rules, for example.
                    toSanitize = toSanitize.Substring(1);
                    result = service.TrySanitizeData(toSanitize, out sanitized);
                    Assert.False(result, $"Test data '{toSanitize}' should not have been sanitized.");
                    Assert.Equal(toSanitize, sanitized);
                }
            }
        }
    }
}
