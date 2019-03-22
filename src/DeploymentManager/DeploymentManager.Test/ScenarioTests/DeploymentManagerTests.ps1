<#
.SYNOPSIS
Test all resource operations 
#>
function Test-EndToEndFunctionalTests
{
    # Setup
    $resourceGroupName = "adm-powershell-test-rg"
	$subscriptionId = "53012dcb-5039-4e96-8e6c-5d913da1cdb5"
	$artifactSourceName = "powershell-sdk-tests-functional"
	$updatedArtifactSourceName = "powershell-sdk-tests"

	$location = "Central US"

    # Create resource group
    $resourceGroup = New-AzResourceGroup -Name $resourceGroupName -Location $location
	Assert-NotNull $resourceGroup "Created resource group is null."

	$artifactSource = New-ArtifactSource $resourceGroupName $artifactSourceName

	# Test all service topology and rollout operation
	Test-ServiceTopology $resourceGroupName $location $artifactSource $updatedArtifactSourceName $subscriptionId

	Remove-AzDeploymentManagerArtifactSource -ResourceGroupName $resourceGroupName -Name $artifactSourceName -Force

	$getArtifactSource = $null
	try
	{
		$getArtifactSource = Get-AzDeploymentManagerArtifactSource -ResourceGroupName $resourceGroupName -Name $artifactSourceName 
	}
	catch 
	{
		$errorString = $_.Exception.Message
		Assert-True { $errorString.Contains("was not found") }
	}

	Assert-Null $getArtifactSource
}

function Test-ServiceTopology
{
    param
    (
    $resourceGroupName,
    $location,
	$artifactSource,
	$updatedArtifactSourceName,
	$subscriptionId
    )

	$serviceTopologyName = "powershell-sdk-tests"

	$serviceTopology = New-AzDeploymentManagerServiceTopology -ResourceGroupName $resourceGroupName -Location $location -Name $serviceTopologyName -ArtifactSourceId $artifactSource.Id
	Validate-Topology $serviceTopology $resourceGroupName $location $serviceTopologyName $artifactSource.Id
	$getResponse = Get-AzDeploymentManagerServiceTopology -ResourceGroupName $resourceGroupName -Name $serviceTopologyName

	Validate-Topology $getResponse $resourceGroupName $location $serviceTopologyName $artifactSource.Id

	# Test Service CRUD operations
	Test-Service $resourceGroupName $location $artifactSource $serviceTopology $subscriptionId

	# Test Set-ServiceTopology 
	$updatedArtifactSource = New-ArtifactSource $resourceGroupName $updatedArtifactSourceName
	$getResponse.ArtifactSourceId = $updatedArtifactSource.Id

	$updatedServiceTopology = Set-AzDeploymentManagerServiceTopology $getResponse
	Validate-Topology $updatedServiceTopology $resourceGroupName $location $serviceTopologyName $updatedArtifactSource.Id

	# Test Remove-ServiceTopology 
	Remove-AzDeploymentManagerServiceTopology -ResourceGroupName $resourceGroupName -Name $serviceTopologyName -Force
	$getResponse = $null
	try
	{
		$getResponse = Get-AzDeploymentManagerServiceTopology -ResourceGroupName $resourceGroupName -Name $serviceTopologyName
	}
	catch 
	{
		$errorString = $_.Exception.Message
		Assert-True { $errorString.Contains("was not found") }
	}

	Assert-Null $getResponse
}

function Validate-Topology
{
    param
    (
    $serviceTopology,
	$resourceGroupName,
    $location,
	$serviceTopologyName,
	$artifactSourceId
    )

		Assert-NotNull $serviceTopology "Created ServiceTopology is null"
		Assert-AreEqual $location $serviceTopology.Location
		Assert-AreEqual $serviceTopologyName $serviceTopology.Name
		Assert-AreEqual $artifactSourceId $serviceTopology.ArtifactSourceId
}

