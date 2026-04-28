function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}
function Start-TestSleep {
    [CmdletBinding(DefaultParameterSetName = 'SleepBySeconds')]
    param(
        [parameter(Mandatory = $true, Position = 0, ParameterSetName = 'SleepBySeconds')]
        [ValidateRange(0.0, 2147483.0)]
        [double] $Seconds,

        [parameter(Mandatory = $true, ParameterSetName = 'SleepByMilliseconds')]
        [ValidateRange('NonNegative')]
        [Alias('ms')]
        [int] $Milliseconds
    )

    if ($TestMode -ne 'playback') {
        switch ($PSCmdlet.ParameterSetName) {
            'SleepBySeconds' {
                Start-Sleep -Seconds $Seconds
            }
            'SleepByMilliseconds' {
                Start-Sleep -Milliseconds $Milliseconds
            }
        }
    }
}

<#
.SYNOPSIS
Gets test query interval start, which is 5 days before the current time of live running the tests. 
#>
function Get-TestQueryIntervalStart {
   Get-Date -Format "yyyy-MM-dd HH:mm:ssZ" -Date (Get-Date -AsUTC).AddDays(-5)
}

<#
.SYNOPSIS
Gets test query interval end, which is the UTC time at time of live running the tests.
#>
function Get-TestQueryIntervalEnd {
   Get-Date -Format "yyyy-MM-dd HH:mm:ssZ" -AsUTC
}

<#
.SYNOPSIS
Validates a list of policy events
#>
function Validate-PolicyEvents {
   param([System.Collections.Generic.List`1[[Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Models.IPolicyEvent]]]$policyEvents, [int]$count)

   Assert-True { $count -ge $policyEvents.Count }
   Assert-True { $policyEvents.Count -gt 0 }
   Foreach ($policyEvent in $policyEvents) {
      Validate-PolicyEvent $policyEvent
   }
}

<#
.SYNOPSIS
Validates a policy event
#>
function Validate-PolicyEvent {
   param([Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Models.IPolicyEvent]$policyEvent)

   Assert-NotNull $policyEvent

   Assert-NotNull $policyEvent.Timestamp
   Assert-NotNullOrEmpty $policyEvent.ResourceId
   Assert-NotNullOrEmpty $policyEvent.PolicyAssignmentId
   Assert-NotNullOrEmpty $policyEvent.PolicyDefinitionId
   Assert-NotNull $policyEvent.IsCompliant
   Assert-NotNullOrEmpty $policyEvent.SubscriptionId
   Assert-NotNullOrEmpty $policyEvent.PolicyDefinitionAction
   Assert-NotNullOrEmpty $policyEvent.TenantId
   Assert-NotNullOrEmpty $policyEvent.PrincipalOid
}

<#
.SYNOPSIS
Validates a list of policy states
#>
function Validate-PolicyStates {
   param(
      [System.Collections.Generic.List`1[[Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Models.IPolicyState]]]$policyStates,
      [int]$count,
      [switch]$expandPolicyEvaluationDetails = $false)

   Assert-True { $count -ge $policyStates.Count }
   Assert-True { $policyStates.Count -gt 0 }
   Foreach ($policyState in $policyStates) {
      Validate-PolicyState $policyState -expandPolicyEvaluationDetails:$expandPolicyEvaluationDetails
   }
}

<#
.SYNOPSIS
Validates a policy state
#>
function Validate-PolicyState {
   param(
      [Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Models.IPolicyState]$policyState,
      [switch]$expandPolicyEvaluationDetails = $false)

   Assert-NotNull $policyState

   Assert-NotNull $policyState.Timestamp
   Assert-NotNullOrEmpty $policyState.ResourceId
   Assert-NotNullOrEmpty $policyState.PolicyAssignmentId
   Assert-NotNullOrEmpty $policyState.PolicyDefinitionId
   Assert-NotNull $policyState.IsCompliant
   Assert-NotNullOrEmpty $policyState.SubscriptionId
   Assert-NotNullOrEmpty $policyState.PolicyDefinitionAction
   Assert-NotNullOrEmpty $policyState.ComplianceState

   if ($expandPolicyEvaluationDetails -and $policyState.ComplianceState -eq "NonCompliant") {
      Assert-NotNull $policyState.PolicyEvaluationDetails

      # Check if at least one property of PolicyEvaluationDetails is not null or empty
      Assert-True { $policyState.PolicyEvaluationDetails.EvaluatedExpression -ne $null -or 
                    $policyState.PolicyEvaluationDetails.IfNotExistDetailResourceId -ne $null -or 
                    $policyState.PolicyEvaluationDetails.IfNotExistDetailTotalResource -ne $null }
   }
}

