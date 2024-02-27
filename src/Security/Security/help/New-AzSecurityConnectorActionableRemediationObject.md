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
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ActionableRemediation.

## EXAMPLES

### EXAMPLE 1
```
New-AzSecurityConnectorActionableRemediationObject -State Enabled -InheritFromParentState Disabled `
```

-BranchConfiguration @{AnnotateDefaultBranch="Enabled"; branchName=@("main", "hotfix")} -CategoryConfiguration @( @{category="First"; minimumSeverityLevel="High"}, @{category="Second"; minimumSeverityLevel="Low"})

## PARAMETERS

### -BranchConfiguration
Repository branch configuration for PR Annotations.
.

```yaml
Type: ITargetBranchConfiguration
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
.

```yaml
Type: ICategoryConfiguration[]
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
Type: String
Parameter Sets: (All)
Aliases:

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
Type: String
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
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

BRANCHCONFIGURATION \<ITargetBranchConfiguration\>: Repository branch configuration for PR Annotations.
  \[AnnotateDefaultBranch \<String\>\]: Configuration of PR Annotations on default branch. 
Enabled - PR Annotations are enabled on the resource's default branch. 
Disabled - PR Annotations are disabled on the resource's default branch.
  \[BranchName \<List\<String\>\>\]: Gets or sets branches that should have annotations.

CATEGORYCONFIGURATION \<ICategoryConfiguration\[\]\>: Gets or sets list of categories and severity levels.
  \[Category \<String\>\]: Rule categories. 
Code - code scanning results. 
Artifact scanning results. 
Dependencies scanning results. 
IaC results. 
Secrets scanning results. 
Container scanning results.
  \[MinimumSeverityLevel \<String\>\]: Gets or sets minimum severity level for a given category.

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/Az.Security/new-azsecurityconnectoractionableremediationobject](https://learn.microsoft.com/powershell/module/Az.Security/new-azsecurityconnectoractionableremediationobject)

