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

using Microsoft.Azure.Management.CosmosDB.Models;
using System;

namespace Microsoft.Azure.Commands.CosmosDB.Helpers
{
    internal static class ThroughputHelper
    {
        private static int? Throughput;
        private static int? AutoscaleMaxThroughput;

        public static ThroughputSettingsUpdateParameters CreateThroughputSettingsObject(int? throughput = null, int? autoscaleMaxThroughput = null)
        {
            Throughput = throughput;
            AutoscaleMaxThroughput = autoscaleMaxThroughput;

            ThroughputHelper.ThroughputValidation(validateBothPresent:true);
            ThroughputSettingsUpdateParameters throughputSettingsUpdateParameters = new ThroughputSettingsUpdateParameters();
            if (throughput != null)
            {
                throughputSettingsUpdateParameters.Resource = new ThroughputSettingsResource
                {
                    Throughput = throughput.Value
                };
            }
            else if (autoscaleMaxThroughput != null)
            {
                throughputSettingsUpdateParameters.Resource = new ThroughputSettingsResource
                {
                    AutoscaleSettings = new AutoscaleSettingsResource { MaxThroughput = autoscaleMaxThroughput.Value }
                };
            }

            return throughputSettingsUpdateParameters;
        }

        public static CreateUpdateOptions PopulateCreateUpdateOptions(int? throughput = null, int? autoscaleMaxThroughput = null)
        {
            Throughput = throughput;
            AutoscaleMaxThroughput = autoscaleMaxThroughput;
            ThroughputHelper.ThroughputValidation();

            CreateUpdateOptions createUpdateOptions = new CreateUpdateOptions();

            if (Throughput != null)
            {
                createUpdateOptions.Throughput = Throughput.Value;
            }
            else if(autoscaleMaxThroughput != null)
            {
                createUpdateOptions.AutoscaleSettings = new AutoscaleSettings { MaxThroughput = AutoscaleMaxThroughput.Value };
            }

            return createUpdateOptions;
        }

        private static void ThroughputValidation(bool validateBothPresent = false)
        {
            if (Throughput != null && AutoscaleMaxThroughput != null)
            {
                throw new Exception("BadRequest: Do not provide both Throughput and AutoscaleMaxThroughput.");
            }
            else if (Throughput == null && AutoscaleMaxThroughput == null && validateBothPresent == true)
            {
                throw new Exception("BadRequest: Please provide either Throughput or AutoscaleMaxThroughput.");
            }
            return;
        }

    }
}