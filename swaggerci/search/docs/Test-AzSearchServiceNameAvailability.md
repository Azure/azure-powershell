---
external help file:
Module Name: Az.Search
online version: https://docs.microsoft.com/en-us/powershell/module/az.search/test-azsearchservicenameavailability
schema: 2.0.0
---

# Test-AzSearchServiceNameAvailability

## SYNOPSIS
Checks whether or not the given search service name is available for use.
Search service names must be globally unique since they are part of the service URI (https://\<name\>.search.windows.net).

## SYNTAX

### CheckExpanded (Default)
```
Test-AzSearchServiceNameAvailability -Name <String> [-SubscriptionId <String>] [-ClientRequestId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Check
```
Test-AzSearchServiceNameAvailability -CheckNameAvailabilityInput <ICheckNameAvailabilityInput>
 [-SubscriptionId <String>] [-ClientRequestId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CheckViaIdentity
```
Test-AzSearchServiceNameAvailability -InputObject <ISearchIdentity>
 -CheckNameAvailabilityInput <ICheckNameAvailabilityInput> [-ClientRequestId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CheckViaIdentityExpanded
```
Test-AzSearchServiceNameAvailability -InputObject <ISearchIdentity> -Name <String> [-ClientRequestId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Checks whether or not the given search service name is available for use.
Search service names must be globally unique since they are part of the service URI (https://\<name\>.search.windows.net).

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

### -CheckNameAvailabilityInput
Input of check name availability API.
To construct, see NOTES section for CHECKNAMEAVAILABILITYINPUT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Search.Models.Api20200801.ICheckNameAvailabilityInput
Parameter Sets: Check, CheckViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ClientRequestId
A client-generated GUID value that identifies this request.
If specified, this will be included in response information as a way to track the request.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Search.Models.ISearchIdentity
Parameter Sets: CheckViaIdentity, CheckViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The search service name to validate.
Search service names must only contain lowercase letters, digits or dashes, cannot use dash as the first two or last one characters, cannot contain consecutive dashes, and must be between 2 and 60 characters in length.

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

### -SubscriptionId
The unique identifier for a Microsoft Azure subscription.
You can obtain this value from the Azure Resource Manager API or the portal.

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

### Microsoft.Azure.PowerShell.Cmdlets.Search.Models.Api20200801.ICheckNameAvailabilityInput

### Microsoft.Azure.PowerShell.Cmdlets.Search.Models.ISearchIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Search.Models.Api20200801.ICheckNameAvailabilityOutput

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


CHECKNAMEAVAILABILITYINPUT <ICheckNameAvailabilityInput>: Input of check name availability API.
  - `Name <String>`: The search service name to validate. Search service names must only contain lowercase letters, digits or dashes, cannot use dash as the first two or last one characters, cannot contain consecutive dashes, and must be between 2 and 60 characters in length.

INPUTOBJECT <ISearchIdentity>: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[Key <String>]`: The query key to be deleted. Query keys are identified by value, not by name.
  - `[KeyKind <AdminKeyKind?>]`: Specifies which key to regenerate. Valid values include 'primary' and 'secondary'.
  - `[Name <String>]`: The name of the new query API key.
  - `[PrivateEndpointConnectionName <String>]`: The name of the private endpoint connection to the Azure Cognitive Search service with the specified resource group.
  - `[ResourceGroupName <String>]`: The name of the resource group within the current subscription. You can obtain this value from the Azure Resource Manager API or the portal.
  - `[SearchServiceName <String>]`: The name of the Azure Cognitive Search service associated with the specified resource group.
  - `[SharedPrivateLinkResourceName <String>]`: The name of the shared private link resource managed by the Azure Cognitive Search service within the specified resource group.
  - `[SubscriptionId <String>]`: The unique identifier for a Microsoft Azure subscription. You can obtain this value from the Azure Resource Manager API or the portal.

## RELATED LINKS

