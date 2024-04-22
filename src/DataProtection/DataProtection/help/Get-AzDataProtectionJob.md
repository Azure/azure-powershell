---
external help file: Az.DataProtection-help.xml
Module Name: Az.DataProtection
online version: https://learn.microsoft.com/powershell/module/az.dataprotection/get-azdataprotectionjob
schema: 2.0.0
---

# Get-AzDataProtectionJob

## SYNOPSIS
Gets or lists jobs in a backup vault

## SYNTAX

### List (Default)
```
Get-AzDataProtectionJob -ResourceGroupName <String> -VaultName <String> [-SubscriptionId <String[]>]
 [-UseSecondaryRegion] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzDataProtectionJob -ResourceGroupName <String> -VaultName <String> [-SubscriptionId <String[]>]
 [-UseSecondaryRegion] [-DefaultProfile <PSObject>] -Id <String> [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDataProtectionJob [-DefaultProfile <PSObject>] -InputObject <IDataProtectionIdentity>
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Gets or lists jobs in a backup vault

## EXAMPLES

### Example 1: Get All backup Jobs in a backup vault
```powershell
Get-AzDataProtectionJob -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName sarath-rg -VaultName sarath-vault
```

```output
Name                                 Type
----                                 ----
a6a4879d-f914-4174-b129-0e27da8a4fb0 Microsoft.DataProtection/backupVaults/backupJobs
1a402664-a245-4a9d-8bb5-a6bafbb40d26 Microsoft.DataProtection/backupVaults/backupJobs
672564f7-1f91-46e2-a0ca-4fb1dc977a1c Microsoft.DataProtection/backupVaults/backupJobs
1653a7b4-8ce4-457e-8084-dc1c9d9e4106 Microsoft.DataProtection/backupVaults/backupJobs
9f21c438-ca0d-45c1-88fe-79f08a8342c7 Microsoft.DataProtection/backupVaults/backupJobs
736bab4d-480f-49f8-92ea-57c5ff203c33 Microsoft.DataProtection/backupVaults/backupJobs
```

This command gets all the backup jobs in a given backup vault.

### Example 2: Get a single Job with Id
```powershell
Get-AzDataProtectionJob -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName sarath-rg -VaultName sarath-vault -Id 4abaea8c-f53a-4bb1-9963-59f96b597165
```

```output
Name                                 Type
----                                 ----
4abaea8c-f53a-4bb1-9963-59f96b597165 Microsoft.DataProtection/backupVaults/backupJobs
```

This command returns a single job entity with given Id.

### Example 3: Get backup Jobs in a backup vault from secondary region
```powershell
Get-AzDataProtectionJob -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName sarath-rg -VaultName sarath-vault -UseSecondaryRegion
```

```output
Name                                 Type
----                                 ----
a6a4879d-f914-4174-b129-0e27da8a4fb0 Microsoft.DataProtection/backupVaults/backupJobs
1a402664-a245-4a9d-8bb5-a6bafbb40d26 Microsoft.DataProtection/backupVaults/backupJobs
```

This command gets cross region restore jobs in a backup vault from secondary region.

## PARAMETERS

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

### -Id
Job ID to get a particular Job

```yaml
Type: System.String
Parameter Sets: Get
Aliases: JobId

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
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IDataProtectionIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
Resource Group of the backup vault

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
Subscription Id of the vault

```yaml
Type: System.String[]
Parameter Sets: List, Get
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UseSecondaryRegion
Switch parameter to fetch dataprotection job from secondary region (Cross Region Restore)

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: List, Get
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VaultName
Name of the backup vault

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

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.IAzureBackupJobResource

## NOTES

## RELATED LINKS
