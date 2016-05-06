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
Create, update, and delete workspaces
#>
function Test-WorkspaceCreateUpdateDelete
{
    $wsname = Get-ResourceName
    $rgname = Get-ResourceGroupName
    $wslocation = Get-ProviderLocation
    
    New-AzureRmResourceGroup -Name $rgname -Location $wslocation -Force

    # Create and get a workspace
    $workspace = New-AzureRmOperationalInsightsWorkspace -ResourceGroupName $rgname -Name $wsname -Location $wslocation -Sku free -Tags @{"tag1" = "val1"} -Force
    Assert-AreEqual $rgname $workspace.ResourceGroupName
    Assert-AreEqual $wsname $workspace.Name
    Assert-AreEqual $wslocation $workspace.Location
    Assert-AreEqual "free" $workspace.Sku
    Assert-NotNull $workspace.ResourceId
    Assert-AreEqual 1 $workspace.Tags.Count
    Assert-NotNull $workspace.CustomerId
    Assert-NotNull $workspace.PortalUrl

    $workspace = Get-AzureRmOperationalInsightsWorkspace -ResourceGroupName $rgname -Name $wsname
    Assert-AreEqual $rgname $workspace.ResourceGroupName
    Assert-AreEqual $wsname $workspace.Name
    Assert-AreEqual $wslocation $workspace.Location
    Assert-AreEqual "free" $workspace.Sku
    Assert-NotNull $workspace.ResourceId
    Assert-AreEqual 1 $workspace.Tags.Count
    Assert-NotNull $workspace.CustomerId
    Assert-NotNull $workspace.PortalUrl

    # Create a second workspace for list testing
    $wstwoname = Get-ResourceName
    $workspacetwo = New-AzureRmOperationalInsightsWorkspace -ResourceGroupName $rgname -Name $wstwoname -Location $wslocation -Force
    
    # List the workspaces in the subscription
    $workspaces = Get-AzureRmOperationalInsightsWorkspace
    Assert-AreEqual 2 $workspaces.Count
    Assert-AreEqual 1 ($workspaces | Where {$_.Name -eq $wsname}).Count
    Assert-AreEqual 1 ($workspaces | Where {$_.Name -eq $wstwoname}).Count
    
    # List the workspaces in the resource group
    $workspaces = Get-AzureRmOperationalInsightsWorkspace -ResourceGroupName $rgname
    Assert-AreEqual 2 $workspaces.Count
    Assert-AreEqual 1 ($workspaces | Where {$_.Name -eq $wsname}).Count
    Assert-AreEqual 1 ($workspaces | Where {$_.Name -eq $wstwoname}).Count

    # Delete the second workspace
    Remove-AzureRmOperationalInsightsWorkspace -ResourceGroupName $rgName -Name $wstwoname -Force
    Assert-ThrowsContains { Get-AzureRmOperationalInsightsWorkspace -ResourceGroupName $rgname -Name $wstwoname } "ResourceNotFound"
    $workspaces = Get-AzureRmOperationalInsightsWorkspace
    Assert-AreEqual 1 $workspaces.Count
    Assert-AreEqual 1 ($workspaces | Where {$_.Name -eq $wsname}).Count
    Assert-AreEqual 0 ($workspaces | Where {$_.Name -eq $wstwoname}).Count

    # Update the tags on the workspace
    $workspace = Set-AzureRmOperationalInsightsWorkspace -ResourceGroupName $rgname -Name $wsname -Tags @{"foo" = "bar"; "foo2" = "bar2"}
    Assert-AreEqual 2 $workspace.Tags.Count

    $workspace = $workspace | New-AzureRmOperationalInsightsWorkspace -Tags @{"foo" = "bar"} -Force
    Assert-AreEqual 1 $workspace.Tags.Count

    # Clear the tags and update the sku via piping
    $workspace | Set-AzureRmOperationalInsightsWorkspace -Tags @{} -Sku standard
    $workspace = Get-AzureRmOperationalInsightsWorkspace -ResourceGroupName $rgname -Name $wsname
    Assert-AreEqual 0 $workspace.Tags.Count
    Assert-AreEqual standard $workspace.Sku

    # Delete the original workspace via piping
    $workspace | Remove-AzureRmOperationalInsightsWorkspace -Force
    $workspaces = Get-AzureRmOperationalInsightsWorkspace -ResourceGroupName $rgname
    Assert-AreEqual 0 $workspaces.Count
    Assert-ThrowsContains { Get-AzureRmOperationalInsightsWorkspace -ResourceGroupName $rgname -Name wsname } "ResourceNotFound"
}

