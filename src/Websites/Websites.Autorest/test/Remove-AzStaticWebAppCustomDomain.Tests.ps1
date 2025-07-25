$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzStaticWebAppCustomDomain.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzStaticWebAppCustomDomain' {
    # NOTE:Before test. Need create domain zone for static web.
    It 'Delete' {
      $domainName = 'www02.azpstest.net'
      Remove-AzStaticWebAppCustomDomain -ResourceGroupName $env.resourceGroup -Name $env.staticweb00 -DomainName $domainName
      $domianList = Get-AzStaticWebAppCustomDomain -ResourceGroupName $env.resourceGroup -Name $env.staticweb00
      $domianList.Name | Should -Not -Contain $domainName
    }

    It 'DeleteViaIdentity' {
      $domainName = 'www03.azpstest.net'
      $domian = New-AzStaticWebAppCustomDomain -ResourceGroupName $env.resourceGroup -Name $env.staticweb00 -DomainName $domainName
      Remove-AzStaticWebAppCustomDomain -InputObject $domian
      $domianList = Get-AzStaticWebAppCustomDomain -ResourceGroupName $env.resourceGroup -Name $env.staticweb00
      $domianList.Name | Should -Not -Contain $domainName
    }
}
