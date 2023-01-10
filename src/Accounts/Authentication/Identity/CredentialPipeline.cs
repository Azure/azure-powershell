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
using System;

namespace Microsoft.Azure.PowerShell.Authenticators.Identity
{
    internal class CredentialPipeline
    {
        private static readonly Lazy<CredentialPipeline> s_singleton = new Lazy<CredentialPipeline>(() => new CredentialPipeline(new TokenCredentialOptions()));

        private CredentialPipeline(TokenCredentialOptions options)
        {
            AuthorityHost = options.AuthorityHost;

            HttpPipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new CredentialResponseClassifier());
        }

        public CredentialPipeline(Uri authorityHost, HttpPipeline httpPipeline)
        {
            AuthorityHost = authorityHost;

            HttpPipeline = httpPipeline;
        }

        public static CredentialPipeline GetInstance(TokenCredentialOptions options)
        {
            return options is null ? s_singleton.Value : new CredentialPipeline(options);
        }

        public Uri AuthorityHost { get; }

        public HttpPipeline HttpPipeline { get; }

        private class CredentialResponseClassifier : ResponseClassifier
        {
            public override bool IsRetriableResponse(HttpMessage message)
            {
                return base.IsRetriableResponse(message) || message.Response.Status == 404;
            }
        }
    }
}
