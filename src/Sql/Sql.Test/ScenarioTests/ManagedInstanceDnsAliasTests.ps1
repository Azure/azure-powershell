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

<#
    .SYNOPSIS
    Tests regarding managed instance DNS aliases.
#>

<#
    .SYNOPSIS
    Helper function for validating DNS alias object.
    .DESCRIPTION
    This function accepts DNS alias object and expected parameters. If the $hasAzureDnsRecord is passed, then we check that the dns record is different from null.
    If the expectedResourceId is passed, we also check that field (this is only used for set operations so we check if it stayed the same after update).
#>
function ValidateDnsAlias($managedInstanceDnsAliasActualObject, $expectedAliasName, $expectedRGName, $expectMIName, $hasAzureDnsRecord, $expectedResourceId)
{
    Assert-AreEqual $expectedAliasName $managedInstanceDnsAliasActualObject.DnsAliasName
    Assert-AreEqual $expectedRGName $managedInstanceDnsAliasActualObject.ResourceGroupName
    Assert-AreEqual $expectMIName $managedInstanceDnsAliasActualObject.ManagedInstanceName
    Assert-NotNull $managedInstanceDnsAliasActualObject.Id
    Assert-Null $managedInstanceDnsAliasActualObject.PublicDnsRecord
    if($hasAzureDnsRecord)
    {
        Assert-NotNull $managedInstanceDnsAliasActualObject.AzureDnsRecord
    }
    else
    {
        Assert-Null $managedInstanceDnsAliasActualObject.AzureDnsRecord
    }
    #Resource id is passed in case of set operation. Check if it stayed the same after updating.
    if($expectedResourceId)
    {
        Assert-AreEqual $expectedResourceId $managedInstanceDnsAliasActualObject.Id
    }
}

<#
    .SYNOPSIS
    Tests CRUD operations on Managed Instance DNS Aliases using different parameter sets.
