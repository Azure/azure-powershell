$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMigrateSolution.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzMigrateSolution' {
    It 'List' -skip {
        $solutions = Get-AzMigrateSolution -MigrateProjectName  $env.migProjectName -ResourceGroupName $env.migResourceGroup -SubscriptionId $env.migSubscriptionId
        $solutions.Count | Should -BeGreaterOrEqual 1 
    }

    It 'Get' {
        $solution = Get-AzMigrateSolution -Name $env.migSolutionName -MigrateProjectName  $env.migProjectName -ResourceGroupName $env.migResourceGroup -SubscriptionId $env.migSubscriptionId
        $solution.Name | Should -Be $env.migSolutionName
    }
}
