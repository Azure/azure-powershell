---
external help file:
Module Name: Az.ConnectedNetwork
online version: https://learn.microsoft.com/powershell/module/Az.ConnectedNetwork/new-azconnectednetworkinterfaceobject
schema: 2.0.0
---

# New-AzConnectedNetworkInterfaceObject

## SYNOPSIS
Create an in-memory object for NetworkInterface.

## SYNTAX

```
New-AzConnectedNetworkInterfaceObject [-IPConfiguration <INetworkInterfaceIPConfiguration[]>]
 [-MacAddress <String>] [-Name <String>] [-VMSwitchType <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for NetworkInterface.

## EXAMPLES

### Example 1: Create a in-memory object for NetworkInterface
```powershell
New-AzConnectedNetworkInterfaceObject -IPConfiguration $ipconf1 -Name "mrmmanagementnic1" -VMSwitchType "Management"
```

```output
MacAddress Name              VMSwitchType
---------- ----              ------------
           mrmmanagementnic1 Management
```

Create a in-memory object for NetworkInterface

## PARAMETERS

### -IPConfiguration
A list of IP configurations of the network interface.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.INetworkInterfaceIPConfiguration[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MacAddress
The MAC address of the network interface.

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

### -Name
The name of the network interface.

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

### -VMSwitchType
The type of the VM switch.

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

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.NetworkInterface

## NOTES

## RELATED LINKS

