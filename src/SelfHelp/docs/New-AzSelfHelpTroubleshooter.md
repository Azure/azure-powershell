---
external help file:
Module Name: Az.SelfHelp
online version: https://learn.microsoft.com/powershell/module/az.selfhelp/new-azselfhelptroubleshooter
schema: 2.0.0
---

# New-AzSelfHelpTroubleshooter

## SYNOPSIS
Creates the specific troubleshooter action under a resource or subscription using the ‘solutionId’ and  ‘properties.parameters’ as the trigger.
\<br/\> Troubleshooters are step-by-step interactive guidance that scope the problem by collecting additional inputs from you in each stage while troubleshooting an Azure issue.
You will be guided down decision tree style workflow and the best possible solution will be presented at the end of the workflow.
\<br/\> Create API creates the Troubleshooter API using ‘parameters’ and ‘solutionId’ \<br/\> After creating the Troubleshooter instance, the following APIs can be used:\<br/\> CONTINUE API: to move to the next step in the flow \<br/\>GET API: to identify the next step after executing the CONTINUE API.
 \<br/\>\<br/\> \<b\>Note:\</b\> ‘requiredParameters’ from solutions response must be passed via ‘properties.
parameters’ in the request body of Troubleshooters API.

## SYNTAX

```
New-AzSelfHelpTroubleshooter -Name <String> -Scope <String> [-Parameter <Hashtable>] [-SolutionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates the specific troubleshooter action under a resource or subscription using the ‘solutionId’ and  ‘properties.parameters’ as the trigger.
\<br/\> Troubleshooters are step-by-step interactive guidance that scope the problem by collecting additional inputs from you in each stage while troubleshooting an Azure issue.
You will be guided down decision tree style workflow and the best possible solution will be presented at the end of the workflow.
\<br/\> Create API creates the Troubleshooter API using ‘parameters’ and ‘solutionId’ \<br/\> After creating the Troubleshooter instance, the following APIs can be used:\<br/\> CONTINUE API: to move to the next step in the flow \<br/\>GET API: to identify the next step after executing the CONTINUE API.
 \<br/\>\<br/\> \<b\>Note:\</b\> ‘requiredParameters’ from solutions response must be passed via ‘properties.
parameters’ in the request body of Troubleshooters API.

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

### -Name
Troubleshooter resource Name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: TroubleshooterName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
Client input parameters to run Troubleshooter Resource

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

### -SolutionId
Solution Id to identify single troubleshooter.

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

### Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.Api20230901Preview.ITroubleshooterResource

## NOTES

ALIASES

## RELATED LINKS

