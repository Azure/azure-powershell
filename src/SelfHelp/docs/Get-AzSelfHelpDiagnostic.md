---
external help file:
Module Name: Az.SelfHelp
online version: https://learn.microsoft.com/powershell/module/az.selfhelp/get-azselfhelpdiagnostic
schema: 2.0.0
---

# Get-AzSelfHelpDiagnostic

## SYNOPSIS

Get the diagnostics using the 'diagnosticsResourceName' you chose while creating the diagnostic.

## SYNTAX

### Get (Default)

```
Get-AzSelfHelpDiagnostic -Scope <String> -SResourceName <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity

```
Get-AzSelfHelpDiagnostic -InputObject <ISelfHelpIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION

Get the diagnostics using the 'diagnosticsResourceName' you chose while creating the diagnostic.

## EXAMPLES

### Example 1: Get diagnostic by resource id and diagnostic name

```powershell
 Get-AzSelfHelpDiagnostic -Scope "subscriptions/6bded6d5-a6df-44e1-96d3-bf71f6f5f8ba/resourceGroups/test-rgName/providers/Microsoft.KeyVault/vaults/testKeyVault" -SResourceName ab-test-983
```

```output
Name
----
ab-test-983
```

Get diagnostic by resource id and diagnostic name

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
Type: Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.ISelfHelpIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Scope

This is an extension resource provider and only resource level extension is supported at the moment.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SResourceName

Unique resource name for insight resources

```yaml
Type: System.String
Parameter Sets: Get
Aliases: DiagnosticsResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.ISelfHelpIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.Api202301Preview.IDiagnosticResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

`INPUTOBJECT <ISelfHelpIdentity>`: Identity Parameter

- `[DiagnosticsResourceName <String>]`: Unique resource name for insight resources
- `[Id <String>]`: Resource identity path
- `[Scope <String>]`: This is an extension resource provider and only resource level extension is supported at the moment.

## RELATED LINKS
