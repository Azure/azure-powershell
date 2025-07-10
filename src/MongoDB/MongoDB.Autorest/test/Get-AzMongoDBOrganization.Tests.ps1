if(($null -eq $TestName) -or ($TestName -contains 'Get-AzMongoDbOrganization'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMongoDbOrganization.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzMongoDbOrganization' {
    It 'List' {
        { Get-AzMongoDbOrganization -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId } | Should -Not -Throw
    }

    It 'Get' {
        { Get-AzMongoDbOrganization -Name $env.ResourceName -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId } | Should -Not -Throw
    }

    It 'List1' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
