---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-aznetworkmanagerassociatedresourceslist
schema: 2.0.0
---

# Get-AzNetworkManagerAssociatedResourcesList

## SYNOPSIS
Gets list of associated resources in network manager IPAM pool.

## SYNTAX

### ByName (Default)
```
Get-AzNetworkManagerAssociatedResourcesList -IpamPoolName <String> -NetworkManagerName <String>
 -ResourceGroupName <String> [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ByResourceId
```
Get-AzNetworkManagerAssociatedResourcesList -ResourceId <String> [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzNetworkManagerAssociatedResourcesList** cmdlet gets the list of associated resources in network manager IPAM pool.

## EXAMPLES

### Example 1
```powershell
Get-AzNetworkManagerAssociatedResourcesList -IpamPoolName "TestPool" -NetworkManagerName "TestNetworkManager" -ResourceGroupName "TestResourceGroupName"
```

```output
ResourceId                  : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG/providers/Microsoft.Network/virtualNetworks/testvNet
PoolId                      : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG/providers/Microsoft.Network/networkManagers/testNM/
                              ipamPools/testPool
Description                 :
AddressPrefixes             : {10.0.16.0/20}
ReservedAddressPrefixes     :
TotalNumberOfIPAddresses    : 4096
NumberOfReservedIPAddresses : 0
CreatedAt                   : 10/2/2024 6:29:55 PM
ReservationExpiresAt        :
AddressPrefixesText         : [
                                "10.0.16.0/20"
                              ]
ReservedAddressPrefixesText : null

ResourceId                  : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ipam-test-rg/providers/Microsoft.Network/virtualNetworks/paige-vn
                              et
PoolId                      : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG/providers/Microsoft.Network/networkManagers/testNM/
                              ipamPools/testPool
Description                 :
AddressPrefixes             : {10.0.8.0/23}
ReservedAddressPrefixes     :
TotalNumberOfIPAddresses    : 512
NumberOfReservedIPAddresses : 0
CreatedAt                   : 10/2/2024 2:37:10 PM
ReservationExpiresAt        :
AddressPrefixesText         : [
                                "10.0.8.0/23"
                              ]
ReservedAddressPrefixesText : null

ResourceId                  : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG/providers/Microsoft.Network/networkManagers/testNM/
                              ipamPools/testPool/staticCidrs/appleCidr1
PoolId                      : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG/providers/Microsoft.Network/networkManagers/testNM/
                              ipamPools/testPool
Description                 :
AddressPrefixes             : {10.0.0.0/24}
ReservedAddressPrefixes     :
TotalNumberOfIPAddresses    : 256
NumberOfReservedIPAddresses : 0
CreatedAt                   : 9/9/2024 2:17:36 PM
ReservationExpiresAt        :
AddressPrefixesText         : [
                                "10.0.0.0/24"
                              ]
ReservedAddressPrefixesText : null
```

Gets the resources in a pool.

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

### -IpamPoolName
The ipamPool name.

```yaml
Type: System.String
Parameter Sets: ByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

### -NetworkManagerName
The networkManager name.

```yaml
Type: System.String
Parameter Sets: ByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: ByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

### -ResourceId
The Ipam Pool resource id.

```yaml
Type: System.String
Parameter Sets: ByResourceId
Aliases: IpamPoolId

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

### System.Collections.Generic.List`1[[Microsoft.Azure.Commands.Network.Models.NetworkManager.PSPoolAssociation, Microsoft.Azure.PowerShell.Cmdlets.Network, Version=7.9.0.0, Culture=neutral, PublicKeyToken=null]]

## NOTES

## RELATED LINKS