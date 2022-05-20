---
external help file:
Module Name: Az.SiteRecovery
online version: https://docs.microsoft.com/en-us/powershell/module/az.siterecovery/switch-azsiterecoveryreplicationprotectioncontainerprotection
schema: 2.0.0
---

# Switch-AzSiteRecoveryReplicationProtectionContainerProtection

## SYNOPSIS
Operation to switch protection from one container to another or one replication provider to another.

## SYNTAX

### SwitchExpanded (Default)
```
Switch-AzSiteRecoveryReplicationProtectionContainerProtection -FabricName <String>
 -ProtectionContainerName <String> -ResourceGroupName <String> -ResourceName <String>
 [-SubscriptionId <String>] [-ProviderSpecificDetailInstanceType <String>]
 [-ReplicationProtectedItemName <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Switch
```
Switch-AzSiteRecoveryReplicationProtectionContainerProtection -FabricName <String>
 -ProtectionContainerName <String> -ResourceGroupName <String> -ResourceName <String>
 -SwitchInput <ISwitchProtectionInput> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### SwitchViaIdentity
```
Switch-AzSiteRecoveryReplicationProtectionContainerProtection -InputObject <ISiteRecoveryIdentity>
 -SwitchInput <ISwitchProtectionInput> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### SwitchViaIdentityExpanded
```
Switch-AzSiteRecoveryReplicationProtectionContainerProtection -InputObject <ISiteRecoveryIdentity>
 [-ProviderSpecificDetailInstanceType <String>] [-ReplicationProtectedItemName <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Operation to switch protection from one container to another or one replication provider to another.

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

### -FabricName
Unique fabric name.

```yaml
Type: System.String
Parameter Sets: Switch, SwitchExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SiteRecovery.Models.ISiteRecoveryIdentity
Parameter Sets: SwitchViaIdentity, SwitchViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -ProtectionContainerName
Protection container name.

```yaml
Type: System.String
Parameter Sets: Switch, SwitchExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProviderSpecificDetailInstanceType
Gets the Instance type.

```yaml
Type: System.String
Parameter Sets: SwitchExpanded, SwitchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReplicationProtectedItemName
The unique replication protected item name.

```yaml
Type: System.String
Parameter Sets: SwitchExpanded, SwitchViaIdentityExpanded
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
Parameter Sets: Switch, SwitchExpanded
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
Parameter Sets: Switch, SwitchExpanded
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
Parameter Sets: Switch, SwitchExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -SwitchInput
Switch protection input.
To construct, see NOTES section for SWITCHINPUT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SiteRecovery.Models.Api20220301.ISwitchProtectionInput
Parameter Sets: Switch, SwitchViaIdentity
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

### Microsoft.Azure.PowerShell.Cmdlets.SiteRecovery.Models.Api20220301.ISwitchProtectionInput

### Microsoft.Azure.PowerShell.Cmdlets.SiteRecovery.Models.ISiteRecoveryIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SiteRecovery.Models.Api20220301.IProtectionContainer

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <ISiteRecoveryIdentity>: Identity Parameter
  - `[AlertSettingName <String>]`: The name of the email notification configuration.
  - `[EventName <String>]`: The name of the Azure Site Recovery event.
  - `[FabricName <String>]`: Fabric name.
  - `[Id <String>]`: Resource identity path
  - `[IntentObjectName <String>]`: Replication protection intent name.
  - `[JobName <String>]`: Job identifier.
  - `[LogicalNetworkName <String>]`: Logical network name.
  - `[MappingName <String>]`: Protection Container mapping name.
  - `[MigrationItemName <String>]`: Migration item name.
  - `[MigrationRecoveryPointName <String>]`: The migration recovery point name.
  - `[NetworkMappingName <String>]`: Network mapping name.
  - `[NetworkName <String>]`: Primary network name.
  - `[PolicyName <String>]`: Replication policy name.
  - `[ProtectableItemName <String>]`: Protectable item name.
  - `[ProtectionContainerName <String>]`: Protection container name.
  - `[ProviderName <String>]`: Recovery services provider name.
  - `[RecoveryPlanName <String>]`: Name of the recovery plan.
  - `[RecoveryPointName <String>]`: The recovery point name.
  - `[ReplicatedProtectedItemName <String>]`: Replication protected item name.
  - `[ReplicationProtectedItemName <String>]`: The name of the protected item on which the agent is to be updated.
  - `[ResourceGroupName <String>]`: The name of the resource group where the recovery services vault is present.
  - `[ResourceName <String>]`: The name of the recovery services vault.
  - `[StorageClassificationMappingName <String>]`: Storage classification mapping name.
  - `[StorageClassificationName <String>]`: Storage classification name.
  - `[SubscriptionId <String>]`: The subscription Id.
  - `[VaultSettingName <String>]`: Vault setting name.
  - `[VcenterName <String>]`: vcenter name.
  - `[VirtualMachineName <String>]`: Virtual Machine name.

SWITCHINPUT <ISwitchProtectionInput>: Switch protection input.
  - `[ProviderSpecificDetailInstanceType <String>]`: Gets the Instance type.
  - `[ReplicationProtectedItemName <String>]`: The unique replication protected item name.

## RELATED LINKS

