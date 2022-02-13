$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzHealthBot.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzHealthBot' {
    It 'UpdateExpanded' {
        $updateHealthBot = update-AzHealthBot -Name $env.HealthBot1 -ResourceGroupName $env.ResourceGroupName -Sku $env.S1
        $updateHealthBot.SkuName | Should -Be $env.S1
    }

    It 'UpdateViaIdentityExpanded' {
        $getHealthBot = Get-AzHealthBot -Name $env.HealthBot1 -ResourceGroupName $env.ResourceGroupName
        $updateHealthBot = update-AzHealthBot -InputObject $getHealthBot -Sku $env.F0
        $updateHealthBot.SkuName | Should -Be $env.F0
    }
}
