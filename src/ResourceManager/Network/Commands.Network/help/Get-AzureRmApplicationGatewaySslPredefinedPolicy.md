---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
online version: 
schema: 2.0.0
---

# Get-AzureRmApplicationGatewaySslPredefinedPolicy

## SYNOPSIS
Gets Predefined SSL Policies provided by Application Gateway.

## SYNTAX

```
Get-AzureRmApplicationGatewaySslPredefinedPolicy [-Name <String>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmApplicationGatewaySslPredefinedPolicy** cmdlet gets Predefined SSL Policies provided by Application Gateway.

## EXAMPLES

### Example 1
```
PS C:\>$policies = Get-AzureRmApplicationGatewaySslPredefinedPolicy
```

This commands returns all the predefined SSL policies.

### Example 2
```
PS C:\>$policy = Get-AzureRmApplicationGatewaySslPredefinedPolicy -Name AppGwSslPolicy20170401
```

This commands returns predefined policy with name AppGwSslPolicy20170401.

## PARAMETERS

### -Name
Name of the ssl predefined policy

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSApplicationGatewaySslPredefinedPolicy
System.Collections.Generic.IEnumerable`1[[Microsoft.Azure.Commands.Network.Models.PSApplicationGatewaySslPredefinedPolicy, Microsoft.Azure.Commands.Network, Version=4.1.0.0, Culture=neutral, PublicKeyToken=null]]

## NOTES

## RELATED LINKS

