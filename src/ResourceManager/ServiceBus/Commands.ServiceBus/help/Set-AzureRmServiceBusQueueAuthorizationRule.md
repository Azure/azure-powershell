---
external help file: Microsoft.Azure.Commands.ServiceBus.dll-Help.xml
Module Name: AzureRM.ServiceBus
online version: 
schema: 2.0.0
---

# Set-AzureRmServiceBusQueueAuthorizationRule

## SYNOPSIS
Updates the specified authorization rule description for the given Service Bus queue.

## SYNTAX

```
Set-AzureRmServiceBusQueueAuthorizationRule [-ResourceGroup] <String> [-Namespace] <String> [-Queue] <String>
 [-InputObj] <SharedAccessAuthorizationRuleAttributes> [[-Name] <String>] [[-Rights] <String[]>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzureRmServiceBusQueueAuthorizationRule** cmdlet updates the description for the specified authorization rule of the given Service Bus queue.

## EXAMPLES

### Example 1
```
PS C:\> $authRuleObj = Get-AzureRmServiceBusQueueAuthorizationRule -ResourceGroup Default-ServiceBus-WestUS -NamespaceName SB-Example1 -QueueName SB-Queue_exampl1 -AuthorizationRuleName SBAuthoRule1

PS C:\> $authRuleObj.Rights.Add("Manage")

PS C:\> Set-AzureRmServiceBusQueueAuthorizationRule -ResourceGroup Default-ServiceBus-WestUS -NamespaceName SB-Example1 -QueueName SB-Queue_exampl1 -AuthRuleObj $authRuleObj
```

Adds **Manage** to the access rights of the authorization rule `SBAuthoRule1` of the queue `SB-Queue_exampl1`.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObj
ServiceBus Queue AuthorizationRule Object.```yaml
Type: SharedAccessAuthorizationRuleAttributes
Parameter Sets: (All)
Aliases: AuthRuleObj

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
AuthorizationRule Name - Required if 'AuthruleObj' not specified.```yaml
Type: String
Parameter Sets: (All)
Aliases: AuthorizationRuleName

Required: False
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Namespace
Namespace Name.```yaml
Type: String
Parameter Sets: (All)
Aliases: NamespaceName

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Queue
Queue Name.```yaml
Type: String
Parameter Sets: (All)
Aliases: QueueName

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroup
The name of the resource group.

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
The rights; for example 
@("Listen","Send","Manage"). Required if 'AuthruleObj' not specified.

```yaml
Type: String[]
Parameter Sets: (All)
Aliases: 
Accepted values: Listen, Send, Manage

Required: False
Position: 4
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

### -ResourceGroup
 System.String

### -NamespaceName
 System.String

### -QueueName
 System.String

### -AuthRuleObj
 Microsoft.Azure.Commands.ServiceBus.Models.SharedAccessAuthorizationRuleAttributes

## OUTPUTS

### Microsoft.Azure.Commands.ServiceBus.Models.SharedAccessAuthorizationRuleAttributes

## NOTES

## RELATED LINKS

