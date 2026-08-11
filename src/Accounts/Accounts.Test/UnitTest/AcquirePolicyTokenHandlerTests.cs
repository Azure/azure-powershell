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
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Common;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.Commands.Profile.Test.UnitTest
{
    // Matches the PipelineChangeDelegate alias declared in ContextAdapter.cs so the internal
    // AddChangeSafetyPolicyTokenHandler overload can be invoked directly from tests.
    using PipelineStep = Func<HttpRequestMessage, CancellationToken, Action, Func<string, CancellationToken, Func<EventArgs>, Task>, Func<HttpRequestMessage, CancellationToken, Action, Func<string, CancellationToken, Func<EventArgs>, Task>, Task<HttpResponseMessage>>, Task<HttpResponseMessage>>;

    public class AcquirePolicyTokenHandlerTests
    {
        public AcquirePolicyTokenHandlerTests()
        {
            // ContextAdapter's constructor reads AzureSession.Instance, so ensure a session exists.
            AzureSessionInitializer.CreateOrReplaceSession(new MemoryDataStore());
        }

        // InvocationInfo has no public constructor, so build an uninitialized instance and set its
        // BoundParameters via the non-public setter to exercise the handler's parameter evaluation.
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

        private static int CountAppendedSteps(IDictionary<string, object> boundParameters)
        {
            int appended = 0;
            Action<PipelineStep> appendStep = _ => appended++;
            ContextAdapter.Instance.AddChangeSafetyPolicyTokenHandler(CreateInvocationInfo(boundParameters), appendStep);
            return appended;
        }

        [Fact]
        public void NoChangeSafetyParameters_DoesNotAppendStep()
        {
            var boundParameters = new Dictionary<string, object>();
            Assert.Equal(0, CountAppendedSteps(boundParameters));
        }

        [Fact]
        public void NullBoundParameters_DoesNotAppendStep()
        {
            Assert.Equal(0, CountAppendedSteps(null));
        }

        [Fact]
        public void AcquirePolicyTokenSwitchPresent_AppendsSingleStep()
        {
            var boundParameters = new Dictionary<string, object>
            {
                { ChangeSafetyParameters.AcquirePolicyTokenParamName, new SwitchParameter(true) }
            };
            Assert.Equal(1, CountAppendedSteps(boundParameters));
        }

        [Fact]
        public void AcquirePolicyTokenSwitchFalse_DoesNotAppendStep()
        {
            var boundParameters = new Dictionary<string, object>
            {
                { ChangeSafetyParameters.AcquirePolicyTokenParamName, new SwitchParameter(false) }
            };
            Assert.Equal(0, CountAppendedSteps(boundParameters));
        }

        [Fact]
        public void ChangeReferenceNonEmpty_AppendsSingleStep()
        {
            var boundParameters = new Dictionary<string, object>
            {
                { ChangeSafetyParameters.ChangeReferenceParamName, "/subscriptions/change-ref" }
            };
            Assert.Equal(1, CountAppendedSteps(boundParameters));
        }

        [Fact]
        public void ChangeReferenceEmpty_DoesNotAppendStep()
        {
            var boundParameters = new Dictionary<string, object>
            {
                { ChangeSafetyParameters.ChangeReferenceParamName, string.Empty }
            };
            Assert.Equal(0, CountAppendedSteps(boundParameters));
        }

        [Fact]
        public void ChangeReferenceWhitespace_DoesNotAppendStep()
        {
            var boundParameters = new Dictionary<string, object>
            {
                { ChangeSafetyParameters.ChangeReferenceParamName, "   " }
            };
            Assert.Equal(0, CountAppendedSteps(boundParameters));
        }

        [Fact]
        public void BothAcquireSwitchAndChangeReference_AppendsSingleStep()
        {
            var boundParameters = new Dictionary<string, object>
            {
                { ChangeSafetyParameters.AcquirePolicyTokenParamName, new SwitchParameter(true) },
                { ChangeSafetyParameters.ChangeReferenceParamName, "/subscriptions/change-ref" }
            };
            Assert.Equal(1, CountAppendedSteps(boundParameters));
        }
    }
}
