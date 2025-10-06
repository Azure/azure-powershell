if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzFunctionApp'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzFunctionApp.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzFunctionApp' {

    It "Does not delete the function app plan if it is the last app in the plan" {

        $planName = $env.functionAppTestPlanName2
        Write-Verbose "Plan name: $planName" -Verbose
        $appName = $env.functionNamePowerShellNew4
        Write-Verbose "App name: $appName" -Verbose
        $resourceGroupName = $env.resourceGroupNameWindowsPremium
        Write-Verbose "Resource group name: $resourceGroupName" -Verbose
        $location = 'centralus'
        Write-Verbose "Location: $location" -Verbose
        $storageAccountName = $env.storageAccountWindows
        Write-Verbose "Storage account name: $storageAccountName" -Verbose
        $workerType = "Windows"
        Write-Verbose "Worker type: $workertype" -Verbose

        $minimumWorkerCount = 1
        Write-Verbose "Minimum worker count: $minimumWorkerCount" -Verbose
        $maxBurst = 3
        Write-Verbose "Maximum burst: $maxBurst" -Verbose
        $sku = "EP1"
        Write-Verbose "SKU: $sku" -Verbose

        try
        {
            Write-Verbose "Creating function app plan '$planName'" -Verbose
            New-AzFunctionAppPlan -Name $planName `
                                  -ResourceGroupName $resourceGroupName `
                                  -WorkerType $workerType `
                                  -MinimumWorkerCount $minimumWorkerCount `
                                  -MaximumWorkerCount $maxBurst `
                                  -Location $location `
                                  -Sku $sku

            Write-Verbose "Creating function app '$appName'" -Verbose
            New-AzFunctionApp -Name $appName `
                              -ResourceGroupName $resourceGroupName `
                              -PlanName $planName `
                              -StorageAccount $storageAccountName  `
                              -Runtime PowerShell `
                              -RuntimeVersion 7.4 `
                              -FunctionsVersion 4

            Write-Verbose "Validate function app properties" -Verbose
            $functionApp = Get-AzFunctionApp -Name $appName -ResourceGroupName $resourceGroupName
            $functionApp.OSType | Should -Be "Windows"
            $functionApp.Runtime | Should -Be "PowerShell"

            Write-Verbose "Remove the function app" -Verbose
            Remove-AzFunctionApp -InputObject $functionApp -Force

            Write-Verbose "Validate that the function app plan exists" -Verbose
            $appPlan = Get-AzFunctionAppPlan -Name $planName -ResourceGroupName $resourceGroupName
            $appPlan.Name | Should -Be $planName

        }
        finally
        {
            Write-Verbose "Test case clean up" -Verbose
            $app = Get-AzFunctionApp -Name $appName -ResourceGroupName $resourceGroupName -ErrorAction SilentlyContinue
            if ($app)
            {
                Remove-AzFunctionApp -InputObject $app -Force -ErrorAction SilentlyContinue
            }

            $plan = Get-AzFunctionAppPlan -Name $planName -ResourceGroupName $resourceGroupName -ErrorAction SilentlyContinue
            if ($plan)
            {
                Remove-AzFunctionAppPlan -InputObject $plan -Force -ErrorAction SilentlyContinue
            }
        }
    }
}
