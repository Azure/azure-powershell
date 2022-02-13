$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzStaticWebAppCustomDomain.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Test-AzStaticWebAppCustomDomain' {
    It 'ValidateExpanded' {
        { Test-AzStaticWebAppCustomDomain -ResourceGroupName $env.resourceGroup -Name $env.staticweb00 -DomainName 'www01.azpstest.net' } | Should -Not -Throw
    }

    It 'ValidateViaIdentityExpanded' {
        { 
          $domain = Get-AzStaticWebAppCustomDomain -ResourceGroupName $env.resourceGroup -Name $env.staticweb00 -DomainName 'www01.azpstest.net' 
          Test-AzStaticWebAppCustomDomain -InputObject $domain
        } | Should -Not -Throw
    }
}
