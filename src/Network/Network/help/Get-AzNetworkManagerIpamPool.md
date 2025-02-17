---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-aznetworkmanageripampool
schema: 2.0.0
---

# Get-AzNetworkManagerIpamPool

## SYNOPSIS
Gets IPAM pool(s).

## SYNTAX

### ByList (Default)
```
Get-AzNetworkManagerIpamPool -NetworkManagerName <String> -ResourceGroupName <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByName
```
Get-AzNetworkManagerIpamPool [-Name <String>] -NetworkManagerName <String> -ResourceGroupName <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByResourceId
```
Get-AzNetworkManagerIpamPool -ResourceId <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
When given a 'Name', the **Get-AzNetworkManagerIpamPool** cmdlet gets that specific IPAM pool. When not given a 'Name', the **Get-AzNetworkManagerIpamPool** cmdlet gets a list of IPAM pools in specified network manager.

## EXAMPLES

### Example 1
```powershell
Get-AzNetworkManagerIpamPool -Name testPool -NetworkManagerName testNM -ResourceGroupName testRG
```

```output
Location           : eastus2euap
Tags               : {}
Properties         : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSIpamPoolProperties
TagsTable          :
PropertiesText     : {
                       "ProvisioningState": "Succeeded",
                       "Description": "",
                       "DisplayName": "",
                       "ParentPoolName": "",
                       "IPAddressType": [
                         "IPv4"
                       ],
                       "AddressPrefixes": [
                         "10.0.0.0/16"
                       ]
                     }
Name               : testPool
ResourceGroupName  : testRG
NetworkManagerName : testNM
Type               : Microsoft.Network/networkManagers/ipamPools
SystemData         : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText     : {
                       "CreatedBy": "test@email.com",
                       "CreatedByType": "User",
                       "CreatedAt": "2024-09-09T14:10:54.2514072Z",
                       "LastModifiedBy": "test@email.com",
                       "LastModifiedByType": "User",
                       "LastModifiedAt": "2024-09-09T14:10:54.2514072Z"
                     }
Id                 : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG/providers/Microsoft.Network/networkManagers/testNM/ipamPools
                     /testPool
```

Gets specific IPAM pool 'testPool'.

### Example 2
```powershell
Get-AzNetworkManagerIpamPool -NetworkManagerName cusNM -ResourceGroupName testRG
```

```output
Get-AzNetworkManagerIpamPool -NetworkManagerName cusNM -ResourceGroupName testRG

Location           : centralus
Tags               : {}
Properties         : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSIpamPoolProperties
TagsTable          :
PropertiesText     : {
                       "ProvisioningState": "Succeeded",
                       "Description": "",
                       "DisplayName": "",
                       "ParentPoolName": "",
                       "IPAddressType": [
                         "IPv4"
                       ],
                       "AddressPrefixes": [
                         "10.0.0.0/16"
                       ]
                     }
Name               : cusPool
ResourceGroupName  : testRG
NetworkManagerName : cusNM
Type               : Microsoft.Network/networkManagers/ipamPools
SystemData         : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText     : {
                       "CreatedBy": "test@email.com",
                       "CreatedByType": "User",
                       "CreatedAt": "2024-09-11T15:14:17.2421406Z",
                       "LastModifiedBy": "test@email.com",
                       "LastModifiedByType": "User",
                       "LastModifiedAt": "2024-09-11T15:14:17.2421406Z"
                     }
Id                 : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG/providers/Microsoft.Network/networkManagers/cusNM/ipamPools/cusPool

Location           : centralus
Tags               : {}
Properties         : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSIpamPoolProperties
TagsTable          :
PropertiesText     : {
                       "ProvisioningState": "Succeeded",
                       "Description": "",
                       "DisplayName": "",
                       "ParentPoolName": "",
                       "IPAddressType": [
                         "IPv4"
                       ],
                       "AddressPrefixes": [
                         "10.0.0.0/10"
                       ]
                     }
Name               : sm_cus_pool1_0911
ResourceGroupName  : testRG
NetworkManagerName : cusNM
Type               : Microsoft.Network/networkManagers/ipamPools
SystemData         : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText     : {
                       "CreatedBy": "test@email.com",
                       "CreatedByType": "User",
                       "CreatedAt": "2024-09-11T15:50:56.5860251Z",
                       "LastModifiedBy": "test@email.com",
                       "LastModifiedByType": "User",
                       "LastModifiedAt": "2024-09-11T15:50:56.5860251Z"
                     }
Id                 : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG/providers/Microsoft.Network/networkManagers/cusNM/ipamPools/sm_cus_pool1_0911
```

Gets all IPAM pools in network manager 'cusNM'.

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
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSIpamPool

## NOTES

## RELATED LINKS

[New-AzNetworkManagerIpamPool](./New-AzNetworkManagerIpamPool.md)

[Remove-AzNetworkManagerIpamPool](./Remove-AzNetworkManagerIpamPool.md)

[Set-AzNetworkManagerIpamPool](./Set-AzNetworkManagerIpamPool.md)
