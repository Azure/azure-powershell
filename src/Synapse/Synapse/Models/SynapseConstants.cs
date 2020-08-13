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
    }
}
