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

        $planName = $env.functionAppTestPlanName
        $functionName = $env.functionNamePowerShell
        $location = 'centralus'
        $minimumWorkerCount = 1
        $maxBurst = 3
        $sku = "EP1"

        try
        {
            Write-Verbose "Creating function app plan '$planName'" -Verbose
            New-AzFunctionAppPlan -Name $planName `
                                  -ResourceGroupName $env.resourceGroupNameWindowsPremium `
                                  -WorkerType "Windows" `
                                  -MinimumWorkerCount $minimumWorkerCount `
                                  -MaximumWorkerCount $maxBurst `
                                  -Location $location `
                                  -Sku $sku

            Write-Verbose "Creating function app '$functionName'" -Verbose
            New-AzFunctionApp -Name $functionName `
                              -ResourceGroupName $env.resourceGroupNameWindowsPremium `
                              -PlanName $planName `
                              -StorageAccount $env.storageAccountWindows  `
                              -Runtime PowerShell `
                              -RuntimeVersion 7.2 `
                              -FunctionsVersion 4

            Write-Verbose "Validate function app properties" -Verbose
            $functionApp = Get-AzFunctionApp -Name $functionName -ResourceGroupName $env.resourceGroupNameWindowsPremium
            $functionApp.OSType | Should -Be "Windows"
            $functionApp.Runtime | Should -Be "PowerShell"

            Write-Verbose "Remove the function app" -Verbose
            Remove-AzFunctionApp -InputObject $functionApp -Force

            Write-Verbose "Validate that the function app plan exists" -Verbose
            $appPlan = Get-AzFunctionAppPlan -Name $planName -ResourceGroupName $env.resourceGroupNameWindowsPremium -ErrorAction SilentlyContinue
            $appPlan.Name | Should -Be $planName

        }
        finally
        {
            Write-Verbose "Test case clean up" -Verbose
            $app = Get-AzFunctionApp -Name $functionName -ResourceGroupName $env.resourceGroupNameWindowsPremium -ErrorAction SilentlyContinue
            if ($app)
            {
                Remove-AzFunctionApp -InputObject $app -Force -ErrorAction SilentlyContinue
            }

            $plan = Get-AzFunctionAppPlan -Name $planName -ResourceGroupName $env.resourceGroupNameWindowsPremium -ErrorAction SilentlyContinue
            if ($plan)
            {
                Remove-AzFunctionAppPlan -InputObject $plan -Force -ErrorAction SilentlyContinue
            }
        }
    }
}
