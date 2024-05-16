if(($null -eq $TestName) -or ($TestName -contains 'Get-AzConnectedLicense'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzConnectedLicense.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzConnectedLicense' {
    It 'List' {
        $all = @(Get-AzConnectedLicense -ResourceGroupName $env.ResourceGroupName)
        $all | Should -Not -BeNullOrEmpty
    }
    
    It 'List2' {
        $all = @(Get-AzConnectedLicense -SubscriptionId $env.SubscriptionId)
        $all | Should -Not -BeNullOrEmpty
    }

    It 'Get' {
        $all = @(Get-AzConnectedLicense -Name $env.EsuLicenseName -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId)
        $all | Should -Not -BeNullOrEmpty
    }

}
