---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-azvirtualrouterautoscaleconfiguration
schema: 2.0.0
---

# New-AzVirtualRouterAutoScaleConfiguration

## SYNOPSIS
Create a VirtualRouterAutoScaleConfiguration object for a Virtual Hub.

## SYNTAX

```
New-AzVirtualRouterAutoScaleConfiguration -MinCapacity <Int32> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzVirtualRouterAutoScaleConfiguration** cmdlet creates a virtual hub autoscale configuration object.

## EXAMPLES

### Example 1

```powershell
New-AzResourceGroup -Location "West US" -Name "testRG"
$virtualWan = New-AzVirtualWan -ResourceGroupName "testRG" -Name "myVirtualWAN" -Location "West US"
$autoscale = New-AzVirtualRouterAutoScaleConfiguration -MinCapacity 3
New-AzVirtualHub -VirtualWan $virtualWan -ResourceGroupName "testRG" -Name "westushub" -AddressPrefix "10.0.1.0/24" -VirtualRouterAutoScaleConfiguration $autoscale 
Remove-AzVirtualHub -ResourceGroupName "testRG" -Name "westushub"
```

The above will create a resource group "testRG", a Virtual WAN and a Virtual Hub in West US in that resource group in Azure. The virtual hub will have the address space "10.0.1.0/24" and minimum capacity 3.

It then deletes the virtual hub using its ResourceGroupName and ResourceName.

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

### -MinCapacity
The minimum number of scale units for VirtualHub Router.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: True
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

### Microsoft.Azure.Commands.Network.Models.PSVirtualRouterAutoScaleConfiguration

## NOTES

## RELATED LINKS
