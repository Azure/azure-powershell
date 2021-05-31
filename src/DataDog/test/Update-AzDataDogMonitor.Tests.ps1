$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDataDogMonitor.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzDataDogMonitor' {
    It 'UpdateExpanded' {
        { 
            Update-AzDataDogMonitor -ResourceGroupName $env.resourceGroup -Name $env.monitorName01 -Tag @{'key1'='value1'; 'key2'='value2'}
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
          $obj =  Get-AzDataDogMonitor -ResourceGroupName $env.resourceGroup -Name $env.monitorName01 
          Update-AzDataDogMonitor -InputObject $obj -Tag @{'key1'='value1'; 'key2'='value2'}
        } | Should -Not -Throw
    }
}
