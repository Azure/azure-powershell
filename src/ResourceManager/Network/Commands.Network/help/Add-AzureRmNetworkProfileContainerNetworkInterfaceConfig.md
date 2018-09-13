---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.network/add-azurermnetworkprofilecontainernetworkinterfaceconfig
schema: 2.0.0
---

# Add-AzureRmNetworkProfileContainerNetworkInterfaceConfig

## SYNOPSIS
Adds a container network interface configraution to a network profile.

## SYNTAX

```
Add-AzureRmNetworkProfileContainerNetworkInterfaceConfig -NetworkProfile <PSNetworkProfile> -Name <String>
 [-IpConfiguration <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSIPConfigurationProfile]>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Add-AzureRmNetworkProfileContainerNetworkInterfaceConfig** cmdlet adds a new container network interface configuration to an existing network profile object.

## EXAMPLES

### Example 1
```powershell
$networkProfile = New-AzureRmNetworkProfile -Name np1 

$networkProfile | Add-AzureRmNetworkProfileContainerNetworkInterface -Name containerNicConfig

$networkProfile | Set-AzureRmNetworkProfile 
```

The first command creates a new network profile top level resource called np1. The second command adds a new container network interface configuration to the piped-in network profile. Finally, the third command updates the network profile, saving the changes made to the network profile.

## PARAMETERS

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

### -IpConfiguration
{{Fill IpConfiguration Description}}

```yaml
Type: System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSIPConfigurationProfile]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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
The reference of the network profile resource.

```yaml
Type: PSNetworkProfile
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
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

### Microsoft.Azure.Commands.Network.Models.PSNetworkProfile

### System.Collections.Generic.List`1[[Microsoft.Azure.Commands.Network.Models.PSIPConfigurationProfile, Microsoft.Azure.Commands.Network, Version=6.7.0.0, Culture=neutral, PublicKeyToken=null]]

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSNetworkProfile

## NOTES

## RELATED LINKS
