$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzHealthBot.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzHealthBot' {
    It 'Delete' {
        Remove-AzHealthBot -Name $env.HealthBot1 -ResourceGroupName $env.ResourceGroupName
        $gethealthbotList = Get-AzHealthBot
        $gethealthbotList.Name | Should -Not -Contain $env.HealthBot1
    }

    It 'DeleteViaIdentity' {
        $newHealthBot = New-AzHealthBot -Name $env.HealthBot2 -ResourceGroupName $env.ResourceGroupName -Location $env.location -Sku $env.F0
        $gethealthbot = Get-AzHealthBot -Name $env.HealthBot2 -ResourceGroupName $env.ResourceGroupName
        Remove-AzHealthBot -InputObject $gethealthbot
        $gethealthbotList = Get-AzHealthBot
        $gethealthbotList.Name | Should -Not -Contain $env.HealthBot2
    }
}
