$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzSpringCloud.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzSpringCloud' {
    It 'UpdateExpanded' {
        $spring = Update-AzSpringCloud -ResourceGroupName $env.resourceGroup -Name $env.springName00 -Tag @{"key01" = "value01"; "key02" = "value02"}
        $spring.Tag.Count | Should -Be 2
    }

    It 'UpdateViaIdentityExpanded' {
        $spring = Get-AzSpringCloud -ResourceGroupName $env.resourceGroup -Name $env.springName00
        $spring = Update-AzSpringCloud -InputObject $spring -Tag @{"key01" = "value01"; "key02" = "value02"; "key03" = "value03"}
        $spring.Tag.Count | Should -Be 3
    }
}
