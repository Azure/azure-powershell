---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/set-aznetworkmanageripampoolstaticcidr
schema: 2.0.0
---

# Set-AzNetworkManagerIpamPoolStaticCidr

## SYNOPSIS
Updates a static CIDR allocation in an IPAM pool.

## SYNTAX

```
Set-AzNetworkManagerIpamPoolStaticCidr -InputObject <PSStaticCidr> [-AsJob] 
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzNetworkManagerIpamPoolStaticCidr** cmdlet updates a static CIDR allocation in an IPAM pool.

## EXAMPLES

### Example 1: Update static CIDR description
```powershell
$ResourceGroupName = "testRG"
$NetworkManagerName = "testNM"
$IpamPoolName = "testPool"
$StaticCidrName = "testStaticCidr"

$staticCidr = Get-AzNetworkManagerIpamPoolStaticCidr -ResourceGroupName $ResourceGroupName -NetworkManagerName $NetworkManagerName -PoolName $IpamPoolName -Name $StaticCidrName

$staticCidr.Properties.Description = "Updated description"

Set-AzNetworkManagerIpamPoolStaticCidr -InputObject $staticCidr
```

Updates the description of an existing static CIDR allocation.

### Example 2: Update static CIDR address prefixes
```powershell
$ResourceGroupName = "testRG"
$NetworkManagerName = "testNM"
$IpamPoolName = "testPool"
$StaticCidrName = "testStaticCidr"

$staticCidr = Get-AzNetworkManagerIpamPoolStaticCidr -ResourceGroupName $ResourceGroupName -NetworkManagerName $NetworkManagerName -PoolName $IpamPoolName -Name $StaticCidrName

$staticCidr.Properties.AddressPrefixes = @("10.0.0.0/24", "10.0.1.0/24")

Set-AzNetworkManagerIpamPoolStaticCidr -InputObject $staticCidr
```

Updates the address prefixes of an existing static CIDR allocation.

## PARAMETERS

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

### -InputObject
The Static CIDR object.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.NetworkManager.PSStaticCidr
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSStaticCidr

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSStaticCidr

## NOTES

## RELATED LINKS

[Get-AzNetworkManagerIpamPoolStaticCidr](./Get-AzNetworkManagerIpamPoolStaticCidr.md)

[New-AzNetworkManagerIpamPoolStaticCidr](./New-AzNetworkManagerIpamPoolStaticCidr.md)

[Remove-AzNetworkManagerIpamPoolStaticCidr](./Remove-AzNetworkManagerIpamPoolStaticCidr.md)