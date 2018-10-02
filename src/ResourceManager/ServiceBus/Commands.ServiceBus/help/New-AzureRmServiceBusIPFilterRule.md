---
external help file: Microsoft.Azure.Commands.ServiceBus.dll-Help.xml
Module Name: AzureRM.ServiceBus
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.servicebus/new-azurermServiceBusipfilterrule
schema: 2.0.0
---

# New-AzureRmServiceBusIPFilterRule

## SYNOPSIS
Creates as new IpFilter Rule for given namespace

## SYNTAX

```
New-AzureRmServiceBusIPFilterRule [-ResourceGroupName] <String> [-Namespace] <String> [-Name] <String>
 -IpMask <String> -Action <String> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzureRmServiceBusIPFilterRule** cmdlet Creates a new Ip Filter Rule for given namespace.

## EXAMPLES

### Example 1
```powershell
PS C:\> New-AzureRmServiceBusIPFilterRule -ResourceGroup MyResourceGroup -Namespace MyNamespace -Name ipfilterrulename -IpMask "13.78.143.246/32" -Action "Accept"

Id         : /subscriptions/XXXX-XXXX-XXXX-XXXX-XXXXXXXXX/resourceGroups/MyResourceGroup/providers/Microsoft.ServiceBus/MyNamespace/TestingpreviewNS1/ipfilterrules/ipfilterrulename
Name       : ipfilterrulename
IpMask     : 13.78.143.221/32
FilterName : ipfilterrulename
Action     : Accept
```

The New-AzureRmServiceBusIPFilterRule cmdlet Creates a new Ip Filter Rule for given namespace namespacename which accepts traffic from "13.78.143.246/32".

## PARAMETERS

### -Action
Action for the IP provided in IPMask, Possible values include: 'Accept', 'Reject'

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Accept, Reject

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### -IpMask
Single IPv4 address or a block of IP addresses in CIDR notation.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
IP Filter Rule Name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Namespace
Namespace Name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: NamespaceName

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String


## OUTPUTS

### Microsoft.Azure.Commands.ServiceBus.Models.PSIpFilterRuleAttributes


## NOTES

## RELATED LINKS
