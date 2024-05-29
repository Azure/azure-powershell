// Copyright (c) Microsoft Corporation. All rights reserved.
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
using Azure.Core.Pipeline;
using Azure.Identity;

using Microsoft.Azure.PowerShell.Authenticators.Identity.Core;
using Microsoft.Identity.Client;

using System;

namespace Microsoft.Azure.PowerShell.Authenticators.Identity
{
    internal class CredentialPipeline
    {
        private static readonly Lazy<CredentialPipeline> s_singleton = new Lazy<CredentialPipeline>(() => new CredentialPipeline(new TokenCredentialOptions()));

        private static readonly IScopeHandler _defaultScopeHandler = new ScopeHandler();

        private CredentialPipeline(TokenCredentialOptions options)
        {
            HttpPipeline = HttpPipelineBuilder.Build(new HttpPipelineOptions(options) { RequestFailedDetailsParser = new ManagedIdentityRequestFailedDetailsParser() });
            Diagnostics = new ClientDiagnostics(options);
        }

        public CredentialPipeline(HttpPipeline httpPipeline, ClientDiagnostics diagnostics)
        {
            HttpPipeline = httpPipeline;
            Diagnostics = diagnostics;
        }

        public static CredentialPipeline GetInstance(TokenCredentialOptions options)
        {
            return options is null ? s_singleton.Value : new CredentialPipeline(options);
        }

        public HttpPipeline HttpPipeline { get; }

        public ClientDiagnostics Diagnostics { get; }

        public IConfidentialClientApplication CreateMsalConfidentialClient(string tenantId, string clientId, string clientSecret)
        {
            return ConfidentialClientApplicationBuilder.Create(clientId).WithHttpClientFactory(new HttpPipelineClientFactory(HttpPipeline)).WithTenantId(tenantId).WithClientSecret(clientSecret).Build();
        }

        public CredentialDiagnosticScope StartGetTokenScope(string fullyQualifiedMethod, TokenRequestContext context)
        {
            IScopeHandler scopeHandler = ScopeGroupHandler.Current ?? _defaultScopeHandler;

            CredentialDiagnosticScope scope = new CredentialDiagnosticScope(Diagnostics, fullyQualifiedMethod, context, scopeHandler);
            scope.Start();
            return scope;
        }

        public CredentialDiagnosticScope StartGetTokenScopeGroup(string fullyQualifiedMethod, TokenRequestContext context)
        {
            var scopeHandler = new ScopeGroupHandler(fullyQualifiedMethod);

            CredentialDiagnosticScope scope = new CredentialDiagnosticScope(Diagnostics, fullyQualifiedMethod, context, scopeHandler);
            scope.Start();
            return scope;
        }

        private class CredentialResponseClassifier : ResponseClassifier
        {
            public override bool IsRetriableResponse(HttpMessage message)
            {
                return base.IsRetriableResponse(message) || message.Response.Status == 404;
            }
        }

        private class ScopeHandler : IScopeHandler
        {
            public DiagnosticScope CreateScope(ClientDiagnostics diagnostics, string name) => diagnostics.CreateScope(name);
            public void Start(string name, in DiagnosticScope scope) => scope.Start();
            public void Dispose(string name, in DiagnosticScope scope) => scope.Dispose();
            public void Fail(string name, in DiagnosticScope scope, Exception exception) => scope.Failed(exception);
        }
    }
}
