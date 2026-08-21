if(($null -eq $TestName) -or ($TestName -contains 'Get-AzNapsterOrganization'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzNapsterOrganization.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzNapsterOrganization' {

    It 'Get' {
        {
            $result = Get-AzNapsterOrganization -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -Name $env.ResourceName
            $result.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $result = Get-AzNapsterOrganization -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName
            $result.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'List1' {
        {
            $result = Get-AzNapsterOrganization -SubscriptionId $env.SubscriptionId
            $result.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }
}
