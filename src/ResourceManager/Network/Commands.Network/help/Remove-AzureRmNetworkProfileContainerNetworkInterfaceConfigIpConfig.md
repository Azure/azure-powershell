---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.network/remove-azurermnetworkprofilecontainernetworkinterfaceconfigipconfig
schema: 2.0.0
---

# Remove-AzureRmNetworkProfileContainerNetworkInterfaceConfigIpConfig

## SYNOPSIS
Removes an ip configuration from a container network interface configruation.

## SYNTAX

```
Remove-AzureRmNetworkProfileContainerNetworkInterfaceConfigIpConfig
 -ContainerNetworkInterfaceConfiguration <PSContainerNetworkInterfaceConfiguration> [-Name <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzureRmNetworkProfileContainerNetworkInterfaceConfigIpConfig** cmdlet removes an ip configuration profile from a container network interface configruation.

## EXAMPLES

### Example 1
```powershell
$networkProfile = Get-AzureRmNetworkProfile -Name np1 -ResourceGroupName rg1

$containerNicConfig = Get-AzureRmNetworkProfileContainerNetworkInterfaceConfig -NetworkProfile $networkProfile -Name cnic1

Remove-AzureRmNetworkProfileContainerNetworkInterfaceConfigIpConfig -ContainerNetworkInterfaceConfiguration $containerNicConfig -Name ipconfigprofile1
```

The first command retrieves an existing network profile. The second retrieves an existing container network interface configuration from the network profile retrieved in the first command. The third command removes an existing container network interface configuration ip configuration from the container nic config retrieved in the second command.

## PARAMETERS

### -ContainerNetworkInterfaceConfiguration
The reference of the Containter network interface configuration resource.

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
The Name of container network interface configuration ip configuration.

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

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSNetworkProfile

## NOTES

## RELATED LINKS
