---
external help file:
Module Name: Az.DataProtection
online version: https://learn.microsoft.com/powershell/module/az.dataprotection/get-azdataprotectionoperationstatus
schema: 2.0.0
---

# Get-AzDataProtectionOperationStatus

## SYNOPSIS
Gets the operation status for a resource.

## SYNTAX

### Get (Default)
```
Get-AzDataProtectionOperationStatus -Location <String> -OperationId <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDataProtectionOperationStatus -InputObject <IDataProtectionIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the operation status for a resource.

## EXAMPLES

### Example 1: Get operation status for a long running operation
```powershell
$operationResponse = Test-AzDataProtectionBackupInstanceReadiness -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subId -BackupInstance $backupInstanceClientObject.Property -NoWait
$operationId = $operationResponse.Target.Split("/")[-1].Split("?")[0]
Get-AzDataProtectionOperationStatus -OperationId $operationId -Location $vault.Location -SubscriptionId $subId
While((Get-AzDataProtectionOperationStatus -OperationId $operationId -Location $vault.Location -SubscriptionId $subId).Status -eq "Inprogress"){
	Start-Sleep -Seconds 10
}
```

```output
EndTime              Name                                                                                                 StartTime            Status
-------              ----                                                                                                 ---------            ------
5/6/2023 11:44:42 AM N2E2NGU0YzItMzZjNC00MDUwLTlmZGYtMGNlZTFjMmI4MWRhO2U3MjRiMGExLTM3NGItNGYwYS05ZDRlLTQxZWQ5Nzg5MzhkZg== 5/6/2023 11:44:21 AM Succeeded
```

First command fetches the operation response for a long running operation, using the the parameter -NoWait.
This is to run the operation in async mode.
Second command splits the operationResponse to get the operationId.
Third command fetches the operation status in async way.
Fourth command fetches the operation status in a loop until it succeeds, while waiting 10 seconds before each iteration.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IDataProtectionIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
Azure region where the operation is triggered.

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

### -OperationId
Operation Id to track the operation status.

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
The ID of the target subscription.
The value must be an UUID.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IDataProtectionIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.IOperationResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IDataProtectionIdentity>`: Identity Parameter
  - `[BackupInstanceName <String>]`: The name of the backup instance.
  - `[BackupPolicyName <String>]`: 
  - `[Id <String>]`: Resource identity path
  - `[JobId <String>]`: The Job ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).
  - `[Location <String>]`: The location in which uniqueness will be verified.
  - `[OperationId <String>]`: 
  - `[RecoveryPointId <String>]`: 
  - `[RequestName <String>]`: 
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[ResourceGuardsName <String>]`: The name of ResourceGuard
  - `[SubscriptionId <String>]`: The ID of the target subscription. The value must be an UUID.
  - `[VaultName <String>]`: The name of the backup vault.

## RELATED LINKS

