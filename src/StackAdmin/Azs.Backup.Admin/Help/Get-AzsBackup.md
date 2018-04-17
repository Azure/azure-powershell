---
external help file: Azs.Backup.Admin-help.xml
Module Name: Azs.Backup.Admin
online version: 
schema: 2.0.0
---

# Get-AzsBackup

## SYNOPSIS
Returns a backup from a location based on name.

## SYNTAX

### List (Default)
```
Get-AzsBackup [-Location <String>] [-ResourceGroupName <String>] [-Top <Int32>] [-Skip <Int32>]
 [<CommonParameters>]
```

### Get
```
Get-AzsBackup -Name <String> [-Location <String>] [-ResourceGroupName <String>] [<CommonParameters>]
```

### ResourceId
```
Get-AzsBackup -ResourceId <String> [<CommonParameters>]
```

### ParentObject
```
Get-AzsBackup -ParentObject <BackupLocation> [-Top <Int32>] [-Skip <Int32>] [<CommonParameters>]
```

## DESCRIPTION
Returns a backup from a location based on name.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
Get-AzsBackup -ResourceGroupName system.local -Location local
```

BackupDataVersion :
BackupId          : 4e90bd2f-c7ab-47a3-a3c7-908cddd1ad0e
RoleStatus        : {NRP, SRP, CRP, KeyVaultInternalControlPlane...}
Status            : Succeeded
CreatedDateTime   : 3/15/2018 1:31:01 AM
TimeTakenToCreate : PT6M41.7853037S
Id                : /subscriptions/b3d6379e-711c-48eb-b051-3c71305ec104/resourceGroups/system.local/providers/Microsoft.Backup.Admin/backupLocations/local/backups/4e90bd2f-c7ab-47a3-a3c7-908cddd1ad0e
Name              : 4e90bd2f-c7ab-47a3-a3c7-908cddd1ad0e
Type              : Microsoft.Backup.Admin/backupLocations/backups
Location          : local
Tags              : {}

Get information for the the specified Azure Stack backup.

## PARAMETERS

### -Location
Location backed up.

```yaml
Type: String
Parameter Sets: List, Get
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the backup.

```yaml
Type: String
Parameter Sets: Get
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ParentObject
{{Fill ParentObject Description}}

```yaml
Type: BackupLocation
Parameter Sets: ParentObject
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the resource group.

```yaml
Type: String
Parameter Sets: List, Get
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource id.

```yaml
Type: String
Parameter Sets: ResourceId
Aliases: id

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Skip
{{Fill Skip Description}}

```yaml
Type: Int32
Parameter Sets: List, ParentObject
Aliases: 

Required: False
Position: Named
Default value: -1
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
{{Fill Top Description}}

```yaml
Type: Int32
Parameter Sets: List, ParentObject
Aliases: 

Required: False
Position: Named
Default value: -1
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.AzureStack.Management.Backup.Admin.Models.Backup

## NOTES

## RELATED LINKS

