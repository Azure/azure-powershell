---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
ms.assetid: D1D51DEF-05DE-45C4-9013-A02A5B248EAC
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/initialize-azvirtualnetworksubnetpolicy
schema: 2.0.0
---

# Initialize-AzVirtualNetworkSubnetPolicy

## SYNOPSIS
Gives permissions to a delegated service to apply or modify network policies on the subnet.

## SYNTAX

### SetByResourceId (Default)
```
Initialize-AzVirtualNetworkSubnetPolicy -Name <String> -ServiceName <String> -ResourceId <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DefaultParameterSet
```
Initialize-AzVirtualNetworkSubnetPolicy -Name <String> -ServiceName <String> -VirtualNetwork <PSVirtualNetwork>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Initialize-AzVirtualNetworkSubnetPolicy** cmdlet gives permissions to a delegated service to apply or modify network intent policies on the subnet.

## EXAMPLES

### Example 1: Initialize the subnet with network policies for first delegated service
```
$serviceNames = Get-AzAvailableServiceDelegation -Location "westus" | ForEach-Object {Write-Output $_.ServiceName}

$virtualNetwork = Get-AzVirtualNetwork -ResourceGroupName $resourceGroupName -Name $virtualNetworkName

Initialize-AzVirtualNetworkSubnetPolicy -Name $subnetName -VirtualNetwork $virtualNetwork -ServiceName $serviceNames[0]
```

### Example 2: Initialize the subnet with network policies for first delegated service using resourceId
```
$serviceNames = Get-AzAvailableServiceDelegation -Location "westus" | ForEach-Object {Write-Output $_.ServiceName}

Initialize-AzVirtualNetworkSubnetPolicy -Name $subnetName -ResourceId $resourceId -ServiceName $serviceNames[0]
```

### Example 3: Initialize the subnet with network policies for first delegated using piping
```
Get-AzVirtualNetwork -ResourceGroupName $rgName -Name $vNetName | Initialize-AzVirtualNetworkSubnetPolicy -Name $subnetName -ServiceName Microsoft.Databricks/workspaces
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

### -Name
Specifies the name of a subnet that this cmdlet initializes.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
Specifies the resourceId string for virtual network which contains subnet to be initialized.

```yaml
Type: System.String
Parameter Sets: SetByResourceId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ServiceName
Specifies the name of the service that this cmdlet configures delegation to.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualNetwork
Specifies a virtual network object which has the subnet to be initialized.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSVirtualNetwork
Parameter Sets: DefaultParameterSet
Aliases: InputObject

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
Default value: False
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
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Network.Models.PSVirtualNetwork

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSSubnet

## NOTES

## RELATED LINKS

[Add-AzVirtualNetworkSubnetConfig](./Add-AzVirtualNetworkSubnetConfig.md)

[Get-AzVirtualNetworkSubnetConfig](./Get-AzVirtualNetworkSubnetConfig.md)

[New-AzVirtualNetworkSubnetConfig](./New-AzVirtualNetworkSubnetConfig.md)

[Remove-AzVirtualNetworkSubnetConfig](./Remove-AzVirtualNetworkSubnetConfig.md)
