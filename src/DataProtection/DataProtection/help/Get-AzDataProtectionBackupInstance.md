---
external help file: Az.DataProtection-help.xml
Module Name: Az.DataProtection
online version: https://learn.microsoft.com/powershell/module/az.dataprotection/get-azdataprotectionbackupinstance
schema: 2.0.0
---

# Get-AzDataProtectionBackupInstance

## SYNOPSIS
Gets a backup instance with name in a backup vault

## SYNTAX

### List (Default)
```
Get-AzDataProtectionBackupInstance -ResourceGroupName <String> [-SubscriptionId <String[]>] -VaultName <String>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzDataProtectionBackupInstance -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 -VaultName <String> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDataProtectionBackupInstance -InputObject <IDataProtectionIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Gets a backup instance with name in a backup vault

## EXAMPLES

### Example 1: Get all the backup instances protected in a specified backup vault.
```powershell
Get-AzDataProtectionBackupInstance -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "MyResourceGroup" -VaultName "MyVault"
```

```output
Name                                                         Type                                                  BackupInstanceName
----                                                         ----                                                  ------------------
sarathdisk-sarathdisk-xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx   Microsoft.DataProtection/backupVaults/backupInstances sarathdisk-sarathdisk-xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
sarathdisk2-sarathdisk2-xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxxcc Microsoft.DataProtection/backupVaults/backupInstances sarathdisk2-sarathdisk2-xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
```

This command gets all the backup instances in a vault.

### Example 2: Get a backup instance by name.
```powershell
Get-AzDataProtectionBackupInstance -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "MyResourceGroup" -VaultName "MyVault" -Name "BackupInstanceName"
```

```output
Name                                                       Type                                                  BackupInstanceName
----                                                       ----                                                  ------------------
sarathdisk-sarathdisk-xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx Microsoft.DataProtection/backupVaults/backupInstances sarathdisk-sarathdisk-xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
```

This command gets a specific backup instance protected in a backup vault.

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

### -Name
The name of the backup instance.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: BackupInstanceName

Required: True
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
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: List, Get
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
Parameter Sets: List, Get
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
Parameter Sets: List, Get
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

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IDataProtectionIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.IBackupInstanceResource

## NOTES

## RELATED LINKS
