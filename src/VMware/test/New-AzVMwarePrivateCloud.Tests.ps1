$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzVMwarePrivateCloud.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzVMwarePrivateCloud' {
    It 'CreateExpanded' {
        {
            $config = New-AzVMwarePrivateCloud -Name $env.rstr2 -ResourceGroupName $env.resourceGroup2 -NetworkBlock 192.168.48.0/22 -Sku av20 -ManagementClusterSize 3 -Location $env.location1 -AcceptEULA
            $config.ManagementClusterSize | Should -Be 3
        } | Should -Not -Throw
    }
}