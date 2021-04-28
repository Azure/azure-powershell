$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzStaticWebAppDetachUserProvidedFunctionAppFromStaticSite.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Invoke-AzStaticWebAppDetachUserProvidedFunctionAppFromStaticSite' {
    It 'Detach' {
      Invoke-AzStaticWebAppDetachUserProvidedFunctionAppFromStaticSite -ResourceGroupName $env.resourceGroup -Name $env.staticweb00 -FunctionAppName $env.functionAppName01
      $functionList = Get-AzStaticWebAppUserProvidedFunctionApp -ResourceGroupName $env.resourceGroup -Name $env.staticweb00
      $functionList.Name | Should -Not -Contain $env.functionAppName01
    }

    It 'DetachViaIdentity' {
      $function = Register-AzStaticWebAppUserProvidedFunctionApp -ResourceGroupName $env.resourceGroup -Name $env.staticweb00 -FunctionAppName $env.functionAppName01 -FunctionAppResourceId $env.functionAppId01 -FunctionAppRegion $env.location -IsForced
      Invoke-AzStaticWebAppDetachUserProvidedFunctionAppFromStaticSite -InputObject $function 
      $functionList = Get-AzStaticWebAppUserProvidedFunctionApp -ResourceGroupName $env.resourceGroup -Name $env.staticweb00
      $functionList.Name | Should -Not -Contain $env.functionAppName01
    }
}
