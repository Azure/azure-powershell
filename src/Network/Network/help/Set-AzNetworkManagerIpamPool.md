---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/set-aznetworkmanageripampool
schema: 2.0.0
---

# Set-AzNetworkManagerIpamPool

## SYNOPSIS
Updates an IPAM pool.
## SYNTAX

```
Set-AzNetworkManagerIpamPool -InputObject <PSIpamPool> [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzNetworkManagerIpamPool** cmdlet updates an IPAM pool.

## EXAMPLES

### Example 1
```powershell
$ResourceGroupName = "testRG"
$NetworkManagerName = "testNM"
$IpamPoolName = "testPool"
$NewAddressPrefixes = @("10.0.0.0/15", "10.0.0.0/16")

$ipamPool = Get-AzNetworkManagerIpamPool -ResourceGroupName $ResourceGroupName -NetworkManagerName $NetworkManagerName -Name $IpamPoolName

$ipamPool.Properties.AddressPrefixes = [System.Collections.Generic.List[string]]$NewAddressPrefixes

Set-AzNetworkManagerIpamPool -InputObject $ipamPool
```

```output
Location           : eastus
Tags               : {}
Properties         : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSIpamPoolProperties
TagsTable          :
PropertiesText     : {
                       "ProvisioningState": "Succeeded",
                       "Description": "Test description.",
                       "DisplayName": "allocationView test",
                       "ParentPoolName": "",
                       "IPAddressType": [
                         "IPv4"
                       ],
                       "AddressPrefixes": [
                         "10.0.0.0/15",
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
                       "CreatedAt": "2024-10-01T15:22:51.5180609Z",
                       "LastModifiedBy": "test@email.com",
                       "LastModifiedByType": "User",
                       "LastModifiedAt": "2024-10-03T14:22:22.7534287Z"
                     }
Id                 : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG/providers/Microsoft.Network/networkManagers/testNM/ipamPools/testPool
```

Update the IPAM pool's addressPrefixes.


### Example 2
```powershell
$ResourceGroupName = "testRG"
$NetworkManagerName = "testNM"
$IpamPoolName = "testPool"
$NewDisplayName = "My Test Pool"

$ipamPool = Get-AzNetworkManagerIpamPool -ResourceGroupName $ResourceGroupName -NetworkManagerName $NetworkManagerName -Name $IpamPoolName

$ipamPool.Properties.DisplayName = $NewDisplayName

Set-AzNetworkManagerIpamPool -InputObject $ipamPool
```

```output
Location           : eastus
Tags               : {}
Properties         : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSIpamPoolProperties
TagsTable          :
PropertiesText     : {
                       "ProvisioningState": "Succeeded",
                       "Description": "Test description.",
                       "DisplayName": "My Test Pool",
                       "ParentPoolName": "",
                       "IPAddressType": [
                         "IPv4"
                       ],
                       "AddressPrefixes": [
                         "10.0.0.0/15",
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
                       "CreatedAt": "2024-10-01T15:22:51.5180609Z",
                       "LastModifiedBy": "test@email.com",
                       "LastModifiedByType": "User",
                       "LastModifiedAt": "2024-10-03T14:48:24.9403689Z"
                     }
Id                 : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG/providers/Microsoft.Network/networkManagers/testNM/ipamPools/testPool
```

Gives the IPAM pool 'testPool' Display Name of 'My Test Pool'
## PARAMETERS

### -AsJob
Run cmdlet in the background

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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

### -InputObject
The Ipam Pool

```yaml
Type: PSIpamPool
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSIpamPool

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSIpamPool

## NOTES

## RELATED LINKS
[New-AzNetworkManagerIpamPool](./New-AzNetworkManagerIpamPool.md)

[Get-AzNetworkManagerIpamPool](./Get-AzNetworkManagerIpamPool.md)

[Remove-AzNetworkManagerIpamPool](./Remove-AzNetworkManagerIpamPool.md)