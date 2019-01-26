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

function Handle-InstanceFailoverGroupTest($scriptBlock, $rg = "testclrg", $primaryLocation = "southeastasia", $secondaryLocation = "southeastasia", $mi1 = $null, $mi2 = $null, $cleanup = $false)
{
	try
	{
		$rg = if ($rg -eq $null) { "testclrg" } else { $rg }
		$miName1 = if ($mi1 -eq $null) { "tdstage-haimb-dont-delete-3" } else { "" }
		$miName2 = if ($mi1 -eq $null) { "threat-detection-test-1" } else { "" }

		Invoke-Command -ScriptBlock $scriptBlock -ArgumentList $primaryLocation, $secondaryLocation, $rg, $miName1, $miName2
	}
	finally
	{	
	}
}

function Handle-InstanceFailoverGroupTestWithInstanceFailoverGroup($scriptBlock, $failoverPolicy = "Automatic")
{
	Handle-InstanceFailoverGroupTest {
		Param($location, $partnerRegion, $rg, $managedInstanceName, $partnerManagedInstanceName)

        $fgName = Get-FailoverGroupName
		$fg = New-AzSqlDatabaseInstanceFailoverGroup -Name $fgName -Location $location -ResourceGroupName $rg -PrimaryManagedInstanceName $managedInstanceName -PartnerRegion $partnerRegion -PartnerResourceGroupName $rg -PartnerManagedInstanceName $partnerManagedInstanceName
		Invoke-Command -ScriptBlock $scriptBlock -ArgumentList $fg
		
	}.GetNewClosure()
}

function Validate-InstanceFailoverGroup($rg, $name, $miName1, $miName2, $role, $partnerRole, $failoverPolicy, $gracePeriod, $readOnlyFailoverPolicy, $fg, $message="no context provided")
{	
	Assert-NotNull $fg.Id "`$fg.Id ($message)"
	Assert-NotNull $fg.PartnerRegion "`$fg.PartnerRegion ($message)"
	Assert-AreEqual $miName1 $fg.PrimaryManagedInstanceName "`$fg.PrimaryManagedInstanceName ($message)"
	Assert-AreEqual $miName2 $fg.PartnerManagedInstanceName "`$fg.PartnerManagedInstanceName ($message)"
	Assert-AreEqual $name $fg.Name "`$fg.Name ($message)"
	Assert-AreEqual $rg $fg.ResourceGroupName "`$fg.ResourceGroupName ($message)"
	Assert-AreEqual $rg $fg.PartnerResourceGroupName "`$fg.PartnerResourceGroupName ($message)"
	Assert-AreEqual $role $fg.ReplicationRole "`$fg.ReplicationRole ($message)"
	Assert-AreEqual $failoverPolicy $fg.ReadWriteFailoverPolicy "`$fg.ReadWriteFailoverPolicy ($message)"
	Assert-AreEqual $gracePeriod $fg.FailoverWithDataLossGracePeriodHours "`$fg.FailoverWithGracePeriodHours ($message)"
	Assert-AreEqual $readOnlyFailoverPolicy $fg.ReadOnlyFailoverPolicy "`$fg.ReadOnlyFailoverPolicy ($message)"
	Assert-AreEqual $true @('CATCH_UP', 'SUSPENDED', 'SEEDING').Contains($fg.ReplicationState) "`$fg.ReplicationState ($message)"
}

