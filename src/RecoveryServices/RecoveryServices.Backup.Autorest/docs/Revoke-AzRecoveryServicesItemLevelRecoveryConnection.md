---
external help file:
Module Name: Az.RecoveryServices
online version: https://docs.microsoft.com/powershell/module/az.recoveryservices/revoke-azrecoveryservicesitemlevelrecoveryconnection
schema: 2.0.0
---

# Revoke-AzRecoveryServicesItemLevelRecoveryConnection

## SYNOPSIS
Revokes an iSCSI connection which can be used to download a script.
Executing this script opens a file explorer\r\ndisplaying all recoverable files and folders.
This is an asynchronous operation.

## SYNTAX

### Revoke (Default)
```
Revoke-AzRecoveryServicesItemLevelRecoveryConnection -ContainerName <String> -FabricName <String>
 -ProtectedItemName <String> -RecoveryPointId <String> -ResourceGroupName <String> -VaultName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RevokeViaIdentity
```
Revoke-AzRecoveryServicesItemLevelRecoveryConnection -InputObject <IRecoveryServicesIdentity>
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Revokes an iSCSI connection which can be used to download a script.
Executing this script opens a file explorer\r\ndisplaying all recoverable files and folders.
This is an asynchronous operation.

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

### -ContainerName
Container name associated with the backed up items.

```yaml
Type: System.String
Parameter Sets: Revoke
Aliases:

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

### -FabricName
Fabric name associated with the backed up items.

```yaml
Type: System.String
Parameter Sets: Revoke
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
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.IRecoveryServicesIdentity
Parameter Sets: RevokeViaIdentity
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

### -ProtectedItemName
Backed up item name whose files/folders are to be restored.

```yaml
Type: System.String
Parameter Sets: Revoke
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecoveryPointId
Recovery point ID which represents backed up data.
iSCSI connection will be revoked for
this backed up data.

```yaml
Type: System.String
Parameter Sets: Revoke
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
Parameter Sets: Revoke
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
Parameter Sets: Revoke
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
Parameter Sets: Revoke
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

### Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.IRecoveryServicesIdentity

## OUTPUTS

### System.Boolean

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

## RELATED LINKS

