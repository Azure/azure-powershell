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
function Test-DdosCustomPolicyCRUD
{
    $rgLocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/DdosCustomPolicies"
    $location = Get-ProviderLocation $resourceTypeParent

    $rgName = Get-ResourceGroupName
    $ddosCustomPolicyName = Get-ResourceName

    try
    {
        # Create the resource group
        New-AzResourceGroup -Name $rgName -Location $location -Tags @{ testtag = "ddosCustomPolicy tag" }

        # Create the DDoS custom policy
        $job = New-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName -Location $rgLocation -TrafficType Tcp -PacketsPerSecond 1000000 -AsJob
        $job | Wait-Job
        $ddosCustomPolicyNew = $job | Receive-Job

        Assert-AreEqual $rgName $ddosCustomPolicyNew.ResourceGroupName
        Assert-AreEqual $ddosCustomPolicyName $ddosCustomPolicyNew.Name
        Assert-NotNull $ddosCustomPolicyNew.Location
        Assert-NotNull $ddosCustomPolicyNew.Etag
        Assert-NotNull $ddosCustomPolicyNew.ProvisioningState

        # Get the DDoS custom policy
        $ddosCustomPolicyGet = Get-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName
        Assert-AreEqual $rgName $ddosCustomPolicyGet.ResourceGroupName
        Assert-AreEqual $ddosCustomPolicyName $ddosCustomPolicyGet.Name
        Assert-NotNull $ddosCustomPolicyGet.Location
        Assert-NotNull $ddosCustomPolicyGet.Etag

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
DDoS custom policy creation with tags
#>
function Test-DdosCustomPolicyCRUDWithTags
{
    $rgLocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/DdosCustomPolicies"
    $location = Get-ProviderLocation $resourceTypeParent

    $rgName = Get-ResourceGroupName
    $ddosCustomPolicyName = Get-ResourceName
    $tags = @{ Environment = "Test"; Project = "DdosCustomPolicy" }

    try
    {
        # Create the resource group
        New-AzResourceGroup -Name $rgName -Location $location -Tags @{ testtag = "ddosCustomPolicy tag" }

        # Create the DDoS custom policy with tags
        $ddosCustomPolicy = New-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName -Location $rgLocation -TrafficType Tcp -PacketsPerSecond 1000000 -Tag $tags

        Assert-AreEqual $rgName $ddosCustomPolicy.ResourceGroupName
        Assert-AreEqual $ddosCustomPolicyName $ddosCustomPolicy.Name
        Assert-NotNull $ddosCustomPolicy.Tag
        Assert-AreEqual "Test" $ddosCustomPolicy.Tag["Environment"]
        Assert-AreEqual "DdosCustomPolicy" $ddosCustomPolicy.Tag["Project"]

        # Get and verify tags
        $ddosCustomPolicyGet = Get-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName
        Assert-AreEqual "Test" $ddosCustomPolicyGet.Tag["Environment"]

        # Remove the DDoS custom policy
        Remove-AzDdosCustomPolicy -Name $ddosCustomPolicyName -ResourceGroupName $rgName
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgName
    }
}

<#
.SYNOPSIS
Test DDoS custom policy linkage with Load Balancer Frontend IP Config
#>
function Test-LoadBalancerFrontendWithDdosCustomPolicy
{
    $resourceTypeParent = "Microsoft.Network/loadBalancers"
    $location = Get-ProviderLocation $resourceTypeParent

    $rgName = Get-ResourceGroupName
    $lbName = Get-ResourceName
    $pipName = Get-ResourceName
    $frontendName = Get-ResourceName
    $ddosCustomPolicyName = Get-ResourceName

    try
    {
        # Create the resource group
        New-AzResourceGroup -Name $rgName -Location $location

        # Create DDoS custom policy
        $ddosCustomPolicy = New-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName -Location $location -TrafficType Tcp -PacketsPerSecond 1000000

        # Create Public IP Address
        $publicIp = New-AzPublicIpAddress -ResourceGroupName $rgName -Name $pipName -Location $location -AllocationMethod Static

        # Create frontend IP config with DDoS custom policy
        $frontendIpConfig = New-AzLoadBalancerFrontendIpConfig -Name $frontendName -PublicIpAddress $publicIp -DdosCustomPolicyId $ddosCustomPolicy.Id

        Assert-NotNull $frontendIpConfig
        Assert-AreEqual $frontendName $frontendIpConfig.Name

        # Create Load Balancer backend pool
        $backendPool = New-AzLoadBalancerBackendAddressPoolConfig -Name "BackendPool"

        # Create Load Balancer with frontend config
        $loadBalancer = New-AzLoadBalancer -ResourceGroupName $rgName -Name $lbName -Location $location `
            -FrontendIpConfiguration $frontendIpConfig -BackendAddressPool $backendPool

        Assert-NotNull $loadBalancer
        Assert-AreEqual $lbName $loadBalancer.Name

        # Verify frontend has DDoS custom policy
        $frontendFromLb = Get-AzLoadBalancerFrontendIpConfig -LoadBalancer $loadBalancer -Name $frontendName
        Assert-NotNull $frontendFromLb
        Assert-NotNull $frontendFromLb.DdosSettings
        Assert-NotNull $frontendFromLb.DdosSettings.DdosCustomPolicy
        Assert-AreEqual $ddosCustomPolicy.Id $frontendFromLb.DdosSettings.DdosCustomPolicy.Id

        $ddosCustomPolicyGet = Get-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName
        Assert-NotNull $ddosCustomPolicyGet.FrontEndIPConfiguration
        Assert-AreEqual 1 $ddosCustomPolicyGet.FrontEndIPConfiguration.Count
        Assert-AreEqual $frontendFromLb.Id $ddosCustomPolicyGet.FrontEndIPConfiguration[0].Id

        # Test Set-AzLoadBalancerFrontendIpConfig with new DDoS policy
        $ddosCustomPolicy2Name = Get-ResourceName
        $ddosCustomPolicy2 = New-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicy2Name -Location $location -TrafficType Tcp -PacketsPerSecond 1000000

        $loadBalancer = Set-AzLoadBalancerFrontendIpConfig -LoadBalancer $loadBalancer -Name $frontendName `
            -PublicIpAddress $publicIp -DdosCustomPolicyId $ddosCustomPolicy2.Id

        Set-AzLoadBalancer -LoadBalancer $loadBalancer | Out-Null
        $loadBalancerUpdated = Get-AzLoadBalancer -ResourceGroupName $rgName -Name $lbName
        $frontendIpConfig2 = Get-AzLoadBalancerFrontendIpConfig -LoadBalancer $loadBalancerUpdated -Name $frontendName

        Assert-NotNull $frontendIpConfig2.DdosSettings
        Assert-AreEqual $ddosCustomPolicy2.Id $frontendIpConfig2.DdosSettings.DdosCustomPolicy.Id

        # Cleanup
        Remove-AzLoadBalancer -ResourceGroupName $rgName -Name $lbName -Force
        Remove-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName
        Remove-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicy2Name
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgName
    }
}

<#
.SYNOPSIS
Test Add-AzLoadBalancerFrontendIpConfig with DDoS custom policy
#>
function Test-AddLoadBalancerFrontendWithDdosCustomPolicy
{
    $resourceTypeParent = "Microsoft.Network/loadBalancers"
    $location = Get-ProviderLocation $resourceTypeParent

    $rgName = Get-ResourceGroupName
    $lbName = Get-ResourceName
    $pipName1 = Get-ResourceName
    $pipName2 = Get-ResourceName
    $frontendName1 = Get-ResourceName
    $frontendName2 = Get-ResourceName
    $ddosCustomPolicyName = Get-ResourceName

    try
    {
        # Create the resource group
        New-AzResourceGroup -Name $rgName -Location $location

        # Create DDoS custom policy
        $ddosCustomPolicy = New-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName -Location $location -TrafficType Tcp -PacketsPerSecond 1000000

        # Create first Public IP Address
        $publicIp1 = New-AzPublicIpAddress -ResourceGroupName $rgName -Name $pipName1 -Location $location -AllocationMethod Static

        # Create first frontend IP config
        $frontendIpConfig1 = New-AzLoadBalancerFrontendIpConfig -Name $frontendName1 -PublicIpAddress $publicIp1

        # Create Load Balancer backend pool
        $backendPool = New-AzLoadBalancerBackendAddressPoolConfig -Name "BackendPool"

        # Create Load Balancer with first frontend config
        $loadBalancer = New-AzLoadBalancer -ResourceGroupName $rgName -Name $lbName -Location $location `
            -FrontendIpConfiguration $frontendIpConfig1 -BackendAddressPool $backendPool

        # Create second Public IP Address
        $publicIp2 = New-AzPublicIpAddress -ResourceGroupName $rgName -Name $pipName2 -Location $location -AllocationMethod Static

        # Add second frontend with DDoS custom policy
        Add-AzLoadBalancerFrontendIpConfig -LoadBalancer $loadBalancer -Name $frontendName2 `
            -PublicIpAddress $publicIp2 -DdosCustomPolicyId $ddosCustomPolicy.Id

        $loadBalancer | Set-AzLoadBalancer

        # Verify the LoadBalancer now has two frontends
        $loadBalancerUpdated = Get-AzLoadBalancer -ResourceGroupName $rgName -Name $lbName
        Assert-AreEqual 2 $loadBalancerUpdated.FrontendIpConfigurations.Count

        # Verify second frontend has DDoS custom policy
        $frontendFromLb = Get-AzLoadBalancerFrontendIpConfig -LoadBalancer $loadBalancerUpdated -Name $frontendName2
        Assert-NotNull $frontendFromLb.DdosSettings
        Assert-AreEqual $ddosCustomPolicy.Id $frontendFromLb.DdosSettings.DdosCustomPolicy.Id

        $ddosCustomPolicyGet = Get-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName
        Assert-NotNull $ddosCustomPolicyGet.FrontEndIPConfiguration
        Assert-AreEqual 1 $ddosCustomPolicyGet.FrontEndIPConfiguration.Count
        Assert-AreEqual $frontendFromLb.Id $ddosCustomPolicyGet.FrontEndIPConfiguration[0].Id

        # Cleanup
        Remove-AzLoadBalancer -ResourceGroupName $rgName -Name $lbName -Force
        Remove-AzDdosCustomPolicy -ResourceGroupName $rgName -Name $ddosCustomPolicyName
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgName
    }
}