<#
.SYNOPSIS
Validates a policy state summary
#>
function Validate-PolicyStateSummary {
   param([Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Models.Summary]$policyStateSummary)

   Assert-NotNull $policyStateSummary

   Assert-NotNull $policyStateSummary.ResultNonCompliantResource
   Assert-NotNull $policyStateSummary.ResultNonCompliantPolicy
   Assert-NotNull $policyStateSummary.ResultCompliantResource

   Assert-NotNull $policyStateSummary.PolicyAssignment
   Assert-True { $policyStateSummary.PolicyAssignment.Count -gt 0 }

   # Validate each policy assignment summary that was returned
   Foreach ($policyAssignmentSummary in $policyStateSummary.PolicyAssignment) {
      Assert-NotNull $policyAssignmentSummary

      Assert-NotNullOrEmpty $policyAssignmentSummary.PolicyAssignmentId

      Assert-NotNull $policyAssignmentSummary.ResultNonCompliantResource
      Assert-NotNull $policyAssignmentSummary.ResultNonCompliantPolicy
      Assert-NotNull $policyAssignmentSummary.ResultCompliantResource
      Assert-NotNull $policyAssignmentSummary.ResultPolicyDetail
      Assert-NotNull $policyAssignmentSummary.ResultPolicyGroupDetail
      Assert-NotNull $policyAssignmentSummary.ResultResourceDetail
      Assert-True { $policyAssignmentSummary.ResultPolicyDetail.Count -gt 0 }

      Assert-NotNull $policyAssignmentSummary.PolicyDefinition
      Assert-NotNull $policyAssignmentSummary.PolicyGroup
      Assert-True { $policyAssignmentSummary.PolicyGroup.Count -gt 0 }

      # Validate the contents of the Policy Definition summaries in the Policy Assignment Summary
      if ($policyAssignmentSummary.PolicyDefinition.Count -gt 0) {
         Assert-True { ($policyAssignmentSummary.PolicyDefinition | Where-Object { $_.ResultNonCompliantResource -gt 0 }).Count -eq $policyAssignmentSummary.ResultNonCompliantPolicy }

         Foreach ($policyDefinitionSummary in $policyAssignmentSummary.PolicyDefinition) {
            Assert-NotNull $policyDefinitionSummary
            Assert-NotNullOrEmpty $policyDefinitionSummary.PolicyDefinitionId
            Assert-NotNullOrEmpty $policyDefinitionSummary.Effect
            Assert-NotNull $policyDefinitionSummary.PolicyDefinitionGroupName

            Assert-NotNull $policyDefinitionSummary.ResultNonCompliantResource
            Assert-Null $policyDefinitionSummary.ResultNonCompliantPolicy
            Assert-NotNull $policyDefinitionSummary.ResultPolicyDetail
            Assert-NotNull $policyDefinitionSummary.ResultPolicyGroupDetail
            Assert-NotNull $policyDefinitionSummary.ResultResourceDetail
            Assert-True { $policyAssignmentSummary.ResultPolicyDetail.Count -gt 0 }
         }
      }
   }
}

<#
.SYNOPSIS
Validates a remediation
#>
function Validate-Remediation {
   param([Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Models.Remediation]$remediation)

   Assert-NotNull $remediation
   Assert-NotNull $remediation.CreatedOn
   Assert-NotNull $remediation.LastUpdatedOn
   Assert-NotNull $remediation.CorrelationId
   Assert-True { $remediation.Id -like "*/providers/microsoft.policyinsights/remediations/*" }
   Assert-AreEqual "Microsoft.PolicyInsights/remediations" $remediation.Type
   Assert-NotNullOrEmpty $remediation.Name
   Assert-NotNullOrEmpty $remediation.PolicyAssignmentId
   Assert-NotNullOrEmpty $remediation.ProvisioningState
   
   # Validate the properties that make up the DeploymentSummary
   Assert-NotNull $remediation.DeploymentStatusFailedDeployment
   Assert-NotNull $remediation.DeploymentStatusSuccessfulDeployment
   Assert-NotNull $remediation.DeploymentStatusTotalDeployment
}

