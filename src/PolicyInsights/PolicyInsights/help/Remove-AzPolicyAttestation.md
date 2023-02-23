---
external help file: Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.dll-Help.xml
Module Name: Az.PolicyInsights
online version: https://learn.microsoft.com/powershell/module/az.policyinsights/remove-azpolicyattestation
schema: 2.0.0
---

# Remove-AzPolicyAttestation

## SYNOPSIS
Deletes a policy attestation.

## SYNTAX

### ByName (Default)
```
Remove-AzPolicyAttestation -Name <String> [-Scope <String>] [-ResourceGroupName <String>] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByResourceId
```
Remove-AzPolicyAttestation -ResourceId <String> [-PassThru] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByInputObject
```
Remove-AzPolicyAttestation -InputObject <PSAttestation> [-PassThru] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzPolicyAttestation** cmdlet deletes a policy attestation.

## EXAMPLES

### Example 1: Delete a policy remediation by name at subscription scope.
```powershell
Set-AzContext -Subscription "d1acb22b-c876-44f7-b08e-3fcf9f6767f4"
Remove-AzPolicyAttestation -Name "attestation-subscription" -PassThru
```

```output
True
```

This command deletes the attestation named 'attestation-subscription' in subscription "d1acb22b-c876-44f7-b08e-3fcf9f6767f4". The `-PassThru` switch forces the cmdlet to return the status of the operation.

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

### -InputObject
The Attestation object.

```yaml
Type: Microsoft.Azure.Commands.PolicyInsights.Models.Attestations.PSAttestation
Parameter Sets: ByInputObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Resource name.

```yaml
Type: System.String
Parameter Sets: ByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PassThru
Return True if the command completes successfully.

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
Resource group name.

```yaml
Type: System.String
Parameter Sets: ByName
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
Resource ID.

```yaml
Type: System.String
Parameter Sets: ByResourceId
Aliases: Id

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Scope
Scope of the resource.
E.g.
'/subscriptions/{subscriptionId}/resourceGroups/{rgName}'.

```yaml
Type: System.String
Parameter Sets: ByName
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

### Microsoft.Azure.Commands.PolicyInsights.Models.Attestations.PSAttestation

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
[Get-AzPolicyAttestation](./Get-AzPolicyAttestation.md)
