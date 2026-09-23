---
external help file: Az.DependencyMap-help.xml
Module Name: Az.DependencyMap
online version: https://learn.microsoft.com/powershell/module/Az.DependencyMap/new-azdependencymapoffazurediscoverysourceresourcepropertiesobject
schema: 2.0.0
---

# New-AzDependencyMapOffAzureDiscoverySourceResourcePropertiesObject

## SYNOPSIS
Create an in-memory object for OffAzureDiscoverySourceResourceProperties.

## SYNTAX

```
New-AzDependencyMapOffAzureDiscoverySourceResourcePropertiesObject [-SourceId <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for OffAzureDiscoverySourceResourceProperties.

## EXAMPLES

### Example 1: Create an instance of the OffAzureDiscoverySourceResourceProperties class.
```powershell
New-AzDependencyMapOffAzureDiscoverySourceResourcePropertiesObject -SourceId testSourceId
```

```output
ProvisioningState SourceId     SourceType
----------------- --------     ----------
                  testSourceId OffAzure
```

This command creates an instance of the OffAzureDiscoverySourceResourceProperties class.

## PARAMETERS

### -SourceId
Source ArmId of Discovery Source resource.

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

### Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.OffAzureDiscoverySourceResourceProperties

## NOTES

## RELATED LINKS
