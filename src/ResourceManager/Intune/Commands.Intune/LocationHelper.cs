using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Authorization;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Resources;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
using Newtonsoft.Json.Linq;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.RestClients;
using System.Threading;

namespace Commands.Intune
{
    internal static class LocationHelper
    {
        private static string asuName = null;
        private static string apiVersion = "2015-01-08-alpha";
        private static string resourceId = "/providers/Microsoft.Intune/locations/hostName";

        public static string GetLocation(ResourceManagerRestRestClient rmClient, CancellationToken cancelToken)
        {
            if (asuName == null)
            {
                Task.Run(
                    async () =>
                    {
                        dynamic location = await rmClient.GetResource<JObject>(resourceId, apiVersion, cancelToken);
                        dynamic properties = location.properties;
                        asuName = properties.hostName;
                    }).Wait();
            }

            return asuName;
        }

    }
}
