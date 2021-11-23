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
Create, update, and delete workspaces
#>
function Test-WorkspaceCreateUpdateDelete
{
    $wsname = Get-ResourceName
    $rgname = Get-ResourceGroupName
    $wslocation = Get-ProviderLocation
    
    try 
    {
        New-AzResourceGroup -Name $rgname -Location $wslocation -Force

        # Create and get a workspace
        $workspace = New-AzOperationalInsightsWorkspace -ResourceGroupName $rgname -Name $wsname -Location $wslocation -Sku "pergb2018" -Tag @{"tag1" = "val1"} -Force
        Assert-AreEqual $rgname $workspace.ResourceGroupName
        Assert-AreEqual $wsname $workspace.Name
        Assert-AreEqual $wslocation $workspace.Location
        Assert-AreEqual "pergb2018" $workspace.Sku
        # if no value for RetentionInDays is specified, use the default value for the sku. For standard, the default is 30.
        Assert-AreEqual 30 $workspace.RetentionInDays
        Assert-NotNull $workspace.ResourceId
        Assert-AreEqual 1 $workspace.Tags.Count
    
        #CustomerId was removed from SDK
        #Assert-NotNull $workspace.CustomerId

        #PortalUrl was removed from SDK
        #Assert-NotNull $workspace.PortalUrl

        $workspace = Get-AzOperationalInsightsWorkspace -ResourceGroupName $rgname -Name $wsname
        Assert-AreEqual $rgname $workspace.ResourceGroupName
        Assert-AreEqual $wsname $workspace.Name
        Assert-AreEqual $wslocation $workspace.Location
        Assert-AreEqual "pergb2018" $workspace.Sku
        Assert-AreEqual 30 $workspace.RetentionInDays
        Assert-NotNull $workspace.ResourceId
        Assert-AreEqual 1 $workspace.Tags.Count
    
        #CustomerId was removed from SDK
        #Assert-NotNull $workspace.CustomerId

        #PortalUrl was removed from SDK
        #Assert-NotNull $workspace.PortalUrl

        # Create a second workspace for list testing
        $wstwoname = Get-ResourceName
        $workspacetwo = New-AzOperationalInsightsWorkspace -ResourceGroupName $rgname -Name $wstwoname -Location $wslocation -Sku "pergb2018" -RetentionInDays 60 -Force

        $workspacetwo = Get-AzOperationalInsightsWorkspace -ResourceGroupName $rgname -Name $wstwoname
        Assert-AreEqual 60 $workspacetwo.RetentionInDays

        # List the workspaces in the subscription
        $workspaces = Get-AzOperationalInsightsWorkspace
        Assert-AreEqual 1 ($workspaces | Where {$_.Name -eq $wsname}).Count
        Assert-AreEqual 1 ($workspaces | Where {$_.Name -eq $wstwoname}).Count

        # List the workspaces in the resource group
        $workspaces = Get-AzOperationalInsightsWorkspace -ResourceGroupName $rgname
        Assert-AreEqual 1 ($workspaces | Where {$_.Name -eq $wsname}).Count
        Assert-AreEqual 1 ($workspaces | Where {$_.Name -eq $wstwoname}).Count

        # Delete the second workspace
        Remove-AzOperationalInsightsWorkspace -ResourceGroupName $rgName -Name $wstwoname -Force
        Assert-ThrowsContains { Get-AzOperationalInsightsWorkspace -ResourceGroupName $rgname -Name $wstwoname } "NotFound"
        $workspaces = Get-AzOperationalInsightsWorkspace
        Assert-AreEqual 1 ($workspaces | Where {$_.Name -eq $wsname}).Count
        Assert-AreEqual 0 ($workspaces | Where {$_.Name -eq $wstwoname}).Count

        # Update the tags on the workspace
        $workspace = Set-AzOperationalInsightsWorkspace -ResourceGroupName $rgname -Name $wsname -Tag @{"foo" = "bar"; "foo2" = "bar2"}
        Assert-AreEqual 2 $workspace.Tags.Count

        $workspace = $workspace | New-AzOperationalInsightsWorkspace -Tag @{"foo" = "bar"} -Force
        Assert-AreEqual 1 $workspace.Tags.Count

        # Clear the tags and update the sku, RetentionInDays via piping
        $workspace | Set-AzOperationalInsightsWorkspace -Tag @{} -Sku standalone -RetentionInDays 123
        $workspace = Get-AzOperationalInsightsWorkspace -ResourceGroupName $rgname -Name $wsname
        Assert-AreEqual 0 $workspace.Tags.Count
    
        #cannot be updated
        #Assert-AreEqual standalone $workspace.Sku
        Assert-AreEqual 123 $workspace.RetentionInDays

        # Delete the original workspace via piping
        $workspace | Remove-AzOperationalInsightsWorkspace -Force
        $workspaces = Get-AzOperationalInsightsWorkspace -ResourceGroupName $rgname
        Assert-AreEqual 0 $workspaces.Count
        Assert-ThrowsContains { Get-AzOperationalInsightsWorkspace -ResourceGroupName $rgname -Name $wsname } "NotFound"

        # Get workspace from deleted workspace
        $workspaces = Get-AzOperationalInsightsDeletedWorkspace -ResourceGroupName $rgname
        $deleted = 0
        Foreach ($workspace in $workspaces){
            if($workspace.Name.Equals($wsname)){
                $deleted += 1
		    }
	    }
        Assert-AreEqual 1 $deleted

        # Restore deleted workspace
        $workspace = Restore-AzOperationalInsightsWorkspace -ResourceGroupName $rgname -Name $wsname -Location $wslocation
        Assert-NotNull $workspace
        Assert-AreEqual 123 $workspace.RetentionInDays

        # Force delete workspace
        $workspace | Remove-AzOperationalInsightsWorkspace -Force -ForceDelete
        $workspaces = Get-AzOperationalInsightsDeletedWorkspace -ResourceGroupName $rgname
        $deleted = 0
        Foreach ($workspace in $workspaces){
            if($workspace.Name.Equals($wsname)){
                $deleted += 1
		    }
	    }
        Assert-AreEqual 0 $deleted
    }	
    finally
	{
		# Cleanup
        Clean-ResourceGroup $rgname 
	}    
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

    try
    {
        New-AzResourceGroup -Name $rgname -Location $wslocation -Force

        #LinkTargets was removed from SDK
        # Query link targets for an identity
        #$accounts = Get-AzOperationalInsightsLinkTargets
        #Assert-AreEqual 0 $accounts.Count

        #CustomerId was removed from SDK
        # Attempt to link a workspace to an invalid account
        #Assert-ThrowsContains { New-AzOperationalInsightsWorkspace -ResourceGroupName $rgname -Name $wsname -Location $wslocation -Sku "STANDARD" -CustomerId ([guid]::NewGuid()) } "BadRequest"

        # Create a real workspace for use in the rest of the test
        $workspace = New-AzOperationalInsightsWorkspace -ResourceGroupName $rgname -Name $wsname -Location $wslocation -Sku "pergb2018" -Tag @{"tag1" = "val1"} -Force

        # Get the shared keys (both param sets)
        $keys = Get-AzOperationalInsightsWorkspaceSharedKeys -ResourceGroupName $rgname -Name $wsname
        Assert-NotNull $keys.PrimarySharedKey
        Assert-NotNull $keys.SecondarySharedKey

        $keys = $workspace | Get-AzOperationalInsightsWorkspaceSharedKeys
        Assert-NotNull $keys.PrimarySharedKey
        Assert-NotNull $keys.SecondarySharedKey

        # List the management groups (both param sets)
        $mgs = Get-AzOperationalInsightsWorkspaceManagementGroups -ResourceGroupName $rgname -Name $wsname
        Assert-AreEqual 0 $mgs.Count

        $mgs = $workspace | Get-AzOperationalInsightsWorkspaceManagementGroups
        Assert-AreEqual 0 $mgs.Count

        # List the usages for a workspace (both param sets)
        $usages = Get-AzOperationalInsightsWorkspaceUsage -ResourceGroupName $rgname -Name $wsname
        Assert-AreEqual 1 $usages.Count
        Assert-AreEqual "DataAnalyzed" $usages[0].Id
        Assert-NotNull $usages[0].Name
        Assert-NotNull $usages[0].NextResetTime
        Assert-AreEqual "Bytes" $usages[0].Unit
        Assert-AreEqual ([Timespan]::FromDays(1)) $usages[0].QuotaPeriod

        $usages = $workspace | Get-AzOperationalInsightsWorkspaceUsage
        Assert-AreEqual 1 $usages.Count
        Assert-AreEqual "DataAnalyzed" $usages[0].Id
        Assert-NotNull $usages[0].Name
        Assert-NotNull $usages[0].NextResetTime
        Assert-AreEqual "Bytes" $usages[0].Unit
        Assert-AreEqual ([Timespan]::FromDays(1)) $usages[0].QuotaPeriod
    }
    finally
	{
		# Cleanup
        Clean-ResourceGroup $rgname 
	}
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

    try
    {
        New-AzResourceGroup -Name $rgname -Location $wslocation -Force

	    # Create and get a workspace
        $workspace = New-AzOperationalInsightsWorkspace -ResourceGroupName $rgname -Name $wsname -Location $wslocation -Sku "pergb2018" -Tag @{"tag1" = "val1"} -Force
        Assert-AreEqual $rgname $workspace.ResourceGroupName
        Assert-AreEqual $wsname $workspace.Name
        Assert-AreEqual $wslocation $workspace.Location
        Assert-AreEqual "pergb2018" $workspace.Sku
        Assert-NotNull $workspace.ResourceId
        Assert-AreEqual 1 $workspace.Tags.Count
    
        #CustomerId was removed from SDK
        #Assert-NotNull $workspace.CustomerId
    
        #PortalUrl was removed from SDK
        #Assert-NotNull $workspace.PortalUrl

        # Enable intelligence packs
	    Set-AzOperationalInsightsIntelligencePack -ResourceGroupName $rgname -WorkspaceName $wsname -IntelligencePackName "ChangeTracking" -Enabled $true
	    Set-AzOperationalInsightsIntelligencePack -ResourceGroupName $rgname -WorkspaceName $wsname -IntelligencePackName "SiteRecovery" -Enabled $true

	    # List to verify that the IP's have been enabled
	    $ipList = Get-AzOperationalInsightsIntelligencePacks -ResourceGroupName $rgname -WorkspaceName $wsname
	    Foreach ($ip in $ipList)
	    {
		    if (($ip.Name -eq "ChangeTracking") -or ($ip.Name -eq "SiteRecovery") -or ($ip.Name -eq "LogManagement") -or ($ip.Name -eq "AzureResources"))
		    {
			    Assert-AreEqual $true $ip.Enabled
		    }
		    else
		    {
			    Assert-AreEqual $false $ip.Enabled
		    }
	    }

	    # Disable intelligence packs
	    Set-AzOperationalInsightsIntelligencePack -ResourceGroupName $rgname -WorkspaceName $wsname -IntelligencePackName "ChangeTracking" -Enabled $false
	    Set-AzOperationalInsightsIntelligencePack -ResourceGroupName $rgname -WorkspaceName $wsname -IntelligencePackName "SiteRecovery" -Enabled $false

	    # List to verify that the IP's have been disabled
	    $ipList = Get-AzOperationalInsightsIntelligencePacks -ResourceGroupName $rgname -WorkspaceName $wsname
	    Foreach ($ip in $ipList)
	    {
		    if (($ip.Name -eq "LogManagement") -or ($ip.Name -eq "AzureResources"))
		    {
			    Assert-AreEqual $true $ip.Enabled 
		    }
		    else
		    {
			    Assert-AreEqual $false $ip.Enabled 
		    }
	    }

	    # Delete the original workspace via piping
        $workspace | Remove-AzOperationalInsightsWorkspace -Force
        $workspaces = Get-AzOperationalInsightsWorkspace -ResourceGroupName $rgname
        Assert-AreEqual 0 $workspaces.Count
        Assert-ThrowsContains { Get-AzOperationalInsightsWorkspace -ResourceGroupName $rgname -Name wsname } "NotFound"
    }
    finally
	{
		# Cleanup
        Clean-ResourceGroup $rgname 
	}
}