#>
function Test-ManagedInstanceDnsAliasCRUDOperations
{
    try
    {
        Write-Debug "Creating test MI"
        $rg = Create-ResourceGroupForTest
        $managedInstance = Create-ManagedInstanceForTest $rg
        $managedInstanceName = $managedInstance.ManagedInstanceName
        $rgName = $rg.ResourceGroupName

        #Create, update and delete by name. Also use -AsJob in order to test that functionality.

        $testAliasName = $managedInstanceName + "-testalias"

        #Create by name parameter set
        Write-Debug "Creating by name"
        $aliasJob = New-AzSqlInstanceDnsAlias -ResourceGroupName $rgName -InstanceName $managedInstanceName -Name $testAliasName -AsJob
        $aliasJob | Wait-Job
        $managedInstanceDnsAlias = $aliasJob.Output
        $managedInstanceDnsAliasResourceId = $managedInstanceDnsAlias.Id
        ValidateDnsAlias $managedInstanceDnsAlias $testAliasName $rgName $managedInstanceName $false

        #Set by name parameter set
        Write-Debug "Setting by name"
        $aliasJob = Set-AzSqlInstanceDnsAlias -ResourceGroupName $rgName -InstanceName $managedInstanceName -Name $testAliasName -HasDnsRecord -AsJob
        $aliasJob | Wait-Job
        $managedInstanceDnsAlias = $aliasJob.Output
        ValidateDnsAlias $managedInstanceDnsAlias $testAliasName $rgName $managedInstanceName $true $managedInstanceDnsAliasResourceId

        #Remove by name parameter set and use PassThru parameter
        Write-Debug "Removing by name"
        $aliasJob = Remove-AzSqlInstanceDnsAlias -ResourceGroupName $rgName -InstanceName $managedInstanceName -Name $testAliasName -PassThru -Force -AsJob
        $aliasJob | Wait-Job
        $managedInstanceDnsAlias = $aliasJob.Output

        #Since -PassThru was passed, we expect that the remove cmdlet returned the original object
        ValidateDnsAlias $managedInstanceDnsAlias $testAliasName $rgName $managedInstanceName $true $managedInstanceDnsAliasResourceId

        #Create by parent object parameter set. This time create the DNS record, then remove it using the set command (by not specifying -HasDnsRecord)
        Write-Debug "Creating by parent object"
        $managedInstanceDnsAlias = New-AzSqlInstanceDnsAlias -InstanceObject $managedInstance -Name $testAliasName -CreateDnsRecord
        $managedInstanceDnsAliasResourceId = $managedInstanceDnsAlias.Id
        ValidateDnsAlias $managedInstanceDnsAlias $testAliasName $rgName $managedInstanceName $true

        #Set by parent object parameter set
        Write-Debug "Setting by parent object"
        $managedInstanceDnsAlias = Set-AzSqlInstanceDnsAlias -InstanceObject $managedInstance -Name $testAliasName
        ValidateDnsAlias $managedInstanceDnsAlias $testAliasName $rgName $managedInstanceName $false $managedInstanceDnsAliasResourceId

        #Remove by parent object parameter set
        Write-Debug "Removing by parent object"
        Remove-AzSqlInstanceDnsAlias -InstanceObject $managedInstance -Name $testAliasName -Force

        #All create parameter sets have been tested by this point. We need to create a new alias for testing of set and remove commands.
        #Set and remove by input object parameter sets.
        $managedInstanceDnsAlias = New-AzSqlInstanceDnsAlias -InstanceObject $managedInstance -Name $testAliasName
        $managedInstanceDnsAliasResourceId = $managedInstanceDnsAlias.Id
        ValidateDnsAlias $managedInstanceDnsAlias $testAliasName $rgName $managedInstanceName $false

        #Set by input object parameter set
        Write-Debug "Setting by input object"
        $managedInstanceDnsAlias = Set-AzSqlInstanceDnsAlias -InputObject $managedInstanceDnsAlias -HasDnsRecord
        ValidateDnsAlias $managedInstanceDnsAlias $testAliasName $rgName $managedInstanceName $true $managedInstanceDnsAliasResourceId

        #Remove by input object parameter set
        Write-Debug "Removing by input object"
        Remove-AzSqlInstanceDnsAlias -InputObject $managedInstanceDnsAlias -Force

        #Set and remove by resource ID parameter sets.
        #First we need to create the DNS alias for testing.
        $managedInstanceDnsAlias = New-AzSqlInstanceDnsAlias -InstanceObject $managedInstance -Name $testAliasName
        $managedInstanceDnsAliasResourceId = $managedInstanceDnsAlias.Id
        ValidateDnsAlias $managedInstanceDnsAlias $testAliasName $rgName $managedInstanceName $false

        #Set by input object parameter set
        Write-Debug "Setting by resource ID"
        $managedInstanceDnsAlias = Set-AzSqlInstanceDnsAlias -ResourceId $managedInstanceDnsAliasResourceId -HasDnsRecord
        ValidateDnsAlias $managedInstanceDnsAlias $testAliasName $rgName $managedInstanceName $true $managedInstanceDnsAliasResourceId

        #Remove by input object parameter set
        Write-Debug "Removing by resource ID"
        Remove-AzSqlInstanceDnsAlias -ResourceId $managedInstanceDnsAliasResourceId -Force
    }
     finally {
         Remove-ResourceGroupForTest $rg
     }
}

<#
    .SYNOPSIS
    Tests Get and Move operations on Managed Instance DNS Aliases using different parameter sets.
