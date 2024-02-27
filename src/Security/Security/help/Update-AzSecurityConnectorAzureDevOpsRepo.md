---
external help file: Az.Security-help.xml
Module Name: Az.security
online version: https://learn.microsoft.com/powershell/module/az.security/update-azsecurityconnectorazuredevopsrepo
schema: 2.0.0
---

# Update-AzSecurityConnectorAzureDevOpsRepo

## SYNOPSIS
Updates a monitored Azure DevOps repository resource.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzSecurityConnectorAzureDevOpsRepo -OrgName <String> -ProjectName <String> -RepoName <String>
 -ResourceGroupName <String> -SecurityConnectorName <String> [-SubscriptionId <String>]
 [-ActionableRemediation <IActionableRemediation>] [-ParentOrgName <String>] [-ParentProjectName <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzSecurityConnectorAzureDevOpsRepo -InputObject <ISecurityIdentity>
 [-ActionableRemediation <IActionableRemediation>] [-ParentOrgName <String>] [-ParentProjectName <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Updates a monitored Azure DevOps repository resource.

## EXAMPLES

### EXAMPLE 1
```
$config = New-AzSecurityConnectorActionableRemediationObject -State Enabled -InheritFromParentState Disabled -CategoryConfiguration @( @{category="IaC"; minimumSeverityLevel="Low"} )
```

Update-AzSecurityConnectorAzureDevOpsRepo -ResourceGroupName "securityConnectors-pwsh-tmp" -SecurityConnectorName "ado-sdk-pwsh-test03" -OrgName "org1" -ProjectName "Build" -RepoName "Build" -ActionableRemediation $config

## PARAMETERS

### -ActionableRemediation
Configuration payload for PR Annotations.
.

```yaml
Type: IActionableRemediation
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJob
Run the command as a job

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: PSObject
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
.

```yaml
Type: ISecurityIdentity
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
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -OrgName
The Azure DevOps organization name.

```yaml
Type: String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ParentOrgName
Gets or sets parent Azure DevOps Organization name.

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

### -ParentProjectName
Gets or sets parent Azure DevOps Project name.

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

### -ProjectName
The project name.

```yaml
Type: String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RepoName
The repository name.

```yaml
Type: String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecurityConnectorName
The security connector name.

```yaml
Type: String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Azure subscription ID

```yaml
Type: String
Parameter Sets: UpdateExpanded
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
Type: SwitchParameter
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
Type: SwitchParameter
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

### Microsoft.Azure.PowerShell.Cmdlets.Security.Models.ISecurityIdentity
## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Security.Models.IAzureDevOpsRepository
## NOTES
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

ACTIONABLEREMEDIATION \<IActionableRemediation\>: Configuration payload for PR Annotations.
  \[BranchConfiguration \<ITargetBranchConfiguration\>\]: Repository branch configuration for PR Annotations.
    \[AnnotateDefaultBranch \<String\>\]: Configuration of PR Annotations on default branch. 
Enabled - PR Annotations are enabled on the resource's default branch. 
Disabled - PR Annotations are disabled on the resource's default branch.
    \[BranchName \<List\<String\>\>\]: Gets or sets branches that should have annotations.
  \[CategoryConfiguration \<List\<ICategoryConfiguration\>\>\]: Gets or sets list of categories and severity levels.
    \[Category \<String\>\]: Rule categories. 
Code - code scanning results. 
Artifact scanning results. 
Dependencies scanning results. 
IaC results. 
Secrets scanning results. 
Container scanning results.
    \[MinimumSeverityLevel \<String\>\]: Gets or sets minimum severity level for a given category.
  \[InheritFromParentState \<String\>\]: Update Settings. 
Enabled - Resource should inherit configurations from parent. 
Disabled - Resource should not inherit configurations from parent.
  \[State \<String\>\]: ActionableRemediation Setting. 
None - the setting was never set. 
Enabled - ActionableRemediation is enabled. 
Disabled - ActionableRemediation is disabled.

INPUTOBJECT \<ISecurityIdentity\>: Identity Parameter
  \[ApiId \<String\>\]: API revision identifier.
Must be unique in the API Management service instance.
Non-current revision has ;rev=n as a suffix where n is the revision number.
  \[GroupFqName \<String\>\]: The GitLab group fully-qualified name.
  \[Id \<String\>\]: Resource identity path
  \[OperationResultId \<String\>\]: The operation result Id.
  \[OrgName \<String\>\]: The Azure DevOps organization name.
  \[OwnerName \<String\>\]: The GitHub owner name.
  \[ProjectName \<String\>\]: The project name.
  \[RepoName \<String\>\]: The repository name.
  \[ResourceGroupName \<String\>\]: The name of the resource group within the user's subscription.
The name is case insensitive.
  \[SecurityConnectorName \<String\>\]: The security connector name.
  \[ServiceName \<String\>\]: The name of the API Management service.
  \[SubscriptionId \<String\>\]: Azure subscription ID

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.security/update-azsecurityconnectorazuredevopsrepo](https://learn.microsoft.com/powershell/module/az.security/update-azsecurityconnectorazuredevopsrepo)

