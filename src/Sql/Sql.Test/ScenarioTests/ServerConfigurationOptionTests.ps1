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

# Location to use for provisioning test managed instances
$instanceLocation = "westcentralus"

# Test constants
$type = "Microsoft.Sql/managedInstances/serverConfigurationOptions"
$name = "allowPolybaseExport"


<#
    .SYNOPSIS
    Tests creating a server configuration option
#>
function Test-ServerConfigurationOption
{
    try
    {
        # Setup
        $rg = Create-ResourceGroupForTest
        $managedInstance = Create-ManagedInstanceForTest $rg
        $rgName = $rg.ResourceGroupName
        $miName = $managedInstance.ManagedInstanceName
                
        # generate expected config opt id
        $instance = Get-AzSqlInstance -ResourceGroupName $rgName -Name $miName
        $instanceId = $instance.Id
        $id = $instanceId + "/serverConfigurationOptions/allowPolybaseExport"

        # Set config value to 1 CreateByNameParameterSet
        $configOpt = Set-AzSqlServerConfigurationOption -ResourceGroupName $rgName -InstanceName $miName -Name $name -Value 1
        Write-Debug ('$configOpt is ' + (ConvertTo-Json $configOpt))
        Assert-NotNull $configOpt
        Assert-AreEqual	$configOpt.ResourceGroupName $rgName
        Assert-AreEqual	$configOpt.InstanceName $miName
        Assert-AreEqual $configOpt.Id $id
        Assert-AreEqual	$configOpt.Type $type
        Assert-AreEqual	$configOpt.Name $name
        Assert-AreEqual	$configOpt.Value 1

        # Reset config value via CreateByParentObjectParameterSet
        $configOpt = Set-AzSqlServerConfigurationOption -InstanceObject $instance -Name $name -Value 0
        Write-Debug ('$configOpt is ' + (ConvertTo-Json $configOpt))
        Assert-NotNull $configOpt
        Assert-AreEqual	$configOpt.ResourceGroupName $rgName
        Assert-AreEqual	$configOpt.InstanceName $miName
        Assert-AreEqual $configOpt.Id $id
        Assert-AreEqual	$configOpt.Type $type
        Assert-AreEqual	$configOpt.Name $name
        Assert-AreEqual	$configOpt.Value 0

        # Test all 4 parameter sets for GET:
        # GetByNameParameterSet
        # GetByParentObjectParameterSet
        # GetByResourceIdParameterSet
        # GetByInstanceResourceIdParameterSet

        # Get opt - (GetByNameParameterSet)
        $configOpt = Get-AzSqlServerConfigurationOption -ResourceGroupName $rgName -InstanceName $miName -Name $name
        Write-Debug ('$configOpt is ' + (ConvertTo-Json $configOpt))
        Assert-NotNull $configOpt
        Assert-AreEqual	$configOpt.ResourceGroupName $rgName
        Assert-AreEqual	$configOpt.InstanceName $miName
        Assert-AreEqual $configOpt.Id $id
        Assert-AreEqual	$configOpt.Type $type
        Assert-AreEqual	$configOpt.Name $name
        Assert-AreEqual	$configOpt.Value 0

        # Get opt - (GetByParentObjectParameterSet)
        $configOpt = Get-AzSqlServerConfigurationOption -InstanceObject $instance -Name $name
        Write-Debug ('$configOpt is ' + (ConvertTo-Json $configOpt))
        Assert-NotNull $configOpt
        Assert-AreEqual	$configOpt.ResourceGroupName $rgName
        Assert-AreEqual	$configOpt.InstanceName $miName
        Assert-AreEqual $configOpt.Id $id
        Assert-AreEqual	$configOpt.Type $type
        Assert-AreEqual	$configOpt.Name $name
        Assert-AreEqual	$configOpt.Value 0

        # Get opt - (GetByResourceIdParameterSet)
        $configOpt = Get-AzSqlServerConfigurationOption -ResourceId $id
        Write-Debug ('$configOpt is ' + (ConvertTo-Json $configOpt))
        Assert-NotNull $configOpt
        Assert-AreEqual	$configOpt.ResourceGroupName $rgName
        Assert-AreEqual	$configOpt.InstanceName $miName
        Assert-AreEqual $configOpt.Id $id
        Assert-AreEqual	$configOpt.Type $type
        Assert-AreEqual	$configOpt.Name $name
        Assert-AreEqual	$configOpt.Value 0

        # Get opt - (GetByInstanceResourceIdParameterSet)
        $configOpt = Get-AzSqlServerConfigurationOption -InstanceResourceId $instanceId -Name $name
        Write-Debug ('$configOpt is ' + (ConvertTo-Json $configOpt))
        Assert-NotNull $configOpt
        Assert-AreEqual	$configOpt.ResourceGroupName $rgName
        Assert-AreEqual	$configOpt.InstanceName $miName
        Assert-AreEqual $configOpt.Id $id
        Assert-AreEqual	$configOpt.Type $type
        Assert-AreEqual	$configOpt.Name $name
        Assert-AreEqual	$configOpt.Value 0

        # List all opts
        $configOpts = Get-AzSqlServerConfigurationOption -ResourceGroupName $rgName -InstanceName $miName
        Write-Debug ('$configOpts is ' + (ConvertTo-Json $configOpts))
        Assert-NotNull $configOpts
        Assert-AreEqual	$configOpts.Count 1

        # Get non existant config opt #1 THROWS
        $msgExcGet = "Cannot validate argument on parameter 'Name'."
        Assert-ThrowsContains { Get-AzSqlServerConfigurationOption -ResourceGroupName $rgName -InstanceName $miName -Name "randomConfigFlag" } $msgExc
        
        # Set invalid config value
        $msgExcGet = "Cannot validate argument on parameter 'Value'."
        Assert-ThrowsContains { Set-AzSqlServerConfigurationOption -ResourceGroupName $rgName -InstanceName $miName -Name $name -Value 3 } $msgExc

    }
    finally
    {
        Remove-ResourceGroupForTest $rg
    }
}

<#
    .SYNOPSIS
    Tests creating a server configuration option
#>
function Test-ServerConfigurationOptionPiping
{
    try
    {
        # Setup
        $rg = Create-ResourceGroupForTest
        $managedInstance = Create-ManagedInstanceForTest $rg
        $rgName = $rg.ResourceGroupName
        $miName = $managedInstance.ManagedInstanceName
        $instance = Get-AzSqlInstance -ResourceGroupName $rgName -Name $miName 

        # set config value via ParentObject piping
        $configOpt = $instance | Set-AzSqlServerConfigurationOption -Name $name -Value 1

        # get & list via parent object piping 
        $litOpts = $instance | Get-AzSqlServerConfigurationOption
        $getOpt =  $instance | Get-AzSqlServerConfigurationOption -Name $name
        Write-Debug ('$litOpts is ' + (ConvertTo-Json $litOpts))
        Write-Debug ('$getOpt is ' + (ConvertTo-Json $getOpt))
        Assert-NotNull $litOpts
        Assert-NotNull $getOpt

    }
    finally
    {
        Remove-ResourceGroupForTest $rg
    }
}
