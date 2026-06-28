---
external help file:
Module Name: Az.ServiceBus
online version: https://learn.microsoft.com/powershell/module/Az.ServiceBus/new-azservicebuslocationsnameobject
schema: 2.0.0
---

# New-AzServiceBusLocationsNameObject

## SYNOPSIS
Create an in-memory object for NamespaceReplicaLocation.

## SYNTAX

```
New-AzServiceBusLocationsNameObject [-LocationName <String>] [-RoleType <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for NamespaceReplicaLocation.

## EXAMPLES

### Example 1: Construct an in-memory NamespaceReplicaLocation object
```powershell
New-AzServiceBusLocationsNameObject -LocationName mylocation -RoleType Secondary -ClusterArmId clusterid
```

Creates an in-memory object of type `INamespaceReplicaLocation`.
An array of `INamespaceReplicaLocation` can be fed as 
input to `GeoDataReplicationLocation` parameter of New-AzServiceBusNamespace and Set-AzServiceBusNamespace.

## PARAMETERS

### -LocationName
Azure regions where a replica of the namespace is maintained.

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

### -RoleType
GeoDR Role Types.

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

### Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.NamespaceReplicaLocation

## NOTES

## RELATED LINKS

