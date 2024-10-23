---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Synapse.dll-Help.xml
Module Name: Az.Synapse
online version: https://learn.microsoft.com/powershell/module/az.synapse/new-azsynapsesparkpool
schema: 2.0.0
---

# New-AzSynapseSparkPool

## SYNOPSIS
Creates a Synapse Analytics Spark pool.

## SYNTAX

### CreateByNameAndEnableAutoScaleParameterSet (Default)
```
New-AzSynapseSparkPool [-ResourceGroupName <String>] -WorkspaceName <String> -Name <String> [-Tag <Hashtable>]
 [-EnableIsolatedCompute] -NodeSize <String> -AutoScaleMinNodeCount <Int32> -AutoScaleMaxNodeCount <Int32>
 [-EnableAutoPause] [-AutoPauseDelayInMinute <Int32>] [-EnableDynamicExecutorAllocation]
 [-MinExecutorCount <Int32>] [-MaxExecutorCount <Int32>] -SparkVersion <String>
 [-SparkConfiguration <PSSparkConfigurationResource>] [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateByNameAndDisableAutoScaleParameterSet
```
New-AzSynapseSparkPool [-ResourceGroupName <String>] -WorkspaceName <String> -Name <String> [-Tag <Hashtable>]
 -NodeCount <Int32> [-EnableIsolatedCompute] -NodeSize <String> [-EnableAutoPause]
 [-AutoPauseDelayInMinute <Int32>] [-EnableDynamicExecutorAllocation] [-MinExecutorCount <Int32>]
 [-MaxExecutorCount <Int32>] -SparkVersion <String> [-SparkConfiguration <PSSparkConfigurationResource>]
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateByParentObjectAndEnableAutoScaleParameterSet
```
New-AzSynapseSparkPool -WorkspaceObject <PSSynapseWorkspace> -Name <String> [-Tag <Hashtable>]
 [-EnableIsolatedCompute] -NodeSize <String> -AutoScaleMinNodeCount <Int32> -AutoScaleMaxNodeCount <Int32>
 [-EnableAutoPause] [-AutoPauseDelayInMinute <Int32>] [-EnableDynamicExecutorAllocation]
 [-MinExecutorCount <Int32>] [-MaxExecutorCount <Int32>] -SparkVersion <String>
 [-SparkConfiguration <PSSparkConfigurationResource>] [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateByParentObjectAndDisableAutoScaleParameterSet
```
New-AzSynapseSparkPool -WorkspaceObject <PSSynapseWorkspace> -Name <String> [-Tag <Hashtable>]
 -NodeCount <Int32> [-EnableIsolatedCompute] -NodeSize <String> [-EnableAutoPause]
 [-AutoPauseDelayInMinute <Int32>] [-EnableDynamicExecutorAllocation] [-MinExecutorCount <Int32>]
 [-MaxExecutorCount <Int32>] -SparkVersion <String> [-SparkConfiguration <PSSparkConfigurationResource>]
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzSynapseSparkPool** cmdlet creates an Azure Synapse Analytics Spark pool.

## EXAMPLES

### Example 1
```powershell
New-AzSynapseSparkPool -WorkspaceName ContosoWorkspace -Name ContosoSparkPool -NodeCount 3 -SparkVersion 2.4 -NodeSize Small
```

This command creates an Azure Synapse Analytics Spark pool.

### Example 2
```powershell
New-AzSynapseSparkPool -WorkspaceName ContosoWorkspace -Name ContosoSparkPool -AutoScaleMinNodeCount 3 -AutoScaleMaxNodeCount 10 -SparkVersion 2.4 -NodeSize Small
```

This command creates an Azure Synapse Analytics Spark pool with auto-scale enabled.

### Example 3
```powershell
New-AzSynapseSparkPool -WorkspaceName ContosoWorkspace -Name ContosoSparkPool -EnableDynamicExecutorAllocation -MinExecutorCount 1 -MaxExecutorCount 4  -NodeCount 10 -SparkVersion 2.4 -NodeSize Small
```

This command creates an Azure Synapse Analytics Spark pool with dynamic executor allocation enabled and specify min executor count and max executor count.

### Example 4
```powershell
$config = Get-AzSynapseSparkConfiguration -WorkspaceName ContosoWorkspace -Name ContosoSparkConfig1
New-AzSynapseSparkPool -WorkspaceName ContosoWorkspace -Name ContosoSparkPool -NodeCount 3 -SparkVersion 2.4 -NodeSize Small -SparkConfiguration $config
```

This command creates an Azure Synapse Analytics Spark pool and specify a Spark configuration for Spark pool.

### Example 5
```powershell
$ws = Get-AzSynapseWorkspace -Name ContosoWorkspace
$ws | New-AzSynapseSparkPool -Name ContosoSparkPool -NodeCount 3 -SparkVersion 2.4 -NodeSize Small
```

