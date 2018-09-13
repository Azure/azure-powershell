---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.network/set-azurermnetworkprofilecontainernetworkinterfaceconfigipconfig
schema: 2.0.0
---

# Set-AzureRmNetworkProfileContainerNetworkInterfaceConfigIpConfig

## SYNOPSIS
Sets the goal state for a container network interface configuration's ip configuration.

## SYNTAX

### SetByResource (Default)
```
Set-AzureRmNetworkProfileContainerNetworkInterfaceConfigIpConfig
 -ContainerNetworkInterfaceConfiguration <PSContainerNetworkInterfaceConfiguration> -Name <String>
 [-Subnet <PSSubnet>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetByResourceId 
```
Set-AzureRmNetworkProfileContainerNetworkInterfaceConfigIpConfig
 -ContainerNetworkInterfaceConfiguration <PSContainerNetworkInterfaceConfiguration> -Name <String>
 [-SubnetId <string>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzureRmNetworkProfileContainerNetworkInterfaceConfigIpConfig** cmdlet sets the goal state for a container network interface configuration's ip configuration.

## EXAMPLES

### Example 1
```powershell
$vnet = Get-AzureRmVirtualNetwork -Name myvnet -ResourceGroupName myrg

$subnet = Get-AzureRmVirtualNetworkSubnetConfig -Name mysubnet -VirtualNetwork $vnet

$containerNicConfig = New-AzureRmNetworkProfileContainerNetworkInterfaceConfig -Name cnic

$containerNicConfig | Set-AzureRmNetworkProfileContainerNetworkInterfaceConfigIpConfig -Name ipconfigprofile -Subnet $subnet
```

The first two commands intialize a vnet and subnet. The third command creates an empty (i.e. no container network 
	interface ip configurations) container network interface configuration. The fourth command sets the goal state of 
	a desired container network interface ip configuration on the container network interface configuration.

## PARAMETERS

### -ContainerNetworkInterfaceConfiguration
The reference of the network profile resource.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSContainerNetworkInterfaceConfiguration
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the container network interface configuration.

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

### -Subnet
{{Fill Subnet Description}}

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSSubnet
Parameter Sets: (All)
Aliases:

Required: False
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Network.Models.PSContainerNetworkInterfaceConfiguration

### Microsoft.Azure.Commands.Network.Models.PSSubnet

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSNetworkProfile

## NOTES

## RELATED LINKS
