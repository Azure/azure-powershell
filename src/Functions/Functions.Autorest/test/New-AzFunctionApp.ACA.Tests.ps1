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


Describe 'New-AzFunctionApp ACA Tests' -Tag 'LiveOnly' {
    
    BeforeAll {

        $resourceGroupNameACA = $env.resourceGroupNameACA
        $locationACA = $env.locationACA
        $storageAccountNameACA = $env.storageAccountNameACA
        $workSpaceACAName = $env.workSpaceACAName
        $environmentACAName = $env.environmentACAName
        $acaTestRunId = $env.acaTestRunId

        Write-Host "acaTestRunId: $($acaTestRunId)"
        Write-Host "resourceGroupNameACA: $($resourceGroupNameACA)"
        Write-Host "locationACA: $($locationACA)"
        Write-Host "storageAccountNameACA: $($storageAccountNameACA)"
        Write-Host "workSpaceACAName: $($workSpaceACAName)"
        Write-Host "environmentACAName: $($environmentACAName)"

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

    It "Creating a function app ACA should throw an error when ResourceCpu is specified without ResourceMemory." {

        $functionAppACAName = "test1appaca1" + $acaTestRunId
        Write-Host "functionAppACAName: $($functionAppACAName)"

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

        $functionAppACAName = "test1appaca2" + $acaTestRunId
        Write-Host "functionAppACAName: $($functionAppACAName)"

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

        $functionAppACAName = "test1appaca3" + $acaTestRunId
        Write-Host "functionAppACAName: $($functionAppACAName)"

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

        $functionAppACAName = "test1appaca4" + $acaTestRunId
        Write-Host "functionAppACAName: $($functionAppACAName)"

        $expectedLinuxFxVersion = "DOCKER|mcr.microsoft.com/azure-functions/dotnet8-quickstart-demo:1.0"

        Write-Verbose "Resource group name: $resourceGroupNameACA" -Verbose
        Write-Verbose "Storage account name: $storageAccountNameACA" -Verbose
        Write-Verbose "Environment name: $environmentACAName" -Verbose
        Write-Verbose "Workload profile name: $($workloadProfile.Name)" -Verbose

        try
        {
            Write-Verbose "Creating function app ACA..." -Verbose
            New-AzFunctionApp -ResourceGroupName $resourceGroupNameACA `
                              -Name $functionAppACAName `
                              -StorageAccountName $storageAccountNameACA `
                              -Environment $environmentACAName `
                              -WorkloadProfileName $workloadProfile.Name

            Write-Verbose "Retrieving function app ACA..." -Verbose
            $functionApp = Get-AzFunctionApp -Name $functionAppACAName -ResourceGroupName $resourceGroupNameACA

            Write-Verbose "Function app ACA retrieved. Validating properties..." -Verbose
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

        $functionAppACAName = "test1appaca5" + $acaTestRunId
        Write-Host "functionAppACAName: $($functionAppACAName)"

        $expectedLinuxFxVersion = "DOCKER|mcr.microsoft.com/azure-functions/dotnet8-quickstart-demo:1.0"
        $resourceCpu = 1
        $resourceMemory = "2.0Gi"
        $scaleMinReplica = 1
        $scaleMaxReplica = 3

        $expectedResourceConfigMemory = ([double]::Parse($resourceMemory.Substring(0, $resourceMemory.Length - 2))).ToString() + "Gi"

        Write-Verbose "Resource group name: $resourceGroupNameACA" -Verbose
        Write-Verbose "Storage account name: $storageAccountNameACA" -Verbose
        Write-Verbose "Environment name: $environmentACAName" -Verbose
        Write-Verbose "Workload profile name: $($workloadProfile.Name)" -Verbose
        Write-Verbose "Resource CPU: $resourceCpu" -Verbose
        Write-Verbose "Resource Memory: $resourceMemory" -Verbose
        Write-Verbose "Scale minimum replica: $scaleMinReplica" -Verbose
        Write-Verbose "Scale maximum replica: $scaleMaxReplica" -Verbose

        try
        {
            Write-Verbose "Creating function app ACA..." -Verbose
            New-AzFunctionApp -ResourceGroupName $resourceGroupNameACA `
                              -Name $functionAppACAName `
                              -StorageAccountName $storageAccountNameACA `
                              -Environment $environmentACAName `
                              -WorkloadProfileName $workloadProfile.Name `
                              -ResourceCpu $resourceCpu `
                              -ResourceMemory $resourceMemory `
                              -ScaleMinReplica $scaleMinReplica `
                              -ScaleMaxReplica $scaleMaxReplica

            Write-Verbose "Retrieving function app ACA..." -Verbose
            $functionApp = Get-AzFunctionApp -Name $functionAppACAName -ResourceGroupName $resourceGroupNameACA

            Write-Verbose "Function app ACA retrieved. Validating properties..." -Verbose
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
