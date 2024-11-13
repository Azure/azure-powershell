---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-aznetworkmanageripampoolstaticcidr
schema: 2.0.0
---

# New-AzNetworkManagerIpamPoolStaticCidr

## SYNOPSIS
Creates a new Static Cidr.

## SYNTAX

```
New-AzNetworkManagerIpamPoolStaticCidr -Name <String> -NetworkManagerName <String> -ResourceGroupName <String>
 -IpamPoolName <String> [-NumberOfIPAddressesToAllocate <String>]
 [-AddressPrefix <System.Collections.Generic.List`1[System.String]>] [-Description <String>] [-Force] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzNetworkManagerIpamPoolStaticCidr** cmdlet creates a new Static Cidr to the given IPAM pool.

## EXAMPLES

### Example 1
```powershell
New-AzNetworkManagerIpamPoolStaticCidr -Name testStaticCidr -NetworkManagerName testNM -ResourceGroupName testRG -PoolName testCmdletPool -AddressPrefix @("10.0.0.0/28")
```

```output
Name               : testStaticCidr
PoolName           : testCmdletPool
ResourceGroupName  : testRG
NetworkManagerName : testNM
Properties         : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSStaticCidrProperties
Type               : Microsoft.Network/networkManagers/ipamPools/staticCidrs
SystemData         : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText     : {
                       "CreatedAt": "2024-10-02T22:34:01.3598795Z"
                     }
Id                 : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG/providers/Microsoft.Network/networkManagers/testNM/ipamPools/testCmdletPool/staticCidrs/testStaticCidr
```

Created the Static Cidr 'testStaticCidr' and allocated it to the IPAM pool 'testCmdletPool'.

## PARAMETERS

### -AddressPrefix
List of IP address prefixes of the resource.

```yaml
Type: System.Collections.Generic.List`1[System.String]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -AsJob
Run cmdlet in the background

```yaml
Type: System.Management.Automation.SwitchParameter
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
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description
Description.

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

### -Force
Do not ask for confirmation if you want to overwrite a resource

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IpamPoolName
IP Address Manager Pool resource name.

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

### -Name
Static Cidr allocation name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -NetworkManagerName
The network manager name.

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

### -NumberOfIPAddressesToAllocate
Number of IP addresses to allocate for a static CIDR resource.
The IP addresses will be assigned based on IpamPools available space.

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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
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
Type: System.Management.Automation.SwitchParameter
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

### System.String

### System.Collections.Generic.List`1[[System.String, System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSStaticCidr

## NOTES

## RELATED LINKS

[Remove-AzNetworkManagerIpamPoolStaticCidr](./Remove-AzNetworkManagerIpamPoolStaticCidr.md)

[Get-AzNetworkManagerIpamPoolStaticCidr](./Get-AzNetworkManagerIpamPoolStaticCidr.md)