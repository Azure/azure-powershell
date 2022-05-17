---
external help file:
Module Name: Az.DataProtection
online version: https://docs.microsoft.com/powershell/module/az.dataprotection/test-azdataprotectionbackupinstancerestore
schema: 2.0.0
---

# Test-AzDataProtectionBackupInstanceRestore

## SYNOPSIS
Validates if Restore can be triggered for a DataSource

## SYNTAX

### ValidateViaIdentity1 (Default)
```
Test-AzDataProtectionBackupInstanceRestore -InputObject <IDataProtectionIdentity>
 -Parameter <IValidateRestoreRequestObject> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Validate1
```
Test-AzDataProtectionBackupInstanceRestore -Name <String> -ResourceGroupName <String> -VaultName <String>
 -Parameter <IValidateRestoreRequestObject> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateExpanded1
```
Test-AzDataProtectionBackupInstanceRestore -Name <String> -ResourceGroupName <String> -VaultName <String>
 -RestoreRequestObjectRestoreTargetInfo <IRestoreTargetInfoBase>
 -RestoreRequestObjectSourceDataStoreType <SourceDataStoreType> -RestoreRequestObjectType <String>
 [-SubscriptionId <String>] [-RestoreRequestObjectSourceResourceId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateViaIdentityExpanded1
```
Test-AzDataProtectionBackupInstanceRestore -InputObject <IDataProtectionIdentity>
 -RestoreRequestObjectRestoreTargetInfo <IRestoreTargetInfoBase>
 -RestoreRequestObjectSourceDataStoreType <SourceDataStoreType> -RestoreRequestObjectType <String>
 [-RestoreRequestObjectSourceResourceId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Validates if Restore can be triggered for a DataSource

## EXAMPLES

### Example 1: Test the backup instance object for restore operation
```powershell
    $instances  = Get-AzDataProtectionBackupInstance -Subscription "subscription/xxxxx-xxxxx-xxx" -ResourceGroup "myrg" -Vault "Myvault" 
    $pointInTimeRange = Find-AzDataProtectionRestorableTimeRange -BackupInstanceName $instances[0].BackupInstanceName -ResourceGroupName "myrg" -SubscriptionId "subscription/xxxxx-xxxxx-xxx"" -VaultName "myvault" -SourceDataStoreType OperationalStore -StartTime (Get-Date).AddDays(-30).ToString("yyyy-MM-ddTHH:mm:ss.0000000Z") -EndTime (Get-Date).AddDays(0).ToString("yyyy-MM-ddTHH:mm:ss.0000000Z")
	$vault = Get-AzDataProtectionBackupVault -ResourceGroupName "myrg" -SubscriptionId "subscription/xxxxx-xxxxx-xxx" -VaultName "Myvault"
	$RestoreRequestObject = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureBlob -SourceDataStore OperationalStore -RestoreLocation $vault.Location -RestoreType OriginalLocation -BackupInstance $instances[0] -PointInTime (Get-Date -Date $pointInTimeRange.RestorableTimeRange.EndTime)

	Test-AzDataProtectionBackupInstanceRestore -InputObject $instances[0] -Parameter $RestoreRequestObject
```

The command tests the backup instance object for restore options

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IDataProtectionIdentity
Parameter Sets: ValidateViaIdentity1, ValidateViaIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the backup instance

```yaml
Type: System.String
Parameter Sets: Validate1, ValidateExpanded1
Aliases: BackupInstanceName

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

### -Parameter
Validate restore request object
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IValidateRestoreRequestObject
Parameter Sets: Validate1, ValidateViaIdentity1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group where the backup vault is present.

```yaml
Type: System.String
Parameter Sets: Validate1, ValidateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RestoreRequestObjectRestoreTargetInfo
Gets or sets the restore target information.
To construct, see NOTES section for RESTOREREQUESTOBJECTRESTORETARGETINFO properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IRestoreTargetInfoBase
Parameter Sets: ValidateExpanded1, ValidateViaIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RestoreRequestObjectSourceDataStoreType
Gets or sets the type of the source data store.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.SourceDataStoreType
Parameter Sets: ValidateExpanded1, ValidateViaIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RestoreRequestObjectSourceResourceId
Fully qualified Azure Resource Manager ID of the datasource which is being recovered.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded1, ValidateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RestoreRequestObjectType
.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded1, ValidateViaIdentityExpanded1
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
Parameter Sets: Validate1, ValidateExpanded1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -VaultName
The name of the backup vault.

```yaml
Type: System.String
Parameter Sets: Validate1, ValidateExpanded1
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

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IValidateRestoreRequestObject

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IDataProtectionIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IOperationJobExtendedInfo

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IDataProtectionIdentity>: Identity Parameter
  - `[BackupInstanceName <String>]`: The name of the backup instance
  - `[BackupPolicyName <String>]`: 
  - `[Id <String>]`: Resource identity path
  - `[JobId <String>]`: The Job ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).
  - `[Location <String>]`: The location in which uniqueness will be verified.
  - `[OperationId <String>]`: 
  - `[RecoveryPointId <String>]`: 
  - `[RequestName <String>]`: 
  - `[ResourceGroupName <String>]`: The name of the resource group where the backup vault is present.
  - `[ResourceGuardsName <String>]`: The name of ResourceGuard
  - `[SubscriptionId <String>]`: The subscription Id.
  - `[VaultName <String>]`: The name of the backup vault.

PARAMETER <IValidateRestoreRequestObject>: Validate restore request object
  - `RestoreRequestObjectRestoreTargetInfo <IRestoreTargetInfoBase>`: Gets or sets the restore target information.
    - `ObjectType <String>`: Type of Datasource object, used to initialize the right inherited type
    - `[RestoreLocation <String>]`: Target Restore region
  - `RestoreRequestObjectSourceDataStoreType <SourceDataStoreType>`: Gets or sets the type of the source data store.
  - `RestoreRequestObjectType <String>`: 
  - `[RestoreRequestObjectSourceResourceId <String>]`: Fully qualified Azure Resource Manager ID of the datasource which is being recovered.

RESTOREREQUESTOBJECTRESTORETARGETINFO <IRestoreTargetInfoBase>: Gets or sets the restore target information.
  - `ObjectType <String>`: Type of Datasource object, used to initialize the right inherited type
  - `[RestoreLocation <String>]`: Target Restore region

## RELATED LINKS

