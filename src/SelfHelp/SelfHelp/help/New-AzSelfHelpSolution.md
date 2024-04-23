---
external help file: Az.SelfHelp-help.xml
Module Name: Az.SelfHelp
online version: https://learn.microsoft.com/powershell/module/az.selfhelp/new-azselfhelpsolution
schema: 2.0.0
---

# New-AzSelfHelpSolution

## SYNOPSIS
Creates a solution for the specific Azure resource or subscription using the inputs 'solutionId and requiredInputs' from discovery solutions.
\<br/\> Azure solutions comprise a comprehensive library of self-help resources that have been thoughtfully curated by Azure engineers to aid customers in resolving typical troubleshooting issues.
These solutions encompass (1.) dynamic and context-aware diagnostics, guided troubleshooting wizards, and data visualizations, (2.) rich instructional video tutorials and illustrative diagrams and images, and (3.) thoughtfully assembled textual troubleshooting instructions.
All these components are seamlessly converged into unified solutions tailored to address a specific support problem area.
Each solution type may require one or more 'requiredParameters' that are required to execute the individual solution component.
In the absence of the 'requiredParameters' it is likely that some of the solutions might fail execution, and you might see an empty response.
\<br/\>\<br/\> \<b\>Note:\</b\>  \<br/\>1.
'requiredInputs' from Discovery solutions response must be passed via 'parameters' in the request body of Solutions API.
\<br/\>2.
'requiredParameters' from the Solutions response is the same as ' additionalParameters' in the request for diagnostics \<br/\>3.
'requiredParameters' from the Solutions response is the same as 'properties.parameters' in the request for Troubleshooters

## SYNTAX

```
New-AzSelfHelpSolution -ResourceName <String> -Scope <String> [-Parameter <Hashtable>]
 [-TriggerCriterion <ITriggerCriterion[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates a solution for the specific Azure resource or subscription using the inputs 'solutionId and requiredInputs' from discovery solutions.
\<br/\> Azure solutions comprise a comprehensive library of self-help resources that have been thoughtfully curated by Azure engineers to aid customers in resolving typical troubleshooting issues.
These solutions encompass (1.) dynamic and context-aware diagnostics, guided troubleshooting wizards, and data visualizations, (2.) rich instructional video tutorials and illustrative diagrams and images, and (3.) thoughtfully assembled textual troubleshooting instructions.
All these components are seamlessly converged into unified solutions tailored to address a specific support problem area.
Each solution type may require one or more 'requiredParameters' that are required to execute the individual solution component.
In the absence of the 'requiredParameters' it is likely that some of the solutions might fail execution, and you might see an empty response.
\<br/\>\<br/\> \<b\>Note:\</b\>  \<br/\>1.
'requiredInputs' from Discovery solutions response must be passed via 'parameters' in the request body of Solutions API.
\<br/\>2.
'requiredParameters' from the Solutions response is the same as ' additionalParameters' in the request for diagnostics \<br/\>3.
'requiredParameters' from the Solutions response is the same as 'properties.parameters' in the request for Troubleshooters

## EXAMPLES

### Example 1: Create New SelfHelp Solution
```powershell
$criteria = [ordered]@{ 
    "name" ="SolutionId" 
    "value" = "apollo-cognitve-search-custom-skill" 
} 

$parameters = [ordered]@{ 
        "SearchText" = "Can not Search" 
} 

New-AzSelfHelpSolution -ResourceName test-resource234 -Scope  /subscriptions/6bded6d5-a6af-43e1-96d3-bf71f6f5f8ba/resourceGroups/DiagnosticsRp-Ev2AssistId-Public-Dev/providers/Microsoft.KeyVault/vaults/DiagRp-Ev2PublicDev -Parameter $parameters -TriggerCriterion $criteria
```

```output
Location Name               ResourceGroupName
-------- ----               -----------------
        test-resource234    DiagnosticsRp-Ev2AssistId-Public-Dev
```

Creates a SelfHelp Solution for a resource.

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

### -Parameter
Client input parameters to run Solution

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

### -ResourceName
Solution resource Name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: SolutionResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
scope = resourceUri of affected resource.\<br/\> For example: /subscriptions/0d0fcd2e-c4fd-4349-8497-200edb3923c6/resourcegroups/myresourceGroup/providers/Microsoft.KeyVault/vaults/test-keyvault-non-read

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

### -TriggerCriterion
Solution request trigger criteria
To construct, see NOTES section for TRIGGERCRITERION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.Api20240301Preview.ITriggerCriterion[]
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

### Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.Api20240301Preview.ISolutionResource

## NOTES

## RELATED LINKS
