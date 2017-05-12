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

using Hyak.Common;
using Microsoft.Azure.Commands.Profile.Errors;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Management.Automation;
using Xunit;

namespace Microsoft.Azure.Commands.Profile.Test
{
    public class ErrorResolutionTests
    {
        class TestHyakException : CloudException
        {
            public TestHyakException(string message, CloudHttpRequestErrorInfo request, CloudHttpResponseErrorInfo response) : base(message)
            {
                Request = request;
                Response = response;
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DoesNotThrowWithNullError()
        {
            var cmdlet = new ResolveError
            {
                Error = null,
                CommandRuntime = new MockCommandRuntime()
            };

            cmdlet.ExecuteCmdlet();
            cmdlet = new ResolveError
            {
                Error = new ErrorRecord[] { null, null },
                CommandRuntime = new MockCommandRuntime()
            };

            cmdlet.ExecuteCmdlet();
            cmdlet = new ResolveError
            {
                CommandRuntime = new MockCommandRuntime()
            };

            cmdlet.ExecuteCmdlet();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void HandlesExceptionError()
        {
            var runtime = new MockCommandRuntime();
            var hyakException = new Hyak.Common.CloudException("exception message")
            {
                Error = new Hyak.Common.CloudError { Code="HyakCode", Message="HyakError"},
                
            };
            var cmdlet = new ResolveError
            {
                Error = new [] 
                {
                    new ErrorRecord(new Exception("exception message"), "errorCode", ErrorCategory.AuthenticationError, this),
                    new ErrorRecord(, "errorCode", ErrorCategory.ConnectionError, this),
                    new ErrorRecord(new Microsoft.Rest.HttpOperationException("exception message"), "errorCode", ErrorCategory.AuthenticationError, this),
                },
                CommandRuntime = new MockCommandRuntime()
            };

            cmdlet.ExecuteCmdlet();
        }
    }
}