function Test-Service
{
    param
    (
    $resourceGroupName,
    $location,
	$artifactSource,
	$serviceTopology,
	$subscriptionId)

	$serviceName = "Contoso_Service"
	$targetLocation = "East US 2"
	$targetSubscriptionId = "53012dcb-5039-4e96-8e6c-5d913da1cdb5"

	$service = New-AzDeploymentManagerService -ResourceGroupName $resourceGroupName -Location $location -Name $serviceName -ServiceTopology $serviceTopology -TargetLocation $targetLocation -TargetSubscriptionId $targetSubscriptionId

	Validate-Service $service $resourceGroupName $location $serviceTopology.Name $serviceName $targetLocation $targetSubscriptionId

	$getResponse = Get-AzDeploymentManagerService -ResourceGroupName $resourceGroupName -Name $serviceName -ServiceTopologyName $serviceTopology.Name

	Validate-Service $getResponse $resourceGroupName $location $serviceTopology.Name $serviceName $targetLocation $targetSubscriptionId

	# Test Service Unit CRUD operations
	Test-ServiceUnit $resourceGroupName $location $artifactSource $serviceTopology $getResponse

	# Test Set-Service
	$getResponse.TargetSubscriptionId = "1e591dc1-b014-4754-b53b-58b67bcab1cd"
	$updatedService = Set-AzDeploymentManagerService $getResponse

	Validate-Service $updatedService $resourceGroupName $location $serviceTopologyName $serviceName $targetLocation $getResponse.TargetSubscriptionId

	# Test Remove-Service
	Remove-AzDeploymentManagerService -ResourceGroupName $resourceGroupName -Name $serviceName -ServiceTopologyName $serviceTopology.Name -Force

	$getResponse = $null

	try
	{
		$getResponse = Get-AzDeploymentManagerService -ResourceGroupName $resourceGroupName -Name $serviceName -ServiceTopologyName $serviceTopology.Name
	}
	catch 
	{
		$errorString = $_.Exception.Message
		Assert-True { $errorString.Contains("not found") }
	}

	Assert-Null $getResponse
}

function Validate-Service
{
    param
    (
    $service,
	$resourceGroupName,
    $location,
	$serviceTopologyName,
	$serviceName,
	$targetLocation,
	$subscriptionId
    )

		Assert-NotNull $service "Created service is null"
		Assert-AreEqual $location $service.Location
		Assert-AreEqual $serviceName $service.Name
		Assert-AreEqual $serviceTopologyName $service.ServiceTopologyName
		Assert-AreEqual $targetLocation $service.TargetLocation
		Assert-AreEqual $subscriptionId $service.TargetSubscriptionId
}

