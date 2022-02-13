$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStaticWebApp.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzStaticWebApp' {
    It 'CreateExpanded' {
      { New-AzStaticWebApp -ResourceGroupName $env.resourceGroup -Name $env.staticweb02 -Location $env.location `
                        -RepositoryUrl $env.repositoryUrl -RepositoryToken $env.githubAccessToken -Branch $env.branch02 `
                        -AppLocation 'Client' -ApiLocation 'Api' -OutputLocation 'wwwroot' -SkuName 'Standard' } | Should -Not -Throw
    }
}
