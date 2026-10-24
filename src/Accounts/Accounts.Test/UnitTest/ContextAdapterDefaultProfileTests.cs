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

using Microsoft.Azure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Profile.Models.Core;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Runtime.CompilerServices;
using Xunit;

namespace Microsoft.Azure.Commands.Profile.Test.UnitTest
{
    /// <summary>
    /// Verifies that ContextAdapter honors the -DefaultProfile parameter of AutoRest-generated cmdlets
    /// instead of always using the process-wide default context.
    /// </summary>
    public class ContextAdapterDefaultProfileTests : RMTestBase
    {
        private readonly string globalSubscriptionId;
        private readonly string passedSubscriptionId = Guid.NewGuid().ToString();

        public ContextAdapterDefaultProfileTests()
        {
            globalSubscriptionId = currentProfile.DefaultContext.Subscription.Id;
        }

        // InvocationInfo has no public constructor, so build an uninitialized instance and set its
        // BoundParameters via the non-public setter.
        private static InvocationInfo CreateInvocationInfo(IDictionary<string, object> boundParameters)
        {
            var invocationInfo = (InvocationInfo)RuntimeHelpers.GetUninitializedObject(typeof(InvocationInfo));
            if (boundParameters != null)
            {
                var setter = typeof(InvocationInfo).GetProperty(nameof(InvocationInfo.BoundParameters)).GetSetMethod(nonPublic: true);
                setter.Invoke(invocationInfo, new object[] { new Dictionary<string, object>(boundParameters) });
            }
            return invocationInfo;
        }

        private PSAzureContext CreatePassedContext()
        {
            var subscription = new AzureSubscription { Id = passedSubscriptionId, Name = "passed" };
            var account = new AzureAccount { Id = "passed", Type = AzureAccount.AccountType.User };
            var context = new AzureContext(
                subscription,
                account,
                AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud],
                new AzureTenant { Id = Guid.NewGuid().ToString(), Directory = "passeddomain.onmicrosoft.com" });
            return new PSAzureContext(context);
        }

        private static object GetSubscriptionId(IDictionary<string, object> boundParameters)
        {
            return ContextAdapter.Instance.GetParameterValue(null, null, CreateInvocationInfo(boundParameters), null, "subscriptionId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DefaultProfileWithContext_UsesPassedContext()
        {
            var boundParameters = new Dictionary<string, object>
            {
                { "DefaultProfile", new PSObject(CreatePassedContext()) }
            };
            Assert.Equal(passedSubscriptionId, GetSubscriptionId(boundParameters));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DefaultProfileWithProfile_UsesDefaultContextOfPassedProfile()
        {
            var boundParameters = new Dictionary<string, object>
            {
                { "DefaultProfile", new PSObject(new PSAzureProfile { Context = CreatePassedContext() }) }
            };
            Assert.Equal(passedSubscriptionId, GetSubscriptionId(boundParameters));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DefaultContext_StillUsesPassedContext()
        {
            var boundParameters = new Dictionary<string, object>
            {
                { "DefaultContext", new PSObject(CreatePassedContext()) }
            };
            Assert.Equal(passedSubscriptionId, GetSubscriptionId(boundParameters));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NoDefaultProfile_UsesGlobalContext()
        {
            Assert.Equal(globalSubscriptionId, GetSubscriptionId(new Dictionary<string, object>()));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NullBoundParameters_UsesGlobalContext()
        {
            Assert.Equal(globalSubscriptionId, GetSubscriptionId(null));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UnconvertibleDefaultProfile_UsesGlobalContext()
        {
            var boundParameters = new Dictionary<string, object>
            {
                { "DefaultProfile", new PSObject("not a context") }
            };
            Assert.Equal(globalSubscriptionId, GetSubscriptionId(boundParameters));
        }
    }
}
