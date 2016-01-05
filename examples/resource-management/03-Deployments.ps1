Param(
  [string]$groupName,
  [string]$location
)

Write-Host "=== Provisioning Deployments in Azure ==="

Write-Host "1. Create a new resource group"
New-AzureRmResourceGroup -Name $groupName -Location $location

Write-Host "2. Test template"
$siteName = Get-ResourceName
$list = Test-AzureResourceGroupTemplate -ResourceGroupName $groupName -TemplateFile sampleTemplate.json -siteName $siteName -hostingPlanName $siteName -siteLocation $location -sku Free -workerSize 0
Write-Host $list
# Assert
Assert-AreEqual 0 @($list).Count

Write-Host "3. Provisioning Deployment"
$deployment = New-AzureRmResourceGroupDeployment -Name $siteName -ResourceGroupName $groupName -TemplateFile sampleTemplate.json -TemplateParameterFile sampleTemplateParams.json
Write-Host $deployment
# Assert
Assert-AreEqual Succeeded $deployment.ProvisioningState