<#
.SYNOPSIS
Validates a remediation deployment
#>
function Validate-RemediationDeployment {
   param([Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Models.IRemediationDeployment]$deployment)

   Assert-NotNull $deployment

   Assert-NotNull $deployment.CreatedOn
   Assert-NotNull $deployment.LastUpdatedOn
   Assert-True { $deployment.RemediatedResourceId -like "/subscriptions/*/providers/*" }
   Assert-NotNullOrEmpty $deployment.Status
   Assert-NotNullOrEmpty $deployment.ResourceLocation
}

<#
.SYNOPSIS
Validates a policy metadata resource
#>
function Validate-PolicyMetadata {
   param([Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Models.PolicyMetadata]$policyMetadata,
      [switch]$validateExtendedProperties = $false)

   Assert-NotNull $policyMetadata

   Assert-NotNull $policyMetadata.Name
   Assert-AreEqual "Microsoft.PolicyInsights/policyMetadata" $policyMetadata.Type
   Assert-True { $policyMetadata.Id -like "/providers/Microsoft.PolicyInsights/policyMetadata/" + $policyMetadata.Name }

   Assert-NotNull $policyMetadata.Title
   Assert-NotNull $policyMetadata.Category
   Assert-NotNull $policyMetadata.MetadataId
   if ($validateExtendedProperties) {
      Assert-NotNull $policyMetadata.Requirement
      Assert-NotNull $policyMetadata.Description
   }
}

<#
.SYNOPSIS
Validates a string is not null or empty
#>
function Assert-NotNullOrEmpty {
   param([string]$value)

   Assert-False { [string]::IsNullOrEmpty($value) }
}

<#
.SYNOPSIS
Validates an attestation
#>
function Validate-Attestation {
   param([Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Models.IAttestation]$attestation)

   Assert-NotNull $attestation
   Assert-NotNull $attestation.LastComplianceStateChangeAt
   Assert-True { $attestation.Id -like "*/providers/microsoft.policyinsights/attestations/*" }
   Assert-AreEqual "Microsoft.PolicyInsights/attestations" $attestation.Type
   Assert-NotNullOrEmpty $attestation.Name
   Assert-NotNullOrEmpty $attestation.PolicyAssignmentId
   Assert-NotNullOrEmpty $attestation.ProvisioningState
}

<#
.SYNOPSIS
Validates the properties of an attestation.
#>
function Validate-AttestationProperties {
   param(
      [Parameter(Mandatory = $true)]$attestation,
      [Parameter(Mandatory = $false)]$expectedName = $null,
      [Parameter(Mandatory = $false)]$expectedProvisioningState = $null,
      [Parameter(Mandatory = $false)]$expectedPolicyAssignmentId = $null,
      [Parameter(Mandatory = $false)]$expectedPolicyDefinitionReferenceId = $null,
      [Parameter(Mandatory = $false)]$expectedComplianceState = $null,
      [Parameter(Mandatory = $false)]$expectedComment = $null,
      [Parameter(Mandatory = $false)]$expectedExpiresOn = $null,
      [Parameter(Mandatory = $false)]$expectedMetadata = $null,
      [Parameter(Mandatory = $false)]$expectedEvidence = $null,
      [Parameter(Mandatory = $false)]$expectedOwner = $null,
      [Parameter(Mandatory = $false)]$expectedAssessmentDate = $null
   )
   if ($null -ne $expectedName) {
      Assert-AreEqual $expectedName $attestation.Name
   }
   if ($null -ne $expectedProvisioningState) {
      Assert-AreEqual $expectedProvisioningState $attestation.ProvisioningState
   }
   if ($null -ne $expectedPolicyAssignmentId) {
      Assert-AreEqual $expectedPolicyAssignmentId $attestation.PolicyAssignmentId
   }
   if ($null -ne $expectedPolicyDefinitionReferenceId) {
      Assert-AreEqual $expectedPolicyDefinitionReferenceId $attestation.PolicyDefinitionReferenceId
   }
   if ($null -ne $expectedComplianceState) {
      Assert-AreEqual $expectedComplianceState $attestation.ComplianceState
   }
   if ($null -ne $expectedExpiresOn) {
      Assert-AreEqual $expectedExpiresOn $attestation.ExpiresOn
   }
   if ($null -ne $expectedMetadata) {
      $expectedMetadataJson = [Newtonsoft.Json.Linq.JObject]::Parse($expectedMetadata)
      Assert-AreEqual $expectedMetadataJson.ToString() $attestation.metadata.ToString()
   }
   if ($null -ne $expectedEvidence) {
      Validate-AttestationEvidence($attestation.Evidence, $expectedEvidence)
   }
   if ($null -ne $expectedOwner) {
      Assert-AreEqual $expectedOwner $attestation.Owner
   }
   if ($null -ne $expectedComment) {
      Assert-AreEqual $expectedComment $attestation.Comment
   }
   if ($null -ne $expectedAssessmentDate) {
      Assert-AreEqual $expectedAssessmentDate $attestation.AssessmentDate
   }
}

