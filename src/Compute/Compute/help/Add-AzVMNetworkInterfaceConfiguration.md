---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version: https://learn.microsoft.com/powershell/module/az.compute/add-azvmnetworkinterfaceconfiguration
schema: 2.0.0
---

# Add-AzVMNetworkInterfaceConfiguration

## SYNOPSIS
Adds an implicit network interface configuration to a virtual machine.

## SYNTAX

```
Add-AzVMNetworkInterfaceConfiguration [-VirtualMachine] <PSVirtualMachine> [[-Name] <String>]
 [[-Primary] <Boolean>] [[-IpConfiguration] <VirtualMachineNetworkInterfaceIPConfiguration[]>]
 [-NetworkApiVersion <String>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Add-AzVMNetworkInterfaceConfiguration** cmdlet adds an implicit network interface configuration to a configurable virtual machine (VM) object.
It initializes the network profile when needed and preserves existing network interface configurations.

## EXAMPLES

### Example 1: Add an implicit network interface with a first-party service IP tag
```powershell
$serviceTagResourceId = '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myResourceGroup/providers/Microsoft.Network/firstPartyServiceTags/myServiceTag'
$subnetId = '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myResourceGroup/providers/Microsoft.Network/virtualNetworks/myVNet/subnets/mySubnet'
$ipTag = New-AzVMIpTagConfig -IpTagType 'FirstPartyUsage' -FirstPartyServiceTagId $serviceTagResourceId
$ipConfig = New-AzVMIpConfig -Name 'ipConfig' -SubnetId $subnetId -PublicIPAddressConfigurationName 'publicIpConfig' -IpTag $ipTag
$vmConfig = New-AzVMConfig -VMName 'myVM' -VMSize 'Standard_D2s_v5'
$vmConfig | Add-AzVMNetworkInterfaceConfiguration -Name 'nicConfig' -Primary $true -IpConfiguration $ipConfig -NetworkApiVersion '2022-11-01'
```

This example adds an implicit network interface and nested public IP configuration to a VM configuration object.

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

### -IpConfiguration
Specifies the IP configurations to add to the network interface configuration.

```yaml
Type: Microsoft.Azure.Management.Compute.Models.VirtualMachineNetworkInterfaceIPConfiguration[]
Parameter Sets: (All)
Aliases:

Required: False
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Specifies the network interface configuration name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -NetworkApiVersion
Specifies the Microsoft.Network API version used to create the implicit networking resources.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Primary
Specifies whether this is the primary network interface configuration.

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VirtualMachine
Specifies the configurable VM object to update.
Create the object with **New-AzVMConfig**.

```yaml
Type: Microsoft.Azure.Commands.Compute.Models.PSVirtualMachine
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue, ByPropertyName)
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
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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

### Microsoft.Azure.Commands.Compute.Models.PSVirtualMachine

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Models.PSVirtualMachine

## NOTES

## RELATED LINKS

[New-AzVMIpConfig](./New-AzVMIpConfig.md)

[New-AzVMConfig](./New-AzVMConfig.md)
