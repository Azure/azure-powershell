if(($null -eq $TestName) -or ($TestName -contains 'New-AzExtensionDataSourceObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzExtensionDataSourceObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzExtensionDataSourceObject' {
    It '__AllParameterSets' {
        {
            New-AzExtensionDataSourceObject -ExtensionName AzureSecurityLinuxAgent -ExtensionSetting @{auditLevel='4'; maxQueueSize='1234'} -Name "myExtensionDataSource1" -Stream "Microsoft-OperationLog"
        } | Should -Not -Throw
    }
}
