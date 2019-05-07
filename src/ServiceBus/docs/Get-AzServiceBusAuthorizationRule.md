---
external help file: Az.ServiceBus-help.xml
Module Name: Az.ServiceBus
online version: https://docs.microsoft.com/en-us/powershell/module/az.servicebus/get-azservicebusauthorizationrule
schema: 2.0.0
---

# Get-AzServiceBusAuthorizationRule

## SYNOPSIS
Gets an authorization rule for a namespace by rule name.

## SYNTAX

### Namespace (Default)
```
Get-AzServiceBusAuthorizationRule -NamespaceName <String> -ResourceGroupName <String> [-Name <String>]
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### DisasterRecoveryConfiguration
```
Get-AzServiceBusAuthorizationRule -NamespaceName <String> -ResourceGroupName <String>
 -DisasterRecoveryConfigurationName <String> [-Name <String>] [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Queue
```
Get-AzServiceBusAuthorizationRule -NamespaceName <String> -ResourceGroupName <String> [-Name <String>]
 [-SubscriptionId <String>] -QueueName <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Topic
```
Get-AzServiceBusAuthorizationRule -NamespaceName <String> -ResourceGroupName <String> [-Name <String>]
 [-SubscriptionId <String>] -TopicName <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets an authorization rule for a namespace by rule name.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

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

### -Name
The authorization rule name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: AuthorizationRule, AuthorizationRuleName

Required: False
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api20170401.ISbAuthorizationRule
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.servicebus/get-azservicebusauthorizationrule](https://docs.microsoft.com/en-us/powershell/module/az.servicebus/get-azservicebusauthorizationrule)

