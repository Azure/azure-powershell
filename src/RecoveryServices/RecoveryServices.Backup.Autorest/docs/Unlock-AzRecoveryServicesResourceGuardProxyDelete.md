---
external help file:
Module Name: Az.RecoveryServices
online version: https://docs.microsoft.com/powershell/module/az.recoveryservices/unlock-azrecoveryservicesresourceguardproxydelete
schema: 2.0.0
---

# Unlock-AzRecoveryServicesResourceGuardProxyDelete

## SYNOPSIS
Secures delete ResourceGuardProxy operations.

## SYNTAX

### UnlockExpanded (Default)
```
Unlock-AzRecoveryServicesResourceGuardProxyDelete -ResourceGroupName <String> -ResourceGuardProxyName <String>
 -VaultName <String> [-SubscriptionId <String>] [-ResourceGuardOperationRequest <String[]>]
 [-ResourceToBeDeleted <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Unlock
```
Unlock-AzRecoveryServicesResourceGuardProxyDelete -ResourceGroupName <String> -ResourceGuardProxyName <String>
 -VaultName <String> -Parameter <IUnlockDeleteRequest> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UnlockViaIdentity
```
Unlock-AzRecoveryServicesResourceGuardProxyDelete -InputObject <IRecoveryServicesIdentity>
 -Parameter <IUnlockDeleteRequest> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UnlockViaIdentityExpanded
```
Unlock-AzRecoveryServicesResourceGuardProxyDelete -InputObject <IRecoveryServicesIdentity>
 [-ResourceGuardOperationRequest <String[]>] [-ResourceToBeDeleted <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Secures delete ResourceGuardProxy operations.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.IRecoveryServicesIdentity
Parameter Sets: UnlockViaIdentity, UnlockViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Parameter
Request body of unlock delete API.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IUnlockDeleteRequest
Parameter Sets: Unlock, UnlockViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group where the recovery services vault is present.

```yaml
Type: System.String
Parameter Sets: Unlock, UnlockExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGuardOperationRequest
.

```yaml
Type: System.String[]
Parameter Sets: UnlockExpanded, UnlockViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGuardProxyName
.

```yaml
Type: System.String
Parameter Sets: Unlock, UnlockExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceToBeDeleted
.

```yaml
Type: System.String
Parameter Sets: UnlockExpanded, UnlockViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription Id.

```yaml
Type: System.String
Parameter Sets: Unlock, UnlockExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -VaultName
The name of the recovery services vault.

```yaml
Type: System.String
Parameter Sets: Unlock, UnlockExpanded
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IUnlockDeleteRequest

### Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.IRecoveryServicesIdentity

## OUTPUTS

### System.String

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IRecoveryServicesIdentity>`: Identity Parameter
  - `[AzureRegion <String>]`: Azure region to hit Api
  - `[BackupEngineName <String>]`: Name of the backup management server.
  - `[ContainerName <String>]`: 
  - `[FabricName <String>]`: Fabric name associated with the backed up item.
  - `[Id <String>]`: Resource identity path
  - `[IntentObjectName <String>]`: Backed up item name whose details are to be fetched.
  - `[JobName <String>]`: Name of the job whose details are to be fetched.
  - `[OperationId <String>]`: Operation id
  - `[PolicyName <String>]`: Backup policy information to be fetched.
  - `[PrivateEndpointConnectionName <String>]`: The name of the private endpoint connection.
  - `[ProtectedItemName <String>]`: 
  - `[RecoveryPointId <String>]`: 
  - `[ResourceGroupName <String>]`: The name of the resource group where the recovery services vault is present.
  - `[ResourceGuardProxyName <String>]`: 
  - `[SubscriptionId <String>]`: The subscription Id.
  - `[VaultName <String>]`: The name of the recovery services vault.

`PARAMETER <IUnlockDeleteRequest>`: Request body of unlock delete API.
  - `[ResourceGuardOperationRequest <String[]>]`: 
  - `[ResourceToBeDeleted <String>]`: 

## RELATED LINKS