function Test-ServiceUnit
{
    param
    (
    $resourceGroupName,
    $location,
	$artifactSource,
	$serviceTopology,
	$service)

	$serviceUnitName = "Contoso_WebApp"
	$targetResourceGroup = "sdk-net-targetResourceGroup"
	$deploymentMode = "Incremental"
	$parametersArtifactSourceRelativePath = "Parameters/WebApp.Parameters.json"
    $templateArtifactSourceRelativePath = "Templates/WebApp.Template.json"

	$serviceUnit = New-AzDeploymentManagerServiceUnit `
		-ResourceGroupName $resourceGroupName `
		-Location $location `
		-ServiceTopology $serviceTopology `
		-ServiceName $service.Name `
		-Name $serviceUnitName `
		-TargetResourceGroup $targetResourceGroup `
		-DeploymentMode $deploymentMode `
		-ParametersArtifactSourceRelativePath $parametersArtifactSourceRelativePath `
		-TemplateArtifactSourceRelativePath $templateArtifactSourceRelativePath 

	Validate-ServiceUnit $serviceUnit $resourceGroupName $location $serviceTopology.Name $service.Name $serviceUnitName $targetResourceGroup $deploymentMode $templateArtifactSourceRelativePath $parametersArtifactSourceRelativePath

	$getResponse = Get-AzDeploymentManagerServiceUnit  `
		-ResourceGroupName $resourceGroupName  `
		-ServiceTopologyName $serviceTopology.Name `
		-ServiceName $serviceName `
		-Name $serviceUnitName

	Validate-ServiceUnit $getResponse $resourceGroupName $location $serviceTopology.Name $service.Name $serviceUnitName $targetResourceGroup $deploymentMode $templateArtifactSourceRelativePath $parametersArtifactSourceRelativePath

	# Test rollout CRUD operations
		# Create a service unit with invalid parameters file for testing restart-rollout scenari
		$invalidParametersArtifactSourceRelativePath = "Parameters/WebApp.Invalid.Parameters.json"
		$invalidServiceUnitName = "Contoso_WebApp_Invalid"

		$invalidServiceUnit = New-AzDeploymentManagerServiceUnit   `
			-ResourceGroupName $resourceGroupName  `
			-Location $location  `
			-ServiceTopology $serviceTopology  `
			-ServiceName $service.Name  `
			-Name $invalidServiceUnitName `
			-TargetResourceGroup $targetResourceGroup `
			-DeploymentMode $deploymentMode `
			-ParametersArtifactSourceRelativePath $invalidParametersArtifactSourceRelativePath `
			-TemplateArtifactSourceRelativePath $templateArtifactSourceRelativePath 
		Validate-ServiceUnit $invalidServiceUnit $resourceGroupName $location $serviceTopology.Name $service.Name $invalidServiceUnitName $targetResourceGroup $deploymentMode $templateArtifactSourceRelativePath $invalidParametersArtifactSourceRelativePath

		# Test Step operations and rollout CRUD operations that depend on Service Units
		Test-Steps $resourceGroupName $location $serviceTopology $artifactSource $serviceUnit

	# Test Set-ServiceUnit
	$getResponse.DeploymentMode = "Complete"
	$getResponse.ParametersArtifactSourceRelativePath = "Parameters/WebApp.Parameters.Dup.json"
	$getResponse.TemplateArtifactSourceRelativePath = "Templates/WebApp.Template.Dup.json"

	$updatedServiceUnit = Set-AzDeploymentManagerServiceUnit $getResponse

	Validate-ServiceUnit $updatedServiceUnit $resourceGroupName $location $serviceTopology.Name $service.Name $serviceUnitName $targetResourceGroup $getResponse.DeploymentMode $getResponse.TemplateArtifactSourceRelativePath $getResponse.ParametersArtifactSourceRelativePath

	# Test Remove-ServiceUnit
	Remove-AzDeploymentManagerServiceUnit -ResourceGroupName $resourceGroupName -ServiceTopologyName $serviceTopology.Name -ServiceName $service.Name -Name $serviceUnitName -Force

	# Remove second service unit created for failure rollout case
	Remove-AzDeploymentManagerServiceUnit -ResourceGroupName $resourceGroupName -ServiceTopologyName $serviceTopology.Name -ServiceName $service.Name -Name $invalidServiceUnitName -Force

	$getResponse = $null
	try
	{
		$getResponse = Get-AzDeploymentManagerServiceUnit -ResourceGroupName $resourceGroupName -ServiceTopologyName $serviceTopology.Name -ServiceName $service.Name -Name $serviceUnitName
	}
	catch 
	{
		$errorString = $_.Exception.Message
		Assert-True { $errorString.Contains("was not found") }
	}

	Assert-Null $getResponse
}

function Validate-Serviceunit
{
    param
    (
    $serviceUnit,
	$resourceGroupName,
    $location,
	$serviceTopologyName,
	$serviceName,
	$serviceUnitName,
	$targetResourceGroup,
	$deploymentMode,
	$templateArtifactSourceRelativePath,
	$parametersArtifactSourceRelativePath)
		Assert-NotNull $serviceUnit "Created service unit is null"
		Assert-AreEqual $location $serviceUnit.Location
		Assert-AreEqual $serviceUnitName $serviceUnit.Name
		Assert-AreEqual $serviceTopologyName $serviceUnit.ServiceTopologyName
		Assert-AreEqual $serviceName $serviceUnit.ServiceName
		Assert-AreEqual $targetResourceGroup $serviceUnit.TargetResourceGroup
		Assert-AreEqual $deploymentMode $serviceUnit.DeploymentMode
		Assert-AreEqual $parametersArtifactSourceRelativePath $serviceUnit.ParametersArtifactSourceRelativePath
        Assert-AreEqual $templateArtifactSourceRelativePath $serviceUnit.TemplateArtifactSourceRelativePath
}

