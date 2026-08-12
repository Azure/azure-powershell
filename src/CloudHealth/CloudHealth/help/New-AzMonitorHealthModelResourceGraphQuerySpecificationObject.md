---
external help file: Az.CloudHealth-help.xml
Module Name: Az.CloudHealth
online version: https://learn.microsoft.com/powershell/module/Az.CloudHealth/new-azmonitorhealthmodelresourcegraphqueryspecificationobject
schema: 2.0.0
---

# New-AzMonitorHealthModelResourceGraphQuerySpecificationObject

## SYNOPSIS
Create an in-memory object for ResourceGraphQuerySpecification.

## SYNTAX

```
New-AzMonitorHealthModelResourceGraphQuerySpecificationObject -ResourceGraphQuery <String>
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ResourceGraphQuerySpecification.

## EXAMPLES

### Example 1: Build a Resource Graph discovery specification
```powershell
New-AzMonitorHealthModelResourceGraphQuerySpecificationObject -ResourceGraphQuery "resources | where type =~ 'microsoft.compute/virtualmachines' | project id"
```

Creates the specification for a discovery rule that finds resources with an Azure Resource Graph query.
The query must project the resource id.

## PARAMETERS

### -ResourceGraphQuery
Azure Resource Graph query text in KQL syntax.
The query must return at least a column named 'id' which contains the resource ID of the discovered resources.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ResourceGraphQuerySpecification

## NOTES

## RELATED LINKS

