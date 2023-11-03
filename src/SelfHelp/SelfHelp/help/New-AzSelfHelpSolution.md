---
external help file:
Module Name: Az.SelfHelp
online version: https://learn.microsoft.com/powershell/module/az.selfhelp/new-azselfhelpsolution
schema: 2.0.0
---

# New-AzSelfHelpSolution

## SYNOPSIS
Creates a solution for the specific Azure resource or subscription using the triggering criteria ‘solutionId and requiredInputs’ from discovery solutions.\<br/\> Solutions are a rich, insightful and a centralized self help experience that brings all the relevant content to troubleshoot an Azure issue into a unified experience.
Solutions include the following components : Text, Diagnostics , Troubleshooters, Images , Video tutorials, Tables , custom charts, images , AzureKB, etc, with capabilities to support new solutions types in the future.
Each solution type may require one or more ‘requiredParameters’ that are required to execute the individual solution component.
In the absence of the ‘requiredParameters’ it is likely that some of the solutions might fail execution, and you might see an empty response.
\<br/\>\<br/\> \<b\>Note:\</b\>  \<br/\>1.
‘requiredInputs’ from Discovery solutions response must be passed via ‘parameters’ in the request body of Solutions API.
\<br/\>2.
‘requiredParameters’ from the Solutions response is the same as ‘ additionalParameters’ in the request for diagnostics \<br/\>3.
‘requiredParameters’ from the Solutions response is the same as ‘properties.parameters’ in the request for Troubleshooters

## SYNTAX

```
New-AzSelfHelpSolution -ResourceName <String> -Scope <String> [-Content <String>] [-Parameter <Hashtable>]
 [-ProvisioningState <SolutionProvisioningState>] [-ReplacementMapDiagnostic <ISolutionsDiagnostic[]>]
 [-ReplacementMapMetricsBasedChart <IMetricsBasedChart[]>]
 [-ReplacementMapTroubleshooter <ISolutionsTroubleshooters[]>] [-ReplacementMapVideo <IVideo[]>]
 [-ReplacementMapVideoGroup <IVideoGroup[]>] [-ReplacementMapWebResult <IWebResult[]>] [-Section <ISection[]>]
 [-SolutionId <String>] [-Title <String>] [-TriggerCriterion <ITriggerCriterion[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a solution for the specific Azure resource or subscription using the triggering criteria ‘solutionId and requiredInputs’ from discovery solutions.\<br/\> Solutions are a rich, insightful and a centralized self help experience that brings all the relevant content to troubleshoot an Azure issue into a unified experience.
Solutions include the following components : Text, Diagnostics , Troubleshooters, Images , Video tutorials, Tables , custom charts, images , AzureKB, etc, with capabilities to support new solutions types in the future.
Each solution type may require one or more ‘requiredParameters’ that are required to execute the individual solution component.
In the absence of the ‘requiredParameters’ it is likely that some of the solutions might fail execution, and you might see an empty response.
\<br/\>\<br/\> \<b\>Note:\</b\>  \<br/\>1.
‘requiredInputs’ from Discovery solutions response must be passed via ‘parameters’ in the request body of Solutions API.
\<br/\>2.
‘requiredParameters’ from the Solutions response is the same as ‘ additionalParameters’ in the request for diagnostics \<br/\>3.
‘requiredParameters’ from the Solutions response is the same as ‘properties.parameters’ in the request for Troubleshooters

## EXAMPLES

### Example 1: Create New SelfHelp Solution
```powershell
$criteria = [ordered]@{
    "name" ="SolutionId"
    "value" = "keyvault-lostdeletedkeys-apollo-solution"
}
$parameters = [ordered]@{
        "SearchText" = "Can not RDP"
        "vault_name" = "DemoKeyvault"
}
New-AzSelfHelpSolution -ResourceName test-resource -Scope  /subscriptions/<subid>/resourceGroups/testRG/providers/Microsoft.KeyVault/kv/testDB -Parameter $parameters -TriggerCriterion $criteria
```

```output
Location Name             ResourceGroupName
-------- ----             -----------------
         test-resource    testRg
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

### -Content
The HTML content that needs to be rendered and shown to customer.

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

### -ProvisioningState
Status of solution provisioning.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Support.SolutionProvisioningState
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReplacementMapDiagnostic
Solution diagnostics results.
To construct, see NOTES section for REPLACEMENTMAPDIAGNOSTIC properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.Api20230901Preview.ISolutionsDiagnostic[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReplacementMapMetricsBasedChart
Solution metrics based charts
To construct, see NOTES section for REPLACEMENTMAPMETRICSBASEDCHART properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.Api20230901Preview.IMetricsBasedChart[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReplacementMapTroubleshooter
Solutions Troubleshooters
To construct, see NOTES section for REPLACEMENTMAPTROUBLESHOOTER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.Api20230901Preview.ISolutionsTroubleshooters[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReplacementMapVideo
Video solutions, which have the power to engage the customer by stimulating their senses
To construct, see NOTES section for REPLACEMENTMAPVIDEO properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.Api20230901Preview.IVideo[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReplacementMapVideoGroup
Group of Videos
To construct, see NOTES section for REPLACEMENTMAPVIDEOGROUP properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.Api20230901Preview.IVideoGroup[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReplacementMapWebResult
Solution AzureKB results
To construct, see NOTES section for REPLACEMENTMAPWEBRESULT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.Api20230901Preview.IWebResult[]
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

### -Section
List of section object.
To construct, see NOTES section for SECTION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.Api20230901Preview.ISection[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SolutionId
Solution Id to identify single solution.

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

### -Title
The title.

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

### -TriggerCriterion
Solution request trigger criteria
To construct, see NOTES section for TRIGGERCRITERION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.Api20230901Preview.ITriggerCriterion[]
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

### Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.Api20230901Preview.ISolutionResource

## NOTES

## RELATED LINKS

