$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDataDogTagRule.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzDataDogTagRule' {
    It 'List' {
        { Get-AzDataDogTagRule -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01 } | Should -Not -Throw
    }

    It 'Get' {
        { Get-AzDataDogTagRule -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01 -Name 'default' } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        {
          $obj = Get-AzDataDogTagRule -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01 -Name 'default'
          Get-AzDataDogTagRule -InputObject $obj
        } | Should -Not -Throw
    }
}