#>
function Test-ManagedInstanceDnsAliasGetAndMoveOperations
{
        #Move command has 8 parameter sets:
        # - MoveByNamesParameterSet - target MI and source DNS alias are both passed by name
        # - MoveByNameAndSourceParentObjectParameterSet - target MI is passed by name, but source DNS alias is passed by parent object
        # - MoveByNameAndSourceInputObjectParameterSet - target MI is passed by name, but source DNS alias is passed by input object
        # - MoveByNameAndSourceResourceIdParameterSet - default - target MI is passed by name, but source DNS alias is passed by resource ID
        # - MoveByParentObjectAndSourceNameParameterSet - target MI is passed by parent object, but source DNS alias is passed by name
        # - MoveByParentObjectsParameterSet - target MI and source DNS alias are both passed by parent object
        # - MoveByParentObjectAndSourceInputObjectParameterSet - target MI is passed by parent object, but source DNS alias is passed by input object
        # - MoveByParentObjectAndSourceResourceIdParameterSet - target MI is passed by parent object, but source DNS alias is passed by resource ID

    try {
        $rg = Create-ResourceGroupForTest

        Write-Debug "Creating source MI"
        $sourceManagedInstance = Create-ManagedInstanceForTest $rg
        Write-Debug "Creating target MI"
        $targetManagedInstance = Create-ManagedInstanceForTest $rg

        $sourceManagedInstanceName = $sourceManagedInstance.ManagedInstanceName
        $targetManagedInstanceName = $targetManagedInstance.ManagedInstanceName

        $rgName = $rg.ResourceGroupName

        $testAliasName = $sourceManagedInstanceName + "-testalias"

        #Create new DNS alias on source instance.
        Write-Debug("Creating source DNS alias")
        $createdManagedInstanceDnsAlias = New-AzSqlInstanceDnsAlias -ResourceGroupName $rgName -InstanceName $sourceManagedInstanceName -Name $testAliasName

        #Get and move by name parameter set.
        $managedInstanceDnsAlias = Get-AzSqlInstanceDnsAlias -ResourceGroupName $rgName -InstanceName $sourceManagedInstanceName -Name $testAliasName

        #Validate if it is the same as the created DNS alias.
        ValidateDnsAlias $managedInstanceDnsAlias $createdManagedInstanceDnsAlias.DnsAliasName $createdManagedInstanceDnsAlias.ResourceGroupName $createdManagedInstanceDnsAlias.ManagedInstanceName $false $createdManagedInstanceDnsAlias.Id

        #Test get alias wildcard filter on Name
        $managedInstanceDnsAlias = Get-AzSqlInstanceDnsAlias -ResourceGroupName $rgName -InstanceName $sourceManagedInstanceName -Name "*test*"
        ValidateDnsAlias $managedInstanceDnsAlias $createdManagedInstanceDnsAlias.DnsAliasName $createdManagedInstanceDnsAlias.ResourceGroupName $createdManagedInstanceDnsAlias.ManagedInstanceName $false $createdManagedInstanceDnsAlias.Id


        #Move by names parameter set and use AsJob to test that functionality
        $aliasJob = Move-AzSqlInstanceDnsAlias -DestResourceGroupName $rgName -DestInstanceName $targetManagedInstanceName -SourceResourceGroupName $rgName -SourceInstanceName $sourceManagedInstanceName -SourceName $testAliasName -AsJob
        $aliasJob | Wait-Job
        $managedInstanceDnsAlias = $aliasJob.Output

        ValidateDnsAlias $managedInstanceDnsAlias $testAliasName $rgName $targetManagedInstanceName $false
        $managedInstanceDnsAliasResourceId = $managedInstanceDnsAlias.Id
        Assert-True {$managedInstanceDnsAliasResourceId.Contains($targetManagedInstanceName)}

        #Get the DNS alias and check if it was moved correctly
        $managedInstanceDnsAlias = Get-AzSqlInstanceDnsAlias -ResourceGroupName $rgName -InstanceName $targetManagedInstanceName -Name $testAliasName
        # The validation should also compare the resource IDs from objects returned by get and move cmdlets, but due to a bug in the backend,
        # the move cmdlet returns an object with a resource ID that misses resource group. Because of that, we skip the validation of the resource ID.
        ValidateDnsAlias $managedInstanceDnsAlias $testAliasName $rgName $targetManagedInstanceName $false

        #Move by name and source parent object parameter set
        #Since the alias is now on the target instance, we will move it back to the source

        $managedInstanceDnsAlias = Move-AzSqlInstanceDnsAlias -DestResourceGroupName $rgName -DestInstanceName $sourceManagedInstanceName -SourceInstanceObject $targetManagedInstance -SourceName $testAliasName
        ValidateDnsAlias $managedInstanceDnsAlias $testAliasName $rgName $sourceManagedInstanceName $false
        $managedInstanceDnsAliasResourceId = $managedInstanceDnsAlias.Id
        Assert-True {$managedInstanceDnsAliasResourceId.Contains($sourceManagedInstanceName)}

        #Move by name and source input object parameter set
        #From now on the dns alias is swapped between two instances
        
        #Get the dns alias
        $managedInstanceDnsAlias = Get-AzSqlInstanceDnsAlias -ResourceGroupName $rgName -InstanceName $sourceManagedInstanceName -Name $testAliasName

        $managedInstanceDnsAlias = Move-AzSqlInstanceDnsAlias -DestResourceGroupName $rgName -DestInstanceName $targetManagedInstanceName -SourceInputObject $managedInstanceDnsAlias
        ValidateDnsAlias $managedInstanceDnsAlias $testAliasName $rgName $targetManagedInstanceName $false
        $managedInstanceDnsAliasResourceId = $managedInstanceDnsAlias.Id
        Assert-True {$managedInstanceDnsAliasResourceId.Contains($targetManagedInstanceName)}

        #Move by name (and use alias for parameters) and source input resource id parameter set
        $managedInstanceDnsAlias = Get-AzSqlInstanceDnsAlias -ResourceGroupName $rgName -InstanceName $targetManagedInstanceName -Name $testAliasName

        $managedInstanceDnsAlias = Move-AzSqlInstanceDnsAlias -DestResourceGroupName $rgName -DestInstanceName $sourceManagedInstanceName -SourceResourceId $managedInstanceDnsAlias.Id
        ValidateDnsAlias $managedInstanceDnsAlias $testAliasName $rgName $sourceManagedInstanceName $false
        $managedInstanceDnsAliasResourceId = $managedInstanceDnsAlias.Id
        Assert-True {$managedInstanceDnsAliasResourceId.Contains($sourceManagedInstanceName)}

        #Get and move by parent object

        #Move by parent objects parameter set
        $managedInstanceDnsAlias = Move-AzSqlInstanceDnsAlias -DestInstanceObject $targetManagedInstance -SourceInstanceObject $sourceManagedInstance -SourceName $testAliasName
        ValidateDnsAlias $managedInstanceDnsAlias $testAliasName $rgName $targetManagedInstanceName $false
        $managedInstanceDnsAliasResourceId = $managedInstanceDnsAlias.Id
        Assert-True {$managedInstanceDnsAliasResourceId.Contains($targetManagedInstanceName)}

        #Get the DNS alias by parent object parameter set and check if it was moved correctly
        $managedInstanceDnsAlias = Get-AzSqlInstanceDnsAlias -InstanceObject $targetManagedInstance -Name $testAliasName
        ValidateDnsAlias $managedInstanceDnsAlias $testAliasName $rgName $targetManagedInstanceName $false

        #Move by parent object and source name parameter set (use alias for source name also)
        $managedInstanceDnsAlias = Move-AzSqlInstanceDnsAlias -DestInstanceObject $sourceManagedInstance -SourceResourceGroupName $rgName -SourceInstanceName $targetManagedInstanceName -SourceDnsAliasName $testAliasName
        ValidateDnsAlias $managedInstanceDnsAlias $testAliasName $rgName $sourceManagedInstanceName $false
        $managedInstanceDnsAliasResourceId = $managedInstanceDnsAlias.Id
        Assert-True {$managedInstanceDnsAliasResourceId.Contains($sourceManagedInstanceName)}

        #Move by parent object and source input object parameter set
        $managedInstanceDnsAlias = Get-AzSqlInstanceDnsAlias -ResourceGroupName $rgName -InstanceName $sourceManagedInstanceName -Name $testAliasName

        $managedInstanceDnsAlias = Move-AzSqlInstanceDnsAlias -DestInstanceObject $targetManagedInstance -SourceInputObject $managedInstanceDnsAlias
        ValidateDnsAlias $managedInstanceDnsAlias $testAliasName $rgName $targetManagedInstanceName $false
        $managedInstanceDnsAliasResourceId = $managedInstanceDnsAlias.Id
        Assert-True {$managedInstanceDnsAliasResourceId.Contains($targetManagedInstanceName)}

        #Move by parent object (and also use alias for parent object parameter) and source resource id parameter set
        $managedInstanceDnsAlias = Get-AzSqlInstanceDnsAlias -ResourceGroupName $rgName -InstanceName $targetManagedInstanceName -Name $testAliasName

        $managedInstanceDnsAlias = Move-AzSqlInstanceDnsAlias -DestInstanceObject $sourceManagedInstance -SourceResourceId $managedInstanceDnsAlias.Id
        ValidateDnsAlias $managedInstanceDnsAlias $testAliasName $rgName $sourceManagedInstanceName $false
        $managedInstanceDnsAliasResourceId = $managedInstanceDnsAlias.Id
        Assert-True {$managedInstanceDnsAliasResourceId.Contains($sourceManagedInstanceName)}

        #Get by resource id to test that functionality. Because of the bug that was mentioned before, the resource ID in the object returned from the
        #move command, we cannot use that resource ID to fetch the dns alias. That's why we will first fetch by name, extract the resource ID from the fetched object
        #and then fetch by resource ID.
        $managedInstanceDnsAlias = Get-AzSqlInstanceDnsAlias -ResourceGroupName $rgName -InstanceName $sourceManagedInstanceName -Name $testAliasName
        $managedInstanceDnsAlias = Get-AzSqlInstanceDnsAlias -ResourceId $managedInstanceDnsAlias.Id
        ValidateDnsAlias $managedInstanceDnsAlias $testAliasName $rgName $sourceManagedInstanceName $false
    }
    finally
    {
        Remove-ResourceGroupForTest $rg
    }
}

