---
external help file: Az.Resources-help.xml
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/new-azpolicyassignment
schema: 2.0.0
---

# New-AzPolicyAssignment

## SYNOPSIS
Creates or updates a policy assignment.

## SYNTAX

### Default (Default)
```
New-AzPolicyAssignment -Name <String> [-Scope <String>] [-NotScope <String[]>] [-DisplayName <String>]
 [-Description <String>] [-Metadata <String>] [-EnforcementMode <String>] [-IdentityType <String>]
 [-IdentityId <String>] [-Location <String>] [-NonComplianceMessage <PSObject[]>] [-Override <IOverride[]>]
 [-ResourceSelector <IResourceSelector[]>] [-BackwardCompatible] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ParameterObject
```
New-AzPolicyAssignment -Name <String> [-Scope <String>] [-NotScope <String[]>] [-DisplayName <String>]
 [-Description <String>] [-Metadata <String>] [-EnforcementMode <String>] [-IdentityType <String>]
 [-IdentityId <String>] [-Location <String>] [-NonComplianceMessage <PSObject[]>] [-Override <IOverride[]>]
 [-ResourceSelector <IResourceSelector[]>] [-BackwardCompatible] [-PolicyDefinition <PSObject>]
 [-DefinitionVersion <String>] -PolicyParameterObject <Hashtable> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ParameterString
