$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStaticWebAppCustomDomain.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzStaticWebAppCustomDomain' {
    # NOTE:Before test. Need create domain zone for static web.
    It 'CreateExpanded' {
      $domainName = 'www02.azpstest.net'
      New-AzStaticWebAppCustomDomain -ResourceGroupName $env.resourceGroup -Name $env.staticweb00 -DomainName $domainName
      $domianList = Get-AzStaticWebAppCustomDomain -ResourceGroupName $env.resourceGroup -Name $env.staticweb00
      $domianList.Name | Should -Contain $domainName
    }
}
