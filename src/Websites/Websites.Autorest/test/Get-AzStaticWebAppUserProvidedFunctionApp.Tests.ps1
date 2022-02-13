$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzStaticWebAppUserProvidedFunctionApp.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzStaticWebAppUserProvidedFunctionApp' {
    It 'List1' {
      $functionList = Get-AzStaticWebAppUserProvidedFunctionApp -ResourceGroupName $env.resourceGroup -Name $env.staticweb00
      $functionList.Count | Should -BeGreaterOrEqual 1
    }

    It 'List' {
      $functionList = Get-AzStaticWebAppUserProvidedFunctionApp -ResourceGroupName $env.resourceGroup -Name $env.staticweb00 -EnvironmentName 'default'
      $functionList.Count | Should -BeGreaterOrEqual 1
    }

    It 'List2' {
      $functionList = Get-AzStaticWebAppUserProvidedFunctionApp -ResourceGroupName $env.resourceGroup -Name $env.staticweb00 -FunctionAppName $env.functionAppName01
      $functionList.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
      $function = Get-AzStaticWebAppUserProvidedFunctionApp -ResourceGroupName $env.resourceGroup -Name $env.staticweb00 -EnvironmentName 'default' -FunctionAppName $env.functionAppName01
      $function.Name | Should -Be $env.functionAppName01
    }

    It 'GetViaIdentity' {
      $function = Get-AzStaticWebAppUserProvidedFunctionApp -ResourceGroupName $env.resourceGroup -Name $env.staticweb00 -EnvironmentName 'default' -FunctionAppName $env.functionAppName01
      $function = Get-AzStaticWebAppUserProvidedFunctionApp -InputObject $function
      $function.Name | Should -Be $env.functionAppName01
    }
}
