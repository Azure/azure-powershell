---
external help file:
Module Name: Az.SelfHelp
online version: https://learn.microsoft.com/powershell/module/az.selfhelp/invoke-azselfhelpcontinuetroubleshooter
schema: 2.0.0
---

# Invoke-AzSelfHelpContinueTroubleshooter

## SYNOPSIS
Uses ‘stepId’ and ‘responses’ as the trigger to continue the troubleshooting steps for the respective troubleshooter resource name.
\<br/\>Continue API is used to provide inputs that are required for the specific troubleshooter to progress into the next step in the process.
This API is used after the Troubleshooter has been created using the Create API.

## SYNTAX

### ContinueExpanded (Default)
```
Invoke-AzSelfHelpContinueTroubleshooter -Scope <String> -TroubleshooterName <String>
 [-Response <ITroubleshooterResponse[]>] [-StepId <String>] [-DefaultProfile <PSObject>] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Continue
```
Invoke-AzSelfHelpContinueTroubleshooter -Scope <String> -TroubleshooterName <String>
 -ContinueRequestBody <IContinueRequestBody> [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ContinueViaIdentity
```
Invoke-AzSelfHelpContinueTroubleshooter -InputObject <ISelfHelpIdentity>
 -ContinueRequestBody <IContinueRequestBody> [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ContinueViaIdentityExpanded
```
Invoke-AzSelfHelpContinueTroubleshooter -InputObject <ISelfHelpIdentity>
 [-Response <ITroubleshooterResponse[]>] [-StepId <String>] [-DefaultProfile <PSObject>] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Uses ‘stepId’ and ‘responses’ as the trigger to continue the troubleshooting steps for the respective troubleshooter resource name.
\<br/\>Continue API is used to provide inputs that are required for the specific troubleshooter to progress into the next step in the process.
This API is used after the Troubleshooter has been created using the Create API.

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

### -ContinueRequestBody
Troubleshooter ContinueRequest body.
To construct, see NOTES section for CONTINUEREQUESTBODY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.Api20230901Preview.IContinueRequestBody
Parameter Sets: Continue, ContinueViaIdentity
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
Parameter Sets: ContinueViaIdentity, ContinueViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -Response
.
To construct, see NOTES section for RESPONSE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.Api20230901Preview.ITroubleshooterResponse[]
Parameter Sets: ContinueExpanded, ContinueViaIdentityExpanded
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
Parameter Sets: Continue, ContinueExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StepId
Unique id of the result.

```yaml
Type: System.String
Parameter Sets: ContinueExpanded, ContinueViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TroubleshooterName
Troubleshooter resource Name.

```yaml
Type: System.String
Parameter Sets: Continue, ContinueExpanded
Aliases:

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

### Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.Api20230901Preview.IContinueRequestBody

### Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.ISelfHelpIdentity

## OUTPUTS

### System.Boolean

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`CONTINUEREQUESTBODY <IContinueRequestBody>`: Troubleshooter ContinueRequest body.
  - `[Response <ITroubleshooterResponse[]>]`: 
    - `[QuestionId <String>]`: id of the question.
    - `[QuestionType <QuestionType?>]`: Text Input. Will be a single line input.
    - `[Response <String>]`: Response key for SingleInput. For Multi-line test/open ended question it is free form text
  - `[StepId <String>]`: Unique id of the result.

`INPUTOBJECT <ISelfHelpIdentity>`: Identity Parameter
  - `[DiagnosticsResourceName <String>]`: Unique resource name for insight resources
  - `[Id <String>]`: Resource identity path
  - `[Scope <String>]`: This is an extension resource provider and only resource level extension is supported at the moment.
  - `[SolutionResourceName <String>]`: Solution resource Name.
  - `[TroubleshooterName <String>]`: Troubleshooter resource Name.

`RESPONSE <ITroubleshooterResponse[]>`: .
  - `[QuestionId <String>]`: id of the question.
  - `[QuestionType <QuestionType?>]`: Text Input. Will be a single line input.
  - `[Response <String>]`: Response key for SingleInput. For Multi-line test/open ended question it is free form text

## RELATED LINKS

