$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzStaticWebAppAttachedRepository.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzStaticWebAppAttachedRepository' {
    It 'Detach' {
      New-AzStaticWebApp -ResourceGroupName $env.resourceGroup -Name $env.staticweb02 -Location $env.location `
                        -RepositoryUrl $env.repositoryUrl -RepositoryToken $env.githubAccessToken -Branch $env.branch02 `
                        -AppLocation 'Client' -ApiLocation 'Api' -OutputLocation 'wwwroot' -SkuName 'Standard'
      { Remove-AzStaticWebAppAttachedRepository -ResourceGroupName $env.resourceGroup -Name $env.staticweb02 } | Should -Not -Throw

    }

    It 'DetachViaIdentity' {
      $web = New-AzStaticWebApp -ResourceGroupName $env.resourceGroup -Name $env.staticweb03 -Location $env.location `
                        -RepositoryUrl $env.repositoryUrl -RepositoryToken $env.githubAccessToken -Branch $env.branch02 `
                        -AppLocation 'Client' -ApiLocation 'Api' -OutputLocation 'wwwroot' -SkuName 'Standard'
      { Remove-AzStaticWebAppAttachedRepository -InputObject $web} | Should -Not -Throw
    }
}
