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

using Microsoft.Azure.Management.HDInsight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Commands.HDInsight.Models.Management;

namespace Microsoft.Azure.Commands.HDInsight.Models
{
    public class AzureHDInsightDataDisksGroups
    {
        public AzureHDInsightDataDisksGroups() { }

        public AzureHDInsightDataDisksGroups(int? disksPerNode = null, string storageAccountType = null, int? diskSizeGB = null)
        {
            DisksPerNode = disksPerNode;
            StorageAccountType = storageAccountType;
            DiskSizeGB = diskSizeGB;
        }

        public AzureHDInsightDataDisksGroups(DataDisksGroups dataDisksGroups)
        {
            DisksPerNode = dataDisksGroups.DisksPerNode;
            StorageAccountType = dataDisksGroups.StorageAccountType;
            DiskSizeGB = dataDisksGroups.DiskSizeGB;
        }

        /// <summary>
        /// Gets or sets the number of disks per node.
        /// </summary>
        public int? DisksPerNode { get; set; }

        /// <summary>
        /// Gets readOnly. The storage account type. Do not set this value.
        /// </summary>
        public string StorageAccountType { get; }

        /// <summary>
        /// Gets readOnly. The DiskSize in GB. Do not set this value.
        /// </summary>
        public int? DiskSizeGB { get; }
    }
}
