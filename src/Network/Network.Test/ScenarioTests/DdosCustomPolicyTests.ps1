# ----------------------------------------------------------------------------------
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.SYNOPSIS
DDoS custom policy management operations
#>
function Test-DdosCustomPolicyDetectionRuleCreation
{
    <#
    .SYNOPSIS
    Test creating DDoS custom policy detection rules with valid inputs
    #>
    
    # Create TCP detection rule
    $tcpRule = New-AzDdosCustomPolicyDetectionRule -Name tcpRule1 -TrafficType Tcp -PacketsPerSecond 1000000
    Assert-AreEqual "Tcp" $tcpRule.TrafficType
    Assert-AreEqual 1000000 $tcpRule.PacketsPerSecond
    Assert-NotNull $tcpRule

    # Create UDP detection rule
    $udpRule = New-AzDdosCustomPolicyDetectionRule -Name udpRule1 -TrafficType Udp -PacketsPerSecond 100000
    Assert-AreEqual "Udp" $udpRule.TrafficType
    Assert-AreEqual 100000 $udpRule.PacketsPerSecond
    Assert-NotNull $udpRule

    # Create TCP SYN detection rule
    $tcpSynRule = New-AzDdosCustomPolicyDetectionRule -Name tcpSynRule1 -TrafficType TcpSyn -PacketsPerSecond 50000
    Assert-AreEqual "TcpSyn" $tcpSynRule.TrafficType
    Assert-AreEqual 50000 $tcpSynRule.PacketsPerSecond
    Assert-NotNull $tcpSynRule
}

<#
.SYNOPSIS
Test DDoS custom policy CRUD operations
#>
function Test-DdosCustomPolicyCRUD
{
    $rgLocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/ddosCustomPolicies"
    $location = Get-ProviderLocation $resourceTypeParent

    $rgName = Get-ResourceGroupName
    $ddosCustomPolicyName = Get-ResourceName

    try
    {
        # Create the resource group
        New-AzResourceGroup -Name $rgName -Location $location -Tags @{ testtag = "ddosCustomPolicy tag" }

        # Create detection rules
        $tcpRule = New-AzDdosCustomPolicyDetectionRule -Name tcpRule1 -TrafficType Tcp -PacketsPerSecond 1000000
        $udpRule = New-AzDdosCustomPolicyDetectionRule -Name udpRule1 -TrafficType Udp -PacketsPerSecond 100000

        # Create the DDoS custom policy with multiple rules
        $ddosCustomPolicyNew = New-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName `
            -Location $rgLocation -DetectionRule @($tcpRule, $udpRule)

        Assert-AreEqual $rgName $ddosCustomPolicyNew.ResourceGroupName
        Assert-AreEqual $ddosCustomPolicyName $ddosCustomPolicyNew.Name
        Assert-NotNull $ddosCustomPolicyNew.Location
        Assert-NotNull $ddosCustomPolicyNew.DetectionRules
        Assert-AreEqual 2 $ddosCustomPolicyNew.DetectionRules.Count

        # Get the DDoS custom policy
        $ddosCustomPolicyGet = Get-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName
        Assert-AreEqual $rgName $ddosCustomPolicyGet.ResourceGroupName
        Assert-AreEqual $ddosCustomPolicyName $ddosCustomPolicyGet.Name
        Assert-NotNull $ddosCustomPolicyGet.Location
        Assert-NotNull $ddosCustomPolicyGet.DetectionRules
        Assert-AreEqual 2 $ddosCustomPolicyGet.DetectionRules.Count

        # Verify detection rules
        $tcpRuleFromPolicy = $ddosCustomPolicyGet.DetectionRules | Where-Object { $_.TrafficType -eq "Tcp" }
        Assert-NotNull $tcpRuleFromPolicy
        Assert-AreEqual 1000000 $tcpRuleFromPolicy.PacketsPerSecond

        $udpRuleFromPolicy = $ddosCustomPolicyGet.DetectionRules | Where-Object { $_.TrafficType -eq "Udp" }
        Assert-NotNull $udpRuleFromPolicy
        Assert-AreEqual 100000 $udpRuleFromPolicy.PacketsPerSecond

        # Remove the DDoS custom policy
        $ddosCustomPolicyDelete = Remove-AzDdosCustomPolicy -Name $ddosCustomPolicyName -ResourceGroupName $rgName -PassThru
        Assert-AreEqual $true $ddosCustomPolicyDelete
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgName
    }
}

<#
.SYNOPSIS
Test DDoS custom policy creation with single detection rule
#>
function Test-DdosCustomPolicyCRUDWithSingleRule
{
    $rgLocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/ddosCustomPolicies"
    $location = Get-ProviderLocation $resourceTypeParent

    $rgName = Get-ResourceGroupName
    $ddosCustomPolicyName = Get-ResourceName

    try
    {
        # Create the resource group
        New-AzResourceGroup -Name $rgName -Location $location -Tags @{ testtag = "singleRule" }

        # Create a single detection rule
        $tcpRule = New-AzDdosCustomPolicyDetectionRule -Name tcpRule1 -TrafficType Tcp -PacketsPerSecond 1000000

        # Create the DDoS custom policy with single rule
        $ddosCustomPolicyNew = New-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName `
            -Location $rgLocation -DetectionRule @($tcpRule)

        Assert-AreEqual $rgName $ddosCustomPolicyNew.ResourceGroupName
        Assert-AreEqual $ddosCustomPolicyName $ddosCustomPolicyNew.Name
        Assert-NotNull $ddosCustomPolicyNew.DetectionRules
        Assert-AreEqual 1 $ddosCustomPolicyNew.DetectionRules.Count
        Assert-AreEqual "Tcp" $ddosCustomPolicyNew.DetectionRules[0].TrafficType
        Assert-AreEqual 1000000 $ddosCustomPolicyNew.DetectionRules[0].PacketsPerSecond

        # Get and verify
        $ddosCustomPolicyGet = Get-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName
        Assert-AreEqual 1 $ddosCustomPolicyGet.DetectionRules.Count

        # Remove the policy
        Remove-AzDdosCustomPolicy -Name $ddosCustomPolicyName -ResourceGroupName $rgName -PassThru | Out-Null
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgName
    }
}

<#
.SYNOPSIS
Test that the service validates a DDoS custom policy without rules
#>
function Test-DdosCustomPolicyCRUDWithoutRules
{
    $rgLocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/ddosCustomPolicies"
    $location = Get-ProviderLocation $resourceTypeParent

    $rgName = Get-ResourceGroupName
    $ddosCustomPolicyName = Get-ResourceName

    try
    {
        New-AzResourceGroup -Name $rgName -Location $location -Tags @{ testtag = "withoutRules" } | Out-Null

        Assert-ThrowsLike {
            New-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName -Location $rgLocation
        } "*Ddos Custom Policy does not contain any properties to customize*"
    }
    finally
    {
        Clean-ResourceGroup $rgName
    }
}

