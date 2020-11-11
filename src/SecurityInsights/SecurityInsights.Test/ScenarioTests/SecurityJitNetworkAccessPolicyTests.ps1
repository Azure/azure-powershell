# ----------------------------------------------------------------------------------
#
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
Get JIT network access policies on a subscription
#>
function Get-AzureRmJitNetworkAccessPolicy-SubscriptionScope
{
	Set-AzureRmJitNetworkAccessPolicy-ResourceGroupLevelResource

    $jitNetworkAccessPolicies = Get-AzJitNetworkAccessPolicy
	Validate-JitNetworkAccessPolicies $jitNetworkAccessPolicies
}

<#
.SYNOPSIS
Get JIT network access policies on a resource group
#>
function Get-AzureRmJitNetworkAccessPolicy-ResourceGroupScope
{
	Set-AzureRmJitNetworkAccessPolicy-ResourceGroupLevelResource

	$rgName = Get-TestResourceGroupName

    $jitNetworkAccessPolicies = Get-AzJitNetworkAccessPolicy -ResourceGroupName $rgName
	Validate-JitNetworkAccessPolicies $jitNetworkAccessPolicies
}

<#
.SYNOPSIS
Get JIT network access policy
#>
function Get-AzureRmJitNetworkAccessPolicy-ResourceGroupLevelResource
{
	$jitNetworkAccessPolicy = Set-AzureRmJitNetworkAccessPolicy-ResourceGroupLevelResource

	$rgName = Extract-ResourceGroup -ResourceId $jitNetworkAccessPolicy.Id
	$location = Extract-ResourceLocation -ResourceId $jitNetworkAccessPolicy.Id

    $fetchedJitNetworkAccessPolicy = Get-AzJitNetworkAccessPolicy -ResourceGroupName $rgName -Location $location -Name $jitNetworkAccessPolicy.Name
	Validate-JitNetworkAccessPolicy $fetchedJitNetworkAccessPolicy
}

<#
.SYNOPSIS
Get JIT network access policy by Resource ID
#>
function Get-AzureRmJitNetworkAccessPolicy-ResourceId
{
	$jitNetworkAccessPolicy = Set-AzureRmJitNetworkAccessPolicy-ResourceGroupLevelResource

    $fetchedJitNetworkAccessPolicy = Get-AzJitNetworkAccessPolicy -ResourceId $jitNetworkAccessPolicy.Id
	Validate-JitNetworkAccessPolicy $fetchedJitNetworkAccessPolicy
}

<#
.SYNOPSIS
Set a JIT network access policy
#>
function Set-AzureRmJitNetworkAccessPolicy-ResourceGroupLevelResource
{
	Set-AzSecurityPricing -Name "VirtualMachines" -PricingTier "Standard" | Out-Null

	$rgName = Get-TestResourceGroupName

	[Microsoft.Azure.Commands.Security.Models.JitNetworkAccessPolicies.PSSecurityJitNetworkAccessPolicyVirtualMachine]$vm = New-Object -TypeName Microsoft.Azure.Commands.Security.Models.JitNetworkAccessPolicies.PSSecurityJitNetworkAccessPolicyVirtualMachine
	  $vm.Id = "/subscriptions/487bb485-b5b0-471e-9c0d-10717612f869/resourceGroups/myService1/providers/Microsoft.Compute/virtualMachines/testService"
	[Microsoft.Azure.Commands.Security.Models.JitNetworkAccessPolicies.PSSecurityJitNetworkAccessPortRule]$port = New-Object -TypeName Microsoft.Azure.Commands.Security.Models.JitNetworkAccessPolicies.PSSecurityJitNetworkAccessPortRule
	$port.AllowedSourceAddressPrefix = "127.0.0.1"
	$port.MaxRequestAccessDuration = "PT3H"
	$port.Number = 22
	$port.Protocol = "TCP"
	$vm.Ports = [Microsoft.Azure.Commands.Security.Models.JitNetworkAccessPolicies.PSSecurityJitNetworkAccessPortRule[]](,$port)

	[Microsoft.Azure.Commands.Security.Models.JitNetworkAccessPolicies.PSSecurityJitNetworkAccessPolicyVirtualMachine[]]$vms = (,$vm)

    return Set-AzureRmJitNetworkAccessPolicy -ResourceGroupName $rgName -Location "centralus" -Name "default" -Kind "Basic" -VirtualMachine $vms
}

<#
.SYNOPSIS
Delete JIT network access policy
#>
function Remove-AzureRmJitNetworkAccessPolicy-ResourceGroupLevelResource
{
	Set-AzureRmJitNetworkAccessPolicy-ResourceGroupLevelResource

	$rgName = Get-TestResourceGroupName

    Remove-AzJitNetworkAccessPolicy -ResourceGroupName $rgName -Location "centralus" -Name "default"
}

<#
.SYNOPSIS
Delete JIT network access policy by resource ID
#>
function Remove-AzureRmJitNetworkAccessPolicy-ResourceId
{
	$jitNetworkAccessPolicy = Set-AzureRmJitNetworkAccessPolicy-ResourceGroupLevelResource

	$rgName = Get-TestResourceGroupName

    Remove-AzJitNetworkAccessPolicy -ResourceId $jitNetworkAccessPolicy.Id
}

<#
.SYNOPSIS
Initiate JIT network access policy request
#>
function Start-AzureRmJitNetworkAccessPolicy-ResourceGroupLevelResource
{
	$jitNetworkAccessPolicy = Set-AzureRmJitNetworkAccessPolicy-ResourceGroupLevelResource

	$rgName = Get-TestResourceGroupName

	[Microsoft.Azure.Commands.Security.Models.JitNetworkAccessPolicies.PSSecurityJitNetworkAccessPolicyInitiateVirtualMachine]$vm = New-Object -TypeName Microsoft.Azure.Commands.Security.Models.JitNetworkAccessPolicies.PSSecurityJitNetworkAccessPolicyInitiateVirtualMachine
	$vm.Id = "/subscriptions/487bb485-b5b0-471e-9c0d-10717612f869/resourceGroups/myService1/providers/Microsoft.Compute/virtualMachines/testService"
	[Microsoft.Azure.Commands.Security.Models.JitNetworkAccessPolicies.PSSecurityJitNetworkAccessPolicyInitiatePort]$port = New-Object -TypeName Microsoft.Azure.Commands.Security.Models.JitNetworkAccessPolicies.PSSecurityJitNetworkAccessPolicyInitiatePort
	$port.AllowedSourceAddressPrefix = "127.0.0.1"
	$port.EndTimeUtc = [DateTime]::UtcNow.AddHours(2)
	$port.Number = 22
	$vm.Ports = (,$port)

    Start-AzJitNetworkAccessPolicy -ResourceGroupName $rgName -Location "centralus" -Name "default" -VirtualMachine (,$vm)
}

<#
.SYNOPSIS
Validates a list of security jitNetworkAccessPolicies
#>
function Validate-JitNetworkAccessPolicies
{
	param($jitNetworkAccessPolicies)

    Assert-True { $jitNetworkAccessPolicies.Count -gt 0 }

	Foreach($jitNetworkAccessPolicy in $jitNetworkAccessPolicies)
	{
		Validate-JitNetworkAccessPolicy $jitNetworkAccessPolicy
	}
}

<#
.SYNOPSIS
Validates a single jitNetworkAccessPolicy
#>
function Validate-JitNetworkAccessPolicy
{
	param($jitNetworkAccessPolicy)

	Assert-NotNull $jitNetworkAccessPolicy
}