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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ServiceClientModel = Microsoft.Azure.Management.RecoveryServices.Backup.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models
{
    /// <summary>
    /// Backup policy constants.
    /// </summary>
    public class PolicyConstants
    {
        /// <summary>
        /// Maximum allowed duration length of retention.
        /// </summary>
        public const int MaxAllowedRetentionDurationCount = 9999;
        public const int MaxAllowedRetentionDurationCountWeekly = 5163;
        public const int MaxAllowedRetentionDurationCountMonthly = 1188;
        public const int MaxAllowedRetentionDurationCountYearly = 99;

        public const int AfsDailyRetentionDaysMax = 200;
        public const int AfsDailyRetentionDaysMin = 1;
        public const int AfsWeeklyRetentionMax = 200;
        public const int AfsWeeklyRetentionMin = 1;
        public const int AfsMonthlyRetentionMax = 120;
        public const int AfsMonthlyRetentionMin = 1;
        public const int AfsYearlyRetentionMax = 10;
        public const int AfsYearlyRetentionMin = 1;

        /// <summary>
        /// Maximum number of days in a month.
        /// </summary>
        public const int MaxAllowedDateInMonth = 28;

        // day constants
        public const int NumOfDaysInWeek = 7;
        public const int NumOfDaysInMonth = 31;
        public const int NumOfDaysInYear = 366;

        // week constants
        public const int NumOfWeeksInMonth = 4;
        public const int NumOfWeeksInYear = 52;

        // month constants
        public const int NumOfMonthsInYear = 12;

        // SQL constants
        public const int MaxAllowedRetentionDurationCountWeeklySql = 5163;
        public const int MaxAllowedRetentionDurationCountMonthlySql = 1188;
        public const int MaxAllowedRetentionDurationCountYearlySql = 99;

    }

    /// <summary>
    /// Trace utilities.
    /// </summary>
    public class TraceUtils
    {
        /// <summary>
        /// Returns a string which contains an enumeration of the given input list.
        /// </summary>
        /// <typeparam name="T">Type of the object in the list</typeparam>
        /// <param name="objList">List of input objects</param>
        /// <returns></returns>
        public static string GetString<T>(IEnumerable<T> objList)
        {
            return (objList == null) ? "null" : "{" + string.Join(", ", objList.Select(e => e.ToString())) + "}";
        }
    }

    /// <summary>
    /// ARM ID utilities.
    /// </summary>
    public class IdUtils
    {
        static readonly string UriFormat = @"/(Subscriptions|subscriptions)/(?<subscriptionsId>.+)"+
            "/(resourceGroups|resourcegroups)" +
            @"/(?<resourceGroupName>.+)/providers/(?<providersName>.+)" +
            "/vaults/(?<BackupVaultName>.+)/backupFabrics/(?<BackupFabricName>.+)" +
            "/protectionContainers/(?<containersName>.+)";
        static readonly Regex ResourceGroupRegex = new Regex(UriFormat, RegexOptions.Compiled);
        const string NameDelimiter = ";";
        const string IdDelimiter = "/";

        public class IdNames
        {
            public const string SubscriptionId = "Subscriptions";
            public const string ResourceGroup = "resourceGroups";
            public const string Provider = "providers";
            public const string Vault = "vaults";
            public const string BackupFabric = "backupFabrics";
            public const string ProtectionContainerName = "protectionContainers";
            public const string ProtectedItemName = "protectedItems";
        }

        /// <summary>
        /// Fetches the resource group name embedded in the ARM ID by parsing.
        /// </summary>
        /// <param name="id">ARM ID to parse</param>
        /// <returns></returns>
        public static string GetResourceGroupName(string id)
        {
            var match = ResourceGroupRegex.Match(id);
            if (match.Success)
            {
                var vmUniqueName = match.Groups["containersName"];
                if (vmUniqueName != null && vmUniqueName.Success)
                {
                    var vmNameInfo = vmUniqueName.Value.Split(NameDelimiter.ToCharArray());
                    if (vmNameInfo.Length == 3)
                    {
                        return vmNameInfo[1];
                    }
                    else if (vmNameInfo.Length == 4)
                    {
                        return vmNameInfo[2];
                    }
                    else
                    {
                        throw new Exception("Container name not in the expected format");
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Fetches the value embedded in the ARM ID, identified the provided input id, in the ARM ID.
        /// </summary>
        /// <param name="id">The ARM input ID</param>
        /// <param name="idName">Name of the value to be returned</param>
        /// <returns></returns>
        public static string GetValueByName(string id, string idName)
        {
            var parts = id.Split(IdDelimiter.ToArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index % 2)
                .ToList();

            var dict = parts[0].ToList().Zip(parts[1].ToList(), (k, v) => new { k, v })
                               .ToDictionary(x => x.k.Value, x => x.v.Value);

            return dict[idName];
        }

        /// <summary>
        /// Parses the name from the fully qualified ARM ID.
        /// URI format: Type;Name
        /// </summary>
        /// <param name="uri">Uri to be parsed</param>
        /// <returns></returns>
        public static string GetNameFromUri(string uri)
        {
            return uri.Substring(uri.IndexOf(NameDelimiter) + 1);
        }

        /// <summary>
        /// Extracts the VM name from the container uri.
        /// Format of container uri: WorkloadType;ContainerType;ResourceGroupName;VMName
        /// </summary>
        /// <param name="uri">Container uri from which to extract the name</param>
        /// <returns></returns>
        public static string GetVmNameFromContainerUri(string uri)
        {
            return uri.Split(NameDelimiter.ToCharArray())[4];
        }
    }

    /// <summary>
    /// Enum utilities.
    /// </summary>
    public class EnumUtils
    {
        /// <summary>
        /// Gets the enum of type T given the string equivalent.
        /// </summary>
        /// <typeparam name="T">Type of the enum represented by the string</typeparam>
        /// <param name="enumValue">String to be parsed</param>
        /// <returns></returns>
        public static T GetEnum<T>(string enumValue)
        {
            try
            {
                return (T)Enum.Parse(typeof(T), enumValue);
            }
            catch (Exception)
            {
                return default(T);
            }
        }
    }

    /// <summary>
    /// Conversion utilities.
    /// </summary>
    public class ConversionUtils
    {
        /// <summary>
        /// Returns the PS backup management type given the service client defined backup management type.
        /// </summary>
        /// <param name="backupManagementType">Service client backup management type</param>
        /// <returns>PowerShell backup management type</returns>
        public static BackupManagementType GetPsBackupManagementType(string backupManagementType)
        {
            switch (backupManagementType)
            {
                case ServiceClientModel.BackupManagementType.AzureIaasVM:
                    return BackupManagementType.AzureVM;
                case ServiceClientModel.BackupManagementType.MAB:
                    return BackupManagementType.MARS;
                case ServiceClientModel.BackupManagementType.DPM:
                    return BackupManagementType.SCDPM;
                case ServiceClientModel.BackupManagementType.AzureBackupServer:
                    return BackupManagementType.AzureBackupServer;
                case ServiceClientModel.BackupManagementType.AzureSql:
                    return BackupManagementType.AzureSQL;
                case ServiceClientModel.BackupManagementType.AzureStorage:
                    return BackupManagementType.AzureStorage;
                case ServiceClientModel.BackupManagementType.AzureWorkload:
                    return BackupManagementType.AzureWorkload;
                case "":
                    return BackupManagementType.NA;
                default:
                    throw new Exception("Unsupported BackupManagementType: " + backupManagementType);
            }
        }

        /// <summary>
        /// Returns the PS backup management type given the service client defined container type.
        /// </summary>
        /// <param name="containerType">Service client container type</param>
        /// <returns>PowerShell container type</returns>
        public static ContainerType GetPsContainerType(string containerType)
        {
            if (containerType == ServiceClientModel.BackupManagementType.AzureIaasVM)
            {
                return ContainerType.AzureVM;
            }
            else if (containerType == ServiceClientModel.BackupManagementType.MAB)
            {
                return ContainerType.Windows;
            }
            else if (containerType ==
                ServiceClientModel.BackupManagementType.AzureSql)
            {
                return ContainerType.AzureSQL;
            }
            else if (containerType ==
                ServiceClientModel.BackupManagementType.AzureStorage)
            {
                return ContainerType.AzureStorage;
            }
            else if (containerType ==
                ServiceClientModel.BackupManagementType.AzureWorkload)
            {
                return ContainerType.AzureVMAppContainer;
            }
            else
            {
                throw new Exception("Unsupported ContainerType: " + containerType);
            }
        }

        /// <summary>
        /// Returns the PS backup management type given the service client defined workload type.
        /// </summary>
        /// <param name="workloadType">Service client workload type</param>
        /// <returns>PowerShell workload type</returns>
        public static WorkloadType GetPsWorkloadType(string workloadType)
        {
            if (workloadType == ServiceClientModel.WorkloadType.VM.ToString())
            {
                return WorkloadType.AzureVM;
            }
            else if (workloadType == ServiceClientModel.WorkloadType.AzureSqlDb.ToString())
            {
                return WorkloadType.AzureSQLDatabase;
            }
            else if (workloadType == ServiceClientModel.WorkloadType.AzureFileShare)
            {
                return WorkloadType.AzureFiles;
            }
            else if (workloadType == ServiceClientModel.WorkloadType.SQLDataBase)
            {
                return WorkloadType.MSSQL;
            }
            else if (workloadType == "SQL")
            {
                return WorkloadType.MSSQL;
            }
            else if (workloadType == ServiceClientModel.WorkloadType.FileFolder)
            {
                return WorkloadType.FileFolder;
            }
            else
            {
                throw new Exception("Unsupported WorkloadType: " + workloadType);
            }
        }

        /// <summary>
        /// Returns the Service Client backup management type given the PS workload type.
        /// </summary>
        /// <param name="workloadType">PS workload type</param>
        /// <returns>Service Client workload type</returns>
        public static string GetServiceClientWorkloadType(string workloadType)
        {
            if (workloadType == WorkloadType.AzureVM.ToString())
            {
                return ServiceClientModel.WorkloadType.VM;
            }
            else if (workloadType == WorkloadType.AzureSQLDatabase.ToString())
            {
                return ServiceClientModel.WorkloadType.AzureSqlDb;
            }
            else if (workloadType == WorkloadType.AzureFiles.ToString())
            {
                return ServiceClientModel.WorkloadType.AzureFileShare;
            }
            else if (workloadType == WorkloadType.MSSQL.ToString())
            {
                return ServiceClientModel.WorkloadType.SQLDataBase;
            }
            else
            {
                throw new Exception("Unsupported WorkloadType: " + workloadType);
            }
        }

        /// <summary>
        /// Returns the ARM resource type from PS workload type
        /// </summary>
        /// <param name="workloadType">PS workload type</param>
        /// <returns>ARM resource type type</returns>
        public static string GetARMResourceType(string workloadType)
        {
            if (workloadType == WorkloadType.AzureVM.ToString())
            {
                return "Microsoft.Compute/virtualMachines";
            }
            else if (workloadType == WorkloadType.AzureFiles.ToString())
            {
                return "Microsoft.Storage/storageAccounts";
            }
            else if (workloadType == WorkloadType.MSSQL.ToString())
            {
                return "VMAppContainer";
            }

            throw new Exception("Unsupported WorkloadType: " + workloadType);
        }

        /// <summary>
        /// Returns the PS resource type from Arm workload type
        /// </summary>
        /// <param name="armType">Arm workload type</param>
        /// <returns>PS resource type type</returns>
        public static string GetWorkloadTypeFromArmType(string armType)
        {
            if (string.Compare(armType, "Microsoft.Compute/virtualMachines", ignoreCase: true) == 0 ||
                string.Compare(armType, "Microsoft.ClassicCompute/virtualMachines", ignoreCase: true) == 0)
            {
                return WorkloadType.AzureVM.ToString();
            }
            else if (string.Compare(armType, "Microsoft.Storage/storageAccounts", ignoreCase: true) == 0)
            {
                return WorkloadType.AzureFiles.ToString();
            }
            else if (string.Compare(armType, "VMAppContainer", ignoreCase: true) == 0)
            {
                return WorkloadType.MSSQL.ToString();
            }

            throw new Exception("Unsupported ArmType: " + armType);
        }
    }
}