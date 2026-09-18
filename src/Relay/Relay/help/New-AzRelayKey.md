---
external help file: Az.Relay-help.xml
Module Name: Az.Relay
online version: https://learn.microsoft.com/powershell/module/az.relay/new-azrelaykey
schema: 2.0.0
---

# New-AzRelayKey

## SYNOPSIS
Regenerates the primary or secondary connection strings to the namespace.

## SYNTAX

### RegenerateExpanded (Default)
```
New-AzRelayKey -Name <String> -Namespace <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -RegenerateKey <String> [-KeyValue <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RegenerateViaJsonString1
```
New-AzRelayKey -Name <String> -Namespace <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -HybridConnection <String> -JsonString <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RegenerateViaJsonFilePath1
```
New-AzRelayKey -Name <String> -Namespace <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -HybridConnection <String> -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RegenerateExpanded1
```
New-AzRelayKey -Name <String> -Namespace <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -HybridConnection <String> -RegenerateKey <String> [-KeyValue <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RegenerateViaJsonString2
```
New-AzRelayKey -Name <String> -Namespace <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -WcfRelay <String> -JsonString <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RegenerateViaJsonFilePath2
```
New-AzRelayKey -Name <String> -Namespace <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -WcfRelay <String> -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RegenerateExpanded2
```
New-AzRelayKey -Name <String> -Namespace <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -WcfRelay <String> -RegenerateKey <String> [-KeyValue <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RegenerateViaJsonFilePath
```
New-AzRelayKey -Name <String> -Namespace <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### RegenerateViaJsonString
```
New-AzRelayKey -Name <String> -Namespace <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonString <String> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Regenerates the primary or secondary connection strings to the namespace.

## EXAMPLES

### Example 1: Regenerates the primary or secondary connection strings for the given Relay namespace
```powershell
New-AzRelayKey -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -Name authRule-01 -RegenerateKey 'PrimaryKey'
```

```output
KeyName     PrimaryConnectionString
-------     -----------------------                                                                                                                          
authRule-01 Endpoint=sb://namespace-pwsh01.servicebus.windows.net/;SharedAccessKeyName=authRule-01;SharedAccessKey=xxxxxxxxxxxxxxxxx
```

This cmdlet regenerates the primary or secondary connection strings for the given Relay namespace.

### Example 2: Regenerates the primary or secondary connection strings for the given Hybrid Connection
```powershell
New-AzRelayKey -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -HybridConnection connection-01  -Name authRule-01 -RegenerateKey 'PrimaryKey'
```

```output
KeyName     PrimaryConnectionString
-------     -----------------------                                                                                                                          
authRule-01 Endpoint=sb://namespace-pwsh01.servicebus.windows.net/;SharedAccessKeyName=authRule-01;SharedAccessKey=xxxxxxxxxxxxxxxxx
```

This cmdlet regenerates the primary or secondary connection strings for the given Hybrid Connection.

### Example 3: Regenerates the primary or secondary connection strings for the given Wcf Relay
```powershell
New-AzRelayKey -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -WcfRelay wcf-01  -Name authRule-01 -RegenerateKey 'PrimaryKey'
```

```output
KeyName     PrimaryConnectionString
-------     -----------------------                                                                                                                          
authRule-01 Endpoint=sb://namespace-pwsh01.servicebus.windows.net/;SharedAccessKeyName=authRule-01;SharedAccessKey=xxxxxxxxxxxxxxxxx
```

This cmdlet regenerates the primary or secondary connection strings for the given Wcf Relay.

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
Parameter Sets: RegenerateViaJsonString1, RegenerateViaJsonFilePath1, RegenerateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Regenerate operation

```yaml
Type: System.String
Parameter Sets: RegenerateViaJsonFilePath1, RegenerateViaJsonFilePath2, RegenerateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Regenerate operation

```yaml
Type: System.String
Parameter Sets: RegenerateViaJsonString1, RegenerateViaJsonString2, RegenerateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyValue
Optional.
If the key value is provided, this is set to key type, or autogenerated key value set for key type.

```yaml
Type: System.String
Parameter Sets: RegenerateExpanded, RegenerateExpanded1, RegenerateExpanded2
Aliases:

Required: False
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

### -RegenerateKey
The access key to regenerate.

```yaml
Type: System.String
Parameter Sets: RegenerateExpanded, RegenerateExpanded1, RegenerateExpanded2
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
Type: System.String
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
Parameter Sets: RegenerateViaJsonString2, RegenerateViaJsonFilePath2, RegenerateExpanded2
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

### Microsoft.Azure.PowerShell.Cmdlets.Relay.Models.IAccessKeys

## NOTES

## RELATED LINKS