function Test-Steps
{
    param
    (
    $resourceGroupName,
    $location,
	$serviceTopology,
	$artifactSource,
	$serviceUnit)

	$stepName = "WaitStep"
	$duration = "PT5M"
	$updatedDuration = "PT10M"

	$step = New-AzDeploymentManagerStep -Name $stepName -ResourceGroupName $resourceGroupName -Location $location -Duration $duration
	Validate-Step $step $stepName $location $resourceGroupName $duration

	$getResponse = Get-AzDeploymentManagerStep -ResourceGroupName $resourceGroupName -Name $stepName
	Validate-Step $getResponse $stepName $location $resourceGroupName $duration

	Test-Rollout $resourceGroupName $location $serviceTopology $artifactSource $serviceUnit

	# Test Set-Step
	$getResponse.StepProperties.Duration = $updatedDuration

	$updatedStep = Set-AzDeploymentManagerStep $getResponse
	Validate-Step $updatedStep $stepName $location $resourceGroupName $updatedDuration

	# Test Remove-Step 
	Remove-AzDeploymentManagerStep -ResourceGroupName $resourceGroupName -Name $stepName -Force
	$getResponse = $null

	try
	{
		$getResponse = Get-AzDeploymentManagerStep -ResourceGroupName $resourceGroupName -Name $stepName
	}
	catch 
	{
		$errorString = $_.Exception.Message
		Assert-True { $errorString.Contains("was not found") }
	}

	Assert-Null $getResponse
}

function Validate-Step
{
    param
    (
    $step,
    $stepName,
    $location,
	$resourceGroupName,
	$duration)

		Assert-NotNull $step "Created step is null"
		Assert-AreEqual $location $step.Location
		Assert-AreEqual $resourceGroupName $step.ResourceGroupName
		Assert-AreEqual $stepName  $step.Name
		Assert-AreEqual $duration  $step.StepProperties.Duration
}

function Test-Rollout
{
    param
    (
    $resourceGroupName,
    $location,
	$serviceTopology,
	$artifactSource,
	$serviceUnit)

	$rolloutName = "adm-powershell-tests-rollout"
	$failedRolloutName = "adm-powershell-tests-invalidRollout"

	New-AzResourceGroup -Name $rolloutName -Location $location
	New-AzResourceGroup -Name $failedRolloutName -Location $location

	$deployment = New-AzResourceGroupDeployment -Name $rolloutName -ResourceGroupName $rolloutName -TemplateFile ".\ScenarioTests\CreateRollout.json"

	$getResponse = Get-AzDeploymentManagerRollout -ResourceGroupName $rolloutName -Name $rolloutName
	Validate-Rollout $getResponse $rolloutName $location $rolloutName @('Running') $serviceTopology $artifactSource

	# Test Stop-Rollout
	$canceledRollout = Stop-AzDeploymentManagerRollout -Rollout $getResponse -Force
	Validate-Rollout $canceledRollout $rolloutName $location $rolloutName @('Canceling', 'Canceled') $serviceTopology $artifactSource

	# Wait for rollout to finish
	while ($canceledRollout.Status -eq "Canceling")
	{
		Start-TestSleep 120000
		$canceledRollout = Get-AzDeploymentManagerRollout -ResourceGroupName $rolloutName -Name $rolloutName
	}

	Assert-AreEqual "Canceled" $canceledRollout.Status

	$failedDeployment = New-AzResourceGroupDeployment -Name $failedRolloutName -ResourceGroupName $failedRolloutName -TemplateFile ".\ScenarioTests\CreateRollout_FailureRollout.json"

	$ErrorActionPreference = "SilentlyContinue"
	$Error.Clear()
	$failedRollout = Get-AzDeploymentManagerRollout -ResourceGroupName $failedRolloutName -Name $failedRolloutName 2>$null

	# Wait for the invalid rollout to fail
	while ($failedRollout.Status -eq "Running")
	{
		Start-TestSleep 60000
		$failedRollout = Get-AzDeploymentManagerRollout -ResourceGroupName $failedRolloutName -Name $failedRolloutName 2>$null
	}

	$Error.Clear()
	Assert-AreEqual "Failed" $failedRollout.Status

	$restartRollout = Restart-AzDeploymentManagerRollout -ResourceGroupName $failedRolloutName -Name $failedRolloutName -SkipSucceeded
	Validate-Rollout $restartRollout $failedRolloutName $location $failedRolloutName @('Running') $serviceTopology $artifactSource $true 1

	Remove-AzDeploymentManagerRollout -ResourceGroupName $rolloutName -Name $rolloutName -Force
	$getResponse = Get-AzDeploymentManagerRollout -ResourceGroupName $rolloutName -Name $rolloutName
	Assert-Null $getResponse
}

