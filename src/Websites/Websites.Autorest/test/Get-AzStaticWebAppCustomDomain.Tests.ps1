$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzStaticWebAppCustomDomain.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzStaticWebAppCustomDomain' {
    # NOTE:Before test. Need create domain zone for static web.
    It 'List'  {
      $domianList = Get-AzStaticWebAppCustomDomain -ResourceGroupName $env.resourceGroup -Name $env.staticweb00
      $domianList.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
      $domainName = 'www01.azpstest.net'
      $domian = Get-AzStaticWebAppCustomDomain -ResourceGroupName $env.resourceGroup -Name $env.staticweb00 -DomainName $domainName
      $domian.Name | Should -Be $domainName
    }

    It 'GetViaIdentity' {
      $domainName = 'www01.azpstest.net'
      $domian = Get-AzStaticWebAppCustomDomain -ResourceGroupName $env.resourceGroup -Name $env.staticweb00 -DomainName $domainName
      $domian = Get-AzStaticWebAppCustomDomain -InputObject $domian
      $domian.Name | Should -Be $domainName
    }
}
