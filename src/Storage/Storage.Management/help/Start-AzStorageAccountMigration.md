---
external help file: Az.Storage-help.xml
Module Name: Az.Storage
online version: https://learn.microsoft.com/powershell/module/az.storage/start-azstorageaccountmigration
schema: 2.0.0
---

# Start-AzStorageAccountMigration

## SYNOPSIS
Account Migration request can be triggered for a storage account to change its redundancy level.
The migration updates the non-zonal redundant storage account to a zonal redundant account or vice-versa in order to have better reliability and availability.
Zone-redundant storage (ZRS) replicates your storage account synchronously across three Azure availability zones in the primary region.

## SYNTAX

### CustomerExpanded (Default)
```
Start-AzStorageAccountMigration -AccountName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -TargetSku <String> [-Name <String>] [-Type <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-PassThru] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CustomerViaJsonFilePath
```
Start-AzStorageAccountMigration -AccountName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CustomerViaJsonString
```
Start-AzStorageAccountMigration -AccountName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CustomerViaIdentityExpanded
```
Start-AzStorageAccountMigration -InputObject <IStorageIdentity> -TargetSku <String> [-Name <String>]
 [-Type <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Account Migration request can be triggered for a storage account to change its redundancy level.
The migration updates the non-zonal redundant storage account to a zonal redundant account or vice-versa in order to have better reliability and availability.
Zone-redundant storage (ZRS) replicates your storage account synchronously across three Azure availability zones in the primary region.

## EXAMPLES

### Example 1: Start a Storage account migration
```powershell
Start-AzStorageAccountMigration -AccountName myaccount -ResourceGroupName myresourcegroup -TargetSku Standard_LRS -Name migration1 -AsJob
```

This command starts a migration to Standard_LRS for Storage account myaccount under resource group myresourcegroup.

### Example 2: Start a Storage account migration by pipeline
```powershell
Get-AzStorageAccount -ResourceGroupName myresourcegroup -Name myaccount | Start-AzStorageAccountMigration  -TargetSku Standard_LRS -AsJob
```

The first command gets a Storage account Id, and then the second command starts a migration to Standard_LRS for Storage account myaccount under resource group myresourcegroup.

### Example 3: Start a Storage account migration with Json string input
```powershell
$properties = '{
   "properties": {
     "targetSkuName": "Standard_ZRS"
   }
}'
 Start-AzStorageAccountMigration -ResourceGroupName myresourcegroup -AccountName myaccount -JsonString $properties -AsJob
```

This command starts a Storage account migration by inputting the TargetSkuName property with a Json string.

### Example 4: Start a Storage account migration with a Json file path input
```powershell
# Before executing the cmdlet, make sure you have a json file that contains {"properties": {"targetSkuName": <TargetSKU>}} 
Start-AzStorageAccountMigration -ResourceGroupName myresourcegroup -AccountName myaccount -JsonFilePath properties.json -AsJob
```

This command starts a Storage account migration by inputting the TargetSkuName property with a Json file path.

## PARAMETERS

### -AccountName
The name of the storage account within the specified resource group.
Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.

```yaml
Type: System.String
Parameter Sets: CustomerExpanded, CustomerViaJsonFilePath, CustomerViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IStorageIdentity
Parameter Sets: CustomerViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Customer operation

```yaml
Type: System.String
Parameter Sets: CustomerViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Customer operation

```yaml
Type: System.String
Parameter Sets: CustomerViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
current value is 'default' for customer initiated migration

```yaml
Type: System.String
Parameter Sets: CustomerExpanded, CustomerViaIdentityExpanded
Aliases:

Required: False
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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group within the user's subscription.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: CustomerExpanded, CustomerViaJsonFilePath, CustomerViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: CustomerExpanded, CustomerViaJsonFilePath, CustomerViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetSku
Target sku name for the account

```yaml
Type: System.String
Parameter Sets: CustomerExpanded, CustomerViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type
SrpAccountMigrationType in ARM contract which is 'accountMigrations'

```yaml
Type: System.String
Parameter Sets: CustomerExpanded, CustomerViaIdentityExpanded
Aliases:

Required: False
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

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IStorageIdentity

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
