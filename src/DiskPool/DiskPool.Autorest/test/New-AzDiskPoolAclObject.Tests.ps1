$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDiskPoolAclObject.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzDiskPoolAclObject' {
    It '__AllParameterSets' {
        $acl = New-AzDiskPoolAclObject -InitiatorIqn 'iqn.2021-05.com.microsoft:target0' -MappedLun @('lun0')
        $acl.InitiatorIqn | Should -Be 'iqn.2021-05.com.microsoft:target0'
        $acl.MappedLun.Count | Should -Be 1
    }
}
