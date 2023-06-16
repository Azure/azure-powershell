---
external help file:
Module Name: Az.RecoveryServices
online version: https://docs.microsoft.com/powershell/module/az.recoveryservices/new-azrecoveryservicesreplicationprotectioncontainermapping
schema: 2.0.0
---

# New-AzRecoveryServicesReplicationProtectionContainerMapping

## SYNOPSIS
The operation to create a protection container mapping.

## SYNTAX

```
New-AzRecoveryServicesReplicationProtectionContainerMapping -MappingName <String>
 -PrimaryProtectionContainer <IProtectionContainer> -ResourceGroupName <String> -ResourceName <String>
 -Policy <IPolicy> -ProviderSpecificInput <IReplicationProviderSpecificContainerMappingInput>
 -RecoveryProtectionContainer <IProtectionContainer> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The operation to create a protection container mapping.

## EXAMPLES

### Example 1: Create a new replication protection container mapping
```powershell
$policy=Get-AzRecoveryServicesReplicationPolicy -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -PolicyName "A2APolicy"
$mappingInput=[Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.A2AContainerMappingInput]::new()
$mappingInput.ReplicationScenario="ReplicateAzureToAzure"
$primaryfabric=Get-AzRecoveryServicesReplicationFabric -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -FabricName "A2Ademo-EastUS"
$primaryprotectioncontainer=Get-AzRecoveryServicesReplicationProtectionContainer -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -Fabric $primaryfabric -ProtectionContainer "A2AEastUSProtectionContainer"
$recoveryfabric=Get-AzRecoveryServicesReplicationFabric -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -FabricName "A2Aprimaryfabric"
$recoveryprotectioncontainer=Get-AzRecoveryServicesReplicationProtectionContainer -ResourceGroupName "a2arecoveryrg" -ResourceName "a2arecoveryvault" -Fabric $recoveryfabric -ProtectionContainer "demoProtectionContainer"
New-AzRecoveryServicesReplicationProtectionContainerMapping -MappingName "demomap" -PrimaryProtectionContainer $primaryprotectioncontainer -ResourceName "a2arecoveryvault" -ResourceGroupName "a2arecoveryrg" -ProviderSpecificInput $mappingInput -Policy $policy -RecoveryProtectionContainer $recoveryprotectioncontainer
```

```output
Id                                                                                                                                                                                                                                                                                                 Location Name    Type
--                                                                                                                                                                                                                                                                                                 -------- ----    ----
/Subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/a2arecoveryrg/providers/Microsoft.RecoveryServices/vaults/a2arecoveryvault/replicationFabrics/A2Ademo-EastUS/replicationProtectionContainers/A2AEastUSProtectionContainer/replicationProtectionContainerMappings/testmappingcmd			demomap	Microsoft.RecoveryServices/vaults/replicationFabrics/replicationProtectionContainers/replicationProtectionContainerMappings
```

Creates a New azure protection container mapping in a recovery services vault.

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

### -MappingName
Protection container mapping name.

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

### -Policy
Applicable policy object.
To construct, see NOTES section for POLICY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IPolicy
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrimaryProtectionContainer
Primary protection container object.
To construct, see NOTES section for PRIMARYPROTECTIONCONTAINER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionContainer
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProviderSpecificInput
Provider specific input for pairing.
To construct, see NOTES section for PROVIDERSPECIFICINPUT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IReplicationProviderSpecificContainerMappingInput
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecoveryProtectionContainer
The target unique protection container object.
To construct, see NOTES section for RECOVERYPROTECTIONCONTAINER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionContainer
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionContainerMapping

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`POLICY <IPolicy>`: Applicable policy object.
  - `[Location <String>]`: Resource Location
  - `[FriendlyName <String>]`: The FriendlyName.
  - `[ProviderSpecificDetailInstanceType <String>]`: Gets the class type. Overridden in derived classes.

`PRIMARYPROTECTIONCONTAINER <IProtectionContainer>`: Primary protection container object.
  - `[Location <String>]`: Resource Location
  - `[FabricFriendlyName <String>]`: Fabric friendly name.
  - `[FabricType <String>]`: The fabric type.
  - `[FriendlyName <String>]`: The name.
  - `[PairingStatus <String>]`: The pairing status of this cloud.
  - `[ProtectedItemCount <Int32?>]`: Number of protected PEs.
  - `[Role <String>]`: The role of this cloud.

`PROVIDERSPECIFICINPUT <IReplicationProviderSpecificContainerMappingInput>`: Provider specific input for pairing.
  - `ReplicationScenario <String>`: The class type.

`RECOVERYPROTECTIONCONTAINER <IProtectionContainer>`: The target unique protection container object.
  - `[Location <String>]`: Resource Location
  - `[FabricFriendlyName <String>]`: Fabric friendly name.
  - `[FabricType <String>]`: The fabric type.
  - `[FriendlyName <String>]`: The name.
  - `[PairingStatus <String>]`: The pairing status of this cloud.
  - `[ProtectedItemCount <Int32?>]`: Number of protected PEs.
  - `[Role <String>]`: The role of this cloud.

## RELATED LINKS

