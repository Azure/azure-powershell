---
external help file: Azs.Compute.Admin-help.xml
Module Name: Azs.Compute.Admin
online version:
schema: 2.0.0
---

# Stop-AzsDiskMigrationJob

## SYNOPSIS
Cancel a managed disk migration job.

## SYNTAX

```
Stop-AzsDiskMigrationJob [[-Location] <String>] [[-Name] <String>] [<CommonParameters>]
```

## DESCRIPTION
Cancel a disk migration job.

## EXAMPLES

### Example 1
```powershell
PS C:\> $migration =New-AzsDiskMigrationJob -Name "mymigrationJob" -Disks $list -location local -TargetShare "\\SU1FileServer.azurestack.local\SU1_ObjStore"
PS C:\> Stop-AzsDiskMigrationJob -Location local -Name $migration.MigrationId
```

Cancel a managed disk migration job.

## PARAMETERS

### -Location
Location of the resource.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
{{Fill Name Description}}

```yaml
Type: String
Parameter Sets: (All)
Aliases: MigrationId

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.AzureStack.Management.Compute.Admin.Models.DiskMigrationJob

## NOTES

## RELATED LINKS
