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
Tests MAM adnroid policy CRUD and app targeting for that policy.
#>
function Test-E2EAndroidMAMPolicy
{
	# Setup
	$policyName ="policy1";
	try
	{
		#Setup
		$policies = Get-AzureRmIntuneAndroidMAMPolicy

		if($policies.Count -gt 0)
		{
			foreach($p in $policies)
			{
				Remove-AzureRmIntuneAndroidMAMPolicy -Name $p.Name -Force
			}
		}

		[Microsoft.Azure.Commands.Intune.IntuneBaseCmdlet]::AndroidPolicyIdsQueue.Enqueue("fa1a4d3b-2cca-406b-8956-6b6b32377641")
		New-AzureRmIntuneAndroidMAMPolicy -FriendlyName $policyName

		$policies = Get-AzureRmIntuneAndroidMAMPolicy
		$policy = $policies[0]

		Assert-True { $policy.FriendlyName -eq $policyName }

		# Get apps
		$result = Get-AzureRmIntuneAndroidMAMApp
	
		# Assert
		Assert-True { $result.Count -ge 1}

		Add-AzureRmIntuneAndroidMAMPolicyApp -Name $policy.Name -AppName $result[0].Name
		
		$targettedApps = Get-AzureRmIntuneAndroidMAMPolicyApp -Name $policy.Name

		Assert-True { $targettedApps.Count -eq 1 }

		Remove-AzureRmIntuneAndroidMAMPolicyApp -Name $policy.Name -AppName $targettedApps[0].Name -Force

		$targettedAppsAfterDelete = Get-AzureRmIntuneAndroidMAMPolicyApp -Name $policy.Name
	
		Assert-True { $targettedAppsAfterDelete.Count -eq 0 }

	}
	finally
	{
		# Cleanup

		if($policy)
		{
		     Remove-AzureRmIntuneAndroidMAMPolicy -Name $policy.Name -Force
		}
	}
}