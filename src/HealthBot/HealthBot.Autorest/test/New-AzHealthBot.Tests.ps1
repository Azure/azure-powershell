$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzHealthBot.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzHealthBot' {
    It 'CreateExpanded' {
        $newHealthBot = New-AzHealthBot -Name $env.HealthBot1 -ResourceGroupName $env.ResourceGroupName -Location $env.location -Sku $env.F0
        $newHealthBot.Name | Should -Be $env.HealthBot1
    }
}
