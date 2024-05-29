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
using Azure.Core;
using System.Linq;
using System.Reflection;

namespace Microsoft.Azure.PowerShell.Authenticators.Identity.Core
{
    internal class ClientDiagnostics : DiagnosticScopeFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientDiagnostics"/> class.
        /// </summary>
        /// <param name="options">The customer provided client options object.</param>
        /// <param name="suppressNestedClientActivities">Flag controlling if <see cref="System.Diagnostics.Activity"/>
        ///  created by this <see cref="ClientDiagnostics"/> for client method calls should be suppressed when called
        ///  by other Azure SDK client methods.  It's recommended to set it to true for new clients; use default (null)
        ///  for backward compatibility reasons, or set it to false to explicitly disable suppression for specific cases.
        ///  The default value could change in the future, the flag should be only set to false if suppression for the client
        ///  should never be enabled.</param>
        public ClientDiagnostics(ClientOptions options, bool suppressNestedClientActivities = default)
                    : this(options.GetType().Namespace,
                    GetResourceProviderNamespace(options.GetType().Assembly),
                    options.Diagnostics,
                    suppressNestedClientActivities)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientDiagnostics"/> class.
        /// </summary>
        /// <param name="optionsNamespace">Namespace of the client class, such as Azure.Storage or Azure.AppConfiguration.</param>
        /// <param name="providerNamespace">Azure Resource Provider namespace of the Azure service SDK is primarily used for.</param>
        /// <param name="diagnosticsOptions">The customer provided client diagnostics options.</param>
        /// <param name="suppressNestedClientActivities">Flag controlling if <see cref="System.Diagnostics.Activity"/>
        ///  created by this <see cref="ClientDiagnostics"/> for client method calls should be suppressed when called
        ///  by other Azure SDK client methods.  It's recommended to set it to true for new clients, use default (null) for old clients
        ///  for backward compatibility reasons, or set it to false to explicitly disable suppression for specific cases.
        ///  The default value could change in the future, the flag should be only set to false if suppression for the client
        ///  should never be enabled.</param>
        public ClientDiagnostics(string optionsNamespace, string providerNamespace, DiagnosticsOptions diagnosticsOptions, bool suppressNestedClientActivities = default)
            : base(optionsNamespace, providerNamespace, diagnosticsOptions.IsDistributedTracingEnabled, suppressNestedClientActivities)
        {
        }

        internal static HttpMessageSanitizer CreateMessageSanitizer(DiagnosticsOptions diagnostics)
        {
            return new HttpMessageSanitizer(
                diagnostics.LoggedQueryParameters.ToArray(),
                diagnostics.LoggedHeaderNames.ToArray());
        }

        internal static string GetResourceProviderNamespace(Assembly assembly)
        {
            foreach (var customAttribute in assembly.GetCustomAttributes(true))
            {
                // Weak bind internal shared type
                var attributeType = customAttribute.GetType();
                if (attributeType.Name == "AzureResourceProviderNamespaceAttribute")
                {
                    return attributeType.GetProperty("ResourceProviderNamespace")?.GetValue(customAttribute) as string;
                }
            }

            return null;
        }
    }
}
