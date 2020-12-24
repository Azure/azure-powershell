$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzADDomainService.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzADDomainService' {
    It 'UpdateExpanded' {
        $ADDomainSetting = New-AzADDomainServiceDomainSecuritySettingObject -TlsV1 $env.TlsV1Status1
        $UpdateADDomain = Update-AzADDomainService -ResourceGroupName $env.ResourceGroupName -Name $env.ADdomainName -DomainSecuritySetting $ADDomainSetting
        $UpdateADDomain.DomainSecuritySettingTlsV1 | Should -Be $env.TlsV1Status1
    }

    It 'UpdateViaIdentityExpanded' {
        Start-Sleep -s 240
        $ADDomainSetting = New-AzADDomainServiceDomainSecuritySettingObject -TlsV1 $env.TlsV1Status2
        $GetADDomainExample = Get-AzADDomainService -ResourceGroupName $env.ResourceGroupName -Name $env.ADdomainName
        $UpdateADDomain = Update-AzADDomainService -InputObject $GetADDomainExample -DomainSecuritySetting $ADDomainSetting
        $UpdateADDomain.DomainSecuritySettingTlsV1 | Should -Be $env.TlsV1Status2
    }
}
