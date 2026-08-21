---
external help file:
Module Name: Az.ManagedNetworkFabric
online version: https://learn.microsoft.com/powershell/module/az.managednetworkfabric/invoke-aznetworkfabriccommitconfiguration
schema: 2.0.0
---

# Invoke-AzNetworkFabricCommitConfiguration

## SYNOPSIS
Atomic commit of the given Network Fabric instance.
Sync commit of NFA resources at Fabric level.

## SYNTAX

### CommitExpanded (Default)
```
Invoke-AzNetworkFabricCommitConfiguration -NetworkFabricName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-CommitPolicy <String>] [-CommitStage <String>] [-Device <String[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Commit
```
Invoke-AzNetworkFabricCommitConfiguration -NetworkFabricName <String> -ResourceGroupName <String>
 -Body <ICommitConfigurationRequest> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CommitViaIdentity
```
Invoke-AzNetworkFabricCommitConfiguration -InputObject <IManagedNetworkFabricIdentity>
 -Body <ICommitConfigurationRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CommitViaIdentityExpanded
```
Invoke-AzNetworkFabricCommitConfiguration -InputObject <IManagedNetworkFabricIdentity>
 [-CommitPolicy <String>] [-CommitStage <String>] [-Device <String[]>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CommitViaJsonFilePath
```
Invoke-AzNetworkFabricCommitConfiguration -NetworkFabricName <String> -ResourceGroupName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CommitViaJsonString
```
Invoke-AzNetworkFabricCommitConfiguration -NetworkFabricName <String> -ResourceGroupName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Atomic commit of the given Network Fabric instance.
Sync commit of NFA resources at Fabric level.

## EXAMPLES

### Example 1: Commit Network Fabric Configuration
```powershell
Invoke-AzNetworkFabricCommitConfiguration -NetworkFabricName $name -ResourceGroupName $resourceGroupName
```

This command commits the pending configuration changes to the given Network Fabric.

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

### -Body
Commit Configuration Request.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.ICommitConfigurationRequest
Parameter Sets: Commit, CommitViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -CommitPolicy
Commit configuration Policy.
Supported policy is StageCEConfiguration, which indicates to prepare the configuration for the CE device type.

```yaml
Type: System.String
Parameter Sets: CommitExpanded, CommitViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CommitStage
Commit stage Action to be performed.

```yaml
Type: System.String
Parameter Sets: CommitExpanded, CommitViaIdentityExpanded
Aliases:

Required: False
Position: Named
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

### -Device
List of ARM resource IDs of devices to be included in the commit operation.
Either CE1 or CE2 is allowed.

```yaml
Type: System.String[]
Parameter Sets: CommitExpanded, CommitViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IManagedNetworkFabricIdentity
Parameter Sets: CommitViaIdentity, CommitViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Commit operation

```yaml
Type: System.String
Parameter Sets: CommitViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Commit operation

```yaml
Type: System.String
Parameter Sets: CommitViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkFabricName
Name of the Network Fabric.

```yaml
Type: System.String
Parameter Sets: Commit, CommitExpanded, CommitViaJsonFilePath, CommitViaJsonString
Aliases:

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Commit, CommitExpanded, CommitViaJsonFilePath, CommitViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: Commit, CommitExpanded, CommitViaJsonFilePath, CommitViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.ICommitConfigurationRequest

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IManagedNetworkFabricIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.ICommitConfigurationResponse

## NOTES

## RELATED LINKS

