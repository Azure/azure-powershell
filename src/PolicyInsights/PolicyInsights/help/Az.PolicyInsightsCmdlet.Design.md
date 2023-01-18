#### New-AzPolicyAttestation

#### SYNOPSIS
Creates a new policy attestation for a policy assignment.

#### SYNTAX

+ ByName (Default)
```powershell
New-AzPolicyAttestation -Name <String> [-Scope <String>] [-ResourceGroupName <String>]
 -PolicyAssignmentId <String> [-ComplianceState <String>] [-PolicyDefinitionReferenceId <String>]
 [-ExpiresOn <DateTime>] [-Owner <String>] [-Comment <String>] [-Evidence <PSAttestationEvidence[]>]
 [-AssessmentDate <DateTime>] [-Metadata <Object>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

+ ByResourceId
```powershell
New-AzPolicyAttestation -ResourceId <String> -PolicyAssignmentId <String> [-ComplianceState <String>]
 [-PolicyDefinitionReferenceId <String>] [-ExpiresOn <DateTime>] [-Owner <String>] [-Comment <String>]
 [-Evidence <PSAttestationEvidence[]>] [-AssessmentDate <DateTime>] [-Metadata <Object>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Create an attestation at subscription scope
```powershell
Set-AzContext -Subscription "My Subscription"
$policyAssignmentId = "/subscriptions/49c37404-cef8-46b2-ba72-fa8419c82ed5/providers/Microsoft.Authorization/policyAssignments/0774f87b3af94c1399d3ee52"
$attestationName = "attestation-subscription"
New-AzPolicyAttestation -PolicyAssignmentId $policyAssignmentId -Name $attestationName -ComplianceState "Compliant"
```

This command creates a new policy attestation at subscription 'My Subscription' for the given policy assignment.

>**Note:**
>This command creates an attestation for the subscription and not the resources underneath it. For ease of management, manual policies should be designed to target the scope which defines the boundary of resources whose compliance state needs to be attested. In this case, the manual policy should be targeting `Microsoft.Resources/subscriptions`. For more information, go to https://learn.microsoft.com/en-us/azure/governance/policy/concepts/attestation-structure to understand the best practices for creating attestations.

+ Example 2: Create an attestation at resource group
```powershell
$policyAssignmentId = "/subscriptions/49c37404-cef8-46b2-ba72-fa8419c82ed5/providers/Microsoft.Authorization/policyAssignments/0774f87b3af94c1399d3ee52"
$attestationName = "attestation-RG"
$rgName = "myRG"
New-AzPolicyAttestation -ResourceGroupName $RGName -PolicyAssignmentId $policyAssignmentId -Name $attestationName -ComplianceState "Compliant"
```

This command creates a new policy attestation at the resource group 'myRG' for the given policy assignment.

>**Note:**
>This command creates an attestation for the resource group and not the resources underneath it. For ease of management, manual policies should be designed to target the scope which defines the boundary of resources whose compliance state needs to be attested. In this case, the manual policy should be targeting `Microsoft.Resources/subscriptions/resourceGroups`. For more information, go to https://learn.microsoft.com/en-us/azure/governance/policy/concepts/attestation-structure to understand the best practices for creating attestations.

+ Example 3: Create an attestation at resource
```powershell
$policyAssignmentId = "/subscriptions/49c37404-cef8-46b2-ba72-fa8419c82ed5/providers/Microsoft.Authorization/policyAssignments/0774f87b3af94c1399d3ee52"
$attestationName = "attestation-resource"
$scope = "/subscriptions/49c37404-cef8-46b2-ba72-fa8419c82ed5/resourceGroups/myRG/providers/Microsoft.Network/virtualNetworks/Test-VN"
New-AzPolicyAttestation `
    -PolicyAssignmentId $policyAssignmentId `
    -Name $attestationName `
    -Scope $scope `
    -ComplianceState "NonCompliant"
```

This command creates an attestation for the resource 'Test-VN' for the given policy assignment.

+ Example 4: Create an attestation with all properties at resource group
```
$attestationName = "attestationRG"
$policyInitiativeAssignmentId = "/subscriptions/49c37404-cef8-46b2-ba72-fa8419c82ed5/resourceGroups/myRG/providers/Microsoft.Authorization/policyAssignments/74067f0991764e9882a046e0"
$policyDefinitionReferenceId = "PS: Manual Policy (RG)_1"

$description = "This is a test description"
$sourceURI = "https://contoso.org/test.pdf"
$owner = "Test Owner"
$evidence = @{
    "Description"=$description 
    "SourceUri"=$sourceURI
}
$policyEvidence = @($evidence)
$metadata = '{"TestKey":"TestValue"}'
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


#### Get-AzPolicyAttestation

#### SYNOPSIS
Gets policy attestations.

#### SYNTAX

+ SubscriptionScope (Default)
```powershell
Get-AzPolicyAttestation [-Top <Int32>] [-Filter <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

+ ByName
```powershell
Get-AzPolicyAttestation -Name <String> [-Scope <String>] [-ResourceGroupName <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

+ GenericScope
```powershell
Get-AzPolicyAttestation -Scope <String> [-Top <Int32>] [-Filter <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

+ ResourceGroupScope
```powershell
Get-AzPolicyAttestation -ResourceGroupName <String> [-Top <Int32>] [-Filter <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

+ ByResourceId
```powershell
Get-AzPolicyAttestation -ResourceId <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Get all policy attestations in the current subscription
```powershell
Set-AzContext -Subscription "MySubscription"
Get-AzPolicyAttestation
```

This command gets all the attestations created at or underneath a subscription named "My Subscription".

+ Example 2: Get a specific policy attestation
```powershell
Get-AzPolicyAttestation -ResourceGroupName "myResourceGroup" -Name "attestation1"
```

This command gets the attestation named 'attestation1' at the resource group 'myResourceGroup'.

+ Example 3: Get 5 policy attestations in a subscription with optional filters
```powershell
Set-AzContext -Subscription "MySubscription"
Get-AzPolicyAttestation -Top 5 -Filter "PolicyAssignmentId eq '/subscriptions/49c37404-cef8-46b2-ba72-fa8419c82ed5/providers/Microsoft.Authorization/policyAssignments/0774f87b3af94c1399d3ee52"
```

This command gets a max of 5 policy attestations underneath the subscription named 'My Subscription'. Only policy attestations for the given policy assignment will be retrieved.


#### Remove-AzPolicyAttestation

#### SYNOPSIS
Deletes a policy attestation.

#### SYNTAX

+ ByName (Default)
```powershell
Remove-AzPolicyAttestation -Name <String> [-Scope <String>] [-ResourceGroupName <String>] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

+ ByResourceId
```powershell
Remove-AzPolicyAttestation -ResourceId <String> [-PassThru] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

+ ByInputObject
```powershell
Remove-AzPolicyAttestation -InputObject <PSAttestation> [-PassThru] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Delete a policy remediation by name at subscription scope.
```powershell
Set-AzContext -Subscription "My Subscription"
Remove-AzPolicyAttestation -Name "attestation1"
```

This command deletes the attestation named 'attestation1' in subscription "My Subscription"

+ Example 2: Delete a policy remediation via piping at resource group.
```powershell
$rgName = "myRG"

Get-AzPolicyAttestation -Name "attestation2" -ResourceGroupName $rgName | Remove-AzPolicyAttestation
```

This command deletes the attestation named 'attestation2' at resource group 'myRG' using input object given by the **Get-AzPolicyAttestation** cmdlet.

+ Example 3: Delete a policy remediation using ResourceId.
```powershell
$scope = "/subscriptions/49c37404-cef8-46b2-ba72-fa8419c82ed5/resourceGroups/myRG/providers/Microsoft.Network/virtualNetworks/Test-VN"
$attestationToDelete = Get-AzPolicyAttestation -Name "attestation3" -Scope $scope
Remove-AzPolicyAttestation -Id $attestationToDelete.Id
```

The first command gets an attestation named 'attestation3' with a resource id supplied as scope. 
The second command then deletes the attestation using the resource id of the stored attestation.


#### Set-AzPolicyAttestation

#### SYNOPSIS
Modifies a policy attestation.

#### SYNTAX

+ ByName (Default)
```powershell
Set-AzPolicyAttestation -Name <String> [-Scope <String>] [-ResourceGroupName <String>]
 [-PolicyAssignmentId <String>] [-ComplianceState <String>] [-PolicyDefinitionReferenceId <String>]
 [-ExpiresOn <DateTime>] [-Owner <String>] [-Comment <String>] [-Evidence <PSAttestationEvidence[]>]
 [-AssessmentDate <DateTime>] [-Metadata <Object>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

+ ByResourceId
```powershell
Set-AzPolicyAttestation -ResourceId <String> [-PolicyAssignmentId <String>] [-ComplianceState <String>]
 [-PolicyDefinitionReferenceId <String>] [-ExpiresOn <DateTime>] [-Owner <String>] [-Comment <String>]
 [-Evidence <PSAttestationEvidence[]>] [-AssessmentDate <DateTime>] [-Metadata <Object>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

+ ByInputObject
```powershell
Set-AzPolicyAttestation -InputObject <PSAttestation> [-PolicyAssignmentId <String>] [-ComplianceState <String>]
 [-PolicyDefinitionReferenceId <String>] [-ExpiresOn <DateTime>] [-Owner <String>] [-Comment <String>]
 [-Evidence <PSAttestationEvidence[]>] [-AssessmentDate <DateTime>] [-Metadata <Object>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Update an attestation by name
```powershell
Set-AzContext -Subscription "My Subscription"
#### Update the existing attestation by resource name at subscription scope (default)   
$comment = "Setting the state to non compliant"
$attestationName = "attestation1"

Set-AzPolicyAttestation -PolicyAssignmentId $policyAssignmentId -Name $attestationName -ComplianceState "NonCompliant" -Comment $comment
```

The command here sets the compliance state and adds a comment to an existing attestation with name 'attestation1' in the subscription named 'My Subscription'

+ Example 2: Update an attestation by ResourceId
```powershell
#### Get an attestation
$rgName = "myRG"
$attestationName = "attestation2"
$attestation = Get-AzPolicyAttestation -ResourceGroupName $rgName -Name $attestationName

#### Update the existing attestation by resource ID at RG
$expiresOn = [System.DateTime]::UtcNow.AddYears(1)
$updatedAttestation = Set-AzPolicyAttestation -Id $attestation.Id -ExpiresOn $expiresOn
```

The first command gets an existing attestation at the resource group 'myRG' with the name 'attestation2'.

The final command updates the expiry time of the policy attestation by the **ResourceId** property of the existing attestation.

+ Example 3: Update an attestation by input object
```powershell
#### Get an attestation
$attestationName = "attestation3"
$scope = "/subscriptions/49c37404-cef8-46b2-ba72-fa8419c82ed5/resourceGroups/myRG/providers/Microsoft.Network/virtualNetworks/Test-VN"
$attestation = Get-AzPolicyAttestation -Name $attestationName -Scope $scope

#### Update attestation by input object
$newOwner = "Test Owner 2"
$attestation | Set-AzPolicyAttestation -Owner $newOwner
```

The first command gets an existing attestation with name 'attestation3' for the given resource using its resource id as the scope

The final command updates the owner of the policy attestation by using piping.


#### Start-AzPolicyComplianceScan

#### SYNOPSIS
Triggers a policy compliance evaluation for all resources in a subscription or resource group.

#### SYNTAX

```powershell
Start-AzPolicyComplianceScan [-ResourceGroupName <String>] [-AsJob] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Start a compliance scan at subscription scope
```powershell
Start-AzPolicyComplianceScan
```

This command starts a policy compliance evaluation for the active subscription.

+ Example 2: Start a compliance scan at resource group scope
```powershell
Start-AzPolicyComplianceScan -ResourceGroupName "myRG"
```

This command starts a policy compliance evaluation for the "myRG" resource group in the active subscription.

+ Example 3: Start a compliance scan and wait for it to complete in the background
```powershell
$job = Start-AzPolicyComplianceScan -AsJob
$job | Wait-Job
```

This command starts a policy compliance evaluation for the active subscription. It will wait for the scan to complete.


#### Get-AzPolicyEvent

#### SYNOPSIS
Gets policy evaluation events generated as resources are created or updated.

#### SYNTAX

+ SubscriptionScope (Default)
```powershell
Get-AzPolicyEvent [-SubscriptionId <String>] [-Top <Int32>] [-OrderBy <String>] [-Select <String>]
 [-From <DateTime>] [-To <DateTime>] [-Filter <String>] [-Apply <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

+ ManagementGroupScope
```powershell
Get-AzPolicyEvent -ManagementGroupName <String> [-Top <Int32>] [-OrderBy <String>] [-Select <String>]
 [-From <DateTime>] [-To <DateTime>] [-Filter <String>] [-Apply <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

+ ResourceGroupScope
```powershell
Get-AzPolicyEvent [-SubscriptionId <String>] -ResourceGroupName <String> [-Top <Int32>] [-OrderBy <String>]
 [-Select <String>] [-From <DateTime>] [-To <DateTime>] [-Filter <String>] [-Apply <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

+ PolicySetDefinitionScope
```powershell
Get-AzPolicyEvent [-SubscriptionId <String>] -PolicySetDefinitionName <String> [-Top <Int32>]
 [-OrderBy <String>] [-Select <String>] [-From <DateTime>] [-To <DateTime>] [-Filter <String>]
 [-Apply <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

+ PolicyDefinitionScope
```powershell
Get-AzPolicyEvent [-SubscriptionId <String>] -PolicyDefinitionName <String> [-Top <Int32>] [-OrderBy <String>]
 [-Select <String>] [-From <DateTime>] [-To <DateTime>] [-Filter <String>] [-Apply <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

+ SubscriptionLevelPolicyAssignmentScope
```powershell
Get-AzPolicyEvent [-SubscriptionId <String>] -PolicyAssignmentName <String> [-Top <Int32>] [-OrderBy <String>]
 [-Select <String>] [-From <DateTime>] [-To <DateTime>] [-Filter <String>] [-Apply <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

+ ResourceGroupLevelPolicyAssignmentScope
```powershell
Get-AzPolicyEvent [-SubscriptionId <String>] -ResourceGroupName <String> -PolicyAssignmentName <String>
 [-Top <Int32>] [-OrderBy <String>] [-Select <String>] [-From <DateTime>] [-To <DateTime>] [-Filter <String>]
 [-Apply <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

+ ResourceScope
```powershell
Get-AzPolicyEvent -ResourceId <String> [-Top <Int32>] [-OrderBy <String>] [-Select <String>] [-From <DateTime>]
 [-To <DateTime>] [-Filter <String>] [-Apply <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Get policy events in current subscription scope
```powershell
Get-AzPolicyEvent
```

Gets policy event records generated in the last day for all resources within the subscription in current session context.

+ Example 2: Get policy events in the specified subscription scope
```powershell
Get-AzPolicyEvent -SubscriptionId "fff10b27-fff3-fff5-fff8-fffbe01e86a5"
```

Gets policy event records generated in the last day for all resources within the specified subscription.

+ Example 3: Get policy events in management group scope
```powershell
Get-AzPolicyEvent -ManagementGroupName "myManagementGroup"
```

Gets policy event records generated in the last day for all resources within the specified management group.

+ Example 4: Get policy events in resource group scope in current subscription
```powershell
Get-AzPolicyEvent -ResourceGroupName "myResourceGroup"
```

Gets policy event records generated in the last day for all resources within the specified resource group (in the subscription in current session context).

+ Example 5: Get policy events in resource group scope in the specified subscription
```powershell
Get-AzPolicyEvent -SubscriptionId "fff10b27-fff3-fff5-fff8-fffbe01e86a5" -ResourceGroupName "myResourceGroup"
```

Gets policy event records generated in the last day for all resources within the specified resource group (in the specified subscription).

+ Example 6: Get policy events for a resource
```powershell
Get-AzPolicyEvent -ResourceId "/subscriptions/fff10b27-fff3-fff5-fff8-fffbe01e86a5/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myns1/eventhubs/eh1/consumergroups/cg1"
```

Gets policy event records generated in the last day for the specified resource.

+ Example 7: Get policy events for a policy set definition in current subscription
```powershell
Get-AzPolicyEvent -PolicySetDefinitionName "fff58873-fff8-fff5-fffc-fffbe7c9d697"
```

Gets policy event records generated in the last day for all resources (within the tenant in current session context) effected by the specified policy set definition (that exists in the subscription in current session context).

+ Example 8: Get policy events for a policy set definition in the specified subscription
```powershell
Get-AzPolicyEvent -SubscriptionId "fff10b27-fff3-fff5-fff8-fffbe01e86a5" -PolicySetDefinitionName "fff58873-fff8-fff5-fffc-fffbe7c9d697"
```

Gets policy event records generated in the last day for all resources (within the tenant in current session context) effected by the specified policy set definition (that exists in the specified subscription).

+ Example 9: Get policy events for a policy definition in current subscription
```powershell
Get-AzPolicyEvent -PolicyDefinitionName "fff58873-fff8-fff5-fffc-fffbe7c9d697"
```

Gets policy event records generated in the last day for all resources (within the tenant in current session context) effected by the specified policy definition (that exists in the subscription in current session context).

+ Example 10: Get policy events for a policy definition in the specified subscription
```powershell
Get-AzPolicyEvent -SubscriptionId "fff10b27-fff3-fff5-fff8-fffbe01e86a5" -PolicyDefinitionName "fff58873-fff8-fff5-fffc-fffbe7c9d697"
```

Gets policy event records generated in the last day for all resources (within the tenant in current session context) effected by the specified policy definition (that exists in the specified subscription).

+ Example 11: Get policy events for a policy assignment in current subscription
```powershell
Get-AzPolicyEvent -PolicyAssignmentName "ddd8ef92e3714a5ea3d208c1"
```

Gets policy event records generated in the last day for all resources (within the tenant in current session context) effected by the specified policy assignment (that exists in the subscription in current session context).

+ Example 12: Get policy events for a policy assignment in the specified subscription
```powershell
Get-AzPolicyEvent -SubscriptionId "fff10b27-fff3-fff5-fff8-fffbe01e86a5" -PolicyAssignmentName "ddd8ef92e3714a5ea3d208c1"
```

Gets policy event records generated in the last day for all resources (within the tenant in current session context) effected by the specified policy assignment (that exists in the specified subscription).

+ Example 13: Get policy events for a policy assignment in the specified resource group in the current subscription
```powershell
Get-AzPolicyEvent -ResourceGroupName "myResourceGroup" -PolicyAssignmentName "ddd8ef92e3714a5ea3d208c1"
```

Gets policy event records generated in the last day for all resources (within the tenant in current session context) effected by the specified policy assignment (that exists in the resource group in the subscription in current session context).

+ Example 14: Get policy events in current subscription scope, with OrderBy, Top and Select query options
```powershell
Get-AzPolicyEvent -OrderBy "Timestamp desc, PolicyAssignmentName asc" -Top 5 -Select "Timestamp, ResourceId, PolicyAssignmentId, PolicySetDefinitionId, PolicyDefinitionId"
```

Gets policy event records generated in the last day for all resources within the subscription in current session context. 
The command orders the results by timestamp and policy assignment name properties, and takes only top 5 of those listed in that order.
It also selects to list only a subset of the columns for each record.

+ Example 15: Get policy events in current subscription scope, with From and To query options
```powershell
Get-AzPolicyEvent -From "2018-03-08 00:00:00Z" -To "2018-03-15 00:00:00Z"
```

Gets policy event records generated within the date range specified for all resources within the subscription in current session context.

+ Example 16: Get policy events in current subscription scope, with Filter query option
```powershell
Get-AzPolicyEvent -Filter "(PolicyDefinitionAction eq 'deny' or PolicyDefinitionAction eq 'audit') and ResourceLocation ne 'eastus'"
```

Gets policy event records generated in the last day for all resources within the subscription in current session context.
The command limits the results returned by filtering based on policy definition action (includes deny or audit actions) and resource location (excludes eastus location).

+ Example 17: Get policy events in current subscription scope, with Apply specifying row count aggregation
```powershell
Get-AzPolicyEvent -Apply "aggregate(`$count as NumberOfRecords)"
```

Gets the number of policy event records generated in the last day for all resources within the subscription in current session context.
The command returns the count of the policy event records only, which is returned inside AdditionalProperties property.

+ Example 18: Get policy events in current subscription scope, with Apply specifying grouping with aggregation
```powershell
Get-AzPolicyEvent -Filter "PolicyDefinitionAction eq 'audit' or PolicyDefinitionAction eq 'deny'" -Apply "groupby((PolicyAssignmentId, PolicyDefinitionId, PolicyDefinitionAction, ResourceId), aggregate(`$count as NumEvents))" -OrderBy "NumEvents desc" -Top 5
```

Gets policy event records generated in the last day for all resources within the subscription in current session context. 
The command limits the results returned by filtering based on policy definition action (includes only audit and deny events).
It groups the results based on policy assignment, policy definition, policy definition action, and resource id, and computes the number of records in each group, which is returned inside AdditionalProperties property.
It orders the results by the count aggregation in descending order, and takes only top 5 of those listed in that order.

+ Example 19: Get policy events in current subscription scope, with Apply specifying grouping without aggregation
```powershell
Get-AzPolicyEvent -Filter "PolicyDefinitionAction eq 'audit' or PolicyDefinitionAction eq 'deny'" -Apply "groupby((ResourceId))"
```

Gets policy event records generated in the last day for all resources within the subscription in current session context. 
The command limits the results returned by filtering based on policy definition action (includes only audit and deny events).
It groups the results based on resource id.
This generates the list of all resources within the subscription that generated a policy event for at least one audit or deny policy.

+ Example 20: Get policy events in current subscription scope, with Apply specifying multiple groupings
```powershell
Get-AzPolicyEvent -Filter "PolicyDefinitionAction eq 'deny'" -Apply "groupby((PolicyAssignmentId, PolicyDefinitionId, ResourceId))/groupby((PolicyAssignmentId, PolicyDefinitionId), aggregate(`$count as NumDeniedResources))" -OrderBy "NumDeniedResources desc" -Top 5
```

Gets policy event records generated in the last day for all resources within the subscription in current session context. 
The command limits the results returned by filtering based on policy definition action (includes only deny events).
It groups the results first based on policy assignment, policy definition, and resource id. 
Then, it further groups the results of this grouping with the same properties except for resource id, and computes the number of records in each of these groups, which is returned inside AdditionalProperties property.
It orders the results by the count aggregation in descending order, and takes only top 5 of those listed in that order.
This generates the top 5 deny policies with the most number of denied resources.


#### Get-AzPolicyMetadata

#### SYNOPSIS
Gets Policy Metadata resources

#### SYNTAX

```powershell
Get-AzPolicyMetadata [-Name <String>] [-Top <Int32>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Get all policy metadata resources
```powershell
Get-AzPolicyMetadata
```

This command gets all policy metadata resources

+ Example 2: Get a collection of 10 policy metadata resources
```powershell
Get-AzPolicyMetadata -Top 10
```

This command gets a collection of 10 policy metadata resources

+ Example 3: Get a single policy metadata resource with the name 'ACF1348'
```powershell
Get-AzPolicyMetadata -Name ACF1348
```

This command gets a single policy metadata resource with the name 'ACF1348'


#### Get-AzPolicyRemediation

#### SYNOPSIS
Gets policy remediations.

#### SYNTAX

+ SubscriptionScope (Default)
```powershell
Get-AzPolicyRemediation [-Top <Int32>] [-Filter <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

+ ByName
```powershell
Get-AzPolicyRemediation -Name <String> [-Scope <String>] [-ManagementGroupName <String>]
 [-ResourceGroupName <String>] [-Top <Int32>] [-IncludeDetail] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

+ GenericScope
```powershell
Get-AzPolicyRemediation -Scope <String> [-Top <Int32>] [-Filter <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

+ ManagementGroupScope
```powershell
Get-AzPolicyRemediation -ManagementGroupName <String> [-Top <Int32>] [-Filter <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

+ ResourceGroupScope
```powershell
Get-AzPolicyRemediation -ResourceGroupName <String> [-Top <Int32>] [-Filter <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

+ ByResourceId
```powershell
Get-AzPolicyRemediation -ResourceId <String> [-Top <Int32>] [-IncludeDetail]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Get all policy remediations in the current subscription
```powershell
Set-AzContext -Subscription "My Subscription"
Get-AzPolicyRemediation
```

This command gets all the remediations created at or underneath a subscription named 'My Subscription'.

+ Example 2: Get a specific policy remediation and the deployment details
```powershell
Get-AzPolicyRemediation -ResourceGroupName "myResourceGroup" -Name "remediation1" -IncludeDetail
```

This command gets the remediation named 'remediation1' from resource group 'myResourceGroup'. The details of the resources being remediated will be included.

+ Example 3: Get 10 policy remediations in a management group with optional filters
```powershell
Get-AzPolicyRemediation -ManagementGroupName "mg1" -Top 10 -Filter "PolicyAssignmentId eq '/providers/Microsoft.Management/managementGroups/mg1/providers/Microsoft.Authorization/policyAssignments/pa1'"
```

This command gets a max of 10 policy remediations from a management group named 'mg1'. Only policy remediations for the given policy assignment will be retrieved.


#### Remove-AzPolicyRemediation

#### SYNOPSIS
Deletes a policy remediation.

#### SYNTAX

+ ByName (Default)
```powershell
Remove-AzPolicyRemediation -Name <String> [-Scope <String>] [-ManagementGroupName <String>]
 [-ResourceGroupName <String>] [-AllowStop] [-AsJob] [-PassThru] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

+ ByResourceId
```powershell
Remove-AzPolicyRemediation -ResourceId <String> [-AllowStop] [-AsJob] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

+ ByInputObject
```powershell
Remove-AzPolicyRemediation -InputObject <PSRemediation> [-AllowStop] [-AsJob] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Delete a policy remediation at resource group scope
```powershell
Remove-AzPolicyRemediation -ResourceGroupName "myRG" -Name "remediation1"
```

This command deletes the remediation named 'remediation1' in resource group 'myRG'.

+ Example 2: Delete a management group remediation via piping
```powershell
$remediation = Get-AzPolicyRemediation -ManagementGroupName "mg1" -Name "remediation1"
$remediation | Remove-AzPolicyRemediation -Confirm
```

This command deletes the remediation named 'remediation1' from management group 'mg1'. A confirmation prompt will be presented before deleting the resource.

+ Example 3: Cancel and delete a policy remediation
```powershell
Remove-AzPolicyRemediation -ResourceGroupName "myRG" -Name "remediation1" -AllowStop
```

This command deletes the remediation named 'remediation1' in resource group 'myRG'. If the remediation is in-progress it will be canceled before being deleted.


#### Start-AzPolicyRemediation

#### SYNOPSIS
Creates and starts a policy remediation for a policy assignment.

#### SYNTAX

+ ByName (Default)
```powershell
Start-AzPolicyRemediation -Name <String> [-Scope <String>] [-ManagementGroupName <String>]
 [-ResourceGroupName <String>] -PolicyAssignmentId <String> [-PolicyDefinitionReferenceId <String>]
 [-LocationFilter <String[]>] [-ResourceDiscoveryMode <String>] [-ResourceCount <Int32>]
 [-ParallelDeploymentCount <Int32>] [-FailureThreshold <Double>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

+ ByResourceId
```powershell
Start-AzPolicyRemediation -ResourceId <String> -PolicyAssignmentId <String>
 [-PolicyDefinitionReferenceId <String>] [-LocationFilter <String[]>] [-ResourceDiscoveryMode <String>]
 [-ResourceCount <Int32>] [-ParallelDeploymentCount <Int32>] [-FailureThreshold <Double>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Start a remediation at subscription scope
```powershell
$policyAssignmentId = "/subscriptions/f0710c27-9663-4c05-19f8-1b4be01e86a5/providers/Microsoft.Authorization/policyAssignments/2deae24764b447c29af7c309"
Set-AzContext -Subscription "My Subscription"
Start-AzPolicyRemediation -PolicyAssignmentId $policyAssignmentId -Name "remediation1"
```

This command creates a new policy remediation in subscription 'My Subscription' for the given policy assignment.

+ Example 2: Start a remediation at management group scope with optional filters
```powershell
$policyAssignmentId = "/providers/Microsoft.Management/managementGroups/mg1/providers/Microsoft.Authorization/policyAssignments/pa1"
Start-AzPolicyRemediation -ManagementGroupName "mg1" -PolicyAssignmentId $policyAssignmentId -Name "remediation1" -LocationFilter "westus","eastus"
```

This command creates a new policy remediation in management group 'mg1' for the given policy assignment. Only resources in the 'westus' or 'eastus' locations will be remediated.

+ Example 3: Start a remediation at resource group scope for a policy set definition assignment
```powershell
$policyAssignmentId = "/subscriptions/f0710c27-9663-4c05-19f8-1b4be01e86a5/resourceGroups/myRG/providers/Microsoft.Authorization/policyAssignments/2deae24764b447c29af7c309"
Start-AzPolicyRemediation -ResourceGroupName "myRG" -PolicyAssignmentId $policyAssignmentId -PolicyDefinitionReferenceId "0349234412441" -Name "remediation1"
```

This command creates a new policy remediation in resource group 'myRG' for the given policy assignment. The policy assignment assigns a policy set definition (also known as an initiative). The policy definition reference ID indicates which policy within the initiative should be remediated.

+ Example 4: Start a remediation and wait for it to complete in the background
```powershell
$policyAssignmentId = "/subscriptions/f0710c27-9663-4c05-19f8-1b4be01e86a5/providers/Microsoft.Authorization/policyAssignments/2deae24764b447c29af7c309"
Set-AzContext -Subscription f0710c27-9663-4c05-19f8-1b4be01e86a5
$job = Start-AzPolicyRemediation -PolicyAssignmentId $policyAssignmentId -Name "remediation1" -AsJob
$job | Wait-Job
$remediation = $job | Receive-Job
```

This command starts a new policy remediation in subscription 'My Subscription' for the given policy assignment. It will wait for the remediation to complete before returning the final remediation status.

+ Example 5: Start a remediation that will discover non-compliant resources before remediating
```powershell
$policyAssignmentId = "/subscriptions/f0710c27-9663-4c05-19f8-1b4be01e86a5/providers/Microsoft.Authorization/policyAssignments/2deae24764b447c29af7c309"
Set-AzContext -Subscription "My Subscription"
Start-AzPolicyRemediation -PolicyAssignmentId $policyAssignmentId -Name "remediation1" -ResourceDiscoveryMode ReEvaluateCompliance
```

This command creates a new policy remediation in subscription 'My Subscription' for the given policy assignment. The compliance state of resources in the subscription will be re-evaluated against the policy assignment and non-compliant resources will be remediated.

+ Example 6: Start a remediation that will remediate up to 10,000 non-compliant resources
```powershell
$policyAssignmentId = "/subscriptions/f0710c27-9663-4c05-19f8-1b4be01e86a5/providers/Microsoft.Authorization/policyAssignments/2deae24764b447c29af7c309"
Set-AzContext -Subscription "My Subscription"
Start-AzPolicyRemediation -PolicyAssignmentId $policyAssignmentId -Name "remediation1" -ResourceCount 10000
```

+ Example 7: Start a remediation that will remediate 30 resources in parallel
```powershell
$policyAssignmentId = "/subscriptions/f0710c27-9663-4c05-19f8-1b4be01e86a5/providers/Microsoft.Authorization/policyAssignments/2deae24764b447c29af7c309"
Set-AzContext -Subscription "My Subscription"
Start-AzPolicyRemediation -PolicyAssignmentId $policyAssignmentId -Name "remediation1" -ParallelDeploymentCount 30
```

+ Example 8: Start a remediation that will terminate if more than half of the remediation deployments fail
```powershell
$policyAssignmentId = "/subscriptions/f0710c27-9663-4c05-19f8-1b4be01e86a5/providers/Microsoft.Authorization/policyAssignments/2deae24764b447c29af7c309"
Set-AzContext -Subscription "My Subscription"
Start-AzPolicyRemediation -PolicyAssignmentId $policyAssignmentId -Name "remediation1" -FailureThreshold 0.5
```


#### Stop-AzPolicyRemediation

#### SYNOPSIS
Cancels an in-progress policy remediation.

#### SYNTAX

+ ByName (Default)
```powershell
Stop-AzPolicyRemediation -Name <String> [-Scope <String>] [-ManagementGroupName <String>]
 [-ResourceGroupName <String>] [-AsJob] [-PassThru] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

+ ByResourceId
```powershell
Stop-AzPolicyRemediation -ResourceId <String> [-AsJob] [-PassThru] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

+ ByInputObject
```powershell
Stop-AzPolicyRemediation -InputObject <PSRemediation> [-AsJob] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Cancel a policy remediation at resource group scope
```powershell
Stop-AzPolicyRemediation -ResourceGroupName "myRG" -Name "remediation1"
```

This command cancels the remediation named 'remediation1' in resource group 'myRG'.

+ Example 2: Cancel a management group remediation via piping
```powershell
$remediation = Get-AzPolicyRemediation -ManagementGroupName "mg1" -Name "remediation1"
$remediation | Stop-AzPolicyRemediation
```

This command cancels the remediation named 'remediation1' in management group 'mg1'.


#### Get-AzPolicyState

#### SYNOPSIS
Gets policy compliance states for resources.

#### SYNTAX

+ SubscriptionScope (Default)
```powershell
Get-AzPolicyState [-All] [-SubscriptionId <String>] [-Top <Int32>] [-OrderBy <String>] [-Select <String>]
 [-From <DateTime>] [-To <DateTime>] [-Filter <String>] [-Apply <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

+ ManagementGroupScope
```powershell
Get-AzPolicyState [-All] -ManagementGroupName <String> [-Top <Int32>] [-OrderBy <String>] [-Select <String>]
 [-From <DateTime>] [-To <DateTime>] [-Filter <String>] [-Apply <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

+ ResourceGroupScope
```powershell
Get-AzPolicyState [-All] [-SubscriptionId <String>] -ResourceGroupName <String> [-Top <Int32>]
 [-OrderBy <String>] [-Select <String>] [-From <DateTime>] [-To <DateTime>] [-Filter <String>]
 [-Apply <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

+ ResourceScope
```powershell
Get-AzPolicyState [-All] -ResourceId <String> [-Top <Int32>] [-OrderBy <String>] [-Select <String>]
 [-From <DateTime>] [-To <DateTime>] [-Filter <String>] [-Apply <String>] [-Expand <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

+ PolicySetDefinitionScope
```powershell
Get-AzPolicyState [-All] [-SubscriptionId <String>] -PolicySetDefinitionName <String> [-Top <Int32>]
 [-OrderBy <String>] [-Select <String>] [-From <DateTime>] [-To <DateTime>] [-Filter <String>]
 [-Apply <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

+ PolicyDefinitionScope
```powershell
Get-AzPolicyState [-All] [-SubscriptionId <String>] -PolicyDefinitionName <String> [-Top <Int32>]
 [-OrderBy <String>] [-Select <String>] [-From <DateTime>] [-To <DateTime>] [-Filter <String>]
 [-Apply <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

+ SubscriptionLevelPolicyAssignmentScope
```powershell
Get-AzPolicyState [-All] [-SubscriptionId <String>] -PolicyAssignmentName <String> [-Top <Int32>]
 [-OrderBy <String>] [-Select <String>] [-From <DateTime>] [-To <DateTime>] [-Filter <String>]
 [-Apply <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

+ ResourceGroupLevelPolicyAssignmentScope
```powershell
Get-AzPolicyState [-All] [-SubscriptionId <String>] -ResourceGroupName <String> -PolicyAssignmentName <String>
 [-Top <Int32>] [-OrderBy <String>] [-Select <String>] [-From <DateTime>] [-To <DateTime>] [-Filter <String>]
 [-Apply <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Get latest policy states in current subscription scope
```powershell
Get-AzPolicyState
```

Gets latest policy state records generated in the last day for all resources within the subscription in current session context.

+ Example 2: Get latest policy states in the specified subscription scope
```powershell
Get-AzPolicyState -SubscriptionId "fff10b27-fff3-fff5-fff8-fffbe01e86a5"
```

Gets latest policy state records generated in the last day for all resources within the specified subscription.

+ Example 3: Get all policy states in current subscription scope
```powershell
Get-AzPolicyState -All
```

Gets all historical policy state records (including latest) generated in the last day for all resources within the subscription in current session context.

+ Example 4: Get latest policy states in management group scope
```powershell
Get-AzPolicyState -ManagementGroupName "myManagementGroup"
```

Gets latest policy state records generated in the last day for all resources within the specified management group.

+ Example 5: Get latest policy states in resource group scope in current subscription
```powershell
Get-AzPolicyState -ResourceGroupName "myResourceGroup"
```

Gets latest policy state records generated in the last day for all resources within the specified resource group (in the subscription in current session context).

+ Example 6: Get latest policy states in resource group scope in the specified subscription
```powershell
Get-AzPolicyState -SubscriptionId "fff10b27-fff3-fff5-fff8-fffbe01e86a5" -ResourceGroupName "myResourceGroup"
```

Gets latest policy state records generated in the last day for all resources within the specified resource group (in the specified subscription).

+ Example 7: Get latest policy states for a resource
```powershell
Get-AzPolicyState -ResourceId "/subscriptions/fff10b27-fff3-fff5-fff8-fffbe01e86a5/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myns1/eventhubs/eh1/consumergroups/cg1"
```

Gets latest policy state records generated in the last day for the specified resource.

+ Example 8: Get latest policy states for a policy set definition in current subscription
```powershell
Get-AzPolicyState -PolicySetDefinitionName "fff58873-fff8-fff5-fffc-fffbe7c9d697"
```

Gets latest policy state records generated in the last day for all resources (within the tenant in current session context) effected by the specified policy set definition (that exists in the subscription in current session context).

+ Example 9: Get latest policy states for a policy set definition in the specified subscription
```powershell
Get-AzPolicyState -SubscriptionId "fff10b27-fff3-fff5-fff8-fffbe01e86a5" -PolicySetDefinitionName "fff58873-fff8-fff5-fffc-fffbe7c9d697"
```

Gets latest policy state records generated in the last day for all resources (within the tenant in current session context) effected by the specified policy set definition (that exists in the specified subscription).

+ Example 10: Get latest policy states for a policy definition in current subscription
```powershell
Get-AzPolicyState -PolicyDefinitionName "fff58873-fff8-fff5-fffc-fffbe7c9d697"
```

Gets latest policy state records generated in the last day for all resources (within the tenant in current session context) effected by the specified policy definition (that exists in the subscription in current session context).

+ Example 11: Get latest policy states for a policy definition in the specified subscription
```powershell
Get-AzPolicyState -SubscriptionId "fff10b27-fff3-fff5-fff8-fffbe01e86a5" -PolicyDefinitionName "fff58873-fff8-fff5-fffc-fffbe7c9d697"
```

Gets latest policy state records generated in the last day for all resources (within the tenant in current session context) effected by the specified policy definition (that exists in the specified subscription).

+ Example 12: Get latest policy states for a policy assignment in current subscription
```powershell
Get-AzPolicyState -PolicyAssignmentName "ddd8ef92e3714a5ea3d208c1"
```

Gets latest policy state records generated in the last day for all resources (within the tenant in current session context) effected by the specified policy assignment (that exists at subscription scope in the subscription in current session context).

+ Example 13: Get latest policy states for a policy assignment with the same scope as the specified subscription
```powershell
Get-AzPolicyState -SubscriptionId "fff10b27-fff3-fff5-fff8-fffbe01e86a5" -PolicyAssignmentName "ddd8ef92e3714a5ea3d208c1"
```

Gets latest policy state records generated in the last day for all resources (within the tenant in current session context) effected by the specified policy assignment (that exists at subscription scope in the specified subscription).

+ Example 14: Get latest policy states for a policy assignment in the specified resource group in the current subscription
```powershell
Get-AzPolicyState -ResourceGroupName "myResourceGroup" -PolicyAssignmentName "ddd8ef92e3714a5ea3d208c1"
```

Gets latest policy state records generated in the last day for all resources (within the tenant in current session context) effected by the specified policy assignment (that exists in the resource group in the subscription in current session context).

+ Example 15: Get latest policy states in current subscription scope, with OrderBy, Top and Select query options
```powershell
Get-AzPolicyState -OrderBy "Timestamp desc, PolicyAssignmentName asc" -Top 5 -Select "Timestamp, ResourceId, PolicyAssignmentId, PolicySetDefinitionId, PolicyDefinitionId, IsCompliant"
```

Gets latest policy state records generated in the last day for all resources within the subscription in current session context. 
The command orders the results by timestamp and policy assignment name properties, and takes only top 5 of those listed in that order.
It also selects to list only a subset of the columns for each record.

+ Example 16: Get latest policy states in current subscription scope, with From and To query options
```powershell
Get-AzPolicyState -From "2018-03-08 00:00:00Z" -To "2018-03-15 00:00:00Z"
```

Gets latest policy state records generated within the date range specified for all resources within the subscription in current session context.

+ Example 17: Get latest policy states in current subscription scope, with Filter query option
```powershell
Get-AzPolicyState -Filter "(PolicyDefinitionAction eq 'deny' or PolicyDefinitionAction eq 'audit') and ComplianceState eq 'NonCompliant' and ResourceLocation ne 'eastus'"
```

Gets latest policy state records generated in the last day for all resources within the subscription in current session context.
The command limits the results returned by filtering based on policy definition action (includes deny or audit actions), compliance status (includes only non-compliant status) and resource location (excludes eastus location).

+ Example 18: Get latest policy states in current subscription scope, with Apply specifying row count aggregation
```powershell
Get-AzPolicyState -Apply "aggregate(`$count as NumberOfRecords)"
```

Gets the number of latest policy state records generated in the last day for all resources within the subscription in current session context.
The command returns the count of the policy state records only, which is returned inside AdditionalProperties property.

+ Example 19: Get latest policy states in current subscription scope, with Apply specifying grouping with aggregation
```powershell
Get-AzPolicyState -Filter "ComplianceState eq 'NonCompliant'" -Apply "groupby((PolicyAssignmentId, PolicySetDefinitionId, PolicyDefinitionReferenceId, PolicyDefinitionId), aggregate(`$count as NumStates))" -OrderBy "NumStates desc" -Top 5
```

Gets latest policy state records generated in the last day for all resources within the subscription in current session context. 
The command limits the results returned by filtering based on compliance status (includes only non-compliant status).
It groups the results based on policy assignment, policy set definition, and policy definition, and computes the number of records in each group, which is returned inside AdditionalProperties property.
It orders the results by the count aggregation in descending order, and takes only top 5 of those listed in that order.

+ Example 20: Get latest policy states in current subscription scope, with Apply specifying grouping without aggregation
```powershell
Get-AzPolicyState -Filter "ComplianceState eq 'NonCompliant'" -Apply "groupby((ResourceId))"
```

Gets latest policy state records generated in the last day for all resources within the subscription in current session context. 
The command limits the results returned by filtering based on compliance status (includes only non-compliant status).
It groups the results based on resource id.
This generates the list of all resources within the subscription that are non-compliant for at least one policy.

+ Example 21: Get latest policy states in current subscription scope, with Apply specifying multiple groupings
```powershell
Get-AzPolicyState -Filter "ComplianceState eq 'NonCompliant'" -Apply "groupby((PolicyAssignmentId, PolicySetDefinitionId, PolicyDefinitionReferenceId, PolicyDefinitionId, ResourceId))/groupby((PolicyAssignmentId, PolicySetDefinitionId, PolicyDefinitionReferenceId, PolicyDefinitionId), aggregate(`$count as NumNonCompliantResources))" -OrderBy "NumNonCompliantResources desc" -Top 5
```

Gets latest policy state records generated in the last day for all resources within the subscription in current session context. 
The command limits the results returned by filtering based on compliance status (includes only non-compliant status).
It groups the results first based on policy assignment, policy set definition, policy definition, and resource id. 
Then, it further groups the results of this grouping with the same properties except for resource id, and computes the number of records in each of these groups, which is returned inside AdditionalProperties property.
It orders the results by the count aggregation in descending order, and takes only top 5 of those listed in that order.
This generates the top 5 policies with the most number of non-compliant resources.

+ Example 22: Get latest policy states including policy evaluation details for a resource
```powershell
Get-AzPolicyState -ResourceId "/subscriptions/fff10b27-fff3-fff5-fff8-fffbe01e86a5/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myns1/eventhubs/eh1/consumergroups/cg1" -Expand "PolicyEvaluationDetails"
```

Gets latest policy state records generated in the last day for the specified resource and expand policyEvaluationDetails.

+ Example 23: Get latest component policy states for a resource (eg. vault) given a resource provider mode policy assignment
```powershell
Get-AzPolicyState -ResourceId "/subscriptions/fff10b27-fff3-fff5-fff8-fffbe01e86a5/resourceGroups/myResourceGroup/providers/Microsoft.KeyVault/vaults/myvault" -Filter "policyAssignmentId eq '/subscriptions/fff10b27-fff3-fff5-fff8-fffbe01e86a5/providers/Microsoft.Authorization/policyAssignments/ddd8ef92e3714a5ea3d208c1'" -Expand "Components(`$filter=ComplianceState eq 'NonCompliant' or ComplianceState eq 'Compliant')"
```

Gets latest component policy state records generated in the last day for the specified resource, given a resource provider mode policy assignment that references a resource provider mode policy definition.

+ Example 24: Get latest component policy states for a resource (eg. vault) given a policy initiative assignment that contains a resource provider mode policy definition
```powershell
Get-AzPolicyState -ResourceId "/subscriptions/fff10b27-fff3-fff5-fff8-fffbe01e86a5/resourceGroups/myResourceGroup/providers/Microsoft.KeyVault/vaults/myvault" -Filter "policyAssignmentId eq '/subscriptions/fff10b27-fff3-fff5-fff8-fffbe01e86a5/providers/Microsoft.Authorization/policyAssignments/ddd8ef92e3714a5ea3d208c1' and policyDefinitionReferenceId eq 'myResourceProviderModeDefinitionReferenceId'" -Expand "Components(`$filter=ComplianceState eq 'NonCompliant' or ComplianceState eq 'Compliant')"
```

Gets latest component policy state records generated in the last day for the specified resource, given a resource provider mode policy assignment that references an initiative containing a resource provider mode policy definition.

+ Example 25: Get latest component counts by compliance state for a resource (eg. vault) given a resource provider mode policy assignment
```powershell
Get-AzPolicyState -ResourceId "/subscriptions/fff10b27-fff3-fff5-fff8-fffbe01e86a5/resourceGroups/myResourceGroup/providers/Microsoft.KeyVault/vaults/myvault" -Filter "policyAssignmentId eq '/subscriptions/fff10b27-fff3-fff5-fff8-fffbe01e86a5/providers/Microsoft.Authorization/policyAssignments/ddd8ef92e3714a5ea3d208c1'" -Expand "Components(`$filter=ComplianceState eq 'NonCompliant' or ComplianceState eq 'Compliant' or ComplianceState eq 'Conflict';`$apply=groupby((complianceState),aggregate(`$count as count)))"
```

Gets latest component counts generated in the last day grouped by compliance state for the specified resource, given a resource provider mode policy assignment.

+ Example 26: Get policy states for a management group scope policy assignment
```powershell
Get-AzPolicyState -SubscriptionId "fff10b27-fff3-fff5-fff8-fffbe01e86a5" -Filter "policyAssignmentId eq '/providers/Microsoft.Management/managementGroups/myManagementGroup/providers/Microsoft.Authorization/policyAssignments/ddd8ef92e3714a5ea3d208c1'"
```

Gets latest policy state records generated in the last day for all resources (within the tenant in current session context) in the specified subscription affected by the specified policy assignment (which is assigned to a management group which is an ancestor of the specified subscription).


#### Get-AzPolicyStateSummary

#### SYNOPSIS
Gets latest policy compliance states summary for resources.

#### SYNTAX

+ SubscriptionScope (Default)
```powershell
Get-AzPolicyStateSummary [-SubscriptionId <String>] [-Top <Int32>] [-From <DateTime>] [-To <DateTime>]
 [-Filter <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

+ ManagementGroupScope
```powershell
Get-AzPolicyStateSummary -ManagementGroupName <String> [-Top <Int32>] [-From <DateTime>] [-To <DateTime>]
 [-Filter <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

+ ResourceGroupScope
```powershell
Get-AzPolicyStateSummary [-SubscriptionId <String>] -ResourceGroupName <String> [-Top <Int32>]
 [-From <DateTime>] [-To <DateTime>] [-Filter <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

+ PolicySetDefinitionScope
```powershell
Get-AzPolicyStateSummary [-SubscriptionId <String>] -PolicySetDefinitionName <String> [-Top <Int32>]
 [-From <DateTime>] [-To <DateTime>] [-Filter <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

+ PolicyDefinitionScope
```powershell
Get-AzPolicyStateSummary [-SubscriptionId <String>] -PolicyDefinitionName <String> [-Top <Int32>]
 [-From <DateTime>] [-To <DateTime>] [-Filter <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

+ SubscriptionLevelPolicyAssignmentScope
```powershell
Get-AzPolicyStateSummary [-SubscriptionId <String>] -PolicyAssignmentName <String> [-Top <Int32>]
 [-From <DateTime>] [-To <DateTime>] [-Filter <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

+ ResourceGroupLevelPolicyAssignmentScope
```powershell
Get-AzPolicyStateSummary [-SubscriptionId <String>] -ResourceGroupName <String> -PolicyAssignmentName <String>
 [-Top <Int32>] [-From <DateTime>] [-To <DateTime>] [-Filter <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

+ ResourceScope
```powershell
Get-AzPolicyStateSummary -ResourceId <String> [-Top <Int32>] [-From <DateTime>] [-To <DateTime>]
 [-Filter <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Get latest non-compliant policy states summary in current subscription scope
```powershell
Get-AzPolicyStateSummary
```

Gets the summary view of latest policy compliance states generated in the last day for all resources within the subscription in current session context.

+ Example 2: Get latest non-compliant policy states summary in the specified subscription scope
```powershell
Get-AzPolicyStateSummary -SubscriptionId "fff10b27-fff3-fff5-fff8-fffbe01e86a5"
```

Gets the summary view of latest policy compliance states generated in the last day for all resources within the specified subscription.

+ Example 3: Get latest non-compliant policy states summary in management group scope
```powershell
Get-AzPolicyStateSummary -ManagementGroupName "myManagementGroup"
```

Gets the summary view of latest policy compliance states generated in the last day for all resources within the specified management group.

+ Example 4: Get latest non-compliant policy states summary in resource group scope in current subscription
```powershell
Get-AzPolicyStateSummary -ResourceGroupName "myResourceGroup"
```

Gets the summary view of latest policy compliance states generated in the last day for all resources within the specified resource group (in the subscription in current session context).

+ Example 5: Get latest non-compliant policy states summary in resource group scope in the specified subscription
```powershell
Get-AzPolicyStateSummary -SubscriptionId "fff10b27-fff3-fff5-fff8-fffbe01e86a5" -ResourceGroupName "myResourceGroup"
```

Gets the summary view of latest policy compliance states generated in the last day for all resources within the specified resource group (in the specified subscription).

+ Example 6: Get latest non-compliant policy states summary for a resource
```powershell
Get-AzPolicyStateSummary -ResourceId "/subscriptions/fff10b27-fff3-fff5-fff8-fffbe01e86a5/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myns1/eventhubs/eh1/consumergroups/cg1"
```

Gets the summary view of latest policy compliance states generated in the last day for the specified resource.

+ Example 7: Get latest non-compliant policy states summary for a policy set definition in current subscription
```powershell
Get-AzPolicyStateSummary -PolicySetDefinitionName "fff58873-fff8-fff5-fffc-fffbe7c9d697"
```

Gets the summary view of latest policy compliance states generated in the last day for all resources (within the tenant in current session context) effected by the specified policy set definition (that exists in the subscription in current session context).

+ Example 8: Get latest non-compliant policy states summary for a policy set definition in the specified subscription
```powershell
Get-AzPolicyStateSummary -SubscriptionId "fff10b27-fff3-fff5-fff8-fffbe01e86a5" -PolicySetDefinitionName "fff58873-fff8-fff5-fffc-fffbe7c9d697"
```

Gets the summary view of latest policy compliance states generated in the last day for all resources (within the tenant in current session context) effected by the specified policy set definition (that exists in the specified subscription).

+ Example 9: Get latest non-compliant policy states summary for a policy definition in current subscription
```powershell
Get-AzPolicyStateSummary -PolicyDefinitionName "fff58873-fff8-fff5-fffc-fffbe7c9d697"
```

Gets the summary view of latest policy compliance states generated in the last day for all resources (within the tenant in current session context) effected by the specified policy definition (that exists in the subscription in current session context).

+ Example 10: Get latest non-compliant policy states summary for a policy definition in the specified subscription
```powershell
Get-AzPolicyStateSummary -SubscriptionId "fff10b27-fff3-fff5-fff8-fffbe01e86a5" -PolicyDefinitionName "fff58873-fff8-fff5-fffc-fffbe7c9d697"
```

Gets the summary view of latest policy compliance states generated in the last day for all resources (within the tenant in current session context) effected by the specified policy definition (that exists in the specified subscription).

+ Example 11: Get latest non-compliant policy states summary for a policy assignment in current subscription
```powershell
Get-AzPolicyStateSummary -PolicyAssignmentName "ddd8ef92e3714a5ea3d208c1"
```

Gets the summary view of latest policy compliance states generated in the last day for all resources (within the tenant in current session context) effected by the specified policy assignment (that exists in the subscription in current session context).

+ Example 12: Get latest non-compliant policy states summary for a policy assignment in the specified subscription
```powershell
Get-AzPolicyStateSummary -SubscriptionId "fff10b27-fff3-fff5-fff8-fffbe01e86a5" -PolicyAssignmentName "ddd8ef92e3714a5ea3d208c1"
```

Gets the summary view of latest policy compliance states generated in the last day for all resources (within the tenant in current session context) effected by the specified policy assignment (that exists in the specified subscription).

+ Example 13: Get latest non-compliant policy states summary for a policy assignment in the specified resource group in the current subscription
```powershell
Get-AzPolicyStateSummary -ResourceGroupName "myResourceGroup" -PolicyAssignmentName "ddd8ef92e3714a5ea3d208c1"
```

Gets the summary view of latest policy compliance states generated in the last day for all resources (within the tenant in current session context) effected by the specified policy assignment (that exists in the resource group in the subscription in current session context).

+ Example 14: Get latest non-compliant policy states summary in current subscription scope, with Top query option
```powershell
Get-AzPolicyStateSummary -Top 5
```

Gets the summary view of latest policy compliance states generated in the last day for all resources within the subscription in current session context. 
The command orders the policy assignment summaries in the results by non-compliant resource counts in descending order, and takes only top 5 of those policy assignment summaries.

+ Example 15: Get latest non-compliant policy states summary in current subscription scope, with From and To query options
```powershell
Get-AzPolicyStateSummary -From "2018-03-08 00:00:00Z" -To "2018-03-15 00:00:00Z"
```

Gets the summary view of latest policy compliance states generated within the date range specified for all resources within the subscription in current session context.

+ Example 16: Get latest non-compliant policy states summary in current subscription scope, with Filter query option
```powershell
Get-AzPolicyStateSummary -Filter "(PolicyDefinitionAction eq 'deny' or PolicyDefinitionAction eq 'audit') and ResourceLocation ne 'eastus'"
```

Gets the summary view of latest policy compliance states generated in the last day for all resources within the subscription in current session context.
The command limits the results returned by filtering based on policy definition action (includes deny or audit actions), and resource location (excludes eastus location).


