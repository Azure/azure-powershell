---
external help file:
Module Name: Az.HelpRp
online version: https://learn.microsoft.com/powershell/module/az.helprp/test-azhelprpdiagnosticnameavailability
schema: 2.0.0
---

# Test-AzHelpRpDiagnosticNameAvailability

## SYNOPSIS
This API is used to check the uniqueness of a resource name used for a diagnostic check.

## SYNTAX

### CheckExpanded (Default)
```
Test-AzHelpRpDiagnosticNameAvailability -Scope <String> [-Name <String>] [-Type <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Check
```
Test-AzHelpRpDiagnosticNameAvailability -Scope <String>
 -CheckNameAvailabilityRequest <ICheckNameAvailabilityRequest> [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CheckViaIdentity
```
Test-AzHelpRpDiagnosticNameAvailability -InputObject <IHelpRpIdentity>
 -CheckNameAvailabilityRequest <ICheckNameAvailabilityRequest> [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CheckViaIdentityExpanded
```
Test-AzHelpRpDiagnosticNameAvailability -InputObject <IHelpRpIdentity> [-Name <String>] [-Type <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
This API is used to check the uniqueness of a resource name used for a diagnostic check.

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

### -CheckNameAvailabilityRequest
The check availability request body.
To construct, see NOTES section for CHECKNAMEAVAILABILITYREQUEST properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HelpRp.Models.Api30.ICheckNameAvailabilityRequest
Parameter Sets: Check, CheckViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

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
Type: Microsoft.Azure.PowerShell.Cmdlets.HelpRp.Models.IHelpRpIdentity
Parameter Sets: CheckViaIdentity, CheckViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the resource for which availability needs to be checked.

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

### -Scope
This is an extension resource provider and only resource level extension is supported at the moment.

```yaml
Type: System.String
Parameter Sets: Check, CheckExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type
The resource type.

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

### Microsoft.Azure.PowerShell.Cmdlets.HelpRp.Models.Api30.ICheckNameAvailabilityRequest

### Microsoft.Azure.PowerShell.Cmdlets.HelpRp.Models.IHelpRpIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HelpRp.Models.Api202301Preview.ICheckNameAvailabilityResponse

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`CHECKNAMEAVAILABILITYREQUEST <ICheckNameAvailabilityRequest>`: The check availability request body.
  - `[Name <String>]`: The name of the resource for which availability needs to be checked.
  - `[Type <String>]`: The resource type.

`INPUTOBJECT <IHelpRpIdentity>`: Identity Parameter
  - `[DiagnosticsResourceName <String>]`: Unique resource name for insight resources
  - `[Id <String>]`: Resource identity path
  - `[Scope <String>]`: This is an extension resource provider and only resource level extension is supported at the moment.

## RELATED LINKS

