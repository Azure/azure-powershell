---
external help file: Az.ServiceBus-help.xml
Module Name: Az.ServiceBus
online version: https://docs.microsoft.com/en-us/powershell/module/az.servicebus/new-azservicebusrule
schema: 2.0.0
---

# New-AzServiceBusRule

## SYNOPSIS
Creates a new rule and updates an existing rule

## SYNTAX

### CreateSubscriptionIdViaHost (Default)
```
New-AzServiceBusRule [-Name] <String> -NamespaceName <String> [-ResourceGroupName] <String>
 -SubscriptionName <String> -TopicName <String> [-Parameter <IRule>] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### CreateExpanded
```
New-AzServiceBusRule [-Name] <String> -NamespaceName <String> [-ResourceGroupName] <String>
 -SubscriptionId <String> -SubscriptionName <String> -TopicName <String> [-ActionCompatibilityLevel <Int32>]
 [-ActionRequiresPreprocessing <Boolean>] [-ActionSqlExpression <String>]
 [-CorrelationFilterContentType <String>] [-CorrelationFilterCorrelationId <String>]
 [-CorrelationFilterLabel <String>] [-CorrelationFilterMessageId <String>]
 [-CorrelationFilterProperty <ICorrelationFilterProperties>] [-CorrelationFilterReplyTo <String>]
 [-CorrelationFilterReplyToSessionId <String>] [-CorrelationFilterRequiresPreprocessing <Boolean>]
 [-CorrelationFilterSessionId <String>] [-CorrelationFilterTo <String>] [-FilterType <FilterType>]
 [-SqlFilterRequiresPreprocessing <Boolean>] [-SqlFilterSqlExpression <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Create
```
New-AzServiceBusRule [-Name] <String> -NamespaceName <String> [-ResourceGroupName] <String>
 -SubscriptionId <String> -SubscriptionName <String> -TopicName <String> [-Parameter <IRule>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateSubscriptionIdViaHostExpanded
```
New-AzServiceBusRule [-Name] <String> -NamespaceName <String> [-ResourceGroupName] <String>
 -SubscriptionName <String> -TopicName <String> [-ActionCompatibilityLevel <Int32>]
 [-ActionRequiresPreprocessing <Boolean>] [-ActionSqlExpression <String>]
 [-CorrelationFilterContentType <String>] [-CorrelationFilterCorrelationId <String>]
 [-CorrelationFilterLabel <String>] [-CorrelationFilterMessageId <String>]
 [-CorrelationFilterProperty <ICorrelationFilterProperties>] [-CorrelationFilterReplyTo <String>]
 [-CorrelationFilterReplyToSessionId <String>] [-CorrelationFilterRequiresPreprocessing <Boolean>]
 [-CorrelationFilterSessionId <String>] [-CorrelationFilterTo <String>] [-FilterType <FilterType>]
 [-SqlFilterRequiresPreprocessing <Boolean>] [-SqlFilterSqlExpression <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates a new rule and updates an existing rule

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -ActionCompatibilityLevel
This property is reserved for future use.
An integer value showing the compatibility level, currently hard-coded to 20.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -ActionRequiresPreprocessing
Value that indicates whether the rule action requires preprocessing.

```yaml
Type: System.Boolean
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -ActionSqlExpression
SQL expression.
e.g.
MyProperty='ABC'

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CorrelationFilterContentType
Content type of the message.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CorrelationFilterCorrelationId
Identifier of the correlation.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CorrelationFilterLabel
Application specific label.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CorrelationFilterMessageId
Identifier of the message.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CorrelationFilterProperty
dictionary object for custom filters

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api20170401.ICorrelationFilterProperties
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CorrelationFilterReplyTo
Address of the queue to reply to.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CorrelationFilterReplyToSessionId
Session identifier to reply to.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CorrelationFilterRequiresPreprocessing
Value that indicates whether the rule action requires preprocessing.

```yaml
Type: System.Boolean
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -CorrelationFilterSessionId
Session identifier.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CorrelationFilterTo
Address to send to.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FilterType
Filter type that is evaluated against a BrokeredMessage.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Support.FilterType
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The rule name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: RuleName

Required: True
Position: 4
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NamespaceName
The namespace name

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

### -Parameter
Description of Rule Resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api20170401.IRule
Parameter Sets: CreateSubscriptionIdViaHost, Create
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the Resource group within the Azure subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SqlFilterRequiresPreprocessing
Value that indicates whether the rule action requires preprocessing.

```yaml
Type: System.Boolean
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -SqlFilterSqlExpression
The SQL expression.
e.g.
MyProperty='ABC'

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription credentials that uniquely identify a Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, Create
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionName
The subscription name.

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

### -TopicName
The topic name.

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api20170401.IRule
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.servicebus/new-azservicebusrule](https://docs.microsoft.com/en-us/powershell/module/az.servicebus/new-azservicebusrule)

