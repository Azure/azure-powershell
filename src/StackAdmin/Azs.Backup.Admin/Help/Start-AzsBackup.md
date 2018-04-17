---
external help file: Azs.Backup.Admin-help.xml
Module Name: Azs.Backup.Admin
online version: 
schema: 2.0.0
---

# Start-AzsBackup

## SYNOPSIS
Back up a specific location.

## SYNTAX

### CreateBackup (Default)
```
Start-AzsBackup [-ResourceGroupName <String>] [-Location <String>] [-Wait] [<CommonParameters>]
```

### CreateBackup_FromResourceId
```
Start-AzsBackup -ResourceId <String> [-Wait] [<CommonParameters>]
```

## DESCRIPTION
Back up a specific location.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
Start-AzsBackup -ResourceGroupName system.local -Location local
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

Start an Azure Stack backup.

## PARAMETERS

### -Location
Name of the backup location.

```yaml
Type: String
Parameter Sets: CreateBackup
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the resource group.

```yaml
Type: String
Parameter Sets: CreateBackup
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
{{Fill ResourceId Description}}

```yaml
Type: String
Parameter Sets: CreateBackup_FromResourceId
Aliases: id

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Wait
{{Fill Wait Description}}

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.AzureStack.Management.Backup.Admin.Models.LongRunningOperationStatus

## NOTES

## RELATED LINKS

