$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-Update-Remove-AzFunctionAppPlan.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzFunctionAppPlan, Update-AzFunctionAppPlan, and Remove-AzFunctionAppPlan E2E' {

    It "Validate New-AzFunctionAppPlan, Update-AzFunctionAppPlan and Remove-AzFunctionAppPlan" {

        $planName = $env.functionAppPlanName
        $location = 'centralus'
        $minimumWorkerCount = 1
        $maxBurst = 3
        $sku = "EP1"

        try
        {
            Write-Verbose "Creating function app plan '$planName'"
            New-AzFunctionAppPlan -Name $planName `
                                  -ResourceGroupName $env.resourceGroupNameWindowsPremium `
                                  -WorkerType "Windows" `
                                  -MinimumWorkerCount $minimumWorkerCount `
                                  -MaximumWorkerCount $maxBurst `
                                  -Location $location `
                                  -Sku $sku

            $plan = Get-AzFunctionAppPlan -Name $planName -ResourceGroupName $env.resourceGroupNameWindowsPremium
            $plan.WorkerType | Should -Be "Windows"
            $plan.SkuTier | Should -Be "ElasticPremium"
            $plan.SkuName | Should -Be $sku
            $plan.Location | Should -Be "Central US"
            $plan.Capacity | Should -Be $minimumWorkerCount
            $plan.MaximumElasticWorkerCount | Should -Be $maxBurst

            # Update function app plan SKU to EP3 and maxBurst to 5
            $sku = "EP3"
            $maxBurst = 5
            
            Update-AzFunctionAppPlan -Name $planName -ResourceGroupName $env.resourceGroupNameWindowsPremium -Sku $sku -MaximumWorkerCount $maxBurst -Force

            $plan = Get-AzFunctionAppPlan -Name $planName -ResourceGroupName $env.resourceGroupNameWindowsPremium
            $plan.WorkerType | Should -Be "Windows"
            $plan.SkuTier | Should -Be "ElasticPremium"
            $plan.SkuName | Should -Be $sku
            $plan.Location | Should -Be "Central US"
            $plan.Capacity | Should -Be $minimumWorkerCount
            $plan.MaximumElasticWorkerCount | Should -Be $maxBurst

        }
        finally
        {
            $plan = Get-AzFunctionAppPlan -Name $planName -ResourceGroupName $env.resourceGroupNameWindowsPremium -ErrorAction SilentlyContinue
            if ($plan)
            {
                Remove-AzFunctionAppPlan -InputObject $plan -Force -ErrorAction SilentlyContinue
            }
        }
    }

    It "Validate New-AzFunctionAppPlan, Update-AzFunctionAppPlan and Remove-AzFunctionAppPlan with piping (specifying InputObject)" {

        $planName = $env.functionAppPlanName
        $location = 'centralus'
        $minimumWorkerCount = 1
        $maxBurst = 3
        $sku = "EP1"

        try
        {
            Write-Verbose "Creating function app plan '$planName'"
            New-AzFunctionAppPlan -Name $planName `
                                  -ResourceGroupName $env.resourceGroupNameWindowsPremium `
                                  -WorkerType "Windows" `
                                  -MinimumWorkerCount $minimumWorkerCount `
                                  -MaximumWorkerCount $maxBurst `
                                  -Location $location `
                                  -Sku $sku

            $plan = Get-AzFunctionAppPlan -Name $planName -ResourceGroupName $env.resourceGroupNameWindowsPremium
            $plan.WorkerType | Should -Be "Windows"
            $plan.SkuTier | Should -Be "ElasticPremium"
            $plan.SkuName | Should -Be $sku
            $plan.Location | Should -Be "Central US"
            $plan.Capacity | Should -Be $minimumWorkerCount
            $plan.MaximumElasticWorkerCount | Should -Be $maxBurst

            # Update function app plan SKU to EP2 and maxBurst to 7
            $sku = "EP2"
            $maxBurst = 7
            Update-AzFunctionAppPlan -InputObject $plan -Sku $sku -MaximumWorkerCount $maxBurst -Force

            $plan = Get-AzFunctionAppPlan -Name $planName -ResourceGroupName $env.resourceGroupNameWindowsPremium
            $plan.WorkerType | Should -Be "Windows"
            $plan.SkuTier | Should -Be "ElasticPremium"
            $plan.SkuName | Should -Be $sku
            $plan.Location | Should -Be "Central US"
            $plan.Capacity | Should -Be $minimumWorkerCount
            $plan.MaximumElasticWorkerCount | Should -Be $maxBurst

            # Remove function app plan
            Remove-AzFunctionAppPlan -InputObject $plan -Force
            $plan = Get-AzFunctionAppPlan -Name $planName -ResourceGroupName $env.resourceGroupNameWindowsPremium
            $plan | Should -Be $null
        }
        finally
        {
            $plan = Get-AzFunctionAppPlan -Name $planName -ResourceGroupName $env.resourceGroupNameWindowsPremium -ErrorAction SilentlyContinue
            if ($plan)
            {
                Remove-AzFunctionAppPlan -InputObject $plan -Force -ErrorAction SilentlyContinue
            }
        }
    }

    It "Validate 'New-AzFunctionAppPlan -AsJob', 'Update-AzFunctionAppPlan -AsJob' and 'Remove-AzFunctionAppPlan -Force'" {

        $planName = $env.functionAppPlanName
        $location = 'centralus'
        $minimumWorkerCount = 1
        $maxBurst = 3
        $sku = "EP1"
        $tags = @{
            "MyTag1" = "MyTag1Value1"
            "MyTag2" = "MyTag1Value2"
        }

        try
        {
            # Create a service plan
            Write-Verbose "Creating function app plan '$planName' job started." -Verbose
            $functionAppPlanJob = New-AzFunctionAppPlan -Name $planName `
                                                        -ResourceGroupName $env.resourceGroupNameWindowsPremium `
                                                        -WorkerType "Windows" `
                                                        -MinimumWorkerCount $minimumWorkerCount `
                                                        -MaximumWorkerCount $maxBurst `
                                                        -Location $location `
                                                        -Sku $sku `
                                                        -Tag $tags `
                                                        -AsJob

            $result = WaitForJobToComplete -JobId $functionAppPlanJob.Id
            $result.State | Should -Be "Completed"
            $result | Remove-Job -ErrorAction SilentlyContinue
            
            $plan = Get-AzFunctionAppPlan -Name $planName -ResourceGroupName $env.resourceGroupNameWindowsPremium
            $plan.WorkerType | Should -Be "Windows"
            $plan.SkuTier | Should -Be "ElasticPremium"
            $plan.SkuName | Should -Be $sku
            $plan.Location | Should -Be "Central US"
            $plan.Capacity | Should -Be $minimumWorkerCount
            $plan.MaximumElasticWorkerCount | Should -Be $maxBurst

            # Validate tags
            foreach ($tagName in $tags.Keys)
            {
                $plan.Tag.AdditionalProperties[$tagName] | Should Be $tags[$tagName]
            }

            # Update function app plan SKU to EP2 and maxBurst to 5
            $sku = "EP2"            
            $functionAppPlanJob = Update-AzFunctionAppPlan -Name $planName `
                                                           -ResourceGroupName $env.resourceGroupNameWindowsPremium `
                                                           -Sku $sku `
                                                           -Force `
                                                           -AsJob

            Write-Verbose "Update-AzFunctionAppPlan job started." -Verbose
            $result = WaitForJobToComplete -JobId $functionAppPlanJob.Id
            $result.State | Should -Be "Completed"
            $result | Remove-Job -ErrorAction SilentlyContinue

            $plan = Get-AzFunctionAppPlan -Name $planName -ResourceGroupName $env.resourceGroupNameWindowsPremium
            $plan.WorkerType | Should -Be "Windows"
            $plan.SkuTier | Should -Be "ElasticPremium"
            $plan.SkuName | Should -Be $sku
            $plan.Location | Should -Be "Central US"
            $plan.Capacity | Should -Be $minimumWorkerCount
            $plan.MaximumElasticWorkerCount | Should -Be $maxBurst

            # Validate tags
            foreach ($tagName in $tags.Keys)
            {
                $plan.Tag.AdditionalProperties[$tagName] | Should Be $tags[$tagName]
            }
            
            Remove-AzFunctionAppPlan -Name $planName -ResourceGroupName $env.resourceGroupNameWindowsPremium -Force
            $plan = Get-AzFunctionAppPlan -Name $planName -ResourceGroupName $env.resourceGroupNameWindowsPremium
            $plan | Should -Be $null
        }
        finally
        {
            $plan = Get-AzFunctionAppPlan -Name $planName -ResourceGroupName $env.resourceGroupNameWindowsPremium -ErrorAction SilentlyContinue
            if ($plan)
            {
                Remove-AzFunctionAppPlan -InputObject $plan -Force -ErrorAction SilentlyContinue
            }
        }
    }
}
