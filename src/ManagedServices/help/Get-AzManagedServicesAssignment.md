---
external help file:
Module Name: Az.ManagedServices
online version: https://docs.microsoft.com/powershell/module/az.managedservices/get-azmanagedservicesassignment
schema: 2.0.0
---

# Get-AzManagedServicesAssignment

## SYNOPSIS
Gets the details of the specified registration assignment.

## SYNTAX

### List (Default)
```
Get-AzManagedServicesAssignment [-Scope <String>] [-ExpandRegistrationDefinition] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzManagedServicesAssignment -Name <String> [-Scope <String>] [-ExpandRegistrationDefinition]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzManagedServicesAssignment -InputObject <IManagedServicesIdentity> [-ExpandRegistrationDefinition]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the details of the specified registration assignment.

## EXAMPLES

### Example 1: List all Azure Lighthouse registration assignments in a subscription
```powershell
Get-AzManagedServicesAssignment
```

```output
Name                                 Type
----                                 ----
xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx Microsoft.ManagedServices/registrationAssignments
xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx Microsoft.ManagedServices/registrationAssignments
xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx Microsoft.ManagedServices/registrationAssignments
```

Lists all the Azure Lighthouse registration assignments in a given subscription in context.

### Example 2: Get Azure Lighthouse registration assignment by name with selected properties
```powershell
Get-AzManagedServicesAssignment -Name xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx | Format-List -Property Id, Name, Type, RegistrationDefinitionId, ProvisioningState
```

```output
Id                       : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.ManagedServices/registrationAssignments/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
Name                     : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
Type                     : Microsoft.ManagedServices/registrationAssignments
RegistrationDefinitionId : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.ManagedServices/registrationDefinitions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
ProvisioningState        : Succeeded
```

Gets Azure Lighthouse registration assignment by name with selected properties.

### Example 3: List all Azure Lighthouse registration assignments by scope
```powershell
Get-AzManagedServicesAssignment -Scope /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx | Format-List -Property Id, Name, Type, RegistrationDefinitionId, ProvisioningState
```

```output
Id                       : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.ManagedServices/registrationAssignments/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
Name                     : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
Type                     : Microsoft.ManagedServices/registrationAssignments
RegistrationDefinitionId : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.ManagedServices/registrationDefinitions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
ProvisioningState        : Succeeded

Id                       : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.ManagedServices/registrationAssignments/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
Name                     : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
Type                     : Microsoft.ManagedServices/registrationAssignments
RegistrationDefinitionId : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.ManagedServices/registrationDefinitions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
ProvisioningState        : Succeeded

Id                       : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.ManagedServices/registrationAssignments/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
Name                     : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
Type                     : Microsoft.ManagedServices/registrationAssignments
RegistrationDefinitionId : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.ManagedServices/registrationDefinitions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
ProvisioningState        : Succeeded
```

Lists all the Azure Lighthouse registration assignments in a given subscription or resource group scope.

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

### -ExpandRegistrationDefinition
The flag indicating whether to return the registration definition details along with the registration assignment details.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Models.IManagedServicesIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The GUID of the registration assignment.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: RegistrationAssignmentId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
The scope of the resource.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: "subscriptions/" + (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Models.IManagedServicesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Models.Api20200201Preview.IRegistrationAssignment

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IManagedServicesIdentity>: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[MarketplaceIdentifier <String>]`: The Azure Marketplace identifier. Expected formats: {publisher}.{product[-preview]}.{planName}.{version} or {publisher}.{product[-preview]}.{planName} or {publisher}.{product[-preview]} or {publisher}).
  - `[RegistrationAssignmentId <String>]`: The GUID of the registration assignment.
  - `[RegistrationDefinitionId <String>]`: The GUID of the registration definition.
  - `[Scope <String>]`: The scope of the resource.

## RELATED LINKS

