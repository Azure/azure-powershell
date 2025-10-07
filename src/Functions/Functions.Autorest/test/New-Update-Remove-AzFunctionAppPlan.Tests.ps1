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

    BeforeAll {
        $resourceGroupName = $env.resourceGroupNameWindowsPremium
        Write-Verbose "Resource group name: $resourceGroupName" -Verbose
    }

    It "Validate New-AzFunctionAppPlan, Update-AzFunctionAppPlan and Remove-AzFunctionAppPlan" {

        $planName = $env.planNameWorkerTypeWindowsNew
        Write-Verbose "Updated planName: $planName" -Verbose
        $location = 'centralus'
        Write-Verbose "Location: $location" -Verbose
        $minimumWorkerCount = 1
        Write-Verbose "Minimum worker count: $minimumWorkerCount" -Verbose
        $maxBurst = 3
        Write-Verbose "Maximum worker count: $maxBurst" -Verbose
        $sku = "EP1"
        Write-Verbose "SKU: $sku" -Verbose
        $workerType = "Windows"
        Write-Verbose "Worker type: $workerType" -Verbose

        try
        {
            Write-Verbose "Creating function app plan '$planName'"
            Write-Verbose "Running: New-AzFunctionAppPlan -Name $planName `
                                    -ResourceGroupName $resourceGroupName `
                                    -WorkerType $workerType `
                                    -MinimumWorkerCount $minimumWorkerCount `
                                    -MaximumWorkerCount $maxBurst `
                                    -Location $location `
                                    -Sku $sku" -Verbose

            New-AzFunctionAppPlan -Name $planName `
                                  -ResourceGroupName $resourceGroupName `
                                  -WorkerType  $workerType `
                                  -MinimumWorkerCount $minimumWorkerCount `
                                  -MaximumWorkerCount $maxBurst `
                                  -Location $location `
                                  -Sku $sku

            $plan = Get-AzFunctionAppPlan -Name $planName -ResourceGroupName $resourceGroupName
            $plan.WorkerType | Should -Be "Windows"
            $plan.SkuTier | Should -Be "ElasticPremium"
            $plan.SkuName | Should -Be $sku
            $plan.Location | Should -Be "Central US"
            $plan.Capacity | Should -Be $minimumWorkerCount
            $plan.MaximumElasticWorkerCount | Should -Be $maxBurst

            # Update function app plan SKU to EP3 and maxBurst to 5
            $sku = "EP3"
            $maxBurst = 5
            
            Update-AzFunctionAppPlan -Name $planName -ResourceGroupName $resourceGroupName -Sku $sku -MaximumWorkerCount $maxBurst -Force

            $plan = Get-AzFunctionAppPlan -Name $planName -ResourceGroupName $resourceGroupName
            $plan.WorkerType | Should -Be "Windows"
            $plan.SkuTier | Should -Be "ElasticPremium"
            $plan.SkuName | Should -Be $sku
            $plan.Location | Should -Be "Central US"
            $plan.Capacity | Should -Be $minimumWorkerCount
            $plan.MaximumElasticWorkerCount | Should -Be $maxBurst

        }
        finally
        {
            $plan = Get-AzFunctionAppPlan -Name $planName -ResourceGroupName $resourceGroupName -ErrorAction SilentlyContinue
            if ($plan)
            {
                Remove-AzFunctionAppPlan -Name $planName -ResourceGroupName $resourceGroupName -Force -ErrorAction SilentlyContinue
            }
        }
    }

    It "Validate New-AzFunctionAppPlan, Update-AzFunctionAppPlan and Remove-AzFunctionAppPlan with piping (specifying InputObject)" {

        $planName = $env.planNameWorkerTypeWindowsNew
        Write-Verbose "Updated planName: $planName" -Verbose

        $location = 'centralus'
        $minimumWorkerCount = 1
        $maxBurst = 3
        $sku = "EP1"

        try
        {
            Write-Verbose "Creating function app plan '$planName'"
            New-AzFunctionAppPlan -Name $planName `
                                  -ResourceGroupName $resourceGroupName `
                                  -WorkerType "Windows" `
                                  -MinimumWorkerCount $minimumWorkerCount `
                                  -MaximumWorkerCount $maxBurst `
                                  -Location $location `
                                  -Sku $sku

            $plan = Get-AzFunctionAppPlan -Name $planName -ResourceGroupName $resourceGroupName
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

            $plan = Get-AzFunctionAppPlan -Name $planName -ResourceGroupName $resourceGroupName
            $plan.WorkerType | Should -Be "Windows"
            $plan.SkuTier | Should -Be "ElasticPremium"
            $plan.SkuName | Should -Be $sku
            $plan.Location | Should -Be "Central US"
            $plan.Capacity | Should -Be $minimumWorkerCount
            $plan.MaximumElasticWorkerCount | Should -Be $maxBurst

            # Remove function app plan
            Remove-AzFunctionAppPlan -InputObject $plan -Force
            $plan = Get-AzFunctionAppPlan -Name $planName -ResourceGroupName $resourceGroupName -ErrorAction SilentlyContinue
            $plan | Should -Be $null
        }
        finally
        {
            $plan = Get-AzFunctionAppPlan -Name $planName -ResourceGroupName $resourceGroupName -ErrorAction SilentlyContinue
            if ($plan)
            {
                Remove-AzFunctionAppPlan -InputObject $plan -Force -ErrorAction SilentlyContinue
            }
        }
    }

    It "Validate 'New-AzFunctionAppPlan -AsJob', 'Update-AzFunctionAppPlan -AsJob' and 'Remove-AzFunctionAppPlan -Force'" {

        $planName = $env.planNameWorkerTypeWindowsNew
        Write-Verbose "Updated planName: $planName" -Verbose

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
                                                        -ResourceGroupName $resourceGroupName `
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
            
            $plan = Get-AzFunctionAppPlan -Name $planName -ResourceGroupName $resourceGroupName
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
                                                           -ResourceGroupName $resourceGroupName `
                                                           -Sku $sku `
                                                           -Force `
                                                           -AsJob

            Write-Verbose "Update-AzFunctionAppPlan job started." -Verbose
            $result = WaitForJobToComplete -JobId $functionAppPlanJob.Id
            $result.State | Should -Be "Completed"
            $result | Remove-Job -ErrorAction SilentlyContinue

            $plan = Get-AzFunctionAppPlan -Name $planName -ResourceGroupName $resourceGroupName
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
            
            Remove-AzFunctionAppPlan -Name $planName -ResourceGroupName $resourceGroupName -Force
            $plan = Get-AzFunctionAppPlan -Name $planName -ResourceGroupName $resourceGroupName -ErrorAction SilentlyContinue
            $plan | Should -Be $null
        }
        finally
        {
            $plan = Get-AzFunctionAppPlan -Name $planName -ResourceGroupName $resourceGroupName -ErrorAction SilentlyContinue
            if ($plan)
            {
                Remove-AzFunctionAppPlan -InputObject $plan -Force -ErrorAction SilentlyContinue
            }
        }
    }
}
