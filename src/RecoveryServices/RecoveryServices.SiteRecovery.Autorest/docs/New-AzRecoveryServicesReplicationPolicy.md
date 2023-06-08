---
external help file:
Module Name: Az.RecoveryServices
online version: https://docs.microsoft.com/powershell/module/az.recoveryservices/new-azrecoveryservicesreplicationpolicy
schema: 2.0.0
---

# New-AzRecoveryServicesReplicationPolicy

## SYNOPSIS


## SYNTAX

```
New-AzRecoveryServicesReplicationPolicy -PolicyName <String> -ResourceGroupName <String>
 -ResourceName <String> [-SubscriptionId <String>] [-ProviderSpecificInput <IPolicyProviderSpecificInput>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION


## EXAMPLES

### Example 1: Create an Azure-To-Azure replication policy in a recovery services vault
```powershell
$policy = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.A2APolicyCreationInput]::new()
$policy.AppConsistentFrequencyInMinute=240
$policy.CrashConsistentFrequencyInMinute=60
$policy.MultiVMSyncStatus='Enable'
$policy.RecoveryPointHistory=4320
$policy.ReplicationScenario="ReplicateAzureToAzure"
New-AzRecoveryServicesReplicationPolicy -PolicyName "demopolicy1" -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -ProviderSpecificInput $policy
```

```output
Location Name        Type
-------- ----        ----
         demopolicy1 Microsoft.RecoveryServices/vaults/replicationPolicies
```

Creates an Azure-To-Azure replication policy in the specified vault in the specified resource group.

### Example 2: Create an HyperV-To-Azure replication policy in a recovery services vault
```powershell
$providerSpecificPolicy = [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.HyperVReplicaAzurePolicyInput]::new()
$providerSpecificPolicy.ApplicationConsistentSnapshotFrequencyInHour = 3
$providerSpecificPolicy.RecoveryPointHistoryDuration = 10
$providerSpecificPolicy.ReplicationScenario = "ReplicateHyperVToAzure"
$providerSpecificPolicy.ReplicationInterval = 300
New-AzRecoveryServicesReplicationPolicy -ResourceGroupName "ASRTesting" -ResourceName "HyperV2AzureVault" -PolicyName "replicapolicy4h2a" -ProviderSpecificInput $providerSpecificPolicy
```

```
Location Name              Type
-------- ----              ----
         replicapolicy4h2a Microsoft.RecoveryServices/vaults/replicationPolicies
```

Creates an HyperV to Azure replication policy in the specified vault in the specified resource group with the given parameters.

## PARAMETERS

### -AsJob


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

### -NoWait


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

### -PolicyName
Specific replication policy name.

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

### -ProviderSpecificInput
To construct, see NOTES section for PROVIDERSPECIFICINPUT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IPolicyProviderSpecificInput
Parameter Sets: (All)
Aliases:

Required: False
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
Subscription Id

```yaml
Type: System.String
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IPolicy

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


PROVIDERSPECIFICINPUT <IPolicyProviderSpecificInput>: 
  - `ReplicationScenario <String>`: The class type.

## RELATED LINKS

