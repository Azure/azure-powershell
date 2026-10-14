### Example 1: Create an attestation at subscription scope
```powershell
$policyAssignmentId = "/subscriptions/e5a130f3-57fd-46b6-9c55-03d21a853935/providers/Microsoft.Authorization/policyAssignments/PSAttestationSubAssignment"
$attestationName = "Attestation-SubscriptionScope-Crud"
New-AzPolicyAttestation -PolicyAssignmentId $policyAssignmentId -Name $attestationName -ComplianceState "Compliant"
```

```output
AssessmentDate               :
Comment                      :
ComplianceState              : Compliant
Evidence                     :
ExpiresOn                    :
Id                           : /subscriptions/e5a130f3-57fd-46b6-9c55-03d21a853935/providers/microsoft.policyinsights/attestations/attestation-subscriptionscope-crud
LastComplianceStateChangeAt  : 3/26/2026 9:01:05 PM
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
SystemDataLastModifiedAt     : 3/26/2026 9:01:05 PM
SystemDataLastModifiedBy     : username@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.PolicyInsights/attestations
```

This command creates a new policy attestation at subscription 'e5a130f3-57fd-46b6-9c55-03d21a853935' for the given policy assignment.

>**Note:**
>This command creates an attestation for the subscription and not the resources underneath it. For ease of management, manual policies should be designed to target the scope which defines the boundary of resources whose compliance state needs to be attested. In this case, the manual policy should be targeting `Microsoft.Resources/subscriptions`. For more information, go to https://learn.microsoft.com/en-us/azure/governance/policy/concepts/attestation-structure to understand the best practices for creating attestations.

### Example 2: Create an attestation at resource group
```powershell
$policyAssignmentId = "/subscriptions/e5a130f3-57fd-46b6-9c55-03d21a853935/providers/Microsoft.Authorization/policyAssignments/PSAttestationRGAssignment"
$attestationName = "Attestation-RGScope-Crud"
$rgName = "ps-attestation-test-rg"
New-AzPolicyAttestation -ResourceGroupName $RGName -PolicyAssignmentId $policyAssignmentId -Name $attestationName -ComplianceState "Compliant"
```

```output
AssessmentDate               :
Comment                      :
ComplianceState              : Compliant
Evidence                     :
ExpiresOn                    :
Id                           : /subscriptions/e5a130f3-57fd-46b6-9c55-03d21a853935/resourcegroups/ps-attestation-test-rg/providers/microsoft.policyinsights/attestations/attestation-rgscope-crud
LastComplianceStateChangeAt  : 3/26/2026 9:28:05 PM
Metadata                     : {
                               }
Name                         : Attestation-RGScope-Crud
Owner                        :
PolicyAssignmentId           : /subscriptions/e5a130f3-57fd-46b6-9c55-03d21a853935/providers/microsoft.authorization/policyassignments/psattestationrgassignment
PolicyDefinitionReferenceId  :
ProvisioningState            : Succeeded
ResourceGroupName            : ps-attestation-test-rg
SystemDataCreatedAt          : 3/26/2026 9:28:05 PM
SystemDataCreatedBy          : username@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 3/26/2026 9:28:05 PM
SystemDataLastModifiedBy     : username@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.PolicyInsights/attestations
```

This command creates a new policy attestation at the resource group 'ps-attestation-test-rg' for the given policy assignment.

>**Note:**
>This command creates an attestation for the resource group and not the resources underneath it. For ease of management, manual policies should be designed to target the scope which defines the boundary of resources whose compliance state needs to be attested. In this case, the manual policy should be targeting `Microsoft.Resources/subscriptions/resourceGroups`. For more information, go to https://learn.microsoft.com/en-us/azure/governance/policy/concepts/attestation-structure to understand the best practices for creating attestations.

