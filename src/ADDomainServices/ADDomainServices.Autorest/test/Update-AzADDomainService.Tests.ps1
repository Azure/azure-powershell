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
        $UpdateADDomain = Update-AzADDomainService -ResourceGroupName $env.ResourceGroupName -Name $env.ADdomainName -DomainSecuritySettingTlsV1 $env.TlsV1Status1
        $UpdateADDomain.DomainSecuritySettingTlsV1 | Should -Be $env.TlsV1Status1
    }

    It 'UpdateViaIdentityExpanded' {
        Start-TestSleep 240
        $GetADDomainExample = Get-AzADDomainService -ResourceGroupName $env.ResourceGroupName -Name $env.ADdomainName
        $UpdateADDomain = Update-AzADDomainService -InputObject $GetADDomainExample -DomainSecuritySettingTlsV1 $env.TlsV1Status2
        $UpdateADDomain.DomainSecuritySettingTlsV1 | Should -Be $env.TlsV1Status2
    }
}
