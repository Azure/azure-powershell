---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
ms.assetid: A29E9921-C1B9-42C2-B816-5D4873AC6688
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.network/new-azurermfirewallnetworkrulecollection
schema: 2.0.0
---

# New-AzureRmFirewallNetworkRuleCollection

## SYNOPSIS
Creates a collection of Firewall rules.

## SYNTAX

```
New-AzureRmFirewallNetworkRuleCollection -Name <String> -Priority <Integer>
 -Rule <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSFirewallNetworkRule]>
 -ActionType <String> 
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzureRmFirewallNetworkRuleCollection** cmdlet creates a collection of Firewall Network Rules.

## EXAMPLES

### 1:  Create a collection of two rules
```
$rule1 = New-AzureRmFirewallNetworkRule -Name "Deny abc" -Protocol "tcp" -SourceIp "10.0.0.0" -DestinationIp "60.1.5.0" -SourcePort "40" -DestinationPort "4040"
$rule2 = New-AzureRmFirewallNetworkRule -Name "AllowAll" -Protocol "udp" -SourceIp "10.0.0.0" -DestinationIp "60.1.5.0" -SourcePort "80" -DestinationPort "8080"
New-AzureRmFirewallNetworkRuleCollection -Name "MyCollection" -Priority 1000 -ActionType "Deny"  -Rule $rule1,$rule2
```

This example creates a collection with 2 rules.
The first rule will deny all traffic from 10.0.0.0:40 to 60.1.5.0:4040
The second rule will deny all traffic from 10.0.0.0:80 to 60.1.5.0:8080

## PARAMETERS

### -Name
Specifies the name of this network rule collection. The name must be unique across all network rule collection.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Priority
Specifies the priority of this rule collection. Priority is a number between 100 and 65000. The smaller the number, the higher the priority.

```yaml
Type: Integer
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description
Specifies an optional description of this rule.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Rule
Specifies the list of rules to be grouped under this collection.

```yaml
Type: System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSFirewallNetworkRule]
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ActionType
Specifies the action to be taken for traffic matching conditions of this rule. Accepted actions are "allow" or "deny".

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -Force
Forces the command to run without asking for user confirmation.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Key-value pairs in the form of a hash table. For example:

@{key0="value0";key1=$null;key2="value2"}

```yaml
Type: Hashtable
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

### None
This cmdlet does not accept any input.

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSFirewallNetworkRuleCollection

## NOTES

## RELATED LINKS

[New-AzureRmFirewallNetworkRule](./New-AzureRmFirewallNetworkRule.md)

[New-AzureRmFirewall](./New-AzureRmFirewall.md)

[Get-AzureRmFirewall](./Get-AzureRmFirewall.md)
