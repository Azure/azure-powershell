---
external help file: Az.Terraform-help.xml
Module Name: Az.Terraform
online version: https://learn.microsoft.com/powershell/module/Az.Terraform/new-azterraformexportresourceobject
schema: 2.0.0
---

# New-AzTerraformExportResourceObject

## SYNOPSIS
Create an in-memory object for ExportResource.

## SYNTAX

```
New-AzTerraformExportResourceObject -ResourceId <String[]> [-NamePattern <String>] [-ResourceName <String>]
 [-ResourceType <String>] [-FullProperty <Boolean>] [-MaskSensitive <Boolean>] [-TargetProvider <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ExportResource.

## EXAMPLES

### Example 1: Create a query object with single resource id
```powershell
New-AzTerraformExportResourceObject -ResourceId "/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/aztfy-pwsh-test-rg/providers/Microsoft.Network/virtualNetworks/test-vnet"
```

```output
FullProperty   :
MaskSensitive  :
NamePattern    :
ResourceId     : {/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/aztfy-pwsh-test-rg/providers/Microsoft.Network/virtualNetworks
                 /test-vnet}
ResourceName   :
ResourceType   :
TargetProvider :
Type           : ExportResource
```

Create a query object with single resource id

### Example 2: Create a query object with multiple resource Ids
```powershell
New-AzTerraformExportResourceObject -ResourceId "/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/aztfy-pwsh-test-rg/providers/Microsoft.Network/virtualNetworks/test-vnet","/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/aztfy-pwsh-test-rg/providers/Microsoft.Network/virtualNetworks/test-vnet2"
```

```output
FullProperty   :
MaskSensitive  :
NamePattern    :
ResourceId     : {/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/aztfy-pwsh-test-rg/providers/Microsoft.Network/virtualNetworks
                 /test-vnet, /subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/aztfy-pwsh-test-rg/providers/Microsoft.Network/virt
                 ualNetworks/test-vnet2}
ResourceName   :
ResourceType   :
TargetProvider :
Type           : ExportResource
```

Create a query object with multiple resource Ids

## PARAMETERS

### -FullProperty
Whether to output all non-computed properties in the generated Terraform configuration? This probably needs manual modifications to make it valid.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaskSensitive
Mask sensitive attributes in the Terraform configuration.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NamePattern
The name pattern of the Terraform resources.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The id of the resource to be exported.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceName
The Terraform resource name.
Only works when resourceIds contains only one item.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceType
The Terraform resource type.
Only works when resourceIds contains only one item.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetProvider
The target Azure Terraform Provider.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.ExportResource

## NOTES

## RELATED LINKS
