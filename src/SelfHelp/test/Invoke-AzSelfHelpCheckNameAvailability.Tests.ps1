if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzSelfHelpCheckNameAvailability'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzSelfHelpCheckNameAvailability.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzSelfHelpCheckNameAvailability' {
    It 'PostExpanded' -skip {
        $resourceName = RandomString -allChars $true -len 10
        $scope = "/subscriptions/$($env.SubscriptionId)"
        $type = "microsoft.help/help"
        $result = Invoke-AzSelfHelpDiagnosticNameAvailability -Name $resourceName -Type $type -Scope $scope
        $result.NameAvailable | Should -Be $true
    }
}