<#
.SYNOPSIS
Test DDoS custom policy creation with tags
#>
function Test-DdosCustomPolicyCRUDWithTags
{
    $rgLocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/ddosCustomPolicies"
    $location = Get-ProviderLocation $resourceTypeParent

    $rgName = Get-ResourceGroupName
    $ddosCustomPolicyName = Get-ResourceName
    $tags = @{ Environment = "Production"; Owner = "NetworkTeam"; CostCenter = "12345" }

    try
    {
        # Create the resource group
        New-AzResourceGroup -Name $rgName -Location $location

        # Create detection rule
        $tcpRule = New-AzDdosCustomPolicyDetectionRule -Name tcpRule1 -TrafficType Tcp -PacketsPerSecond 1000000

        # Create the DDoS custom policy with tags
        $ddosCustomPolicyNew = New-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName `
            -Location $rgLocation -DetectionRule @($tcpRule) -Tag $tags

        Assert-AreEqual $rgName $ddosCustomPolicyNew.ResourceGroupName
        Assert-NotNull $ddosCustomPolicyNew.Tag
        Assert-AreEqual "Production" $ddosCustomPolicyNew.Tag["Environment"]
        Assert-AreEqual "NetworkTeam" $ddosCustomPolicyNew.Tag["Owner"]
        Assert-AreEqual "12345" $ddosCustomPolicyNew.Tag["CostCenter"]

        # Get and verify tags
        $ddosCustomPolicyGet = Get-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName
        Assert-NotNull $ddosCustomPolicyGet.Tag
        Assert-AreEqual "Production" $ddosCustomPolicyGet.Tag["Environment"]

        # Remove the policy
        Remove-AzDdosCustomPolicy -Name $ddosCustomPolicyName -ResourceGroupName $rgName -PassThru | Out-Null
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgName
    }
}

<#
.SYNOPSIS
Test DDoS custom policy with three different traffic types
#>
function Test-DdosCustomPolicyCRUDWithMultipleTrafficTypes
{
    $rgLocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/ddosCustomPolicies"
    $location = Get-ProviderLocation $resourceTypeParent

    $rgName = Get-ResourceGroupName
    $ddosCustomPolicyName = Get-ResourceName

    try
    {
        # Create the resource group
        New-AzResourceGroup -Name $rgName -Location $location

        # Create three different detection rules
        $tcpRule = New-AzDdosCustomPolicyDetectionRule -Name tcpRule1 -TrafficType Tcp -PacketsPerSecond 1000000
        $udpRule = New-AzDdosCustomPolicyDetectionRule -Name udpRule1 -TrafficType Udp -PacketsPerSecond 100000
        $tcpSynRule = New-AzDdosCustomPolicyDetectionRule -Name tcpSynRule1 -TrafficType TcpSyn -PacketsPerSecond 50000

        # Create the DDoS custom policy
        $ddosCustomPolicyNew = New-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName `
            -Location $rgLocation -DetectionRule @($tcpRule, $udpRule, $tcpSynRule)

        Assert-AreEqual 3 $ddosCustomPolicyNew.DetectionRules.Count

        # Verify each traffic type
        $rules = $ddosCustomPolicyNew.DetectionRules
        Assert-NotNull ($rules | Where-Object { $_.TrafficType -eq "Tcp" })
        Assert-NotNull ($rules | Where-Object { $_.TrafficType -eq "Udp" })
        Assert-NotNull ($rules | Where-Object { $_.TrafficType -eq "TcpSyn" })

        # Get and verify
        $ddosCustomPolicyGet = Get-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName
        Assert-AreEqual 3 $ddosCustomPolicyGet.DetectionRules.Count

        # Remove the policy
        Remove-AzDdosCustomPolicy -Name $ddosCustomPolicyName -ResourceGroupName $rgName -PassThru | Out-Null
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgName
    }
}

<#
.SYNOPSIS
Test DDoS custom policy removal without PassThru
#>
function Test-DdosCustomPolicyRemoveWithoutPassThru
{
    $rgLocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/ddosCustomPolicies"
    $location = Get-ProviderLocation $resourceTypeParent

    $rgName = Get-ResourceGroupName
    $ddosCustomPolicyName = Get-ResourceName

    try
    {
        # Create the resource group
        New-AzResourceGroup -Name $rgName -Location $location

        # Create detection rule
        $tcpRule = New-AzDdosCustomPolicyDetectionRule -Name tcpRule1 -TrafficType Tcp -PacketsPerSecond 1000000

        # Create the DDoS custom policy
        New-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName `
            -Location $rgLocation -DetectionRule @($tcpRule)

        # Remove without PassThru (should not return anything)
        $result = Remove-AzDdosCustomPolicy -Name $ddosCustomPolicyName -ResourceGroupName $rgName
        Assert-Null $result
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgName
    }
}

<#
.SYNOPSIS
Test error handling for invalid detection rule parameters
#>
function Test-DdosCustomPolicyDetectionRuleValidation
{
    # Test invalid traffic type - should fail
    Assert-ThrowsLike {
        New-AzDdosCustomPolicyDetectionRule -Name invalidRule -TrafficType "InvalidType" -PacketsPerSecond 1000000
    } "*InvalidType*"

    # Test packets per second less than 1 - should fail
    Assert-ThrowsLike {
        New-AzDdosCustomPolicyDetectionRule -Name tcpRule1 -TrafficType Tcp -PacketsPerSecond 0
    } "*"

    # Test negative packets per second - should fail
    Assert-ThrowsLike {
        New-AzDdosCustomPolicyDetectionRule -Name tcpRule1 -TrafficType Tcp -PacketsPerSecond -100
    } "*"
}

<#
.SYNOPSIS
Test adding a detection rule to a DDoS custom policy and persisting with Set
#>
function Test-DdosCustomPolicyAddDetectionRule
{
    $rgLocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/ddosCustomPolicies"
    $location = Get-ProviderLocation $resourceTypeParent

    $rgName = Get-ResourceGroupName
    $ddosCustomPolicyName = Get-ResourceName

    try
    {
        # Create the resource group
        New-AzResourceGroup -Name $rgName -Location $location

        # Create a policy with a single detection rule
        $tcpRule = New-AzDdosCustomPolicyDetectionRule -Name tcpRule1 -TrafficType Tcp -PacketsPerSecond 1000000
        $ddosCustomPolicyNew = New-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName `
            -Location $rgLocation -DetectionRule @($tcpRule)
        Assert-AreEqual 1 $ddosCustomPolicyNew.DetectionRules.Count

        # Add a detection rule to the in-memory policy object
        $modifiedPolicy = Get-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName |
            Add-AzDdosCustomPolicyDetectionRule -Name udpRule1 -TrafficType Udp -PacketsPerSecond 100000

        Assert-AreEqual 2 $modifiedPolicy.DetectionRules.Count
        Assert-NotNull ($modifiedPolicy.DetectionRules | Where-Object { $_.TrafficType -eq "Udp" })

        # Verify the policy in Azure is unchanged until Set is called
        $originalPolicy = Get-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName
        Assert-AreEqual 1 $originalPolicy.DetectionRules.Count

        # Persist the updated policy and verify
        $persistedPolicy = $modifiedPolicy | Set-AzDdosCustomPolicy
        Assert-AreEqual 2 $persistedPolicy.DetectionRules.Count

        $updatedPolicy = Get-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName
        Assert-AreEqual 2 $updatedPolicy.DetectionRules.Count
        Assert-NotNull ($updatedPolicy.DetectionRules | Where-Object { $_.TrafficType -eq "Tcp" })
        Assert-NotNull ($updatedPolicy.DetectionRules | Where-Object { $_.TrafficType -eq "Udp" })

        Remove-AzDdosCustomPolicy -Name $ddosCustomPolicyName -ResourceGroupName $rgName -PassThru | Out-Null
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgName
    }
}

