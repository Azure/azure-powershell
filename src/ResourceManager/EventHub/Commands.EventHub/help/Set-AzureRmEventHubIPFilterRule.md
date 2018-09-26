---
external help file: Microsoft.Azure.Commands.EventHub.dll-Help.xml
Module Name: AzureRM.EventHub
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.servicebus/set-azurermeventhubipfilterrule
schema: 2.0.0
---

# Set-AzureRmEventHubIPFilterRule

## SYNOPSIS
update the specified IpFilter Rule for the given namespace

## SYNTAX

### IpFilterRulePropertiesSet (Default)
```
Set-AzureRmEventHubIPFilterRule [-ResourceGroupName] <String> [-Namespace] <String> [-Name] <String>
 [-Action <String>] [-IpMask <String>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### IpFilterRuleInputObjectSet
```
Set-AzureRmEventHubIPFilterRule -InputObject <PSIpFilterRuleAttributes> [-Action <String>] [-IpMask <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### IpFilterRuleResourceIdParameterSet
```
Set-AzureRmEventHubIPFilterRule [-ResourceId] <String> [-Action <String>] [-IpMask <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
command **Set-AzureRmEventHubIPFilterRule** will update the specified Ip Filter Rule description. 

## EXAMPLES

### Example 1
```powershell
PS C:\> $updatedIpfilterRule = Set-AzureRmEventHubIPFilterRule -ResourceGroup MyResourceGroup -Namespace MYNamespace -Name TestingIpFilterRule -IpMask "13.78.143.219/32" -Action "Reject"

Id         : /subscriptions/XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXX/resourceGroups/MyResourceGroup/providers/Microsoft.EventHub/namespaces/MYNamespace/ipfilterrules/TestingIpFilterRule
Name       : TestingIpFilterRule
IpMask     : 13.78.143.219/32
FilterName : TestingIpFilterRule
Action     : Reject
```

update the Ip Filter rule using parameters

### Example 2
```powershell

PS C:\> $createdIpfilterRule = Get-AzureRmEventHubIPFilterRule -ResourceGroup MyResourceGroup -Namespace MYNamespace -Name TestingIpFilterRule
PS C:\> $createdIpfilterRule.IpMask = "XX.XX.XX.XX/32"
PS C:\> $updatedIpfilterRule = Set-AzureRmEventHubIPFilterRule -InputObject $createdIpfilterRule

Id         : /subscriptions/XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXX/resourceGroups/MyResourceGroup/providers/Microsoft.EventHub/namespaces/MYNamespace/ipfilterrules/TestingIpFilterRule
Name       : TestingIpFilterRule
IpMask     : XX.XX.XX.XX/32
FilterName : TestingIpFilterRule
Action     : Reject
```

update the Ip Filter rule using InputObject

### Example 3
```powershell

PS C:\> $createdIpfilterRule = Get-AzureRmEventHubIPFilterRule -ResourceGroup MyResourceGroup -Namespace MYNamespace -Name TestingIpFilterRule
PS C:\> $updatedIpfilterRule = Set-AzureRmEventHubIPFilterRule -InputObject $createdIpfilterRule -IpMask "XX.XX.XX.XX/32"

Id         : /subscriptions/XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXX/resourceGroups/MyResourceGroup/providers/Microsoft.EventHub/namespaces/MYNamespace/ipfilterrules/TestingIpFilterRule
Name       : TestingIpFilterRule
IpMask     : XX.XX.XX.XX/32
FilterName : TestingIpFilterRule
Action     : Reject
```

update the Ip Filter rule using InputObject and -IpMask

## PARAMETERS

### -Action
IP Filter Action.
Possible values include: 'Accept', 'Reject'

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Accept, Reject

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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

### -InputObject
Ip Filter Rule Object

```yaml
Type: Microsoft.Azure.Commands.EventHub.Models.PSIpFilterRuleAttributes
Parameter Sets: IpFilterRuleInputObjectSet
Aliases: EventHubObj

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IpMask
Single IPv4 address or a block of IP addresses in CIDR notation.

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

### -Name
Ip Filter Rule Name

```yaml
Type: System.String
Parameter Sets: IpFilterRulePropertiesSet
Aliases:

Required: True
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

### Microsoft.Azure.Commands.EventHub.Models.PSIpFilterRuleAttributes
System.String


## OUTPUTS

### Microsoft.Azure.Commands.EventHub.Models.PSIpFilterRuleAttributes


## NOTES

## RELATED LINKS
