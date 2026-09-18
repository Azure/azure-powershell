---
external help file: Az.Terraform-help.xml
Module Name: Az.Terraform
online version: https://learn.microsoft.com/powershell/module/Az.Terraform/new-azterraformexportresourcegroupobject
schema: 2.0.0
---

# New-AzTerraformExportResourceGroupObject

## SYNOPSIS
Create an in-memory object for ExportResourceGroup.

## SYNTAX

```
New-AzTerraformExportResourceGroupObject -ResourceGroupName <String> [-NamePattern <String>]
 [-FullProperty <Boolean>] [-MaskSensitive <Boolean>] [-TargetProvider <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ExportResourceGroup.

## EXAMPLES

### Example 1: Create a new parameter object with resource group name
```powershell
New-AzTerraformExportResourceGroupObject -ResourceGroupName aztfy-pwsh-test-rg
```

```output
FullProperty      :
MaskSensitive     :
NamePattern       :
ResourceGroupName : aztfy-pwsh-test-rg
TargetProvider    :
Type              : ExportResourceGroup
```

Create a new parameter object with resource group name

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

### -ResourceGroupName
The name of the resource group to be exported.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.ExportResourceGroup

## NOTES

## RELATED LINKS
