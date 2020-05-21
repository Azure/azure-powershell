$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzFunctionAppPlan.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzFunctionAppPlan' {

    It "New-AzFunctionAppPlan -Location supports locations with no spaces, e.g., 'centralus'" {

        $planName = $env.functionAppPlanName
        $location = 'centralus'

        try
        {
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
