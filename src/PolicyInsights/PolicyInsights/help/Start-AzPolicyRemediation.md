---
external help file: Az.PolicyInsights-help.xml
Module Name: Az.PolicyInsights
online version: https://learn.microsoft.com/powershell/module/az.policyinsights/start-azpolicyremediation
schema: 2.0.0
---

# Start-AzPolicyRemediation

## SYNOPSIS
Creates and starts a policy remediation for a policy assignment.

## SYNTAX

### CreateBySubscriptionId (Default)
```
Start-AzPolicyRemediation -Name <String> [-SubscriptionId <String>] -PolicyAssignmentId <String>
 [-FailureThresholdPercentage <Single>] [-FilterLocation <String[]>] [-FilterResourceId <String[]>]
 [-ParallelDeployment <Int32>] [-PolicyDefinitionReferenceId <String>] [-ResourceCount <Int32>]
 [-ResourceDiscoveryMode <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateByResourceGroup
```
Start-AzPolicyRemediation -Name <String> [-SubscriptionId <String>] -ResourceGroupName <String>
 -PolicyAssignmentId <String> [-FailureThresholdPercentage <Single>] [-FilterLocation <String[]>]
 [-FilterResourceId <String[]>] [-ParallelDeployment <Int32>] [-PolicyDefinitionReferenceId <String>]
 [-ResourceCount <Int32>] [-ResourceDiscoveryMode <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateByResourceId
```
Start-AzPolicyRemediation -Name <String> -ResourceId <String> -PolicyAssignmentId <String>
 [-FailureThresholdPercentage <Single>] [-FilterLocation <String[]>] [-FilterResourceId <String[]>]
 [-ParallelDeployment <Int32>] [-PolicyDefinitionReferenceId <String>] [-ResourceCount <Int32>]
 [-ResourceDiscoveryMode <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateByScope
```
Start-AzPolicyRemediation -Name <String> -PolicyAssignmentId <String> [-FailureThresholdPercentage <Single>]
 [-FilterLocation <String[]>] [-FilterResourceId <String[]>] [-ParallelDeployment <Int32>]
 [-PolicyDefinitionReferenceId <String>] [-ResourceCount <Int32>] [-ResourceDiscoveryMode <String>]
 -Scope <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### CreateByManagementGroup
```
Start-AzPolicyRemediation -Name <String> -ManagementGroupId <String> -PolicyAssignmentId <String>
 [-FailureThresholdPercentage <Single>] [-FilterLocation <String[]>] [-FilterResourceId <String[]>]
 [-ParallelDeployment <Int32>] [-PolicyDefinitionReferenceId <String>] [-ResourceCount <Int32>]
 [-ResourceDiscoveryMode <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentity
```
Start-AzPolicyRemediation -InputObject <IPolicyInsightsIdentity> -PolicyAssignmentId <String>
 [-FailureThresholdPercentage <Single>] [-FilterLocation <String[]>] [-FilterResourceId <String[]>]
 [-ParallelDeployment <Int32>] [-PolicyDefinitionReferenceId <String>] [-ResourceCount <Int32>]
 [-ResourceDiscoveryMode <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Start-AzPolicyRemediation** cmdlet creates a policy remediation for a particular policy assignment.

All non-compliant resources at or below the remediation's scope will be remediated.

This cmdlet can also be used to restart a previously created Remediation that is in a terminal state.

Remediation is only supported for policies with the 'deployIfNotExists' and 'modify' effect.

## EXAMPLES

### Example 1: Start a remediation at subscription scope
```powershell
$policyAssignmentId = "/subscriptions/f0710c27-9663-4c05-19f8-1b4be01e86a5/providers/Microsoft.Authorization/policyAssignments/2deae24764b447c29af7c309"
Start-AzPolicyRemediation -PolicyAssignmentId $policyAssignmentId -Name "remediation1" -NoWait
```

This command creates a new policy remediation in the current context's subscription for the provided policy assignment.
The cmdlet will return immediately after the remediation is created without waiting for the remediation to complete.

### Example 2: Start a remediation at management group scope with optional filters
```powershell
$policyAssignmentId = "/providers/Microsoft.Management/managementGroups/mg1/providers/Microsoft.Authorization/policyAssignments/pa1"
Start-AzPolicyRemediation -ManagementGroupId "mg1" -PolicyAssignmentId $policyAssignmentId -Name "remediation1" -FilterLocation "westus","eastus"
```

This command creates a new policy remediation in management group 'mg1' for the given policy assignment.
Only resources in the 'westus' or 'eastus' locations will be remediated.

### Example 3: Start a remediation at resource group scope for a policy set definition assignment
```powershell
$policyAssignmentId = "/subscriptions/f0710c27-9663-4c05-19f8-1b4be01e86a5/resourceGroups/myRG/providers/Microsoft.Authorization/policyAssignments/2deae24764b447c29af7c309"
Start-AzPolicyRemediation -ResourceGroupName "myRG" -PolicyAssignmentId $policyAssignmentId -PolicyDefinitionReferenceId "0349234412441" -Name "remediation1"
```

This command creates a new policy remediation in resource group 'myRG' for the given policy assignment.
The policy assignment assigns a policy set definition (also known as an initiative).
The policy definition reference ID indicates which policy within the initiative should be remediated.

### Example 4: Start a remediation and wait for it to complete in the background
```powershell
$policyAssignmentId = "/subscriptions/f0710c27-9663-4c05-19f8-1b4be01e86a5/providers/Microsoft.Authorization/policyAssignments/2deae24764b447c29af7c309"
$job = Start-AzPolicyRemediation -PolicyAssignmentId $policyAssignmentId -Name "remediation1" -AsJob
$job | Wait-Job
$remediation = $job | Receive-Job
```

This command starts a new policy remediation in the current context's subscription with the provided policy assignment.
It will wait for the remediation to complete before returning the final remediation status.

### Example 5: Start a remediation that will discover non-compliant resources before remediating
```powershell
$policyAssignmentId = "/subscriptions/f0710c27-9663-4c05-19f8-1b4be01e86a5/providers/Microsoft.Authorization/policyAssignments/2deae24764b447c29af7c309"
Start-AzPolicyRemediation -PolicyAssignmentId $policyAssignmentId -Name "remediation1" -ResourceDiscoveryMode ReEvaluateCompliance
```

This command creates a new policy remediation in  the current context's subscription with the provided policy assignment.
The compliance state of resources in the subscription will be re-evaluated against the policy assignment and non-compliant resources will be remediated.

### Example 6: Start a remediation that will remediate up to 10,000 non-compliant resources
```powershell
$policyAssignmentId = "/subscriptions/f0710c27-9663-4c05-19f8-1b4be01e86a5/providers/Microsoft.Authorization/policyAssignments/2deae24764b447c29af7c309"
Start-AzPolicyRemediation -PolicyAssignmentId $policyAssignmentId -Name "remediation1" -ResourceCount 10000
```

### Example 7: Start a remediation that will remediate 30 resources in parallel
```powershell
$policyAssignmentId = "/subscriptions/f0710c27-9663-4c05-19f8-1b4be01e86a5/providers/Microsoft.Authorization/policyAssignments/2deae24764b447c29af7c309"
Start-AzPolicyRemediation -PolicyAssignmentId $policyAssignmentId -Name "remediation1" -ParallelDeploymentCount 30
```

### Example 8: Start a remediation that will terminate if more than half of the remediation deployments fail
```powershell
$policyAssignmentId = "/subscriptions/f0710c27-9663-4c05-19f8-1b4be01e86a5/providers/Microsoft.Authorization/policyAssignments/2deae24764b447c29af7c309"
Start-AzPolicyRemediation -PolicyAssignmentId $policyAssignmentId -Name "remediation1" -FailureThreshold 0.5
```

## PARAMETERS

### -AsJob
Run cmdlet in the background.

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

### -FailureThresholdPercentage
A number between 0.0 to 1.0 representing the percentage failure threshold.
The remediation will fail if the percentage of failed remediation operations (i.e.
failed deployments) exceeds this threshold.

```yaml
Type: System.Single
Parameter Sets: (All)
Aliases: FailureThreshold

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FilterLocation
The resource locations that should be included in the remediation.

Resources that don't reside in these locations will not be remediated.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases: LocationFilter

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FilterResourceId
The IDs of the resources that will be remediated.
Can specify at most 100 IDs.
This filter cannot be used when ReEvaluateCompliance is set to ReEvaluateCompliance.
This filter cannot be empty if provided, or the remediation won't target any resources.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Models.IPolicyInsightsIdentity
Parameter Sets: CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ManagementGroupId
Management group ID.

```yaml
Type: System.String
Parameter Sets: CreateByManagementGroup
Aliases: ManagementGroupName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the remediation.

```yaml
Type: System.String
Parameter Sets: CreateBySubscriptionId, CreateByResourceGroup, CreateByResourceId, CreateByScope, CreateByManagementGroup
Aliases: RemediationName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously.

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

### -ParallelDeployment
Determines how many resources to remediate at any given time.
Can be used to increase or reduce the pace of the remediation.
If not provided, the default parallel deployments value is used.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases: ParallelDeploymentCount

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PolicyAssignmentId
The resource ID of the policy assignment that should be remediated.
E.g.
'/subscriptions/\{subscriptionId}/providers/Microsoft.Authorization/policyAssignments/\{assignmentName}'.

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

### -PolicyDefinitionReferenceId
The policy definition reference ID of the individual definition that should be remediated.
Required when the policy assignment being remediated assigns a policy set definition.

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

### -ResourceCount
Determines the max number of non-compliant resources that can be remediated by the remediation job.
If not provided, the default resource count is used.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceDiscoveryMode
Describes how the remediation task will discover resources that need to be remediated.
ReEvaluateCompliance is not supported when remediating management group scopes.
Defaults to ExistingNonCompliant if not specified.

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

### -ResourceGroupName
Resource group name.

```yaml
Type: System.String
Parameter Sets: CreateByResourceGroup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
ID of the resource that the remediation is being created for.

```yaml
Type: System.String
Parameter Sets: CreateByResourceId
Aliases: Id

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
Scope of the resource.
E.g.
'/subscriptions/\{subscriptionId}/resourceGroups/\{rgName}'.

```yaml
Type: System.String
Parameter Sets: CreateByScope
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
Uses current subscription if one isn't provided.

```yaml
Type: System.String
Parameter Sets: CreateBySubscriptionId, CreateByResourceGroup
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Models.IPolicyInsightsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Models.IRemediation

## NOTES

## RELATED LINKS
