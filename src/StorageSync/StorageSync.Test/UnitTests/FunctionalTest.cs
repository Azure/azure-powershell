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

namespace Microsoft.Azure.Commands.StorageSync.Test.UnitTests
{
    using System.Collections;
    using System.Management.Automation;
    using System.Management.Automation.Remoting;
    using System.Security;
    using Microsoft.Azure.Commands.StorageSync.Evaluation.Cmdlets;
    using Xunit;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;

    /// <summary>
    /// Class FunctionalTest.
    /// </summary>
    public class FunctionalTest
    {

        /// <summary>
        /// The computer name
        /// </summary>
        private readonly string _computerName;
        /// <summary>
        /// Initializes a new instance of the <see cref="FunctionalTest"/> class.
        /// </summary>
        public FunctionalTest()
        {
            _computerName = "windows-2012-r2.redmond.corp.microsoft.com";
        }

        /// <summary>
        /// Defines the test method WhenComputerNameDoestNotExistsItThrows.
        /// </summary>
        [Fact(Skip = "Depends on external artefacts")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]  
        public void WhenComputerNameDoestNotExistsItThrows()
        {
            // Prepare
            InvokeCompatibilityCheckCmdlet cmdlet = new InvokeCompatibilityCheckCmdlet()
            {
                ComputerName = "non_existent_computer_name"
            };

            // Exercise
            IEnumerator results = cmdlet.Invoke().GetEnumerator();
            PSRemotingTransportException thrownException = Assert.Throws<PSRemotingTransportException>(() => results.MoveNext());

            // Verify
            Assert.Contains("Cannot find the computer", thrownException.Message);

        }

        /// <summary>
        /// Defines the test method WhenCredentialsAreIncorrectItThrows.
        /// </summary>
        [Fact(Skip = "Depends on external artefacts")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]  
        public void WhenCredentialsAreIncorrectItThrows()
        {
            SecureString secureInvalidPassword = CreateSecureStringFrom("invalid_password");
            InvokeCompatibilityCheckCmdlet cmdlet = new InvokeCompatibilityCheckCmdlet
            {
                ComputerName = _computerName,
                Credential = new PSCredential("invalid_username", secureInvalidPassword)
            };
           

            IEnumerator results = cmdlet.Invoke().GetEnumerator();
            PSRemotingTransportException thrownException = Assert.Throws<PSRemotingTransportException>(() => results.MoveNext());

            // Verify
            Assert.Contains("The user name or password is incorrect.", thrownException.Message);
        }

        /// <summary>
        /// Creates the secure string from.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns>SecureString.</returns>
        private SecureString CreateSecureStringFrom(string s)
        {
            SecureString ss = new SecureString();
            foreach (char c in s)
            {
                ss.AppendChar(c);
            }

            return ss;
        }
    }
}
