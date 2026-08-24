---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version: https://learn.microsoft.com/powershell/module/az.compute/new-azvmipconfig
schema: 2.0.0
---

# New-AzVMIpConfig

## SYNOPSIS
Creates an IP configuration for an implicit virtual machine network interface.

## SYNTAX

```
New-AzVMIpConfig [[-Name] <String>] [[-SubnetId] <String>] [-Primary]
 [-PublicIPAddressConfigurationName <String>] [-IpTag <VirtualMachineIpTag[]>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzVMIpConfig** cmdlet creates an IP configuration for an implicit virtual machine (VM) network interface.
When IP tags are supplied, the cmdlet adds them to the nested public IP address configuration.

## EXAMPLES

### Example 1: Create an IP configuration with a first-party service IP tag
```powershell
$ipTag = New-AzVMIpTagConfig -IpTagType 'FirstPartyUsage' -FirstPartyServiceTagId $serviceTagResourceId
$ipConfig = New-AzVMIpConfig -Name 'ipConfig' -SubnetId $subnetId -PublicIPAddressConfigurationName 'publicIpConfig' -IpTag $ipTag
```

This example creates an implicit network interface IP configuration with a nested public IP configuration and first-party service IP tag.

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

### -IpTag
Specifies IP tags to associate with the implicit public IP address.

```yaml
Type: Microsoft.Azure.Management.Compute.Models.VirtualMachineIpTag[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Specifies the IP configuration name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Primary
Indicates that this is the primary IP configuration.

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

### -PublicIPAddressConfigurationName
Specifies the name of the nested implicit public IP address configuration.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: PublicIPAddressName

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SubnetId
Specifies the resource ID of the subnet for the IP configuration.

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

### System.String

### Microsoft.Azure.Management.Compute.Models.VirtualMachineIpTag

## OUTPUTS

### Microsoft.Azure.Management.Compute.Models.VirtualMachineNetworkInterfaceIPConfiguration

## NOTES

## RELATED LINKS

[Add-AzVMNetworkInterfaceConfiguration](./Add-AzVMNetworkInterfaceConfiguration.md)

[New-AzVMIpTagConfig](./New-AzVMIpTagConfig.md)
