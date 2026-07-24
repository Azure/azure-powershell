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

using Microsoft.Azure.Commands.Compute.Automation;
using Xunit;

namespace Microsoft.Azure.Commands.Compute.Test.ScenarioTests
{
    public class RunCommandParameterValueEscaperTests
    {
        [Theory]
        [InlineData("abc^123", "abc^^123")]
        [InlineData("abc&123", "abc^&123")]
        [InlineData("abc%123", "abc%%123")]
        [InlineData("abc<123", "abc^<123")]
        [InlineData("abc>123", "abc^>123")]
        [InlineData("abc|123", "abc^|123")]
        [InlineData("abc\"123", "abc^\"123")]
        public void Escape_ShouldEscapeCmdSpecialCharacters_ForRunPowerShellScript(string value, string expected)
        {
            var escaped = RunCommandParameterValueEscaper.Escape("RunPowerShellScript", value);

            Assert.Equal(expected, escaped);
        }

        [Fact]
        public void Escape_ShouldNotModifyValue_ForOtherCommandIds()
        {
            var value = "abc^&%<>|\"123";

            var escaped = RunCommandParameterValueEscaper.Escape("RunShellScript", value);

            Assert.Equal(value, escaped);
        }
    }
}
