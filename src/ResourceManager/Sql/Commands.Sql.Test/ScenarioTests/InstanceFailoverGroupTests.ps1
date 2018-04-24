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

function Handle-InstanceFailoverGroupTest($scriptBlock, $rg = "testclrg", $primaryLocation = "southeastasia", $secondaryLocation = "southeastasia", $server1 = $null, $server2 = $null, $cleanup = $false)
{
	try
	{
		$rg = if ($rg -eq $null) { "testclrg" } else { $rg }
		$serverName1 = if ($server1 -eq $null) { "tdstage-haimb-dont-delete-3" } else { "" }
		$serverName2 = if ($server1 -eq $null) { "threat-detection-test-1" } else { "" }
		$server1 = if ($server1 -eq $null) { Get-ManagedInstanceForTest $rg $serverName1 } else { $server1 }
		$server2 = if ($server2 -eq $null) { Get-ManagedInstanceForTest $rg $serverName2 } else { $server2 }

		Invoke-Command -ScriptBlock $scriptBlock -ArgumentList $primaryLocation, $secondaryLocation, $server1, $server2
	}
	finally
	{	
	}
}

function Handle-InstanceFailoverGroupTestWithInstanceFailoverGroup($scriptBlock, $failoverPolicy = "Automatic")
{
	Handle-InstanceFailoverGroupTest {
		Param($location, $partnerRegion, $managedInstance, $partnerManagedInstance)

		$fgName = Get-FailoverGroupName
		$fg = New-AzureRmSqlDatabaseInstanceFailoverGroup -Name $fgName -Location $location -ResourceGroupName $managedInstance.ResourceGroupName -PrimaryManagedInstanceName $managedInstance.Name -PartnerRegion $partnerRegion -PartnerResourceGroupName $partnerManagedInstance.ResourceGroupName -PartnerManagedInstanceName $partnerManagedInstance.Name 
		Invoke-Command -ScriptBlock $scriptBlock -ArgumentList $fg
		
	}.GetNewClosure()
}

function Validate-InstanceFailoverGroup($managedInstance, $partnerManagedInstance, $name, $role, $partnerRole, $failoverPolicy, $gracePeriod, $readOnlyFailoverPolicy, $fg, $message="no context provided")
{	
	Assert-NotNull $fg.Id "`$fg.Id ($message)"
	Assert-NotNull $fg.PartnerRegion "`$fg.PartnerRegion ($message)"
	Assert-NotNull $fg.ManagedInstancePairs "`$fg.ManagedInstancePairs ($message)"
	Assert-AreEqual $name $fg.Name "`$fg.Name ($message)"
	Assert-AreEqual $managedInstance.ResourceGroupName $fg.ResourceGroupName "`$fg.ResourceGroupName ($message)"
	Assert-AreEqual $partnerManagedInstance.ResourceGroupName $fg.PartnerResourceGroupName "`$fg.PartnerResourceGroupName ($message)"
	Assert-AreEqual $role $fg.ReplicationRole "`$fg.ReplicationRole ($message)"
	Assert-AreEqual $partnerRole $fg.PartnerRegion.ReplicationRole "`$fg.PartnerRegion.ReplicationRole ($message)"
	Assert-AreEqual $failoverPolicy $fg.ReadWriteFailoverPolicy "`$fg.ReadWriteFailoverPolicy ($message)"
	Assert-AreEqual $gracePeriod $fg.FailoverWithDataLossGracePeriodHours "`$fg.FailoverWithGracePeriodHours ($message)"
	Assert-AreEqual $readOnlyFailoverPolicy $fg.ReadOnlyFailoverPolicy "`$fg.ReadOnlyFailoverPolicy ($message)"
	Assert-AreEqual $true @('CATCH_UP', 'SUSPENDED', 'SEEDING').Contains($fg.ReplicationState) "`$fg.ReplicationState ($message)"
}

function Assert-InstanceFailoverGroupsEqual($expected, $actual, $role = $null, $failoverPolicy = $null, $gracePeriod = $null, $readOnlyFailoverPolicy = $null, $message = "no context provided")
{
	$managedInstance = @{ 'Name' = $expected.PrimaryManagedInstanceName; 'Location' = $expected.LocationName; 'ResourceGroupName' = $expected.ResourceGroupName }
	$partnerManagedInstance = @{ 'Name' = $expected.PartnerManagedInstanceName; 'Location' = $expected.PartnerRegion.Location; 'ResourceGroupName' = $expected.PartnerResourceGroupName }
	$failoverPolicy = if ($failoverPolicy -eq $null) { $expected.ReadWriteFailoverPolicy } else { $failoverPolicy }
	$gracePeriod = if ($gracePeriod -eq $null -and $failoverPolicy -ne "Manual") { $expected.FailoverWithDataLossGracePeriodHours } else { $gracePeriod }
	$readOnlyFailoverPolicy = if ($readOnlyFailoverPolicy -eq $null) { $expected.ReadOnlyFailoverPolicy } else { $readOnlyFailoverPolicy }
	$role = if ($role -eq $null) { $expected.ReplicationRole } else { $role }

	$partnerRole = if ($role -eq "Primary") { "Secondary" } else { "Primary" }

	Validate-InstanceFailoverGroup `
		$managedInstance `
		$partnerManagedInstance `
		$expected.Name `
		$role `
		$partnerRole `
		$failoverPolicy `
		$gracePeriod `
		$readOnlyFailoverPolicy `
		$actual `
		$message
}

