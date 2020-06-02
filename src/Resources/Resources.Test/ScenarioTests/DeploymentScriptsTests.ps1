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
Tests deployment scripts Get operations with different parameter sets for PowerShell
#>
function Test-GetDeploymentScript-PowerShell
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"
	$subId = (Get-AzContext).Subscription.SubscriptionId

	try
	{
		# Prepare 
		New-AzResourceGroup -Name $rgname -Location $rglocation

		$deployment = New-AzResourceGroupDeployment -Name $rname -ResourceGroupName $rgname -TemplateFile TemplateScriptDeployment.json -TemplateParameterFile TemplateScriptDeploymentParameters.json
		$deploymentScriptName = "PsTest-DeploymentScripts-" + $deployment.parameters.scriptSuffix.Value
		$resourceId = "/subscriptions/$subId/resourcegroups/$rgname/providers/Microsoft.Resources/deploymentScripts/$deploymentScriptName"

		# Test - GetByNameAndResourceGroup
		$getByNameAndResourceGroup = Get-AzDeploymentScript -ResourceGroupName $rgname -Name $deploymentScriptName 

		# Assert
		Assert-NotNull $getByNameAndResourceGroup
		Assert-AreEqual $deploymentScriptName $getByNameAndResourceGroup.Name
		Assert-AreEqual $rgname $getByNameAndResourceGroup.ResourceGroupName

		# Test - GetByResourceId
		$getByResourceId = Get-AzDeploymentScript -Id $resourceId

		#Assert
		Assert-NotNull $getByResourceId
		Assert-AreEqual $deploymentScriptName $getByResourceId.Name

		#Test - ListByResourceGroupName
		$listByResourceGroup = Get-AzDeploymentScript -ResourceGroupName $rgname

		# Assert
		Assert-AreNotEqual 0 $listByResourceGroup.Count
		Assert-True { $listByResourceGroup.name.contains($deploymentScriptName) }
	}
	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests deployment scripts Get operations with different parameter sets for Cli.
#>
function Test-GetDeploymentScript-Cli
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"
	$subId = (Get-AzContext).Subscription.SubscriptionId
	
	try
	{
		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation

		$deployment = New-AzResourceGroupDeployment -Name $rname -ResourceGroupName $rgname -TemplateFile TemplateScriptDeploymentCli.json -TemplateParameterFile TemplateScriptDeploymentParametersCli.json
		$deploymentScriptName = "PsTest-DeploymentScripts-" + $deployment.parameters.scriptSuffix.Value
		$resourceId = "/subscriptions/$subId/resourcegroups/$rgname/providers/Microsoft.Resources/deploymentScripts/$deploymentScriptName"

		# Test - GetByNameAndResourceGroup
		$getByNameAndResourceGroup = Get-AzDeploymentScript -ResourceGroupName $rgname -Name $deploymentScriptName 

		# Assert
		Assert-NotNull $getByNameAndResourceGroup
		Assert-AreEqual $deploymentScriptName $getByNameAndResourceGroup.Name
		Assert-AreEqual $rgname $getByNameAndResourceGroup.ResourceGroupName

		# Test - GetByResourceId
		$getByResourceId = Get-AzDeploymentScript -Id $resourceId

		#Assert
		Assert-NotNull $getByResourceId
		Assert-AreEqual $deploymentScriptName $getByResourceId.Name

		#Test - ListByResourceGroupName
		$listByResourceGroup = Get-AzDeploymentScript -ResourceGroupName $rgname

		# Assert
		Assert-AreNotEqual 0 $listByResourceGroup.Count
		Assert-True { $listByResourceGroup.name.contains($deploymentScriptName) }
	}
	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests deployment scripts Get operation with a script that will error out.
