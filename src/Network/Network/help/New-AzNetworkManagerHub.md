---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/new-aznetworkmanagerhub
schema: 2.0.0
---

# New-AzNetworkManagerHub

## SYNOPSIS
Creates a network manager hub.

## SYNTAX

```
New-AzNetworkManagerHub -ResourceId <String> -ResourceType <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzNetworkManagerHub** cmdlet creates a network manager hub.

## EXAMPLES

### Example 1
```powershell
New-AzNetworkManagerHub -ResourceId "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsoft.Network/networkManagers/TestNMName/networkGroups/TestGroup" -ResourceType "Microsoft.Network/virtualNetworks"
```
```output
ResourceId                                                                                                                                               ResourceType
----------                                                                                                                                               ------------
/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsoft.Network/networkManagers/TestNMName/networkGroups/TestGroup Microsoft.Network/virtualNetworks
```
Creates a network manager virtual network hub.

## PARAMETERS

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

### -ResourceId
Resource Id

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

### -ResourceType
Resource Type

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerHub

## NOTES

## RELATED LINKS
[New-AzNetworkManagerConnectivityConfiguration](./New-AzNetworkManagerConnectivityConfiguration.md)