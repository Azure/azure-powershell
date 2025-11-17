---
external help file: Microsoft.Azure.PowerShell.Cmdlets.SignalR.dll-Help.xml
Module Name: Az.SignalR
online version: https://learn.microsoft.com/powershell/module/az.signalr/new-azsignalrnetworkipruleobject
schema: 2.0.0
---

# New-AzSignalRNetworkIpRuleObject

## SYNOPSIS
Create an in-memory IP rule object for use with SignalR Network ACL Ip rule cmdlets.

## SYNTAX

```
New-AzSignalRNetworkIpRuleObject -Value <String> [-Action <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Creates a PSIpRule object (not persisted in Azure) that defines a single IP rule entry with a value (single IP address, CIDR range, or Azure Service Tag) and an action (Allow or Deny). The resulting object can be supplied to Add-AzSignalRNetworkIpRule or Remove-AzSignalRNetworkIpRule.

## EXAMPLES

### Example 1: Create an allow rule for a CIDR range
```powershell
$rule = New-AzSignalRNetworkIpRuleObject -Value "10.1.0.0/16" -Action Allow
$rule
```
Creates an IP rule permitting traffic from the specified CIDR range.

### Example 2: Create a deny rule for a single IP
```powershell
$denyRule = New-AzSignalRNetworkIpRuleObject -Value "52.23.45.10" -Action Deny
```
Creates an IP rule that denies access for a specific IP address.

## PARAMETERS

### -Action
Action for the IP rule. Allow or Deny. Default: Allow

```yaml
Type: String
Parameter Sets: (All)
Aliases:
Accepted values: Allow, Deny

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Value
IP rule value. Accepts IP, CIDR or ServiceTag.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.SignalR.Models.PSIpRule

## NOTES

## RELATED LINKS
