$global:createRolloutTemplate = ".\ScenarioTests\CreateRollout.json"
$global:failureCreateRolloutTemplate = ".\ScenarioTests\CreateRollout_FailureRollout.json"

$global:parametersFileName = "Storage.Parameters.json"
$global:invalidParametersFileName = "Storage_Invalid.Parameters.json"
$global:templateFileName = "Storage.Template.json"
$global:parametersCopyFileName = "Storage.Copy.Parameters.json"
$global:templateCopyFileName = "Storage.Copy.Template.json"

$global:restHealthCheckPropertiesFilePath = Join-Path "ScenarioTests" "RestHealthCheckProperties.json" # using forward slash to make this platform-agnostic for tests run during merge validations.

$global:parametersArtifactSourceRelativePath = "ScenarioTests\ArtifactRoot\" + $global:parametersFileName
$global:templateArtifactSourceRelativePath = "ScenarioTests\ArtifactRoot\" + $global:templateFileName
$global:invalidParametersArtifactSourceRelativePath = "ScenarioTests\ArtifactRoot\" + $global:invalidParametersFileName
$global:parametersCopyArtifactSourceRelativePath = "ScenarioTests\ArtifactRoot\" + $global:parametersCopyFileName
$global:templateCopyArtifactSourceRelativePath = "ScenarioTests\ArtifactRoot\" + $global:templateCopyFileName

