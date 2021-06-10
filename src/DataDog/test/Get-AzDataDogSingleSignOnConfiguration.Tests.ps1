$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDataDogSingleSignOnConfiguration.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzDataDogSingleSignOnConfiguration' {
    It 'List' {
        { Get-AzDataDogSingleSignOnConfiguration -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01 } | Should -Not -Throw
    }

    It 'Get' {
        { Get-AzDataDogSingleSignOnConfiguration -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01 -Name 'default' } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        {
            $obj = Get-AzDataDogSingleSignOnConfiguration -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01 -Name 'default'
            Get-AzDataDogSingleSignOnConfiguration -InputObject $obj
        } | Should -Not -Throw
    }
}
