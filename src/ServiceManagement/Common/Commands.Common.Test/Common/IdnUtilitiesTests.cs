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
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.ServiceManagemenet.Common.Models;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.WindowsAzure.Commands.Common.Test
{
    public class IdnUtilitiesTests
    {
        private static string[] unicodeStrings = { null,
                                                    "",
                                                    "测试工具",
                                                    "prefix测试工具",
                                                    "测试工具suffix",
                                                    "prefix测试工具suffix",
                                                    "prefix.测试工具",
                                                    "测试工具.suffix",
                                                    "prefix.测试工具.suffix",
                                                    "前缀.测试工具.后缀",
                                                    "前缀.测试工具",
                                                    "测试工具.后缀"
                                                };

        private static string[] punycodeStrings = { null,
                                                     "",
                                                    "xn--h6qv61a43lrx3a",
                                                    "xn--prefix-up2j943fwv5az27d",
                                                    "xn--suffix-op2j943fwv5az27d",
                                                    "xn--prefixsuffix-173t950lojyc7d6f",
                                                    "prefix.xn--h6qv61a43lrx3a",
                                                    "xn--h6qv61a43lrx3a.suffix",
                                                    "prefix.xn--h6qv61a43lrx3a.suffix",
                                                    "xn--ldrr30i.xn--h6qv61a43lrx3a.xn--fqr621h",
                                                    "xn--ldrr30i.xn--h6qv61a43lrx3a",
                                                    "xn--h6qv61a43lrx3a.xn--fqr621h"
                                                 };

        private static string[] unicodeUserStrings = { null,
                                                        "",
                                                        "用户名",
                                                        "prefix用户名",
                                                        "用户名suffix",
                                                        "prefix用户名suffix",
                                                        "prefix.用户名",
                                                        "用户名.suffix",
                                                        "prefix.用户名.suffix",
                                                        "前缀.用户名.后缀",
                                                        "前缀.用户名",
                                                        "用户名.后缀",
                                                        "prefix+用户名",
                                                        "用户名+suffix",
                                                        "prefix+用户名.suffix",
                                                        "前缀+用户名+后缀",
                                                        "前缀+用户名",
                                                        "用户名+后缀",
                                                        "prefix-用户名",
                                                        "用户名-suffix",
                                                        "prefix-用户名-suffix",
                                                        "前缀-用户名-后缀",
                                                        "前缀-用户名",
                                                        "用户名-后缀"
                                                    };

        private static string[] punycodeUserStrings = { null,
                                                        "",
                                                        "xn--eqr924avxo",
                                                        "xn--prefix-8h6jw94g4v9a",
                                                        "xn--suffix-2h6jw94g4v9a",
                                                        "xn--prefixsuffix-x80uj25men7c",
                                                        "prefix.xn--eqr924avxo",
                                                        "xn--eqr924avxo.suffix",
                                                        "prefix.xn--eqr924avxo.suffix",
                                                        "xn--ldrr30i.xn--eqr924avxo.xn--fqr621h",
                                                        "xn--ldrr30i.xn--eqr924avxo",
                                                        "xn--eqr924avxo.xn--fqr621h",
                                                        "xn--prefix+-ey3lv66hou3b",
                                                        "xn--+suffix-6x3lv66hou3b",
                                                        "xn--prefix+-ey3lv66hou3b.suffix",
                                                        "xn--++-7j5cl0ega168s1j4a7pqga",
                                                        "xn--+-wg8au7cnw2aykw7pn",
                                                        "xn--+-i68ae116lykweqn",
                                                        "xn--prefix--ey3lv66hou3b",
                                                        "xn---suffix-6x3lv66hou3b",
                                                        "xn--prefix--suffix-655xu17nhkzd",
                                                        "xn-----7j5cl0ega168s1j4a7pqga",
                                                        "xn----wg8au7cnw2aykw7pn",
                                                        "xn----i68ae116lykweqn"
                                                    };

        public IdnUtilitiesTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UnicodeToPunycodeConversionTest()
        {
            Assert.Equal(unicodeStrings.Length, punycodeStrings.Length);
            Assert.Equal(unicodeUserStrings.Length, punycodeUserStrings.Length);

            // Test straight Unicode to Punycode conversion.
            for (int i = 0; i < unicodeStrings.Length; i++)
            {
                Assert.Equal(IdnHelper.GetAscii(unicodeStrings[i]), punycodeStrings[i]);
            }

            // Test Unicode to Punycode conversion for user names.
            for (int i = 0; i < unicodeUserStrings.Length; i++)
            {
                Assert.Equal(IdnHelper.GetAsciiForUserName(unicodeUserStrings[i]), punycodeUserStrings[i]);
            }

            // Test user names that start with the $ sign.
            for (int i = 0; i < unicodeUserStrings.Length; i++)
            {
                Assert.Equal(IdnHelper.GetAsciiForUserName("$" + unicodeUserStrings[i]), "$" + punycodeUserStrings[i]);
            }

            // Test user names in the email address format that has the @ sign in the middle.
            for (int i = 0; i < unicodeUserStrings.Length; i++)
            {
                // Skip null or empty strings.
                if (string.IsNullOrEmpty(unicodeUserStrings[i]))
                {
                    continue;
                }

                for (int j = 0; j < unicodeStrings.Length; j++)
                {
                    // Skip null or empty strings.
                    if (string.IsNullOrEmpty(unicodeStrings[j]))
                    {
                        continue;
                    }

                    string ustring = unicodeUserStrings[i] + "@" + unicodeStrings[j];
                    string pstring = punycodeUserStrings[i] + "@" + punycodeStrings[j];
                    Assert.Equal(IdnHelper.GetAsciiForUserName(ustring), pstring);
                }
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PunycodeToUnicodeConversionTest()
        {
            Assert.Equal(punycodeStrings.Length, unicodeStrings.Length);
            Assert.Equal(punycodeUserStrings.Length, unicodeUserStrings.Length);

            // Test straight Punycode to Unicode conversion.
            for (int i = 0; i < punycodeStrings.Length; i++)
            {
                Assert.Equal(IdnHelper.GetUnicode(punycodeStrings[i]), unicodeStrings[i]);
            }

            // Test Punycode to Unicode conversion for user names.
            for (int i = 0; i < punycodeUserStrings.Length; i++)
            {
                Assert.Equal(IdnHelper.GetUnicodeForUserName(punycodeUserStrings[i]), unicodeUserStrings[i]);
            }

            // Test user names that start with the $ sign.
            for (int i = 0; i < punycodeUserStrings.Length; i++)
            {
                Assert.Equal(IdnHelper.GetUnicodeForUserName("$" + punycodeUserStrings[i]), "$" + unicodeUserStrings[i]);
            }

            // Test user names in the email address format that has the @ sign in the middle.
            for (int i = 0; i < punycodeUserStrings.Length; i++)
            {
                // Skip null or empty strings.
                if (string.IsNullOrEmpty(punycodeUserStrings[i]))
                {
                    continue;
                }

                for (int j = 0; j < punycodeStrings.Length; j++)
                {
                    // Skip null or empty strings.
                    if (string.IsNullOrEmpty(punycodeStrings[j]))
                    {
                        continue;
                    }

                    string pstring = punycodeUserStrings[i] + "@" + punycodeStrings[j];
                    string ustring = unicodeUserStrings[i] + "@" + unicodeStrings[j];
                    Assert.Equal(IdnHelper.GetUnicodeForUserName(pstring), ustring);
                }
            }
        }
    }
}
