---
external help file: Azs.Compute.Admin-help.xml
Module Name: Azs.Compute.Admin
online version:
schema: 2.0.0
---

# Get-DiskMigrationJob

## SYNOPSIS

## SYNTAX

### DiskMigrationJobs_List (Default)
```
Get-DiskMigrationJob [-Status <String>] -Location <String> [<CommonParameters>]
```

### ResourceId_DiskMigrationJobs_Get
```
Get-DiskMigrationJob -ResourceId <String> [<CommonParameters>]
```

### DiskMigrationJobs_Get
```
Get-DiskMigrationJob -Location <String> -Name <String> [<CommonParameters>]
```

### InputObject_DiskMigrationJobs_Get
```
Get-DiskMigrationJob -InputObject <DiskMigrationJob> [<CommonParameters>]
```

## DESCRIPTION
Returns a list of disk migration jobs.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -InputObject
The input object of type Microsoft.AzureStack.Management.Compute.Admin.Models.DiskMigrationJob.

```yaml
Type: DiskMigrationJob
Parameter Sets: InputObject_DiskMigrationJobs_Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
Location of the resource.

```yaml
Type: String
Parameter Sets: DiskMigrationJobs_List, DiskMigrationJobs_Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The migration job guid name.

```yaml
Type: String
Parameter Sets: DiskMigrationJobs_Get
Aliases: MigrationId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource id.

```yaml
Type: String
Parameter Sets: ResourceId_DiskMigrationJobs_Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Status
The parameters of disk migration job status.

```yaml
Type: String
Parameter Sets: DiskMigrationJobs_List
Aliases:

Required: False
Position: Named
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