<#
.SYNOPSIS
Validates an attestation evidence.
#>
function Validate-AttestationEvidence {
   param($actualEvidence, $expectedEvidence)

   Assert-NotNullOrEmpty $actualEvidence
   for ($i = 0; $i -lt $actualEvidence.Count; $i++) {
      Assert-AreEqual $expectedEvidence[$i].Description $actualEvidence[$i].Description
      Assert-AreEqual $expectedEvidence[$i].SourceUri $actualEvidence[$i].SourceUri
   }
}

$env = @{}
if ($UsePreviousConfigForRecord) {
    $previousEnv = Get-Content (Join-Path $PSScriptRoot 'env.json') | ConvertFrom-Json
    $previousEnv.psobject.properties | Foreach-Object { $env[$_.Name] = $_.Value }
}
# Add script method called AddWithCache to $env, when useCache is set true, it will try to get the value from the $env first.
# example: $val = $env.AddWithCache('key', $val, $true)
$env | Add-Member -Type ScriptMethod -Value { param( [string]$key, [object]$val, [bool]$useCache) if ($this.Contains($key) -and $useCache) { return $this[$key] } else { $this[$key] = $val; return $val } } -Name 'AddWithCache'
function setupEnv() {
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id

    # TESTING NOTES
    # if running tests frequently, comment out the RG deletion in cleanupEnv


    # --- common variables used in legacy tests ---
    $env['managementGroup'] = 'PowershellTesting' # need to ensure this value is the parent MG of the current subscription
    $env['firstRgName'] = 'PSTestRG1'
    $env['secondRgName'] = 'PSTestRG2'
    $env['emptyRgName'] = 'PSTestEmptyRG'
    $env['testResourceNamePrefix'] = 'pstests'
    $env['testResourceId'] = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.firstRgName)/providers/Microsoft.Network/networkSecurityGroups/$($env.testResourceNamePrefix)1"
    $env['modifyPolicyDefName'] = 'PSTestModifyDefinition'
    $env['dinePolicyDefName'] = 'PSTestDINEDefinition'
    $env['auditPolicyDefName'] = 'PSTestAuditDefinition'
    $env['policySetDefName'] = 'PSTestInitiative'
    $env['dineAssignmentNameSub'] = 'PSTestDeployAssignmentSub'
    $env['remediationSubPolicyAssignmentId'] = "/subscriptions/$($env.SubscriptionId)/providers/Microsoft.Authorization/policyAssignments/$($env.dineAssignmentNameSub)"
    $env['dineAssignmentNameMg'] = 'PSTestDeployAssignmentMG'
    $env['remediationMgPolicyAssignmentId'] = "/providers/Microsoft.Management/managementGroups/$($env.managementGroup)/providers/Microsoft.Authorization/policyAssignments/$($env.dineAssignmentNameMg)"
    $env['modifyAssignmentNameSub'] = 'PSTestModifyAssignmentSub'
    $env['remediationSubModifyPolicyAssignmentId'] = "/subscriptions/$($env.SubscriptionId)/providers/Microsoft.Authorization/policyAssignments/$($env.modifyAssignmentNameSub)"
    $env['auditAssignmentNameSub'] = 'PSTestAuditAssignmentSub'
    $env['auditAssignmentNameRg'] = 'PSTestAuditAssignmentRG'
    $env['auditSetAssignmentNameSub'] = 'PSTestAuditInitiativeAssignmentSub'
    $env['manualPolicyDefNameSub'] = 'PSTestAttestationSub'
    $env['manualPolicyDefNameRg'] = 'PSTestAttestationRG'
    $env['manualPolicyDefNameResource'] = 'PSTestAttestationResource'
    $env['manualPolicySetDefNameSub'] = 'PSTestAttestationInitiativeSub'
    $env['manualPolicySetDefNameRg'] = 'PSTestAttestationInitiativeRG'
    $env['manualPolicySetDefNameResource'] = 'PSTestAttestationInitiativeResource'
    # attestation sub scope
    $env['attestationAssignmentNameSub'] = 'PSAttestationSubAssignment'
    $env['attestationSetAssignmentNameSub'] = 'PSAttestationInitiativeSubAssignment'
    $env['attestationSubPolicyAssignmentId'] = "/subscriptions/$($env.SubscriptionId)/providers/Microsoft.Authorization/policyAssignments/$($env.attestationAssignmentNameSub)"
    $env['attestationSetSubPolicyAssignmentId'] = "/subscriptions/$($env.SubscriptionId)/providers/Microsoft.Authorization/policyAssignments/$($env.attestationSetAssignmentNameSub)"
    $env['attestationSetSubPolicyRefId'] = "$($env.manualPolicyDefNameSub)_1"
    # attestation rg scope
    $env['attestationRgName'] = 'ps-attestation-test-rg'
    $env['attestationSetAssignmentNameRg'] = 'PSAttestationInitiativeRGAssignment'
    $env['attestationAssignmentNameRg'] = 'PSAttestationRGAssignment'
    $env['attestationRgPolicyAssignmentId'] = "/subscriptions/$($env.SubscriptionId)/providers/Microsoft.Authorization/policyAssignments/$($env.attestationAssignmentNameRg)"
    $env['attestationSetRgPolicyAssignmentId'] = "/subscriptions/$($env.SubscriptionId)/providers/Microsoft.Authorization/policyAssignments/$($env.attestationSetAssignmentNameRg)"
    $env['attestationSetRgPolicyRefId'] = "$($env.manualPolicyDefNameRg)_1"
    # attestation resource scope
    $env['attestationTestResourceName'] = "$($env.testResourceNamePrefix)0"
    $env['attestationTestResourceId'] = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.attestationRgName)/providers/Microsoft.Network/networkSecurityGroups/$($env.attestationTestResourceName)"
    $env['attestationAssignmentNameResource'] = 'PSAttestationResourceAssignment'
    $env['attestationResourcePolicyAssignmentId'] = "/subscriptions/$($env.SubscriptionId)/providers/Microsoft.Authorization/policyAssignments/$($env.attestationAssignmentNameResource)"
    $env['attestationSetAssignmentNameResource'] = 'PSAttestationInitiativeResourceAssignment'
    $env['attestationSetResourcePolicyAssignmentId'] = "/subscriptions/$($env.SubscriptionId)/providers/Microsoft.Authorization/policyAssignments/$($env.attestationSetAssignmentNameResource)"
    $env['attestationSetResourcePolicyRefId'] = "$($env.manualPolicyDefNameResource)_1"

    # date values that we want saved for playback runs
    $env['fromDate'] = Get-TestQueryIntervalStart
    $env['toDate'] = Get-TestQueryIntervalEnd

    # --- BELOW SECTION IS ENVIRONMENT SETUP --- 

    # Connect
    Connect-AzAccount -SubscriptionId $env.SubscriptionId -TenantId $env.Tenant -AuthScope MicrosoftGraphEndpointResourceId

    #Create an empty RG
    Get-AzResourceGroup -Name $env.emptyRgName -ErrorVariable rgNotPresent -ErrorAction SilentlyContinue
    if ($rgNotPresent) {
       New-AzResourceGroup -Name $env.emptyRgName -Location "eastus"
    }

    # Create 2 RGs
    foreach ($resourceGroupName in @($env.firstRgName, $env.secondRgName)) {
       Get-AzResourceGroup -Name $resourceGroupName -ErrorVariable rgNotPresent -ErrorAction SilentlyContinue
       if ($rgNotPresent) {
          New-AzResourceGroup -Name $resourceGroupName -Location "northcentralus"
       }
    }

    # Create DINE and modify definitions (MG-level)
    $deployIfNotExistsPolicyDefinition = New-AzPolicyDefinition -Name $env.dinePolicyDefName -Policy "$PSScriptRoot/TestSetupFiles/NSG_DINE_neverCompliant_policyDefinition.json" -DisplayName "PS cmdlet tests: never compliant DINE policy" -Mode Indexed -ManagementGroupName $env.managementGroup
    $modifyPolicyDefinition = New-AzPolicyDefinition -Name $env.modifyPolicyDefName -Policy "$PSScriptRoot/TestSetupFiles/NSG_modify_neverCompliant_policyDefinition.json" -DisplayName "PS cmdlet tests: never compliant modify policy" -Mode Indexed -ManagementGroupName $env.managementGroup

    # Assign the DINE policy in both MG and subscription level
    $mgDINEAssignment = New-AzPolicyAssignment -Name $env.dineAssignmentNameMg -Scope "/providers/microsoft.management/managementgroups/$($env.managementGroup)" -DisplayName "PS cmdlet tests: never compliant DINE policy (MG)" -PolicyDefinition $deployIfNotExistsPolicyDefinition -IdentityType "SystemAssigned" -Location "westus2"
    $subDINEAssignment = New-AzPolicyAssignment -Name $env.dineAssignmentNameSub -Scope "/subscriptions/$($env.SubscriptionId)" -DisplayName "PS cmdlet tests: never compliant DINE policy (Sub)" -PolicyDefinition $deployIfNotExistsPolicyDefinition -IdentityType "SystemAssigned" -Location "westus2"

    # Assign the modify policy to the subscription
    $subModifyAssignment = New-AzPolicyAssignment -Name $env.modifyAssignmentNameSub -Scope "/subscriptions/$($env.SubscriptionId)" -DisplayName "PS cmdlet tests: never compliant modify policy" -PolicyDefinition $modifyPolicyDefinition -IdentityType "SystemAssigned" -Location "westus2"
    
    # Store all the identities created for assignments
    $env['mgDINEAssignmentIdentity'] = $mgDINEAssignment.IdentityPrincipalId
    $env['subDINEAssignmentIdentity'] = $subDINEAssignment.IdentityPrincipalId
    $env['subModifyAssignmentIdentity'] = $subModifyAssignment.IdentityPrincipalId

    # Give the assignments permissions to perform remediations
    Start-TestSleep -Seconds 60
    New-AzRoleAssignment -Scope "/providers/microsoft.management/managementgroups/$($env.managementGroup)" -ObjectId $env.mgDINEAssignmentIdentity -RoleDefinitionName "Key Vault Contributor"
    New-AzRoleAssignment -Scope "/subscriptions/$($env.SubscriptionId)" -ObjectId $env.subDINEAssignmentIdentity -RoleDefinitionName "Key Vault Contributor"
    New-AzRoleAssignment -Scope "/subscriptions/$($env.SubscriptionId)" -ObjectId $env.subModifyAssignmentIdentity -RoleDefinitionName "Tag Contributor"

    # Trigger 101 modify remediations with different names (don't care about the outcome, just want to have 101 remediation entities we can query)
    New-AzResourceGroupDeployment -ResourceGroupName $env.firstRgName -AsJob -TemplateFile "$PSScriptRoot/TestSetupFiles/CreateRemediationsTemplate.json" -remediationCount 101 -assignmentId $subModifyAssignment.Id

    # Create a subscription-level audit policy definition
    $partiallyCompliantAuditPolicyDefinition = New-AzPolicyDefinition -Name $env.auditPolicyDefName -Policy "$PSScriptRoot/TestSetupFiles/NSG_audit_partiallyCompliant_policyDefinition.json" -DisplayName "PS cmdlet tests: partially compliant audit policy" -Mode Indexed -SubscriptionId $env.SubscriptionId

    # Assign the audit policy to subscription and RG levels
    New-AzPolicyAssignment -Name $env.auditAssignmentNameSub -Scope "/subscriptions/$($env.SubscriptionId)" -DisplayName "PS cmdlet tests: partially compliant audit policy (Sub)" -PolicyDefinition $partiallyCompliantAuditPolicyDefinition
    New-AzPolicyAssignment -Name $env.auditAssignmentNameRg -Scope "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.firstRgName)" -DisplayName "PS cmdlet tests: partially compliant audit policy (RG)" -PolicyDefinition $partiallyCompliantAuditPolicyDefinition

    # Create an initiative for the audit policy
    $policyDefinitions = @"
    [
       {
          "policyDefinitionId": "$($partiallyCompliantAuditPolicyDefinition.Id)"
       }
    ]
