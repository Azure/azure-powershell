---
external help file:
Module Name: Az.RecoveryServices
online version: https://learn.microsoft.com/powershell/module/az.recoveryservices/get-azrecoveryservicesbackupoperationresult
schema: 2.0.0
---

# Get-AzRecoveryServicesBackupOperationResult

## SYNOPSIS
Provides the status of the delete operations such as deleting backed up item.
Once the operation has started, the\r\nstatus code in the response would be Accepted.
It will continue to be in this state till it reaches completion.
On\r\nsuccessful completion, the status code will be OK.
This method expects OperationID as an argument.
OperationID is\r\npart of the Location header of the operation response.

## SYNTAX

### Get (Default)
```
Get-AzRecoveryServicesBackupOperationResult -OperationId <String> -ResourceGroupName <String>
 -VaultName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-PassThru]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzRecoveryServicesBackupOperationResult -InputObject <IRecoveryServicesIdentity>
 [-DefaultProfile <PSObject>] [-PassThru] [<CommonParameters>]
```

## DESCRIPTION
Provides the status of the delete operations such as deleting backed up item.
Once the operation has started, the\r\nstatus code in the response would be Accepted.
It will continue to be in this state till it reaches completion.
On\r\nsuccessful completion, the status code will be OK.
This method expects OperationID as an argument.
OperationID is\r\npart of the Location header of the operation response.

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
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -OperationId
OperationID which represents the operation.

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
Parameter Sets: Get
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
Parameter Sets: Get
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
Parameter Sets: Get
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

### Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.IRecoveryServicesIdentity

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