<#
.SYNOPSIS
Test removing a detection rule from a DDoS custom policy
#>
function Test-DdosCustomPolicyRemoveDetectionRule
{
    $rgLocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/ddosCustomPolicies"
    $location = Get-ProviderLocation $resourceTypeParent

    $rgName = Get-ResourceGroupName
    $ddosCustomPolicyName = Get-ResourceName

    try
    {
        # Create the resource group
        New-AzResourceGroup -Name $rgName -Location $location

        # Create three detection rules
        $tcpRule = New-AzDdosCustomPolicyDetectionRule -Name tcpRule1 -TrafficType Tcp -PacketsPerSecond 1000000
        $udpRule = New-AzDdosCustomPolicyDetectionRule -Name udpRule1 -TrafficType Udp -PacketsPerSecond 100000
        $tcpSynRule = New-AzDdosCustomPolicyDetectionRule -Name tcpSynRule1 -TrafficType TcpSyn -PacketsPerSecond 50000

        # Create the DDoS custom policy with three rules
        $ddosCustomPolicyNew = New-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName `
            -Location $rgLocation -DetectionRule @($tcpRule, $udpRule, $tcpSynRule)

        Assert-AreEqual 3 $ddosCustomPolicyNew.DetectionRules.Count

        # Get the policy
        $policy = Get-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName
        Assert-AreEqual 3 $policy.DetectionRules.Count

        # Remove UDP rule from policy object (in-memory)
        $modifiedPolicy = $policy | Remove-AzDdosCustomPolicyDetectionRule -Name udpRule1
        Assert-AreEqual 2 $modifiedPolicy.DetectionRules.Count
        Assert-Null ($modifiedPolicy.DetectionRules | Where-Object { $_.TrafficType -eq "Udp" })
        Assert-NotNull ($modifiedPolicy.DetectionRules | Where-Object { $_.TrafficType -eq "Tcp" })
        Assert-NotNull ($modifiedPolicy.DetectionRules | Where-Object { $_.TrafficType -eq "TcpSyn" })

        # Verify original policy in Azure still has all 3 rules (changes not persisted yet)
        $originalPolicy = Get-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName
        Assert-AreEqual 3 $originalPolicy.DetectionRules.Count

        # Persist the changes to Azure
        $modifiedPolicy | Set-AzDdosCustomPolicy | Out-Null

        # Verify policy in Azure now has only 2 rules
        $updatedPolicy = Get-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName
        Assert-AreEqual 2 $updatedPolicy.DetectionRules.Count
        Assert-Null ($updatedPolicy.DetectionRules | Where-Object { $_.TrafficType -eq "Udp" })

        # Remove the policy
        Remove-AzDdosCustomPolicy -Name $ddosCustomPolicyName -ResourceGroupName $rgName -PassThru | Out-Null
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgName
    }
}

<#
.SYNOPSIS
Test DDoS custom policy update and persistence using Set cmdlet
#>
function Test-DdosCustomPolicyCRUDWithSet
{
    $rgLocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/ddosCustomPolicies"
    $location = Get-ProviderLocation $resourceTypeParent

    $rgName = Get-ResourceGroupName
    $ddosCustomPolicyName = Get-ResourceName

    try
    {
        # Create the resource group
        New-AzResourceGroup -Name $rgName -Location $location

        # Create two detection rules
        $tcpRule = New-AzDdosCustomPolicyDetectionRule -Name tcpRule1 -TrafficType Tcp -PacketsPerSecond 1000000
        $udpRule = New-AzDdosCustomPolicyDetectionRule -Name udpRule1 -TrafficType Udp -PacketsPerSecond 100000

        # Create policy with two rules
        $ddosCustomPolicyNew = New-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName `
            -Location $rgLocation -DetectionRule @($tcpRule, $udpRule)
        Assert-AreEqual 2 $ddosCustomPolicyNew.DetectionRules.Count

        # Get policy and remove one rule via pipeline
        $policyUpdated = Get-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName |
            Remove-AzDdosCustomPolicyDetectionRule -Name tcpRule1

        Assert-AreEqual 1 $policyUpdated.DetectionRules.Count
        Assert-AreEqual "Udp" $policyUpdated.DetectionRules[0].TrafficType

        # Set (persist) the updated policy using pipeline
        $pipelineResult = $policyUpdated | Set-AzDdosCustomPolicy
        Assert-AreEqual 1 $pipelineResult.DetectionRules.Count

        # Verify the changes persisted in Azure
        $verifyPolicy = Get-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName
        Assert-AreEqual 1 $verifyPolicy.DetectionRules.Count
        Assert-AreEqual "Udp" $verifyPolicy.DetectionRules[0].TrafficType

        # Add a new rule through the add-rule cmdlet and persist again
        $verifyPolicy |
            Add-AzDdosCustomPolicyDetectionRule -Name tcpSynRule1 -TrafficType TcpSyn -PacketsPerSecond 50000 |
            Set-AzDdosCustomPolicy | Out-Null

        # Verify the new rule was added
        $finalPolicy = Get-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName
        Assert-AreEqual 2 $finalPolicy.DetectionRules.Count
        Assert-NotNull ($finalPolicy.DetectionRules | Where-Object { $_.TrafficType -eq "TcpSyn" })

        # Remove the policy
        Remove-AzDdosCustomPolicy -Name $ddosCustomPolicyName -ResourceGroupName $rgName -PassThru | Out-Null
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgName
    }
}

