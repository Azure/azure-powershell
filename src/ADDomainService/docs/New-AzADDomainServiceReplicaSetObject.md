---
external help file:
Module Name: Az.ADDomainServices
online version: https://docs.microsoft.com/en-us/powershell/module/az.ADDomainServices/new-AzADDomainServicesReplicaSetObject
schema: 2.0.0
---

# New-AzADDomainServiceReplicaSetObject

## SYNOPSIS
Create a in-memory object for ReplicaSet

## SYNTAX

```
New-AzADDomainServiceReplicaSetObject [-Location <String>] [-SubnetId <String>] [<CommonParameters>]
```

## DESCRIPTION
Create a in-memory object for ReplicaSet

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

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

ALIASES

## RELATED LINKS

