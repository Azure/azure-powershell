---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
ms.assetid: C0E1D4DF-232F-49C6-BE4C-05C8E8038329
online version:
schema: 2.0.0
---

# New-AzureRmSecureGatewayApplicationRule

## SYNOPSIS
Creates a Secure Gateway Application Rule.

## SYNTAX

```
New-AzureRmSecureGatewayApplicationRule -Name <String> -Priority <Integer> [-Description <String>]
 -Protocol <System.Collections.Generic.List`1[System.String]>
 -TargetFqdn <System.Collections.Generic.List`1[System.String]>
 -ActionType <String> [<CommonParameters>]
```

## DESCRIPTION
The **New-AzureRmSecureGatewayApplicationRule** cmdlet creates an application rule for Azure secure gateway.

## EXAMPLES

### 1:  Create a rule to allow all HTTPS traffic
```
New-AzureRmSecureGatewayApplicationRule -Name "AllowHTTPS" -Priority 100 -Protocol "https" -TargetFqdn "*" -ActionType "allow"
```

This example creates a rule which will allow all HTTPS traffic.

### 2:  Allow *.msn.com, but deny *.site.msn.com for HTTP traffic
```
New-AzureRmSecureGatewayApplicationRule -Name "AllowMsnHttp" -Priority 100 -Protocol "http" -TargetFqdn "*.msn.com" -ActionType "allow"
New-AzureRmSecureGatewayApplicationRule -Name "BlockMsnSiteHttp" -Priority 90 -Protocol "http" -TargetFqdn "*.site.msn.com" -ActionType "deny"
```

This example evidentiates the importance of priority for a rule.
If "AllowMsnHttp" rule would have a bigger priority (smaller number), all MSN traffic will match it, including the traffic for *.site.msn.com.
By giving the subdomain rule ("BlockMsnSiteHttp") a bigger priority, we are sure traffic will match it first and thus deny traffic to *.site.msn.com.

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
Specifies the priority of this rule. Priority is a number between 0 and 65000. The smaller the number, the bigger the priority.

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

### -Protocol
Specifies the type of traffic to be filtered by this rule. Possible values are HTTP and HTTPS.

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

### -TargetFqdn
Specifies a list of domain names filtered by this rule.
"*" is accepted only as first character of an entry in this list. When used, "*" matches any number of characters. (e.g. "*msn.com" will match msn.com and all its subdomains)

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

### Microsoft.Azure.Commands.Network.Models.PSSecureGatewayApplicationRule

## NOTES

## RELATED LINKS

[New-AzureRmSecureGatewayApplicationRuleCollection](./New-AzureRmSecureGatewayApplicationRuleCollection.md)

[New-AzureRmSecureGateway](./New-AzureRmSecureGateway.md)

[Get-AzureRmSecureGateway](./Get-AzureRmSecureGateway.md)
