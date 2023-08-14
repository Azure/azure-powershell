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

using Microsoft.Azure.Management.HDInsight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Commands.HDInsight.Models.Management;

namespace Microsoft.Azure.Commands.HDInsight.Models
{
    public class AzureHDInsightRole
    {
        public AzureHDInsightRole() { }

        public AzureHDInsightRole(string name = null, int? minInstanceCount = null, int? targetInstanceCount = null, AzureHDInsightAutoscale autoscaleConfiguration = null, AzureHDInsightHardwareProfile hardwareProfile = null, AzureHDInsightOsProfile osProfile = null, AzureHDInsightVirtualNetworkProfile virtualNetworkProfile = null, IList<AzureHDInsightDataDisksGroups> dataDisksGroups = null, IList<AzureHDInsightScriptAction> scriptActions = null)
        {
            Name = name;
            MinInstanceCount = minInstanceCount;
            TargetInstanceCount = targetInstanceCount;
            AutoscaleConfiguration = autoscaleConfiguration;
            HardwareProfile = hardwareProfile;
            OsProfile = osProfile;
            VirtualNetworkProfile = virtualNetworkProfile;
            DataDisksGroups = dataDisksGroups;
            ScriptActions = scriptActions;
        }

        public AzureHDInsightRole(Role role)
        {
            Name = role.Name;
            MinInstanceCount = role.MinInstanceCount;
            TargetInstanceCount = role.TargetInstanceCount;
            AutoscaleConfiguration = role.AutoscaleConfiguration != null ? new AzureHDInsightAutoscale(role.AutoscaleConfiguration) : null;
            HardwareProfile = role.HardwareProfile != null ? new AzureHDInsightHardwareProfile(role.HardwareProfile) : null;
            OsProfile = role.OsProfile != null ? new AzureHDInsightOsProfile(role.OsProfile) : null;
            VirtualNetworkProfile = role.VirtualNetworkProfile != null ? new AzureHDInsightVirtualNetworkProfile(role.VirtualNetworkProfile) : null;
            DataDisksGroups = role.DataDisksGroups?.Select(dataDisk => new AzureHDInsightDataDisksGroups(dataDisk)).ToList();
            ScriptActions = role.ScriptActions?.Select(script => new AzureHDInsightScriptAction(script)).ToList();
        }

        /// <summary>
        /// Gets or sets the name of the role.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the minimum instance count of the cluster.
        /// </summary>
        public int? MinInstanceCount { get; set; }

        /// <summary>
        /// Gets or sets the instance count of the cluster.
        /// </summary>
        public int? TargetInstanceCount { get; set; }

        /// <summary>
        /// Gets or sets the autoscale configurations.
        /// </summary>
        public AzureHDInsightAutoscale AutoscaleConfiguration { get; set; }

        /// <summary>
        /// Gets or sets the hardware profile.
        /// </summary>
        public AzureHDInsightHardwareProfile HardwareProfile { get; set; }

        /// <summary>
        /// Gets or sets the operating system profile.
        /// </summary>
        public AzureHDInsightOsProfile OsProfile { get; set; }

        /// <summary>
        /// Gets or sets the virtual network profile.
        /// </summary>
        public AzureHDInsightVirtualNetworkProfile VirtualNetworkProfile { get; set; }

        /// <summary>
        /// Gets or sets the data disks groups for the role.
        /// </summary>
        public IList<AzureHDInsightDataDisksGroups> DataDisksGroups { get; set; }

        /// <summary>
        /// Gets or sets the list of script actions on the role.
        /// </summary>
        public IList<AzureHDInsightScriptAction> ScriptActions { get; set; }
    }
}
