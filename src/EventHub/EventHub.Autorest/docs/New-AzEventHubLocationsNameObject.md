---
external help file:
Module Name: Az.EventHub
online version: https://learn.microsoft.com/powershell/module/Az.EventHub/new-azeventhublocationsnameobject
schema: 2.0.0
---

# New-AzEventHubLocationsNameObject

## SYNOPSIS
Create an in-memory object for NamespaceReplicaLocation.

## SYNTAX

```
New-AzEventHubLocationsNameObject [-ClusterArmId <String>] [-LocationName <String>] [-RoleType <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for NamespaceReplicaLocation.

## EXAMPLES

### Example 1: Construct an in-memory NamespaceReplicaLocation object
```powershell
New-AzEventHubLocationsNameObject -LocationName mylocation -RoleType Secondary -ClusterArmId clusterid
```

Creates an in-memory object of type `INamespaceReplicaLocation`.
An array of `INamespaceReplicaLocation` can be fed as 
input to `GeoDataReplicationLocation` parameter of New-AzEventHubNamespace and Set-AzEventHubNamespace.

## PARAMETERS

### -ClusterArmId
Optional property that denotes the ARM ID of the Cluster.
This is required, if a namespace replica should be placed in a Dedicated Event Hub Cluster.

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

### Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.NamespaceReplicaLocation

## NOTES

## RELATED LINKS

