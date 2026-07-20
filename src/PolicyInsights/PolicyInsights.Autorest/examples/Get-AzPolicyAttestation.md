### Example 1: Get all policy attestations in the current subscription
```powershell
Get-AzPolicyAttestation | fl
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

This command gets all the attestations created at or underneath the subscription of the current context.

### Example 2: Get a specific policy attestation
```powershell
Get-AzPolicyAttestation -ResourceGroupName "ps-attestation-test-rg" -Name "Attestation-RGScope-Crud"
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

This command gets the attestation named 'Attestation-RGScope-Crud' at the resource group 'ps-attestation-test-rg'.

### Example 3: Get 5 policy attestations in a subscription with optional filters
```powershell
Get-AzPolicyAttestation -Top 5 -Filter "PolicyAssignmentId eq '/subscriptions/e5a130f3-57fd-46b6-9c55-03d21a853935/providers/microsoft.authorization/policyassignments/PSAttestationResourceAssignment'"
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

This command gets a max of 5 policy attestations underneath the current context's subscription. Only policy attestations for the given policy assignment will be retrieved.
