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

using Microsoft.Azure.Commands.CodeSigning;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System;
using Xunit;


namespace Microsoft.Azure.Commands.KeyVault.Test.UnitTests
{
    public class GetCodeSigningEkuTests : CodeSigningUnitTestBase
    {
        private GetAzureCodeSigningEku cmdlet;


        public GetCodeSigningEkuTests()
        {
            base.SetupTest();

            cmdlet = new GetAzureCodeSigningEku()
            {
            };
          
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ErrorRemoveKeyWithPassThruTest()
        {
            //keyVaultClientMock.Setup(kv => kv.DeleteKey(VaultName, KeyName)).Throws(new Exception()).Verifiable();

            //// Mock the should process to return true
            //commandRuntimeMock.Setup(cr => cr.ShouldProcess(KeyName, It.IsAny<string>())).Returns(true);
            //cmdlet.Name = KeyName;
            //cmdlet.Force = true;
            //cmdlet.PassThru = true;
            //try
            //{
            //    cmdlet.ExecuteCmdlet();
            //}
            //catch { }

            //keyVaultClientMock.VerifyAll();
            //commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<PSKeyVaultKey>()), Times.Never());
        }
    }
}
