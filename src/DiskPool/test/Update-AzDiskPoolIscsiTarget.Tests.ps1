$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDiskPoolIscsiTarget.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzDiskPoolIscsiTarget' {
    It 'UpdateExpanded' {
        $lun0 = New-AzDiskPoolIscsiLunObject -ManagedDiskAzureResourceId $env.diskId2 -Name "lun0"
        $lun1 = New-AzDiskPoolIscsiLunObject -ManagedDiskAzureResourceId $env.diskId3 -Name "lun1"
        $luns = @($lun0, $lun1)

        $iscsiTarget = Update-AzDiskPoolIscsiTarget -Name $env.target0 `
        -DiskPoolName $env.diskPool5 `
        -ResourceGroupName $env.resourceGroup `
        -Lun $luns

        $iscsiTarget.Name | Should -Be $env.target0
        $iscsiTarget.lun.Count | Should -Be 2
        $iscsiTarget.provisioningState | Should -Be "Succeeded"
    }

    It 'UpdateViaIdentityExpanded' {
        $lun1 = New-AzDiskPoolIscsiLunObject -ManagedDiskAzureResourceId $env.diskId3 -Name "lun1"
        $luns = @($lun1)

        $iscsiTarget = Get-AzDiskPoolIscsiTarget -Name $env.target0 `
        -DiskPoolName $env.diskPool5 `
        -ResourceGroupName $env.resourceGroup `

        $iscsiTarget = Update-AzDiskPoolIscsiTarget -InputObject $iscsiTarget ` -Lun $luns
        
        $iscsiTarget.Name | Should -Be $env.target0
        $iscsiTarget.lun.Count | Should -Be 1
        $iscsiTarget.provisioningState | Should -Be "Succeeded"
    }
}
