---
external help file:
Module Name: Az.Relay
online version: https://learn.microsoft.com/powershell/module/az.relay/set-azwcfrelay
schema: 2.0.0
---

# Set-AzWcfRelay

## SYNOPSIS
Creates or updates a WCF relay.
This operation is idempotent.

## SYNTAX

### UpdateExpanded (Default)
```
Set-AzWcfRelay -Name <String> -Namespace <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-UserMetadata <String>] [-WcfRelayType <Relaytype>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Update
```
Set-AzWcfRelay -Name <String> -Namespace <String> -ResourceGroupName <String> -InputObject <IWcfRelay>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a WCF relay.
This operation is idempotent.

## EXAMPLES

### Example 1: Updates the description for the WcfRelay in the specified Relay namespace with InputObject
```powershell
$wcf = Get-AzWcfRelay -ResourceGroupName Relay-ServiceBus-EastUS -Namespace namespace-pwsh01 -Name wcfRelay-01
$wcf.UserMetadata = "User Meta Data"
Set-AzWcfRelay -ResourceGroupName Relay-ServiceBus-EastUS -Namespace namespace-pwsh01 -Name wcfRelay-01 -InputObject $wcf | Format-List
```

```output
CreatedAt                    : 1/1/0001 12:00:00 AM 
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/Relay-ServiceBus-EastUS/providers/Microsoft.Relay/namespaces/namespace-pwsh01/wcfrelays/wcfRe 
                               lay-01
IsDynamic                    : False
ListenerCount                : 0
Location                     : eastus
Name                         : wcfRelay-01
RelayType                    : NetTcp
RequiresClientAuthorization  : False
RequiresTransportSecurity    : False
ResourceGroupName            : Relay-ServiceBus-EastUS
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.Relay/namespaces/wcfrelays
UpdatedAt                    : 1/1/0001 12:00:00 AM
UserMetadata                 : User Meta Data
```

This command updates the description for the WcfRelay in the specified Relay namespace.

### Example 2: Updates the description for the WcfRelay in the specified Relay namespace with Properties
```powershell
Set-AzWcfRelay -ResourceGroupName Relay-ServiceBus-EastUS -Namespace namespace-pwsh01 -Name wcfRelay-01 -UserMetadata "usermetadata is a placeholder to store user-defined string data for the HybridConnection endpoint.e.g. it can be used to store descriptive data, such as list of teams and their contact information also user-defined configuration settings can be stored." | Format-List
```

```output
CreatedAt                    : 3/30/2023 1:56:56 AM
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/Relay-ServiceBus-EastUS/providers/Microsoft.Relay/namespaces/namespace-pwsh01/wcfrelays/wcfRe 
                               lay-01
IsDynamic                    : False
ListenerCount                : 0
Location                     : eastus
Name                         : wcfRelay-01
RelayType                    : NetTcp
RequiresClientAuthorization  : False
RequiresTransportSecurity    : False
ResourceGroupName            : Relay-ServiceBus-EastUS
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.Relay/namespaces/wcfrelays
UpdatedAt                    : 3/30/2023 2:53:03 AM
UserMetadata                 : usermetadata is a placeholder to store user-defined string data for the HybridConnection endpoint.e.g. it can be used to store descriptive data, such as list    
                               of teams and their contact information also user-defined configuration settings can be stored.
```

This command updates the specified WcfRelay with a new description in the specified namespace.
This example updates the UserMetadata property with new value.

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
Description of the WCF relay resource.
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Relay.Models.Api20211101.IWcfRelay
Parameter Sets: Update
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The relay name.

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
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserMetadata
The usermetadata is a placeholder to store user-defined string data for the WCF Relay endpoint.
For example, it can be used to store descriptive data, such as list of teams and their contact information.
Also, user-defined configuration settings can be stored.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WcfRelayType
WCF relay type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Relay.Support.Relaytype
Parameter Sets: UpdateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Relay.Models.Api20211101.IWcfRelay

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Relay.Models.Api20211101.IWcfRelay

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IWcfRelay>`: Description of the WCF relay resource.
  - `[RelayType <Relaytype?>]`: WCF relay type.
  - `[RequiresClientAuthorization <Boolean?>]`: Returns true if client authorization is needed for this relay; otherwise, false.
  - `[RequiresTransportSecurity <Boolean?>]`: Returns true if transport security is needed for this relay; otherwise, false.
  - `[SystemDataCreatedAt <DateTime?>]`: The timestamp of resource creation (UTC).
  - `[SystemDataCreatedBy <String>]`: The identity that created the resource.
  - `[SystemDataCreatedByType <CreatedByType?>]`: The type of identity that created the resource.
  - `[SystemDataLastModifiedAt <DateTime?>]`: The timestamp of resource last modification (UTC)
  - `[SystemDataLastModifiedBy <String>]`: The identity that last modified the resource.
  - `[SystemDataLastModifiedByType <CreatedByType?>]`: The type of identity that last modified the resource.
  - `[UserMetadata <String>]`: The usermetadata is a placeholder to store user-defined string data for the WCF Relay endpoint. For example, it can be used to store descriptive data, such as list of teams and their contact information. Also, user-defined configuration settings can be stored.

## RELATED LINKS

