---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
online version:
schema: 2.0.0
---

# Get-AzureRmNetworkProfileContainerNetworkInterfaceConfigIpConfig

## SYNOPSIS
Gets a container network interface configuration ip configuration.

## SYNTAX

```
Get-AzureRmNetworkProfileContainerNetworkInterfaceConfigIpConfig
 -ContainerNetworkInterfaceConfiguration <PSContainerNetworkInterfaceConfiguration> [-Name <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmNetworkProfileContainerNetworkInterfaceConfigIpConfig** cmdlet retrieves a container network interface configuration ip configuration from a supplied container network interface configuration.

## EXAMPLES

### Example 1
```powershell
$networkProfile = Get-AzureRmNetworkProfile -Name np1 -ResourceGroupName rg1

$containerNicConfig = Get-AzureRmNetworkProfileContainerNetworkInterfaceConfig -NetworkProfile $networkProfile -Name cnicConfig1

$ipConfigProfile = Get-AzureRmNetworkProfileContainerNetworkInterfaceConfigIpConfig -ContainerNetworkInterfaceConfiguration $containerNicConfig -Name ipProf1
```

The first command retrieves an existing network profile named np1 in resource group rg1. The second command retrieves a container network interface configuration named cnicConfig1 from network profile np1. The third command then retrieves the ip configuration profile from the container network interface configuration.

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

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSContainerNetworkInterfaceConfiguration

## NOTES

## RELATED LINKS
