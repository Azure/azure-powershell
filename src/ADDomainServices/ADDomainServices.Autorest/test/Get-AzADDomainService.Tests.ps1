$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzADDomainService.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzADDomainService' {
    It 'List' {
        $GetADDomainList = Get-AzADDomainService
        $GetADDomainList.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $GetADDomain = Get-AzADDomainService -ResourceGroupName $env.ResourceGroupName -Name $env.ADdomainName
        $GetADDomain.Name | Should -Be $env.ADdomainName
    }

    It 'List1' {
        $GetADDomainList = Get-AzADDomainService -ResourceGroupName $env.ResourceGroupName
        $GetADDomainList.Count | Should -BeGreaterOrEqual 1
    }

    It 'GetViaIdentity' {
        $GetADDomainExample = Get-AzADDomainService -ResourceGroupName $env.ResourceGroupName -Name $env.ADdomainName
        $GetADDomain = Get-AzADDomainService -InputObject $GetADDomainExample
        $GetADDomain.Name | Should -Be $env.ADdomainName
    }
}