<#
    .SYNOPSIS
    Tests some piping scenarios for various operations on Managed Instance DNS Aliases.
#>
function Test-ManagedInstanceDnsAliasPipingScenarios
{
    try {
        $rg = Create-ResourceGroupForTest

        Write-Debug "Creating source MI"
        $sourceManagedInstance = Create-ManagedInstanceForTest $rg
        Write-Debug "Creating target MI"
        $targetManagedInstance = Create-ManagedInstanceForTest $rg

        $sourceManagedInstanceName = $sourceManagedInstance.ManagedInstanceName
        $targetManagedInstanceName = $targetManagedInstance.ManagedInstanceName

        $rgName = $rg.ResourceGroupName

        $testAliasName = $sourceManagedInstanceName + "-testalias"

        #Create MI DNS alias by piping the MI object
        $createdInstanceDnsAlias = $sourceManagedInstance | New-AzSqlInstanceDnsAlias -Name $testAliasName -CreateDnsRecord

        #List MI DNS alias by piping parent MI object
        $managedInstanceDnsAliases = $sourceManagedInstance | Get-AzSqlInstanceDnsAlias

        #Validate that the list contains only 1 entry
        Assert-AreEqual $managedInstanceDnsAliases.Count 1

        #Validate it is the same as the created dns alias
        ValidateDnsAlias $managedInstanceDnsAliases[0] $createdInstanceDnsAlias.DnsAliasName $createdInstanceDnsAlias.ResourceGroupName $createdInstanceDnsAlias.ManagedInstanceName $true $createdInstanceDnsAlias.Id

        #Get DNS alias by piping the alias resource Id
        $managedInstanceDnsAlias = $createdInstanceDnsAlias.Id | Get-AzSqlInstanceDnsAlias

        #Validate it is the same as the created dns alias
        ValidateDnsAlias $managedInstanceDnsAlias $createdInstanceDnsAlias.DnsAliasName $createdInstanceDnsAlias.ResourceGroupName $createdInstanceDnsAlias.ManagedInstanceName $true $createdInstanceDnsAlias.Id

        #Test set command piping
        #Set by piping parent object
        $managedInstanceDnsAlias = $sourceManagedInstance | Set-AzSqlInstanceDnsAlias -Name $testAliasName

        #Validate it was updated correctly (the azure dns recourd should be null)
        ValidateDnsAlias $managedInstanceDnsAlias $testAliasName $rgName $sourceManagedInstanceName $false

        #Set by piping input object
        $managedInstanceDnsAlias = $managedInstanceDnsAlias | Set-AzSqlInstanceDnsAlias -HasDnsRecord

        #Validate it was updated correctly (the azure dns recourd should exist now)
        ValidateDnsAlias $managedInstanceDnsAlias $testAliasName $rgName $sourceManagedInstanceName $true

        #Set by piping resource id
        $managedInstanceDnsAlias = $managedInstanceDnsAlias.Id | Set-AzSqlInstanceDnsAlias

        #Validate it was updated correctly (the azure dns recourd should be null)
        ValidateDnsAlias $managedInstanceDnsAlias $testAliasName $rgName $sourceManagedInstanceName $false

        #Test move commands:
        # - Target instance object, source instance object and source input object can only be passed from pipeline but cannot be passed from pipeline by property name
        # - Source resource id can be passed from pipeline by property name also

        #Pass target instance object by pipeline
        $managedInstanceDnsAlias = $targetManagedInstance | Move-AzSqlInstanceDnsAlias -SourceResourceId $managedInstanceDnsAlias.ID

        #Validate that move has been successfully completed
        ValidateDnsAlias $managedInstanceDnsAlias $testAliasName $rgName $targetManagedInstanceName $false
        $managedInstanceDnsAliasResourceId = $managedInstanceDnsAlias.Id
        Assert-True {$managedInstanceDnsAliasResourceId.Contains($targetManagedInstanceName)}

        #Since both target instance object and source instance object, source input object are passed through pipeline (but not by property name)
        # we cannot pipe source instance object and source input object when using parameter sets which have target instance object (because of PS limitations regarding pipelines)
        # PowerShell limits that only a single parameter can be passed by pipeline in the same parameter set. Others can only be passed by pipeline through property name.
        # That's why source instance object and source input object can only be piped if using ByName parameter sets for target instance object.
        #Pass source instance object (which is now $targetManagedInstance because the dns alias has been moved previously) by pipeline
        $managedInstanceDnsAlias = $targetManagedInstance | Move-AzSqlInstanceDnsAlias -DestResourceGroupName $rgName -DestInstanceName $sourceManagedInstanceName -SourceName $testAliasName

        #Validate that move has been successfully completed
        ValidateDnsAlias $managedInstanceDnsAlias $testAliasName $rgName $sourceManagedInstanceName $false
        $managedInstanceDnsAliasResourceId = $managedInstanceDnsAlias.Id
        Assert-True {$managedInstanceDnsAliasResourceId.Contains($sourceManagedInstanceName)}

        #Pass source input object via pipeline. First we need to get it, because of the bug regarding resource id from move command output
        $managedInstanceDnsAlias = Get-AzSqlInstanceDnsAlias -InstanceObject $sourceManagedInstance -Name $testAliasName

        #Now pass the input object through pipeline
        $managedInstanceDnsAlias = $managedInstanceDnsAlias | Move-AzSqlInstanceDnsAlias -DestResourceGroupName $rgName -DestInstanceName $targetManagedInstanceName

        #Validate that move has been successfully completed
        ValidateDnsAlias $managedInstanceDnsAlias $testAliasName $rgName $targetManagedInstanceName $false
        $managedInstanceDnsAliasResourceId = $managedInstanceDnsAlias.Id
        Assert-True {$managedInstanceDnsAliasResourceId.Contains($targetManagedInstanceName)}

        #Pass source resource Id by pipiline. First we need to get it for the correct resource Id
        $managedInstanceDnsAlias = Get-AzSqlInstanceDnsAlias -InstanceObject $targetManagedInstance -Name $testAliasName

        #Now pass the source resource Id
        $managedInstanceDnsAlias = $managedInstanceDnsAlias.Id | Move-AzSqlInstanceDnsAlias -DestResourceGroupName $rgName -DestInstanceName $sourceManagedInstanceName

        #Validate that move has been successfully completed
        ValidateDnsAlias $managedInstanceDnsAlias $testAliasName $rgName $sourceManagedInstanceName $false
        $managedInstanceDnsAliasResourceId = $managedInstanceDnsAlias.Id
        Assert-True {$managedInstanceDnsAliasResourceId.Contains($sourceManagedInstanceName)}

        #Pass source resource Id by pipiline by property name.Now we can use target instance object as a parameter too.
        #First we need to get it for the correct resource Id
        $managedInstanceDnsAlias = Get-AzSqlInstanceDnsAlias -InstanceObject $sourceManagedInstance -Name $testAliasName

        # Even though we are passing $managedInstanceDnsAlias to the pipeline, the actual parameter set will recognize the Id property of it and use the
        # MoveByParentObjectAndSourceResourceIdParameterSet. This happens because source resource Id can be passed by property name too.
        $managedInstanceDnsAlias = $managedInstanceDnsAlias | Move-AzSqlInstanceDnsAlias -DestInstanceObject $targetManagedInstance

        #Validate that move has been successfully completed
        ValidateDnsAlias $managedInstanceDnsAlias $testAliasName $rgName $targetManagedInstanceName $false
        $managedInstanceDnsAliasResourceId = $managedInstanceDnsAlias.Id
        Assert-True {$managedInstanceDnsAliasResourceId.Contains($targetManagedInstanceName)}
    }
    finally
    {
        Remove-ResourceGroupForTest $rg
    }
}