"@

    $policySetDefinition = New-AzPolicySetDefinition -Name $env.policySetDefName -DisplayName "PS cmdlet tests: test initiative" -PolicyDefinition $policyDefinitions -SubscriptionId $env.SubscriptionId

    # Assign the initiative to the subscription
    New-AzPolicyAssignment -Name $env.auditSetAssignmentNameSub -Scope "/subscriptions/$($env.SubscriptionId)" -DisplayName "PS cmdlet tests: initiative with audit policy (Sub)" -PolicySetDefinition $policySetDefinition

    Start-TestSleep -Seconds 60

    # In each RG, create 510 NSGs (will take a while)
    foreach ($resourceGroupName in @($env.firstRgName, $env.secondRgName)) {
      # If RG was already populated with NSGs, skip deployment
      $rgNsgs = Get-AzResource -ResourceGroupName $resourceGroupName -ResourceType "Microsoft.Network/networkSecurityGroups"
      if($rgNsgs.count -eq 510)
      {
        Write-Host -ForegroundColor Magenta "RG already populated with NSG's"
        continue
      }
      New-AzResourceGroupDeployment -ResourceGroupName $resourceGroupName -TemplateFile "$PSScriptRoot/TestSetupFiles/CreateNSGsTemplate.json" -resourceCount 510 -resourceNamePrefix $env.testResourceNamePrefix
    }

    #region Attestation Tests Setup
    $resourceGroup3 = $env.attestationRgName

    # Create the required RG(s) for attestations.
    foreach ($resourceGroupName in @($resourceGroup3)) {
       Get-AzResourceGroup -Name $resourceGroupName -ErrorVariable rgNotPresent -ErrorAction SilentlyContinue
       if ($rgNotPresent) {
          New-AzResourceGroup -Name $resourceGroupName -Location "northcentralus"
       }
    }

    # Create Subscription targetting manual policy
    $manualPolicySubcriptionDefinition = New-AzPolicyDefinition -Name $env.manualPolicyDefNameSub -Policy "$PSScriptRoot/TestSetupFiles/ManualPolicySubDefinition.json" -DisplayName "PS cmdlet tests: Subscription Manual Policy" -Mode All

    # Create RG targetting manual policy
    $manualPolicyRGDefinition = New-AzPolicyDefinition -Name $env.manualPolicyDefNameRg -Policy "$PSScriptRoot/TestSetupFiles/ManualPolicyRGDefinition.json" -DisplayName "PS cmdlet tests: RG Manual Policy" -Mode All

    # Create Resource targetting manual policy
    $manualPolicyResourceDefinition = New-AzPolicyDefinition -Name $env.manualPolicyDefNameResource -Policy "$PSScriptRoot/TestSetupFiles/ManualPolicyResourceDefinition.json" -DisplayName "PS cmdlet tests: Resource Manual Policy" -Mode All

    # Create a network security group for testing resource level attestations.
    New-AzResourceGroupDeployment -ResourceGroupName $resourceGroup3 -TemplateFile "$PSScriptRoot/TestSetupFiles/CreateNSGsTemplate.json" -resourceCount 1 -resourceNamePrefix $env.testResourceNamePrefix

    # Assign the manual policies targetting each of Subscription, Resource Groups and Resource Types to the subscription
    $manualPolicySubAssignment = New-AzPolicyAssignment -Name $env.attestationAssignmentNameSub -Scope "/subscriptions/$($env.SubscriptionId)" -DisplayName "PS cmdlet tests: Subscription Manual Policy" -PolicyDefinition $manualPolicySubcriptionDefinition

    $manualPolicyRGAssignment = New-AzPolicyAssignment -Name $env.attestationAssignmentNameRg -Scope "/subscriptions/$($env.SubscriptionId)" -DisplayName "PS cmdlet tests: RG Manual Policy" -PolicyDefinition $manualPolicyRGDefinition

    $manualPolicyResourceAssignment = New-AzPolicyAssignment -Name $env.attestationAssignmentNameResource -Scope "/subscriptions/$($env.SubscriptionId)" -DisplayName "PS cmdlet tests: Resource Manual Policy" -PolicyDefinition $manualPolicyResourceDefinition

    # Define Policy Initiatives
    $manualpolicyDefinitionsSubscription = @"
    [
       {
          "policyDefinitionId":"$($manualPolicySubcriptionDefinition.Id)",
          "policyDefinitionReferenceId": "$($env.manualPolicyDefNameSub)_1"
       }
    ]
