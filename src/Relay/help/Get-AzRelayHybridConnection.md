---
external help file:
Module Name: Az.Relay
online version: https://learn.microsoft.com/powershell/module/az.relay/get-azrelayhybridconnection
schema: 2.0.0
---

# Get-AzRelayHybridConnection

## SYNOPSIS
Returns the description for the specified hybrid connection.

## SYNTAX

### List (Default)
```
Get-AzRelayHybridConnection -Namespace <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzRelayHybridConnection -Name <String> -Namespace <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzRelayHybridConnection -InputObject <IRelayIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Returns the description for the specified hybrid connection.

## EXAMPLES

### Example 1: List all Hybrid Connections within the Relay namespace
```powershell
Get-AzRelayHybridConnection -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01
```

```output
Location Name          ResourceGroupName
-------- ----          -----------------
eastus   connection-01 lucas-relay-rg
```

This cmdlet lists all Hybrid Connections within the Relay namespace.

### Example 2: Gets a HybridConnection within the Relay namespace
```powershell
Get-AzRelayHybridConnection -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -Name connection-01 | Format-List
```

```output
CreatedAt                    : 12/20/2022 6:29:13 AM
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/lucas-relay-rg/providers/Microso
                               ft.Relay/namespaces/namespace-pwsh01/hybridconnections/connection-01
ListenerCount                : 0
Location                     : eastus
Name                         : connection-01
RequiresClientAuthorization  : True
ResourceGroupName            : lucas-relay-rg
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.Relay/namespaces/hybridconnections
UpdatedAt                    : 12/20/2022 6:29:40 AM
UserMetadata                 : 
```

This cmdlet gets a HybridConnection within the Relay namespace.

### Example 3: Gets a HybridConnection within the Relay namespace by pipeline
```powershell
Get-AzRelayHybridConnection -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 | Get-AzRelayHybridConnection
```

```output
Location Name          ResourceGroupName
-------- ----          -----------------
eastus   connection-01 lucas-relay-rg
```

This command gets a HybridConnection within the Relay namespace by pipeline.

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
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The hybrid connection name.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: HybridConnectionName

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
Parameter Sets: Get, List
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
Parameter Sets: Get, List
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
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Relay.Models.IRelayIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Relay.Models.Api20211101.IHybridConnection

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

