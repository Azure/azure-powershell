---
external help file: Microsoft.Azure.Commands.ServiceBus.dll-Help.xml
Module Name: AzureRM.ServiceBus
online version:https://docs.microsoft.com/en-us/powershell/module/azurerm.servicebus/get-azurermServiceBusipfilterrule
schema: 2.0.0
---

# Get-AzureRmServiceBusIPFilterRule

## SYNOPSIS
Returns description for the specified rule or list of Ip Filter rules for specified namespace.

## SYNTAX

### IpFilterRulePropertiesSet (Default)
```
Get-AzureRmServiceBusIPFilterRule [-ResourceGroupName] <String> [-Namespace] <String> [[-Name] <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### IpFilterRuleResourceIdParameterSet
```
Get-AzureRmServiceBusIPFilterRule [-ResourceId] <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmServiceBusIPFilterRule** cmdlet returns the description of the specified Ip Filter Rule or list of Ip Filter Rules.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-AzureRmServiceBusIPFilterRule -ResourceGroup MyResourceGroup -Namespace MyNamespace -Name TestingIpFilterRule

Id         : /subscriptions/XXXX-XXXX-XXXX-XXXX-XXXXXXXXX/resourceGroups/MyResourceGroup/providers/Microsoft.ServiceBus/MyNamespace/TestingpreviewNS1/ipfilterrules/TestingIpFilterRule
Name       : TestingIpFilterRule
IpMask     : 13.78.143.221/32
FilterName : TestingIpFilterRule
Action     : Accept
```

Get-AzureRmServiceBusIPFilterRule cmdlet with the name of the Ip Filter Rule will return the rule description

### Example 2
```powershell
PS C:\> Get-AzureRmServiceBusIPFilterRule -ResourceGroup resourcegroup -Namespace namespaceame

Id         : /subscriptions/XXXX-XXXX-XXXX-XXXX-XXXXXXXXX/resourceGroups/MyResourceGroup/providers/Microsoft.ServiceBus/MyNamespace/TestingpreviewNS1/ipfilterrules/TestingIpFilterRule
Name       : TestingIpFilterRule
IpMask     : 13.78.143.221/32
FilterName : TestingIpFilterRule
Action     : Accept

Id         : /subscriptions/XXXX-XXXX-XXXX-XXXX-XXXXXXXXX/resourceGroups/MyResourceGroup/providers/Microsoft.ServiceBus/MyNamespace/TestingpreviewNS1/ipfilterrules/TestingIpFilterRule1
Name       : TestingIpFilterRule1
IpMask     : 10.12.12.221/32
FilterName : TestingIpFilterRule1
Action     : Accept

```

Get-AzureRmServiceBusIPFilterRule cmdlet without specific Ip Filter Rule name will return the list of rule description

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

### -Name
IP Filter Rule Name

```yaml
Type: System.String
Parameter Sets: IpFilterRulePropertiesSet
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Namespace
Namespace Name

```yaml
Type: System.String
Parameter Sets: IpFilterRulePropertiesSet
Aliases: NamespaceName

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name

```yaml
Type: System.String
Parameter Sets: IpFilterRulePropertiesSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
Ip Filter Rule Resource Id

```yaml
Type: System.String
Parameter Sets: IpFilterRuleResourceIdParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
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
