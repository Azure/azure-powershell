$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWindowsIotServicesDevice.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzWindowsIotServicesDevice' {
    It 'List1' {
        $wisList = Get-AzWindowsIotServicesDevice
        $wisList.Count | Should -BeGreaterOrEqual 2
    }

    It 'List' {
        $wisList = Get-AzWindowsIotServicesDevice -ResourceGroupName $env.resourceGroup
        $wisList.Count | Should -Be 2
    }

    It 'Get' {
        $wis = Get-AzWindowsIotServicesDevice -ResourceGroupName $env.resourceGroup -Name $env.wis01
        $wis.Name | Should -Be $env.wis01
    }

    It 'GetViaIdentity' {
        $wis = Get-AzWindowsIotServicesDevice -ResourceGroupName $env.resourceGroup -Name $env.wis01
        $wis = Get-AzWindowsIotServicesDevice -InputObject $wis
        $wis.Name | Should -Be $env.wis01
    }
}