<#
.SYNOPSIS
Test comprehensive add detection rule workflow with validation
#>
function Test-DdosCustomPolicyAddDetectionRuleComprehensive
{
    $rgLocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/ddosCustomPolicies"
    $location = Get-ProviderLocation $resourceTypeParent

    $rgName = Get-ResourceGroupName
    $ddosCustomPolicyName = Get-ResourceName

    try
    {
        # Create the resource group
        New-AzResourceGroup -Name $rgName -Location $location

        # Creation phase: Create policy with TCP rule
        $tcpRule = New-AzDdosCustomPolicyDetectionRule -Name tcpRule1 -TrafficType Tcp -PacketsPerSecond 1000000
        $policy = New-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName `
            -Location $rgLocation -DetectionRule @($tcpRule)
        Assert-AreEqual 1 $policy.DetectionRules.Count

        # Test multiple add operations in sequence
        
        # Add UDP rule
        $policy = Get-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName
        $policy = $policy | Add-AzDdosCustomPolicyDetectionRule -Name udpRule1 -TrafficType Udp -PacketsPerSecond 100000
        Assert-AreEqual 2 $policy.DetectionRules.Count
        $policy | Set-AzDdosCustomPolicy | Out-Null

        # Add TcpSyn rule
        $policy = Get-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName
        $policy = $policy | Add-AzDdosCustomPolicyDetectionRule -Name tcpSynRule1 -TrafficType TcpSyn -PacketsPerSecond 50000
        Assert-AreEqual 3 $policy.DetectionRules.Count
        $policy | Set-AzDdosCustomPolicy | Out-Null

        # Verify all three rules exist in Azure
        $finalPolicy = Get-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName
        Assert-AreEqual 3 $finalPolicy.DetectionRules.Count
        Assert-NotNull ($finalPolicy.DetectionRules | Where-Object { $_.TrafficType -eq "Tcp" })
        Assert-NotNull ($finalPolicy.DetectionRules | Where-Object { $_.TrafficType -eq "Udp" })
        Assert-NotNull ($finalPolicy.DetectionRules | Where-Object { $_.TrafficType -eq "TcpSyn" })

        Remove-AzDdosCustomPolicy -Name $ddosCustomPolicyName -ResourceGroupName $rgName -PassThru | Out-Null
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgName
    }
}

<#
.SYNOPSIS
Test comprehensive remove detection rule workflow
#>
function Test-DdosCustomPolicyRemoveDetectionRuleComprehensive
{
    $rgLocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/ddosCustomPolicies"
    $location = Get-ProviderLocation $resourceTypeParent

    $rgName = Get-ResourceGroupName
    $ddosCustomPolicyName = Get-ResourceName

    try
    {
        # Create the resource group
        New-AzResourceGroup -Name $rgName -Location $location

        # Create policy with three rules
        $tcpRule = New-AzDdosCustomPolicyDetectionRule -Name tcpRule1 -TrafficType Tcp -PacketsPerSecond 1000000
        $udpRule = New-AzDdosCustomPolicyDetectionRule -Name udpRule1 -TrafficType Udp -PacketsPerSecond 100000
        $tcpSynRule = New-AzDdosCustomPolicyDetectionRule -Name tcpSynRule1 -TrafficType TcpSyn -PacketsPerSecond 50000

        $policy = New-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName `
            -Location $rgLocation -DetectionRule @($tcpRule, $udpRule, $tcpSynRule)
        Assert-AreEqual 3 $policy.DetectionRules.Count

        # Remove TCP rule
        $policy = Get-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName
        $policy = $policy | Remove-AzDdosCustomPolicyDetectionRule -Name tcpRule1
        Assert-AreEqual 2 $policy.DetectionRules.Count
        $policy | Set-AzDdosCustomPolicy | Out-Null

        # Verify removal persisted
        $verifyPolicy = Get-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName
        Assert-AreEqual 2 $verifyPolicy.DetectionRules.Count
        Assert-Null ($verifyPolicy.DetectionRules | Where-Object { $_.TrafficType -eq "Tcp" })
        Assert-NotNull ($verifyPolicy.DetectionRules | Where-Object { $_.TrafficType -eq "Udp" })

        # Remove UDP rule
        $verifyPolicy = $verifyPolicy | Remove-AzDdosCustomPolicyDetectionRule -Name udpRule1
        Assert-AreEqual 1 $verifyPolicy.DetectionRules.Count
        $verifyPolicy | Set-AzDdosCustomPolicy | Out-Null

        # Verify final state
        $finalPolicy = Get-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName
        Assert-AreEqual 1 $finalPolicy.DetectionRules.Count
        Assert-NotNull ($finalPolicy.DetectionRules | Where-Object { $_.TrafficType -eq "TcpSyn" })

        # Remove last rule (should null the collection)
        $finalPolicy = $finalPolicy | Remove-AzDdosCustomPolicyDetectionRule -Name tcpSynRule1
        Assert-Null $finalPolicy.DetectionRules
            # API does not allow Setting a policy with zero detection rules (DdosCustomPolicyNoPropertiesSet).
            # In-memory validation is sufficient; remove the policy to clean up.
            Remove-AzDdosCustomPolicy -Name $ddosCustomPolicyName -ResourceGroupName $rgName -PassThru | Out-Null
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgName
    }
}

<#
.SYNOPSIS
Test comprehensive set cmdlet with multiple scenarios
#>
function Test-DdosCustomPolicySetComprehensive
{
    $rgLocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/ddosCustomPolicies"
    $location = Get-ProviderLocation $resourceTypeParent

    $rgName = Get-ResourceGroupName
    $ddosCustomPolicyName = Get-ResourceName

    try
    {
        # Create the resource group
        New-AzResourceGroup -Name $rgName -Location $location

        # Create policy with single rule
        $tcpRule = New-AzDdosCustomPolicyDetectionRule -Name tcpRule1 -TrafficType Tcp -PacketsPerSecond 1000000
        $policy = New-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName `
            -Location $rgLocation -DetectionRule @($tcpRule)

        # Test 1: Add rule and set
        $policy = Get-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName
        $policy = $policy | Add-AzDdosCustomPolicyDetectionRule -Name udpRule1 -TrafficType Udp -PacketsPerSecond 100000
        $setResult = $policy | Set-AzDdosCustomPolicy
        Assert-AreEqual 2 $setResult.DetectionRules.Count

        # Test 2: Remove rule and set
        $policy = Get-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName
        $policy = $policy | Remove-AzDdosCustomPolicyDetectionRule -Name tcpRule1
        $setResult = $policy | Set-AzDdosCustomPolicy
        Assert-AreEqual 1 $setResult.DetectionRules.Count

        # Test 3: Complex workflow - add, remove, add, set
        $policy = Get-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName
        $policy = $policy |
            Add-AzDdosCustomPolicyDetectionRule -Name tcpRule2 -TrafficType Tcp -PacketsPerSecond 1000000 |
            Add-AzDdosCustomPolicyDetectionRule -Name tcpSynRule1 -TrafficType TcpSyn -PacketsPerSecond 50000
        Assert-AreEqual 3 $policy.DetectionRules.Count

        $policy = $policy | Remove-AzDdosCustomPolicyDetectionRule -Name udpRule1
        Assert-AreEqual 2 $policy.DetectionRules.Count

        $setResult = $policy | Set-AzDdosCustomPolicy
        Assert-AreEqual 2 $setResult.DetectionRules.Count

        # Verify final state in Azure
        $finalPolicy = Get-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName
        Assert-AreEqual 2 $finalPolicy.DetectionRules.Count
        Assert-NotNull ($finalPolicy.DetectionRules | Where-Object { $_.TrafficType -eq "Tcp" })
        Assert-NotNull ($finalPolicy.DetectionRules | Where-Object { $_.TrafficType -eq "TcpSyn" })

        Remove-AzDdosCustomPolicy -Name $ddosCustomPolicyName -ResourceGroupName $rgName -PassThru | Out-Null
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgName
    }
}

<#
.SYNOPSIS
Test detection rule parameter variations
#>
function Test-DdosCustomPolicyDetectionRuleParameterVariations
{
    # Test minimum packets per second
    $minRule = New-AzDdosCustomPolicyDetectionRule -Name minTcpRule -TrafficType Tcp -PacketsPerSecond 1
    Assert-AreEqual 1 $minRule.PacketsPerSecond

    # Test large packets per second
    $maxRule = New-AzDdosCustomPolicyDetectionRule -Name tcpRule1 -TrafficType Tcp -PacketsPerSecond 10000000
    Assert-AreEqual 10000000 $maxRule.PacketsPerSecond

    # Test each traffic type
    $tcpRule = New-AzDdosCustomPolicyDetectionRule -Name tcpRule1 -TrafficType Tcp -PacketsPerSecond 1000000
    Assert-AreEqual "Tcp" $tcpRule.TrafficType

    $udpRule = New-AzDdosCustomPolicyDetectionRule -Name udpRule1 -TrafficType Udp -PacketsPerSecond 100000
    Assert-AreEqual "Udp" $udpRule.TrafficType

    $tcpSynRule = New-AzDdosCustomPolicyDetectionRule -Name tcpSynRule1 -TrafficType TcpSyn -PacketsPerSecond 50000
    Assert-AreEqual "TcpSyn" $tcpSynRule.TrafficType
}

<#
.SYNOPSIS
Test policy creation with various rule counts
#>
function Test-DdosCustomPolicyCRUDWithVariousRuleCounts
{
    $rgLocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/ddosCustomPolicies"
    $location = Get-ProviderLocation $resourceTypeParent

    $rgName = Get-ResourceGroupName

    try
    {
        # Create the resource group
        New-AzResourceGroup -Name $rgName -Location $location

        # Test with 1 rule
        $policy1Name = Get-ResourceName
        $rule1 = New-AzDdosCustomPolicyDetectionRule -Name tcpRule1 -TrafficType Tcp -PacketsPerSecond 1000000
        $policy1 = New-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $policy1Name `
            -Location $rgLocation -DetectionRule @($rule1)
        Assert-AreEqual 1 $policy1.DetectionRules.Count

        # Test with 2 rules
        $policy2Name = Get-ResourceName
        $rule2a = New-AzDdosCustomPolicyDetectionRule -Name tcpRule1 -TrafficType Tcp -PacketsPerSecond 1000000
        $rule2b = New-AzDdosCustomPolicyDetectionRule -Name udpRule1 -TrafficType Udp -PacketsPerSecond 100000
        $policy2 = New-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $policy2Name `
            -Location $rgLocation -DetectionRule @($rule2a, $rule2b)
        Assert-AreEqual 2 $policy2.DetectionRules.Count

        # Test with 3 rules (max supported)
        $policy3Name = Get-ResourceName
        $rule3a = New-AzDdosCustomPolicyDetectionRule -Name tcpRule1 -TrafficType Tcp -PacketsPerSecond 1000000
        $rule3b = New-AzDdosCustomPolicyDetectionRule -Name udpRule1 -TrafficType Udp -PacketsPerSecond 100000
        $rule3c = New-AzDdosCustomPolicyDetectionRule -Name tcpSynRule1 -TrafficType TcpSyn -PacketsPerSecond 50000
        $policy3 = New-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $policy3Name `
            -Location $rgLocation -DetectionRule @($rule3a, $rule3b, $rule3c)
        Assert-AreEqual 3 $policy3.DetectionRules.Count

        # Cleanup
        Remove-AzDdosCustomPolicy -Name $policy1Name -ResourceGroupName $rgName -PassThru | Out-Null
        Remove-AzDdosCustomPolicy -Name $policy2Name -ResourceGroupName $rgName -PassThru | Out-Null
        Remove-AzDdosCustomPolicy -Name $policy3Name -ResourceGroupName $rgName -PassThru | Out-Null
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgName
    }
}