function Validate-InstanceFailoverGroupWithGet($fg, $message = "no context provided")
{
	$actual = $fg | Get-AzureRmSqlDatabaseInstanceFailoverGroup
	Assert-InstanceFailoverGroupsEqual $fg $actual -message $message
}

<#
	.SYNOPSIS
	Tests create and update a failover group
#>

function Test-CreateInstanceFailoverGroup-Named()
{
	Handle-InstanceFailoverGroupTest {
		Param($location, $partnerRegion, $managedInstance, $partnerManagedInstance)

        $fgName = Get-FailoverGroupName
		$fg = New-AzureRmSqlDatabaseInstanceFailoverGroup -Name $fgName -Location $location -ResourceGroupName $managedInstance.ResourceGroupName -PrimaryManagedInstanceName $managedInstance.Name -PartnerRegion $partnerRegion -PartnerResourceGroupName $partnerManagedInstance.ResourceGroupName -PartnerManagedInstanceName $partnerManagedInstance.Name 
		Validate-InstanceFailoverGroup $managedInstance $partnerManagedInstance $fg.Name Primary Secondary Automatic 1 Disabled $fg
		Validate-InstanceFailoverGroupWithGet $fg

		$fg | Remove-AzureRmSqlDatabaseInstanceFailoverGroup -Force
	}
}

function Test-CreateInstanceFailoverGroup-Positional()
{
	Handle-InstanceFailoverGroupTest {
		Param($location, $partnerRegion, $managedInstance, $partnerManagedInstance)

		$fgName = Get-FailoverGroupName
		$fg = New-AzureRmSqlDatabaseInstanceFailoverGroup -ResourceGroupName $managedInstance.ResourceGroupName -PrimaryManagedInstanceName $managedInstance.Name -Name $fgName -Location $location -PartnerRegion $partnerRegion -PartnerManagedInstanceName $partnerManagedInstance.Name 
		Validate-InstanceFailoverGroup $managedInstance $partnerManagedInstance $fg.Name Primary Secondary Automatic 1 Disabled $fg
		Validate-InstanceFailoverGroupWithGet $fg

		$fg | Remove-AzureRmSqlDatabaseInstanceFailoverGroup -Force
	}
}

function Test-CreateInstanceFailoverGroup-AutomaticPolicy()
{
	Handle-InstanceFailoverGroupTest {
		Param($location, $partnerRegion, $managedInstance, $partnerManagedInstance)
		
        $fgName = Get-FailoverGroupName
		$fg = $managedInstance | New-AzureRmSqlDatabaseInstanceFailoverGroup -PrimaryManagedInstanceName $managedInstance.Name -Name $fgName -PartnerRegion $partnerRegion -PartnerManagedInstanceName $partnerManagedInstance.Name -FailoverPolicy Automatic
		Validate-InstanceFailoverGroup $managedInstance $partnerManagedInstance $fg.Name Primary Secondary Automatic 1 Disabled $fg
        Validate-InstanceFailoverGroupWithGet $fg

		$fg | Remove-AzureRmSqlDatabaseInstanceFailoverGroup -Force
	}
}

function Test-CreateInstanceFailoverGroup-AutomaticPolicyGracePeriodReadOnlyFailover()
{
	Handle-InstanceFailoverGroupTest {
		Param($location, $partnerRegion, $managedInstance, $partnerManagedInstance)

        $fgName = Get-FailoverGroupName
		$fg = $managedInstance | New-AzureRmSqlDatabaseInstanceFailoverGroup -PrimaryManagedInstanceName $managedInstance.Name -Name $fgName -PartnerRegion $partnerRegion -PartnerManagedInstanceName $partnerManagedInstance.Name -FailoverPolicy Automatic -GracePeriodWithDataLossHours 123 -AllowReadOnlyFailoverToPrimary Enabled
		Validate-InstanceFailoverGroup $managedInstance $partnerManagedInstance $fg.Name Primary Secondary Automatic 123 Enabled $fg
		Validate-InstanceFailoverGroupWithGet $fg

		$fg | Remove-AzureRmSqlDatabaseInstanceFailoverGroup -Force
	}
}

