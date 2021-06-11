$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzStreamAnalyticsFunction.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzStreamAnalyticsFunction' {
    It 'List' {
        $result = Get-AzStreamAnalyticsFunction -ResourceGroupName $env.resourceGroup -JobName $env.job01
        $result.Count | Should -Be 2
    }

    It 'Get' {
      $result = Get-AzStreamAnalyticsFunction -ResourceGroupName $env.resourceGroup -JobName $env.job01 -Name $env.function01
      $result.Name | Should -Be $env.function01   
    }

    It 'GetViaIdentity' {
      $result = Get-AzStreamAnalyticsFunction -ResourceGroupName $env.resourceGroup -JobName $env.job01 -Name $env.function01
      $result = Get-AzStreamAnalyticsFunction -InputObject $result
      $result.Name | Should -Be $env.function01 
    }
}
