---
external help file:
Module Name: Az.ADDomainServices
online version: https://learn.microsoft.com/powershell/module/Az.ADDomainServices/new-AzADDomainServiceReplicaSetObject
schema: 2.0.0
---

# New-AzADDomainServiceReplicaSetObject

## SYNOPSIS
Create an in-memory object for ReplicaSet.

## SYNTAX

```
New-AzADDomainServiceReplicaSetObject [-Location <String>] [-SubnetId <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ReplicaSet.

## EXAMPLES

### Example 1: Create ReplicaSet for AdDomain
```powershell
New-AzADDomainServiceReplicaSetObject -Location westus -SubnetId /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.Network/virtualNetworks/test-vm/subnets/test-subnets
```

```output
DomainControllerIPAddress ExternalAccessIPAddress HealthLastEvaluated Location ServiceStatus SubnetId
------------------------- ----------------------- ------------------- -------- ------------- --------
                                                                      westus                 /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resource… 
```

Create an in-memory object for ReplicaSet.
This object can be used to create or update a domain service.

## PARAMETERS

### -Location
Virtual network location.

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

### -SubnetId
The name of the virtual network that Domain Services will be deployed on.
The id of the subnet that Domain Services will be deployed on.
/virtualNetwork/vnetName/subnets/subnetName.

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

### Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ReplicaSet

## NOTES

## RELATED LINKS

