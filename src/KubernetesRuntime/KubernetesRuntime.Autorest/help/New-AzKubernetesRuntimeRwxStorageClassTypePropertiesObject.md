---
external help file:
Module Name: Az.KubernetesRuntime
online version: https://learn.microsoft.com/powershell/module/Az.KubernetesRuntime/new-azkubernetesruntimerwxstorageclasstypepropertiesobject
schema: 2.0.0
---

# New-AzKubernetesRuntimeRwxStorageClassTypePropertiesObject

## SYNOPSIS
Create an in-memory object for RwxStorageClassTypeProperties.

## SYNTAX

```
New-AzKubernetesRuntimeRwxStorageClassTypePropertiesObject -BackingStorageClassName <String>
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for RwxStorageClassTypeProperties.

## EXAMPLES

### Example 1: Create a RwxStorageClassTypeProperties object
```powershell
$typeProperties = New-AzKubernetesRuntimeRwxStorageClassTypePropertiesObject `
    -BackingStorageClassName "default"
```

Create a `RwxStorageClassTypeProperties` object and set `default` storage class as its backing storage class.

## PARAMETERS

### -BackingStorageClassName
The backing storageclass used to create new storageclass.

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

### Microsoft.Azure.PowerShell.Cmdlets.KubernetesRuntime.Models.RwxStorageClassTypeProperties

## NOTES

## RELATED LINKS

