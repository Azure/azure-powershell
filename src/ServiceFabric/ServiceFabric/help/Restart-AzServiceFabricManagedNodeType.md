---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ServiceFabric.dll-help.xml
Module Name: Az.ServiceFabric
online version: https://learn.microsoft.com/powershell/module/az.servicefabric/restart-azservicefabricmanagednodetype
schema: 2.0.0
---

# Restart-AzServiceFabricManagedNodeType

## SYNOPSIS
Restarts one or more nodes on the node type.
It will disable the fabric nodes, trigger a restart on the VMs and activate the nodes back again.

## SYNTAX

### RestartExpanded (Default)
```
Restart-AzServiceFabricManagedNodeType [-ClusterName] <String> [-Name] <String> [-ResourceGroupName] <String>
 [-SubscriptionId <String>] [-Force] [-Node <String[]>] [-UpdateType <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RestartViaJsonString
```
Restart-AzServiceFabricManagedNodeType [-ClusterName] <String> [-Name] <String> [-ResourceGroupName] <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RestartViaJsonFilePath
```
Restart-AzServiceFabricManagedNodeType [-ClusterName] <String> [-Name] <String> [-ResourceGroupName] <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Restart
```
Restart-AzServiceFabricManagedNodeType [-ClusterName] <String> [-Name] <String> [-ResourceGroupName] <String>
 [-SubscriptionId <String>] -Parameter <INodeTypeActionParameters> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RestartViaIdentityManagedClusterExpanded
```
Restart-AzServiceFabricManagedNodeType [-Name] <String> -ManagedClusterInputObject <IServiceFabricIdentity>
 [-Force] [-Node <String[]>] [-UpdateType <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RestartViaIdentityManagedCluster
```
Restart-AzServiceFabricManagedNodeType [-Name] <String> -ManagedClusterInputObject <IServiceFabricIdentity>
 -Parameter <INodeTypeActionParameters> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### RestartViaIdentityExpanded
```
Restart-AzServiceFabricManagedNodeType -InputObject <IServiceFabricIdentity> [-Force] [-Node <String[]>]
 [-UpdateType <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### RestartViaIdentity
```
Restart-AzServiceFabricManagedNodeType -InputObject <IServiceFabricIdentity>
 -Parameter <INodeTypeActionParameters> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Restarts one or more nodes on the node type.
It will disable the fabric nodes, trigger a restart on the VMs and activate the nodes back again.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
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

### -ClusterName
The name of the cluster resource.

```yaml
Type: System.String
Parameter Sets: RestartExpanded, RestartViaJsonString, RestartViaJsonFilePath, Restart
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -Force
Force the action to go through.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: RestartExpanded, RestartViaIdentityManagedClusterExpanded, RestartViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceFabric.Models.IServiceFabricIdentity
Parameter Sets: RestartViaIdentityExpanded, RestartViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Restart operation

```yaml
Type: System.String
Parameter Sets: RestartViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Restart operation

```yaml
Type: System.String
Parameter Sets: RestartViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagedClusterInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceFabric.Models.IServiceFabricIdentity
Parameter Sets: RestartViaIdentityManagedClusterExpanded, RestartViaIdentityManagedCluster
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the node type.

```yaml
Type: System.String
Parameter Sets: RestartExpanded, RestartViaJsonString, RestartViaJsonFilePath, Restart, RestartViaIdentityManagedClusterExpanded, RestartViaIdentityManagedCluster
Aliases: NodeTypeName

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Node
List of node names from the node type.

```yaml
Type: System.String[]
Parameter Sets: RestartExpanded, RestartViaIdentityManagedClusterExpanded, RestartViaIdentityExpanded
Aliases:

Required: False
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
Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
Parameters for Node type action.
If nodes are not specified on the parameters, the operation will be performed in all nodes of the node type one upgrade domain at a time.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceFabric.Models.INodeTypeActionParameters
Parameter Sets: Restart, RestartViaIdentityManagedCluster, RestartViaIdentity
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
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: RestartExpanded, RestartViaJsonString, RestartViaJsonFilePath, Restart
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: RestartExpanded, RestartViaJsonString, RestartViaJsonFilePath, Restart
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -UpdateType
Specifies the way the operation will be performed.

```yaml
Type: System.String
Parameter Sets: RestartExpanded, RestartViaIdentityManagedClusterExpanded, RestartViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.ServiceFabric.Models.INodeTypeActionParameters

### Microsoft.Azure.PowerShell.Cmdlets.ServiceFabric.Models.IServiceFabricIdentity

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
