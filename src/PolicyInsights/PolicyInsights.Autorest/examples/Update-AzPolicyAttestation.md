### Example 1: Update an attestation by name
```powershell
# Update the existing attestation by resource name at subscription scope (default)
$comment = "Setting the state to non compliant"
$attestationName = "Attestation-SubscriptionScope-Crud"
$policyAssignmentId = "/subscriptions/e5a130f3-57fd-46b6-9c55-03d21a853935/providers/Microsoft.Authorization/policyAssignments/PSAttestationSubAssignment"
Update-AzPolicyAttestation -PolicyAssignmentId $policyAssignmentId -Name $attestationName -ComplianceState "NonCompliant" -Comment $comment
```

```output
AssessmentDate               :
Comment                      : Setting the state to non compliant
ComplianceState              : NonCompliant
Evidence                     :
ExpiresOn                    :
Id                           : /subscriptions/e5a130f3-57fd-46b6-9c55-03d21a853935/providers/microsoft.policyinsights/attestations/attestation-subscriptionscope-crud
LastComplianceStateChangeAt  : 3/27/2026 6:50:22 PM
Metadata                     : {
                               }
Name                         : Attestation-SubscriptionScope-Crud
Owner                        :
PolicyAssignmentId           : /subscriptions/e5a130f3-57fd-46b6-9c55-03d21a853935/providers/microsoft.authorization/policyassignments/psattestationsubassignment
PolicyDefinitionReferenceId  :
ProvisioningState            : Succeeded
ResourceGroupName            :
SystemDataCreatedAt          : 3/26/2026 9:01:05 PM
SystemDataCreatedBy          : username@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 3/27/2026 6:50:22 PM
SystemDataLastModifiedBy     : username@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.PolicyInsights/attestations
```

The command here sets the compliance state and adds a comment to an existing attestation with name 'Attestation-SubscriptionScope-Crud'.

### Example 2: Update an attestation by ResourceId
```powershell
# Get an attestation
$rgName = "ps-attestation-test-rg"
$attestationName = "Attestation-RGScope-Crud"
$attestation = Get-AzPolicyAttestation -ResourceGroupName $rgName -Name $attestationName

# Update the existing attestation by resource ID at RG scope
$expiresOn = [System.DateTime]::UtcNow.AddYears(1)
Update-AzPolicyAttestation -Id $attestation.Id -ExpiresOn $expiresOn
```

```output
AssessmentDate               :
Comment                      :
ComplianceState              : Compliant
Evidence                     :
ExpiresOn                    : 3/27/2027 6:54:11 PM
Id                           : /subscriptions/e5a130f3-57fd-46b6-9c55-03d21a853935/resourcegroups/ps-attestation-test-rg/providers/microsoft.policyinsights/attestations/attestation-rgscope-crud
LastComplianceStateChangeAt  : 3/26/2026 9:28:05 PM
Metadata                     : {
                               }
Name                         : attestation-rgscope-crud
Owner                        :
PolicyAssignmentId           : /subscriptions/e5a130f3-57fd-46b6-9c55-03d21a853935/providers/microsoft.authorization/policyassignments/psattestationrgassignment
PolicyDefinitionReferenceId  :
ProvisioningState            : Succeeded
ResourceGroupName            : ps-attestation-test-rg
SystemDataCreatedAt          : 3/26/2026 9:28:05 PM
SystemDataCreatedBy          : username@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 3/27/2026 6:54:39 PM
SystemDataLastModifiedBy     : username@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.PolicyInsights/attestations
```

The first command gets an existing attestation at the resource group 'ps-attestation-test-rg' with the name 'attestation-rgscope-crud'.

The final command updates the expiry time of the policy attestation by the **ResourceId** property of the existing attestation.

### Example 3: Update an attestation by input object
```powershell
# Get an attestation
$attestationName = "Attestation-ResourceScope-Crud"
$scope = "/subscriptions/e5a130f3-57fd-46b6-9c55-03d21a853935/resourceGroups/ps-attestation-test-rg/providers/Microsoft.Network/networkSecurityGroups/pstests0"
$attestation = Get-AzPolicyAttestation -Name $attestationName -Scope $scope

# Update attestation by input object
$newOwner = "Test Owner 2"
$attestation | Update-AzPolicyAttestation -Owner $newOwner
```

```output
AssessmentDate               :
Comment                      :
ComplianceState              : Compliant
Evidence                     :
ExpiresOn                    :
Id                           : /subscriptions/e5a130f3-57fd-46b6-9c55-03d21a853935/resourcegroups/ps-attestation-test-rg/providers/microsoft.network/networksecuritygroups/pstests0/providers/microsoft.policyins
                               ights/attestations/attestation-resourcescope-crud
LastComplianceStateChangeAt  : 3/26/2026 9:28:50 PM
Metadata                     : {
                               }
Name                         : attestation-resourcescope-crud
Owner                        : Test Owner 2
PolicyAssignmentId           : /subscriptions/e5a130f3-57fd-46b6-9c55-03d21a853935/providers/microsoft.authorization/policyassignments/psattestationresourceassignment
PolicyDefinitionReferenceId  :
ProvisioningState            : Succeeded
ResourceGroupName            : ps-attestation-test-rg
SystemDataCreatedAt          : 3/26/2026 9:28:50 PM
SystemDataCreatedBy          : username@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 3/27/2026 6:59:14 PM
SystemDataLastModifiedBy     : username@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.PolicyInsights/attestations
```

The first command gets an existing attestation with name 'attestation-resourcescope-crud' for the given resource using its resource id as the scope.

The final command updates the owner of the policy attestation by using piping.