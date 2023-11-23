$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzWindowsIotServicesDevice.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzWindowsIotServicesDevice' {
    It 'UpdateExpanded' {
        # Cannot update paramter tag and the azure portal cannot update it.
        $wis = Update-AzWindowsIotServicesDevice -ResourceGroupName $env.resourceGroup -Name $env.wis01 -Quantity 100 #-Tag @{'key1'=1;'key2'=1}
        $wis.Quantity | Should -Be 100
        # $wis.Tag.Count | Should -be 2
    }

    It 'UpdateViaIdentityExpanded' {
        $wis = Update-AzWindowsIotServicesDevice -ResourceGroupName $env.resourceGroup -Name $env.wis01
        $wis = Update-AzWindowsIotServicesDevice -InputObject $wis -Quantity 200 # -Tag @{'key1'=1;'key2'=1; 'key3'=1}
        $wis.Quantity | Should -Be 200
        # $wis.Tag.Count | Should -be 2
    }
}
