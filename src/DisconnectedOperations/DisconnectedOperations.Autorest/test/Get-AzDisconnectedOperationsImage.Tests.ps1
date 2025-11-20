if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDisconnectedOperationsImage'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDisconnectedOperationsImage.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDisconnectedOperationsImage' {
    It 'List' {
        $result = Get-AzDisconnectedOperationsImage -Name $env.Name -ResourceGroupName $env.ResourceGroupName
        foreach($image in $result) {
            $image | Should -Not -BeNullOrEmpty
            $image.Type | Should -Be 'Microsoft.Edge/disconnectedOperations/images'
            $image.Id | Should -Not -BeNullOrEmpty
            $image.ResourceGroupName | Should -Be $env.ResourceGroupName
        }
    }

    It 'Get' {
        $result = Get-AzDisconnectedOperationsImage -ImageName $env.ImageName -Name $env.Name -ResourceGroupName $env.ResourceGroupName
        $result | Should -Not -BeNullOrEmpty
        $result.Type | Should -Be 'Microsoft.Edge/disconnectedOperations/images'
        $result.Id | Should -Not -BeNullOrEmpty
        $result.ResourceGroupName | Should -Be $env.ResourceGroupName
    }

    It 'GetViaIdentity' {
        $imageInputObject = @{
            "ImageName" = $env.ImageName;
            "Name" = $env.Name;
            "ResourceGroupName" = $env.ResourceGroupName;
            "SubscriptionId" = $env.SubscriptionId;
        }
        $result = Get-AzDisconnectedOperationsImage -InputObject $imageInputObject
        $result | Should -Not -BeNullOrEmpty
        $result.Type | Should -Be 'Microsoft.Edge/disconnectedOperations/images'
        $result.Id | Should -Not -BeNullOrEmpty
        $result.ResourceGroupName | Should -Be $env.ResourceGroupName
    }

    It 'GetViaIdentityDisconnectedOperation' {
        $disconnectedOperationInputObject = @{
            "Name" = $env.Name;
            "ResourceGroupName" = $env.ResourceGroupName;
            "SubscriptionId" = $env.SubscriptionId;
        }
        $result = Get-AzDisconnectedOperationsImage -ImageName $env.ImageName -DisconnectedOperationInputObject $disconnectedOperationInputObject
        $result | Should -Not -BeNullOrEmpty
        $result.Type | Should -Be 'Microsoft.Edge/disconnectedOperations/images'
        $result.Id | Should -Not -BeNullOrEmpty
        $result.ResourceGroupName | Should -Be $env.ResourceGroupName
    }
}
