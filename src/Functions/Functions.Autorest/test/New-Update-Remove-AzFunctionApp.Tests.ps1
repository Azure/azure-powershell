$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-Update-Remove-AzFunctionApp.Tests.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzFunctionApp, Update-AzFunctionApp, and Remove-AzFunctionApp E2E' {

    BeforeAll {

        $planName = $env.planNameWorkerTypeWindows
        Write-Verbose "Plan name: $planName" -Verbose

        $resourceGroupName = $env.resourceGroupNameWindowsPremium
        Write-Verbose "Resource group name: $resourceGroupName" -Verbose

        $storageAccountName = $env.storageAccountWindows
        Write-Verbose "Storage account name: $storageAccountName" -Verbose

        $identityInfo = $env.identityInfo
        Write-Verbose "Identity id: $($identityInfo.Id | Out-String)" -Verbose

        $newApplInsights = $env.newApplInsights
        Write-Verbose "New Application Insights name: $($newApplInsights.Name | Out-String)" -Verbose

        $location = "centralus"
        Write-Verbose "Location: $location" -Verbose

        $tags = @{
            "MyTag1" = "MyTag1Value1"
            "MyTag2" = "MyTag1Value2"
        }
        Write-Verbose "Tags: $($tags | Out-String)" -Verbose
    }

    It "Validate New-AzFunctionAppPlan, Update-AzFunctionApp and Remove-AzFunctionApp" {

        try
        {
            Write-Verbose "Create function app with a SystemAssigned managed identity" -Verbose
            $appName = $env.functionNamePowerShell
            Write-Verbose "App name: $appName" -Verbose

            New-AzFunctionApp -Name $appName `
                              -ResourceGroupName $resourceGroupName `
                              -PlanName $planName `
                              -StorageAccount $storageAccountName `
                              -Runtime PowerShell `
                              -RuntimeVersion "7.2" `
                              -FunctionsVersion 4 `
                              -IdentityType SystemAssigned `
                              -Tag $tags

            $functionApp = Get-AzFunctionApp -Name $appName -ResourceGroupName $resourceGroupName
            Write-Verbose "FunctionApp retrieved. Validating properties" -Verbose
            $functionApp.OSType | Should -Be "Windows"
            $functionApp.Runtime | Should -Be "PowerShell"
            $functionApp.IdentityType | Should -Be "SystemAssigned"

            foreach ($tagName in $tags.Keys)
            {
                $functionApp.Tag.AdditionalProperties[$tagName] | Should -Be $tags[$tagName]
            }

            Write-Verbose "Create premium function app plan" -Verbose
            $newPlanName = $env.planNameWorkerTypeWindowsNew
            Write-Verbose "Updated planName: $newPlanName" -Verbose
            New-AzFunctionAppPlan -Name $newPlanName `
                                  -ResourceGroupName $resourceGroupName `
                                  -WorkerType "Windows" `
                                  -MinimumWorkerCount 1 `
                                  -MaximumWorkerCount 10 `
                                  -Location $location `
                                  -Sku EP1

            $plan = Get-AzFunctionAppPlan -Name $newPlanName -ResourceGroupName $resourceGroupName
            Write-Verbose "Plan retrieved. Validating properties" -Verbose
            $plan.WorkerType | Should -Be "Windows"
            $plan.SkuTier | Should -Be "ElasticPremium"
            $plan.SkuName | Should -Be "EP1"
            $plan.Location | Should -Be "Central US"
            $plan.Name | Should -Be $newPlanName

            Write-Verbose "Update function app plan hosting plan" -Verbose
            Update-AzFunctionApp -Name $appName -ResourceGroupName $resourceGroupName -PlanName $newPlanName -Force

            $functionApp = Get-AzFunctionApp -Name $appName -ResourceGroupName $resourceGroupName
            Write-Verbose "FunctionApp after plan update. Validate plan name" -Verbose
            $functionApp.AppServicePlan | Should -Be $newPlanName

            # Update test to use -InputObject when https://github.com/Azure/azure-powershell/issues/23266 is fixed
            # Update-AzFunctionApp -InputObject $functionApp -IdentityType None -Force
            # Update-AzFunctionApp -Name $appName -ResourceGroupName $resourceGroupName -IdentityType None -Force

            Write-Verbose "Update function -> remove SystemAssigned managed identity" -Verbose
            Update-AzFunctionApp -Name $appName -ResourceGroupName $resourceGroupName -IdentityType None -Force

            $functionApp = Get-AzFunctionApp -Name $appName -ResourceGroupName $resourceGroupName
            Write-Verbose "FunctionApp after identity removal. Validate IdentityType" -Verbose
            $functionApp.IdentityType | Should -Be $null

            Write-Verbose "Update function app ApplicationInsights via -ApplicationInsightsName" -Verbose
            $applicationInsightsName = $newApplInsights.Name
            Write-Verbose "New ApplicationInsights name: $applicationInsightsName" -Verbose
            Update-AzFunctionApp -Name $appName -ResourceGroupName $resourceGroupName -ApplicationInsightsName $applicationInsightsName -Force

            $applicationSettings = Get-AzFunctionAppSetting -Name $appName -ResourceGroupName $resourceGroupName
            Write-Verbose "FunctionAppSetting after update. Validate ApplicationInsights" -Verbose
            $applicationSettings["APPINSIGHTS_INSTRUMENTATIONKEY"] | Should -Be $newApplInsights.InstrumentationKey
        }
        finally
        {
            Write-Verbose "FunctionApp for cleanup." -Verbose
            $functionApp = Get-AzFunctionApp -Name $appName -ResourceGroupName $resourceGroupName -ErrorAction SilentlyContinue
            if ($functionApp) {
                Remove-AzFunctionApp -Name $appName -ResourceGroupName $resourceGroupName -Force -ErrorAction SilentlyContinue
            }

            $plan = Get-AzFunctionAppPlan -Name $newPlanName -ResourceGroupName $resourceGroupName -ErrorAction SilentlyContinue
            Write-Verbose "Plan for cleanup." -Verbose
            if ($plan)
            {
                Remove-AzFunctionAppPlan -Name $newPlanName -ResourceGroupName $resourceGroupName -Force -ErrorAction SilentlyContinue
            }
        }
    }

    It "Validate New-AzFunctionApp -AsJob, Update-AzFunctionApp -AsJob and Remove-AzFunctionApp" {

        try
        {
            Write-Verbose "Creating function app -AsJob" -Verbose
            $appName = $env.functionNamePowerShellNew1
            Write-Verbose "App name: $appName" -Verbose

            $functionAppJob = New-AzFunctionApp -Name $appName `
                                                -ResourceGroupName $resourceGroupName `
                                                -PlanName $planName `
                                                -StorageAccount $storageAccountName `
                                                -OSType "Windows" `
                                                -Runtime "PowerShell" `
                                                -RuntimeVersion 7.4 `
                                                -FunctionsVersion 4 `
                                                -AsJob

            Write-Verbose "Job completed. Validating result" -Verbose
            $result = WaitForJobToComplete -JobId $functionAppJob.Id
            $result.State | Should -Be "Completed"
            $result | Remove-Job -ErrorAction SilentlyContinue

            $functionApp = Get-AzFunctionApp -Name $appName -ResourceGroupName $resourceGroupName
            $functionApp.OSType | Should -Be "Windows"
            $functionApp.Runtime | Should -Be "PowerShell"
            $functionApp.AppServicePlan | Should -Be $planName

            Write-Verbose "Update function app -> enable a SystemAssigned managed identity" -Verbose
            $updateFunctionAppJob = Update-AzFunctionApp -Name $appName -ResourceGroupName $resourceGroupName -IdentityType SystemAssigned -Force -AsJob
            $result = WaitForJobToComplete -JobId $updateFunctionAppJob.Id
            $result.State | Should -Be "Completed"
            $result | Remove-Job -ErrorAction SilentlyContinue

            Write-Verbose "Run: Get-AzFunctionApp -Name $appName -ResourceGroupName $resourceGroupName" -Verbose
            $functionApp = Get-AzFunctionApp -Name $appName -ResourceGroupName $resourceGroupName
            Write-Verbose "FunctionApp after identity enable. Validate IdentityType" -Verbose
            $functionApp.IdentityType | Should -Be "SystemAssigned"

            Write-Verbose "Remove function app" -Verbose
            Write-Verbose "Run: Remove-AzFunctionApp -Name $appName -ResourceGroupName $resourceGroupName -Force" -Verbose
            Remove-AzFunctionApp -Name $appName -ResourceGroupName $resourceGroupName -Force

            Write-Verbose "Validate that the function app was deleted." -Verbose
            $functionApp = Get-AzFunctionApp -Name $appName -ResourceGroupName $resourceGroupName -ErrorAction SilentlyContinue
            $functionApp | Should -Be $null
        }
        finally
        {
            $functionApp = Get-AzFunctionApp -Name $appName -ResourceGroupName $resourceGroupName -ErrorAction SilentlyContinue
            if ($functionApp)
            {
                Write-Verbose "Cleaning up function app" -Verbose
                Remove-AzFunctionApp -Name $appName -ResourceGroupName $resourceGroupName -Force -ErrorAction SilentlyContinue
            }
        }
    }

    It "Create a function app and then use Update-AzFunctionApp to enable a UserAssigned managed identity for the app" {

        try
        {
            Write-Verbose "Creating function app" -Verbose
            $appName = $env.functionNamePowerShellNew2
            Write-Verbose "App name: $appName" -Verbose

            New-AzFunctionApp -Name $appName `
                              -ResourceGroupName $resourceGroupName `
                              -PlanName $planName `
                              -StorageAccount $storageAccountName `
                              -OSType "Windows" `
                              -Runtime "PowerShell" `
                              -RuntimeVersion 7.4 `
                              -FunctionsVersion 4

            $functionApp = Get-AzFunctionApp -Name $appName -ResourceGroupName $resourceGroupName
            $functionApp.OSType | Should -Be "Windows"
            $functionApp.Runtime | Should -Be "PowerShell"
            $functionApp.AppServicePlan | Should -Be $planName

            Write-Verbose "Update function app -> enable a UserAssigned managed identity for the app" -Verbose
            $identityInfo = $env.identityInfo
            Write-Verbose "Identity id: $($identityInfo.Id)" -Verbose
            Update-AzFunctionApp -Name $appName `
                                 -ResourceGroupName $resourceGroupName `
                                 -IdentityType UserAssigned `
                                 -IdentityID $identityInfo.Id `
                                 -Force

            $functionApp = Get-AzFunctionApp -Name $appName -ResourceGroupName $resourceGroupName
            $functionApp.IdentityType | Should -Be "UserAssigned"

            $userAssignedIdentity = $functionApp.IdentityUserAssignedIdentity.AdditionalProperties
            $userAssignedIdentity.ContainsKey($identityInfo.Id) | Should -Be $true

            Write-Verbose "Remove function app" -Verbose
            Remove-AzFunctionApp -Name $appName -ResourceGroupName $resourceGroupName -Force

            $functionApp = Get-AzFunctionApp -Name $appName -ResourceGroupName $resourceGroupName -ErrorAction SilentlyContinue
            $functionApp | Should -Be $null
        }
        finally
        {
            $functionApp = Get-AzFunctionApp -Name $appName -ResourceGroupName $resourceGroupName -ErrorAction SilentlyContinue
            if ($functionApp)
            {
                Remove-AzFunctionApp -Name $appName -ResourceGroupName $resourceGroupName -Force -ErrorAction SilentlyContinue
            }
        }
    }
}
