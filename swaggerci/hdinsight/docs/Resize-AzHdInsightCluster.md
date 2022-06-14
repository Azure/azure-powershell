---
external help file:
Module Name: Az.HdInsight
online version: https://docs.microsoft.com/en-us/powershell/module/az.hdinsight/resize-azhdinsightcluster
schema: 2.0.0
---

# Resize-AzHdInsightCluster

## SYNOPSIS
Resizes the specified HDInsight cluster to the specified size.

## SYNTAX

### ResizeExpanded (Default)
```
Resize-AzHdInsightCluster -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-TargetInstanceCount <Int32>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Resize
```
Resize-AzHdInsightCluster -Name <String> -ResourceGroupName <String> -Parameter <IClusterResizeParameters>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ResizeViaIdentity
```
Resize-AzHdInsightCluster -InputObject <IHdInsightIdentity> -Parameter <IClusterResizeParameters>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ResizeViaIdentityExpanded
```
Resize-AzHdInsightCluster -InputObject <IHdInsightIdentity> [-TargetInstanceCount <Int32>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Resizes the specified HDInsight cluster to the specified size.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AsJob
Run the command as a job

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

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsight.Models.IHdInsightIdentity
Parameter Sets: ResizeViaIdentity, ResizeViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the cluster.

```yaml
Type: System.String
Parameter Sets: Resize, ResizeExpanded
Aliases: ClusterName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -Parameter
The Resize Cluster request parameters.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsight.Models.Api20210601.IClusterResizeParameters
Parameter Sets: Resize, ResizeViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

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

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: Resize, ResizeExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: Resize, ResizeExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetInstanceCount
The target instance count for the operation.

```yaml
Type: System.Int32
Parameter Sets: ResizeExpanded, ResizeViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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

### Microsoft.Azure.PowerShell.Cmdlets.HdInsight.Models.Api20210601.IClusterResizeParameters

### Microsoft.Azure.PowerShell.Cmdlets.HdInsight.Models.IHdInsightIdentity

## OUTPUTS

### System.Boolean

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IHdInsightIdentity>: Identity Parameter
  - `[ApplicationName <String>]`: The constant value for the application name.
  - `[ClusterName <String>]`: The name of the cluster.
  - `[ConfigurationName <String>]`: The name of the cluster configuration.
  - `[ExtensionName <String>]`: The name of the cluster extension.
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: The Azure location (region) for which to make the request.
  - `[OperationId <String>]`: The long running operation id.
  - `[PrivateEndpointConnectionName <String>]`: The name of the private endpoint connection.
  - `[PrivateLinkResourceName <String>]`: The name of the private link resource.
  - `[ResourceGroupName <String>]`: The name of the resource group.
  - `[RoleName <RoleName?>]`: The constant value for the roleName
  - `[ScriptExecutionId <String>]`: The script execution Id
  - `[ScriptName <String>]`: The name of the script.
  - `[SubscriptionId <String>]`: The subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.

PARAMETER <IClusterResizeParameters>: The Resize Cluster request parameters.
  - `[TargetInstanceCount <Int32?>]`: The target instance count for the operation.

## RELATED LINKS

