### Example 1: Delete a policy remediation by name at subscription scope.
```powershell
Remove-AzPolicyAttestation -Name "attestation-subscription" -PassThru
```

```output
True
```

This command deletes the attestation named 'attestation-subscription' in the current context's subscription. The `-PassThru` switch forces the cmdlet to return the status of the operation.

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