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

namespace Microsoft.Azure.Commands.Intune
{
    using System.Management.Automation;
    using Management.Intune;
    using Management.Intune.Models;
    using System.Collections.Generic;
    using System.Globalization;

    /// <summary>
    /// Cmdlet to get apps for Android platform.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmIntuneAndroidMAMApp"), OutputType(typeof(List<Application>))]
    public sealed class GetIntuneAndroidMAMAppCmdlet : IntuneBaseCmdlet
    {
        /// <summary>
        /// Contains the cmdlet's execution logic.
        /// </summary>
        protected override void ProcessRecord()
        {
            string filter = string.Format(CultureInfo.InvariantCulture, IntuneConstants.PlatformFilterQueryParam, PlatformType.Android.ToString().ToLower());

            MultiPageGetter<Application> mpg = new MultiPageGetter<Application>();
            var items = mpg.GetAllResources(this.IntuneClient.GetApps, this.IntuneClient.GetAppsNext, this.AsuHostName, filter);
            List<Application> apps = new List<Application>(items.Count);
            foreach(var item in items)
            {
                apps.Add(item);
            }

            this.WriteObject(apps, enumerateCollection: true);
        }      
    }
}
