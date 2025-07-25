$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzWindowsIotServicesDevice.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzWindowsIotServicesDevice' {
    It 'Delete' {
        Remove-AzWindowsIotServicesDevice -ResourceGroupName $env.resourceGroup -Name $env.wis03
        $wisList = Get-AzWindowsIotServicesDevice -ResourceGroupName $env.resourceGroup
        $wisList.Name | Should -Not -Contain $env.wis03
    }

    It 'DeleteViaIdentity' {
        $wis = Get-AzWindowsIotServicesDevice -ResourceGroupName $env.resourceGroup -Name $env.wis02
        Remove-AzWindowsIotServicesDevice -InputObject $wis
        $wisList = Get-AzWindowsIotServicesDevice -ResourceGroupName $env.resourceGroup
        $wisList.Name | Should -Not -Contain $env.wis02
    }
}
