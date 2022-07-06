---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Synapse.dll-Help.xml
Module Name: Az.Synapse
online version: https://docs.microsoft.com/powershell/module/az.synapse/update-azsynapsesparkpool
schema: 2.0.0
---

# Update-AzSynapseSparkPool

## SYNOPSIS
Updates a Apache Spark pool in Azure Synapse Analytics.

## SYNTAX

### SetByNameParameterSet (Default)
```
Update-AzSynapseSparkPool [-ResourceGroupName <String>] -WorkspaceName <String> -Name <String>
 [-Tag <Hashtable>] [-EnableAutoScale <Boolean>] [-AutoScaleMinNodeCount <Int32>]
 [-AutoScaleMaxNodeCount <Int32>] [-EnableAutoPause <Boolean>] [-AutoPauseDelayInMinute <Int32>]
 [-NodeCount <Int32>] [-NodeSize <String>] [-SparkVersion <String>] [-LibraryRequirementsFilePath <String>]
 [-SparkConfigFilePath <String>] [-PackageAction <PackageActionType>]
 [-Package <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Synapse.Models.WorkspacePackages.PSSynapseWorkspacePackage]>]
 [-ForceApplySetting] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### SetByParentObjectParameterSet
```
Update-AzSynapseSparkPool -Name <String> -WorkspaceObject <PSSynapseWorkspace> [-Tag <Hashtable>]
 [-EnableAutoScale <Boolean>] [-AutoScaleMinNodeCount <Int32>] [-AutoScaleMaxNodeCount <Int32>]
 [-EnableAutoPause <Boolean>] [-AutoPauseDelayInMinute <Int32>] [-NodeCount <Int32>] [-NodeSize <String>]
 [-SparkVersion <String>] [-LibraryRequirementsFilePath <String>] [-SparkConfigFilePath <String>]
 [-PackageAction <PackageActionType>]
 [-Package <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Synapse.Models.WorkspacePackages.PSSynapseWorkspacePackage]>]
 [-ForceApplySetting] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### SetByInputObjectParameterSet
```
Update-AzSynapseSparkPool -InputObject <PSSynapseSparkPool> [-Tag <Hashtable>] [-EnableAutoScale <Boolean>]
 [-AutoScaleMinNodeCount <Int32>] [-AutoScaleMaxNodeCount <Int32>] [-EnableAutoPause <Boolean>]
 [-AutoPauseDelayInMinute <Int32>] [-NodeCount <Int32>] [-NodeSize <String>] [-SparkVersion <String>]
 [-LibraryRequirementsFilePath <String>] [-SparkConfigFilePath <String>] [-PackageAction <PackageActionType>]
 [-Package <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Synapse.Models.WorkspacePackages.PSSynapseWorkspacePackage]>]
 [-ForceApplySetting] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### SetByResourceIdParameterSet
```
Update-AzSynapseSparkPool -ResourceId <String> [-Tag <Hashtable>] [-EnableAutoScale <Boolean>]
 [-AutoScaleMinNodeCount <Int32>] [-AutoScaleMaxNodeCount <Int32>] [-EnableAutoPause <Boolean>]
 [-AutoPauseDelayInMinute <Int32>] [-NodeCount <Int32>] [-NodeSize <String>] [-SparkVersion <String>]
 [-LibraryRequirementsFilePath <String>] [-SparkConfigFilePath <String>] [-PackageAction <PackageActionType>]
 [-Package <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Synapse.Models.WorkspacePackages.PSSynapseWorkspacePackage]>]
 [-ForceApplySetting] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Update-AzSynapseSparkPool** cmdlet updates an Apache Spark pool in Azure Synapse Analytics.

## EXAMPLES

### Example 1
```powershell
Update-AzSynapseSparkPool -WorkspaceName ContosoWorkspace -Name ContosoSparkPool -Tag @{"key" = "value"} -NodeCount 5 -NodeSize Medium
```

This command updates an Apache Spark pool in Azure Synapse Analytics.

### Example 2
```powershell
$pool = Get-AzSynapseSparkPool -WorkspaceName ContosoWorkspace -Name ContosoSparkPool
$pool | Update-AzSynapseSparkPool -Tag @{"key" = "value1"}
```

This command updates an Apache Spark pool in Azure Synapse Analytics through pipeline.

### Example 3
```powershell
$ws = Get-AzSynapseWorkspace -Name ContosoWorkspace
$ws | Update-AzSynapseSparkPool -Name ContosoSparkPool -Tag @{"key" = "value2"}
```

This command updates an Apache Spark pool in Azure Synapse Analytics through pipeline.

### Example 4
```powershell
Update-AzSynapseSparkPool -ResourceId /subscriptions/21686af7-58ec-4f4d-9c68-f431f4db4edd/resourceGroups/ContosoResourceGroup/providers/Microsoft.Synapse/workspaces/ContosoWorkspace/bigDataPools/ContosoSparkPool -Tag @{"key" = "value3"}
```

This command updates an Apache Spark pool in Azure Synapse Analytics with resource ID.

### Example 5
```powershell
Update-AzSynapseSparkPool -WorkspaceName ContosoWorkspace -Name ContosoSparkPool -EnableAutoScale $true -AutoScaleMinNodeCount 3 -AutoScaleMaxNodeCount 7
```

This command enables auto-scale for an Apache Spark pool in Azure Synapse Analytics.

