---
external help file:
Module Name: Az.RecoveryServices
online version: https://docs.microsoft.com/powershell/module/az.recoveryservices/invoke-azrecoveryservicesprepare
schema: 2.0.0
---

# Invoke-AzRecoveryServicesPrepare

## SYNOPSIS
Prepares source vault for Data Move operation

## SYNTAX

### PrepareExpanded (Default)
```
Invoke-AzRecoveryServicesPrepare -ResourceGroupName <String> -VaultName <String>
 -DataMoveLevel <DataMoveLevel> -TargetRegion <String> -TargetResourceId <String> [-SubscriptionId <String>]
 [-IgnoreMoved] [-SourceContainerArmId <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Prepare
```
Invoke-AzRecoveryServicesPrepare -ResourceGroupName <String> -VaultName <String>
 -Parameter <IPrepareDataMoveRequest> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### PrepareViaIdentity
```
Invoke-AzRecoveryServicesPrepare -InputObject <IRecoveryServicesIdentity> -Parameter <IPrepareDataMoveRequest>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### PrepareViaIdentityExpanded
```
Invoke-AzRecoveryServicesPrepare -InputObject <IRecoveryServicesIdentity> -DataMoveLevel <DataMoveLevel>
 -TargetRegion <String> -TargetResourceId <String> [-IgnoreMoved] [-SourceContainerArmId <String[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Prepares source vault for Data Move operation

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

### -DataMoveLevel
DataMove Level

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support.DataMoveLevel
Parameter Sets: PrepareExpanded, PrepareViaIdentityExpanded
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

### -IgnoreMoved
Ignore the artifacts which are already moved.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: PrepareExpanded, PrepareViaIdentityExpanded
Aliases:

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
Parameter Sets: PrepareViaIdentity, PrepareViaIdentityExpanded
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

### -Parameter
Prepare DataMove Request
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IPrepareDataMoveRequest
Parameter Sets: Prepare, PrepareViaIdentity
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
The name of the resource group where the recovery services vault is present.

```yaml
Type: System.String
Parameter Sets: Prepare, PrepareExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceContainerArmId
Source Container ArmIdsThis needs to be populated only if DataMoveLevel is set to container

```yaml
Type: System.String[]
Parameter Sets: PrepareExpanded, PrepareViaIdentityExpanded
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
Parameter Sets: Prepare, PrepareExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetRegion
Target Region

```yaml
Type: System.String
Parameter Sets: PrepareExpanded, PrepareViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetResourceId
ARM Id of target vault

```yaml
Type: System.String
Parameter Sets: PrepareExpanded, PrepareViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VaultName
The name of the recovery services vault.

```yaml
Type: System.String
Parameter Sets: Prepare, PrepareExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IPrepareDataMoveRequest

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

`PARAMETER <IPrepareDataMoveRequest>`: Prepare DataMove Request
  - `DataMoveLevel <DataMoveLevel>`: DataMove Level
  - `TargetRegion <String>`: Target Region
  - `TargetResourceId <String>`: ARM Id of target vault
  - `[IgnoreMoved <Boolean?>]`: Ignore the artifacts which are already moved.
  - `[SourceContainerArmId <String[]>]`: Source Container ArmIds         This needs to be populated only if DataMoveLevel is set to container

## RELATED LINKS

