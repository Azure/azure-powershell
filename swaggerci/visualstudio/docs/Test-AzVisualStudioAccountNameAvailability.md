---
external help file:
Module Name: Az.VisualStudio
online version: https://docs.microsoft.com/en-us/powershell/module/az.visualstudio/test-azvisualstudioaccountnameavailability
schema: 2.0.0
---

# Test-AzVisualStudioAccountNameAvailability

## SYNOPSIS
Checks if the specified Visual Studio Team Services account name is available.
Resource name can be either an account name or an account name and PUID.

## SYNTAX

### CheckExpanded (Default)
```
Test-AzVisualStudioAccountNameAvailability [-SubscriptionId <String>] [-ResourceName <String>]
 [-ResourceType <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Check
```
Test-AzVisualStudioAccountNameAvailability -Body <ICheckNameAvailabilityParameter> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CheckViaIdentity
```
Test-AzVisualStudioAccountNameAvailability -InputObject <IVisualStudioIdentity>
 -Body <ICheckNameAvailabilityParameter> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CheckViaIdentityExpanded
```
Test-AzVisualStudioAccountNameAvailability -InputObject <IVisualStudioIdentity> [-ResourceName <String>]
 [-ResourceType <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Checks if the specified Visual Studio Team Services account name is available.
Resource name can be either an account name or an account name and PUID.

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

### -Body
The body of a POST request to check name availability.
To construct, see NOTES section for BODY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.VisualStudio.Models.Api20140401Preview.ICheckNameAvailabilityParameter
Parameter Sets: Check, CheckViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
Type: Microsoft.Azure.PowerShell.Cmdlets.VisualStudio.Models.IVisualStudioIdentity
Parameter Sets: CheckViaIdentity, CheckViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceName
The name of the resource to check availability for.

```yaml
Type: System.String
Parameter Sets: CheckExpanded, CheckViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceType
The type of resource to check availability for.

```yaml
Type: System.String
Parameter Sets: CheckExpanded, CheckViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The Azure subscription identifier.

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

### Microsoft.Azure.PowerShell.Cmdlets.VisualStudio.Models.Api20140401Preview.ICheckNameAvailabilityParameter

### Microsoft.Azure.PowerShell.Cmdlets.VisualStudio.Models.IVisualStudioIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.VisualStudio.Models.Api20140401Preview.ICheckNameAvailabilityResult

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


BODY <ICheckNameAvailabilityParameter>: The body of a POST request to check name availability.
  - `[ResourceName <String>]`: The name of the resource to check availability for.
  - `[ResourceType <String>]`: The type of resource to check availability for.

INPUTOBJECT <IVisualStudioIdentity>: Identity Parameter
  - `[AccountResourceName <String>]`: The name of the Visual Studio Team Services account resource.
  - `[ExtensionResourceName <String>]`: The name of the extension.
  - `[Id <String>]`: Resource identity path
  - `[ResourceGroupName <String>]`: Name of the resource group within the Azure subscription.
  - `[ResourceName <String>]`: Name of the resource.
  - `[RootResourceName <String>]`: Name of the Team Services account.
  - `[SubContainerName <String>]`: This parameter should be set to the resourceName.
  - `[SubscriptionId <String>]`: The Azure subscription identifier.

## RELATED LINKS

