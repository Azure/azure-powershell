---
external help file:
Module Name: Az.Relay
online version: https://learn.microsoft.com/powershell/module/az.relay/set-azrelayauthorizationrule
schema: 2.0.0
---

# Set-AzRelayAuthorizationRule

## SYNOPSIS
Creates or updates an authorization rule for a namespace.

## SYNTAX

### UpdateExpanded (Default)
```
Set-AzRelayAuthorizationRule -Name <String> -Namespace <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Rights <AccessRights[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Update
```
Set-AzRelayAuthorizationRule -Name <String> -Namespace <String> -ResourceGroupName <String>
 -InputObject <IAuthorizationRule> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Update1
```
Set-AzRelayAuthorizationRule -HybridConnection <String> -Name <String> -Namespace <String>
 -ResourceGroupName <String> -InputObject <IAuthorizationRule> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update2
```
Set-AzRelayAuthorizationRule -Name <String> -Namespace <String> -ResourceGroupName <String> -WcfRelay <String>
 -InputObject <IAuthorizationRule> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateExpanded1
```
Set-AzRelayAuthorizationRule -HybridConnection <String> -Name <String> -Namespace <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-Rights <AccessRights[]>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateExpanded2
```
Set-AzRelayAuthorizationRule -Name <String> -Namespace <String> -ResourceGroupName <String> -WcfRelay <String>
 [-SubscriptionId <String>] [-Rights <AccessRights[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Creates or updates an authorization rule for a namespace.

## EXAMPLES

### Example 1: Adds Listen from the access rights of the authorization rule for the Relay namespace
```powershell
Set-AzRelayAuthorizationRule -ResourceGroupName Relay-ServiceBus-EastUS -Namespace namespace-pwsh01 -Name authRule-01 -Rights 'Listen' | Format-List
```

```output
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/Relay-ServiceBus-EastUS/providers/Microsoft.Relay/namespaces/namespace-pwsh01/authorizationRu
                               les/authRule-01
Location                     : eastus
Name                         : authRule-01
ResourceGroupName            : Relay-ServiceBus-EastUS
Rights                       : {Listen}
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.Relay/Namespaces/AuthorizationRules
```

This cmdlet adds Listen from the access rights of the authorization rule for the Relay namespace.

### Example 2: Adds Send from the access rights of the authorization rule for the Relay namespace with InputeObject parameter
```powershell
$authRule = Get-AzRelayAuthorizationRule -ResourceGroupName Relay-ServiceBus-EastUS -Namespace namespace-pwsh01 -Name authRule-01
$authRule.Rights += 'Send'
Set-AzRelayAuthorizationRule -ResourceGroupName Relay-ServiceBus-EastUS -Namespace namespace-pwsh01 -Name authRule-01 -InputObject $authRule | Format-List
```

```output
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/Relay-ServiceBus-EastUS/providers/Microsoft.Relay/namespaces/namespace-pwsh01/authorizationRu
                               les/authRule-01
Location                     : eastus
Name                         : authRule-01
ResourceGroupName            : Relay-ServiceBus-EastUS
Rights                       : {Listen, Send}
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.Relay/Namespaces/AuthorizationRules
```

This cmdlet adds Send from the access rights of the authorization rule for the Relay namespace with InputeObject parameter.

### Example 3: Set or update Listen from the access rights of the authorization rule for the Hybrid Connection
```powershell
Set-AzRelayAuthorizationRule -ResourceGroupName Relay-ServiceBus-EastUS -Namespace namespace-pwsh01 -HybridConnection connection-01 -Name authRule-02 -Rights 'Listen' | Format-List
```

```output
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/Relay-ServiceBus-EastUS/providers/Microsoft.Relay/namespaces/namespace-pwsh01/hybridConnectio
                               ns/connection-01/authorizationRules/authRule-02
Location                     : 
Name                         : authRule-02
ResourceGroupName            : Relay-ServiceBus-EastUS
Rights                       : {Listen}
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.Relay/namespaces/hybridconnections/authorizationrules
```

This cmdlet set or update Listen from the access rights of the authorization rule for the Hybrid Connection.

### Example 4: Adds Send from the access rights of the authorization rule for the Hybrid Connection with InputeObject parameter
```powershell
$authRule = Get-AzRelayAuthorizationRule -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -HybridConnection connection-01 -Name authRule-01
$authRule.Rights += 'Send'
Set-AzRelayAuthorizationRule -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -HybridConnection connection-01 -Name authRule-01 -InputObject $authRule | Format-List
```

```output
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/lucas-relay-rg/providers/Microsoft.Relay/namespaces/namespace
                               -pwsh01/hybridConnections/connection-01/authorizationRules/authRule-01
Location                     : 
Name                         : authRule-01
ResourceGroupName            : lucas-relay-rg
Rights                       : {Listen, Send}
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.Relay/namespaces/hybridconnections/authorizationrules
```

This cmdlet adds Send from the access rights of the authorization rule for the Hybrid Connection with InputeObject parameter.

### Example 5: Adds Send from the access rights of the authorization rule for the Wcf Relay
```powershell
Set-AzRelayAuthorizationRule -ResourceGroupName Relay-ServiceBus-EastUS -Namespace namespace-pwsh01 -WcfRelay wcfrelay-01 -Name authRule-03 -Rights 'Listen' | Format-List
```

```output
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/Relay-ServiceBus-EastUS/providers/Microsoft.Relay/namespaces/namespace-pwsh01/wcfRelays/wcfre
                               lay-01/authorizationRules/authRule-03
Location                     : 
Name                         : authRule-03
ResourceGroupName            : Relay-ServiceBus-EastUS
Rights                       : {Listen}
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.Relay/namespaces/wcfrelays/authorizationrules
```

This cmdlet adds Send from the access rights of the authorization rule for the Wcf Relay.

### Example 6: Adds Send from the access rights of the authorization rule for the Wcf Relay with InputeObject parameter
```powershell
$authRule = Get-AzRelayAuthorizationRule -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -WcfRelay wcf-01 -Name authRule-01
$authRule.Rights += 'Send'
Set-AzRelayAuthorizationRule -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -WcfRelay wcf-01 -Name authRule-01 -InputObject $authRule | Format-List
```

```output
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/lucas-relay-rg/providers/Microsoft.Relay/namespaces/namespace-pwsh01/wcfRela
                               ys/wcf-01/authorizationRules/authRule-01
Location                     : 
Name                         : authRule-01
ResourceGroupName            : lucas-relay-rg
Rights                       : {Listen, Send}
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.Relay/namespaces/wcfrelays/authorizationrules
```

This cmdlet adds Send from the access rights of the authorization rule for the Wcf Relay with InputeObject parameter.

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
Parameter Sets: Update1, UpdateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Single item in a List or Get AuthorizationRule operation
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Relay.Models.Api20211101.IAuthorizationRule
Parameter Sets: Update, Update1, Update2
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
Parameter Sets: (All)
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

### -Rights
The rights associated with the rule.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Relay.Support.AccessRights[]
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateExpanded2
Aliases:

Required: False
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
Parameter Sets: Update2, UpdateExpanded2
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

### Microsoft.Azure.PowerShell.Cmdlets.Relay.Models.Api20211101.IAuthorizationRule

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Relay.Models.Api20211101.IAuthorizationRule

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IAuthorizationRule>`: Single item in a List or Get AuthorizationRule operation
  - `[Rights <AccessRights[]>]`: The rights associated with the rule.
  - `[SystemDataCreatedAt <DateTime?>]`: The timestamp of resource creation (UTC).
  - `[SystemDataCreatedBy <String>]`: The identity that created the resource.
  - `[SystemDataCreatedByType <CreatedByType?>]`: The type of identity that created the resource.
  - `[SystemDataLastModifiedAt <DateTime?>]`: The timestamp of resource last modification (UTC)
  - `[SystemDataLastModifiedBy <String>]`: The identity that last modified the resource.
  - `[SystemDataLastModifiedByType <CreatedByType?>]`: The type of identity that last modified the resource.

## RELATED LINKS

