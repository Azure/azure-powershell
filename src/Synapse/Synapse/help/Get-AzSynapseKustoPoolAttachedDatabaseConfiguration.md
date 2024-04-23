---
external help file: Az.Synapse-help.xml
Module Name: Az.Synapse
online version: https://learn.microsoft.com/powershell/module/az.synapse/get-azsynapsekustopoolattacheddatabaseconfiguration
schema: 2.0.0
---

# Get-AzSynapseKustoPoolAttachedDatabaseConfiguration

## SYNOPSIS
Returns an attached database configuration.

## SYNTAX

### List (Default)
```
Get-AzSynapseKustoPoolAttachedDatabaseConfiguration -KustoPoolName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] -WorkspaceName <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzSynapseKustoPoolAttachedDatabaseConfiguration -AttachedDatabaseConfigurationName <String>
 -KustoPoolName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>] -WorkspaceName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSynapseKustoPoolAttachedDatabaseConfiguration -InputObject <ISynapseIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Returns an attached database configuration.

## EXAMPLES

### Example 1: List all the AttachedDatabaseConfigurations in a kusto pool
```powershell
Get-AzSynapseKustoPoolAttachedDatabaseConfiguration -ResourceGroupName testrg -WorkspaceName testws -KustoPoolName testfollowerkustopool
```

```output
Name                                               Type                                                                   Location
----                                               ----                                                                   --------
testws/testfollowerkustopool/followerconfiguration Microsoft.Synapse/workspaces/kustoPools/AttachedDatabaseConfigurations East US 2
```

The above command lists all the AttachedDatabaseConfigurations in the kusto pool "testfollowerkustopool".

### Example 2: Get a specific AttachedDatabaseConfiguration in a kusto pool
```powershell
Get-AzSynapseKustoPoolAttachedDatabaseConfiguration -ResourceGroupName testrg -WorkspaceName testws -KustoPoolName testfollowerkustopool -Name followerconfiguration
```

```output
Name                                               Type                                                                   Location
----                                               ----                                                                   --------
testws/testfollowerkustopool/followerconfiguration Microsoft.Synapse/workspaces/kustoPools/AttachedDatabaseConfigurations East US 2
```

The above command returns the AttachedDatabaseConfigurations named "followerconfiguration" in the cluster "testfollowerkustopool".

## PARAMETERS

### -AttachedDatabaseConfigurationName
The name of the attached database configuration.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: Name

Required: True
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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.ISynapseIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -KustoPoolName
The name of the Kusto pool.

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
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
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: List, Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceName
The name of the workspace

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.ISynapseIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Synapse.Models.Api20210601Preview.IAttachedDatabaseConfiguration

## NOTES

## RELATED LINKS
