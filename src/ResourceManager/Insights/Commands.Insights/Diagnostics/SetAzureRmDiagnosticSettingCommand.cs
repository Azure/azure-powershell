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

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using System.Threading;
using System.Xml;
using Microsoft.Azure.Commands.Insights.OutputClasses;
using Microsoft.Azure.Management.Insights.Models;

namespace Microsoft.Azure.Commands.Insights.Diagnostics
{
    /// <summary>
    /// Get the list of events for at a subscription level.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmDiagnosticSetting"), OutputType(typeof(PSServiceDiagnosticSettings))]
    public class SetAzureRmDiagnosticSettingCommand : ManagementCmdletBase
    {
        #region Parameters declarations

        /// <summary>
        /// Gets or sets the resourceId parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the storage account parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The storage account id")]
        public string StorageAccountId { get; set; }

        /// <summary>
        /// Gets or sets the enable parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The value indicating whether the diagnostics should be enabled or disabled")]
        [ValidateNotNullOrEmpty]
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets the categories parameter of the cmdlet
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, HelpMessage = "The log categories")]
        public List<string> Categories { get; set; }

        /// <summary>
        /// Gets or sets the timegrain parameter of the cmdlet
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, HelpMessage = "The timegrains")]
        public List<string> Timegrains { get; set; }

        #endregion

        protected override void ProcessRecordInternal()
        {
            var putParameters = new ServiceDiagnosticSettingsPutParameters();
            
            if (this.Categories == null && this.Timegrains == null && !this.Enabled)
            {
                // This is the only case where no call to get diagnostic settings is necessary. Since we are disabling everything, we just need to request stroage account false.

                putParameters.Properties = new ServiceDiagnosticSettings();
            }
            else
            {
                ServiceDiagnosticSettingsGetResponse getResponse = this.InsightsManagementClient.ServiceDiagnosticSettingsOperations.GetAsync(this.ResourceId, CancellationToken.None).Result;

                ServiceDiagnosticSettings properties = getResponse.Properties;

                if (this.Enabled && string.IsNullOrWhiteSpace(this.StorageAccountId))
                {
                    throw new ArgumentException("StorageAccountId can't be null when enabling");
                }

                if (!string.IsNullOrWhiteSpace(this.StorageAccountId))
                {
                    properties.StorageAccountId = this.StorageAccountId;
                }
                
                if (this.Categories == null)
                {
                    foreach (var log in properties.Logs)
                    {
                        log.Enabled = this.Enabled;
                    }
                }
                else
                {
                    foreach (string category in this.Categories)
                    {
                        LogSettings logSettings = properties.Logs.FirstOrDefault(x => string.Equals(x.Category, category, StringComparison.OrdinalIgnoreCase));

                        if (logSettings == null)
                        {
                            throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Log category '{0}' is not available for '{1}'", category, this.StorageAccountId));
                        }

                        logSettings.Enabled = this.Enabled;
                    }   
                }

                if (this.Timegrains == null)
                {
                    foreach (var metric in properties.Metrics)
                    {
                        metric.Enabled = this.Enabled;
                    }
                }
                else
                {
                    foreach (string timegrainString in this.Timegrains)
                    {
                        TimeSpan timegrain = XmlConvert.ToTimeSpan(timegrainString);
                        MetricSettings metricSettings = properties.Metrics.FirstOrDefault(x => TimeSpan.Equals(x.TimeGrain, timegrain));

                        if (metricSettings == null)
                        {
                            throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Metric timegrain '{0}' is not available for '{1}'", timegrainString, this.StorageAccountId));
                        }
                        metricSettings.Enabled = this.Enabled;
                    }
                }

                putParameters.Properties = properties;
            }

            this.InsightsManagementClient.ServiceDiagnosticSettingsOperations.PutAsync(this.ResourceId, putParameters, CancellationToken.None).Wait();
            PSServiceDiagnosticSettings psResult = new PSServiceDiagnosticSettings(putParameters.Properties);
            WriteObject(psResult);
        }
    }
}
