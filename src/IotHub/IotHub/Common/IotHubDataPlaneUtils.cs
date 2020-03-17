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

namespace Microsoft.Azure.Commands.Management.IotHub.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Commands.Management.IotHub.Models;
    using Microsoft.Azure.Devices;
    using Microsoft.Azure.Devices.Shared;
    using Newtonsoft.Json;

    public static class IotHubDataPlaneUtils
    {
        public const string DeviceScopePrefix = "ms-azure-iot-edge://";
        public const string TracingAllowedForSku = "standard";
        public const string TracingProperty = "azureiot*com^dtracing^1";

        public static readonly string[] TracingAllowedForLocation = { "northeurope", "westus2", "west us 2", "southeastasia" };

        public static string GetEdgeDevices()
        {
            return "select * from devices where capabilities.iotEdge=true";
        }

        public static string GetNonEdgeDevices(string DeviceScope)
        {
            return $"select * from devices where capabilities.iotEdge=false and deviceScope='{DeviceScope}'";
        }

        public static Device ToDevice(PSDevice psDevice)
        {
            return IotHubUtils.ConvertObject<PSDevice, Device>(psDevice);
        }

        public static Module ToModule(PSModule psModule)
        {
            return IotHubUtils.ConvertObject<PSModule, Module>(psModule);
        }

        public static PSDevice ToPSDevice(Device device)
        {
            return IotHubUtils.ConvertObject<Device, PSDevice>(device);
        }

        public static IEnumerable<PSDevices> ToPSDevices(IEnumerable<Device> devices)
        {
            return IotHubUtils.ConvertObject<IEnumerable<Device>, IEnumerable<PSDevices>>(devices.ToList());
        }

        public static PSModule ToPSModule(Module module)
        {
            return IotHubUtils.ConvertObject<Module, PSModule>(module);
        }

        public static IEnumerable<PSModules> ToPSModules(IEnumerable<Module> modules)
        {
            return IotHubUtils.ConvertObject<IEnumerable<Module>, IEnumerable<PSModules>>(modules.ToList());
        }

        public static void ValidateDeviceTracing(string DeviceId, string Sku, string Location, bool IsEdgeDevice)
        {
            if (!TracingAllowedForLocation.Any(location => location.Equals(Location, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException($"Distributed tracing isn\'t supported for the hub located at \"{Location}\"");
            }
            if (!TracingAllowedForSku.Equals(Sku, StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException($"Distributed tracing isn\'t supported for the hub belongs to \"{Sku}\" sku tier.");
            }
            if (IsEdgeDevice)
            {
                throw new ArgumentException($"The device \"{DeviceId}\" should be non-edge device.");
            }
        }

        public static PSDeviceTracing GetDeviceTracing(string DeviceId, Twin deviceTwin)
        {
            PSDeviceTracing psDeviceTracing = new PSDeviceTracing
            {
                DeviceId = DeviceId,
                TracingOption = new PSDistributedTracing() { SamplingMode = PSDistributedTracingSamplingMode.Disabled, SamplingRate = 0 },
                IsSynced = false
            };

            if (deviceTwin.Properties.Desired.Contains(TracingProperty))
            {
                psDeviceTracing.TracingOption = JsonConvert.DeserializeObject<PSDistributedTracing>(deviceTwin.Properties.Desired[TracingProperty].ToString());
            }

            if (deviceTwin.Properties.Reported.Contains(TracingProperty))
            {
                PSDistributedTracing psReportedDistributedTracing = JsonConvert.DeserializeObject<PSDistributedTracing>(deviceTwin.Properties.Reported[TracingProperty].ToString());
                if (psReportedDistributedTracing != null)
                {
                    psDeviceTracing.IsSynced = (psDeviceTracing.TracingOption.SamplingMode.Equals(psReportedDistributedTracing.SamplingMode) && psDeviceTracing.TracingOption.SamplingRate.Equals(psReportedDistributedTracing.SamplingRate));
                }
            }

            return psDeviceTracing;
        }
    }
}