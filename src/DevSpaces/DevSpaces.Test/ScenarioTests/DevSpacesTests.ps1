<#
.SYNOPSIS
Test DevSpaces stuff
#>
function Test-AzureRmDevSpacesController
{
    # Manual Setup. Create these resource maunally in the subscription
    $resourceGroupName = "rgps4504"
    $kubeClusterName = "kubeps5496"

    # Setup
    $devSpacesName = Get-DevSpacesControllerName
    $tagKey =  Get-DevSpacesControllerTagKey
    $tagValue =  Get-DevSpacesControllerTagValue

    $referenceObject = @{}
    $referenceObject.Name = $devSpacesName
    $referenceObject.ResourceGroupName = $resourceGroupName
    $referenceObject.ProvisioningState = "Succeeded"
    $referenceObject.Location = "eastus"

    #Create new dev spaces
    $devSpaceController = New-AzureRmDevSpacesController -ResourceGroupName $resourceGroupName -Name $devSpacesName -TargetClusterName $kubeClusterName -TargetResourceGroupName $resourceGroupName
    Assert-AreEqualPSController $referenceObject $devSpaceController

    #Get dev spaces
    $devSpaceController = Get-AzureRmDevSpacesController -ResourceGroupName $resourceGroupName -Name $devSpacesName
    Assert-AreEqualPSController $referenceObject $devSpaceController

    #update dev spaces
    $devSpaceControllerUpdated = $devSpaceController | Update-AzureRmDevSpacesController -Tag @{ $tagKey=$tagValue}
    Assert-AreEqualPSController $referenceObject $devSpaceControllerUpdated
    $tag = Get-AzureRmTag -Name $tagKey
    $tagValueExist = $tag.Values.Name -Contains $tagValue
    Assert-AreEqual "True" $tagValueExist

    #Delete Dev Spaces
    $deletedAzureRmDevSpace = $devSpaceController | Remove-AzureRmDevSpacesController -PassThru
    Assert-AreEqual "True" $deletedAzureRmDevSpace

    #Get dev spaces to verify delete
    $azureRmDevSpaces = Get-AzureRmDevSpacesController -ResourceGroupName $resourceGroupName
    Assert-Null $azureRmDevSpaces    
}

<#
.SYNOPSIS
Test DevSpaces stuff with AsJob Parameter
#>
function Test-TestAzureDevSpacesAsJobParameter
{
    # Manual Setup. Create these resource maunally in the subscription
    $resourceGroupName = "rgps4505"
    $kubeClusterName = "kubeps5497"

    # Setup
    $devSpacesName = Get-DevSpacesControllerName
    $tagKey =  Get-DevSpacesControllerTagKey
    $tagValue =  Get-DevSpacesControllerTagValue

    $referenceObject = @{}
    $referenceObject.Name = $devSpacesName
    $referenceObject.ResourceGroupName = $resourceGroupName
    $referenceObject.ProvisioningState = "Succeeded"
    $referenceObject.Location = "eastus"

	$job = New-AzureRmDevSpacesController -ResourceGroupName $resourceGroupName -Name $devSpacesName -TargetClusterName $kubeClusterName -TargetResourceGroupName $resourceGroupName -AsJob
	$job | Wait-Job
	$devSpaceController = $job | Receive-Job
	Assert-AreEqualPSController $referenceObject $devSpaceController

	$deletedJob = $devSpaceController | Remove-AzureRmDevSpacesController -PassThru -AsJob
	$deletedJob | Wait-Job
	$deletedAzureRmDevSpace = $deletedJob | Receive-Job
	Assert-AreEqual "True" $deletedAzureRmDevSpace

    #Get dev spaces to verify delete
    $azureRmDevSpaces = Get-AzureRmDevSpacesController -ResourceGroupName $resourceGroupName
    Assert-Null $azureRmDevSpaces
}