### Example 6
```powershell
Update-AzSynapseSparkPool -WorkspaceName ContosoWorkspace -Name ContosoSparkPool -EnableAutoScale $false
```

This command disables auto-scale for an Apache Spark pool in Azure Synapse Analytics.

### Example 7
```powershell
Update-AzSynapseSparkPool -WorkspaceName ContosoWorkspace -Name ContosoSparkPool -EnableAutoPause $true -AutoPauseDelayInMinute 15
```

This command enables auto-pause for an Apache Spark pool in Azure Synapse Analytics.

### Example 8
```powershell
Update-AzSynapseSparkPool -WorkspaceName ContosoWorkspace -Name ContosoSparkPool -EnableAutoPause $false
```

This command disables auto-pause for an Apache Spark pool in Azure Synapse Analytics.

### Example 9
```powershell
$packages = Get-AzSynapseWorkspacePackage -WorkspaceName ContosoWorkspace
Update-AzSynapseSparkPool -WorkspaceName ContosoWorkspace -Name ContosoSparkPool -PackageAction Add -Package $packages
```

The first command retrieves workspace packages. The second command links these workspace packages to an Apache Spark pool in Azure Synapse Analytics.

### Example 10
```powershell
$package = Get-AzSynapseWorkspacePackage -WorkspaceName ContosoWorkspace -Name ContosoPackage
Update-AzSynapseSparkPool -WorkspaceName ContosoWorkspace -Name ContosoSparkPool -PackageAction Remove -Package $package
```

The first command retrieves workspace packages named ContosoPackage. The second command removes the workspace package from an Apache Spark pool in Azure Synapse Analytics.

### Example 11
```powershell
$pool = Get-AzSynapseSparkPool -ResourceGroupName ContosoResourceGroup -WorkspaceName ContosoWorkspace -Name ContosoSparkPool
$pool | Update-AzSynapseSparkPool -PackageAction Remove -Package $pool.WorkspacePackages
```

The first command retrieves an Apache Spark pool in Azure Synapse Analytics. The second command removes all workspace packages that are linked to that Apache Spark pool.

### Example 12
```powershell
Update-AzSynapseSparkPool -WorkspaceName ContosoWorkspace -Name ContosoSparkPool -Tag @{"key" = "value"} -NodeCount 5 -NodeSize Medium -SparkConfigFilePath "c:\sparkconfig.txt"
```

This command updates an Apache Spark pool in Azure Synapse Analytics and upload a spark configuration file for the spark pool.

### Example 13
```powershell
Update-AzSynapseSparkPool -WorkspaceName ContosoWorkspace -Name ContosoSparkPool -NodeSize small -ForceApplySetting
```

This command updates an Apache Spark pool in Azure Synapse Analytics, set NodeSize to small for the spark pool and force stop any running jobs in the Spark pool to apply this new setting.

### Example 14
```powershell
$pool = Get-AzSynapseSparkPool -ResourceGroupName ContosoResourceGroup -WorkspaceName ContosoWorkspace -Name ContosoSparkPool
$pool | Update-AzSynapseSparkPool -PackageAction Remove -Package $pool.WorkspacePackages -ForceApplySetting
```

The first command retrieves an Apache Spark pool in Azure Synapse Analytics. The second command removes all workspace packages that are linked to that Apache Spark pool and force stop any running jobs in the Spark pool to apply this new setting.

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
Parameter Sets: (All)
Aliases:

Required: False
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
Parameter Sets: (All)
Aliases:

Required: False
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
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableAutoScale
Indicates whether Auto-scale should be enabled

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ForceApplySetting
Whether to stop any running jobs in the Big Data pool.

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

### -InputObject
Spark pool input object, usually passed through the pipeline.

```yaml
Type: Microsoft.Azure.Commands.Synapse.Models.PSSynapseSparkPool
Parameter Sets: SetByInputObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LibraryRequirementsFilePath
Environment configuration file ("PIP freeze" output).

```yaml
Type: System.String
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
Parameter Sets: SetByNameParameterSet, SetByParentObjectParameterSet
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
Parameter Sets: (All)
Aliases:

Required: False
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
Accepted values: Small, Medium, Large

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Package
The workspace packages.

```yaml
Type: System.Collections.Generic.List`1[Microsoft.Azure.Commands.Synapse.Models.WorkspacePackages.PSSynapseWorkspacePackage]
Parameter Sets: (All)
Aliases: WorkspacePackage

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PackageAction
Package action must be specified when you add or remove a workspace package from a Apache Spark pool.

```yaml
Type: Microsoft.Azure.Commands.Synapse.Models.SynapseConstants+PackageActionType
Parameter Sets: (All)
Aliases:
Accepted values: Add, Remove

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Resource group name.

```yaml
Type: System.String
Parameter Sets: SetByNameParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
Resource identifier of Synapse Spark pool.

```yaml
Type: System.String
Parameter Sets: SetByResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SparkConfigFilePath
Spark pool properties configuration file.

```yaml
Type: System.String
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
Allowed values: 2.3,2.4,3.1,3.2

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
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
Parameter Sets: SetByNameParameterSet
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
Parameter Sets: SetByParentObjectParameterSet
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

### Microsoft.Azure.Commands.Synapse.Models.PSSynapseSparkPool

## OUTPUTS

### Microsoft.Azure.Commands.Synapse.Models.PSSynapseSparkPool

## NOTES

## RELATED LINKS
