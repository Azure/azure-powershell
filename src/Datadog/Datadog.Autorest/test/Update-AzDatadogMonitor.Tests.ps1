$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDatadogMonitor.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzDatadogMonitor' {
    It 'UpdateExpanded' {
        { 
            Update-AzDatadogMonitor -ResourceGroupName $env.resourceGroup -Name $env.monitorName01 -Tag @{'key1'='value1'; 'key2'='value2'}
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
          $obj =  Get-AzDatadogMonitor -ResourceGroupName $env.resourceGroup -Name $env.monitorName01 
          Update-AzDatadogMonitor -InputObject $obj -Tag @{'key1'='value1'; 'key2'='value2'}
        } | Should -Not -Throw
    }
}
