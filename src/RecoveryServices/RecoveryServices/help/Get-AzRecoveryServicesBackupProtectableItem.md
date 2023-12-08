---
external help file: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Backup.dll-help.xml
Module Name: Az.RecoveryServices
online version: https://learn.microsoft.com/powershell/module/az.recoveryservices/get-azrecoveryservicesbackupprotectableitem
schema: 2.0.0
---

# Get-AzRecoveryServicesBackupProtectableItem

## SYNOPSIS
This command will retrieve all protectable items within a certain container or across all registered containers.
It will consist of all the elements of the hierarchy of the application.
Returns DBs and their upper tier entities like Instance, AvailabilityGroup etc.

## SYNTAX

### FilterParamSet (Default)
```
Get-AzRecoveryServicesBackupProtectableItem -ResourceGroupName <String> -VaultName <String>
 -DatasourceType <DatasourceTypes> [-SubscriptionId <String[]>] [-Container <IProtectionContainerResource>]
 [-ItemType <String>] [-Name <String>] [-ServerName <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### IdParamSet
```
Get-AzRecoveryServicesBackupProtectableItem -ResourceGroupName <String> -VaultName <String>
 [-SubscriptionId <String[]>] [-ItemType <String>] [-Name <String>] [-ServerName <String>]
 [-DefaultProfile <PSObject>] -ParentID <String> [<CommonParameters>]
```

## DESCRIPTION
This command will retrieve all protectable items within a certain container or across all registered containers.
It will consist of all the elements of the hierarchy of the application.
Returns DBs and their upper tier entities like Instance, AvailabilityGroup etc.

## EXAMPLES

### Example 1: List protectable items for datasource type MSSQL
```powershell
$proItems = Get-AzRecoveryServicesBackupProtectableItem -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subscriptionId -DatasourceType "MSSQL"
$proItems
```

```output
ETag Location Name                           AutoProtectionPolicy
---- -------- ----                           --------------------
              sqlinstance;mssqlserver
              sqldatabase;mssqlserver;master
              sqldatabase;mssqlserver;model
```

This command is used to fetch protectable items for DatasourceType MSSQL which can be protected by a recovery services vault.

### Example 2: Filter protectable items based on Container, Name, ServerName, ItemType
```powershell
$proItems = Get-AzRecoveryServicesBackupProtectableItem -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subscriptionId -DatasourceType MSSQL -ItemType SQLInstance -ServerName $serverName -Container $container -Name $protectableItemName
$proItems[0] | fl
```

```output
AutoProtectionPolicy :
NodesList            :
BackupManagementType : AzureWorkload
ETag                 :
FriendlyName         : MSSQLSERVER
Id                   : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/hiagarg/providers/Microsoft.RecoveryServices/vaults/hiagaVault/backupFabrics/Azure/protectionContainers/vmappcontainer;compute;hiagarg;sql-vm1/protectableItems/sqlinstance;mssqlserver
Location             :
Name                 : sqlinstance;mssqlserver
Property             : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.AzureVMWorkloadSqlInstanceProtectableItem
ProtectableItemType  : SQLInstance
ProtectionState      : NotProtected
Tag                  : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.ResourceTags
Type                 : Microsoft.RecoveryServices/vaults/backupFabrics/protectionContainers/protectableItems
WorkloadType         : SQL
```

The above command shows an example on how to filter protectable items based on Container, Name, ServerName, ItemType.

## PARAMETERS

### -Container
Specifies a container object for which this cmdlet gets protectable items.
To obtain an ProtectionContainerResource, use the Get-AzRecoveryServicesBackupContainer cmdlet
To construct, see NOTES section for CONTAINER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionContainerResource
Parameter Sets: FilterParamSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatasourceType
Specifies the DatasourceType

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support.DatasourceTypes
Parameter Sets: FilterParamSet
Aliases:
Accepted values: AzureVM, MSSQL, SAPHANA, AzureFiles

Required: True
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

### -ItemType
Specifies the type of protectable item.
Acceptable values: SQLDataBase, SQLInstance, SQLAvailabilityGroup

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Specifies the name of the Database, Instance or AvailabilityGroup

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ParentID
Specifies the ARM ID of an Instance or Availability Group

```yaml
Type: System.String
Parameter Sets: IdParamSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group where the recovery services vault is present

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

### -ServerName
Specifies the name of the server to which the item belongs

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription Id

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VaultName
The name of the recovery services vault

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IWorkloadProtectableItemResource

## NOTES

## RELATED LINKS
