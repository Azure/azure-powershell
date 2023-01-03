---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ResourceManager.dll-Help.xml
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/remove-azpolicyexemption
schema: 2.0.0
---

# Remove-AzPolicyExemption

## SYNOPSIS
Removes a policy exemption.

## SYNTAX

### NameParameterSet (Default)
```
Remove-AzPolicyExemption -Name <String> [-Scope <String>] [-Force] [-ApiVersion <String>] [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### IdParameterSet
```
Remove-AzPolicyExemption -Id <String> [-Force] [-ApiVersion <String>] [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### InputObjectParameterSet
```
Remove-AzPolicyExemption [-Force] -InputObject <PsPolicyExemption> [-ApiVersion <String>] [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzPolicyExemption** cmdlet removes the specified policy exemption.

## EXAMPLES

### Example 1: Remove policy exemption by name and scope
```powershell
$ResourceGroup = Get-AzResourceGroup -Name 'ResourceGroup11'
Remove-AzPolicyExemption -Name 'PolicyExemption07' -Scope $ResourceGroup.ResourceId -Confirm
```

The first command gets a resource group named ResourceGroup11 by using the Get-AzResourceGroup cmdlet.
The command stores that object in the $ResourceGroup variable.
The second command removes the policy exemption named PolicyExemption07 that was assigned at a resource group level.
The **ResourceId** property of $ResourceGroup identifies the resource group.

### Example 2: Remove policy exemption by ID
```powershell
$ResourceGroup = Get-AzResourceGroup -Name 'ResourceGroup11' 
$PolicyExemption = Get-AzPolicyExemption -Name 'PolicyExemption07' -Scope $ResourceGroup.ResourceId
Remove-AzPolicyExemption -Id $PolicyExemption.ResourceId -Confirm
```

The first command gets a resource group named ResourceGroup11, and then stores that object in the $ResourceGroup variable.
The second command gets the policy exemption at a resource group level, and then stores it in the $PolicyExemption variable.
The **ResourceId** property of $ResourceGroup identifies the resource group.
The final command removes the policy exemption that the **ResourceId** property of $PolicyExemption identifies.

## PARAMETERS

### -ApiVersion
When set, indicates the version of the resource provider API to use.
If not specified, the API version is automatically determined as the latest available.

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
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
Do not ask for confirmation.

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

### -Id
The fully qualified policy exemption ID to delete, including the scope, e.g.
/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Authorization/policyExemptions/{policyExemptionName}.

```yaml
Type: System.String
Parameter Sets: IdParameterSet
Aliases: ResourceId

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -InputObject
The policy exemption object to remove that was output from another cmdlet.

```yaml
Type: Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicyExemption
Parameter Sets: InputObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -Name
The name of the policy exemption to delete.

```yaml
Type: System.String
Parameter Sets: NameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Pre
When set, indicates that the cmdlet should use pre-release API versions when automatically determining which version to use.

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

### -Scope
The scope of the policy exemption to delete, e.g.
/providers/managementGroups/{managementGroupName}, defaults to current subscription.

```yaml
Type: System.String
Parameter Sets: NameParameterSet
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

### System.String

### Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicyExemption

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
