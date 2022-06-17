$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDiskPool.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzDiskPool' {
    It 'UpdateExpanded' {
        $diskPool = Get-AzDiskPool -ResourceGroupName $env.resourceGroup -Name $env.diskPool5
        $diskPool.Disk.Count | Should -Be 0

        $disks = @($env.diskId2)
        $diskPool = Update-AzDiskPool -Name $env.diskPool5 -ResourceGroupName $env.resourceGroup -DiskId $disks 
        $diskPool.Disk.Count | Should -Be 1
    }
    
    It 'UpdateViaIdentityExpanded' {
        $diskPool = Get-AzDiskPool -ResourceGroupName $env.resourceGroup -Name $env.diskPool5
        $diskPool.Disk.Count | Should -Be 1 
        
        $disks = @($env.diskId2)
        $disks += @($env.diskId3)
        $diskPool = Update-AzDiskPool -InputObject $diskPool -DiskId $disks
        $diskPool.Disk.Count | Should -Be 2
    }
}
