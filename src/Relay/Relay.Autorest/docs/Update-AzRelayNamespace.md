---
external help file:
Module Name: Az.Relay
online version: https://learn.microsoft.com/powershell/module/az.relay/update-azrelaynamespace
schema: 2.0.0
---

# Update-AzRelayNamespace

## SYNOPSIS
Creates or updates a namespace.
Once created, this namespace's resource manifest is immutable.
This operation is idempotent.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzRelayNamespace -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzRelayNamespace -InputObject <IRelayIdentity> [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a namespace.
Once created, this namespace's resource manifest is immutable.
This operation is idempotent.

## EXAMPLES

### Example 1: Updates a Relay namespace
```powershell
Update-AzRelayNamespace -ResourceGroupName lucas-relay-rg -Name namespace-pwsh01 -Tag @{'k'='v'}
```

```output
Name             ResourceGroupName Location Status     SkuName  ServiceBusEndpoint
----             ----------------- -------- ------     -------  ------------------
namespace-pwsh01 lucas-relay-rg    East US  Activating Standard https://namespace-pwsh01.servicebus.windows.net:443/
```

This cmdlet updates a Relay namespace.

### Example 2: Updates a Relay namespace by pipeline
```powershell
Get-AzRelayNamespace -ResourceGroupName lucas-relay-rg -Name namespace-pwsh01 | Update-AzRelayNamespace -Tag @{'k'='v'}
```

```output
Name             ResourceGroupName Location Status     SkuName  ServiceBusEndpoint
----             ----------------- -------- ------     -------  ------------------
namespace-pwsh01 lucas-relay-rg    East US  Activating Standard https://namespace-pwsh01.servicebus.windows.net:443/
```

This cmdlet updates a Relay namespace by pipeline.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Relay.Models.IRelayIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The namespace name

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: NamespaceName

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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
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

### Microsoft.Azure.PowerShell.Cmdlets.Relay.Models.IRelayIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Relay.Models.Api20211101.IRelayNamespace

## NOTES

## RELATED LINKS

