---
external help file: Az.Security-help.xml
Module Name: Az.Security
online version: https://learn.microsoft.com/powershell/module/Az.Security/new-azsecurityconnectoractionableremediationobject
schema: 2.0.0
---

# New-AzSecurityConnectorActionableRemediationObject

## SYNOPSIS
Create an in-memory object for ActionableRemediation.

## SYNTAX

```
New-AzSecurityConnectorActionableRemediationObject [-BranchConfiguration <ITargetBranchConfiguration>]
 [-CategoryConfiguration <ICategoryConfiguration[]>] [-InheritFromParentState <String>] [-State <String>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ActionableRemediation.

## EXAMPLES

### Example 1: Create new ActionableRemediation object
```powershell
New-AzSecurityConnectorActionableRemediationObject -State Enabled -InheritFromParentState Disabled `
            -BranchConfiguration @{AnnotateDefaultBranch="Enabled"; branchName=@("main", "hotfix")} -CategoryConfiguration @( @{category="First"; minimumSeverityLevel="High"}, @{category="Second"; minimumSeverityLevel="Low"})
```

```output
BranchConfiguration    : {
                           "branchNames": [ "main", "hotfix" ],
                           "annotateDefaultBranch": "Enabled"
                         }
CategoryConfiguration  : {{
                           "minimumSeverityLevel": "High",
                           "category": "First"
                         }, {
                           "minimumSeverityLevel": "Low",
                           "category": "Second"
                         }}
InheritFromParentState : Disabled
State                  : Enabled
```

## PARAMETERS

### -BranchConfiguration
Repository branch configuration for PR Annotations.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Security.Models.ITargetBranchConfiguration
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CategoryConfiguration
Gets or sets list of categories and severity levels.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Security.Models.ICategoryConfiguration[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InheritFromParentState
Update Settings.

        Enabled - Resource should inherit configurations from parent.
        Disabled - Resource should not inherit configurations from parent.

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -State
ActionableRemediation Setting.
        None - the setting was never set.
        Enabled - ActionableRemediation is enabled.
        Disabled - ActionableRemediation is disabled.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Security.Models.ActionableRemediation

## NOTES

## RELATED LINKS