<#
.SYNOPSIS
Test in-memory mutation isolation (changes don't persist without Set)
#>
function Test-DdosCustomPolicyInMemoryMutationIsolation
{
    $rgLocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/ddosCustomPolicies"
    $location = Get-ProviderLocation $resourceTypeParent

    $rgName = Get-ResourceGroupName
    $ddosCustomPolicyName = Get-ResourceName

    try
    {
        # Create the resource group
        New-AzResourceGroup -Name $rgName -Location $location

        # Create policy
        $tcpRule = New-AzDdosCustomPolicyDetectionRule -Name tcpRule1 -TrafficType Tcp -PacketsPerSecond 1000000
        New-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName `
            -Location $rgLocation -DetectionRule @($tcpRule) | Out-Null

        # Add rule in-memory but don't set
        $localPolicy = Get-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName
        $localPolicy = $localPolicy | Add-AzDdosCustomPolicyDetectionRule -Name udpRule1 -TrafficType Udp -PacketsPerSecond 100000

        # Local policy should have 2 rules
        Assert-AreEqual 2 $localPolicy.DetectionRules.Count

        # But Azure should still have 1 rule
        $azurePolicy = Get-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName
        Assert-AreEqual 1 $azurePolicy.DetectionRules.Count

        # Now persist with Set
        $localPolicy | Set-AzDdosCustomPolicy | Out-Null

        # Now Azure should have 2 rules
        $azurePolicy = Get-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName
        Assert-AreEqual 2 $azurePolicy.DetectionRules.Count

        Remove-AzDdosCustomPolicy -Name $ddosCustomPolicyName -ResourceGroupName $rgName -PassThru | Out-Null
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgName
    }
}

<#
.SYNOPSIS
Test case-insensitive detection rule name handling in remove
#>
function Test-DdosCustomPolicyRemoveTrafficTypeCaseInsensitive
{
    $rgLocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/ddosCustomPolicies"
    $location = Get-ProviderLocation $resourceTypeParent

    $rgName = Get-ResourceGroupName
    $ddosCustomPolicyName = Get-ResourceName

    try
    {
        # Create the resource group
        New-AzResourceGroup -Name $rgName -Location $location

        # Create policy with mixed case rules
        $tcpRule = New-AzDdosCustomPolicyDetectionRule -Name tcpRule1 -TrafficType Tcp -PacketsPerSecond 1000000
        New-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName `
            -Location $rgLocation -DetectionRule @($tcpRule) | Out-Null

        # Try to remove with different case (should succeed due to case-insensitive matching)
        $policy = Get-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName
        $policy = $policy | Remove-AzDdosCustomPolicyDetectionRule -Name TCPRULE1
        Assert-Null $policy.DetectionRules

            # API does not allow Setting a policy with zero detection rules (DdosCustomPolicyNoPropertiesSet).
            # In-memory null assertion above is sufficient to verify case-insensitive matching worked.
            Remove-AzDdosCustomPolicy -Name $ddosCustomPolicyName -ResourceGroupName $rgName -PassThru | Out-Null
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgName
    }
}

<#
.SYNOPSIS
Test pipeline chaining of Add and Remove operations
#>
function Test-DdosCustomPolicyPipelineChaining
{
    $rgLocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/ddosCustomPolicies"
    $location = Get-ProviderLocation $resourceTypeParent

    $rgName = Get-ResourceGroupName
    $ddosCustomPolicyName = Get-ResourceName

    try
    {
        # Create the resource group
        New-AzResourceGroup -Name $rgName -Location $location

        # Create initial policy
        $tcpRule = New-AzDdosCustomPolicyDetectionRule -Name tcpRule1 -TrafficType Tcp -PacketsPerSecond 1000000
        New-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName `
            -Location $rgLocation -DetectionRule @($tcpRule) | Out-Null

        # Complex pipeline: Add multiple rules then remove one and set
        Get-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName |
            Add-AzDdosCustomPolicyDetectionRule -Name udpRule1 -TrafficType Udp -PacketsPerSecond 100000 |
            Add-AzDdosCustomPolicyDetectionRule -Name tcpSynRule1 -TrafficType TcpSyn -PacketsPerSecond 50000 |
            Remove-AzDdosCustomPolicyDetectionRule -Name udpRule1 |
            Set-AzDdosCustomPolicy | Out-Null

        # Verify final state
        $finalPolicy = Get-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName
        Assert-AreEqual 2 $finalPolicy.DetectionRules.Count
        Assert-NotNull ($finalPolicy.DetectionRules | Where-Object { $_.TrafficType -eq "Tcp" })
        Assert-NotNull ($finalPolicy.DetectionRules | Where-Object { $_.TrafficType -eq "TcpSyn" })
        Assert-Null ($finalPolicy.DetectionRules | Where-Object { $_.TrafficType -eq "Udp" })

        Remove-AzDdosCustomPolicy -Name $ddosCustomPolicyName -ResourceGroupName $rgName -PassThru | Out-Null
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgName
    }
}

<#
.SYNOPSIS
Test duplicate traffic type allowed in memory but rejected on persist
#>
function Test-DdosCustomPolicyDuplicateTrafficTypePersistFailure
{
    $rgLocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/ddosCustomPolicies"
    $location = Get-ProviderLocation $resourceTypeParent

    $rgName = Get-ResourceGroupName
    $ddosCustomPolicyName = Get-ResourceName

    try
    {
        # Create the resource group
        New-AzResourceGroup -Name $rgName -Location $location

        # Create initial policy with one TCP rule
        $tcpRule1 = New-AzDdosCustomPolicyDetectionRule -Name tcpRule1 -TrafficType Tcp -PacketsPerSecond 1000000
        New-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName `
            -Location $rgLocation -DetectionRule @($tcpRule1) | Out-Null

        # Add another TCP rule with a different name to in-memory object
        $afterSet = Get-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName
        $dupTcp = $afterSet | Add-AzDdosCustomPolicyDetectionRule -Name tcpRule2 -TrafficType Tcp -PacketsPerSecond 1200000

        # In-memory object now has duplicate traffic type entries
        Assert-AreEqual 2 $dupTcp.DetectionRules.Count
        Assert-AreEqual 2 (($dupTcp.DetectionRules | Where-Object { $_.TrafficType -eq "Tcp" }).Count)

        # Persist should fail from backend validation
        Assert-ThrowsLike {
            $dupTcp | Set-AzDdosCustomPolicy
        } "*"

        # Verify persisted resource remains unchanged
        $latest = Get-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName
        Assert-AreEqual 1 $latest.DetectionRules.Count
        Assert-AreEqual 1 (($latest.DetectionRules | Where-Object { $_.TrafficType -eq "Tcp" }).Count)

        Remove-AzDdosCustomPolicy -Name $ddosCustomPolicyName -ResourceGroupName $rgName -PassThru | Out-Null
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgName
    }
}

<#
.SYNOPSIS
Test creation of the nested mitigation rule objects.
#>
function Test-DdosCustomPolicyMitigationRuleCreation
{
    $tcpRule = New-AzDdosCustomPolicyMitigationRule -Name tcpRule -TrafficScope Tcp `
        -TcpPacketsPerSecond 100000 -TcpConnectionsPerSecond 10000 `
        -DenyIpPrefix @("192.0.2.0/24", "2001:db8::/32") `
        -DenyGeoMatch "Europe.DE" -PermitIpPrefix "198.51.100.0/24"
    Assert-AreEqual "tcpRule" $tcpRule.Name
    Assert-AreEqual "Tcp" $tcpRule.Properties.TrafficScope
    Assert-AreEqual 100000 $tcpRule.Properties.TcpDefaultMitigations.PerSourceRateLimiting.PacketsPerSecond
    Assert-AreEqual 10000 $tcpRule.Properties.TcpDefaultMitigations.PerSourceConnectionRateLimiting.ConnectionsPerSecond
    Assert-AreEqual 2 $tcpRule.Properties.SourcePolicyOverrides.Count
    Assert-AreEqual 2 $tcpRule.DenyIpPrefixes.Count
    Assert-AreEqual "Europe.DE" $tcpRule.DenyGeoMatches[0]
    Assert-AreEqual "198.51.100.0/24" $tcpRule.PermitIpPrefixes[0]

    $udpRule = New-AzDdosCustomPolicyMitigationRule -Name udpRule -TrafficScope Udp `
        -UdpPacketsPerSecond 90000 -PermitGeoMatch @("US", "Africa", "Africa.ZM")
    Assert-AreEqual "udpRule" $udpRule.Name
    Assert-AreEqual "Udp" $udpRule.Properties.TrafficScope
    Assert-AreEqual 90000 $udpRule.Properties.UdpDefaultMitigations.PerSourceRateLimiting.PacketsPerSecond
    Assert-AreEqual "Permit" $udpRule.Properties.SourcePolicyOverrides[0].PolicyAction.ActionType
    Assert-AreEqual "US" $udpRule.PermitGeoMatches[0]
    Assert-AreEqual "Africa" $udpRule.PermitGeoMatches[1]
    Assert-AreEqual "Africa.ZM" $udpRule.PermitGeoMatches[2]
}

<#
.SYNOPSIS
Test local mitigation rule validation.
#>
function Test-DdosCustomPolicyMitigationRuleValidation
{
    Assert-ThrowsLike {
        New-AzDdosCustomPolicyMitigationRule -Name invalidTcp -TrafficScope Tcp -UdpPacketsPerSecond 100
    } "*UdpPacketsPerSecond can only be used with a UDP mitigation rule*"

    Assert-ThrowsLike {
        New-AzDdosCustomPolicyMitigationRule -Name invalidUdp -TrafficScope Udp -TcpPacketsPerSecond 100
    } "*TCP rate limits can only be used with a TCP mitigation rule*"

    $serviceValidatedRule = New-AzDdosCustomPolicyMitigationRule -Name serviceValidated -TrafficScope Tcp `
        -TcpPacketsPerSecond -1 -DenyIpPrefix "not-a-cidr" -DenyGeoMatch "invalid-country"
    Assert-AreEqual -1 $serviceValidatedRule.Properties.TcpDefaultMitigations.PerSourceRateLimiting.PacketsPerSecond
    Assert-AreEqual "not-a-cidr" $serviceValidatedRule.DenyIpPrefixes[0]

    $emptyRule = New-AzDdosCustomPolicyMitigationRule -Name emptyRule -TrafficScope Tcp
    Assert-NotNull $emptyRule

    Assert-ThrowsLike {
        New-AzDdosCustomPolicyMitigationRule -Name invalidGeo -TrafficScope Tcp -DenyGeoMatch "Europe.DE.extra"
    } "*must use <Country>, <Continent>, or <Continent>.<Country> format*"
}

<#
.SYNOPSIS
Test case-insensitive in-memory mitigation rule mutation.
#>
function Test-DdosCustomPolicyMitigationRuleMutation
{
    $policy = [Microsoft.Azure.Commands.Network.Models.PSDdosCustomPolicy]::new()
    $policy.Name = "policy"

    $policy = $policy | Add-AzDdosCustomPolicyMitigationRule -Name tcpRule -TrafficScope Tcp `
        -TcpPacketsPerSecond 100000 -DenyIpPrefix "192.0.2.0/24"
    $policy = $policy | Add-AzDdosCustomPolicyMitigationRule -Name udpRule -TrafficScope Udp `
        -UdpPacketsPerSecond 90000
    Assert-AreEqual 2 $policy.MitigationRules.Count

    $tcpRule = $policy | Get-AzDdosCustomPolicyMitigationRule -Name TCPRULE
    Assert-AreEqual 100000 $tcpRule.Properties.TcpDefaultMitigations.PerSourceRateLimiting.PacketsPerSecond

    $policy = $policy | Set-AzDdosCustomPolicyMitigationRule -Name TcPrUlE `
        -TcpConnectionsPerSecond 15000
    $tcpRule = $policy | Get-AzDdosCustomPolicyMitigationRule -Name tcpRule
    Assert-AreEqual 100000 $tcpRule.Properties.TcpDefaultMitigations.PerSourceRateLimiting.PacketsPerSecond
    Assert-AreEqual 15000 $tcpRule.Properties.TcpDefaultMitigations.PerSourceConnectionRateLimiting.ConnectionsPerSecond
    Assert-AreEqual "192.0.2.0/24" $tcpRule.DenyIpPrefixes[0]

    $policy = $policy | Set-AzDdosCustomPolicyMitigationRule -Name tcpRule `
        -TcpPacketsPerSecond 150000
    $tcpRule = $policy | Get-AzDdosCustomPolicyMitigationRule -Name tcpRule
    Assert-AreEqual 150000 $tcpRule.Properties.TcpDefaultMitigations.PerSourceRateLimiting.PacketsPerSecond
    Assert-AreEqual 15000 $tcpRule.Properties.TcpDefaultMitigations.PerSourceConnectionRateLimiting.ConnectionsPerSecond
    Assert-AreEqual "192.0.2.0/24" $tcpRule.DenyIpPrefixes[0]

    Assert-ThrowsLike {
        $policy | Add-AzDdosCustomPolicyMitigationRule -Name TCPRULE -TrafficScope Tcp -TcpPacketsPerSecond 100
    } "*already exists*"

    $policy = $policy | Remove-AzDdosCustomPolicyMitigationRule -Name UDPRULE
    Assert-AreEqual 1 $policy.MitigationRules.Count
    Assert-AreEqual "tcpRule" $policy.MitigationRules[0].Name

    Assert-ThrowsLike {
        $policy | Get-AzDdosCustomPolicyMitigationRule -Name missingRule
    } "*was not found*"
}

<#
.SYNOPSIS
Test mitigation-rule edge cases and failure atomicity.
#>
function Test-DdosCustomPolicyMitigationRuleEdgeCases
{
    $policy = [Microsoft.Azure.Commands.Network.Models.PSDdosCustomPolicy]::new()
    $policy.Name = "policy"
    $policy = $policy | Add-AzDdosCustomPolicyMitigationRule -Name tcpRule -TrafficScope Tcp `
        -TcpPacketsPerSecond 100000 -TcpConnectionsPerSecond 10000 `
        -DenyIpPrefix "192.0.2.0/24" -DenyGeoMatch "Europe.DE" `
        -PermitIpPrefix "198.51.100.0/24"
    $policy = $policy | Add-AzDdosCustomPolicyMitigationRule -Name udpRule -TrafficScope Udp `
        -UdpPacketsPerSecond 90000

    $allRules = $policy | Get-AzDdosCustomPolicyMitigationRule
    Assert-AreEqual 2 $allRules.Count

    $policy = $policy | Add-AzDdosCustomPolicyMitigationRule -Name secondTcpRule -TrafficScope Tcp `
        -TcpPacketsPerSecond 200000
    Assert-AreEqual 3 $policy.MitigationRules.Count

    $tcpRule = $policy | Get-AzDdosCustomPolicyMitigationRule -Name tcpRule
    $tcpRule.Id = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Network/ddosCustomPolicies/policy/ddosMitigationRules/tcpRule"
    $tcpRule.Etag = "etag"
    $tcpRule.Type = "Microsoft.Network/ddosCustomPolicies/ddosMitigationRules"
    $tcpRule.Properties.ProvisioningState = "Succeeded"
    $policy = $policy | Set-AzDdosCustomPolicyMitigationRule -Name tcpRule
    $tcpRule = $policy | Get-AzDdosCustomPolicyMitigationRule -Name tcpRule
    Assert-AreEqual "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Network/ddosCustomPolicies/policy/ddosMitigationRules/tcpRule" $tcpRule.Id
    Assert-AreEqual "etag" $tcpRule.Etag
    Assert-AreEqual "Microsoft.Network/ddosCustomPolicies/ddosMitigationRules" $tcpRule.Type
    Assert-AreEqual "Succeeded" $tcpRule.Properties.ProvisioningState
    Assert-AreEqual 100000 $tcpRule.Properties.TcpDefaultMitigations.PerSourceRateLimiting.PacketsPerSecond
    Assert-AreEqual 10000 $tcpRule.Properties.TcpDefaultMitigations.PerSourceConnectionRateLimiting.ConnectionsPerSecond
    Assert-AreEqual "192.0.2.0/24" $tcpRule.DenyIpPrefixes[0]

    $policy = $policy | Set-AzDdosCustomPolicyMitigationRule -Name tcpRule `
        -DenyIpPrefix @()
    $tcpRule = $policy | Get-AzDdosCustomPolicyMitigationRule -Name tcpRule
    Assert-AreEqual 0 $tcpRule.DenyIpPrefixes.Count
    Assert-AreEqual "Europe.DE" $tcpRule.DenyGeoMatches[0]
    Assert-AreEqual "198.51.100.0/24" $tcpRule.PermitIpPrefixes[0]
    Assert-AreEqual 100000 $tcpRule.Properties.TcpDefaultMitigations.PerSourceRateLimiting.PacketsPerSecond
    Assert-AreEqual 10000 $tcpRule.Properties.TcpDefaultMitigations.PerSourceConnectionRateLimiting.ConnectionsPerSecond

    $policy = $policy | Set-AzDdosCustomPolicyMitigationRule -Name tcpRule `
        -DenyGeoMatch @()
    $tcpRule = $policy | Get-AzDdosCustomPolicyMitigationRule -Name tcpRule
    Assert-AreEqual 0 $tcpRule.DenyIpPrefixes.Count
    Assert-AreEqual 0 $tcpRule.DenyGeoMatches.Count
    Assert-AreEqual "198.51.100.0/24" $tcpRule.PermitIpPrefixes[0]

    $futureOverride = [Microsoft.Azure.Commands.Network.Models.PSDdosCustomPolicySourcePolicyOverride]::new()
    $futureOverride.PolicyAction = [Microsoft.Azure.Commands.Network.Models.PSDdosCustomPolicySourcePolicyAction]::new()
    $futureOverride.PolicyAction.ActionType = "FutureAction"
    $futureOverride.Conditions = [Microsoft.Azure.Commands.Network.Models.PSDdosCustomPolicySourceMatchConditions]::new()
    $futureOverride.Conditions.IpPrefixes = [System.Collections.Generic.List[string]]@("203.0.113.0/24")
    $tcpRule.Properties.SourcePolicyOverrides.Add($futureOverride)
    $policy = $policy | Set-AzDdosCustomPolicyMitigationRule -Name tcpRule `
        -PermitIpPrefix @()
    $tcpRule = $policy | Get-AzDdosCustomPolicyMitigationRule -Name tcpRule
    Assert-AreEqual 0 $tcpRule.PermitIpPrefixes.Count
    Assert-AreEqual 1 ($tcpRule.Properties.SourcePolicyOverrides | Where-Object { $_.PolicyAction.ActionType -eq "FutureAction" }).Count

    $emptyPolicy = [Microsoft.Azure.Commands.Network.Models.PSDdosCustomPolicy]::new()
    $emptyPolicy.Name = "emptyPolicy"
    Assert-AreEqual 0 @($emptyPolicy | Get-AzDdosCustomPolicyMitigationRule).Count
    $emptyPolicy = $emptyPolicy | Add-AzDdosCustomPolicyMitigationRule -Name serviceValidatedRule -TrafficScope Tcp
    Assert-AreEqual 1 $emptyPolicy.MitigationRules.Count
    $emptyPolicy = $emptyPolicy |
        Remove-AzDdosCustomPolicyMitigationRule -Name missingRule
    Assert-AreEqual 1 $emptyPolicy.MitigationRules.Count

    $policy = $policy |
        Remove-AzDdosCustomPolicyMitigationRule -Name missingRule
    Assert-AreEqual 3 $policy.MitigationRules.Count

    $policy = $policy | Remove-AzDdosCustomPolicyMitigationRule -Name UDPRULE
    Assert-AreEqual 2 $policy.MitigationRules.Count
    $policy = $policy | Remove-AzDdosCustomPolicyMitigationRule -Name TCPRULE
    Assert-AreEqual 1 $policy.MitigationRules.Count
}

<#
.SYNOPSIS
Test persisted mitigation rule CRUD on a DDoS custom policy.
#>
function Test-DdosCustomPolicyMitigationRuleCRUD
{
    $resourceTypeParent = "Microsoft.Network/ddosCustomPolicies"
    $location = "eastus2euap"
    $rgName = Get-ResourceGroupName
    $policyName = Get-ResourceName

    try
    {
        New-AzResourceGroup -Name $rgName -Location $location

        $detectionRule = New-AzDdosCustomPolicyDetectionRule -Name detectionRule -TrafficType Tcp `
            -PacketsPerSecond 120000
        $tcpRule = New-AzDdosCustomPolicyMitigationRule -Name tcpRule -TrafficScope Tcp `
            -TcpPacketsPerSecond 120000 -TcpConnectionsPerSecond 12000 `
            -DenyIpPrefix "192.0.2.0/24" -DenyGeoMatch "Europe.DE"

        $policy = New-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $policyName `
            -Location $location -DetectionRule @($detectionRule) -MitigationRule @($tcpRule)
        Assert-NotNull $policy
        Assert-AreEqual 1 $policy.DetectionRules.Count
        Assert-AreEqual 1 $policy.MitigationRules.Count
        Assert-AreEqual "tcpRule" $policy.MitigationRules[0].Name
        Assert-AreEqual "Tcp" $policy.MitigationRules[0].Properties.TrafficScope

        $policy = Get-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $policyName
        $persistedTcpRule = $policy | Get-AzDdosCustomPolicyMitigationRule -Name TCPRULE
        Assert-AreEqual 120000 $persistedTcpRule.Properties.TcpDefaultMitigations.PerSourceRateLimiting.PacketsPerSecond
        Assert-AreEqual 12000 $persistedTcpRule.Properties.TcpDefaultMitigations.PerSourceConnectionRateLimiting.ConnectionsPerSecond
        Assert-AreEqual "192.0.2.0/24" $persistedTcpRule.DenyIpPrefixes[0]
        Assert-AreEqual "Europe.DE" $persistedTcpRule.DenyGeoMatches[0]

        $policy = $policy | Add-AzDdosCustomPolicyMitigationRule -Name udpRule -TrafficScope Udp `
            -UdpPacketsPerSecond 90000 -PermitIpPrefix "198.51.100.0/24"
        $policy = $policy | Set-AzDdosCustomPolicy

        $policy = Get-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $policyName
        $persistedUdpRule = $policy | Get-AzDdosCustomPolicyMitigationRule -Name UDPRULE
        Assert-AreEqual 2 $policy.MitigationRules.Count
        Assert-AreEqual 90000 $persistedUdpRule.Properties.UdpDefaultMitigations.PerSourceRateLimiting.PacketsPerSecond
        Assert-AreEqual "198.51.100.0/24" $persistedUdpRule.PermitIpPrefixes[0]

        $policy = $policy | Set-AzDdosCustomPolicyMitigationRule -Name tcpRule `
            -TcpPacketsPerSecond 140000 -TcpConnectionsPerSecond 14000 `
            -DenyGeoMatch @("US", "Africa.ZM", "MX")
        $policy = $policy | Set-AzDdosCustomPolicy

        $policy = Get-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $policyName
        $persistedTcpRule = $policy | Get-AzDdosCustomPolicyMitigationRule -Name tcpRule
        $persistedUdpRule = $policy | Get-AzDdosCustomPolicyMitigationRule -Name udpRule
        Assert-AreEqual 2 $policy.MitigationRules.Count
        Assert-AreEqual 140000 $persistedTcpRule.Properties.TcpDefaultMitigations.PerSourceRateLimiting.PacketsPerSecond
        Assert-AreEqual 14000 $persistedTcpRule.Properties.TcpDefaultMitigations.PerSourceConnectionRateLimiting.ConnectionsPerSecond
        Assert-AreEqual 3 $persistedTcpRule.DenyGeoMatches.Count
        Assert-AreEqual 90000 $persistedUdpRule.Properties.UdpDefaultMitigations.PerSourceRateLimiting.PacketsPerSecond
        Assert-AreEqual 1 $policy.DetectionRules.Count

        $policy = $policy | Remove-AzDdosCustomPolicyMitigationRule -Name udpRule
        $policy = $policy | Set-AzDdosCustomPolicy

        $policy = Get-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $policyName
        $persistedTcpRule = $policy | Get-AzDdosCustomPolicyMitigationRule -Name tcpRule
        Assert-AreEqual 1 $policy.MitigationRules.Count
        Assert-AreEqual 1 $policy.DetectionRules.Count

        $policy = $policy | Set-AzDdosCustomPolicyMitigationRule -Name tcpRule `
            -TcpConnectionsPerSecond $null -DenyIpPrefix @() -DenyGeoMatch @()
        $policy = $policy | Set-AzDdosCustomPolicy

        $policy = Get-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $policyName
        $persistedTcpRule = $policy | Get-AzDdosCustomPolicyMitigationRule -Name tcpRule
        Assert-AreEqual 140000 $persistedTcpRule.Properties.TcpDefaultMitigations.PerSourceRateLimiting.PacketsPerSecond
        Assert-Null $persistedTcpRule.Properties.TcpDefaultMitigations.PerSourceConnectionRateLimiting
        Assert-AreEqual 0 $persistedTcpRule.DenyIpPrefixes.Count
        Assert-AreEqual 0 $persistedTcpRule.DenyGeoMatches.Count

        $policy = $policy | Set-AzDdosCustomPolicy
        Assert-AreEqual 1 $policy.DetectionRules.Count
        Assert-AreEqual 1 $policy.MitigationRules.Count

        $policy = $policy | Remove-AzDdosCustomPolicyMitigationRule -Name tcpRule
        $policy = $policy | Set-AzDdosCustomPolicy
        $policy = Get-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $policyName
        Assert-AreEqual 1 $policy.DetectionRules.Count
        Assert-AreEqual 0 @($policy.MitigationRules).Count

        Remove-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $policyName -PassThru | Out-Null
    }
    finally
    {
        Clean-ResourceGroup $rgName
    }
}
