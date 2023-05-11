---
external help file:
Module Name: Az.SelfHelp
online version: https://learn.microsoft.com/powershell/module/az.selfhelp/new-azselfhelpdiagnostic
schema: 2.0.0
---

# New-AzSelfHelpDiagnostic

## SYNOPSIS

Diagnostics tells you precisely the root cause of the issue and how to address it.
You can get diagnostics once you discover and identify the relevant solution for your Azure issue.\<br/\>\<br/\> You can create diagnostics using the ‘solutionId’ from Solution Discovery API response and ‘additionalParameters’ \<br/\>\<br/\> \<b\>Note: \</b\>‘requiredParameterSets’ from Solutions Discovery API response must be passed via ‘additionalParameters’ as an input to Diagnostics API

## SYNTAX

```
New-AzSelfHelpDiagnostic -Scope <String> -SResourceName <String> [-GlobalParameter <Hashtable>]
 [-Insight <IDiagnosticInvocation[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION

Diagnostics tells you precisely the root cause of the issue and how to address it.
You can get diagnostics once you discover and identify the relevant solution for your Azure issue.\<br/\>\<br/\> You can create diagnostics using the ‘solutionId’ from Solution Discovery API response and ‘additionalParameters’ \<br/\>\<br/\> \<b\>Note: \</b\>‘requiredParameterSets’ from Solutions Discovery API response must be passed via ‘additionalParameters’ as an input to Diagnostics API

## EXAMPLES

### Example 1: Create Diagnostic for a KeyVault resource.

```powershell
$insightsToInvoke = [ordered]@{
                "solutionId" = "Demo2InsightV2"
            }
New-AzSelfHelpDiagnostic -Scope "/subscriptions/6bded6d5-a6af-43e1-96d3-bf71f6f5f8ba/resourceGroups/aravind-test-resources/providers/Microsoft.KeyVault/vaults/ab-tests-kv-an" -SResourceName ab-test-973 -Insight $insightsToInvoke
```

```output
Name        SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----        ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
ab-test-973                                                                                                                                                aravind-test-reso…
```

Creates a diagnostic for a KeyVault resource.

## PARAMETERS

### -AsJob

Run the command as a job

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

### -GlobalParameter

Global parameters that can be passed to all solutionIds.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Insight

SolutionIds that are needed to be invoked.
To construct, see NOTES section for INSIGHT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.Api202301Preview.IDiagnosticInvocation[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait

Run the command asynchronously

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

This is an extension resource provider and only resource level extension is supported at the moment.

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

### -SResourceName

Unique resource name for insight resources

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: DiagnosticsResourceName

Required: True
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

## OUTPUTS

### System.Boolean

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

`INSIGHT <IDiagnosticInvocation[]>`: SolutionIds that are needed to be invoked.

- `[AdditionalParameter <IDiagnosticInvocationAdditionalParameters>]`: Additional parameters required to invoke the solutionId.
  - `[(Any) <String>]`: This indicates any property can be added to this object.
- `[SolutionId <String>]`: Solution Id to invoke.

## RELATED LINKS
