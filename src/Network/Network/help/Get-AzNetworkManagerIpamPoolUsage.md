---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-aznetworkmanageripampoolusage
schema: 2.0.0
---

# Get-AzNetworkManagerIpamPoolUsage

## SYNOPSIS
Gets pool usage information for a given pool.

## SYNTAX

### ByName (Default)
```
Get-AzNetworkManagerIpamPoolUsage -IpamPoolName <String> -NetworkManagerName <String>
 -ResourceGroupName <String> [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ByResourceId
```
Get-AzNetworkManagerIpamPoolUsage -ResourceId <String> [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzNetworkManagerIpamPoolUsage** cmdlet gets pool usage information for a given pool.

## EXAMPLES

### Example 1
```powershell
Get-AzNetworkManagerIpamPoolUsage -IpamPoolName testPool -NetworkManagerName testNM -ResourceGroupName testRG
```

```output
AddressPrefixes              : {10.0.0.0/14}
AllocatedAddressPrefixes     : {10.0.0.0/20, 10.0.32.0/19, 10.0.64.0/18, 10.0.128.0/29…}
ReservedAddressPrefixes      : {}
AvailableAddressPrefixes     : {10.0.16.0/20, 10.0.128.8/29, 10.0.128.16/28, 10.0.128.32/27…}
TotalNumberOfIPAddresses     : 262144
NumberOfAllocatedIPAddresses : 111112
NumberOfReservedIPAddresses  : 0
NumberOfAvailableIPAddresses : 151032
AddressPrefixesText          : [
                                 "10.0.0.0/14"
                               ]
AllocatedAddressPrefixesText : [
                                 "10.0.0.0/20",
                                 "10.0.32.0/19",
                                 "10.0.64.0/18",
                               ]
ReservedAddressPrefixesText  : []
AvailableAddressPrefixesText : [
                                 "10.0.16.0/20",
                                 "10.0.128.8/29",
                                 "10.0.128.16/28",
                                 "10.0.128.32/27",
                                 "10.0.128.64/26",
                                 "10.0.128.128/25",
                                 "10.0.129.0/24",
                               ]
```

Retrieved pool usage information for the pool 'testPool'.

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

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSPoolUsage

## NOTES

## RELATED LINKS