if(($null -eq $TestName) -or ($TestName -contains 'Get-AzRelationshipsContainsRelationship'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzRelationshipsContainsRelationship.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzRelationshipsContainsRelationship' {
    It 'ListBySubscription' {
        { Get-AzRelationshipsContainsRelationship -SubscriptionId $env.SubscriptionId -ErrorAction Stop } | Should -Throw
    }

    It 'ListByResourceGroup' {
        { Get-AzRelationshipsContainsRelationship -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.SgmResourceGroupName -ErrorAction Stop } | Should -Throw
    }
}
