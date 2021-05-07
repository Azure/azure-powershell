$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzStaticWebApp.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzStaticWebApp' {
    It 'List' {
      $webList = Get-AzStaticWebApp
      $webList.Count | Should -BeGreaterOrEqual 2
    }

    It 'List1' {
      $webList = Get-AzStaticWebApp -ResourceGroupName $env.resourceGroup
      $webList.Count | Should -Be 2
    }

    It 'Get' {
      $web = Get-AzStaticWebApp -ResourceGroupName $env.resourceGroup -Name $env.staticweb00
      $web.Name | Should -Be $env.staticweb00
    }

    It 'GetViaIdentity' {
      $web = Get-AzStaticWebApp -ResourceGroupName $env.resourceGroup -Name $env.staticweb00
      $web = Get-AzStaticWebApp -InputObject $web
      $web.Name | Should -Be $env.staticweb00
    }
}
