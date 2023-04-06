---
external help file:
Module Name: Az.Relay
online version: https://learn.microsoft.com/powershell/module/az.relay/get-azrelaykey
schema: 2.0.0
---

# Get-AzRelayKey

## SYNOPSIS
Primary and secondary connection strings to the namespace.

## SYNTAX

### List (Default)
```
Get-AzRelayKey -Name <String> -Namespace <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### List1
```
Get-AzRelayKey -HybridConnection <String> -Name <String> -Namespace <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### List2
```
Get-AzRelayKey -Name <String> -Namespace <String> -ResourceGroupName <String> -WcfRelay <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Primary and secondary connection strings to the namespace.

## EXAMPLES

### Example 1: Get the primary and secondary connection strings for the given Relay namespace
```powershell
Get-AzRelayKey -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -Name authRule-01
```

```output
KeyName                   : authRule-01
PrimaryConnectionString   : Endpoint=sb://namespace-pwsh01.servicebus.windows.net/;SharedAccessKeyName=authRule-01;SharedAccessKey=xxxxxxxxxxxxxxxxx
PrimaryKey                : xxxxxxxxxxxxxxxxx
SecondaryConnectionString : Endpoint=sb://namespace-pwsh01.servicebus.windows.net/;SharedAccessKeyName=authRule-01;SharedAccessKey=xxxxxxxxxxxxxxxxx
SecondaryKey              : xxxxxxxxxxxxxxxxx
```

This cmdlet gets the primary and secondary connection strings for the given Relay namespace.

### Example 2: Get the primary and secondary connection strings for the given Hybrid Connection
```powershell
Get-AzRelayKey -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -HybridConnection connection-01  -Name authRule-01
```

```output
KeyName                   : authRule-01
PrimaryConnectionString   : Endpoint=sb://namespace-pwsh01.servicebus.windows.net/;SharedAccessKeyName=authRule-01;SharedAccessKey=xxxxxxxxxxxxxxxxx
PrimaryKey                : xxxxxxxxxxxxxxxxx
SecondaryConnectionString : Endpoint=sb://namespace-pwsh01.servicebus.windows.net/;SharedAccessKeyName=authRule-01;SharedAccessKey=xxxxxxxxxxxxxxxxx
SecondaryKey              : xxxxxxxxxxxxxxxxx
```

This cmdlet gets the primary and secondary connection strings for the given Hybrid Connection.

### Example 3: Get the primary and secondary connection strings for the given Wcf Relay
```powershell
Get-AzRelayKey -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -WcfRelay wcf-01  -Name authRule-01 | Format-List
```

```output
KeyName                   : authRule-01
PrimaryConnectionString   : Endpoint=sb://namespace-pwsh01.servicebus.windows.net/;SharedAccessKeyName=authRule-01;SharedAccessKey=xxxxxxxxxxxxxxxxx
PrimaryKey                : xxxxxxxxxxxxxxxxx
SecondaryConnectionString : Endpoint=sb://namespace-pwsh01.servicebus.windows.net/;SharedAccessKeyName=authRule-01;SharedAccessKey=xxxxxxxxxxxxxxxxx
SecondaryKey              : xxxxxxxxxxxxxxxxx
```

This cmdlet gets the primary and secondary connection strings for the given Wcf Relay.

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -HybridConnection
The hybrid connection name.

```yaml
Type: System.String
Parameter Sets: List1
Aliases:

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
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Namespace
The namespace name

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
Subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -WcfRelay
The relay name.

```yaml
Type: System.String
Parameter Sets: List2
Aliases:

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

### Microsoft.Azure.PowerShell.Cmdlets.Relay.Models.Api20211101.IAccessKeys

## NOTES

ALIASES

## RELATED LINKS

