---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
ms.assetid: C0E1D4DF-232F-49C6-BE4C-05C8E8038329
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.network/new-azurermfirewallnetworkrule
schema: 2.0.0
---

# New-AzureRmFirewallNetworkRule

## SYNOPSIS
Creates a Firewall Network Rule.

## SYNTAX

```
New-AzureRmFirewallNetworkRule -Name <String> [-Description <String>]
 -Protocol <System.Collections.Generic.List`1[System.String]>
 -SourceIp <System.Collections.Generic.List`1[System.String]>
 -DestinationIp <System.Collections.Generic.List`1[System.String]>
 -SourcePort <System.Collections.Generic.List`1[System.String]>
 -DestinationPort <System.Collections.Generic.List`1[System.String]>
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzureRmFirewallNetworkRule** cmdlet creates an network rule for Azure Firewall.

## EXAMPLES

### 1:  Create a rule to deny all TCP traffic
```
$rule1 = New-AzureRmFirewallNetworkRule -Name "Deny all TCP traffic" -Protocol "tcp" -SourceIp "*" -DestinationIp "*" -SourcePort "*" -DestinationPort "*"
```

This example creates a rule which will allow all HTTPS traffic.

### 2:  The deny all TCP traffic from 10.0.0.0:40 to 60.1.5.0:4040
```
$rule1 = New-AzureRmFirewallNetworkRule -Name "Deny TCP traffic" -Protocol "tcp" -SourceIp "10.0.0.0" -DestinationIp "60.1.5.0" -SourcePort "40" -DestinationPort "4040"
```

## PARAMETERS

### -Name
Specifies the name of this network rule. The name must be unique inside a rule collection.

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

### -Protocol
Specifies the type of traffic to be filtered by this rule. Possible values are TCP, UDP, and Any.

```yaml
Type: System.Collections.Generic.List`1[System.String]
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceIp
Specifies a list of source IPs filtered by this rule.

```yaml
Type: System.Collections.Generic.List`1[System.String]
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: True
```

### -DestinationIp
Specifies a list of destination IPs filtered by this rule.

```yaml
Type: System.Collections.Generic.List`1[System.String]
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: True
```

### -SourcePort
Specifies a list of source ports filtered by this rule.

```yaml
Type: System.Collections.Generic.List`1[System.String]
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: True
```

### -DestinationPorts
Specifies a list of destination ports filtered by this rule.

```yaml
Type: System.Collections.Generic.List`1[System.String]
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: True
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

### Microsoft.Azure.Commands.Network.Models.PSFirewallNetworkRule

## NOTES

## RELATED LINKS

[New-AzureRmFirewallNetworkRuleCollection](./New-AzureRmFirewallNetworkRuleCollection.md)

[New-AzureRmFirewall](./New-AzureRmFirewall.md)

[Get-AzureRmFirewall](./Get-AzureRmFirewall.md)
