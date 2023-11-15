---
external help file:
Module Name: Az.SelfHelp
online version: https://learn.microsoft.com/powershell/module/az.selfhelp/update-azselfhelpsolution
schema: 2.0.0
---

# Update-AzSelfHelpSolution

## SYNOPSIS
Update the requiredInputs or additional information needed to execute the solution

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzSelfHelpSolution -ResourceName <String> -Scope <String> [-Content <String>] [-Parameter <Hashtable>]
 [-ProvisioningState <SolutionProvisioningState>] [-ReplacementMapDiagnostic <ISolutionsDiagnostic[]>]
 [-ReplacementMapMetricsBasedChart <IMetricsBasedChart[]>]
 [-ReplacementMapTroubleshooter <ISolutionsTroubleshooters[]>] [-ReplacementMapVideo <IVideo[]>]
 [-ReplacementMapVideoGroup <IVideoGroup[]>] [-ReplacementMapWebResult <IWebResult[]>] [-Section <ISection[]>]
 [-SolutionId <String>] [-Title <String>] [-TriggerCriterion <ITriggerCriterion[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzSelfHelpSolution -InputObject <ISelfHelpIdentity> [-Content <String>] [-Parameter <Hashtable>]
 [-ProvisioningState <SolutionProvisioningState>] [-ReplacementMapDiagnostic <ISolutionsDiagnostic[]>]
 [-ReplacementMapMetricsBasedChart <IMetricsBasedChart[]>]
 [-ReplacementMapTroubleshooter <ISolutionsTroubleshooters[]>] [-ReplacementMapVideo <IVideo[]>]
 [-ReplacementMapVideoGroup <IVideoGroup[]>] [-ReplacementMapWebResult <IWebResult[]>] [-Section <ISection[]>]
 [-SolutionId <String>] [-Title <String>] [-TriggerCriterion <ITriggerCriterion[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update the requiredInputs or additional information needed to execute the solution

## EXAMPLES

### Example 1: Update the Solution Resource
```powershell
$parameters = [ordered]@{ 
        "SearchText" = "Can not RDP" 
        "vault_name" = "DemoKeyvault" 
} 
$criteria = [ordered]@{ 
    "name" =" ReplacementKey" 
    "value" = "<!--85c7bc9e-4405-4e3a-82b0-8c4edc29a04d-->" 
} 
Update-AzSelfHelpSolution -ResourceName test-resource -Scope  /subscriptions/6bded6d5-a6af-43e1-96d3-bf71f6f5f8ba/resourceGroups/DiagnosticsRp-Ev2AssistId-Public-Dev/providers/Microsoft.KeyVault/vaults/DiagRp-Ev2PublicDev -Parameter $parameters -TriggerCriterion $criteria 
```

```output
Location Name             ResourceGroupName
-------- ----             -----------------
         test-resource    testRg
```

Updates the requiredInputs or additional information needed to execute the solution

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.ISelfHelpIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.ISelfHelpIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.Api20230901Preview.ISolutionResource

## NOTES

## RELATED LINKS

