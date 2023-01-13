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
Converts an object to a Hashtable.
#>
function ConvertTo-Hashtable {
	[CmdletBinding()]
	[OutputType('hashtable')]
	param (
		[Parameter(ValueFromPipeline)]
		$InputObject
	)
 
	process {
		if ($null -eq $InputObject) {
			return $null
		}
 
		if ($InputObject -is [System.Collections.IEnumerable] -and $InputObject -isnot [string]) {
			$collection = @(
				foreach ($object in $InputObject) {
					ConvertTo-Hashtable -InputObject $object
				}
			)
 
			Write-Output -NoEnumerate $collection
		}
		elseif ($InputObject -is [psobject]) {
			$hashtable = @{}

			foreach ($property in $InputObject.PSObject.Properties) {
				$hashtable[$property.Name] = ConvertTo-Hashtable -InputObject $property.Value
			}

			$hashtable
		}
		else {
			$InputObject
		}
	}
}

<#
.SYNOPSIS
Tests deployment template validation.
#>
function Test-ValidateDeployment
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$location = "West US 2"

	# Test
	New-AzResourceGroup -Name $rgname -Location $location

	$list = Test-AzResourceGroupDeployment -ResourceGroupName $rgname -TemplateFile Build2014_Website_App.json -siteName $rname -hostingPlanName $rname -siteLocation $location -sku Free -workerSize 0

	# Assert
	Assert-AreEqual 0 @($list).Count
}

