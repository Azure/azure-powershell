$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzADDomainService.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzADDomainService' {
    It 'Delete' {
        Remove-AzADDomainService -ResourceGroupName $env.ResourceGroupName -Name $env.ADdomainName
        $GetADDomainList = Get-AzADDomainService
        $GetADDomainList.Name | Should -Not -Contain $env.ADdomainName
    }

    It 'DeleteViaIdentity' {
        $ReplicaSet = New-AzADDomainServiceReplicaSetObject -Location $env.Location -SubnetId $env.SubnetId
        $NewAdDomain = New-AzADDomainService -name $env.ADdomainName -ResourceGroupName $env.ResourceGroupName -DomainName $env.ADDomainNameCom -ReplicaSet $ReplicaSet
        # Start-Sleep -s 120
        $GetADDomainExample = Get-AzADDomainService -ResourceGroupName $env.ResourceGroupName -Name $env.ADdomainName
        Remove-AzADDomainService -InputObject $GetADDomainExample
        $GetADDomainList = Get-AzADDomainService
        $GetADDomainList.Name | Should -Not -Contain $env.ADdomainName
    }
}