#>
function Test-GetDeploymentScriptWithBadScript
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"
	
	try
	{
		# Prepare		
		New-AzResourceGroup -Name $rgname -Location $rglocation
		$exceptionMessage = "bad: command not found. Please refer to https://aka.ms/DeploymentScriptsTroubleshoot for more deployment script information."
		Assert-ThrowsContains { New-AzResourceGroupDeployment -Name $rname -ResourceGroupName $rgname -TemplateFile TemplateScriptDeploymentCli.json -TemplateParameterFile TemplateScriptDeploymentParametersCliBadScript.json } $exceptionMessage	
	
		#$deployment = New-AzResourceGroupDeployment -Name $rname -ResourceGroupName $rgname -TemplateFile TemplateScriptDeploymentCli.json -TemplateParameterFile TemplateScriptDeploymentParametersCliBadScript.json
		$deployment = Get-AzResourceGroupDeployment -ResourceGroupName $rgname 
		$deploymentScriptName = "PsTest-DeploymentScripts-" + $deployment.parameters.scriptSuffix.Value

		# Test
		$deploymentScript = Get-AzDeploymentScript -ResourceGroupName $rgname -Name $deploymentScriptName 

		# Assert
		Assert-NotNull $deploymentScript
		Assert-AreEqual $deploymentScriptName $deploymentScript.Name
		Assert-AreEqual $rgname $deploymentScript.ResourceGroupName
		Assert-NotNull $deploymentScript.Status.Error 

	}
	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests deployment scripts Get operation that all properties show in the result.
#>
function Test-GetAllDeploymentScriptPropertiesCli
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"
	
	try 
	{
		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation

		$deployment = New-AzResourceGroupDeployment -Name $rname -ResourceGroupName $rgname -TemplateFile TemplateScriptDeploymentCli.json -TemplateParameterFile TemplateScriptDeploymentParametersCli.json
		$deploymentScriptName = "PsTest-DeploymentScripts-" + $deployment.parameters.scriptSuffix.Value

		# Test
		$deploymentScript = Get-AzDeploymentScript -ResourceGroupName $rgname -Name $deploymentScriptName 

		# Assert
		Assert-NotNull $deploymentScript
		Assert-AreEqual $deploymentScriptName $deploymentScript.Name
		Assert-AreEqual "westus2" $deploymentScript.Location
		Assert-AreEqual "AzureCLI" $deploymentScript.ScriptKind
		Assert-True  { $deploymentScript.Identity.UserAssignedIdentities.Keys.contains("/subscriptions/a1bfa635-f2bf-42f1-86b5-848c674fc321/resourceGroups/Ds-TestRg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/filiz-user-assigned-msi") }
		Assert-AreEqual "2.0.80" $deploymentScript.AzCliVersion
		Assert-AreEqual "OnExpiration" $deploymentScript.CleanupPreference		
		Assert-AreEqual "P1D" $deploymentScript.retentionInterval
		Assert-AreEqual "PT30M" $deploymentScript.timeout
		Assert-AreEqual "Succeeded" $deploymentScript.ProvisioningState
		Assert-NotNull $deploymentScript.Status
		Assert-NotNull $deploymentScript.Status.ContainerInstanceId
		Assert-NotNull $deploymentScript.Status.StorageAccountId
		Assert-NotNull $deploymentScript.Status.StartTime
		Assert-NotNull $deploymentScript.Status.EndTime
		Assert-NotNull $deploymentScript.Status.ExpirationTime
		Assert-AreNotEqual 0 $deploymentScript.Outputs.Count
		Assert-AreEqual $null $deploymentScript.primaryScriptUri
		Assert-AreEqual 0 $deploymentScript.supportingScriptUris.Count
		Assert-NotNull $deploymentScript.ScriptContent
		Assert-NotNull $deploymentScript.arguments
		Assert-AreEqual 0 $deploymentScript.environmentVariables.Count
		Assert-AreEqual $null $deploymentScript.forceUpdateTag
	}
	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests deployment scripts Get logs operation with different parameter sets for PowerShell.