<#
.SYNOPSIS
Perform workspace actions and verify the results
#>
function Test-WorkspaceActions
{
    $wsname = Get-ResourceName
    $rgname = Get-ResourceGroupName
    $wslocation = Get-ProviderLocation
    
    New-AzureRmResourceGroup -Name $rgname -Location $wslocation -Force

    # Query link targets for an identity
    $accounts = Get-AzureRmOperationalInsightsLinkTargets
    Assert-AreEqual 0 $accounts.Count

    # Attempt to link a workspace to an invalid account
    Assert-ThrowsContains { New-AzureRmOperationalInsightsWorkspace -ResourceGroupName $rgname -Name $wsname -Location $wslocation -CustomerId ([guid]::NewGuid()) } "not a valid link target"

    # Create a real workspace for use in the rest of the test
    $workspace = New-AzureRmOperationalInsightsWorkspace -ResourceGroupName $rgname -Name $wsname -Location $wslocation -Sku "STANDARD" -Tags @{"tag1" = "val1"} -Force

    # Get the shared keys (both param sets)
    $keys = Get-AzureRmOperationalInsightsWorkspaceSharedKeys -ResourceGroupName $rgname -Name $wsname
    Assert-NotNull $keys.PrimarySharedKey
    Assert-NotNull $keys.SecondarySharedKey

    $keys = $workspace | Get-AzureRmOperationalInsightsWorkspaceSharedKeys
    Assert-NotNull $keys.PrimarySharedKey
    Assert-NotNull $keys.SecondarySharedKey

    # List the management groups (both param sets)
    $mgs = Get-AzureRmOperationalInsightsWorkspaceManagementGroups -ResourceGroupName $rgname -Name $wsname
    Assert-AreEqual 0 $mgs.Count

    $mgs = $workspace | Get-AzureRmOperationalInsightsWorkspaceManagementGroups
    Assert-AreEqual 0 $mgs.Count

    # List the usages for a workspace (both param sets)
    $usages = Get-AzureRmOperationalInsightsWorkspaceUsage -ResourceGroupName $rgname -Name $wsname
    Assert-AreEqual 1 $usages.Count
    Assert-AreEqual "DataAnalyzed" $usages[0].Id
    Assert-NotNull $usages[0].Name
    Assert-NotNull $usages[0].NextResetTime
    Assert-AreEqual "Bytes" $usages[0].Unit
    Assert-AreEqual ([Timespan]::FromDays(1)) $usages[0].QuotaPeriod

    $usages = $workspace | Get-AzureRmOperationalInsightsWorkspaceUsage
    Assert-AreEqual 1 $usages.Count
    Assert-AreEqual "DataAnalyzed" $usages[0].Id
    Assert-NotNull $usages[0].Name
    Assert-NotNull $usages[0].NextResetTime
    Assert-AreEqual "Bytes" $usages[0].Unit
    Assert-AreEqual ([Timespan]::FromDays(1)) $usages[0].QuotaPeriod
}

<#
.SYNOPSIS
Enable, disable, and list intelligence packs and verify the results
#>
function Test-WorkspaceEnableDisableListIntelligencePacks
{

    $wsname = Get-ResourceName
    $rgname = Get-ResourceGroupName
    $wslocation = Get-ProviderLocation

	New-AzureRmResourceGroup -Name $rgname -Location $wslocation -Force

	# Create and get a workspace
    $workspace = New-AzureRmOperationalInsightsWorkspace -ResourceGroupName $rgname -Name $wsname -Location $wslocation -Sku free -Tags @{"tag1" = "val1"} -Force
    Assert-AreEqual $rgname $workspace.ResourceGroupName
    Assert-AreEqual $wsname $workspace.Name
    Assert-AreEqual $wslocation $workspace.Location
    Assert-AreEqual "free" $workspace.Sku
    Assert-NotNull $workspace.ResourceId
    Assert-AreEqual 1 $workspace.Tags.Count
    Assert-NotNull $workspace.CustomerId
    Assert-NotNull $workspace.PortalUrl

    # Enable intelligence packs
	Set-AzureRmOperationalInsightsIntelligencePack -ResourceGroupName $rgname -WorkspaceName $wsname -IntelligencePackName "ChangeTracking" -Enabled $true
	Set-AzureRmOperationalInsightsIntelligencePack -ResourceGroupName $rgname -WorkspaceName $wsname -IntelligencePackName "SiteRecovery" -Enabled $true

	# List to verify that the IP's have been enabled
	$ipList = Get-AzureRmOperationalInsightsIntelligencePacks -ResourceGroupName $rgname -WorkspaceName $wsname
	Foreach ($ip in $ipList)
	{
		if (($ip.Name -eq "ChangeTracking") -or ($ip.Name -eq "SiteRecovery") -or ($ip.Name -eq "LogManagement"))
		{
			Assert-AreEqual $ip.Enabled $true
		}
		else
		{
			Assert-AreEqual $ip.Enabled $false
		}
	}

	# Disable intelligence packs
	Set-AzureRmOperationalInsightsIntelligencePack -ResourceGroupName $rgname -WorkspaceName $wsname -IntelligencePackName "ChangeTracking" -Enabled $false
	Set-AzureRmOperationalInsightsIntelligencePack -ResourceGroupName $rgname -WorkspaceName $wsname -IntelligencePackName "SiteRecovery" -Enabled $false

	# List to verify that the IP's have been disabled
	$ipList = Get-AzureRmOperationalInsightsIntelligencePacks -ResourceGroupName $rgname -WorkspaceName $wsname
	Foreach ($ip in $ipList)
	{
		if ($ip.Name -eq "LogManagement")
		{
			Assert-AreEqual $ip.Enabled $true
		}
		else
		{
			Assert-AreEqual $ip.Enabled $false
		}
	}

	# Delete the original workspace via piping
    $workspace | Remove-AzureRmOperationalInsightsWorkspace -Force
    $workspaces = Get-AzureRmOperationalInsightsWorkspace -ResourceGroupName $rgname
    Assert-AreEqual 0 $workspaces.Count
    Assert-ThrowsContains { Get-AzureRmOperationalInsightsWorkspace -ResourceGroupName $rgname -Name wsname } "ResourceNotFound"
}