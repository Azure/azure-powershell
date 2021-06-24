$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzStaticWebApp.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzStaticWebApp' {
    It 'Delete' {
      Remove-AzStaticWebApp -ResourceGroupName $env.resourceGroup -Name $env.staticweb02
      $webList = Get-AzStaticWebApp -ResourceGroupName $env.resourceGroup
      $webList.Name | Should -Not -Contain $env.staticweb02
    } 

    It 'DeleteViaIdentity' {
      New-AzStaticWebApp -ResourceGroupName $env.resourceGroup -Name $env.staticweb02 -Location $env.location `
                        -RepositoryUrl $env.repositoryUrl -RepositoryToken $env.githubAccessToken -Branch $env.branch02 `
                        -AppLocation 'Client' -ApiLocation 'Api' -OutputLocation 'wwwroot' -SkuName 'Standard'
      $web =  Get-AzStaticWebApp -ResourceGroupName $env.resourceGroup -Name $env.staticweb02
      Remove-AzStaticWebApp -InputObject $web
      $webList = Get-AzStaticWebApp -ResourceGroupName $env.resourceGroup
      $webList.Name | Should -Not -Contain $env.staticweb02
    }
}
