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

    It "Validate New-AzFunctionAppPlan, Update-AzFunctionApp and Remove-AzFunctionApp" {

        # Update-AzFunctionApp is an important scenario to validate given that in the update operation 
        # will copy the exiting function app configuration to create a new one.

        $functionName = $env.functionNamePowerShell
        $location = "centralus"
        $tags = @{
            "MyTag1" = "MyTag1Value1"
            "MyTag2" = "MyTag1Value2"
        }

        try
        {
            Write-Verbose "Create function app with a SystemAssigned managed identity" -Verbose
            New-AzFunctionApp -Name $functionName `
                              -ResourceGroupName $env.resourceGroupNameWindowsPremium `
                              -PlanName $env.planNameWorkerTypeWindows `
                              -StorageAccount $env.storageAccountWindows  `
                              -Runtime PowerShell `
                              -RuntimeVersion "7.2" `
                              -FunctionsVersion 4 `
                              -IdentityType SystemAssigned `
                              -Tag $tags

            $functionApp = Get-AzFunctionApp -Name $functionName -ResourceGroupName $env.resourceGroupNameWindowsPremium
            $functionApp.OSType | Should -Be "Windows"
            $functionApp.Runtime | Should -Be "PowerShell"
            $functionApp.IdentityType | Should -Be "SystemAssigned"
            
            # Validate tags
            foreach ($tagName in $tags.Keys)
            {
                $functionApp.Tag.AdditionalProperties[$tagName] | Should Be $tags[$tagName]
            }

            # Update function app plan
            Write-Verbose "Create premium function app plan" -Verbose
            $planName = $env.functionAppPlanName
            New-AzFunctionAppPlan -Name $planName `
                                  -ResourceGroupName $env.resourceGroupNameWindowsPremium `
                                  -WorkerType "Windows" `
                                  -MinimumWorkerCount 1 `
                                  -MaximumWorkerCount 10 `
                                  -Location $location `
                                  -Sku EP1

            $plan = Get-AzFunctionAppPlan -Name $planName -ResourceGroupName $env.resourceGroupNameWindowsPremium
            $plan.WorkerType | Should -Be "Windows"
            $plan.SkuTier | Should -Be "ElasticPremium"
            $plan.SkuName | Should -Be "EP1"
            $plan.Location | Should -Be "Central US"
            $plan.Name | Should -Be $planName

            Write-Verbose "Update function app plan hosting plan" -Verbose
            Update-AzFunctionApp -Name $functionName -ResourceGroupName $env.resourceGroupNameWindowsPremium -PlanName $planName -Force

            $functionApp = Get-AzFunctionApp -Name $functionName -ResourceGroupName $env.resourceGroupNameWindowsPremium
            $functionApp.OSType | Should -Be "Windows"
            $functionApp.Runtime | Should -Be "PowerShell"
            $functionApp.IdentityType | Should -Be "SystemAssigned"
            $functionApp.AppServicePlan | Should -Be $planName
            
            # Validate tags
            foreach ($tagName in $tags.Keys)
            {
                $functionApp.Tag.AdditionalProperties[$tagName] | Should Be $tags[$tagName]
            }

            # Remove the managed identity from the function app - run Update-AzFunctionApp
            Write-Verbose "Update function -> remove SystemAssigned managed identity" -Verbose
            Update-AzFunctionApp -InputObject $functionApp -IdentityType None -Force
            
            $functionApp = Get-AzFunctionApp -Name $functionName -ResourceGroupName $env.resourceGroupNameWindowsPremium
            $functionApp.OSType | Should -Be "Windows"
            $functionApp.Runtime | Should -Be "PowerShell"
            $functionApp.IdentityType | Should -Be $null
            $functionApp.AppServicePlan | Should -Be $planName

            # Update application insigts
            Write-Verbose "Update function app ApplicationInsights via -ApplicationInsightsName" -Verbose
            $newApplInsights = $env.newApplInsights
            Update-AzFunctionApp -InputObject $functionApp -ApplicationInsightsName $newApplInsights.Name -Force

            $functionApp = Get-AzFunctionApp -Name $functionName -ResourceGroupName $env.resourceGroupNameWindowsPremium
            $functionApp.OSType | Should -Be "Windows"
            $functionApp.Runtime | Should -Be "PowerShell"
            $functionApp.IdentityType | Should -Be $null
            $functionApp.AppServicePlan | Should -Be $planName
            $functionApp.ApplicationSettings["APPINSIGHTS_INSTRUMENTATIONKEY"] | Should -Be $newApplInsights.InstrumentationKey

            # Validate tags
            foreach ($tagName in $tags.Keys)
            {
                $functionApp.Tag.AdditionalProperties[$tagName] | Should Be $tags[$tagName]
            }
        }
        finally
        {
            $functionApp = Get-AzFunctionApp -Name $functionName -ResourceGroupName $env.resourceGroupNameWindowsPremium -ErrorAction SilentlyContinue
            if ($functionApp)
            {
                Remove-AzFunctionApp -InputObject $functionApp -Force -ErrorAction SilentlyContinue
            }

            $plan = Get-AzFunctionAppPlan -Name $planName -ResourceGroupName $env.resourceGroupNameWindowsPremium -ErrorAction SilentlyContinue
            if ($plan)
            {
                Remove-AzFunctionAppPlan -InputObject $plan -Force -ErrorAction SilentlyContinue
            }
        }
    }

    It "Validate New-AzFunctionApp -AsJob, Update-AzFunctionApp -AsJob and Remove-AzFunctionApp" {

        $functionName = $env.functionNamePowerShell

        try
        {
            Write-Verbose "Creating function app -AsJob" -Verbose
            $functionAppJob = New-AzFunctionApp -Name $functionName `
                                                -ResourceGroupName $env.resourceGroupNameWindowsPremium `
                                                -PlanName $env.planNameWorkerTypeWindows `
                                                -StorageAccount $env.storageAccountWindows `
                                                -OSType "Windows" `
                                                -Runtime "PowerShell" `
                                                -RuntimeVersion 7.2 `
                                                -FunctionsVersion 4 `
                                                -AsJob

            Write-Verbose "Job completed. Validating result" -Verbose
            $result = WaitForJobToComplete -JobId $functionAppJob.Id
            $result.State | Should -Be "Completed"
            $result | Remove-Job -ErrorAction SilentlyContinue

            $functionApp = Get-AzFunctionApp -Name $functionName -ResourceGroupName $env.resourceGroupNameWindowsPremium
            $functionApp.OSType | Should -Be "Windows"
            $functionApp.Runtime | Should -Be "PowerShell"
            $functionApp.AppServicePlan | Should -Be $env.planNameWorkerTypeWindows

            Write-Verbose "Update function app -> enable a SystemAssigned managed identity" -Verbose
            $updateFunctionAppJob = Update-AzFunctionApp -Name $functionName -ResourceGroupName $env.resourceGroupNameWindowsPremium -IdentityType SystemAssigned -Force -AsJob
            $result = WaitForJobToComplete -JobId $updateFunctionAppJob.Id
            $result.State | Should -Be "Completed"
            $result | Remove-Job -ErrorAction SilentlyContinue

            $functionApp = Get-AzFunctionApp -Name $functionName -ResourceGroupName $env.resourceGroupNameWindowsPremium
            $functionApp.OSType | Should -Be "Windows"
            $functionApp.Runtime | Should -Be "PowerShell"
            $functionApp.IdentityType | Should -Be "SystemAssigned"
            $functionApp.AppServicePlan | Should -Be $env.planNameWorkerTypeWindows

            Write-Verbose "Remove function app" -Verbose
            Remove-AzFunctionApp -Name $functionName -ResourceGroupName $env.resourceGroupNameWindowsPremium -Force

            $functionApp = Get-AzFunctionApp -Name $functionName -ResourceGroupName $env.resourceGroupNameWindowsPremium
            $functionApp | Should -Be $null
        }
        finally
        {
            $functionApp = Get-AzFunctionApp -Name $functionName -ResourceGroupName $env.resourceGroupNameWindowsPremium -ErrorAction SilentlyContinue
            if ($functionApp)
            {
                Remove-AzFunctionApp -InputObject $functionApp -Force -ErrorAction SilentlyContinue
            }
        }
    }

    It "Create a function app and then use Update-AzFunctionApp to enable a UserAssigned managed identity for the app" {

        $functionName = $env.functionNamePowerShell
        $identityInfo = $env.identityInfo

        try
        {
            Write-Verbose "Creating function app" -Verbose
            New-AzFunctionApp -Name $functionName `
                              -ResourceGroupName $env.resourceGroupNameWindowsPremium `
                              -PlanName $env.planNameWorkerTypeWindows `
                              -StorageAccount $env.storageAccountWindows `
                              -OSType "Windows" `
                              -Runtime "PowerShell" `
                              -RuntimeVersion 7.2 `
                              -FunctionsVersion 4

            $functionApp = Get-AzFunctionApp -Name $functionName -ResourceGroupName $env.resourceGroupNameWindowsPremium
            $functionApp.OSType | Should -Be "Windows"
            $functionApp.Runtime | Should -Be "PowerShell"
            $functionApp.AppServicePlan | Should -Be $env.planNameWorkerTypeWindows

            Write-Verbose "Update function app -> enable a UserAssigned managed identity for the app" -Verbose
            Update-AzFunctionApp -Name $functionName `
                                 -ResourceGroupName $env.resourceGroupNameWindowsPremium `
                                 -IdentityType UserAssigned `
                                 -IdentityID $identityInfo.Id `
                                 -Force

            $functionApp = Get-AzFunctionApp -Name $functionName -ResourceGroupName $env.resourceGroupNameWindowsPremium
            $functionApp.OSType | Should -Be "Windows"
            $functionApp.Runtime | Should -Be "PowerShell"
            $functionApp.IdentityType | Should -Be "UserAssigned"

            $userAssignedIdentity = $functionApp.IdentityUserAssignedIdentity.AdditionalProperties
            $userAssignedIdentity.ContainsKey($identityInfo.Id) | Should -Be $true

            Write-Verbose "Remove function app" -Verbose
            Remove-AzFunctionApp -Name $functionName -ResourceGroupName $env.resourceGroupNameWindowsPremium -Force

            $functionApp = Get-AzFunctionApp -Name $functionName -ResourceGroupName $env.resourceGroupNameWindowsPremium
            $functionApp | Should -Be $null
        }
        finally
        {
            $functionApp = Get-AzFunctionApp -Name $functionName -ResourceGroupName $env.resourceGroupNameWindowsPremium -ErrorAction SilentlyContinue
            if ($functionApp)
            {
                Remove-AzFunctionApp -InputObject $functionApp -Force -ErrorAction SilentlyContinue
            }
        }
    }
}
