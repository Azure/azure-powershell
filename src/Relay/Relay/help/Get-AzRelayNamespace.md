---
external help file:
Module Name: Az.Relay
online version: https://learn.microsoft.com/powershell/module/az.relay/get-azrelaynamespace
schema: 2.0.0
---

# Get-AzRelayNamespace

## SYNOPSIS
Returns the description for the specified namespace.

## SYNTAX

### List (Default)
```
Get-AzRelayNamespace [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzRelayNamespace -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzRelayNamespace -InputObject <IRelayIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzRelayNamespace -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Returns the description for the specified namespace.

## EXAMPLES

### Example 1: List all Relay namespaces within the resource group
```powershell
Get-AzRelayNamespace -ResourceGroupName lucas-relay-rg
```

```output
Name             ResourceGroupName Location        Status SkuName  ServiceBusEndpoint
----             ----------------- --------        ------ -------  ------------------
lucasrelay       lucas-relay-rg    West Central US Active Standard https://lucasrelay.servicebus.windows.net:443/
namespace-pwsh01 lucas-relay-rg    East US         Active Standard https://namespace-pwsh01.servicebus.windows.net:443/
```

The cmdlet lists all Relay namespaces within the resource group.

### Example 2: Gets a description for the specified Relay namespace within the resource group
```powershell
Get-AzRelayNamespace -ResourceGroupName lucas-relay-rg -Name namespace-pwsh01 | Format-List
```

```output
CreatedAt                    : 12/20/2022 3:20:46 AM
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/lucas-relay-rg/providers/Microso
                               ft.Relay/namespaces/namespace-pwsh01
Location                     : East US
MetricId                     : 9e223dbe-3399-4e19-88eb-0975f02ac87f:namespace-pwsh01
Name                         : namespace-pwsh01
PrivateEndpointConnection    : 
ProvisioningState            : Succeeded
PublicNetworkAccess          : 
ResourceGroupName            : lucas-relay-rg
ServiceBusEndpoint           : https://namespace-pwsh01.servicebus.windows.net:443/
SkuName                      : Standard
SkuTier                      : Standard
Status                       : Active
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Tag                          : {
                               }
Type                         : Microsoft.Relay/Namespaces
UpdatedAt                    : 12/20/2022 3:21:28 AM
```

The cmdlet gets a description for the specified Relay namespace within the resource group.

### Example 3: Gets a description for the specified Relay namespace by pipeline
```powershell
$namespaces = Get-AzRelayNamespace -ResourceGroupName lucas-relay-rg 
$namespaces[0] | Get-AzRelayNamespace
```

```output
Name       ResourceGroupName Location        Status SkuName  ServiceBusEndpoint
----       ----------------- --------        ------ -------  ------------------
lucasrelay lucas-relay-rg    West Central US Active Standard https://lucasrelay.servicebus.windows.net:443/
```

The cmdlet gets a description for the specified Relay namespace by pipeline.

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
The namespace name

```yaml
Type: System.String
Parameter Sets: Get
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
Parameter Sets: Get, List1
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
Parameter Sets: Get, List, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.Relay.Models.Api20211101.IRelayNamespace

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