<#
.SYNOPSIS
Tests deployment via template file and parameter object.
#>
function Test-NewDeploymentFromTemplateFile
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"
	$expectedTags = @{"key1"="value1"; "key2"="value2";}

	try
	{
		# Test
		New-AzResourceGroup -Name $rgname -Location $rglocation

		$deployment = New-AzResourceGroupDeployment -Name $rname -ResourceGroupName $rgname -TemplateFile sampleDeploymentTemplate.json -TemplateParameterFile sampleDeploymentTemplateParams.json -Tag $expectedTags

		# Assert
		Assert-AreEqual Succeeded $deployment.ProvisioningState
		Assert-True { AreHashtableEqual $expectedTags $deployment.Tags }

		$subId = (Get-AzContext).Subscription.SubscriptionId
		$deploymentId = "/subscriptions/$subId/resourcegroups/$rgname/providers/Microsoft.Resources/deployments/$rname"
		$getById = Get-AzResourceGroupDeployment -Id $deploymentId
		Assert-AreEqual $getById.DeploymentName $deployment.DeploymentName

		[hashtable]$actualTags = $getById.Tags
		Assert-True { AreHashtableEqual $expectedTags $getById.Tags }
	}

	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Test-NewDeploymentFromTemplateSpec
{
	# Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $rglocation = "West US 2"
    $subId = (Get-AzContext).Subscription.SubscriptionId

	try
	{
		# Prepare our RG and basic template spec:

        New-AzResourceGroup -Name $rgname -Location $rglocation

        $sampleTemplateJson = Get-Content -Raw -Path "sampleTemplate.json"
        $basicCreatedTemplateSpec = New-AzTemplateSpec -ResourceGroupName $rgname -Name $rname -Location $rgLocation -Version "v1" -TemplateJson $sampleTemplateJson

		$resourceId = $basicCreatedTemplateSpec.Id + "/versions/v1"

		#Create deployment
		$deployment = New-AzResourceGroupDeployment -Name $rname -ResourceGroupName $rgname -TemplateSpecId $resourceId -TemplateParameterFile "sampleTemplateParams.json"

		# Assert
		Assert-AreEqual Succeeded $deployment.ProvisioningState

	}

	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Test-NewSubscriptionDeploymentFromTemplateSpec
{
	# Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $rglocation = "West US 2"
    $subId = (Get-AzContext).Subscription.SubscriptionId

	try
	{
		# Prepare our RG and basic template spec:

		New-AzResourceGroup -Name $rgname -Location $rglocation

        $sampleTemplateJson = Get-Content -Raw -Path "subscription_level_template.json"
        $basicCreatedTemplateSpec = New-AzTemplateSpec -ResourceGroupName $rgname -Name $rname -Location $rgLocation -Version "v1" -TemplateJson $sampleTemplateJson

		$resourceId = $basicCreatedTemplateSpec.Id + "/versions/v1"

		#Create deployment
		$deployment = New-AzSubscriptionDeployment -Name $rname -TemplateSpecId $resourceId -TemplateParameterFile "subscription_level_parameters.json" -Location $rglocation

		# Assert
		Assert-AreEqual Succeeded $deployment.ProvisioningState

	}

	finally
    {
        # Cleanup
		Clean-DeploymentAtSubscription $deployment
		Clean-ResourceGroup $rgname
    }
}

function Test-NewFailedSubscriptionDeploymentFromTemplateSpec
{
	# Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $rglocation = "West US 2"
    $subId = (Get-AzContext).Subscription.SubscriptionId

	try
	{
		# Prepare our RG and basic template spec:

		New-AzResourceGroup -Name $rgname -Location $rglocation

		#Use template that will fail at subscription scope
        $sampleTemplateJson = Get-Content -Raw -Path "subscription_level_template.json"
        $basicCreatedTemplateSpec = New-AzTemplateSpec -ResourceGroupName $rgname -Name $rname -Location $rgLocation -Version "v1" -TemplateJson $sampleTemplateJson

		$resourceId = $basicCreatedTemplateSpec.Id + "/versions/v2"

		#Create deployment
		try {
			$deployment = New-AzSubscriptionDeployment -Name $rname -TemplateSpecId $resourceId -TemplateParameterFile "subscription_level_parameters.json" -Location $rglocation
		}
		Catch {
			 Assert-true { $Error[0].exception.message.Contains("InvalidTemplateSpec") }
		}

	}

	finally
    {
        # Cleanup
		Clean-DeploymentAtSubscription $deployment
		Clean-ResourceGroup $rgname
    }
}

function Test-NewMGDeploymentFromTemplateSpec
{
	# Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
	$managementGroupId = Get-ResourceName
    $rglocation = "West US 2"
    $subId = (Get-AzContext).Subscription.SubscriptionId

	try
	{
		#Create New MG
		New-AzManagementGroup -GroupName $managementGroupId -ParentId "/providers/Microsoft.Management/managementGroups/AzDeploymentsPSTest"

		# Prepare our RG and basic template spec:

		New-AzResourceGroup -Name $rgname -Location $rglocation

        $sampleTemplateJson = Get-Content -Raw -Path "simpleTemplate.json"
        $basicCreatedTemplateSpec = New-AzTemplateSpec -ResourceGroupName $rgname -Name $rname -Location $rgLocation -Version "v1" -TemplateJson $sampleTemplateJson

		$resourceId = $basicCreatedTemplateSpec.Id + "/versions/v1"

		#Create deployment
		$deployment = New-AzManagementGroupDeployment -ManagementGroupId $managementGroupId -Name $rname -TemplateSpecId $resourceId -TemplateParameterFile "simpleTemplateParams.json" -Location $rglocation

		# Assert
		Assert-AreEqual Succeeded $deployment.ProvisioningState

	}

	finally
    {
        # Cleanup
		Remove-AzManagementGroupDeployment -ManagementGroup $managementGroupId -Name $rname
		Clean-ResourceGroup $rgname
		Remove-AzManagementGroup -GroupName $managementGroupId
    }
}

function Test-NewTenantDeploymentFromTemplateSpec
{
	# Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $rglocation = "West US 2"
    $subId = (Get-AzContext).Subscription.SubscriptionId

	try
	{
		# Prepare our RG and basic template spec:

		New-AzResourceGroup -Name $rgname -Location $rglocation

        $sampleTemplateJson = Get-Content -Raw -Path "simpleTemplate.json"
        $basicCreatedTemplateSpec = New-AzTemplateSpec -ResourceGroupName $rgname -Name $rname -Location $rgLocation -Version "v1" -TemplateJson $sampleTemplateJson

		$resourceId = $basicCreatedTemplateSpec.Id + "/versions/v1"

		#Create deployment
		$deployment = New-AzTenantDeployment -Name $rname -TemplateSpecId $resourceId -TemplateParameterFile "simpleTemplateParams.json" -Location $rglocation

		# Assert
		Assert-AreEqual Succeeded $deployment.ProvisioningState

	}

	finally
    {
        # Cleanup
		Clean-ResourceGroup $rgname
		Remove-AzTenantDeployment -Name $rname
		Clean-DeploymentAtTenant $rname
    }
}

function Test-NewDeploymentFromTemplateObject
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $rglocation = "West US 2"

    try
    {
        # Test
        New-AzResourceGroup -Name $rgname -Location $rglocation

        $path = (Get-Item ".\").FullName
        $file = Join-Path $path "sampleDeploymentTemplate.json"
		$templateObject = ConvertFrom-Json ([System.IO.File]::ReadAllText($file)) | ConvertTo-Hashtable
        $deployment = New-AzResourceGroupDeployment -Name $rname -ResourceGroupName $rgname -TemplateObject $templateObject -TemplateParameterFile sampleDeploymentTemplateParams.json 
		
        # Assert
        Assert-AreEqual Succeeded $deployment.ProvisioningState

		$subId = (Get-AzContext).Subscription.SubscriptionId
		$deploymentId = "/subscriptions/$subId/resourcegroups/$rgname/providers/Microsoft.Resources/deployments/$rname"
		$getById = Get-AzResourceGroupDeployment -Id $deploymentId
		Assert-AreEqual $getById.DeploymentName $deployment.DeploymentName
	}

	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Test-TestResourceGroupDeploymentErrors
{
    # Catch exception when resource group doesn't exist
    $rgname = "unknownresourcegroup"
    $deploymentName = Get-ResourceName
    $result = Test-AzResourceGroupDeploymentWithName -DeploymentName $deploymentName -ResourceGroupName $rgname -TemplateFile sampleDeploymentTemplate.json -TemplateParameterFile sampleDeploymentTemplateParams.json
    Write-Debug "$result"
    Assert-NotNull $result
    Assert-AreEqual "ResourceGroupNotFound" $result.Code
    Assert-AreEqual "Resource group '$rgname' could not be found." $result.Message

    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $rglocation = "West US 2"

    try
    {
        # Test
        # Catch exception when parameter template is missing
        New-AzResourceGroup -Name $rgname -Location $rglocation
        $result = Test-AzResourceGroupDeploymentWithName -DeploymentName $deploymentName -ResourceGroupName $rgname -TemplateFile sampleDeploymentTemplate.json -SkipTemplateParameterPrompt
        Assert-NotNull $result
        Assert-AreEqual "InvalidTemplate" $result.Code
        Assert-StartsWith "Deployment template validation failed" $result.Message
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests cross resource group deployment via template file.
.DESCRIPTION
Smoke[Broken]Test
#>
function Test-CrossResourceGroupDeploymentFromTemplateFile
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rgname2 = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"
	$expectedTags = @{"key1"="value1"; "key2"="value2";}

	try
	{
		# Test
		New-AzResourceGroup -Name $rgname -Location $rglocation
		New-AzResourceGroup -Name $rgname2 -Location $rglocation

		$parameters = @{ "NestedDeploymentResourceGroup" = $rgname2 }
		$deployment = New-AzResourceGroupDeployment -Name $rname -ResourceGroupName $rgname -TemplateFile sampleTemplateWithCrossResourceGroupDeployment.json -TemplateParameterObject $parameters -Tag $expectedTags

		# Assert
		Assert-AreEqual Succeeded $deployment.ProvisioningState
		Assert-True { AreHashtableEqual $expectedTags $deployment.Tags }

		$subId = (Get-AzContext).Subscription.SubscriptionId
		$deploymentId = "/subscriptions/$subId/resourcegroups/$rgname/providers/Microsoft.Resources/deployments/$rname"
		$getById = Get-AzResourceGroupDeployment -Id $deploymentId
		Assert-AreEqual $getById.DeploymentName $deployment.DeploymentName
		Assert-True { AreHashtableEqual $expectedTags $getById.Tags }

		$nestedDeploymentId = "/subscriptions/$subId/resourcegroups/$rgname2/providers/Microsoft.Resources/deployments/nestedTemplate"
		$nestedDeployment = Get-AzResourceGroupDeployment -Id $nestedDeploymentId
		Assert-AreEqual Succeeded $nestedDeployment.ProvisioningState
	}

	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests nested errors displayed when temployment put fails.
#>
function Test-NestedErrorsDisplayed
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "CentralUSEUAP"

	try
	{
		# Test
		$ErrorActionPreference = "SilentlyContinue"
		$Error.Clear()
		New-AzResourceGroup -Name $rgname -Location $rglocation
		New-AzResourceGroupDeployment -Name $rname -ResourceGroupName $rgname -TemplateFile sampleTemplateThrowsNestedErrors.json
	}
	catch
	{
		Assert-True { $Error[1].Contains("Storage account name must be between 3 and 24 characters in length") }
	}
	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests nested deployment.
.DESCRIPTION
Smoke[Broken]Test
#>
function Test-NestedDeploymentFromTemplateFile
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"
	$expectedTags = @{"key1"="value1"; "key2"="value2";}

	try
	{
		# Test
		New-AzResourceGroup -Name $rgname -Location $rglocation

		$deployment = New-AzResourceGroupDeployment -Name $rname -ResourceGroupName $rgname -TemplateFile sampleNestedTemplate.json -TemplateParameterFile sampleNestedTemplateParams.json -Tag $expectedTags

		# Assert
		Assert-AreEqual Succeeded $deployment.ProvisioningState
		Assert-True { AreHashtableEqual $expectedTags $deployment.Tags }

		$subId = (Get-AzContext).Subscription.SubscriptionId
		$deploymentId = "/subscriptions/$subId/resourcegroups/$rgname/providers/Microsoft.Resources/deployments/$rname"
		$getById = Get-AzResourceGroupDeployment -Id $deploymentId
		Assert-AreEqual $getById.DeploymentName $deployment.DeploymentName
	}

	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests save deployment template file.
.DESCRIPTION
Smoke[Broken]Test
#>
function Test-SaveDeploymentTemplateFile
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"

	try
	{
		# Test
		New-AzResourceGroup -Name $rgname -Location $rglocation

		$deployment = New-AzResourceGroupDeployment -Name $rname -ResourceGroupName $rgname -TemplateFile sampleDeploymentTemplate.json -TemplateParameterFile sampleDeploymentTemplateParams.json

		# Assert
		Assert-AreEqual Succeeded $deployment.ProvisioningState

		$saveOutput = Save-AzResourceGroupDeploymentTemplate -ResourceGroupName $rgname -DeploymentName $rname -Force
		Assert-NotNull $saveOutput
		Assert-True { $saveOutput.Path.Contains($rname + ".json") }
	}

	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests deployment via template file and parameter file with KeyVault reference.
#>
function Test-NewDeploymentWithKeyVaultReference
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$keyVaultname = Get-ResourceName
	$secretName = Get-ResourceName
	$rglocation = "CentralUSEUAP"
	$location = Get-ProviderLocation "Microsoft.Web/sites"
	$hostplanName = "xDeploymentTestHost26668"

	try
	{
		# Test
		New-AzResourceGroup -Name $rgname -Location $rglocation

		$context = Get-AzContext
		$subscriptionId = $context.Subscription.SubscriptionId
		$tenantId = $context.Tenant.TenantId
		$adUser = Get-AzADUser -UserPrincipalName $context.Account.Id
		$objectId = $adUser.Id
		$KeyVaultResourceId = "/subscriptions/" + $subscriptionId + "/resourcegroups/" + $rgname + "/providers/Microsoft.KeyVault/vaults/" + $keyVaultname

		$parameters = @{ "keyVaultName" = $keyVaultname; "secretName" = $secretName; "secretValue" = $hostplanName; "tenantId" = $tenantId; "objectId" = $objectId }
		$deployment = New-AzResourceGroupDeployment -Name $rname -ResourceGroupName $rgname -TemplateFile keyVaultSetupTemplate.json -TemplateParameterObject $parameters

		# Assert
		Assert-AreEqual Succeeded $deployment.ProvisioningState

		$content = (Get-Content keyVaultTemplateParams.json) -join '' | ConvertFrom-Json
		$content.hostingPlanName.reference.KeyVault.id = $KeyVaultResourceId
		$content.hostingPlanName.reference.SecretName = $secretName
		$content | ConvertTo-Json -depth 999 | Out-File keyVaultTemplateParams.json

		$deployment = New-AzResourceGroupDeployment -Name $rname -ResourceGroupName $rgname -TemplateFile sampleTemplate.json -TemplateParameterFile keyVaultTemplateParams.json

		# Assert
		Assert-AreEqual Succeeded $deployment.ProvisioningState

		$subId = (Get-AzContext).Subscription.SubscriptionId
		$deploymentId = "/subscriptions/$subId/resourcegroups/$rgname/providers/Microsoft.Resources/deployments/$rname"
		$getById = Get-AzResourceGroupDeployment -Id $deploymentId
		Assert-AreEqual $getById.DeploymentName $deployment.DeploymentName
	}

	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests deployment with template file with complex parameters.
#>
function Test-NewDeploymentWithComplexPramaters
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "CentralUSEUAP"

	try
	{
		# Test
		New-AzResourceGroup -Name $rgname -Location $rglocation

		$deployment = New-AzResourceGroupDeployment -Name $rname -ResourceGroupName $rgname -TemplateFile complexParametersTemplate.json -TemplateParameterFile complexParameters.json

		# Assert
		Assert-AreEqual Succeeded $deployment.ProvisioningState

		$subId = (Get-AzContext).Subscription.SubscriptionId
		$deploymentId = "/subscriptions/$subId/resourcegroups/$rgname/providers/Microsoft.Resources/deployments/$rname"
		$getById = Get-AzResourceGroupDeployment -Id $deploymentId
		Assert-AreEqual $getById.DeploymentName $deployment.DeploymentName
	}

	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests deployment with template file with parameter object.
#>
function Test-NewDeploymentWithParameterObject
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "CentralUSEUAP"

	try
	{
		# Test
		New-AzResourceGroup -Name $rgname -Location $rglocation

		$deployment = New-AzResourceGroupDeployment -Name $rname -ResourceGroupName $rgname -TemplateFile complexParametersTemplate.json -TemplateParameterObject @{appSku=@{code="f1"; name="Free"}; servicePlan="plan1"; ranks=@("c", "d")}

		# Assert
		Assert-AreEqual Succeeded $deployment.ProvisioningState

		$subId = (Get-AzContext).Subscription.SubscriptionId
		$deploymentId = "/subscriptions/$subId/resourcegroups/$rgname/providers/Microsoft.Resources/deployments/$rname"
		$getById = Get-AzResourceGroupDeployment -Id $deploymentId
		Assert-AreEqual $getById.DeploymentName $deployment.DeploymentName
	}

	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests deployment with template file with dynamic parameters.
#>
function Test-NewDeploymentWithDynamicParameters
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"

	try
	{
		# Test
		New-AzResourceGroup -Name $rgname -Location $rglocation

		$deployment = New-AzResourceGroupDeployment -Name $rname -ResourceGroupName $rgname -TemplateFile complexParametersTemplate.json -appSku @{code="f3"; name=@{major="Official"; minor="1.0"}} -servicePlan "plan1" -ranks @("c", "d")

		# Assert
		Assert-AreEqual Succeeded $deployment.ProvisioningState

		$subId = (Get-AzContext).Subscription.SubscriptionId
		$deploymentId = "/subscriptions/$subId/resourcegroups/$rgname/providers/Microsoft.Resources/deployments/$rname"
		$getById = Get-AzResourceGroupDeployment -Id $deploymentId
		Assert-AreEqual $getById.DeploymentName $deployment.DeploymentName
	}

	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests error displayed for invalid parameters.
#>
function Test-NewDeploymentWithInvalidParameters
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "CentralUSEUAP"

	try
	{
		# Test
		$ErrorActionPreference = "SilentlyContinue"
		$Error.Clear()
		New-AzResourceGroup -Name $rgname -Location $rglocation
		$deployment = New-AzResourceGroupDeployment -Name $rname -ResourceGroupName $rgname -TemplateFile complexParametersTemplate.json -appSku @{code="f4"; name="Free"} -servicePlan "plan1"
	}
	catch
	{
		Assert-True { $Error[1].Contains("The parameter value is not part of the allowed value(s)") }
	}
	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests deployment via template file with KeyVault reference in TemplateParameterObject.
#>
function Test-NewDeploymentWithKeyVaultReferenceInParameterObject
{
	# Setup
	$location = "West US"

	$vaultId = "/subscriptions/996a2f3f-ee01-4ffd-9765-d2c3fc98f30a/resourceGroups/demo-rg-2/providers/Microsoft.KeyVault/vaults/pstestsaname"
	$secretName = "examplesecret"

	try
	{
		$deploymentRG = Get-ResourceGroupName
		$deploymentName = Get-ResourceName

		New-AzResourceGroup -Name $deploymentRG -Location $location

		# Test
		$parameters = @{"storageAccountName"= @{"reference"= @{"keyVault"= @{"id"= $vaultId};"secretName"= $secretName}}}
		$deployment = New-AzResourceGroupDeployment -Name $deploymentName -ResourceGroupName $deploymentRG -TemplateFile StorageAccountTemplate.json -TemplateParameterObject $parameters

		# Assert
		Assert-AreEqual Succeeded $deployment.ProvisioningState
	}

	finally
    {
        # Cleanup
        Clean-ResourceGroup $deploymentRG
    }
}

<#
.SYNOPSIS
Tests deployment exception thrown with nonexistent template file.
#>
function Test-NewDeploymentFromNonexistentTemplateFile
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $rglocation = "West US 2"
    try
    {
        # Test
        New-AzResourceGroup -Name $rgname -Location $rglocation

        # Assert exception is thrown
        $path = (Get-Item ".\").FullName
        $file = Join-Path $path "nonexistentFile.json"
        $exceptionMessage = "Cannot retrieve the dynamic parameters for the cmdlet. Cannot find path '$file' because it does not exist."
        Assert-Throws { New-AzResourceGroupDeployment -Name $rname -ResourceGroupName $rgname -TemplateFile $file -TemplateParameterFile sampleTemplateParams.json } $exceptionMessage
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests deployment exception thrown with nonexistent template parameter file.
#>
function Test-NewDeploymentFromNonexistentTemplateParameterFile
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $rglocation = "West US 2"
    try
    {
        # Test
        New-AzResourceGroup -Name $rgname -Location $rglocation

        # Assert exception is thrown
        $path = (Get-Item ".\").FullName
        $file = Join-Path $path "nonexistentFile.json"
        $exceptionMessage = "Cannot retrieve the dynamic parameters for the cmdlet. Cannot find path '$file' because it does not exist."
        Assert-Throws { New-AzResourceGroupDeployment -Name $rname -ResourceGroupName $rgname -TemplateFile sampleTemplateParams.json -TemplateParameterFile $file } $exceptionMessage
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests deployment via Bicep file.
#>
function Test-NewDeploymentFromBicepFile
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $rglocation = "West US 2"
    $expectedTags = @{"key1"="value1"; "key2"="value2";}

    try
    {
        # Test
        New-AzResourceGroup -Name $rgname -Location $rglocation

        $deployment = New-AzResourceGroupDeployment -Name $rname -ResourceGroupName $rgname -TemplateFile sampleDeploymentBicepFile.bicep -Tag $expectedTags

        # Assert
        Assert-AreEqual Succeeded $deployment.ProvisioningState
        Assert-True { AreHashtableEqual $expectedTags $deployment.Tags }

        $subId = (Get-AzContext).Subscription.SubscriptionId
        $deploymentId = "/subscriptions/$subId/resourcegroups/$rgname/providers/Microsoft.Resources/deployments/$rname"
        $getById = Get-AzResourceGroupDeployment -Id $deploymentId
        Assert-AreEqual $getById.DeploymentName $deployment.DeploymentName

        [hashtable]$actualTags = $getById.Tags
        Assert-True { AreHashtableEqual $expectedTags $getById.Tags }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests deployment template via bicep file.
#>
function Test-TestDeploymentFromBicepFile
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $location = "West US 2"

    # Test
    try
    {
        New-AzResourceGroup -Name $rgname -Location $location

        $list = Test-AzResourceGroupDeployment -ResourceGroupName $rgname -TemplateFile sampleDeploymentBicepFile.bicep

        # Assert
        Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
is running live in target environment
#>
function IsLive
{
    return [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback
}

<#
.SYNOPSIS
Tests what-if on a deployment from a template in a storage account using a query string.
Please make sure to re-record this test if any changes are made to WhatIf or ResourceGroupDeployments
#>
function Test-WhatIfWithQueryString
{
	# Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
	$saname = "querystringpstests"
    $rglocation = "West US 2"
    $subId = (Get-AzContext).Subscription.SubscriptionId

	if(IsLive)
    {
		try
		{
			# Prepare our RG
			New-AzResourceGroup -Name $rgname -Location $rglocation

			#Prepare our Storage Account
			$account = New-AzStorageAccount -ResourceGroupName $rgname -AccountName $saname -Location $rglocation -SkuName "Standard_LRS"

			#Get StorageAccountKey
			$key = (Get-AzStorageAccountKey -ResourceGroupName $rgname -AccountName $saname)| Where-Object {$_.KeyName -eq "key1"}

			#Get StorageAccount context
			$context = New-AzStorageContext -StorageAccountName $saname -StorageAccountKey $key.Value

			#Create FileShare
			New-AzStorageShare -Name "querystringshare" -Context $context

			#Upload files to the StorageAccount
			Set-AzStorageFileContent -ShareName "querystringshare" -Source "sampleLinkedTemplateParent.json" -Path "sampleLinkedTemplateParent.json" -Context $context
			Set-AzStorageFileContent -ShareName "querystringshare" -Source "sampleLinkedTemplateChild.json" -Path "sampleLinkedTemplateChild.json" -Context $context

			#Get SAStoken
			$token = New-AzStorageAccountSASToken -Service File -ResourceType Service,Container,Object -Permission "r" -Context $context -ExpiryTime (Get-Date).AddMinutes(3)

			#Create deployment
			$deployment =New-AzResourceGroupDeployment -Name $rname -ResourceGroupName $rgname -TemplateUri "https://querystringpstests.file.core.windows.net/querystringshare/sampleLinkedTemplateParent.json" -QueryString $token.Substring(1)

			# Assert
			Assert-AreEqual Succeeded $deployment.ProvisioningState

			#Run What-if
			$result =  New-AzResourceGroupDeployment -Name $rname -ResourceGroupName $rgname -TemplateUri "https://querystringpstests.file.core.windows.net/querystringshare/sampleLinkedTemplateParent.json" -QueryString $token.Substring(1) -WhatIf

			#assert that nothing has changed.
			Assert-AreEqual 0 ($result).Count
		}

		finally
		{
			# Cleanup
			Remove-AzStorageAccount -Force -ResourceGroupName $rgname -Name $saname;
			Clean-ResourceGroup $rgname
		}
	}
}

<#
.SYNOPSIS
Tests deployment via template file containing a single datetime string output.
#>
function Test-NewDeploymentFromTemplateFileContainingDatetimeOutput
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"

	try
	{
		# Test
		New-AzResourceGroup -Name $rgname -Location $rglocation

		$datetime = "2021-07-08T22:56:00"
		$datetimeFormatted = $datetime | Get-Date
		$parameters = @{ "date"= $datetime }

		$deployment = New-AzResourceGroupDeployment -Name $rname -ResourceGroupName $rgname -TemplateFile simpleTemplateWithDatetimeOutput.json -TemplateParameterObject $parameters

		# Assert
		Assert-AreEqual Succeeded $deployment.ProvisioningState

		$subId = (Get-AzContext).Subscription.SubscriptionId
		$deploymentId = "/subscriptions/$subId/resourcegroups/$rgname/providers/Microsoft.Resources/deployments/$rname"
		$getById = Get-AzResourceGroupDeployment -Id $deploymentId
		Assert-AreEqual $getById.DeploymentName $deployment.DeploymentName

		$datetimeOutput = $getById.Outputs.date.Value | Get-Date
		
		Assert-AreEqual $datetimeFormatted $datetimeOutput
	}

	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests deployment via template and parameter file containing a single datetime string output.
#>
function Test-NewDeploymentFromTemplateAndParameterFileContainingDatetimeOutput
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"

	try
	{
		# Test
		New-AzResourceGroup -Name $rgname -Location $rglocation

		# NOTE(jcotillo): This is the same value as the one from: simpleTemplateWithDatetimeOutputParameters.json
		# if the parameter file gets updated, please ensure to update this value as well otherwise test will fail.
		$datetime = "2021-07-08T22:56:00"
		$datetimeFormatted = $datetime | Get-Date
		$parameters = @{ "date"= $datetime }

		$deployment = New-AzResourceGroupDeployment -Name $rname -ResourceGroupName $rgname -TemplateFile simpleTemplateWithDatetimeOutput.json -TemplateParameterFile simpleTemplateWithDatetimeOutputParameters.json

		# Assert
		Assert-AreEqual Succeeded $deployment.ProvisioningState

		$subId = (Get-AzContext).Subscription.SubscriptionId
		$deploymentId = "/subscriptions/$subId/resourcegroups/$rgname/providers/Microsoft.Resources/deployments/$rname"
		$getById = Get-AzResourceGroupDeployment -Id $deploymentId
		Assert-AreEqual $getById.DeploymentName $deployment.DeploymentName

		$datetimeOutput = $getById.Outputs.date.Value | Get-Date
		
		Assert-AreEqual $datetimeFormatted $datetimeOutput
	}

	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests deployment via template and parameter file containing a tags with different casing.
#>
function Test-NewDeploymentFromTemplateFileContainingTagsOutput
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"

	try
	{
		# Test
		New-AzResourceGroup -Name $rgname -Location $rglocation

		$tagsToCompare = @{
			"MY_FIRST_TAG" = "tagValue";
			"MYFIRSTTAG" = "tagvalue2";
			"mysecondTag" = "tagValue3";
			"mythirdtag" = "tagvalue4"
		}

		$parameters = @{ "tags"= $tagsToCompare }

		$deployment = New-AzResourceGroupDeployment -Name $rname -ResourceGroupName $rgname -TemplateFile simpleTemplateWithTagsOutput.json -TemplateParameterObject $parameters

		# Assert
		Assert-AreEqual Succeeded $deployment.ProvisioningState

		$subId = (Get-AzContext).Subscription.SubscriptionId
		$deploymentId = "/subscriptions/$subId/resourcegroups/$rgname/providers/Microsoft.Resources/deployments/$rname"
		$getById = Get-AzResourceGroupDeployment -Id $deploymentId
		Assert-AreEqual $getById.DeploymentName $deployment.DeploymentName

		$tagsOutput = $getById.Outputs.tags.Value

		$tagsOutputJson = ConvertTo-Json -Compress $tagsOutput
		
		# Performs a case sensitive comparison
		# Doing a foreach on the keys and comparing against the JSON string
		# this needed because the flag -AsHashTable doesn't seem to work 
		# in ConvertTo-Json cmdlet
		foreach ($tag in $tagsToCompare.Keys)
		{
			Assert-True { $tagsOutputJson -clike "*${tag}*"}
		}
	}

	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests deployment via template and parameter file containing a tags with different casing.
#>
function Test-NewDeploymentFromTemplateAndParameterFileContainingTagsOutput
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "West US 2"

	try
	{
		# Test
		New-AzResourceGroup -Name $rgname -Location $rglocation

		$tagsToCompare = @{
			"MY_FIRST_TAG" = "tagValue";
			"MYFIRSTTAG" = "tagvalue2";
			"mysecondTag" = "tagValue3";
			"mythirdtag" = "tagvalue4"
		}

		$deployment = New-AzResourceGroupDeployment -Name $rname -ResourceGroupName $rgname -TemplateFile simpleTemplateWithTagsOutput.json -TemplateParameterFile simpleTemplateWithTagsOutputParameters.json

		# Assert
		Assert-AreEqual Succeeded $deployment.ProvisioningState

		$subId = (Get-AzContext).Subscription.SubscriptionId
		$deploymentId = "/subscriptions/$subId/resourcegroups/$rgname/providers/Microsoft.Resources/deployments/$rname"
		$getById = Get-AzResourceGroupDeployment -Id $deploymentId
		Assert-AreEqual $getById.DeploymentName $deployment.DeploymentName

		$tagsOutput = $getById.Outputs.tags.Value
		
		$tagsOutputJson = ConvertTo-Json -Compress $tagsOutput
		
		# Performs a case sensitive comparison
		# Doing a foreach on the keys and comparing against the JSON string
		# this needed because the flag -AsHashTable doesn't seem to work 
		# in ConvertTo-Json cmdlet
		foreach ($tag in $tagsToCompare.Keys)
		{
			Assert-True { $tagsOutputJson -clike "*${tag}*"}
		}
	}

	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests symbolic name resource deployment
#>
function Test-SymbolicNameDeployment
{
<# 
* main.bicep:
    ```bicep
    @description('Location for all resources.')
    param location string = resourceGroup().location
    
    var storageAccountName = 'storage${uniqueString(resourceGroup().id)}'
    var endpointName = 'endpoint-${uniqueString(resourceGroup().id)}'
    var profileName = 'cdn-${uniqueString(resourceGroup().id)}'
    var storageAccountHostName = replace(replace(storageAccount.properties.primaryEndpoints.blob, 'https://', ''), '/', '')
    
    resource storageAccount 'Microsoft.Storage/storageAccounts@2021-01-01' = {
      name: storageAccountName
      location: location
      tags: {
        displayName: storageAccountName
      }
      kind: 'StorageV2'
      sku: {
        name: 'Standard_LRS'
      }
    }
    
    resource cdnProfile 'Microsoft.Cdn/profiles@2020-09-01' = {
      name: profileName
      location: location
      tags: {
        displayName: profileName
      }
      sku: {
        name: 'Standard_Verizon'
      }
    }
    
    resource endpoint 'Microsoft.Cdn/profiles/endpoints@2020-09-01' = {
      parent: cdnProfile
      name: endpointName
      location: location
      tags: {
        displayName: endpointName
      }
      properties: {
        originHostHeader: storageAccountHostName
        isHttpAllowed: true
        isHttpsAllowed: true
        queryStringCachingBehavior: 'IgnoreQueryString'
        contentTypesToCompress: [
          'text/plain'
          'text/html'
          'text/css'
          'application/x-javascript'
          'text/javascript'
        ]
        isCompressionEnabled: true
        origins: [
          {
            name: 'origin1'
            properties: {
              hostName: storageAccountHostName
            }
          }
        ]
      }
    }
    
    output hostName string = endpoint.properties.hostName
    output originHostHeader string = endpoint.properties.originHostHeader
    ```
#>

	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "East US 2"

	try
	{
		# Test
		New-AzResourceGroup -Name $rgname -Location $rglocation

		# Validate
		$deployment = Test-AzResourceGroupDeployment -ResourceGroupName $rgname -TemplateFile symbolicNameTemplate.json

		# Deploy
		$deployment = New-AzResourceGroupDeployment -Name $rname -ResourceGroupName $rgname -TemplateFile symbolicNameTemplate.json
		
		# Assert
		Assert-AreEqual Succeeded $deployment.ProvisioningState
	}

	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests symbolic name resource deployment
#>
function Test-ExtensibleResourceDeployment
{
<# 
* aks.bicep:
    ```bicep
    param location string = resourceGroup().location
    param baseName string
    param dnsPrefix string
    param linuxAdminUsername string
    param sshRSAPublicKey string
    
    var osDiskSizeGB = 0
    var agentCount = 3
    var agentVMSize = 'standard_f2s_v2' //'Standard_DS2_v2'
    var resourceNamee = toLower('${baseName}${uniqueString(resourceGroup().id)}')
    
    resource aks 'Microsoft.ContainerService/managedClusters@2020-09-01' = {
      name: resourceNamee
      location: location
      properties: {
        dnsPrefix: dnsPrefix
        agentPoolProfiles: [
          {
            name: 'agentpool'
            osDiskSizeGB: osDiskSizeGB
            count: agentCount
            vmSize: agentVMSize
            osType: 'Linux'
            mode: 'System'
          }
        ]
        linuxProfile: {
          adminUsername: linuxAdminUsername
          ssh: {
            publicKeys: [
              {
                keyData: sshRSAPublicKey
              }
            ]
          }
        }
      }
      identity: {
        type: 'SystemAssigned'
      }
    }
    
    resource keyVault 'Microsoft.KeyVault/vaults@2022-07-01' = {
      name: resourceNamee
      location: location
      properties: {
        sku: {
          family: 'A'
          name: 'standard'
        }
        tenantId: subscription().tenantId
        accessPolicies: []
        enabledForTemplateDeployment: true
      }
    }
    
    resource secret 'Microsoft.KeyVault/vaults/secrets@2022-07-01' = {
      parent: keyVault
      name: 'kubeconfig'
      properties: {
        value: aks.listClusterAdminCredential().kubeconfigs[0].value
      }
    }
    
    output keyVaultId string = keyVault.id
    output secretName string = secret.name
    ```
* kubernetes.bicep:
    ```bicep
    @secure()
    param kubeConfig string
    
    import kubernetes as k8s {
      kubeConfig: kubeConfig
      namespace: 'default'
    }
    
    var backName = 'azure-vote-back'
    var backPort = 6379
    
    var frontName = 'azure-vote-front'
    var frontPort = 80
    
    @description('Application back-end deployment (redis)')
    resource backDeploy 'apps/Deployment@v1' = {
      metadata: {
        name: backName
      }
      spec: {
        replicas: 1
        selector: {
          matchLabels: {
            app: backName
          }
        }
        template: {
          metadata: {
            labels: {
              app: backName
            }
          }
          spec: {
            containers: [
              {
                name: backName
                image: 'mcr.microsoft.com/oss/bitnami/redis:6.0.8'
                env: [
                  {
                    name: 'ALLOW_EMPTY_PASSWORD'
                    value: 'yes'
                  }
                ]
                resources: {
                  requests: {
                    cpu: '100m'
                    memory: '128Mi'
                  }
                  limits: {
                    cpu: '250m'
                    memory: '256Mi'
                  }
                }
                ports: [
                  {
                    containerPort: backPort
                    name: 'redis'
                  }
                ]
              }
            ]
          }
        }
      }
    }
    
    @description('Configure back-end service')
    resource backSvc 'core/Service@v1' = {
      metadata: {
        name: backName
      }
      spec: {
        ports: [
          {
            port: backPort
          }
        ]
        selector: {
          app: backName
        }
      }
    }
    
    @description('Application front-end deployment (website)')
    resource frontDeploy 'apps/Deployment@v1' = {
      metadata: {
        name: frontName
      }
      spec: {
        replicas: 1
        selector: {
          matchLabels: {
            app: frontName
          }
        }
        template: {
          metadata: {
            labels: {
              app: frontName
            }
          }
          spec: {
            nodeSelector: {
              'beta.kubernetes.io/os': 'linux'
            }
            containers: [
              {
                name: frontName
                image: 'mcr.microsoft.com/azuredocs/azure-vote-front:v1'
                resources: {
                  requests: {
                    cpu: '100m'
                    memory: '128Mi'
                  }
                  limits: {
                    cpu: '250m'
                    memory: '256Mi'
                  }
                }
                ports: [
                  {
                    containerPort: frontPort
                  }
                ]
                env: [
                  {
                    name: 'REDIS'
                    value: backName
                  }
                ]
              }
            ]
          }
        }
      }
    }
    
    @description('Configure front-end service')
    resource frontSvc 'core/Service@v1' = {
      metadata: {
        name: frontName
      }
      spec: {
        type: 'LoadBalancer'
        ports: [
          {
            port: frontPort
          }
        ]
        selector: {
          app: frontName
        }
      }
    }
    ```
#>

	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = "East US 2"

	try
	{
		# Test
		New-AzResourceGroup -Name $rgname -Location $rglocation
		$parameters = @{ "baseName" = $rname; "dnsPrefix" = $rname; "linuxAdminUsername" = "admin$rname"; "sshRSAPublicKey" = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABgQCd0Z7O2n3XcN0nm1DXGu0LkFMtW9bNyEXQC1FgPskQ1FN1FNIuumHdRC6h1w44/aUiDBaOZ+Tb/opB30OZDNAqdc0L0tBqatZiP1oIorFrjAS15vCdMUy3S6u9WxJKPteB2O45gMvTVz+80mYmWwTsRpSNXXJ6TPKazNwNtgQw0fpKHsnkFHSnBOpqXqtZPhJMCPggHOzU49iK1tPyInMPqhvk4Kk9OC7E3SU7l6hQn76wIpREkIdEVxhlLhxN37N+wPk5d1krreJE+EOVg/EJOORIpeG/MIn6ticeCb+dXnyfJkZTh/7J/zmTKlIzF43Eeg3OLMPunQGgPCDtRujZJAA+lFFT4m0h+LmtlWeBO9VlsAmfC2hm0OgGgkn69qLJ3pw5WLBp1NDpgeIwp6jvCYw2sUr4b2VzRfOMKiRngCrNrt9LKdJ57W2t8Y1kkfK9xlLEI/+goLT2KD07NmU4wuFsBHA2uh55S0j/NAUpgouB+nONrelIy8IUnpzlPkM= ant@ant-mbp-work.lan" }
		$deployment = New-AzResourceGroupDeployment -Name "setup" -ResourceGroupName $rgname -TemplateFile extensibleResources_aks.json -TemplateParameterObject $parameters
		$keyVaultId = $deployment.Outputs["keyVaultId"].Value
		$secretName = $deployment.Outputs["secretName"].Value

		# Validate
		$parameters = @{ "kubeConfig" = @{ "reference" = @{ "keyVault" = @{ "id" = $keyVaultId }; "secretName" = $secretName }}}
		$deployment = Test-AzResourceGroupDeployment -ResourceGroupName $rgname -TemplateFile extensibleResources_kubernetes.json -TemplateParameterObject $parameters

		# Deploy
		$deployment = New-AzResourceGroupDeployment -Name $rname -ResourceGroupName $rgname -TemplateFile extensibleResources_kubernetes.json -TemplateParameterObject $parameters
		
		# Assert
		Assert-AreEqual Succeeded $deployment.ProvisioningState
	}

	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}