"@

    $manualpolicyDefinitionsRG = @"
    [
       {
          "policyDefinitionId":"$($manualPolicyRGDefinition.Id)",
          "policyDefinitionReferenceId": "$($env.manualPolicyDefNameRg)_1"
       }
    ]
"@

    $manualpolicyDefinitionsResource = @"
    [
       {
          "policyDefinitionId":"$($manualPolicyResourceDefinition.Id)",
          "policyDefinitionReferenceId": "$($env.manualPolicyDefNameResource)_1"
       }
    ]
"@

    $policySetDefinitionSub = New-AzPolicySetDefinition -Name $env.manualPolicySetDefNameSub -DisplayName "PS cmdlet tests: Attestation initiative SUB" -PolicyDefinition $manualpolicyDefinitionsSubscription -SubscriptionId $env.SubscriptionId
    $policySetDefinitionRG = New-AzPolicySetDefinition -Name $env.manualPolicySetDefNameRg -DisplayName "PS cmdlet tests: Attestation initiative RG" -PolicyDefinition $manualpolicyDefinitionsRG -SubscriptionId $env.SubscriptionId
    $policySetDefinitionResource = New-AzPolicySetDefinition -Name $env.manualPolicySetDefNameResource -DisplayName "PS cmdlet tests: Attestation initiative Resource" -PolicyDefinition $manualpolicyDefinitionsResource -SubscriptionId $env.SubscriptionId

    # Assign the initiatives to the subscription
    New-AzPolicyAssignment -Name $env.attestationSetAssignmentNameSub -Scope "/subscriptions/$($env.SubscriptionId)" -DisplayName "PS cmdlet tests: Attestation initiative SUB" -PolicySetDefinition $policySetDefinitionSub

    New-AzPolicyAssignment -Name $env.attestationSetAssignmentNameRg -Scope "/subscriptions/$($env.SubscriptionId)" -DisplayName "PS cmdlet tests: Attestation initiative RG" -PolicySetDefinition $policySetDefinitionRG

    New-AzPolicyAssignment -Name $env.attestationSetAssignmentNameResource -Scope "/subscriptions/$($env.SubscriptionId)" -DisplayName "PS cmdlet tests: Attestation initiative Resource" -PolicySetDefinition $policySetDefinitionResource

    #endregion

    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}

