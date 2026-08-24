---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version: https://learn.microsoft.com/powershell/module/az.compute/new-azvmiptagconfig
schema: 2.0.0
---

# New-AzVMIpTagConfig

## SYNOPSIS
Creates an IP tag object for an implicit virtual machine public IP address.

## SYNTAX

```
New-AzVMIpTagConfig [-IpTagType] <String> [-Tag <String>] [-FirstPartyServiceTagId <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzVMIpTagConfig** cmdlet creates an IP tag configuration object for an implicit public IP address on a virtual machine (VM).
Pass the object to the *IpTag* parameter of **New-AzVMIpConfig**.

## EXAMPLES

### Example 1: Create a first-party service IP tag
```powershell
$ipTag = New-AzVMIpTagConfig -IpTagType 'FirstPartyUsage' -Tag 'Sql' -FirstPartyServiceTagId $serviceTagResourceId
$ipConfig = New-AzVMIpConfig -Name 'ipConfig' -PublicIPAddressConfigurationName 'publicIpConfig' -IpTag $ipTag
```

This example creates an IP tag with a first-party service tag resource ID and adds it to an implicit public IP configuration.

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

### -FirstPartyServiceTagId
Specifies the resource ID of the first-party service tag associated with the implicit public IP address.

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

### -IpTagType
Specifies the IP tag type.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Tag
Specifies the IP tag value.

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

## OUTPUTS

### Microsoft.Azure.Management.Compute.Models.VirtualMachineIpTag

## NOTES

## RELATED LINKS

[New-AzVMIpConfig](./New-AzVMIpConfig.md)
