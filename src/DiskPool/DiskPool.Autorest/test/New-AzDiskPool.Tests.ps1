$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDiskPool.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzDiskPool' {
    It 'CreateExpanded' {
        $diskPool = New-AzDiskPool -Name $env.diskPool5 -ResourceGroupName $env.resourceGroup -Location $env.location -SkuName 'Standard_S1' -SkuTier 'Standard' -SubnetId $env.diskPoolSubnetId -AvailabilityZone "1" 
        $diskPool.name | Should -Be $env.diskPool5
        $diskPool.status | Should -Be "Running"
    }
}
