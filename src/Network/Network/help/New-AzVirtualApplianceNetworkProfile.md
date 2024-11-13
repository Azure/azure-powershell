---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-azvirtualappliancenetworkprofile
schema: 2.0.0
---

# New-AzVirtualApplianceNetworkProfile

## SYNOPSIS
Define a Network Profile for virtual appliance.

## SYNTAX

```
New-AzVirtualApplianceNetworkProfile
 -NetworkInterfaceConfiguration <PSVirtualApplianceNetworkInterfaceConfiguration[]>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The New-AzVirtualApplianceNetworkProfile command defines network profile of virtual appliance, it's a list of interface configurations.

## EXAMPLES

### Example 1
```powershell
$ipConfig1 = New-AzVirtualApplianceIpConfiguration -Name "publicnicipconfig" -Primary $true
$ipConfig2 = New-AzVirtualApplianceIpConfiguration -Name "publicnicipconfig-2" -Primary $false
$nicConfig1 = New-AzVirtualApplianceNetworkInterfaceConfiguration -NicType "PublicNic" -IpConfiguration $ipConfig1, $ipConfig2

$ipConfig3 = New-AzVirtualApplianceIpConfiguration -Name "privatenicipconfig" -Primary $true
$ipConfig4 = New-AzVirtualApplianceIpConfiguration -Name "privatenicipconfig-2" -Primary $false
$nicConfig2 = New-AzVirtualApplianceNetworkInterfaceConfiguration -NicType "PrivateNic" -IpConfiguration $ipConfig3, $ipConfig4

$networkProfile = New-AzVirtualApplianceNetworkProfile -NetworkInterfaceConfiguration $nicConfig1, $nicConfig2
```

Creates a network profile object using two PSVirtualApplianceNetworkInterfaceConfiguration

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

### -NetworkInterfaceConfiguration
The network interface configurations of the network profile.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSVirtualApplianceNetworkInterfaceConfiguration[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
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

### None

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSVirtualApplianceNetworkProfile

## NOTES

## RELATED LINKS
