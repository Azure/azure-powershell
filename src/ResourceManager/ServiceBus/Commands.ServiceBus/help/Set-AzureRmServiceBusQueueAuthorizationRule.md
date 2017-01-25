---
external help file: Microsoft.Azure.Commands.ServiceBus.dll-Help.xml
online version: 
schema: 2.0.0
---

# Set-AzureRmServiceBusQueueAuthorizationRule

## SYNOPSIS
updates given AuthorizationRule description for the provided ServiceBus Queue

## SYNTAX

```
Set-AzureRmServiceBusQueueAuthorizationRule [-ResourceGroup] <String> [-NamespaceName] <String>
 [-QueueName] <String> [-AuthRuleObj] <SharedAccessAuthorizationRuleAttributes>
 [[-AuthorizationRuleName] <String>] [[-Rights] <String[]>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The ** Set-AzureRmServiceBusQueueAuthorizationRule ** cmdlet updates new description for specified AuthorizationRule of the provided ServiceBus Queue.

## EXAMPLES

### Example 1
```
PS C:\> $authRuleObj = Get-AzureRmServiceBusQueueAuthorizationRule -ResourceGroup Default-ServiceBus-WestUS -NamespaceName SB-Example1 -QueueName SB-Queue_exampl1 -AuthorizationRuleName SBAuthoRule1

PS C:\> $authRuleObj.Rights.Add("Manage")

PS C:\> Set-AzureRmServiceBusQueueAuthorizationRule -ResourceGroup Default-ServiceBus-WestUS -NamespaceName SB-Example1 -QueueName SB-Queue_exampl1 -AuthRuleObj $authRuleObj
```

Adding 'Manage' to Accessright of AuthorizationRule 'SBAuthoRule1' of Queue 'SB-Queue_exampl1'

## PARAMETERS

### -AuthRuleObj
ServiceBus Queue AuthorizationRule Object.

```yaml
Type: SharedAccessAuthorizationRuleAttributes
Parameter Sets: (All)
Aliases: 

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -AuthorizationRuleName
AuthorizationRule Name - Required if 'AuthruleObj' not specified.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -NamespaceName
Namespace Name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -QueueName
Queue Name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroup
The name of the resource group

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Rights
Required if 'AuthruleObj' not specified.
Rights - e.g. 
@("Listen","Send","Manage")

```yaml
Type: String[]
Parameter Sets: (All)
Aliases: 

Required: False
Position: 4
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String
-ResourceGroup : System.String
-NamespaceName : System.String
-QueueName : System.String
-AuthRuleObj : Microsoft.Azure.Commands.ServiceBus.Models.SharedAccessAuthorizationRuleAttributes

## OUTPUTS

### Microsoft.Azure.Commands.ServiceBus.Models.SharedAccessAuthorizationRuleAttributes

## NOTES

## RELATED LINKS

