---
external help file:
Module Name: Az.RelayApi
online version: https://docs.microsoft.com/en-us/powershell/module/az.relayapi/test-azrelayapinamespacenameavailability
schema: 2.0.0
---

# Test-AzRelayApiNamespaceNameAvailability

## SYNOPSIS
Check the specified namespace name availability.

## SYNTAX

### CheckExpanded (Default)
```
Test-AzRelayApiNamespaceNameAvailability -Name <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Check
```
Test-AzRelayApiNamespaceNameAvailability -Parameter <ICheckNameAvailability> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CheckViaIdentity
```
Test-AzRelayApiNamespaceNameAvailability -InputObject <IRelayApiIdentity> -Parameter <ICheckNameAvailability>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CheckViaIdentityExpanded
```
Test-AzRelayApiNamespaceNameAvailability -InputObject <IRelayApiIdentity> -Name <String>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Check the specified namespace name availability.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RelayApi.Models.IRelayApiIdentity
Parameter Sets: CheckViaIdentity, CheckViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The namespace name to check for availability.
The namespace name can contain only letters, numbers, and hyphens.
The namespace must start with a letter, and it must end with a letter or number.

```yaml
Type: System.String
Parameter Sets: CheckExpanded, CheckViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
Description of the check name availability request properties.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RelayApi.Models.Api20211101.ICheckNameAvailability
Parameter Sets: Check, CheckViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
Subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: Check, CheckExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.RelayApi.Models.Api20211101.ICheckNameAvailability

### Microsoft.Azure.PowerShell.Cmdlets.RelayApi.Models.IRelayApiIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.RelayApi.Models.Api20211101.ICheckNameAvailabilityResult

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IRelayApiIdentity>: Identity Parameter
  - `[AuthorizationRuleName <String>]`: The authorization rule name.
  - `[HybridConnectionName <String>]`: The hybrid connection name.
  - `[Id <String>]`: Resource identity path
  - `[NamespaceName <String>]`: The namespace name
  - `[PrivateEndpointConnectionName <String>]`: The PrivateEndpointConnection name
  - `[PrivateLinkResourceName <String>]`: The PrivateLinkResource name
  - `[RelayName <String>]`: The relay name.
  - `[ResourceGroupName <String>]`: Name of the Resource group within the Azure subscription.
  - `[SubscriptionId <String>]`: Subscription credentials which uniquely identify the Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.

PARAMETER <ICheckNameAvailability>: Description of the check name availability request properties.
  - `Name <String>`: The namespace name to check for availability. The namespace name can contain only letters, numbers, and hyphens. The namespace must start with a letter, and it must end with a letter or number.

## RELATED LINKS

