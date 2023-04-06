---
external help file:
Module Name: Az.Relay
online version: https://learn.microsoft.com/powershell/module/az.relay/set-azrelayhybridconnection
schema: 2.0.0
---

# Set-AzRelayHybridConnection

## SYNOPSIS
Creates or updates a service hybrid connection.
This operation is idempotent.

## SYNTAX

### UpdateExpanded (Default)
```
Set-AzRelayHybridConnection -Name <String> -Namespace <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-UserMetadata <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Update
```
Set-AzRelayHybridConnection -Name <String> -Namespace <String> -ResourceGroupName <String>
 -InputObject <IHybridConnection> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a service hybrid connection.
This operation is idempotent.

## EXAMPLES

### Example 1: Updates the specified HybridConnection with a new UserMetadata in the specified namespace.
```powershell
Set-AzRelayHybridConnection -ResourceGroupName Relay-ServiceBus-EastUS -Namespace namespace-pwsh01 -Name connection-01 -UserMetadata "Update UserMetaData" | Format-List
```

```output
CreatedAt                    : 1/1/0001 12:00:00 AM
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/Relay-ServiceBus-EastUS/providers/Microsoft.Relay/namespaces/namespace-pwsh01/hybridconnectio 
                               ns/connection-01
ListenerCount                : 0
Location                     : eastus
Name                         : connection-01
RequiresClientAuthorization  : True
ResourceGroupName            : Relay-ServiceBus-EastUS
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.Relay/namespaces/hybridconnections
UpdatedAt                    : 1/1/0001 12:00:00 AM
UserMetadata                 : Update UserMetaData
```

This command updates the specified HybridConnection with a new UserMetadata in the specified namespace.
This example updates the UserMetadata property with new value.

### Example 2: Updates a HybridConnection in the specified Relay namespace
```powershell
$connection = Get-AzRelayHybridConnection -ResourceGroupName Relay-ServiceBus-EastUS -Namespace namespace-pwsh01 -Name connection-01
$connection.UserMetadata = "testHybirdConnection"
Set-AzRelayHybridConnection -ResourceGroupName Relay-ServiceBus-EastUS -Namespace namespace-pwsh01 -Name connection-01 -InputObject $connection | Format-List
```

```output
CreatedAt                    : 3/30/2023 3:34:25 AM
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/Relay-ServiceBus-EastUS/providers/Microsoft.Relay/namespaces/namespace-pwsh01/hybridconnectio 
                               ns/connection-01
ListenerCount                : 0
Location                     : eastus
Name                         : connection-01
RequiresClientAuthorization  : True
ResourceGroupName            : Relay-ServiceBus-EastUS
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.Relay/namespaces/hybridconnections
UpdatedAt                    : 3/30/2023 6:28:37 AM
UserMetadata                 : testHybirdConnection
```

This command updates a HybridConnection in the specified Relay namespace.

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
Description of hybrid connection resource.
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Relay.Models.Api20211101.IHybridConnection
Parameter Sets: Update
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
Parameter Sets: (All)
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
The usermetadata is a placeholder to store user-defined string data for the hybrid connection endpoint.
For example, it can be used to store descriptive data, such as a list of teams and their contact information.
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

### Microsoft.Azure.PowerShell.Cmdlets.Relay.Models.Api20211101.IHybridConnection

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Relay.Models.Api20211101.IHybridConnection

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IHybridConnection>`: Description of hybrid connection resource.
  - `[RequiresClientAuthorization <Boolean?>]`: Returns true if client authorization is needed for this hybrid connection; otherwise, false.
  - `[SystemDataCreatedAt <DateTime?>]`: The timestamp of resource creation (UTC).
  - `[SystemDataCreatedBy <String>]`: The identity that created the resource.
  - `[SystemDataCreatedByType <CreatedByType?>]`: The type of identity that created the resource.
  - `[SystemDataLastModifiedAt <DateTime?>]`: The timestamp of resource last modification (UTC)
  - `[SystemDataLastModifiedBy <String>]`: The identity that last modified the resource.
  - `[SystemDataLastModifiedByType <CreatedByType?>]`: The type of identity that last modified the resource.
  - `[UserMetadata <String>]`: The usermetadata is a placeholder to store user-defined string data for the hybrid connection endpoint. For example, it can be used to store descriptive data, such as a list of teams and their contact information. Also, user-defined configuration settings can be stored.

## RELATED LINKS