function Test-CreateInstanceFailoverGroup-ManualPolicy()
{
	Handle-InstanceFailoverGroupTest {
		Param($location, $partnerRegion, $managedInstance, $partnerManagedInstance)

        $fgName = Get-FailoverGroupName
		$fg = $managedInstance | New-AzureRmSqlDatabaseInstanceFailoverGroup -PrimaryManagedInstanceName $managedInstance.Name -Name $fgName -PartnerRegion $partnerRegion -PartnerManagedInstanceName $partnerManagedInstance.Name -FailoverPolicy Manual 
        Validate-InstanceFailoverGroup $managedInstance $partnerManagedInstance $fg.Name Primary Secondary Manual $null Disabled $fg
		Validate-InstanceFailoverGroupWithGet $fg

		$fg | Remove-AzureRmSqlDatabaseInstanceFailoverGroup -Force
	}
}

function Test-SetInstanceFailoverGroup-Named()
{
	Handle-InstanceFailoverGroupTestWithInstanceFailoverGroup {
		Param($fg)

		$newFg = $fg | Set-AzureRmSqlDatabaseInstanceFailoverGroup 
		Assert-InstanceFailoverGroupsEqual $fg $newFg
		Validate-InstanceFailoverGroupWithGet $newFg
		
		$newFg | Remove-AzureRmSqlDatabaseInstanceFailoverGroup -Force
	}
}

function Test-SetInstanceFailoverGroup-Positional()
{
	Handle-InstanceFailoverGroupTestWithInstanceFailoverGroup {
		Param($fg)

		$newFg = $fg | Set-AzureRmSqlDatabaseInstanceFailoverGroup
		Assert-InstanceFailoverGroupsEqual $fg $newFg
		Validate-InstanceFailoverGroupWithGet $newFg

		$newFg | Remove-AzureRmSqlDatabaseInstanceFailoverGroup -Force
	}
}

function Test-SetInstanceFailoverGroup-AutomaticWithGracePeriodReadOnlyFailover()
{
	Handle-InstanceFailoverGroupTestWithInstanceFailoverGroup {
		Param($fg)

		$newFg = $fg | Set-AzureRmSqlDatabaseInstanceFailoverGroup -FailoverPolicy Automatic -GracePeriodWithDataLossHours 123 -AllowReadOnlyFailoverToPrimary Enabled
		Assert-InstanceFailoverGroupsEqual $fg $newFg -failoverPolicy Automatic -gracePeriod 123 -readOnlyFailoverPolicy Enabled
		Validate-InstanceFailoverGroupWithGet $newFg

		$newFg | Remove-AzureRmSqlDatabaseInstanceFailoverGroup -Force
	} -failoverPolicy Manual
}

function Test-SetInstanceFailoverGroup-AutomaticToManual()
{
	Handle-InstanceFailoverGroupTestWithInstanceFailoverGroup {
		Param($fg)

		$newFg = $fg | Set-AzureRmSqlDatabaseInstanceFailoverGroup -FailoverPolicy Manual
		Assert-InstanceFailoverGroupsEqual $fg $newFg -failoverPolicy Manual -gracePeriod $null
		Validate-InstanceFailoverGroupWithGet $newFg

		$newFg | Remove-AzureRmSqlDatabaseInstanceFailoverGroup -Force
	}
}

function Test-SetInstanceFailoverGroup-ManualToAutomaticNoGracePeriod()
{
	Handle-InstanceFailoverGroupTestWithInstanceFailoverGroup {
		Param($fg)

		$newFg = $fg | Set-AzureRmSqlDatabaseInstanceFailoverGroup -FailoverPolicy Manual
		Assert-InstanceFailoverGroupsEqual $fg $newFg -failoverPolicy Manual -gracePeriod $null

		$newFg = $fg | Set-AzureRmSqlDatabaseInstanceFailoverGroup -FailoverPolicy Automatic
		Assert-InstanceFailoverGroupsEqual $fg $newFg -failoverPolicy Automatic -gracePeriod 1
		Validate-InstanceFailoverGroupWithGet $newFg

		$newFg | Remove-AzureRmSqlDatabaseInstanceFailoverGroup -Force
	} -failoverPolicy Manual
}

function Test-SwitchInstanceFailoverGroup()
{
	Handle-InstanceFailoverGroupTestWithInstanceFailoverGroup {
		Param($fg)

		$fg | Switch-AzureRmSqlDatabaseInstanceFailoverGroup 

		$newPrimaryFg = $fg | Get-AzureRmSqlDatabaseInstanceFailoverGroup

		Validate-InstanceFailoverGroupWithGet $newPrimaryFg		

		$newPrimaryFg | Remove-AzureRmSqlDatabaseInstanceFailoverGroup -Force
	}
}

function Test-SwitchInstanceFailoverGroupAllowDataLoss()
{
	Handle-InstanceFailoverGroupTestWithInstanceFailoverGroup {
		Param($fg)

		$fg | Switch-AzureRmSqlDatabaseInstanceFailoverGroup -AllowDataLoss
		$newPrimaryFg = $fg | Get-AzureRmSqlDatabaseInstanceFailoverGroup

		Validate-InstanceFailoverGroupWithGet $newPrimaryFg

		$newPrimaryFg | Remove-AzureRmSqlDatabaseInstanceFailoverGroup -Force
	}
}