```
New-AzPolicyAssignment -Name <String> [-Scope <String>] [-NotScope <String[]>] [-DisplayName <String>]
 [-Description <String>] [-Metadata <String>] [-EnforcementMode <String>] [-IdentityType <String>]
 [-IdentityId <String>] [-Location <String>] [-NonComplianceMessage <PSObject[]>] [-Override <IOverride[]>]
 [-ResourceSelector <IResourceSelector[]>] [-BackwardCompatible] [-PolicyDefinition <PSObject>]
 [-DefinitionVersion <String>] -PolicyParameter <String> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### PolicyDefinitionOrPolicySetDefinition
```
New-AzPolicyAssignment -Name <String> [-Scope <String>] [-NotScope <String[]>] [-DisplayName <String>]
 [-Description <String>] [-Metadata <String>] [-EnforcementMode <String>] [-IdentityType <String>]
 [-IdentityId <String>] [-Location <String>] [-NonComplianceMessage <PSObject[]>] [-Override <IOverride[]>]
 [-ResourceSelector <IResourceSelector[]>] [-BackwardCompatible] -PolicyDefinition <PSObject>
 [-DefinitionVersion <String>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzPolicyAssignment** cmdlet creates or updates a policy assignment with the given scope and name.
Policy assignments apply to all resources contained within their scope.
For example, when you assign a policy at resource group scope, that policy applies to all resources in the group.

## EXAMPLES

### Example 1: Policy assignment at subscription level
```powershell
$Subscription = Get-AzSubscription -SubscriptionName 'Subscription01'
$Policy = Get-AzPolicyDefinition -Name 'VirtualMachinePolicy'
New-AzPolicyAssignment -Name 'VirtualMachinePolicyAssignment' -PolicyDefinition $Policy -Scope "/subscriptions/$($Subscription.Id)"
```

The first command gets a subscription named Subscription01 by using the Get-AzSubscription cmdlet and stores it in the $Subscription variable.
The second command gets the policy definition named VirtualMachinePolicy by using the Get-AzPolicyDefinition cmdlet and stores it in the $Policy variable.
The final command assigns the policy in $Policy at the level of the subscription identified by the subscription scope string.

### Example 2: Policy assignment at resource group level
```powershell
$ResourceGroup = Get-AzResourceGroup -Name 'ResourceGroup11'
$Policy = Get-AzPolicyDefinition -Name 'VirtualMachinePolicy'
New-AzPolicyAssignment -Name 'VirtualMachinePolicyAssignment' -PolicyDefinition $Policy -Scope $ResourceGroup.ResourceId
```

The first command gets a resource group named ResourceGroup11 by using the Get-AzResourceGroup cmdlet and stores it in the $ResourceGroup variable.
The second command gets the policy definition named VirtualMachinePolicy by using the Get-AzPolicyDefinition cmdlet and stores it in the $Policy variable.
The final command assigns the policy in $Policy at the level of the resource group identified by the **ResourceId** property of $ResourceGroup.

### Example 3: Policy assignment at resource group level with policy parameter object
```powershell
$ResourceGroup = Get-AzResourceGroup -Name 'ResourceGroup11'
$Policy = Get-AzPolicyDefinition -BuiltIn | Where-Object {$_.DisplayName -eq 'Allowed locations'}
$Locations = Get-AzLocation | Where-Object displayname -like '*east*'
$AllowedLocations = @{'listOfAllowedLocations'=($Locations.location)}
New-AzPolicyAssignment -Name 'RestrictLocationPolicyAssignment' -PolicyDefinition $Policy -Scope $ResourceGroup.ResourceId -PolicyParameterObject $AllowedLocations
```

The first command gets a resource group named ResourceGroup11 by using the Get-AzResourceGroup cmdlet.
The command stores that object in the $ResourceGroup variable.
The second command gets the built-in policy definition for allowed locations by using the Get-AzPolicyDefinition cmdlet.
The command stores that object in the $Policy variable.
The third and fourth commands create an object containing all Azure regions with "east" in the name.
The commands store that object in the $AllowedLocations variable.
The final command assigns the policy in $Policy at the level of a resource group using the policy parameter object in $AllowedLocations.
The **ResourceId** property of $ResourceGroup identifies the resource group.

### Example 4: Policy assignment at resource group level with policy parameter file
```powershell
'{
    "listOfAllowedLocations":  {
      "value": [
        "westus",
        "westeurope",
        "japanwest"
      ]
    }
}' > .\AllowedLocations.json

$ResourceGroup = Get-AzResourceGroup -Name 'ResourceGroup11'
$Policy = Get-AzPolicyDefinition -BuiltIn | Where-Object {$_.DisplayName -eq 'Allowed locations'}
New-AzPolicyAssignment -Name 'RestrictLocationPolicyAssignment' -PolicyDefinition $Policy -Scope $ResourceGroup.ResourceId -PolicyParameter .\AllowedLocations.json
```

The first command creates a parameter file called _AllowedLocations.json_ in the local working directory.
The second command gets a resource group named ResourceGroup11 by using the Get-AzResourceGroup cmdlet and stores it in the $ResourceGroup variable.
The third command gets the built-in policy definition for allowed locations by using the Get-AzPolicyDefinition cmdlet and stores it in the $Policy variable.
The final command assigns the policy in $Policy at the resource group identified by the **ResourceId** property of $ResourceGroup using the policy parameter file AllowedLocations.json from the local working directory.

### Example 5: Policy assignment with a system assigned managed identity
```powershell
$ResourceGroup = Get-AzResourceGroup -Name 'ResourceGroup11'
$Policy = Get-AzPolicyDefinition -Name 'VirtualMachinePolicy'
New-AzPolicyAssignment -Name 'VirtualMachinePolicyAssignment' -PolicyDefinition $Policy -Scope $ResourceGroup.ResourceId -Location 'eastus' -IdentityType 'SystemAssigned'
```

The first command gets a resource group named ResourceGroup11 by using the Get-AzResourceGroup cmdlet and stores it in the $ResourceGroup variable.
The second command gets the policy definition named VirtualMachinePolicy by using the Get-AzPolicyDefinition cmdlet and stores it in the $Policy variable.
The final command assigns the policy in $Policy to the resource group.
A system assigned managed identity is automatically created and assigned to the policy assignment.

### Example 6: Policy assignment with a user assigned managed identity
```powershell
$ResourceGroup = Get-AzResourceGroup -Name 'ResourceGroup11'
$Policy = Get-AzPolicyDefinition -Name 'VirtualMachinePolicy'
$UserAssignedIdentity = Get-AzUserAssignedIdentity -ResourceGroupName 'ResourceGroup1' -Name 'UserAssignedIdentity1'
New-AzPolicyAssignment -Name 'VirtualMachinePolicyAssignment' -PolicyDefinition $Policy -Scope $ResourceGroup.ResourceId -Location 'eastus' -IdentityType 'UserAssigned' -IdentityId $UserAssignedIdentity.Id
```

The first command gets a resource group named ResourceGroup11 by using the Get-AzResourceGroup cmdlet and stores it in the $ResourceGroup variable.
The second command gets the policy definition named VirtualMachinePolicy by using the Get-AzPolicyDefinition cmdlet and stores it in the $Policy variable.
The third command gets the user assigned managed identity named UserAssignedIdentity1 by using the Get-AzUserAssignedIdentity cmdlet and stores it in the $UserAssignedIdentity variable.
The final command assigns the policy in $Policy to the resource group.
The user assigned managed identity identified by the **Id** property of $UserAssignedIdentity is assigned to the policy assignment by passing the **Id*** property to the IdentityId parameter.

### Example 7: Policy assignment with an enforcement mode property
```powershell
$Subscription = Get-AzSubscription -SubscriptionName 'Subscription01'
$Policy = Get-AzPolicyDefinition -Name 'VirtualMachinePolicy'
New-AzPolicyAssignment -Name 'VirtualMachinePolicyAssignment' -PolicyDefinition $Policy -Scope "/subscriptions/$($Subscription.Id)" -EnforcementMode DoNotEnforce
```

The first command gets a subscription named Subscription01 by using the Get-AzSubscription cmdlet and stores it in the $Subscription variable.
The second command gets the policy definition named VirtualMachinePolicy by using the Get-AzPolicyDefinition cmdlet and stores it in the $Policy variable.
The final command assigns the policy in $Policy at the level of the subscription identified by the subscription scope string.

The assignment is set with an EnforcementMode value of _DoNotEnforce_ i.e.
the policy effect is not enforced during resource creation or update.

### Example 8: Policy assignment with non-compliance messages
```powershell
$PolicySet = Get-AzPolicySetDefinition -Name 'VirtualMachinePolicySet'
$NonComplianceMessages = @(@{Message="Only DsV2 SKUs are allowed."; PolicyDefinitionReferenceId="DefRef1"}, @{Message="Virtual machines must follow cost management best practices."})
New-AzPolicyAssignment -Name 'VirtualMachinePolicyAssignment' -PolicySetDefinition $PolicySet -NonComplianceMessage $NonComplianceMessages
```

The first command gets the policy set definition named VirtualMachinePolicySet by using the Get-AzPolicySetDefinition cmdlet and stores it in the $PolicySet variable.
The second command creates an array of non-compliance messages.
One general purpose message for the entire assignment and one message specific to a SKU restriction policy within the assigned policy set definition.
The final command assigns the policy set definition in $PolicySet to the subscription with two non-compliance messages that will be shown if a resource is denied by policy.

### Example 9: Policy assignment with resource selector
```powershell
$Policy = Get-AzPolicyDefinition -Name 'VirtualMachinePolicy'
$ResourceSelector = @{Name = "MyLocationSelector"; Selector = @(@{Kind = "resourceLocation"; In = @("eastus", "eastus2")})}
New-AzPolicyAssignment -Name 'VirtualMachinePolicyAssignment' -PolicyDefinition $Policy -ResourceSelector $ResourceSelector
```

The first command gets the policy definition named VirtualMachinePolicy by using the Get-AzPolicyDefinition cmdlet and stores it in the $Policy variable.
The second command creates a resource selector object that will be used to specify the assignment should only apply to resources located in East US or East US 2 and stores it in the $ResourceSelector variable.
The final command assigns the policy definition in $Policy to the subscription with the resource selector specified by $ResourceSelector.

### Example 10: Policy assignment with override
```powershell
$Policy = Get-AzPolicyDefinition -Name 'VirtualMachinePolicy'
$Selector = @{Kind = "resourceLocation"; In = @("eastus", "eastus2")}
$Override = @(@{Kind = "policyEffect"; Value = 'Disabled'; Selector = @($Selector)})
New-AzPolicyAssignment -Name 'VirtualMachinePolicyAssignment' -PolicyDefinition $Policy -Override $Override
```

The first command gets the policy definition named VirtualMachinePolicy by using the Get-AzPolicyDefinition cmdlet and stores it in the $Policy variable.
The second command creates a location selector specifying East US or East US 2 locations and stores it in the $Selector variable.
The third command creates an override object that will be used to specify that the assigned definition should have a Disabled effect in the locations identified by the $Selector object and stores it in the $Override variable.
The final command assigns the policy definition in $Policy to the subscription with the override specified by $Override.

### Example 11: [Backcompat] Policy assignment at resource group level with policy parameter object
```powershell
$ResourceGroup = Get-AzResourceGroup -Name 'ResourceGroup11'
$Policy = Get-AzPolicyDefinition -BuiltIn | Where-Object {$_.Properties.DisplayName -eq 'Allowed locations'}
$Locations = Get-AzLocation | Where-Object displayname -like '*east*'
$AllowedLocations = @{'listOfAllowedLocations'=($Locations.location)}
New-AzPolicyAssignment -Name 'RestrictLocationPolicyAssignment' -PolicyDefinition $Policy -Scope $ResourceGroup.ResourceId -PolicyParameterObject $AllowedLocations
```

The first command gets a resource group named ResourceGroup11 by using the Get-AzResourceGroup cmdlet.
The command stores that object in the $ResourceGroup variable.
The second command gets the built-in policy definition for allowed locations by using the Get-AzPolicyDefinition cmdlet.
The command stores that object in the $Policy variable.
The third and fourth commands create an object containing all Azure regions with "east" in the name.
The commands store that object in the $AllowedLocations variable.
The final command assigns the policy in $Policy at the level of a resource group using the policy parameter object in $AllowedLocations.
The **ResourceId** property of $ResourceGroup identifies the resource group.

### Example 12: [Backcompat] Policy assignment at resource group level with policy parameter file
```powershell
'{
    "listOfAllowedLocations":  {
      "value": [
        "westus",
        "westeurope",
        "japanwest"
      ]
    }
}' > .\AllowedLocations.json

$ResourceGroup = Get-AzResourceGroup -Name 'ResourceGroup11'
$Policy = Get-AzPolicyDefinition -BuiltIn | Where-Object {$_.Properties.DisplayName -eq 'Allowed locations'}
New-AzPolicyAssignment -Name 'RestrictLocationPolicyAssignment' -PolicyDefinition $Policy -Scope $ResourceGroup.ResourceId -PolicyParameter .\AllowedLocations.json
```

The first command creates a parameter file called _AllowedLocations.json_ in the local working directory.
The second command gets a resource group named ResourceGroup11 by using the Get-AzResourceGroup cmdlet and stores it in the $ResourceGroup variable.
The third command gets the built-in policy definition for allowed locations by using the Get-AzPolicyDefinition cmdlet and stores it in the $Policy variable.
The final command assigns the policy in $Policy at the resource group identified by the **ResourceId** property of $ResourceGroup using the policy parameter file AllowedLocations.json from the local working directory.

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

### -DefinitionVersion
Indicate version of policy definition or policy set definition

```yaml
Type: System.String
Parameter Sets: ParameterObject, ParameterString, PolicyDefinitionOrPolicySetDefinition
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description
This message will be part of response in case of policy violation.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DisplayName
The display name of the policy assignment.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -EnforcementMode
The policy assignment enforcement mode.
Possible values are Default and DoNotEnforce.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -IdentityId
The user identity associated with the policy.
The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.

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

### -IdentityType
The identity type.
This is the only required field when adding a system or user assigned identity to a resource.

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

### -Location
The location of the policy assignment.
Only required when utilizing managed identity.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Metadata
The policy assignment metadata.
Metadata is an open ended object and is typically a collection of key value pairs.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
The name of the policy assignment.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: PolicyAssignmentName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -NonComplianceMessage
The messages that describe why a resource is non-compliant with the policy.
To construct, see NOTES section for NONCOMPLIANCEMESSAGE properties and create a hash table.

```yaml
Type: System.Management.Automation.PSObject[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -NotScope
The policy's excluded scopes.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Override
The policy property value override.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IOverride[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PolicyDefinition
Accept policy definition or policy set definition object

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: ParameterObject, ParameterString
Aliases: PolicySetDefinition

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: PolicyDefinitionOrPolicySetDefinition
Aliases: PolicySetDefinition

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PolicyParameter
The parameter values for the assigned policy rule.
The keys are the parameter names.

```yaml
Type: System.String
Parameter Sets: ParameterString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PolicyParameterObject
The parameter values for the assigned policy rule.
The keys are the parameter names.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: ParameterObject
Aliases:

Required: True
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

### -ResourceSelector
The resource selector list to filter policies by resource properties.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceSelector[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
The scope of the policy assignment.
Valid scopes are: management group (format: '/providers/Microsoft.Management/managementGroups/{managementGroup}'), subscription (format: '/subscriptions/{subscriptionId}'), resource group (format: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}', or resource (format: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/[{parentResourcePath}/]{resourceType}/{resourceName}'

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### System.Management.Automation.PSObject

### System.Management.Automation.PSObject[]

### System.String

### System.String[]

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignment

## NOTES

## RELATED LINKS
