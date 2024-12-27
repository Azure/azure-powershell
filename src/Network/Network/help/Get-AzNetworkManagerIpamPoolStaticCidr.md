---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-aznetworkmanageripampoolstaticcidr
schema: 2.0.0
---

# Get-AzNetworkManagerIpamPoolStaticCidr

## SYNOPSIS
Gets Static Cidr(s) in an IPAM pool.

## SYNTAX

### ByList (Default)
```
Get-AzNetworkManagerIpamPoolStaticCidr -NetworkManagerName <String> -ResourceGroupName <String>
 -IpamPoolName <String> [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ByName
```
Get-AzNetworkManagerIpamPoolStaticCidr [-Name <String>] -NetworkManagerName <String>
 -ResourceGroupName <String> -IpamPoolName <String> [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ByResourceId
```
Get-AzNetworkManagerIpamPoolStaticCidr -ResourceId <String> [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
If given a Static Cidr name, the **Get-AzNetworkManagerIpamPoolStaticCidr** cmdlet gets that Static Cidr from the given IPAM pool. If no Static Cidr name is given, the **Get-AzNetworkManagerIpamPoolStaticCidr** cmdlet lists all Static Cidrs from the given IPAM pool.

## EXAMPLES

### Example 1
```powershell
Get-AzNetworkManagerIpamPoolStaticCidr -Name testStaticCidr -NetworkManagerName testNM -ResourceGroupName testRG -IpamPoolName testPool
```

```output
Name               : testStaticCidr
PoolName           : testPool
ResourceGroupName  : testRG
NetworkManagerName : testNM
Properties         : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSStaticCidrProperties
Type               : Microsoft.Network/networkManagers/ipamPools/staticCidrs
SystemData         : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText     : {
                       "CreatedAt": "2024-08-09T15:41:45.4596243Z"
                     }
Id                 : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG/providers/Microsoft.Network/networkManagers/testNM/ipamPools
                     /testPool/staticCidrs/testStaticCidr
```

Gets static Cidr with name 'testStaticCidr'

### Example 2
```powershell
Get-AzNetworkManagerIpamPoolStaticCidr -NetworkManagerName testNM -ResourceGroupName testRG -IpamPoolName testPool
```

```output
Name               : New
PoolName           :
ResourceGroupName  : testRG
NetworkManagerName : testNM
Properties         : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSStaticCidrProperties
Type               : Microsoft.Network/networkManagers/ipamPools/staticCidrs
SystemData         : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText     : {
                       "CreatedAt": "2024-08-09T16:14:26.6711721Z"
                     }
Id                 : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG/providers/Microsoft.Network/networkManagers/testNM/ipamPools
                     /testPool/staticCidrs/New

Name               : New2
PoolName           :
ResourceGroupName  : testRG
NetworkManagerName : testNM
Properties         : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSStaticCidrProperties
Type               : Microsoft.Network/networkManagers/ipamPools/staticCidrs
SystemData         : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText     : {
                       "CreatedAt": "2024-08-09T16:21:25.6566499Z"
                     }
Id                 : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG/providers/Microsoft.Network/networkManagers/testNM/ipamPools
                     /testPool/staticCidrs/New2

Name               : On-Prem
PoolName           :
ResourceGroupName  : testRG
NetworkManagerName : testNM
Properties         : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSStaticCidrProperties
Type               : Microsoft.Network/networkManagers/ipamPools/staticCidrs
SystemData         : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText     : {
                       "CreatedAt": "2024-08-02T01:37:35.4681441Z"
                     }
Id                 : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG/providers/Microsoft.Network/networkManagers/testNM/ipamPools
                     /testPool/staticCidrs/On-Prem
```

Gets all Static Cidrs present in the testPool.

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
The pool resource name.

```yaml
Type: System.String
Parameter Sets: ByList, ByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

### -Name
The resource name.

```yaml
Type: System.String
Parameter Sets: ByName
Aliases: ResourceName

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

### -NetworkManagerName
The network manager name.

```yaml
Type: System.String
Parameter Sets: ByList, ByName
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
Parameter Sets: ByList, ByName
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
Accept wildcard characters: True
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSStaticCidr

## NOTES

## RELATED LINKS

[Remove-AzNetworkManagerIpamPoolStaticCidr](./Remove-AzNetworkManagerIpamPoolStaticCidr.md)

[Set-AzNetworkManagerIpamPoolStaticCidr](./Set-AzNetworkManagerIpamPoolStaticCidr.md)
