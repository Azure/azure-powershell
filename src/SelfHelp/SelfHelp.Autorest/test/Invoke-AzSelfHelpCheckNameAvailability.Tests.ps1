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

Describe 'Invoke-AzSelfHelpCheckNameAvailability' -Tag 'LiveOnly'{
    It 'Post' {
        $resourceName = RandomString -allChars $true -len 10
        $scope = "/subscriptions/$($env.SubscriptionId)"
        $CHECKNAMEAVAILABILITYREQUEST = [ordered]@{ 
            "name" ="helloworld" 
            “type” = “solutions” 
        } 
        $result = Invoke-AzSelfHelpCheckNameAvailability -Scope $scope -CheckNameAvailabilityRequest $CHECKNAMEAVAILABILITYREQUEST
        $result.NameAvailable | Should -Be $true
    }
}
