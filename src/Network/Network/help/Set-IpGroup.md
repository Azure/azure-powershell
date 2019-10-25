---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
ms.assetid: 40E56EC1-3327-4DFF-8262-E2EEBB5E4447
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/set-ipgroup
schema: 2.0.0
---

# Set-IpGroup

## SYNOPSIS
Saves a modified Firewall.

## SYNTAX

```
Set-IpGroup -IpGroup <PSIpGroup> [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-IpGroup** cmdlet updates an Azure Firewall.

## EXAMPLES

### 1:  Update priority of a Firewall application rule collection
```

$ipGroup = Get-AzIpGroup -ResourceId /subscriptions/aeb5b02a-0f18-45a4-86d6-81808115cacf/resourceGroups/rg2/providers/Microsoft.Network/ipGroups/testIpGroup
$ipGroup.IpAddresses.Add("11.11.0.0/24")


Set-AzIpGroup -IpGroup $ipGroup

```

This example updates the ipAddress in the IpGroup.


## PARAMETERS

### -AsJob
Run cmdlet in the background

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

### -IpGroup
The IpGroup

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSIpGroup
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Network.Models.PSIpGroup

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSIpGroup

## NOTES

## RELATED LINKS

[Get-IpGroup](./Get-IpGroup.md)

[New-IpGroup](./New-IpGroup.md)

[Remove-IpGroup](./Remove-IpGroup.md)
