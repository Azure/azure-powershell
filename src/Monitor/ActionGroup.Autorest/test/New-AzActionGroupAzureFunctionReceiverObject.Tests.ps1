if(($null -eq $TestName) -or ($TestName -contains 'New-AzActionGroupAzureFunctionReceiverObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzActionGroupAzureFunctionReceiverObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzActionGroupAzureFunctionReceiverObject' {
    It '__AllParameterSets' {
        {
            New-AzActionGroupAzureFunctionReceiverObject -FunctionAppResourceId "/subscriptions/5def922a-3ed4-49c1-b9fd-05ec533819a3/resourceGroups/aznsTest/providers/Microsoft.Web/sites/testFunctionApp" -FunctionName HttpTriggerCSharp1 -HttpTriggerUrl "http://test.me" -Name "sample azure function" -UseCommonAlertSchema $true
        } | Should -Not -Throw
    }
}
