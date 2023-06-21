---
external help file:
Module Name: Az.SelfHelp
online version: https://learn.microsoft.com/powershell/module/az.selfhelp/test-azselfhelpdiagnosticnameavailability
schema: 2.0.0
---

# Test-AzSelfHelpDiagnosticNameAvailability

## SYNOPSIS

This API is used to check the uniqueness of a resource name used for a diagnostic check.

## SYNTAX

### CheckExpanded (Default)

```
Test-AzSelfHelpDiagnosticNameAvailability -Scope <String> [-Name <String>] [-Type <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Check

```
Test-AzSelfHelpDiagnosticNameAvailability -Scope <String>
 -CheckNameAvailabilityRequest <ICheckNameAvailabilityRequest> [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CheckViaIdentity

```
Test-AzSelfHelpDiagnosticNameAvailability -InputObject <ISelfHelpIdentity>
 -CheckNameAvailabilityRequest <ICheckNameAvailabilityRequest> [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CheckViaIdentityExpanded

```
Test-AzSelfHelpDiagnosticNameAvailability -InputObject <ISelfHelpIdentity> [-Name <String>] [-Type <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION

This API is used to check the uniqueness of a resource name used for a diagnostic check.

## EXAMPLES

### Example 1: Example when the diagnostic resource name is available

```powershell
Test-AzSelfHelpDiagnosticNameAvailability -Name test-diagnostics-resource -Type microsoft.help/diagnostics -Scope "subscriptions/6bded6d5-a6af-43e1-96d3-bf71f6f5f8ba"
```

```output
Message NameAvailable Reason
------- ------------- ------
        True

```

Example when the diagnostic resource name is available

### Example 2: Example when the diagnostic resource name is available

```powershell
Test-AzSelfHelpDiagnosticNameAvailability -Name test-diagnostics-resource -Type microsoft.help/diagnostics -Scope "subscriptions/6bded6d5-a6af-43e1-96d3-bf71f6f5f8ba"
```

```output
Message                            NameAvailable   Reason
-------                            -------------   ------
Resource name is currently in use. False           Resource name already exisits/unavailable
```

Example when the diagnostic resource name is not available

## PARAMETERS

### -CheckNameAvailabilityRequest

The check availability request body.
To construct, see NOTES section for CHECKNAMEAVAILABILITYREQUEST properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.Api30.ICheckNameAvailabilityRequest
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
Type: Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.ISelfHelpIdentity
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

### Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.Api30.ICheckNameAvailabilityRequest

### Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.ISelfHelpIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.Api202301Preview.ICheckNameAvailabilityResponse

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

`CHECKNAMEAVAILABILITYREQUEST <ICheckNameAvailabilityRequest>`: The check availability request body.

- `[Name <String>]`: The name of the resource for which availability needs to be checked.
- `[Type <String>]`: The resource type.

`INPUTOBJECT <ISelfHelpIdentity>`: Identity Parameter

- `[DiagnosticsResourceName <String>]`: Unique resource name for insight resources
- `[Id <String>]`: Resource identity path
- `[Scope <String>]`: This is an extension resource provider and only resource level extension is supported at the moment.

## RELATED LINKS
