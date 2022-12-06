---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/new-aznetworkmanageraddressprefixitem
schema: 2.0.0
---

# New-AzNetworkManagerAddressPrefixItem

## SYNOPSIS
Creates a network manager address prefix item.

## SYNTAX

```
New-AzNetworkManagerAddressPrefixItem -AddressPrefix <String> -AddressPrefixType <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzNetworkManagerAddressPrefixItem** cmdlet creates a network manager address prefix item.

## EXAMPLES

### Example 1
```powershell
New-AzNetworkManagerAddressPrefixItem -AddressPrefix "Internet" -AddressPrefixType "ServiceTag"   
```
```output
AddressPrefix AddressPrefixType
------------- -----------------
Internet      ServiceTag
```
Creates a network manager service tag address prefix item.

### Example 2
```powershell
New-AzNetworkManagerAddressPrefixItem -AddressPrefix "10.0.0.1" -AddressPrefixType "IPPrefix"   
```
```output
AddressPrefix AddressPrefixType
------------- -----------------
10.0.0.1      IPPrefix
```
Creates a network manager IP address prefix item.

## PARAMETERS

### -AddressPrefix
AddressPrefix

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -AddressPrefixType
AddressPrefix Type.

```yaml
Type: String
Parameter Sets: (All)
Aliases:
Accepted values: IPPrefix, ServiceTag

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerAddressPrefixItem

## NOTES

## RELATED LINKS
