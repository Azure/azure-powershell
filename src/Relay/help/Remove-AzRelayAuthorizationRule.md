---
external help file:
Module Name: Az.Relay
online version: https://learn.microsoft.com/powershell/module/az.relay/remove-azrelayauthorizationrule
schema: 2.0.0
---

# Remove-AzRelayAuthorizationRule

## SYNOPSIS
Deletes a namespace authorization rule.

## SYNTAX

### Delete (Default)
```
Remove-AzRelayAuthorizationRule -Name <String> -Namespace <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Delete1
```
Remove-AzRelayAuthorizationRule -HybridConnection <String> -Name <String> -Namespace <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Delete2
```
Remove-AzRelayAuthorizationRule -Name <String> -Namespace <String> -ResourceGroupName <String>
 -WcfRelay <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### DeleteViaIdentity
```
Remove-AzRelayAuthorizationRule -InputObject <IRelayIdentity> [-DefaultProfile <PSObject>] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Deletes a namespace authorization rule.

## EXAMPLES

### Example 1: Remove an authorization rule description of the Relay namespace
```powershell
Remove-AzRelayAuthorizationRule -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -Name authRule-03
```

This cmdlet removes an authorization rule description of the Relay namespace.

### Example 2: Remove an authorization rule description of the Hybrid Connection
```powershell
Remove-AzRelayAuthorizationRule -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -HybridConnection connection-01 -Name authRule-01
```

This cmdlet removes an authorization rule description of the Hybrid Connection.

### Example 3: Remove an authorization rule description of the Wcf Relay
```powershell
Remove-AzRelayAuthorizationRule -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -WcfRelay wcf-02 -Name authRule-01
```

This cmdlet removes an authorization rule description of the Wcf Relay.

### Example 4: Remove authorization rule by pipeline
```powershell
Get-AzRelayAuthorizationRule -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -WcfRelay wcf-02 | Remove-AzRelayAuthorizationRule
```

This cmdlet removes authorization rule by pipeline.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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
Parameter Sets: Delete1
Aliases:

Required: True
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
Parameter Sets: DeleteViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The authorization rule name.

```yaml
Type: System.String
Parameter Sets: Delete, Delete1, Delete2
Aliases: AuthorizationRuleName

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
Parameter Sets: Delete, Delete1, Delete2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the Resource group within the Azure subscription.

```yaml
Type: System.String
Parameter Sets: Delete, Delete1, Delete2
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
Parameter Sets: Delete, Delete1, Delete2
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
Parameter Sets: Delete2
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

### Microsoft.Azure.PowerShell.Cmdlets.Relay.Models.IRelayIdentity

## OUTPUTS

### System.Boolean

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IRelayIdentity>`: Identity Parameter
  - `[AuthorizationRuleName <String>]`: The authorization rule name.
  - `[HybridConnectionName <String>]`: The hybrid connection name.
  - `[Id <String>]`: Resource identity path
  - `[NamespaceName <String>]`: The namespace name
  - `[PrivateEndpointConnectionName <String>]`: The PrivateEndpointConnection name
  - `[PrivateLinkResourceName <String>]`: The PrivateLinkResource name
  - `[RelayName <String>]`: The relay name.
  - `[ResourceGroupName <String>]`: Name of the Resource group within the Azure subscription.
  - `[SubscriptionId <String>]`: Subscription credentials which uniquely identify the Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.

## RELATED LINKS

