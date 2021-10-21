---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/get-aznetworkmanagereffectivevirtualnetworkbynetworkgrouplist
schema: 2.0.0
---

# Get-AzNetworkManagerEffectiveVirtualNetworkByNetworkGroupList

## SYNOPSIS
Lists NetworkManager Effective Virtual Networks in a network group.

## SYNTAX

```
Get-AzNetworkManagerEffectiveVirtualNetworkByNetworkGroupList -NetworkGroupName <String>
 -NetworkManagerName <String> -ResourceGroupName <String> [-SkipToken <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzNetworkManagerEffectiveVirtualNetworkByNetworkGroupList** cmdlet lists NetworkManager Effective Virtual Networks in a network group.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-AzNetworkManagerEffectiveVirtualNetworkByNetworkGroupList -NetworkGroupName "TestNG" -NetworkManagerName "TestNM"
 -ResourceGroupName "TestRG" -skipToken "FakeSkipToken"

Value     : [
              {
                "Id": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsoft.Network/virtualNetworks/pstestvent",
                "Location": "centraluseuap",
                "MembershipType": "Dynamic"
              }
            ]
SkipToken :

```


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

### -NetworkGroupName
The networkManager networkgroup name.

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

### -NetworkManagerName
The networkManager name.

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

### -ResourceGroupName
The resource group name.

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

### -SkipToken
SkipToken.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
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

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerEffectiveVirtualNetworksListResult

## NOTES

## RELATED LINKS

[Get-AzNetworkManagerEffectiveVirtualNetworkList](./Get-AzNetworkManagerEffectiveVirtualNetworkList.md)
