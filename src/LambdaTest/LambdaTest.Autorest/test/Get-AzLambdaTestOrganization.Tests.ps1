if(($null -eq $TestName) -or ($TestName -contains 'Get-AzLambdaTestOrganization'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzLambdaTestOrganization.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzLambdaTestOrganization' {
    
    It 'Get' {
        { 
            $result =  Get-AzLambdaTestOrganization -SubscriptionId  $env.SubscriptionId -ResourceGroupName $env.ResourceGroupName -Name $env.ResourceName
            $result.Count | Should -BeGreaterThan 0 
        } | Should -Not -Throw
    }
}
