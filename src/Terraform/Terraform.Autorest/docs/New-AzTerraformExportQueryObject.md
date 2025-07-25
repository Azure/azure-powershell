---
external help file:
Module Name: Az.Terraform
online version: https://learn.microsoft.com/powershell/module/Az.Terraform/new-azterraformexportqueryobject
schema: 2.0.0
---

# New-AzTerraformExportQueryObject

## SYNOPSIS
Create an in-memory object for ExportQuery.

## SYNTAX

```
New-AzTerraformExportQueryObject -Query <String> [-FullProperty <Boolean>] [-MaskSensitive <Boolean>]
 [-NamePattern <String>] [-Recursive <Boolean>] [-TargetProvider <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ExportQuery.

## EXAMPLES

### Example 1: Create a query object with ARG query
```powershell
 New-AzTerraformExportQueryObject -Query "type =~ `"Microsoft.Compute/virtu
alMachines`""
```

```output
FullProperty   :
MaskSensitive  :
NamePattern    :
Query          : type =~ "Microsoft.Compute/virtualMachines"
Recursive      :
TargetProvider :
Type           : ExportQuery
```

Create a query object with ARG query

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

### -Query
The ARG where predicate.
Note that you can combine multiple conditions in one where predicate, e.g.
resourceGroup =~ "my-rg" and type =~ "microsoft.network/virtualnetworks".

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

### -Recursive
Whether to recursively list child resources of the query result.

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

### Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.ExportQuery

## NOTES

## RELATED LINKS