<#
.SYNOPSIS
Test all resource operations 
#>
function Test-EndToEndFunctionalTests
{
    # Setup
	$resourceGroupName = Get-AdmAssetName
	$subscriptionId = $(getVariable "SubscriptionId")
	$artifactSourceName = $resourceGroupName + "ArtifactSource"
	$updatedArtifactSourceName = $resourceGroupName  + "ArtifactSourceUpdated"
	$location = Get-ProviderLocation "Microsoft.DeploymentManager/serviceTopologies"
	$storageAccountName = $resourceGroupName + "psstgacct"

    # Create resource group
    $resourceGroup = New-AzResourceGroup -Name $resourceGroupName -Location $location
	# $resourceGroup = TestSetup-CreateResourceGroup
	Assert-NotNull $resourceGroup "Created resource group is null."
	Assert-AreEqual $resourceGroupName $resourceGroup.ResourceGroupName

	$resourceGroupName = $resourceGroup.ResourceGroupName

	# Create and set managed identity
	Set-ManagedIdentity $subscriptionId $resourceGroupName

	# Create artifact source
	$artifactSource = New-ArtifactSource $resourceGroupName $storageAccountName $artifactSourceName true

	# Test all service topology and rollout operation
	Test-ServiceTopology $resourceGroupName $location $artifactSource $updatedArtifactSourceName $storageAccountName $subscriptionId

	# Test List Artifact Sources
	$artifactSources = Get-AzDeploymentManagerArtifactSource -ResourceGroupName $resourceGroupName
	Assert-True { $artifactSources.Count -ge 2 }
	$selectedArtifactSource = $artifactSources | Where-Object {$_.Name -eq $artifactSourceName}
	Assert-NotNull $selectedArtifactSource "Created artifact source not returned in list"

	Remove-AzDeploymentManagerArtifactSource -ResourceGroupName $resourceGroupName -Name $artifactSourceName
	Remove-AzDeploymentManagerArtifactSource -ResourceGroupName $resourceGroupName -Name $updatedArtifactSourceName

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
	$storageAccountName,
	$subscriptionId)

	$serviceTopologyName = $resourceGroupName + "ServiceTopology"

	$serviceTopology = New-AzDeploymentManagerServiceTopology -ResourceGroupName $resourceGroupName -Location $location -Name $serviceTopologyName -ArtifactSourceId $artifactSource.Id
	Validate-Topology $serviceTopology $resourceGroupName $location $serviceTopologyName $artifactSource.Id
	$getResponse = Get-AzDeploymentManagerServiceTopology -ResourceGroupName $resourceGroupName -Name $serviceTopologyName

	Validate-Topology $getResponse $resourceGroupName $location $serviceTopologyName $artifactSource.Id

	# Test Service CRUD operations
	Test-Service $resourceGroupName $location $artifactSource $serviceTopology $subscriptionId

	# Test Set-ServiceTopology 
	$updatedArtifactSource = New-ArtifactSource $resourceGroupName $storageAccountName $updatedArtifactSourceName $false
	$getResponse.ArtifactSourceId = $updatedArtifactSource.Id

	$updatedServiceTopology = Set-AzDeploymentManagerServiceTopology $getResponse
	Validate-Topology $updatedServiceTopology $resourceGroupName $location $serviceTopologyName $updatedArtifactSource.Id

	# Test List ServiceTopologies
	$serviceTopology2Name = $resourceGroupName + "ServiceTopology2"
	$serviceTopology2 = New-AzDeploymentManagerServiceTopology -ResourceGroupName $resourceGroupName -Location $location -Name $serviceTopology2Name -ArtifactSourceId $artifactSource.Id

	$serviceTopologies = Get-AzDeploymentManagerServiceTopology -ResourceGroupName $resourceGroupName
	Assert-True { $serviceTopologies.Count -ge 2 }
	$selectedTopology = $serviceTopologies | Where-Object {$_.Name -eq $serviceTopologyName}
	Assert-NotNull $selectedTopology "Created topology not returned in list"
	Validate-Topology $selectedTopology $resourceGroupName $location $serviceTopologyName $updatedArtifactSource.Id

	# Test Remove-ServiceTopology 
	Remove-AzDeploymentManagerServiceTopology -ResourceGroupName $resourceGroupName -Name $serviceTopologyName
	Remove-AzDeploymentManagerServiceTopology -ResourceGroupName $resourceGroupName -Name $serviceTopology2Name
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

	$serviceName = $resourceGroupName + "Service"
	$targetLocation = $location

	$service = New-AzDeploymentManagerService -ResourceGroupName $resourceGroupName -Location $location -Name $serviceName -ServiceTopologyObject $serviceTopology -TargetLocation $targetLocation -TargetSubscriptionId $subscriptionId

	Validate-Service $service $resourceGroupName $location $serviceTopology.Name $serviceName $targetLocation $subscriptionId

	$getResponse = Get-AzDeploymentManagerService -ResourceGroupName $resourceGroupName -Name $serviceName -ServiceTopologyName $serviceTopology.Name

	Validate-Service $getResponse $resourceGroupName $location $serviceTopology.Name $serviceName $targetLocation $subscriptionId

	# Test Service Unit CRUD operations
	Test-ServiceUnit $resourceGroupName $location $artifactSource $serviceTopology $getResponse

	# Test Set-Service
	$getResponse.TargetSubscriptionId = "29843263-a568-4db8-899f-10977b9d5c7b"
	$updatedService = Set-AzDeploymentManagerService $getResponse

	Validate-Service $updatedService $resourceGroupName $location $serviceTopologyName $serviceName $targetLocation $getResponse.TargetSubscriptionId

	# Test List Services
	$service2Name = $resourceGroupName + "Service2"
	$service2 = New-AzDeploymentManagerService -ResourceGroupName $resourceGroupName -Location $location -Name $service2Name -ServiceTopologyObject $serviceTopology -TargetLocation $targetLocation -TargetSubscriptionId $subscriptionId

	$services = Get-AzDeploymentManagerService -ResourceGroupName $resourceGroupName -ServiceTopologyName $serviceTopology.Name
	Assert-True { $services.Count -ge 2 }
	$selectedService = $services | Where-Object {$_.Name -eq $service2Name }
	Assert-NotNull $selectedService "Created service not returned in list"
	Validate-Service $selectedService $resourceGroupName $location $serviceTopologyName $service2Name $targetLocation $subscriptionId

	# Test Remove-Service
	Remove-AzDeploymentManagerService -ResourceGroupName $resourceGroupName -Name $serviceName -ServiceTopologyName $serviceTopology.Name
	Remove-AzDeploymentManagerService -ResourceGroupName $resourceGroupName -Name $service2Name -ServiceTopologyName $serviceTopology.Name

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
		Assert-AreEqual $serviceName $service.Name
		Assert-AreEqual $serviceTopologyName $service.ServiceTopologyName
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

	$serviceUnitName = $resourceGroupName  + "ServiceUnit"
	$deploymentMode = "Incremental"

	$serviceUnit = New-AzDeploymentManagerServiceUnit `
		-ResourceGroupName $resourceGroupName `
		-Location $location `
		-ServiceTopologyObject $serviceTopology `
		-ServiceName $service.Name `
		-Name $serviceUnitName `
		-TargetResourceGroup $resourceGroupName `
		-DeploymentMode $deploymentMode `
		-ParametersArtifactSourceRelativePath $global:parametersFileName `
		-TemplateArtifactSourceRelativePath $global:templateFileName

	Validate-ServiceUnit $serviceUnit $resourceGroupName $location $serviceTopology.Name $service.Name $serviceUnitName $resourceGroupName $deploymentMode $global:templateFileName $global:parametersFileName

	$getResponse = Get-AzDeploymentManagerServiceUnit  `
		-ResourceGroupName $resourceGroupName  `
		-ServiceTopologyName $serviceTopology.Name `
		-ServiceName $serviceName `
		-Name $serviceUnitName

	Validate-ServiceUnit $getResponse $resourceGroupName $location $serviceTopology.Name $service.Name $serviceUnitName $resourceGroupName $deploymentMode $global:templateFileName $global:parametersFileName

	# Test rollout CRUD operations
		# Create a service unit with invalid parameters file for testing restart-rollout scenari
		$invalidServiceUnitName = $resourceGroupName + "InvalidServiceUnit"

		$invalidServiceUnit = New-AzDeploymentManagerServiceUnit   `
			-ResourceGroupName $resourceGroupName  `
			-Location $location  `
			-ServiceTopologyObject $serviceTopology  `
			-ServiceName $service.Name  `
			-Name $invalidServiceUnitName `
			-TargetResourceGroup $resourceGroupName `
			-DeploymentMode $deploymentMode `
			-ParametersArtifactSourceRelativePath $global:invalidParametersFileName `
			-TemplateArtifactSourceRelativePath $global:templateFileName
		Validate-ServiceUnit $invalidServiceUnit $resourceGroupName $location $serviceTopology.Name $service.Name $invalidServiceUnitName $resourceGroupName $deploymentMode $global:templateFileName $global:invalidParametersFileName

		# Test Step operations and rollout CRUD operations that depend on Service Units
		Test-Steps $resourceGroupName $location $serviceTopology $artifactSource $serviceUnit $invalidServiceUnit

	# Test Set-ServiceUnit
	$getResponse.DeploymentMode = "Complete"
	$getResponse.ParametersArtifactSourceRelativePath = $global:parametersCopyFileName
	$getResponse.TemplateArtifactSourceRelativePath = $global:templateCopyFileName

	$updatedServiceUnit = Set-AzDeploymentManagerServiceUnit $getResponse

	Validate-ServiceUnit $updatedServiceUnit $resourceGroupName $location $serviceTopology.Name $service.Name $serviceUnitName $resourceGroupName $getResponse.DeploymentMode $getResponse.TemplateArtifactSourceRelativePath $getResponse.ParametersArtifactSourceRelativePath

	# Test List Service Units
	$serviceUnits = Get-AzDeploymentManagerServiceUnit  `
		-ResourceGroupName $resourceGroupName  `
		-ServiceTopologyName $serviceTopology.Name `
		-ServiceName $serviceName 
	Assert-True { $serviceUnits.Count -ge 2 }
	$selectedServiceUnit = $serviceUnits | Where-Object {$_.Name -eq $serviceUnitName}
	Assert-NotNull $selectedServiceUnit "Created service unit not returned in list"
	Validate-ServiceUnit $selectedServiceUnit $resourceGroupName $location $serviceTopology.Name $service.Name $serviceUnitName $resourceGroupName $getResponse.DeploymentMode $getResponse.TemplateArtifactSourceRelativePath $getResponse.ParametersArtifactSourceRelativePath

	# Test Remove-ServiceUnit
	Remove-AzDeploymentManagerServiceUnit -ResourceGroupName $resourceGroupName -ServiceTopologyName $serviceTopology.Name -ServiceName $service.Name -Name $serviceUnitName

	# Remove second service unit created for failure rollout case
	Remove-AzDeploymentManagerServiceUnit -ResourceGroupName $resourceGroupName -ServiceTopologyName $serviceTopology.Name -ServiceName $service.Name -Name $invalidServiceUnitName

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
	$serviceUnit,
	$invalidServiceUnit)

	$stepName = "WaitStep"
	$duration = "PT5M"
	$updatedDuration = "PT10M"

	$step = New-AzDeploymentManagerStep -Name $stepName -ResourceGroupName $resourceGroupName -Location $location -Duration $duration
	Validate-Step $step $stepName $location $resourceGroupName $duration

	$getResponse = Get-AzDeploymentManagerStep -ResourceGroupName $resourceGroupName -Name $stepName
	Validate-Step $getResponse $stepName $location $resourceGroupName $duration

	Test-Rollout $resourceGroupName $location $serviceTopology $artifactSource $serviceUnit $invalidServiceUnit $step

	# Test Set-Step
	$getResponse.StepProperties.Duration = $updatedDuration

	$updatedStep = Set-AzDeploymentManagerStep $getResponse
	Validate-Step $updatedStep $stepName $location $resourceGroupName $updatedDuration

	# Test Health Check step
	Test-HealthCheckStep $resourceGroupName $location

	# Test Remove-Step 
	Remove-AzDeploymentManagerStep -ResourceGroupName $resourceGroupName -Name $stepName
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
		Assert-AreEqual $resourceGroupName $step.ResourceGroupName
		Assert-AreEqual $stepName  $step.Name
		Assert-AreEqual $duration  $step.StepProperties.Duration
}

function Test-HealthCheckStep
{
    param
    (
    $resourceGroupName,
    $location)

	$stepName = "RestHealthCheckStep"
	$updatedHealthyStateDuration = "PT60M"

	$healthCheckStepProperties = Get-Content -Raw -Path $global:restHealthCheckPropertiesFilePath | ConvertFrom-Json
	$step = New-AzDeploymentManagerStep -Name $stepName -ResourceGroupName $resourceGroupName -Location $location -HealthCheckPropertiesFile $global:restHealthCheckPropertiesFilePath
	Validate-RestHealthCheckStep $step $stepName $location $resourceGroupName $healthCheckStepProperties

	$getResponse = Get-AzDeploymentManagerStep -ResourceGroupName $resourceGroupName -Name $stepName
	Validate-RestHealthCheckStep $getResponse $stepName $location $resourceGroupName $healthCheckStepProperties

	# Test Set-Step
	$getResponse.StepProperties.Attributes.HealthyStateDuration = $updatedHealthyStateDuration

	$updatedStep = Set-AzDeploymentManagerStep $getResponse
	Validate-RestHealthCheckStep $updatedStep $stepName $location $resourceGroupName $getResponse.StepProperties

	# Test creating step with healthcheck properties
	$step2Name = "RestHealthCheckStep2"
	$step = New-AzDeploymentManagerStep -Name $step2Name -ResourceGroupName $resourceGroupName -Location $location -HealthCheckProperties $getResponse.StepProperties
	Validate-RestHealthCheckStep $step $step2Name $location $resourceGroupName $getResponse.StepProperties

	# Test list steps
	$steps = Get-AzDeploymentManagerStep -ResourceGroupName $resourceGroupName
	Assert-True { $steps.Count -ge 2 }
	$selectedStep = $steps | Where-Object {$_.Name -eq $stepName}
	Assert-NotNull $selectedStep "Created step not returned in list"

	# Test Remove-Step 
	Remove-AzDeploymentManagerStep -ResourceGroupName $resourceGroupName -Name $stepName
	Remove-AzDeploymentManagerStep -ResourceGroupName $resourceGroupName -Name $step2Name
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

function Validate-RestHealthCheckStep
{
    param
    (
    $step,
    $stepName,
    $location,
	$resourceGroupName,
	$healthCheckStepProperties)

		Assert-NotNull $step "Created step is null"
		Assert-AreEqual $resourceGroupName $step.ResourceGroupName
		Assert-AreEqual $stepName  $step.Name

		Assert-NotNull $step.StepProperties "Step properties is null in the created health check step"
		Assert-NotNull $step.StepProperties.Attributes "Attributes in the StepProperties are null in the created health check step"
		Assert-AreEqual $step.StepProperties.Attributes.WaitDuration $healthCheckStepProperties.Attributes.WaitDuration
		Assert-AreEqual $step.StepProperties.Attributes.MaxElasticDuration $healthCheckStepProperties.Attributes.MaxElasticDuration
		Assert-AreEqual $step.StepProperties.Attributes.HealthyStateDuration $healthCheckStepProperties.Attributes.HealthyStateDuration

		Assert-AreEqual $step.StepProperties.Attributes.HealthChecks.Count $healthCheckStepProperties.Attributes.HealthChecks.Count

		$refHealthCheck = $healthCheckStepProperties.Attributes.HealthChecks[0]
		$selectedHealthCheck = $step.StepProperties.Attributes.HealthChecks | Where-Object {$_.Name -eq $refHealthCheck.Name}
		Assert-NotNull $selectedHealthCheck "Rest Health check isn't found in the step properties"

		Assert-AreEqual $refHealthCheck.Request.Method $selectedHealthCheck.Request.Method
		Assert-AreEqual $refHealthCheck.Request.Uri $selectedHealthCheck.Request.Uri
		Assert-AreEqual $refHealthCheck.Request.Authentication.Name $selectedHealthCheck.Request.Authentication.Name
		Assert-AreEqual $refHealthCheck.Request.Authentication.InProperty $selectedHealthCheck.Request.Authentication.InProperty
		Assert-AreEqual $refHealthCheck.Request.Authentication.Value $selectedHealthCheck.Request.Authentication.Value

		Assert-AreEqual $refHealthCheck.Response.Regex.MatchQuantifier $selectedHealthCheck.Response.Regex.MatchQuantifier
}

function Test-Rollout
{
    param
    (
    $resourceGroupName,
    $location,
	$serviceTopology,
	$artifactSource,
	$serviceUnit,
	$invalidServiceUnit,
	$step)

	$rolloutName = $resourceGroupName + "Rollout"
	$failedRolloutName = $resourceGroupName + "InvalidRollout"

	Replace-RolloutPlaceholders $rolloutName $userAssignedIdentity $serviceTopology.Id $artifactSource.Id $step.Id $serviceUnit.Id $global:createRolloutTemplate

	$deployment = New-AzResourceGroupDeployment -Name $rolloutName -ResourceGroupName $resourceGroupName -TemplateFile $global:createRolloutTemplate

	$getResponse = Get-AzDeploymentManagerRollout -ResourceGroupName $resourceGroupName -Name $rolloutName
	Validate-Rollout $getResponse $resourceGroupName $location $rolloutName @('Running') $serviceTopology $artifactSource

	# Test Stop-Rollout
	$canceledRollout = Stop-AzDeploymentManagerRollout -InputObject $getResponse -Force
	Validate-Rollout $canceledRollout $resourceGroupName $location $rolloutName @('Canceling', 'Canceled') $serviceTopology $artifactSource

	# Wait for rollout to finish
	while ($canceledRollout.Status -eq "Canceling")
	{
		Start-TestSleep -Seconds 120
		$canceledRollout = Get-AzDeploymentManagerRollout -ResourceGroupName $resourceGroupName -Name $rolloutName
	}

	Assert-AreEqual "Canceled" $canceledRollout.Status

	Replace-RolloutPlaceholders $failedRolloutName $userAssignedIdentity $serviceTopology.Id $artifactSource.Id $step.Id $invalidServiceUnit.Id $global:failureCreateRolloutTemplate

	$failedDeployment = New-AzResourceGroupDeployment -Name $failedRolloutName -ResourceGroupName $resourceGroupName -TemplateFile $global:failureCreateRolloutTemplate

	$ErrorActionPreference = "SilentlyContinue"
	$Error.Clear()
	$failedRollout = Get-AzDeploymentManagerRollout -ResourceGroupName $resourceGroupName -Name $failedRolloutName 2>$null

	# Wait for the invalid rollout to fail
	while ($failedRollout.Status -eq "Running")
	{
		Start-TestSleep -Seconds 60
		$failedRollout = Get-AzDeploymentManagerRollout -ResourceGroupName $resourceGroupName -Name $failedRolloutName 2>$null
	}

	$Error.Clear()
	Assert-AreEqual "Failed" $failedRollout.Status

	$restartRollout = Restart-AzDeploymentManagerRollout -ResourceGroupName $resourceGroupName -Name $failedRolloutName -SkipSucceeded
	Validate-Rollout $restartRollout $resourceGroupName $location $failedRolloutName @('Running') $serviceTopology $artifactSource $true 1

	# Test list rollouts
	$rollouts = Get-AzDeploymentManagerRollout -ResourceGroupName $resourceGroupName
	Assert-True { $rollouts.Count -ge 2 }
	$selectedRollout = $rollouts | Where-Object {$_.Name -eq $rolloutName}
	Assert-NotNull $selectedRollout "Created rollout not returned in list"

	Remove-AzDeploymentManagerRollout -ResourceGroupName $resourceGroupName -Name $rolloutName
	$getResponse = Get-AzDeploymentManagerRollout -ResourceGroupName $resourceGroupName  -Name $rolloutName
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
	$storageAccountName,
    $artifactSourceName,
	$setupContainer)

	# Artifacts setup information
	$artifactRoot = "ScenarioTests\ArtifactRoot"
	$containerName = "artifacts"

	$sasKeyForContainer = ""
	Get-SasForContainer $resourceGroupName  $storageAccountName $containerName $artifactRoot $setupContainer ([ref]$sasKeyForContainer)
    $artifactSource = New-AzDeploymentManagerArtifactSource -ResourceGroupName $resourceGroupName -Name $artifactSourceName -Location $location -SasUri $sasKeyForContainer -ArtifactRoot $artifactRoot

    Assert-AreEqual $artifactSourceName $artifactSource.Name
    Assert-AreEqual $resourceGroupName $artifactSource.ResourceGroupName
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
	$artifactRoot,
	$setupContainer,
    [ref] $sasKeyForContainer
    )
    if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback)
    {
		if ($setupContainer -eq $true)
		{
			$storageAccount = New-AzureRmStorageAccount -ResourceGroupName $resourceGroupName -Name $storageName -Location "Central US" 
			Assert-NotNull $storageAccount
		}

        # Get storage account context
        $storageAccountContext = New-AzStorageContext -StorageAccountName $storageName -StorageAccountKey (Get-AzStorageAccountKey -ResourceGroupName $resourceGroupName -Name $storageName).Value[0]

		if ($setupContainer -eq $true)
		{
			Setup-StorageContainerForTest $resourceGroupName $storageName $containerName $artifactRoot $storageAccountContext
		}

        # Get SAS token for container
        $sasKeyForContainer.Value = New-AzStorageContainerSASToken -Name $storageContainerName -Permission "rl" -StartTime ([System.DateTime]::Now).AddHours(-20) -ExpiryTime ([System.DateTime]::Now).AddHours(48) -Context $storageAccountContext -FullUri
    }
    else
    {
        $sasKeyForContainer.Value = "dummysasforcontainer"
    }
}

function Setup-StorageContainerForTest
{
    param
    (
    $resourceGroupName,
    $storageName,
    $storageContainerName,
	$artifactRoot,
	$storageAccountContext)

    if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback)
    {
		$stgAcctForTemplate = $resourceGroupName + "stgtemplate"
		$storageAcountReplacementSymbol = "__STORAGEACCOUNTNAME__"

		Replace-String $storageAcountReplacementSymbol $stgAcctForTemplate $global:parametersArtifactSourceRelativePath
		Replace-String $storageAcountReplacementSymbol $stgAcctForTemplate $global:templateArtifactSourceRelativePath
		Replace-String $storageAcountReplacementSymbol $stgAcctForTemplate $global:parametersCopyArtifactSourceRelativePath
		Replace-String $storageAcountReplacementSymbol $stgAcctForTemplate $global:templateCopyArtifactSourceRelativePath

		$container = New-AzStorageContainer -Name $storageContainerName -Context $storageAccountContext

		Set-AzStorageBlobContent -Container $storageContainerName -Context $storageAccountContext -File $global:parametersArtifactSourceRelativePath -Blob $global:parametersArtifactSourceRelativePath
		Set-AzStorageBlobContent -Container $storageContainerName -Context $storageAccountContext -File $global:parametersCopyArtifactSourceRelativePath -Blob $global:parametersCopyArtifactSourceRelativePath
		Set-AzStorageBlobContent -Container $storageContainerName -Context $storageAccountContext -File $global:templateArtifactSourceRelativePath -Blob $global:templateArtifactSourceRelativePath
		Set-AzStorageBlobContent -Container $storageContainerName -Context $storageAccountContext -File $global:templateCopyArtifactSourceRelativePath -Blob $global:templateCopyArtifactSourceRelativePath
		Set-AzStorageBlobContent -Container $storageContainerName -Context $storageAccountContext -File $global:invalidParametersArtifactSourceRelativePath -Blob $global:invalidParametersArtifactSourceRelativePath
    }
}

function Replace-RolloutPlaceholders
{
	param(
		$rolloutName,
		$userAssignedIdentity,
		$targetServiceTopologyId,
		$artifactSourceId,
		$stepId,
		$serviceUnitId,
		$file
	)

    if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback)
	{
		Replace-String "__ROLLOUT_NAME__" $rolloutName $file
		Replace-String "__TARGET_SERVICE_TOPOLOGY__" $targetServiceTopologyId $file
		Replace-String "__ARTIFACT_SOURCE_ID__" $artifactSourceId $file
		Replace-String "__STEP_ID__" $stepId $file
		Replace-String "__SERVICE_UNIT_ID__" $serviceUnitId $file
	}
}

function Replace-String
{
	param (
	$replacementSymbol,
	$replacementValue,
	$file)

    if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback)
	{
		$content = Get-Content($file)
		$content = $content.replace($replacementSymbol, $replacementValue)
		$content | out-file $file -encoding UTF8
	}
}

function Set-ManagedIdentity
{
	param(
		$subscriptionId,
		$resourceGroupName
	)

    if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback)
	{
		# Create identity for rollouts
		$identityName = $resourceGroupName + "Identity"
		$identityLocation = Get-ProviderLocation "Microsoft.ManagedIdentity/userAssignedIdentities"
		$identity = New-AzUserAssignedIdentity -ResourceGroupName $resourceGroupName -Name $identityName -Location $identityLocation
		$identityScope = "/subscriptions/" + $subscriptionId

		# Allow MSI to percolate
		Start-TestSleep -Seconds 120
		$roleAssignment = $null
		try
		{
			New-AzRoleAssignment -ObjectId $identity.PrincipalId -RoleDefinitionName "Contributor" -Scope $identityScope
		}
		catch 
		{
			# Swallow failure after creating assignment in graph operation as cmdlet fails while making a graph call with error
			# "The request did not have a subscription or a valid tenant level resource provider". The graph call is made after creating the assignment.
			$errorString = $_.Exception.Message
			Write-Verbose $errorString
		}

		Start-TestSleep -Seconds 30
		Replace-String "__USER_ASSIGNED_IDENTITY__" $identity.Id $global:createRolloutTemplate
		Replace-String "__USER_ASSIGNED_IDENTITY__" $identity.Id $global:failureCreateRolloutTemplate
	}
}
