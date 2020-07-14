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

using Microsoft.Azure.Management.WebSites.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System;

namespace Microsoft.Azure.Commands.WebApps.Models.WebApp
{
    class PSCloningInfo : CloningInfo
    {
        public PSCloningInfo(CloningInfo other)
            : base(
                  sourceWebAppId: other.SourceWebAppId,
                  sourceWebAppLocation: other.SourceWebAppLocation,
                  correlationId: other.CorrelationId,
                  overwrite: other.Overwrite,
                  cloneCustomHostNames: other.CloneCustomHostNames,
                  cloneSourceControl: other.CloneSourceControl,
                  hostingEnvironment: other.HostingEnvironment,
                  appSettingsOverrides: other.AppSettingsOverrides,
                  configureLoadBalancing: other.ConfigureLoadBalancing,
                  trafficManagerProfileId: other.TrafficManagerProfileId,
                  trafficManagerProfileName: other.TrafficManagerProfileName
                  )
        {

        }
    }
}