### Example 3: Create an attestation at resource
```powershell
$policyAssignmentId = "/subscriptions/e5a130f3-57fd-46b6-9c55-03d21a853935/providers/Microsoft.Authorization/policyAssignments/PSAttestationResourceAssignment"
$attestationName = "Attestation-ResourceScope-Crud"
$scope = "/subscriptions/e5a130f3-57fd-46b6-9c55-03d21a853935/resourceGroups/ps-attestation-test-rg/providers/Microsoft.Network/networkSecurityGroups/pstests0"
New-AzPolicyAttestation -PolicyAssignmentId $policyAssignmentId -Name $attestationName -Scope $scope -ComplianceState "Compliant"
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
Name                         : Attestation-ResourceScope-Crud
Owner                        :
PolicyAssignmentId           : /subscriptions/e5a130f3-57fd-46b6-9c55-03d21a853935/providers/microsoft.authorization/policyassignments/psattestationresourceassignment
PolicyDefinitionReferenceId  :
ProvisioningState            : Succeeded
ResourceGroupName            : ps-attestation-test-rg
SystemDataCreatedAt          : 3/26/2026 9:28:50 PM
SystemDataCreatedBy          : username@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 3/26/2026 9:28:50 PM
SystemDataLastModifiedBy     : username@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.PolicyInsights/attestations
```

This command creates an attestation for the resource 'pstests0' for the given policy assignment.

### Example 4: Create an attestation with all properties at resource group
```powershell
$attestationName = "Attestation-RG-Full"
$policyInitiativeAssignmentId = "/subscriptions/e5a130f3-57fd-46b6-9c55-03d21a853935/providers/microsoft.authorization/policyassignments/PSAttestationInitiativeRGAssignment"

$policyDefinitionReferenceId = "PSTestAttestationRG_1"
$RGName = "ps-attestation-test-rg"
$description = "This is a test description"
$sourceURI = "https://contoso.org/test.pdf"
$evidence = @{ "Description"=$description; "SourceUri"=$sourceURI }
$comment = "This is a test comment"
$policyEvidence = @($evidence)
$owner = "Test Owner"
$expiresOn = [datetime]::UtcNow.AddYears(1)
$metadata = '{"TestKey":"TestValue"}'
$compliant = "Compliant"

New-AzPolicyAttestation `
    -Name $attestationName `
    -ResourceGroupName $RGName `
    -PolicyAssignmentId $policyInitiativeAssignmentId `
    -PolicyDefinitionReferenceId $policyDefinitionReferenceId `
    -ComplianceState $Compliant `
    -Comment $comment `
    -Evidence $policyEvidence `
    -ExpiresOn $expiresOn `
    -AssessmentDate $expiresOn.AddDays(-2) `
    -Owner $owner `
    -Metadata $metadata
```

```output
AssessmentDate               : 3/25/2027 12:00:19 AM
Comment                      : This is a test comment
ComplianceState              : Compliant
Evidence                     : {{
                                 "description": "This is a test description",
                                 "sourceUri": "https://contoso.org/test.pdf"
                               }}
ExpiresOn                    : 3/27/2027 12:00:19 AM
Id                           : /subscriptions/e5a130f3-57fd-46b6-9c55-03d21a853935/resourcegroups/ps-attestation-test-rg/providers/microsoft.policyinsights/attestations/attestation-rg-full
LastComplianceStateChangeAt  : 3/27/2026 12:01:31 AM
Metadata                     : {
                                 "TestKey": "TestValue"
                               }
Name                         : Attestation-RG-Full
Owner                        : Test Owner
PolicyAssignmentId           : /subscriptions/e5a130f3-57fd-46b6-9c55-03d21a853935/providers/microsoft.authorization/policyassignments/psattestationinitiativergassignment
PolicyDefinitionReferenceId  : pstestattestationrg_1
ProvisioningState            : Succeeded
ResourceGroupName            : ps-attestation-test-rg
SystemDataCreatedAt          : 3/27/2026 12:01:31 AM
SystemDataCreatedBy          : username@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 3/27/2026 12:01:31 AM
SystemDataLastModifiedBy     : username@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.PolicyInsights/attestations
```

This command creates an attestation at resource group scope with all of the fields populated.