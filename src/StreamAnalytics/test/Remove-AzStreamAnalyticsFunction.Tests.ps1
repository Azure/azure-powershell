$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzStreamAnalyticsFunction.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzStreamAnalyticsFunction' {
    It 'Delete' {
      New-AzStreamAnalyticsFunction -ResourceGroupName $env.resourceGroup -JobName $env.job02 -Name $env.function01 -File (Join-Path $PSScriptRoot 'template-json\Function_JavascriptUdf.json')
      Remove-AzStreamAnalyticsFunction -ResourceGroupName $env.resourceGroup -JobName $env.job02 -Name $env.function01
      $result = Get-AzStreamAnalyticsFunction -ResourceGroupName $env.resourceGroup -JobName $env.job02
      $result.Name | Should -Not -Contain $env.function01
    }

    It 'DeleteViaIdentity' {
      New-AzStreamAnalyticsFunction -ResourceGroupName $env.resourceGroup -JobName $env.job02 -Name $env.function02 -File (Join-Path $PSScriptRoot 'template-json\Function_JavascriptUdf.json')
      $result = Get-AzStreamAnalyticsFunction -ResourceGroupName $env.resourceGroup -JobName $env.job02 -Name $env.function02
      Remove-AzStreamAnalyticsFunction -InputObject $result
      $result = Get-AzStreamAnalyticsFunction -ResourceGroupName $env.resourceGroup -JobName $env.job02
      $result.Name | Should -Not -Contain $env.function02
    }
}
