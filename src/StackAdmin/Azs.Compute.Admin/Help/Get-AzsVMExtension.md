---
external help file: Azs.Compute.Admin-help.xml
Module Name: Azs.Compute.Admin
online version: 
schema: 2.0.0
---

# Get-AzsVMExtension

## SYNOPSIS
Returns virtual machine image extensions currently available.

## SYNTAX

### List (Default)
```
Get-AzsVMExtension [-Location <String>] [<CommonParameters>]
```

### Get
```
Get-AzsVMExtension -Publisher <String> -Type <String> -Version <String> [-Location <String>]
 [<CommonParameters>]
```

### ResourceId
```
Get-AzsVMExtension -ResourceId <String> [<CommonParameters>]
```

## DESCRIPTION
Returns virtual machine image extensions.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
Get-AzsVMExtension -Location "local"
```

VmOsType                  : Windows
ComputeRole               : N/A
VmScaleSetEnabled         : False
SupportMultipleExtensions : False
IsSystemExtension         : False
SourceBlob                :
ProvisioningState         : Succeeded
Id                        : /subscriptions/0ff0bbbe-d68d-4314-8f68-80a808b5a6ec/providers/Microsoft.Compute.Admin/locations/local/artifactTypes/VMExtension/publishers/Microsoft.Compute/types/BGInfo/versions/2.1
Name                      :
Type                      : Microsoft.Compute.Admin/locations/artifactTypes/VMExtension/publishers/types/versions/
Location                  : local
...

Get all VM extensions at a location.

### -------------------------- EXAMPLE 2 --------------------------
```
Get-AzsVMExtension --Publisher "Microsoft" -Type "MicroExtension" -Version "0.1.0"
```

VmOsType                  : Linux
ComputeRole               : N/A
VmScaleSetEnabled         : False
SupportMultipleExtensions : True
IsSystemExtension         : False
SourceBlob                : Microsoft.AzureStack.Management.Compute.Admin.Models.AzureBlob
ProvisioningState         : Creating
Id                        : /subscriptions/0ff0bbbe-d68d-4314-8f68-80a808b5a6ec/providers/Microsoft.Compute.Admin/locations/local/artifactTypes/VMExtension/publishers/Microsoft/types/MicroExtension/versions/0.1.0
Name                      :
Type                      : Microsoft.Compute.Admin/locations/artifactTypes/VMExtension/publishers/types/versions/
Location                  : local

Get specific VM extension.

## PARAMETERS

### -Location
Location of the resource.

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

### -Publisher
Name of the publisher.

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

### -Type
Type of extension.

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

### -Version
The version of the virtual machine image extension.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.AzureStack.Management.Compute.Admin.Models.VMExtension

## NOTES

## RELATED LINKS

