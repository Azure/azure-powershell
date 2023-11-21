$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzFunctionAppPlan.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzFunctionAppPlan' {

    It 'GetAll' {
        $functionAppPlans = @(Get-AzFunctionAppPlan)
        $functionAppPlans.Count | Should -BeGreaterThan 0
    }

    # ByName
    foreach ($planDefinition in $env.servicePlansToCreate)
    {
        It "ByName '$($planDefinition.Name)'" {

            $functionAppPlan = Get-AzFunctionAppPlan -Name $planDefinition.Name -ResourceGroupName $planDefinition.ResourceGroupName

            $functionAppPlan.WorkerType | Should -Be $planDefinition.WorkerType
            $functionAppPlan.ResourceGroupName | Should -Be $planDefinition.ResourceGroupName
            $functionAppPlan.Location | Should -Be $planDefinition.Location
        }
    }


    It 'ByResourceGroupName' {
        $functionAppPlans = @(Get-AzFunctionAppPlan -ResourceGroupName $env.resourceGroupNameWindowsPremium)
        $functionAppPlans.Count | Should -BeGreaterThan 0

        $functionAppPlans | ForEach-Object {
            $_.ResourceGroupName | Should Be $env.resourceGroupNameWindowsPremium
        }
    }

    It 'ByLocation' {
        $functionAppPlans = @(Get-AzFunctionAppPlan -Location $env.location)
        $functionAppPlans.Count | Should -BeGreaterThan 0

        $functionAppPlans | ForEach-Object {
            $_.Location | Should Be $env.location
        }

    }
}