function Validate-Rollout
{
    param
    (
    $rollout,
	$resourceGroupName,
    $location,
	$rolloutName,
	$rolloutStatus,
	$serviceTopology,
	$artifactSource,
    $skipSucceeded = $false,
	$retryAttempt = 0)

		Assert-NotNull $rollout "Created rollout is null"
		Assert-AreEqual $location $rollout.Location
		Assert-AreEqual $resourceGroupName $rollout.ResourceGroupName
		Assert-True { $rolloutStatus.Contains($rollout.Status) }
		Assert-AreEqual $serviceTopology.Id  $rollout.TargetServiceTopologyId
		Assert-AreEqual $artifactSource.Id  $rollout.ArtifactSourceId
		Assert-AreEqual $retryAttempt $rollout.OperationInfo.RetryAttempt
		Assert-AreEqual $skipSucceeded $rollout.OperationInfo.SkipSucceededOnRetry
}

function New-ArtifactSource
{
    param
    (
    $resourceGroupName,
    $artifactSourceName
    )

	$artifactRoot = "builds/1.0.0.0"
	$storageAccountResourceGroup = "adm-sdk-tests"
	$storageAccountName = "sdktests"
	$containerName = "artifacts"

	$sasKeyForContainer = ""
	Get-SasForContainer $storageAccountResourceGroup $storageAccountName $containerName ([ref]$sasKeyForContainer)
    $artifactSource = New-AzDeploymentManagerArtifactSource -ResourceGroupName $resourceGroupName -Name $artifactSourceName -Location $location -SasUri $sasKeyForContainer -ArtifactRoot $artifactRoot

    Assert-AreEqual $artifactSourceName $artifactSource.Name
    Assert-AreEqual $resourceGroupName $artifactSource.ResourceGroupName
    Assert-AreEqual $location $artifactSource.Location
    Assert-AreEqual "Microsoft.DeploymentManager/artifactSources" $artifactSource.Type
	Assert-AreEqual $artifactRoot $artifactSource.ArtifactRoot

	return $artifactSource
}

function Get-SasForContainer
{
    param
    (
    $resourceGroupName,
    $storageName,
    $storageContainerName,
    [ref] $sasKeyForContainer
    )
    if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback)
    {
        # Get storage account context
        $storageAccountContext = New-AzStorageContext -StorageAccountName $storageName -StorageAccountKey (Get-AzStorageAccountKey -ResourceGroupName $resourceGroupName -Name $storageName).Value[0]

        # Get SAS token for container
        $sasKeyForContainer.Value = New-AzStorageContainerSASToken -Name $storageContainerName -Permission "rl" -StartTime ([System.DateTime]::Now).AddHours(-20) -ExpiryTime ([System.DateTime]::Now).AddHours(48) -Context $storageAccountContext -FullUri
    }
    else
    {
        $sasKeyForContainer.Value = "dummysasforcontainer"
    }
}

<#
.SYNOPSIS
Sleeps but only during recording.
#>
function Start-TestSleep($milliseconds)
{
    if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback)
    {
        Start-Sleep -Milliseconds $milliseconds
    }
}
