---
external help file:
Module Name: Az.RecoveryServices
online version: https://docs.microsoft.com/powershell/module/az.recoveryservices/get-azrecoveryservicesreplicationpolicy
schema: 2.0.0
---

# Get-AzRecoveryServicesReplicationPolicy

## SYNOPSIS
Gets the details of a replication policy.

## SYNTAX

### List (Default)
```
Get-AzRecoveryServicesReplicationPolicy -ResourceGroupName <String> -ResourceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzRecoveryServicesReplicationPolicy -PolicyName <String> -ResourceGroupName <String>
 -ResourceName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the details of a replication policy.

## EXAMPLES

### Example 1: List all replication policies in a recovery services vault
```powershell
Get-AzRecoveryServicesReplicationPolicy -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault"
```

```output
Id                                                                                                                                                                            Location Name        Type
--                                                                                                                                                                            -------- ----        ----
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationPolicies/demopolicy3          demopolicy3 Microsoft.RecoveryServices/vaults/replicationPolicies
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationPolicies/demopolicy2          demopolicy2 Microsoft.RecoveryServices/vaults/replicationPolicies
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationPolicies/demopolicy1          demopolicy1 Microsoft.RecoveryServices/vaults/replicationPolicies
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationPolicies/A2APolicy            A2APolicy   Microsoft.RecoveryServices/vaults/replicationPolicies
```

Lists all the replication policies in the specified vault in the specified resource group.

### Example 2: Get info for a specific replication policy
```powershell
Get-AzRecoveryServicesReplicationPolicy -PolicyName "A2APolicy" -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault"
```

```output
Id                                                                                                                                                                          Location Name      Type
--                                                                                                                                                                          -------- ----      ----
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationPolicies/A2APolicy          A2APolicy Microsoft.RecoveryServices/vaults/replicationPolicies
```

Gets info for a specific replication policy by its name in the specified vault in the specified resource group.

## PARAMETERS

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

### -PolicyName
Replication policy name.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group where the recovery services vault is present.

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

### -ResourceName
The name of the recovery services vault.

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

### -SubscriptionId
The subscription Id.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IPolicy

## NOTES

ALIASES

## RELATED LINKS

