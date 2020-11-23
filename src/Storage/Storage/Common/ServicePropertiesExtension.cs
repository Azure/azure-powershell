﻿// ----------------------------------------------------------------------------------
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

namespace Microsoft.WindowsAzure.Commands.Storage.Common
{
    using Microsoft.Azure.Storage.Shared.Protocol;
    using XTable = Microsoft.Azure.Cosmos.Table;

    public static class ServicePropertiesExtension
    {
        /// <summary>
        /// Clean all the settings on the ServiceProperties project
        /// </summary>
        /// <param name="serviceProperties">Service properties</param>
        internal static void Clean(this ServiceProperties serviceProperties)
        {
            serviceProperties.Logging = null;
            serviceProperties.HourMetrics = null;
            serviceProperties.MinuteMetrics = null;
            serviceProperties.Cors = null;
            serviceProperties.DefaultServiceVersion = null;
            serviceProperties.DeleteRetentionPolicy = null;
        }

        /// <summary>
        /// Clean all the settings on the ServiceProperties project
        /// </summary>
        /// <param name="serviceProperties">Service properties</param>
        internal static void Clean(this XTable.ServiceProperties serviceProperties)
        {
            serviceProperties.Logging = null;
            serviceProperties.HourMetrics = null;
            serviceProperties.MinuteMetrics = null;
            serviceProperties.Cors = null;
            serviceProperties.DefaultServiceVersion = null;
        }
    }
}
