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

using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.KeyVault.WebKey;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.KeyVault.Test.Models
{
    public class UtilitiesTests
    {
        public UtilitiesTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ConvertStringAndSecureString()
        {
            var origStr = "this is test string";
            var secureString = origStr.ConvertToSecureString();
            var convStr = secureString.ConvertToString();

            Assert.Equal(origStr, convStr);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetWebKeyFromByok()
        {
            Random rnd = new Random();
            byte[] byokBlob = new byte[100];
            rnd.NextBytes(byokBlob);
            string tempPath = Path.GetTempFileName() + ".byok";
            File.WriteAllBytes(tempPath, byokBlob);
            IWebKeyConverter converters = WebKeyConverterFactory.CreateConverterChain();
            var webKey = converters.ConvertKeyFromFile(new FileInfo(tempPath), null);

            Assert.True(webKey.T.SequenceEqual(byokBlob));
            Assert.Equal(webKey.Kty, JsonWebKeyType.RsaHsm);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetWebKeyFromCertificate()
        {
            string password = "123";
            // This allows the test to run in Visual Studio and in the console runner. The file will exist in one of the two locations depending on the environment.
            var consolePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? String.Empty, "Resources", "pshtest.pfx");
            var vsPath = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "pshtest.pfx");

            IWebKeyConverter converters = WebKeyConverterFactory.CreateConverterChain();
            var webKey = converters.ConvertKeyFromFile(new FileInfo(File.Exists(consolePath) ? consolePath : vsPath), password.ConvertToSecureString());

            Assert.True(webKey.HasPrivateKey());
            Assert.True(webKey.IsValid());
            Assert.Equal(webKey.Kty, JsonWebKeyType.Rsa);
        }
    }
}
