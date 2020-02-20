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

using Microsoft.Azure.Commands.IotCentral.Models;
using Microsoft.Azure.Management.IotCentral.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.IotCentral.Common
{
    public static class IotCentralUtils
    {
        public static PSIotCentralApp ToPSIotCentralApp(App iotCentralApp)
        {
            return new PSIotCentralApp(iotCentralApp);
        }

        public static IEnumerable<PSIotCentralApp> ToPSIotCentralApps(IEnumerable<App> iotCentralApps)
        {
            return iotCentralApps.Select(app => ToPSIotCentralApp(app));
        }

        public static AppPatch CreateAppPatch(App iotCentralApp)
        {
            var copiedIotCenralApp = new AppPatch()
            {
                DisplayName = iotCentralApp.DisplayName,
                Tags = iotCentralApp.Tags,
                Subdomain = iotCentralApp.Subdomain
            };
            return copiedIotCenralApp;
        }
    }
}