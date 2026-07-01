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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using Xunit;

namespace Microsoft.Azure.Authentication.Test.UnitTests
{
    public class AgenticSessionTests : IDisposable
    {
        private readonly string _originalEnvValue;

        public AgenticSessionTests()
        {
            _originalEnvValue = Environment.GetEnvironmentVariable(AgenticSession.AgentSessionIdEnvVarName);
            Environment.SetEnvironmentVariable(AgenticSession.AgentSessionIdEnvVarName, null);
        }

        public void Dispose()
        {
            Environment.SetEnvironmentVariable(AgenticSession.AgentSessionIdEnvVarName, _originalEnvValue);
        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.CheckIn)]
        public void TryGetSessionId_ReturnsNull_WhenEnvVarNotSet()
        {
            Assert.Null(AgenticSession.TryGetSessionId());
            Assert.False(AgenticSession.IsActive());
        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.CheckIn)]
        public void TryGetSessionId_ReturnsNull_WhenEnvVarIsEmpty()
        {
            Environment.SetEnvironmentVariable(AgenticSession.AgentSessionIdEnvVarName, string.Empty);
            Assert.Null(AgenticSession.TryGetSessionId());
            Assert.False(AgenticSession.IsActive());
        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.CheckIn)]
        public void TryGetSessionId_ReturnsValue_WhenEnvVarIsSet()
        {
            Environment.SetEnvironmentVariable(AgenticSession.AgentSessionIdEnvVarName, "sess-456");
            Assert.Equal("sess-456", AgenticSession.TryGetSessionId());
            Assert.True(AgenticSession.IsActive());
        }
    }
}
