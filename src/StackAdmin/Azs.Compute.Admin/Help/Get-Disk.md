---
external help file: Azs.Compute.Admin-help.xml
Module Name: Azs.Compute.Admin
online version:
schema: 2.0.0
---

# Get-Disk

## SYNOPSIS

## SYNTAX

### Disks_List (Default)
```
Get-Disk -Location <String> [-Start <Int32>] [-SharePath <String>] [-Count <Int32>]
 [-UserSubscriptionId <String>] [-Status <String>] [<CommonParameters>]
```

### ResourceId_Disks_Get
```
Get-Disk -ResourceId <String> [<CommonParameters>]
```

### InputObject_Disks_Get
```
Get-Disk -InputObject <Disk> [<CommonParameters>]
```

### Disks_Get
```
Get-Disk -Location <String> -Name <String> [<CommonParameters>]
```

## DESCRIPTION
Returns a list of disks.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -Count
The maximum number of disks to return.

```yaml
Type: Int32
Parameter Sets: Disks_List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The input object of type Microsoft.AzureStack.Management.Compute.Admin.Models.Disk.

```yaml
Type: Disk
Parameter Sets: InputObject_Disks_Get
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
Parameter Sets: Disks_List, Disks_Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The disk guid as identity.

```yaml
Type: String
Parameter Sets: Disks_Get
Aliases: DiskId

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
Parameter Sets: ResourceId_Disks_Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SharePath
The source share which the resource belongs to.

```yaml
Type: String
Parameter Sets: Disks_List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Start
The start index of disks in query.

```yaml
Type: Int32
Parameter Sets: Disks_List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Status
The parameters of disk state.

```yaml
Type: String
Parameter Sets: Disks_List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserSubscriptionId
Tenant Subscription Id which the resource belongs to.

```yaml
Type: String
Parameter Sets: Disks_List
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

### Microsoft.AzureStack.Management.Compute.Admin.Models.Disk

## NOTES

## RELATED LINKS
