---
external help file: Az.ServiceBus-help.xml
Module Name: Az.ServiceBus
online version: https://docs.microsoft.com/en-us/powershell/module/az.servicebus/get-azservicebuskey
schema: 2.0.0
---

# Get-AzServiceBusKey

## SYNOPSIS
Gets the primary and secondary connection strings for the namespace.

## SYNTAX

### Namespace (Default)
```
Get-AzServiceBusKey -AuthorizationRuleName <String> -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DisasterRecoveryConfiguration
```
Get-AzServiceBusKey -DisasterRecoveryConfigurationName <String> -AuthorizationRuleName <String>
 -NamespaceName <String> -ResourceGroupName <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Queue
```
Get-AzServiceBusKey -AuthorizationRuleName <String> -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -QueueName <String> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### Topic
```
Get-AzServiceBusKey -AuthorizationRuleName <String> -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -TopicName <String> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the primary and secondary connection strings for the namespace.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -AuthorizationRuleName
The authorization rule name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: AuthorizationRule, Name

Required: True
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

### -DisasterRecoveryConfigurationName
The Disaster Recovery configuration name

```yaml
Type: System.String
Parameter Sets: DisasterRecoveryConfiguration
Aliases: Alias, AliasName, DisasterRecoveryConfiguration

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NamespaceName
The namespace name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: Namespace

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -QueueName
The queue name.

```yaml
Type: System.String
Parameter Sets: Queue
Aliases: Queue

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the Resource group within the Azure subscription.

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

### -SubscriptionId
Subscription credentials that uniquely identify a Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

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

### -TopicName
The topic name.

```yaml
Type: System.String
Parameter Sets: Topic
Aliases: Topic

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

### Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api20170401.IAccessKeys
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.servicebus/get-azservicebuskey](https://docs.microsoft.com/en-us/powershell/module/az.servicebus/get-azservicebuskey)

