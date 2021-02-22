using Microsoft.Azure.Management.Synapse.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public static class SynapseConstants
    {
        public const string SynapsePrefix = "Synapse";

        public const string Workspace = nameof(Workspace);

        public const string WorkspaceName = nameof(WorkspaceName);

        public const string FirewallRuleName = nameof(FirewallRuleName);

        public const string FirewallRule = nameof(FirewallRule);

        public const string SparkPool = nameof(SparkPool);

        public const string AutoScale = nameof(AutoScale);

        public const string AutoPause = nameof(AutoPause);

        public const string SparkJob = nameof(SparkJob);

        public const string SparkStatement = nameof(SparkStatement);

        public const string SparkSession = nameof(SparkSession);

        public const string Timeout = nameof(Timeout);

        public const string SqlPool = nameof(SqlPool);

        public const string SqlPoolGeoBackup = nameof(SqlPoolGeoBackup);

        public const string DroppedSqlPool = nameof(DroppedSqlPool);

        public const string VulnerabilityAssessmentScanRecord = nameof(VulnerabilityAssessmentScanRecord);

        public const string VulnerabilityAssessmentScan = nameof(VulnerabilityAssessmentScan);

        public const string SqlPoolName = nameof(SqlPoolName);

        public const string RestorePoint = nameof(RestorePoint);

        public const string Sql = nameof(Sql);

        public const string AuditSetting = nameof(AuditSetting);

        public const string ActiveDirectoryAdministrator = nameof(ActiveDirectoryAdministrator);

        public const string AdvancedThreatProtectionSetting = nameof(AdvancedThreatProtectionSetting);

        public const string VulnerabilityAssessmentSetting = nameof(VulnerabilityAssessmentSetting);

        public const string TransparentDataEncryption = nameof(TransparentDataEncryption);

        public const string AdvancedDataSecurity = nameof(AdvancedDataSecurity);

        public const string AdvancedDataSecurityPolicy = nameof(AdvancedDataSecurityPolicy);

        public const string SqlDatabase = nameof(SqlDatabase);

        public const string SparkPoolName = nameof(SparkPoolName);

        public const string Job = nameof(Job);

        public const string RoleAssignment = nameof(RoleAssignment);

        public const string RoleDefinition = nameof(RoleDefinition);

        public const string SparkDotNetJarFile = "local:///usr/hdp/current/spark2-client/jars/microsoft-spark.jar";

        public const string SparkDotNetClassName = "org.apache.spark.deploy.dotnet.DotnetRunner";

        public const string SparkDotNetAssemblySearchPathsKey = "spark.yarn.appMasterEnv.DOTNET_ASSEMBLY_SEARCH_PATHS";

        public const string SparkDotNetUdfsFolderName = "udfs";

        public const string JarExtention = ".jar";

        public const string MainExecutableFile = nameof(MainExecutableFile);

        public const string IntegrationRuntime = nameof(IntegrationRuntime);

        public const string IntegrationRuntimeName = nameof(IntegrationRuntimeName);

        public const string IntegrationRuntimeTypeManaged = "Managed";

        public const string IntegrationRuntimeSelfhosted = "SelfHosted";

        public const string LinkedIntegrationRuntimeKeyAuth = "Key";

        public const string LinkedIntegrationRuntimeRbacAuth = "RBAC";

        public const string IntegrationRuntimeSelfhostedLinked = "SelfHosted(Linked)";

        public const string Key = nameof(Key);

        public const string Metric = nameof(Metric);

        public const string Node = nameof(Node);

        public const string Upgrade = nameof(Upgrade);

        public const string SubnetName = nameof(SubnetName);

        public const string IntegrationRuntimeLicenseIncluded = "LicenseIncluded";

        public const string IntegrationRuntimeBasePrice = "BasePrice";

        public const string Credential = nameof(Credential);

        public const string IntegrationRuntimeAutoUpdateEnabled = "On";

        public const string IntegrationRuntimeAutoUpdateDisabled = "Off";

        public const string Pipeline = nameof(Pipeline);

        public const string PipelineRun = nameof(PipelineRun);

        public const string ActivityRun = nameof(ActivityRun);

        public const string LinkedService = nameof(LinkedService);

        public const string Notebook = nameof(Notebook);

        // TODO: In future, we should expose the default version string of Spark SDK and use that value here.
        public const string SparkServiceEndpointApiVersion = "2019-11-01-priview";

        public const string Trigger = nameof(Trigger);

        public const string SubscriptionStatus = nameof(SubscriptionStatus);

        public const string Subscription = nameof(Subscription);

        public const string TriggerRun = nameof(TriggerRun);

        public const string Dataset = nameof(Dataset);

        public const string DataFlow = nameof(DataFlow);

        public const string SensitivityRecommendation = nameof(SensitivityRecommendation);

        public const string PointInTime = nameof(PointInTime);

        public const string TargetSqlPoolName = nameof(TargetSqlPoolName);

        public static Dictionary<string, ComputeNodeSize> ComputeNodeSizes = new Dictionary<string, ComputeNodeSize>
        {
            {
                NodeSize.Small,
                new ComputeNodeSize
                {
                    Name = NodeSize.Small,
                    Cores = 4,
                    Memory = 28
                }
            },
            {
                NodeSize.Medium,
                new ComputeNodeSize
                {
                    Name = NodeSize.Medium,
                    Cores = 8,
                    Memory = 56
                }
            },
            {
                NodeSize.Large,
                new ComputeNodeSize
                {
                    Name = NodeSize.Large,
                    Cores = 16,
                    Memory = 112
                }
            }
        };

        public const int DefaultPollingInterval = 5000;

        public const int MaxPollingCount = 900;

        public const int UnknownId = -1;

        public const int PageSize = 20;

        public static string InteractiveSessionPrompt = $"{Environment.NewLine}Spark> ";

        public const string DefaultCollation = "SQL_Latin1_General_CP1_CI_AS";

        public const string AllowAllStartIpAddress = "0.0.0.0";

        public const string AllowAllEndIpAddress = "255.255.255.255";

        public const string StorageBlobDataContributorRoleName = "Azure Blob Data Contributor";

        public class Security
        {
            // Parameters Names:
            public const string Enabled = "Enabled";
            public const string Disabled = "Disabled";

            public const string Primary = "Primary";
            public const string Secondary = "Secondary";
        }

        public class DetectionType
        {
            public const string Sql_Injection = "Sql_Injection";
            public const string Sql_Injection_Vulnerability = "Sql_Injection_Vulnerability";
            public const string Access_Anomaly = "Access_Anomaly";
            public const string Data_Exfiltration = "Data_Exfiltration";
            public const string Unsafe_Action = "Unsafe_Action";
            public const string None = "None";
        }
    }
}
