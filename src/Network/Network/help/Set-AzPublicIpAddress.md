---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
ms.assetid: EC798838-1850-4E88-B17F-D2F00F2D4EE9
online version: https://learn.microsoft.com/powershell/module/az.network/set-azpublicipaddress
schema: 2.0.0
---

# Set-AzPublicIpAddress

## SYNOPSIS
Updates a public IP address.

## SYNTAX

```
Set-AzPublicIpAddress -PublicIpAddress <PSPublicIpAddress> [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzPublicIpAddress** cmdlet updates a public IP address.

## EXAMPLES

### Example 1: Change allocation method of a public IP address
```powershell
$publicIp = Get-AzPublicIpAddress -Name $publicIpName -ResourceGroupName $rgName

$publicIp.PublicIpAllocationMethod = "Static"
    
Set-AzPublicIpAddress -PublicIpAddress $publicIp

Get-AzPublicIpAddress -Name $publicIpName -ResourceGroupName $rgName
```

 First command gets the public IP address resource with name $publicIPName in the resource 
    group $rgName.
    Second command sets the allocation method of the public IP address object to "Static".
    Set-AzPublicIPAddress command updates the public IP address resource with the 
    updated object, and modifies the allocation method to 'Static'. A public IP address gets 
    allocated immediately.

### Example 2: Add DNS domain label of a public IP address
```powershell
$publicIp = Get-AzPublicIpAddress -Name $publicIpName -ResourceGroupName $rgName

$publicIp.DnsSettings = @{"DomainNameLabel" = "newdnsprefix"}
    
Set-AzPublicIpAddress -PublicIpAddress $publicIp

$publicIp = Get-AzPublicIpAddress -Name $publicIpName -ResourceGroupName $rgName
```

First command gets the public IP address resource with name $publicIPName in the resource 
    group $rgName.
    Second command sets the DomainNameLabel property to the required dns prefix.
    Set-AzPublicIPAddress command updates the public IP address resource with the 
    updated object. DomainNameLabel & Fqdn are modified as expected.
    

### Example 3: Change DNS domain label of a public IP address
```powershell
$publicIp = Get-AzPublicIpAddress -Name $publicIpName -ResourceGroupName $rgName

$publicIp.DnsSettings.DomainNameLabel = "newdnsprefix"
    
Set-AzPublicIpAddress -PublicIpAddress $publicIp

$publicIp = Get-AzPublicIpAddress -Name $publicIpName -ResourceGroupName $rgName
```

First command gets the public IP address resource with name $publicIPName in the resource 
    group $rgName.
    Second command sets the DomainNameLabel property to the required dns prefix.
    Set-AzPublicIPAddress command updates the public IP address resource with the 
    updated object. DomainNameLabel & Fqdn are modified as expected.

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
The credentials, account, tenant, and subscription used for communication with azure.

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

### -PublicIpAddress
Specifies a public IP address object representing the state to which the public IP address should be set.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSPublicIpAddress
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Network.Models.PSPublicIpAddress

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSPublicIpAddress

## NOTES

## RELATED LINKS

[Get-AzPublicIpAddress](./Get-AzPublicIpAddress.md)

[New-AzPublicIpAddress](./New-AzPublicIpAddress.md)

[Remove-AzPublicIpAddress](./Remove-AzPublicIpAddress.md)


