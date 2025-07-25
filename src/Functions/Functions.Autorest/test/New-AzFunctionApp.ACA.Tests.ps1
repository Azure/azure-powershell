if(($null -eq $TestName) -or ($TestName -contains 'New-AzFunctionApp.ACA'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzFunctionApp.ACA.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}


Describe 'New-AzFunctionApp ACA Tests' -Tags 'LiveOnly' {
    
    BeforeAll {

        $resourceGroupNameACA = "Functions-ACA-Test-" + (GetRandomStringValue -len 4)
        $locationACA = "WestCentralUS"
        $storageAccountNameACA = "funcacastotorage" + (GetRandomStringValue -len 4)
        $workSpaceACAName = "workspace-azpstest" + (GetRandomStringValue -len 4)
        $environmentACAName = "azps-env-test" + (GetRandomStringValue -len 3)
        $functionAppACAName = "test1appaca" + (GetRandomStringValue -len 4)

        Write-Host "resourceGroupNameACA: $($resourceGroupNameACA)"
        Write-Host "locationACA: $($locationACA)"
        Write-Host "storageAccountNameACA: $($storageAccountNameACA)"
        Write-Host "workSpaceACAName: $($workSpaceACAName)"
        Write-Host "environmentACAName: $($environmentACAName)"
        Write-Host "functionAppACAName: $($functionAppACAName)"

        # Create test resources
        Write-Host ""
        Write-Host "Create resource group and storage account." -ForegroundColor Yellow
        New-AzResourceGroup -Name $resourceGroupNameACA -Location $locationACA 
        New-AzStorageAccount -Name $storageAccountNameACA -ResourceGroupName $resourceGroupNameACA -Location $locationACA -SkuName "Standard_GRS" | Out-Null
        
        Write-Host ""
        Write-Host "Create Log Analytics workspace." -ForegroundColor Yellow
        New-AzOperationalInsightsWorkspace -ResourceGroupName $resourceGroupNameACA `
                                           -Name $workSpaceACAName `
                                           -Sku PerGB2018 `
                                           -Location $locationACA `
                                           -PublicNetworkAccessForIngestion "Enabled" `
                                           -PublicNetworkAccessForQuery "Enabled" | Out-Null

        Write-Host ""
        Write-Host "Get Log Analytics workspace customer id and shared key." -ForegroundColor Yellow
        $customId = (Get-AzOperationalInsightsWorkspace -ResourceGroupName $resourceGroupNameACA -Name $workSpaceACAName).CustomerId
        $sharedKey = (Get-AzOperationalInsightsWorkspaceSharedKey -ResourceGroupName $resourceGroupNameACA -Name $workSpaceACAName).PrimarySharedKey
        $workloadProfile = New-AzContainerAppWorkloadProfileObject -Name "Consumption" -Type "Consumption"

        Write-Host ""
        Write-Host "Create managed environment." -ForegroundColor Yellow
        New-AzContainerAppManagedEnv -Name $environmentACAName `
                                     -ResourceGroupName $resourceGroupNameACA `
                                     -Location $locationACA `
                                     -AppLogConfigurationDestination "log-analytics" `
                                     -LogAnalyticConfigurationCustomerId $CustomId `
                                     -LogAnalyticConfigurationSharedKey $SharedKey `
                                     -VnetConfigurationInternal:$false `
                                     -WorkloadProfile $workloadProfile | Out-Null
    }

    AfterAll {
        
        Write-Host "Removing test resources." -ForegroundColor Yellow
        Remove-AzResourceGroup -Name $resourceGroupNameACA
    }

    It "Creating a function app ACA should throw an error when ResourceCpu is specified without ResourceMemory." {

        $result = {
            New-AzFunctionApp -ResourceGroupName $resourceGroupNameACA `
                              -Name $functionAppACAName `
                              -StorageAccountName $storageAccountNameACA `
                              -Environment $environmentACAName `
                              -WorkloadProfileName $workloadProfile.Name `
                              -ResourceCpu 1 `
                              -ScaleMinReplica 1 `
                              -ScaleMaxReplica 3 `
                              -WhatIf
        }

        $result | Should -Throw -ErrorId "ResourceMemoryNotSpecified"
    }

    It "Creating a function app ACA should throw an error when ResourceMemory is specified without ResourceCpu." {

        $result = {
            New-AzFunctionApp -ResourceGroupName $resourceGroupNameACA `
                              -Name $functionAppACAName `
                              -StorageAccountName $storageAccountNameACA `
                              -Environment $environmentACAName `
                              -WorkloadProfileName $workloadProfile.Name `
                              -ResourceMemory 2.0Gi `
                              -ScaleMinReplica 1 `
                              -ScaleMaxReplica 3 `
                              -WhatIf
        }
        
        $result | Should -Throw -ErrorId "ResourceCpuNotSpecified"
    }

    It "Creating a function app ACA should throw an error when ResourceMemory is not specified in Gi." {

        $result = {
            New-AzFunctionApp -ResourceGroupName $resourceGroupNameACA `
                              -Name $functionAppACAName `
                              -StorageAccountName $storageAccountNameACA `
                              -Environment $environmentACAName `
                              -WorkloadProfileName $workloadProfile.Name `
                              -ResourceCpu 1 `
                              -ResourceMemory 2.0 `
                              -ScaleMinReplica 1 `
                              -ScaleMaxReplica 3 `
                              -WhatIf
        }

        $result | Should -Throw -ErrorId "InvalidResourceMemory"
    }

    It "Creating a function app ACA with minimum required parameters should succeed." {

        $expectedLinuxFxVersion = "DOCKER|mcr.microsoft.com/azure-functions/dotnet8-quickstart-demo:1.0"

        try
        {
            New-AzFunctionApp -ResourceGroupName $resourceGroupNameACA `
                              -Name $functionAppACAName `
                              -StorageAccountName $storageAccountNameACA `
                              -Environment $environmentACAName `
                              -WorkloadProfileName $workloadProfile.Name

            $functionApp = Get-AzFunctionApp -Name $functionAppACAName -ResourceGroupName $resourceGroupNameACA
            $functionApp.OSType | Should -Be "Linux"
            $functionApp.Runtime | Should -Be "Container App"
            $functionApp.SiteConfig.LinuxFxVersion | Should -Be $expectedLinuxFxVersion
            $functionApp.ManagedEnvironmentId | Should Match $environmentACAName
            $functionApp.WorkloadProfileName | Should -match $workloadProfile.Name
        }
        finally
        {
            $functionApp = Get-AzFunctionApp -Name $functionAppACAName -ResourceGroupName $resourceGroupNameACA -ErrorAction SilentlyContinue
            if ($functionApp)
            {
                Remove-AzFunctionApp -InputObject $functionApp -Force -ErrorAction SilentlyContinue
            }
        }
    }

    It "Creating a function app ACA with all options should succeed." {

        $expectedLinuxFxVersion = "DOCKER|mcr.microsoft.com/azure-functions/dotnet8-quickstart-demo:1.0"
        $resourceCpu = 1
        $resourceMemory = "2.0Gi"
        $scaleMinReplica = 1
        $scaleMaxReplica = 3

        $expectedResourceConfigMemory = ([double]::Parse($resourceMemory.Substring(0, $resourceMemory.Length - 2))).ToString() + "Gi"

        try
        {
            New-AzFunctionApp -ResourceGroupName $resourceGroupNameACA `
                              -Name $functionAppACAName `
                              -StorageAccountName $storageAccountNameACA `
                              -Environment $environmentACAName `
                              -WorkloadProfileName $workloadProfile.Name `
                              -ResourceCpu $resourceCpu `
                              -ResourceMemory $resourceMemory `
                              -ScaleMinReplica $scaleMinReplica `
                              -ScaleMaxReplica $scaleMaxReplica

            $functionApp = Get-AzFunctionApp -Name $functionAppACAName -ResourceGroupName $resourceGroupNameACA
            $functionApp.OSType | Should -Be "Linux"
            $functionApp.Runtime | Should -Be "Container App"
            $functionApp.SiteConfig.LinuxFxVersion | Should -Be $expectedLinuxFxVersion
            $functionApp.ManagedEnvironmentId | Should Match $environmentACAName
            $functionApp.WorkloadProfileName | Should -match $workloadProfile.Name

            $functionApp.ResourceConfigCpu | Should -match $resourceCpu
            $functionApp.ResourceConfigMemory | Should -match $expectedResourceConfigMemory

            $functionApp.SiteConfig.MinimumElasticInstanceCount | Should -match $scaleMinReplica
            $functionApp.SiteConfig.FunctionAppScaleLimit  | Should -match $scaleMaxReplica
        }
        finally
        {
            $functionApp = Get-AzFunctionApp -Name $functionAppACAName -ResourceGroupName $resourceGroupNameACA -ErrorAction SilentlyContinue
            if ($functionApp)
            {
                Remove-AzFunctionApp -InputObject $functionApp -Force -ErrorAction SilentlyContinue
            }
        }
    }
}
