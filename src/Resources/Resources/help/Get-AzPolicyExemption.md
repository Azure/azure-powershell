---
external help file: Az.Resources-help.xml
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/get-azpolicyexemption
schema: 2.0.0
---

# Get-AzPolicyExemption

## SYNOPSIS
Gets policy exemptions.

## SYNTAX

### Name (Default)
```
Get-AzPolicyExemption [-Name <String>] [-Scope <String>] [-PolicyAssignmentIdFilter <String>]
 [-Filter <String>] [-BackwardCompatible] [-DefaultProfile <PSObject>] [-Break]
 [-HttpPipelineAppend <SendAsyncStep[]>] [-HttpPipelinePrepend <SendAsyncStep[]>] [-Proxy <Uri>]
 [-ProxyCredential <PSCredential>] [-ProxyUseDefaultCredentials] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### IncludeDescendent
```
Get-AzPolicyExemption [-Scope <String>] [-IncludeDescendent] [-Filter <String>] [-BackwardCompatible]
 [-DefaultProfile <PSObject>] [-Break] [-HttpPipelineAppend <SendAsyncStep[]>]
 [-HttpPipelinePrepend <SendAsyncStep[]>] [-Proxy <Uri>] [-ProxyCredential <PSCredential>]
 [-ProxyUseDefaultCredentials] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Id
```
Get-AzPolicyExemption [-PolicyAssignmentIdFilter <String>] -Id <String> [-Filter <String>]
 [-BackwardCompatible] [-DefaultProfile <PSObject>] [-Break] [-HttpPipelineAppend <SendAsyncStep[]>]
 [-HttpPipelinePrepend <SendAsyncStep[]>] [-Proxy <Uri>] [-ProxyCredential <PSCredential>]
 [-ProxyUseDefaultCredentials] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzPolicyExemption** cmdlet gets a collection of policy exemptions or a specific policy exemption identified by name or ID.

## EXAMPLES

### Example 1 Get all policy exemptions
```powershell
Get-AzPolicyExemption
```

This command gets all the policy exemptions in the current subscription.
If you need to list all the exemptions related to the given scope, including those from ancestor scopes and those from descendent scopes you need to pass the `-IncludeDescendent` parameter.

### Example 2: Get a specific policy exemption
```powershell
$ResourceGroup = Get-AzResourceGroup -Name 'ResourceGroup11'
Get-AzPolicyExemption -Name 'PolicyExemption07' -Scope $ResourceGroup.ResourceId
```

The first command gets a resource group named ResourceGroup11 by using the Get-AzResourceGroup cmdlet and stores it in the $ResourceGroup variable.
The second command gets the policy exemption named PolicyExemption07 for the scope that the **ResourceId** property of $ResourceGroup identifies.

### Example 3: Get all policy exemptions associated with a policy assignment
```powershell
$Assignment = Get-AzPolicyAssignment -Name 'PolicyAssignment07'
Get-AzPolicyExemption -PolicyAssignmentIdFilter $Assignment.ResourceId
```

The first command gets a policy assignment named PolicyAssignment07.
The second command gets all of the policy exemptions that are assigned with the policy assignment.

## PARAMETERS

### -BackwardCompatible
Causes cmdlet to return artifacts using legacy format placing policy-specific properties in a property bag object.

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

### -Break
Wait for .NET debugger to attach

```yaml
Type: System.Management.Automation.SwitchParameter
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
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Filter
The filter to apply on the operation.
Valid values for $filter are: 'atScope()', 'atExactScope()', 'excludeExpired()' or 'policyAssignmentId eq '{value}''.
If $filter is not provided, no filtering is performed.
If $filter is not provided, the unfiltered list includes all policy exemptions associated with the scope, including those that apply directly or apply from containing scopes.
If $filter=atScope() is provided, the returned list only includes all policy exemptions that apply to the scope, which is everything in the unfiltered list except those applied to sub scopes contained within the given scope.
If $filter=atExactScope() is provided, the returned list only includes all policy exemptions that at the given scope.
If $filter=excludeExpired() is provided, the returned list only includes all policy exemptions that either haven't expired or didn't set expiration date.
If $filter=policyAssignmentId eq '{value}' is provided.
the returned list only includes all policy exemptions that are associated with the give policyAssignmentId.

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

### -HttpPipelineAppend
SendAsync Pipeline Steps to be appended to the front of the pipeline

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.SendAsyncStep[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HttpPipelinePrepend
SendAsync Pipeline Steps to be prepended to the front of the pipeline

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.SendAsyncStep[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
The fully qualified resource Id of the exemption.

```yaml
Type: System.String
Parameter Sets: Id
Aliases: ResourceId

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -IncludeDescendent
Causes the list of returned policy exemptions to include all exemptions related to the given scope, including those from ancestor scopes and those from descendent scopes.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: IncludeDescendent
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
The name of the policy exemption.

```yaml
Type: System.String
Parameter Sets: Name
Aliases: PolicyExemptionName

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PolicyAssignmentIdFilter
The policy assignment id filter.

```yaml
Type: System.String
Parameter Sets: Name, Id
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### -Proxy
The URI for the proxy server to use

```yaml
Type: System.Uri
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProxyCredential
Credentials for a proxy server to use for the remote call

```yaml
Type: System.Management.Automation.PSCredential
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProxyUseDefaultCredentials
Use the default credentials for the proxy

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
The scope of the policy exemption.
Valid scopes are: management group (format: '/providers/Microsoft.Management/managementGroups/{managementGroup}'), subscription (format: '/subscriptions/{subscriptionId}'), resource group (format: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}', or resource (format: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/[{parentResourcePath}/]{resourceType}/{resourceName}'

```yaml
Type: System.String
Parameter Sets: Name, IncludeDescendent
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Management.Automation.SwitchParameter

### System.String

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyExemption

## NOTES

## RELATED LINKS