#>
function Test-GetDeploymentScriptLog-PowerShell
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"
	$subId = (Get-AzContext).Subscription.SubscriptionId

	try 
	{
		#Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation

		$deployment = New-AzResourceGroupDeployment -Name $rname -ResourceGroupName $rgname -TemplateFile TemplateScriptDeployment.json -TemplateParameterFile TemplateScriptDeploymentParameters.json
		$deploymentScriptName = "PsTest-DeploymentScripts-" + $deployment.parameters.scriptSuffix.Value		
		$resourceId = "/subscriptions/$subId/resourcegroups/$rgname/providers/Microsoft.Resources/deploymentScripts/$deploymentScriptName"
		$tailInteger = 5

		# Test - GetLogByNameAndResourceGroup
		$getLogByNameAndResourceGroup = Get-AzDeploymentScriptLog -ResourceGroupName $rgname -Name $deploymentScriptName 

		# Assert
		Assert-NotNull $getLogByNameAndResourceGroup
		Assert-NotNull $deploymentScriptName $getLogByNameAndResourceGroup.Log
		Assert-AreEqual $deploymentScriptName $getLogByNameAndResourceGroup.DeploymentScriptName


		# Test - GetLogByNameAndResourceGroup - WithTailParameter
		$getLogByNameAndResourceGroupWithTail = Get-AzDeploymentScriptLog -ResourceGroupName $rgname -Name $deploymentScriptName -Tail $tailInteger
		$tail = [math]::min( ($getLogByNameAndResourceGroup.Log -split '\n').count, $tailInteger)

		# Assert
		Assert-NotNull $getLogByNameAndResourceGroupWithTail
		Assert-NotNull $deploymentScriptName $getLogByNameAndResourceGroupWithTail.Log
		Assert-AreEqual $deploymentScriptName $getLogByNameAndResourceGroupWithTail.DeploymentScriptName
		Assert-AreEqual ($getLogByNameAndResourceGroupWithTail.Log -split '\n').count $tail


		# Test - GetLogByDeploymentScriptResourceId
		$getLogByResourceId = Get-AzDeploymentScriptLog -DeploymentScriptResourceId $resourceId

		#Assert
		Assert-NotNull $getLogByResourceId
		Assert-NotNull $deploymentScriptName $getLogByResourceId.Log
		Assert-AreEqual $deploymentScriptName $getLogByResourceId.DeploymentScriptName

		# Test - GetLogByDeploymentScriptResourceId - WithTailParameter
		$getLogByResourceIdWithTail = Get-AzDeploymentScriptLog -DeploymentScriptResourceId $resourceId -Tail $tailInteger
		$tail = [math]::min( ($getLogByResourceId.Log -split '\n').count, $tailInteger)

		#Assert
		Assert-NotNull $getLogByResourceIdWithTail
		Assert-NotNull $deploymentScriptName $getLogByResourceIdWithTail.Log
		Assert-AreEqual $deploymentScriptName $getLogByResourceIdWithTail.DeploymentScriptName
		Assert-AreEqual ($getLogByResourceIdWithTail.Log -split '\n').count $tail
	

		#Test - GetLogByInputObject
		$deploymentScript = Get-AzDeploymentScript -ResourceGroupName $rgname -Name $deploymentScriptName 
		$getLogByInputObject = Get-AzDeploymentScriptLog -DeploymentScriptObject $deploymentScript

		# Assert
		Assert-NotNull $getLogByInputObject
		Assert-NotNull $deploymentScriptName $getLogByInputObject.Log
		Assert-AreEqual $deploymentScriptName $getLogByInputObject.DeploymentScriptName

		#Test - GetLogByInputObject - WithTailParameter
		$deploymentScript = Get-AzDeploymentScript -ResourceGroupName $rgname -Name $deploymentScriptName 
		$getLogByInputObjectWithTail = Get-AzDeploymentScriptLog -DeploymentScriptObject $deploymentScript -Tail $tailInteger
		$tail = [math]::min( ($getLogByInputObject.Log -split '\n').count, $tailInteger)

		# Assert
		Assert-NotNull $getLogByInputObjectWithTail
		Assert-NotNull $deploymentScriptName $getLogByInputObjectWithTail.Log
		Assert-AreEqual $deploymentScriptName $getLogByInputObjectWithTail.DeploymentScriptName
		Assert-AreEqual ($getLogByResourceIdWithTail.Log -split '\n').count $tail
	}
	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests deployment scripts Get logs operation with different parameter sets for Cli.
