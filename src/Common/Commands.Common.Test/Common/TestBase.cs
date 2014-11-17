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

using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Models;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.WindowsAzure.Commands.Test.Utilities.Common
{
    /// <summary>
    /// Base class for Microsoft Azure PowerShell unit tests.
    /// </summary>
    public abstract class TestBase
    {
        public TestBase()
        {
            BaseSetup();
        }

        /// <summary>
        /// Initialize the necessary environment for the tests.
        /// </summary>
        [TestInitialize]
        public void BaseSetup()
        {
            if (ProfileClient.DataStore != null && !(ProfileClient.DataStore is MockDataStore))
            {
                ProfileClient.DataStore = new MockDataStore();
            }
            if (AzureSession.CurrentContext.Subscription == null)
            {
                var newGuid = Guid.NewGuid();
                AzureSession.SetCurrentContext(
                    new AzureSubscription { Id = newGuid, Name = "test", Environment = EnvironmentName.AzureCloud, Account = "test" },
                    null,
                    new AzureAccount
                    {
                        Id = "test",
                        Type = AzureAccount.AccountType.User,
                        Properties = new Dictionary<AzureAccount.Property, string>
                        {
                            {AzureAccount.Property.Subscriptions, newGuid.ToString()}
                        }
                    });
            }
            AzureSession.AuthenticationFactory = new MockTokenAuthenticationFactory();
        }

        /// <summary>
        /// Gets or sets a reference to the TestContext used for interacting
        /// with the test framework.
        /// </summary>
        public TestContext TestContext { get; set; }

        /// <summary>
        /// Log a message with the test framework.
        /// </summary>
        /// <param name="format">Format string.</param>
        /// <param name="args">Arguments.</param>
        public void Log(string format, params object[] args)
        {
            if (TestContext != null)
            {
                TestContext.WriteLine(format, args);
            }
            else
            {
                Console.WriteLine(format, args);
            }
        }
    }
}
