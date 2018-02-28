---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
ms.assetid: A29E9921-C1B9-42C2-B816-5D4873AC6688
online version:
schema: 2.0.0
---

# New-AzureRmSecureGatewayApplicationRuleCollection

## SYNOPSIS
Creates a collection of secure gateway rules.

## SYNTAX

```
New-AzureRmSecureGatewayApplicationRuleCollection -Name <String> -Priority <Integer> [-Description <String>]
 -Rule <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSSecureGatewayApplicationRule]>
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzureRmSecureGatewayApplicationRuleCollection** cmdlet creates a collection of Secure Gateway Application Rules.

## EXAMPLES

### 1:  Create a collection of two rules
```
$rule1 = New-AzureRmSecureGatewayApplicationRule -Name "Deny abc" -Priority 100 -Protocol "https" -TargetFqdn "*.abc" -ActionType "deny"
$rule2 = New-AzureRmSecureGatewayApplicationRule -Name "AllowAll" -Priority 1000 -Protocol "https" -TargetFqdn "*" -ActionType "allow"
New-AzureRmSecureGatewayApplicationRuleCollection -Name "MyCollection" -Priority 1000 -Rule $rule1,$rule2
```

This example creates a collection with 2 rules.
The first rule (which has a bigger priority - smaller number) will deny all traffic to *.abc domains.
The second rule (which only applies if traffic was not filtered by the first rule) will allow all HTTPS traffic.

## PARAMETERS

### -Name
Specifies the name of this application rule. The name must be unique inside a rule collection.

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
Specifies the priority of this rule. Priority is a number between 100 and 65000. The smaller the number, the bigger the priority.

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
Type: System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSSecureGatewayApplicationRule]
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

### Microsoft.Azure.Commands.Network.Models.PSSecureGatewayApplicationRuleCollection

## NOTES

## RELATED LINKS

[New-AzureRmSecureGatewayApplicationRule](./New-AzureRmSecureGatewayApplicationRule.md)

[New-AzureRmSecureGateway](./New-AzureRmSecureGateway.md)

[Get-AzureRmSecureGateway](./Get-AzureRmSecureGateway.md)
