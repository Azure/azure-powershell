if(($null -eq $TestName) -or ($TestName -contains 'Get-AzStackHCIVMImage'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzStackHCIVMImage.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzStackHCIVMImage' {
    It 'BySubscription' {
        Get-AzStackHCIVMImage -SubscriptionId $env.subscriptionId | Should -Not -BeNullOrEmpty
    }

    It 'ByName' {
       Get-AzStackHCIVMImage -Name $env.imageName -ResourceGroupName $env.resourceGroupName -SubscriptionId $env.subscriptionId | Should -Not -BeNullOrEmpty
    }

    It 'ByResourceGroup' {
        Get-AzStackHCIVMImage -ResourceGroupName $env.resourceGroupName -SubscriptionId $env.subscriptionId | Should -Not -BeNullOrEmpty
    }

    It 'ByResourceId' {
        Get-AzStackHCIVMImage -ResourceId $env.vmImageId  | Should -Not -BeNullOrEmpty
    }
}
