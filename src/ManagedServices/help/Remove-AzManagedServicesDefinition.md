---
external help file:
Module Name: Az.ManagedServices
online version: https://docs.microsoft.com/powershell/module/az.managedservices/remove-azmanagedservicesdefinition
schema: 2.0.0
---

# Remove-AzManagedServicesDefinition

## SYNOPSIS
Deletes the registration definition.

## SYNTAX

### Delete (Default)
```
Remove-AzManagedServicesDefinition -Name <String> [-Scope <String>] [-DefaultProfile <PSObject>] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### DeleteViaIdentity
```
Remove-AzManagedServicesDefinition -InputObject <IManagedServicesIdentity> [-DefaultProfile <PSObject>]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Deletes the registration definition.

## EXAMPLES

### Example 1: Removes Azure Lighthouse registration definition
```powershell
Remove-AzManagedServicesDefinition -Name xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx -Scope "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"
```

Removes Azure Lighthouse registration definition at the given scope.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Models.IManagedServicesIdentity
Parameter Sets: DeleteViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The GUID of the registration definition.

```yaml
Type: System.String
Parameter Sets: Delete
Aliases: RegistrationDefinitionId

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

### -Scope
The scope of the resource.

```yaml
Type: System.String
Parameter Sets: Delete
Aliases:

Required: False
Position: Named
Default value: "subscriptions/" + (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Models.IManagedServicesIdentity

## OUTPUTS

### System.Boolean

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT `<IManagedServicesIdentity>`: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[MarketplaceIdentifier <String>]`: The Azure Marketplace identifier. Expected formats: {publisher}.{product[-preview]}.{planName}.{version} or {publisher}.{product[-preview]}.{planName} or {publisher}.{product[-preview]} or {publisher}).
  - `[RegistrationAssignmentId <String>]`: The GUID of the registration assignment.
  - `[RegistrationDefinitionId <String>]`: The GUID of the registration definition.
  - `[Scope <String>]`: The scope of the resource.

## RELATED LINKS

