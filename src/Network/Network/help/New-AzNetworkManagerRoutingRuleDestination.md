---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-aznetworkmanagerroutingruledestination
schema: 2.0.0
---

# New-AzNetworkManagerRoutingRuleDestination

## SYNOPSIS
Creates a network manager routing rule destination.

## SYNTAX

```
New-AzNetworkManagerRoutingRuleDestination -DestinationAddress <String> -Type <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzNetworkManagerRoutingRuleDestination** cmdlet creates a network manager routing rule destination.

## EXAMPLES

### Example 1
```powershell
New-AzNetworkManagerRoutingRuleDestination -DestinationAddress "ApiManagement" -Type "ServiceTag"
```

```output
DestinationAddress Type
------------------ -----------------
ApiManagement      ServiceTag
```

Creates a network manager service tag routing rule destination.

### Example 2
```powershell
New-AzNetworkManagerRoutingRuleDestination -DestinationAddress "10.0.0.1" -Type "AddressPrefix"
```

```output
DestinationAddress Type
------------------ -----------------
10.0.0.1		   AddressPrefix
```

Creates a network manager routing rule destination object.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DestinationAddress
DestinationAddress

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Type
DestinationAddress Type.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: AddressPrefix, ServiceTag

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerRoutingRuleDestination

## NOTES

## RELATED LINKS