#>
function Test-GetDeploymentScriptLog-Cli
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"
	$subId = (Get-AzContext).Subscription.SubscriptionId

	try
	{
		# Prepare 
		New-AzResourceGroup -Name $rgname -Location $rglocation

		$deployment = New-AzResourceGroupDeployment -Name $rname -ResourceGroupName $rgname -TemplateFile TemplateScriptDeploymentCli.json -TemplateParameterFile TemplateScriptDeploymentParametersCli.json
		$deploymentScriptName = "PsTest-DeploymentScripts-" + $deployment.parameters.scriptSuffix.Value		
		$resourceId = "/subscriptions/$subId/resourcegroups/$rgname/providers/Microsoft.Resources/deploymentScripts/$deploymentScriptName"
		$tailInteger = 2

		# Test - GetLogByNameAndResourceGroup
		$getLogByNameAndResourceGroup = Get-AzDeploymentScriptLog -ResourceGroupName $rgname -Name $deploymentScriptName

		# Assert
		Assert-NotNull $getLogByNameAndResourceGroup
		Assert-NotNull $deploymentScriptName $getLogByNameAndResourceGroup.Log
		Assert-AreEqual $deploymentScriptName $getLogByNameAndResourceGroup.DeploymentScriptName

		# Test - GetLogByNameAndResourceGroup - WithTailParameter
		$getLogByNameAndResourceGroupWithTail = Get-AzDeploymentScriptLog -ResourceGroupName $rgname -Name $deploymentScriptName  -Tail $tailInteger
		
		#\r is used in the template deployment script to denote line breaks in the CLI log output
		$tail = [math]::min( ($getLogByNameAndResourceGroup.Log -split '\r').count, $tailInteger)

		# Assert
		Assert-NotNull $getLogByNameAndResourceGroupWithTail
		Assert-NotNull $deploymentScriptName $getLogByNameAndResourceGroupWithTail.Log
		Assert-AreEqual $deploymentScriptName $getLogByNameAndResourceGroupWithTail.DeploymentScriptName

		#Counting \n instead of \r as every instance of \r is replaced with \n when the backend processes the Tail parameter.
		Assert-AreEqual ($getLogByNameAndResourceGroupWithTail.Log -split '\n').count $tail

		# Test - GetLogByDeploymentScriptResourceId
		$getLogByResourceId = Get-AzDeploymentScriptLog -DeploymentScriptResourceId $resourceId

		#Assert
		Assert-NotNull $getLogByResourceId
		Assert-NotNull $deploymentScriptName $getLogByResourceId.Log
		Assert-AreEqual $deploymentScriptName $getLogByResourceId.DeploymentScriptName


		# Test - GetLogByDeploymentScriptResourceId - WithTailParameter
		$getLogByResourceIdWithTail = Get-AzDeploymentScriptLog -DeploymentScriptResourceId $resourceId -Tail $tailInteger
		$tail = [math]::min( ($getLogByResourceId.Log -split '\r').count, $tailInteger)

		#Assert
		Assert-NotNull $getLogByResourceIdWithTail
		Assert-NotNull $deploymentScriptName $getLogByResourceIdWithTail.Log
		Assert-AreEqual $deploymentScriptName $getLogByResourceIdWithTail.DeploymentScriptName
		Assert-AreEqual ($getLogByResourceIdWithTail.Log -split '\n').count $tail


		#Test - GetLogByInputObject
		$deploymentScript = Get-AzDeploymentScript -ResourceGroupName $rgname -Name $deploymentScriptName 
		$getLogByInputObject = Get-AzDeploymentScriptLog -DeploymentScriptObject $deploymentScript

		# Assert
		Assert-NotNull $getLogByInputObject
		Assert-NotNull $deploymentScriptName $getLogByInputObject.Log
		Assert-AreEqual $deploymentScriptName $getLogByInputObject.DeploymentScriptName


		#Test - GetLogByInputObject - WithTailParameter
		$deploymentScript = Get-AzDeploymentScript -ResourceGroupName $rgname -Name $deploymentScriptName 
		$getLogByInputObjectWithTail = Get-AzDeploymentScriptLog -DeploymentScriptObject $deploymentScript -Tail $tailInteger
		$tail = [math]::min( ($getLogByResourceId.Log -split '\r').count, $tailInteger)

		# Assert
		Assert-NotNull $getLogByInputObjectWithTail
		Assert-NotNull $deploymentScriptName $getLogByInputObjectWithTail.Log
		Assert-AreEqual $deploymentScriptName $getLogByInputObjectWithTail.DeploymentScriptName
		Assert-AreEqual ($getLogByInputObjectWithTail.Log -split '\n').count $tail
	}
	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests deployment scripts Get logs operation with piped deployment script object.
