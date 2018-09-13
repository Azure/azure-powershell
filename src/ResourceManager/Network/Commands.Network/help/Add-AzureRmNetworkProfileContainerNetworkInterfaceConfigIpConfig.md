---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
online version:
schema: 2.0.0
---

# Add-AzureRmNetworkProfileContainerNetworkInterfaceConfigIpConfig

## SYNOPSIS
Adds a container network interface ip config profile to a container nic config.

## SYNTAX

```
Add-AzureRmNetworkProfileContainerNetworkInterfaceConfigIpConfig -NetworkProfile <PSNetworkProfile>
 -ContainerNetworkInterfaceConfiguration <PSContainerNetworkInterfaceConfiguration> -Name <String>
 -Subnet <PSSubnet> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Add-AzureRmNetworkProfileContainerNetworkInterfaceConfigIpConfig** cmdlet adds a container network interface ip config profile to a container network interface configuration.

## EXAMPLES

### Example 1
```powershell
$vnet = Get-AzureRmVirtualNetwork -Name myvnet -ResourceGroupName myrg
$subnet = Get-AzureRmVirtualNetworkSubnetConfig -Name mysubnet -VirtualNetwork $vnet

$containerNetworkInterfaceConfig = New-AzureRmNetworkProfileContainerNetworkInterfaceConfig -Name cniConfig

$containerNetworkInterfaceConfig | Add-AzureRmNetworkProfileContainerNetworkInterfaceConfigIpConfig -Name ipconfigProfile1 -Subnet $subnet;
```

The first two commands get an existing vnet and subnet. The second command creates a new container network interface configuration named cniConfig. The third command adds a new container network interface ip configuration profile to the container nic config created by the second command.

## PARAMETERS

### -ContainerNetworkInterfaceConfiguration
The reference of the container network interface configuration.

```yaml
Type: PSContainerNetworkInterfaceConfiguration
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
Type: IAzureContextContainer
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
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkProfile
The reference of the network profile.

```yaml
Type: PSNetworkProfile
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Subnet
The reference to the subnet which this IP Configuration profile references.

```yaml
Type: PSSubnet
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Network.Models.PSContainerNetworkInterfaceConfiguration

### Microsoft.Azure.Commands.Network.Models.PSSubnet

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSNetworkProfile

## NOTES

## RELATED LINKS
