$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDiskPoolIscsiTarget.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzDiskPoolIscsiTarget' {
    It 'CreateExpanded' {
        $lun1 = New-AzDiskPoolIscsiLunObject -ManagedDiskAzureResourceId $env.diskId1 -Name 'lun1'
        $target1 = New-AzDiskPoolIscsiTarget -DiskPoolName $env.diskPool1 -Name $env.target1 -ResourceGroupName $env.resourceGroup -Lun @($lun1) -AclMode 'Dynamic'
        $target1.Name | Should -Be $env.target1
        $target1.ProvisioningState | Should -Be 'Succeeded'
    }
}