#>
function Test-PipeDeploymentScriptObjectToGetLogs
{
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"
	$tailInteger = 2

	try
	{
		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation

		$deployment = New-AzResourceGroupDeployment -Name $rname -ResourceGroupName $rgname -TemplateFile TemplateScriptDeploymentCli.json -TemplateParameterFile TemplateScriptDeploymentParametersCli.json
		$suffix = $deployment.parameters.scriptSuffix.Value
		$deploymentScriptName = "PsTest-DeploymentScripts-" + $suffix

		#Test - GetLogsByInputObjectPiped 
		$getLogByInputObject = Get-AzDeploymentScript -ResourceGroupName $rgname -Name $deploymentScriptName | Get-AzDeploymentScriptLog 

		# Assert
		Assert-NotNull $getLogByInputObject
		Assert-NotNull $deploymentScriptName $getLogByInputObject.Log
		Assert-AreEqual $deploymentScriptName $getLogByInputObject.DeploymentScriptName


		#Test - GetLogsByInputObjectPiped - WithTailParameter
		$getLogByInputObjectWithTail = Get-AzDeploymentScript -ResourceGroupName $rgname -Name $deploymentScriptName | Get-AzDeploymentScriptLog -Tail $tailInteger
		$tail = [math]::min( ($getLogByInputObject.Log -split '\r').count, $tailInteger)

		# Assert
		Assert-NotNull $getLogByInputObjectWithTail
		Assert-NotNull $deploymentScriptName $getLogByInputObjectWithTail.Log
		Assert-AreEqual $deploymentScriptName $getLogByInputObjectWithTail.DeploymentScriptName
		Assert-AreEqual ($getLogByInputObjectWithTail.Log -split '\n').count $tail
	}
	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests deployment scripts Get logs operation with not existing file path.
#>
function Test-TrySaveNonExistingFilePathForLogFile
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"	
	$badPath = "bad-path"
	$tailInteger = 3

	try 
	{
		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation

		$deployment = New-AzResourceGroupDeployment -Name $rname -ResourceGroupName $rgname -TemplateFile TemplateScriptDeployment.json -TemplateParameterFile TemplateScriptDeploymentParameters.json
		$deploymentScriptName = "PsTest-DeploymentScripts-" + $deployment.parameters.scriptSuffix.Value

		$deploymentScript = Get-AzDeploymentScript -ResourceGroupName $rgname -Name $deploymentScriptName 

		# Assert
		Assert-NotNull $deploymentScript
		Assert-NotNull $deploymentScriptName $deploymentScript.Log
		Assert-AreEqual $deploymentScriptName $deploymentScript.Name

		# Test & Assert exception is thrown
		$path = (Get-Item ".\").FullName
        $fullPath = Join-Path $path $badPath
        $exceptionMessage = "Cannot find path '$fullPath'"
        Assert-Throws { Save-AzDeploymentScriptLog -DeploymentScriptObject $deploymentScript -OutputPath $badPath } $exceptionMessage
		Assert-Throws { Save-AzDeploymentScriptLog -DeploymentScriptObject $deploymentScript -OutputPath $badPath -Tail $tailInteger} $exceptionMessage	
	}
	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests deployment scripts Delete operation for PowerShell.
#>
function Test-RemoveDeploymentScript-PowerShell
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"
		
	try
	{
		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation

		$deployment = New-AzResourceGroupDeployment -Name $rname -ResourceGroupName $rgname -TemplateFile TemplateScriptDeployment.json -TemplateParameterFile TemplateScriptDeploymentParameters.json
		$deploymentScriptName = "PsTest-DeploymentScripts-" + $deployment.parameters.scriptSuffix.Value				

		$deploymentScript = Get-AzDeploymentScript -ResourceGroupName $rgname -Name $deploymentScriptName 

		# Assert
		Assert-NotNull $deploymentScript
		Assert-AreEqual $deploymentScriptName $deploymentScript.Name
		Assert-AreEqual $rgname $deploymentScript.ResourceGroupName

		# Test
		$result = Remove-AzDeploymentScript -ResourceGroupName $rgname -name $deploymentScriptName -PassThru

		# Assert
		Assert-True { $result }
	}
	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests deployment scripts Delete operation for Cli.
#>
function Test-RemoveDeploymentScript-Cli
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"

	try
	{
		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation

		$deployment = New-AzResourceGroupDeployment -Name $rname -ResourceGroupName $rgname -TemplateFile TemplateScriptDeploymentCli.json -TemplateParameterFile TemplateScriptDeploymentParametersCli.json
		$deploymentScriptName = "PsTest-DeploymentScripts-" + $deployment.parameters.scriptSuffix.Value		
		
		$deploymentScript = Get-AzDeploymentScript -ResourceGroupName $rgname -Name $deploymentScriptName 

		# Assert
		Assert-NotNull $deploymentScript
		Assert-AreEqual $deploymentScriptName $deploymentScript.Name
		Assert-AreEqual $rgname $deploymentScript.ResourceGroupName

		$result = Remove-AzDeploymentScript -InputObject $deploymentScript -PassThru

		# Assert
		Assert-True { $result }
	}
	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests deployment scripts Delete operation for not existing deployment script.
#>
function Test-TryRemoveNonExistingDeploymentScript
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"
	$subId = (Get-AzContext).Subscription.SubscriptionId
	$badResourceId = "/subscriptions/$subId/resourcegroups/$rgname/providers/Microsoft.Resources/deploymentScripts/this-doesnt-exist"
	$message = "Deployment script 'this-doesnt-exist' doesn't exist in resource group '$rgname'."

	try
	{
		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation

		# Test & Assert
		Assert-Throws { Remove-AzDeploymentScript -Id $badResourceId } $message
	}
	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests deployment scripts Delete operation for piped deployment script object.
#>
<#
.SYNOPSIS
Tests deployment scripts Delete operation for Cli.
#>
function Test-RemovePipedDeploymentScriptObject
{
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"

	try
	{
		# Prepare
		New-AzResourceGroup -Name $rgname -Location $rglocation

		$deployment = New-AzResourceGroupDeployment -Name $rname -ResourceGroupName $rgname -TemplateFile TemplateScriptDeploymentCli.json -TemplateParameterFile TemplateScriptDeploymentParametersCli.json
		$suffix = $deployment.parameters.scriptSuffix.Value
		$deploymentScriptName = "PsTest-DeploymentScripts-" + $suffix

		#Test - RemovePipedDeploymentScript
		$result = Get-AzDeploymentScript -ResourceGroupName $rgname -Name $deploymentScriptName | Remove-AzDeploymentScript -PassThru

		# Assert
		Assert-True { $result }
	}
	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