This command creates an Azure Synapse Analytics Spark pool through pipeline.

### Example 6
```powershell
$ws = Get-AzSynapseWorkspace -Name ContosoWorkspace
$ws | New-AzSynapseSparkPool -Name ContosoSparkPool -AutoScaleMinNodeCount 3 -AutoScaleMaxNodeCount 10 -SparkVersion 2.4 -NodeSize Small
```

This command creates an Azure Synapse Analytics Spark pool with auto-scale enabled through pipeline.

### Example 7
```powershell
$ws = Get-AzSynapseWorkspace -Name ContosoWorkspace
$ws | New-AzSynapseSparkPool -Name ContosoSparkPool -EnableIsolatedCompute -NodeSize XXXLarge -NodeCount 3 -SparkVersion 2.4
```

This command creates an Azure Synapse Analytics Spark pool with isolated compute enabled through pipeline.

## PARAMETERS

### -AsJob
Run cmdlet in the background

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoPauseDelayInMinute
Number of minutes idle. This parameter can be specified when Auto-pause is enabled. The default value will be [15] if it is not specified manually.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoScaleMaxNodeCount
Maximum number of nodes to be allocated in the specified Spark pool.
This parameter must be specified when Auto-scale is enabled.

```yaml
Type: System.Int32
Parameter Sets: CreateByNameAndEnableAutoScaleParameterSet, CreateByParentObjectAndEnableAutoScaleParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoScaleMinNodeCount
Minimum number of nodes to be allocated in the specified Spark pool.
This parameter must be specified when Auto-scale is enabled.

```yaml
Type: System.Int32
Parameter Sets: CreateByNameAndEnableAutoScaleParameterSet, CreateByParentObjectAndEnableAutoScaleParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableAutoPause
Indicates whether Auto-pause should be enabled.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableDynamicExecutorAllocation
Indicates whether dynamic executor allocation should be enabled.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableIsolatedCompute
The Isolate Compute option is only available with the XXXLarge (80 vCPU / 504 GB) node size. Enabling this option offers isolation for Apache Spark compute for untrusted services. Isolated compute costs the same as the non-isolated VM of the same size. If you expect to enable Isolated Compute for spark pool, ensure that your Synapse workspace is created in an isolated compute supported region, please refer to this document for more details: https://learn.microsoft.com/en-us/azure/synapse-analytics/spark/apache-spark-pool-configurations#isolated-compute.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaxExecutorCount
Maximum number of executors to be allocated in the specified Spark pool. This parameter can be specified when DynamicExecutorAllocation is enabled. The value should lie between 1 (inclusive) and maximumNodeCount (exclusive). If it is not specified manually, the default value will be 2.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MinExecutorCount
Minimum number of executors to be allocated in the specified Spark pool. This parameter can be specified when DynamicExecutorAllocation is enabled. The value should lie between 1 (inclusive) and maxExecutors (exclusive). If it is not specified manually, the default value will be 1.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of Synapse Spark pool.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: SparkPoolName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NodeCount
Number of nodes to be allocated in the specified Spark pool.

```yaml
Type: System.Int32
Parameter Sets: CreateByNameAndDisableAutoScaleParameterSet, CreateByParentObjectAndDisableAutoScaleParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NodeSize
Number of core and memory to be used for nodes allocated in the specified Spark pool.
This parameter must be specified when Auto-scale is disabled

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Small, Medium, Large, XLarge, XXLarge, XXXLarge

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Resource group name.

```yaml
Type: System.String
Parameter Sets: CreateByNameAndEnableAutoScaleParameterSet, CreateByNameAndDisableAutoScaleParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SparkConfiguration
Apache Spark configuration. When a job is submitted to the pool, the properties specified in the selected configuration will be referenced.

```yaml
Type: Microsoft.Azure.Commands.Synapse.Models.PSSparkConfigurationResource
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SparkVersion
Apache Spark version.
Allowed values: 2.4

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
A string,string dictionary of tags associated with the resource.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceName
Name of Synapse workspace.

```yaml
Type: System.String
Parameter Sets: CreateByNameAndEnableAutoScaleParameterSet, CreateByNameAndDisableAutoScaleParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceObject
workspace input object, usually passed through the pipeline.

```yaml
Type: Microsoft.Azure.Commands.Synapse.Models.PSSynapseWorkspace
Parameter Sets: CreateByParentObjectAndEnableAutoScaleParameterSet, CreateByParentObjectAndDisableAutoScaleParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Synapse.Models.PSSynapseWorkspace

## OUTPUTS

### Microsoft.Azure.Commands.Synapse.Models.PSSynapseSparkPool

## NOTES

## RELATED LINKS
