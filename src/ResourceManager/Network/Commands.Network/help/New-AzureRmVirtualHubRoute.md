---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.network/new-azurermvirtualhubroute
schema: 2.0.0
---

# New-AzureRmVirtualHubRoute

## SYNOPSIS
Creates an Azure Virtual Hub Route object.

## SYNTAX

```
New-AzureRmVirtualHubRoute -AddressPrefix <String[]> -NextHopIpAddress <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Creates an Azure Virtual Hub Route object.

## EXAMPLES

### Example 1

```powershell
PS C:\> $route1 = 

AddressPrefixes            NextHopIpAddress
---------------            ----------------
{10.0.0.0/16, 11.0.0.0/16} 12.0.0.5
```

The above will create a virtual hub route object that can be included in the virtual hub route table.

The virtual hub route is an in-memory object that can be used to create a VirtualHubRouteTable object.

## PARAMETERS

### -AddressPrefix
List of Address Prefixes.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NextHopIpAddress
The Next Hop IpAddress.

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSVirtualHubRoute

## NOTES

## RELATED LINKS
