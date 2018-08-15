---
external help file: Azs.Compute.Admin-help.xml
Module Name: Azs.Compute.Admin
online version:
schema: 2.0.0
---

# New-DiskMigrationJob

## SYNOPSIS

## SYNTAX

### DiskMigrationJobs_Create (Default)
```
New-DiskMigrationJob
 -Disks <System.Collections.Generic.IList`1[Microsoft.AzureStack.Management.Compute.Admin.Models.Disk]>
 -TargetShare <String> -Location <String> -Name <String> [<CommonParameters>]
```

### ResourceId_DiskMigrationJobs_Create
```
New-DiskMigrationJob -ResourceId <String>
 -Disks <System.Collections.Generic.IList`1[Microsoft.AzureStack.Management.Compute.Admin.Models.Disk]>
 -TargetShare <String> [<CommonParameters>]
```

### InputObject_DiskMigrationJobs_Create
```
New-DiskMigrationJob
 -Disks <System.Collections.Generic.IList`1[Microsoft.AzureStack.Management.Compute.Admin.Models.Disk]>
 -TargetShare <String> -InputObject <DiskMigrationJob> [<CommonParameters>]
```

## DESCRIPTION
Create a disk migration job.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -Disks
The parameters of disk list.

```yaml
Type: System.Collections.Generic.IList`1[Microsoft.AzureStack.Management.Compute.Admin.Models.Disk]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The input object of type Microsoft.AzureStack.Management.Compute.Admin.Models.DiskMigrationJob.

```yaml
Type: DiskMigrationJob
Parameter Sets: InputObject_DiskMigrationJobs_Create
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
Parameter Sets: DiskMigrationJobs_Create
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
Parameter Sets: DiskMigrationJobs_Create
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
Parameter Sets: ResourceId_DiskMigrationJobs_Create
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TargetShare
The target share name.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
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
