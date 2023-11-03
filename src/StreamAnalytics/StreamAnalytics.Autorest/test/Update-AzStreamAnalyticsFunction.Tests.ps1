$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzStreamAnalyticsFunction.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzStreamAnalyticsFunction' {
    It 'UpdateExpanded' {
        { Update-AzStreamAnalyticsFunction -ResourceGroupName $env.resourceGroup -JobName $env.job01 -Name $env.function01 -File (Join-Path $PSScriptRoot 'template-json\Function_JavascriptUdf.json') } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded'  {
      $result = Get-AzStreamAnalyticsFunction -ResourceGroupName $env.resourceGroup -JobName $env.job01 -Name $env.function01
      { Update-AzStreamAnalyticsFunction -InputObject $result -File (Join-Path $PSScriptRoot 'template-json\Function_JavascriptUdf.json') } | Should -Not -Throw
    }
}