function cleanupEnv() {
    # Clean resources you create for testing
    Write-Host -ForegroundColor Magenta "Cleaning up globals"

    # delete resource groups if present 
    foreach ($resourceGroupName in @($env.firstRgName, $env.secondRgName, $env.emptyRgName, $env.attestationRgName)) {
        Get-AzResourceGroup -Name $resourceGroupName -ErrorVariable rgNotPresent -ErrorAction SilentlyContinue
        if (-not $rgNotPresent) {
            Remove-AzResourceGroup -Name $resourceGroupName -Force
        }
    }
    
    #delete role assignments created in setup
    Remove-AzRoleAssignment -ObjectId $env.mgDINEAssignmentIdentity -Scope "/providers/microsoft.management/managementgroups/$($env.managementGroup)" -RoleDefinitionName "Key Vault Contributor"
    Remove-AzRoleAssignment -ObjectId $env.subDINEAssignmentIdentity -Scope "/subscriptions/$($env.SubscriptionId)" -RoleDefinitionName "Key Vault Contributor"
    Remove-AzRoleAssignment -ObjectId $env.subModifyAssignmentIdentity -Scope "/subscriptions/$($env.SubscriptionId)" -RoleDefinitionName "Tag Contributor"

    Write-Host -ForegroundColor Magenta "Cleanup completed"
}