function Assert-InstanceFailoverGroupsEqual($expected, $actual, $role = $null, $failoverPolicy = $null, $gracePeriod = $null, $readOnlyFailoverPolicy = $null, $message = "no context provided")
{
	$failoverPolicy = if ($failoverPolicy -eq $null) { $expected.ReadWriteFailoverPolicy } else { $failoverPolicy }
	$gracePeriod = if ($gracePeriod -eq $null -and $failoverPolicy -ne "Manual") { $expected.FailoverWithDataLossGracePeriodHours } else { $gracePeriod }
	$readOnlyFailoverPolicy = if ($readOnlyFailoverPolicy -eq $null) { $expected.ReadOnlyFailoverPolicy } else { $readOnlyFailoverPolicy }
	$role = if ($role -eq $null) { $expected.ReplicationRole } else { $role }

	$partnerRole = if ($role -eq "Primary") { "Secondary" } else { "Primary" }

	Validate-InstanceFailoverGroup `
		$expected.ResourceGroupName `
		$expected.Name `
		$expected.PrimaryManagedInstanceName `
		$expected.PartnerManagedInstanceName `
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
	$actual = Get-AzSqlDatabaseInstanceFailoverGroup -ResourceGroupName $fg.ResourceGroupName -Location $fg.Location -Name $fg.Name
	Assert-InstanceFailoverGroupsEqual $fg $actual -message $message
}

<#
	.SYNOPSIS
	Tests create and update a failover group
#>

function Test-CreateInstanceFailoverGroup-Named()
{
	Handle-InstanceFailoverGroupTest {
		Param($location, $partnerRegion, $rg, $managedInstanceName, $partnerManagedInstanceName)

        $fgName = Get-FailoverGroupName
		$fg = New-AzSqlDatabaseInstanceFailoverGroup -Name $fgName -Location $location -ResourceGroupName $rg -PrimaryManagedInstanceName $managedInstanceName -PartnerRegion $partnerRegion -PartnerResourceGroupName $rg -PartnerManagedInstanceName $partnerManagedInstanceName
		Validate-InstanceFailoverGroup $rg $fgName $managedInstanceName $partnerManagedInstanceName Primary Secondary Automatic 1 Disabled $fg
		Validate-InstanceFailoverGroupWithGet $fg

		Remove-AzSqlDatabaseInstanceFailoverGroup -Name $fgName -Location $location -ResourceGroupName $rg -Force
	}
}

function Test-CreateInstanceFailoverGroup-Positional()
{
	Handle-InstanceFailoverGroupTest {
		Param($location, $partnerRegion, $rg, $managedInstanceName, $partnerManagedInstanceName)

		$fgName = Get-FailoverGroupName
		$fg = New-AzSqlDatabaseInstanceFailoverGroup -ResourceGroupName $rg -PrimaryManagedInstanceName $managedInstanceName -Name $fgName -Location $location -PartnerRegion $partnerRegion -PartnerManagedInstanceName $partnerManagedInstanceName 
		Validate-InstanceFailoverGroup $rg $fgName $managedInstanceName $partnerManagedInstanceName Primary Secondary Automatic 1 Disabled $fg
		Validate-InstanceFailoverGroupWithGet $fg

		$fg | Remove-AzSqlDatabaseInstanceFailoverGroup -Force
	}
}

function Test-CreateInstanceFailoverGroup-AutomaticPolicy()
{
	Handle-InstanceFailoverGroupTest {
		Param($location, $partnerRegion, $rg, $managedInstanceName, $partnerManagedInstanceName)
		
        $fgName = Get-FailoverGroupName
		$fg = New-AzSqlDatabaseInstanceFailoverGroup -ResourceGroupName $rg -Location $location -PrimaryManagedInstanceName $managedInstanceName -Name $fgName -PartnerRegion $partnerRegion -PartnerManagedInstanceName $partnerManagedInstanceName -FailoverPolicy Automatic
		Validate-InstanceFailoverGroup $rg $fgName $managedInstanceName $partnerManagedInstanceName Primary Secondary Automatic 1 Disabled $fg
        Validate-InstanceFailoverGroupWithGet $fg

		$fg | Remove-AzSqlDatabaseInstanceFailoverGroup -Force
	}
}

function Test-CreateInstanceFailoverGroup-AutomaticPolicyGracePeriodReadOnlyFailover()
{
	Handle-InstanceFailoverGroupTest {
		Param($location, $partnerRegion, $rg, $managedInstanceName, $partnerManagedInstanceName)

        $fgName = Get-FailoverGroupName
		$fg = New-AzSqlDatabaseInstanceFailoverGroup -ResourceGroupName $rg -Location $location  -PrimaryManagedInstanceName $managedInstanceName -Name $fgName -PartnerRegion $partnerRegion -PartnerManagedInstanceName $partnerManagedInstanceName -FailoverPolicy Automatic -GracePeriodWithDataLossHours 123 -AllowReadOnlyFailoverToPrimary Enabled
		Validate-InstanceFailoverGroup $rg $fgName $managedInstanceName $partnerManagedInstanceName Primary Secondary Automatic 123 Enabled $fg
		Validate-InstanceFailoverGroupWithGet $fg

		$fg | Remove-AzSqlDatabaseInstanceFailoverGroup -Force
	}
}

function Test-CreateInstanceFailoverGroup-ManualPolicy()
{
	Handle-InstanceFailoverGroupTest {
		Param($location, $partnerRegion, $rg, $managedInstanceName, $partnerManagedInstanceName)

        $fgName = Get-FailoverGroupName
		$fg = New-AzSqlDatabaseInstanceFailoverGroup -ResourceGroupName $rg -Location $location  -PrimaryManagedInstanceName $managedInstanceName -Name $fgName -PartnerRegion $partnerRegion -PartnerManagedInstanceName $partnerManagedInstanceName -FailoverPolicy Manual 
        Validate-InstanceFailoverGroup $rg $fgName $managedInstanceName $partnerManagedInstanceName Primary Secondary Manual $null Disabled $fg
		Validate-InstanceFailoverGroupWithGet $fg

		$fg | Remove-AzSqlDatabaseInstanceFailoverGroup -Force
	}
}

function Test-SetInstanceFailoverGroup-Named()
{
	Handle-InstanceFailoverGroupTestWithInstanceFailoverGroup {
		Param($fg)

		$newFg = $fg | Set-AzSqlDatabaseInstanceFailoverGroup 
		Assert-InstanceFailoverGroupsEqual $fg $newFg
		Validate-InstanceFailoverGroupWithGet $newFg
		
		$newFg | Remove-AzSqlDatabaseInstanceFailoverGroup -Force
	}
}

function Test-SetInstanceFailoverGroup-Positional()
{
	Handle-InstanceFailoverGroupTestWithInstanceFailoverGroup {
		Param($fg)

		$newFg = $fg | Set-AzSqlDatabaseInstanceFailoverGroup
		Assert-InstanceFailoverGroupsEqual $fg $newFg
		Validate-InstanceFailoverGroupWithGet $newFg

		$newFg | Remove-AzSqlDatabaseInstanceFailoverGroup -Force
	}
}

function Test-SetInstanceFailoverGroup-AutomaticWithGracePeriodReadOnlyFailover()
{
	Handle-InstanceFailoverGroupTestWithInstanceFailoverGroup {
		Param($fg)

		$newFg = $fg | Set-AzSqlDatabaseInstanceFailoverGroup -FailoverPolicy Automatic -GracePeriodWithDataLossHours 123 -AllowReadOnlyFailoverToPrimary Enabled
		Assert-InstanceFailoverGroupsEqual $fg $newFg -failoverPolicy Automatic -gracePeriod 123 -readOnlyFailoverPolicy Enabled
		Validate-InstanceFailoverGroupWithGet $newFg

		$newFg | Remove-AzSqlDatabaseInstanceFailoverGroup -Force
	} -failoverPolicy Manual
}

function Test-SetInstanceFailoverGroup-AutomaticToManual()
{
	Handle-InstanceFailoverGroupTestWithInstanceFailoverGroup {
		Param($fg)

		$newFg = $fg | Set-AzSqlDatabaseInstanceFailoverGroup -FailoverPolicy Manual
		Assert-InstanceFailoverGroupsEqual $fg $newFg -failoverPolicy Manual -gracePeriod $null
		Validate-InstanceFailoverGroupWithGet $newFg

		$newFg | Remove-AzSqlDatabaseInstanceFailoverGroup -Force
	}
}

function Test-SetInstanceFailoverGroup-ManualToAutomaticNoGracePeriod()
{
	Handle-InstanceFailoverGroupTestWithInstanceFailoverGroup {
		Param($fg)

		$newFg = $fg | Set-AzSqlDatabaseInstanceFailoverGroup -FailoverPolicy Manual
		Assert-InstanceFailoverGroupsEqual $fg $newFg -failoverPolicy Manual -gracePeriod $null

		$newFg = $fg | Set-AzSqlDatabaseInstanceFailoverGroup -FailoverPolicy Automatic
		Assert-InstanceFailoverGroupsEqual $fg $newFg -failoverPolicy Automatic -gracePeriod 1
		Validate-InstanceFailoverGroupWithGet $newFg

		$newFg | Remove-AzSqlDatabaseInstanceFailoverGroup -Force
	} -failoverPolicy Manual
}

function Test-SwitchInstanceFailoverGroup()
{
	Handle-InstanceFailoverGroupTestWithInstanceFailoverGroup {
		Param($fg)

		$fg | Switch-AzSqlDatabaseInstanceFailoverGroup 

		$newPrimaryFg = Get-AzSqlDatabaseInstanceFailoverGroup -ResourceGroupName $fg.ResourceGroupName -Location $fg.Location -Name $fg.Name

		Validate-InstanceFailoverGroupWithGet $newPrimaryFg		

		$newPrimaryFg | Remove-AzSqlDatabaseInstanceFailoverGroup -Force
	}
}

function Test-SwitchInstanceFailoverGroupAllowDataLoss()
{
	Handle-InstanceFailoverGroupTestWithInstanceFailoverGroup {
		Param($fg)

		$fg | Switch-AzSqlDatabaseInstanceFailoverGroup -AllowDataLoss
		$newPrimaryFg = Get-AzSqlDatabaseInstanceFailoverGroup -ResourceGroupName $fg.ResourceGroupName -Location $fg.Location -Name $fg.Name

		Validate-InstanceFailoverGroupWithGet $newPrimaryFg

		$newPrimaryFg | Remove-AzSqlDatabaseInstanceFailoverGroup -Force
	}
}