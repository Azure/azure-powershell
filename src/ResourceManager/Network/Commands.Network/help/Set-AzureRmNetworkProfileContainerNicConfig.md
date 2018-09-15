---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.network/set-AzureRmNetworkProfileContainerNicconfig
schema: 2.0.0
---

# Set-AzureRmNetworkProfileContainerNicConfig

## SYNOPSIS
Sets the goal state for a container network interface configuration.

## SYNTAX

```
Set-AzureRmNetworkProfileContainerNicConfig -NetworkProfile <PSNetworkProfile> -Name <String>
 [-IpConfiguration <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSIPConfigurationProfile]>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzureRmNetworkProfileContainerNicConfig** cmdlet sets the goal state for a network profile's container network interface configuration.

## EXAMPLES

### Example 1
```powershell
$containerNicConfig = New-AzureRmNetworkProfileContainerNicConfig -Name cnic1

$networkProfile = New-AzureRmNetworkProfile -ResourceGroupName rg -Name np1 -Location $location;

$networkProfile | Set-AzureRmNetworkProfileContainerNicConfig -ContainerNetworkInterfaceConfiguration $containerNicConfig

$networkProfile | Set-NetworkProfile
```

The first command creates an empty container network interface configuration. The second command creates a network profile and adds the previously created container network interface configuration to this network profile. The third command creates the container network interface configuration on the network profile. The fourth command updates the network profile. 

## PARAMETERS

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
Type: System.String
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
Type: Microsoft.Azure.Commands.Network.Models.PSNetworkProfile
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

### Microsoft.Azure.Commands.Network.Models.PSNetworkProfile

### System.Collections.Generic.List`1[[Microsoft.Azure.Commands.Network.Models.PSIPConfigurationProfile, Microsoft.Azure.Commands.Network, Version=6.7.0.0, Culture=neutral, PublicKeyToken=null]]

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSNetworkProfile

## NOTES

## RELATED LINKS
