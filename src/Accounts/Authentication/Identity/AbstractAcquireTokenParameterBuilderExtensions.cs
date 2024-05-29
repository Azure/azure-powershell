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
//

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace Microsoft.Azure.PowerShell.Authenticators.Identity
{
    internal static class AbstractAcquireTokenParameterBuilderExtensions
    {
        public static async ValueTask<AuthenticationResult> ExecuteAsync<T>(this AbstractAcquireTokenParameterBuilder<T> builder, bool async, CancellationToken cancellationToken)
            where T : AbstractAcquireTokenParameterBuilder<T>
        {
            Microsoft.Identity.Client.AuthenticationResult result = async
                ? await builder.ExecuteAsync(cancellationToken).ConfigureAwait(false)
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
                : builder.ExecuteAsync(cancellationToken).GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.

            return result;
        }
    }
}
