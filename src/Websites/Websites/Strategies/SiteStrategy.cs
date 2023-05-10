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

using Microsoft.Azure.Management.WebSites;
using Microsoft.Azure.Management.WebSites.Models;
using Microsoft.Azure.Management.Internal.Resources.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Common.Strategies.WebApps
{
    static class SiteStrategy
    {
        public static ResourceStrategy<Site> Strategy { get; } = AppServicePolicy.Create(
            provider: "sites",
            getOperations: client => client.WebApps,
            getAsync: (o, p) => o.GetAsync(p.ResourceGroupName, p.Name, p.CancellationToken),
            createOrUpdateAsync: (o, p) => o.CreateOrUpdateAsync(p.ResourceGroupName, p.Name, p.Model, cancellationToken: p.CancellationToken),
            createTime: _ => 20,
            compulsoryLocation: true);

        public static ResourceConfig<Site> CreateSiteConfig(this ResourceConfig<ResourceGroup> resourceGroup,
            ResourceConfig<AppServicePlan> plan, string siteName, SiteConfig siteConfig = null, IDictionary<string, string> tags=null) =>
            Strategy.CreateResourceConfig(
                resourceGroup,
                siteName,
                createModel: engine =>
                    new Site(location: null, name: siteName, tags:tags)
                    {
                        //Name = siteName,
                        SiteConfig = siteConfig,
                        ServerFarmId = engine.GetId(plan),
                        Tags = tags
                    });
    }
}