<#
    .SYNOPSIS
    Tests whether errors are handled correctly for various operations on Managed Instance DNS Aliases.
#>
function Test-ManagedInstanceDnsAliasErrorHandling
{
    try {
        $rg = Create-ResourceGroupForTest

        Write-Debug "Creating source MI"
        $managedInstance = Create-ManagedInstanceForTest $rg

        $managedInstanceName = $managedInstance.ManagedInstanceName

        $rgName = $rg.ResourceGroupName

        $testAliasName = $managedInstanceName + "-testalias"
        $invalidMIName = "invalidname"

        #Test whether required parameters are validated to not be null or empty
        $errorMessage = "Cannot validate argument on parameter"
        Assert-ThrowsContains { New-AzSqlInstanceDnsAlias -ResourceGroupName $rgName -InstanceName $managedInstanceName -Name ""} $errorMessage
        Assert-ThrowsContains { New-AzSqlInstanceDnsAlias -ResourceGroupName $rgName -InstanceName "" -Name $testAliasName} $errorMessage
        Assert-ThrowsContains { New-AzSqlInstanceDnsAlias -ResourceGroupName "" -InstanceName $managedInstanceName -Name $testAliasName} $errorMessage
        Assert-ThrowsContains { New-AzSqlInstanceDnsAlias -InstanceObject $null -Name $testAliasName} $msgExc

        #Get a non existant DNS alias
        $msgExcNotFound = "The requested resource of type 'Microsoft.Sql/managedInstances/dnsAliases' with name '" + $testAliasName + "' was not found."
        Assert-ThrowsContains { Get-AzSqlInstanceDnsAlias -ResourceGroupName $rgName -InstanceName $managedInstanceName -Name $testAliasName} $msgExcNotFound

        #Do the same for set
        Assert-ThrowsContains { Set-AzSqlInstanceDnsAlias -ResourceGroupName $rgName -InstanceName $managedInstanceName -Name $testAliasName -HasDnsRecord} $msgExcNotFound

        #Check moving to non existant MI
        $msgExcNotFoundParent = "Can not perform requested operation on nested resource. Parent resource '" + $invalidMIName + "' not found."
        Assert-ThrowsContains { Move-AzSqlInstanceDnsAlias -DestResourceGroupName $rgName -DestInstanceName $invalidMIName -SourceResourceGroupName $rgName -SourceInstanceName $managedInstanceName -SourceName $testAliasName}$msgExcNotFoundParent

        #Assert confirmation message
        $removeConfirmationMessage = "Are you sure you want to remove the instance DNS alias named '"+$testAliasName+"' from managed instance '"+$managedInstanceName+"' located in resource group '"+$rgName+"'?"
        Assert-ThrowsContains { Remove-AzSqlInstanceDnsAlias -ResourceGroupName $rgName -InstanceName $managedInstanceName -Name $testAliasName }

        #Remove non existant resource
        Assert-ThrowsContains { Remove-AzSqlInstanceDnsAlias -ResourceGroupName $rgName -InstanceName $managedInstanceName -Name $testAliasName -Force} $msgExcNotFound
    }
    finally
    {
        Remove-ResourceGroupForTest $rg
    }
}