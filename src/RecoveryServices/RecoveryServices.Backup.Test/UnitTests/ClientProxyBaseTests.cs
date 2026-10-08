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

using System.Net;
using System.Net.Security;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS;
using Xunit;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Test.UnitTests
{
    public class ClientProxyBaseTests
    {
        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void ConstructorPreservesCertificateValidationCallback(bool hasExistingCallback)
        {
            var originalCallback = ServicePointManager.ServerCertificateValidationCallback;
            RemoteCertificateValidationCallback expectedCallback = hasExistingCallback
                ? new RemoteCertificateValidationCallback((sender, certificate, chain, errors) => errors == SslPolicyErrors.None)
                : null;

            // This assembly disables parallelization; restore shared state even if the assertion fails.
            try
            {
                ServicePointManager.ServerCertificateValidationCallback = expectedCallback;

                var proxy = new ClientProxyBase(null);

                Assert.Same(expectedCallback, ServicePointManager.ServerCertificateValidationCallback);
                Assert.False(string.IsNullOrEmpty(proxy.GetClientRequestId()));
            }
            finally
            {
                ServicePointManager.ServerCertificateValidationCallback = originalCallback;
            }
        }
    }
}
