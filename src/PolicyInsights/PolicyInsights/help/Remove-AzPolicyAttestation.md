---
external help file: Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.dll-help.xml
Module Name: Az.PolicyInsights
online version: https://learn.microsoft.com/powershell/module/az.policyinsights/remove-azpolicyattestation
schema: 2.0.0
---

# Remove-AzPolicyAttestation

## SYNOPSIS
Deletes a policy attestation.

## SYNTAX

### DeleteBySubscriptionId (Default)
```
Remove-AzPolicyAttestation -Name <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DeleteByResourceGroup
```
Remove-AzPolicyAttestation -Name <String> [-SubscriptionId <String>] -ResourceGroupName <String>
 [-DefaultProfile <PSObject>] [-PassThru] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### DeleteByResourceId
```
Remove-AzPolicyAttestation [-Name <String>] -ResourceId <String> [-DefaultProfile <PSObject>] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DeleteByScope
```
Remove-AzPolicyAttestation -Name <String> -Scope <String> [-DefaultProfile <PSObject>] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DeleteViaInputObject
```
Remove-AzPolicyAttestation -InputObject <IPolicyInsightsIdentity> [-DefaultProfile <PSObject>] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzPolicyAttestation** cmdlet deletes a policy attestation, with no return value by default.

## EXAMPLES

### Example 1: Delete a policy remediation by name at subscription scope.
```powershell
Remove-AzPolicyAttestation -Name "attestation-subscription" -PassThru
```

```output
True
```

This command deletes the attestation named 'attestation-subscription' in the current context's subscription.
The `-PassThru` switch forces the cmdlet to return the status of the operation.

### Example 2: Delete a policy remediation via piping at resource group.
```powershell
$rgName = "ps-attestation-test-rg"
Get-AzPolicyAttestation -Name "attestation-RG" -ResourceGroupName $rgName | Remove-AzPolicyAttestation
```

This command deletes the attestation named 'attestation-RG' at resource group 'ps-attestation-test-rg' using input object given by the **Get-AzPolicyAttestation** cmdlet.

### Example 3: Delete a policy remediation using ResourceId.
```powershell
$scope = "/subscriptions/d1acb22b-c876-44f7-b08e-3fcf9f6767f4/resourceGroups/ps-attestation-test-rg/providers/Microsoft.Network/networkSecurityGroups/pstests0"
$attestationToDelete = Get-AzPolicyAttestation -Name "attestation-resource" -Scope $scope
Remove-AzPolicyAttestation -Id $attestationToDelete.Id
```

The first command gets an attestation named 'attestation-resource' with a resource id supplied as scope.
The second command then deletes the attestation using the resource id of the stored attestation.

## PARAMETERS

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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Models.IPolicyInsightsIdentity
Parameter Sets: DeleteViaInputObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the attestation.

```yaml
Type: System.String
Parameter Sets: DeleteBySubscriptionId, DeleteByResourceGroup, DeleteByScope
Aliases: AttestationName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: DeleteByResourceId
Aliases: AttestationName

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: DeleteByResourceGroup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
ID of the resource that the attestation was made against or full Resource ID of the attestation.

```yaml
Type: System.String
Parameter Sets: DeleteByResourceId
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
Parameter Sets: DeleteByScope
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
Parameter Sets: DeleteBySubscriptionId, DeleteByResourceGroup
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

### System.Boolean

## NOTES

## RELATED LINKS
