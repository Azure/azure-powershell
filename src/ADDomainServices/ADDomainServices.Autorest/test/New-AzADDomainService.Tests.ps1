$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzADDomainService.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzADDomainService' {
    It 'CreateExpanded' {
        $ReplicaSet = New-AzADDomainServiceReplicaSetObject -Location $env.Location -SubnetId $env.SubnetId
        $NewAdDomain = New-AzADDomainService -Name $env.ADdomainName -ResourceGroupName $env.ResourceGroupName -DomainName $env.ADDomainNameCom -ReplicaSet $ReplicaSet
        $NewAdDomain.name | Should -Be $env.ADdomainName
    }
}
