if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDisconnectedOperationsDisconnectedOperation'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDisconnectedOperationsDisconnectedOperation.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDisconnectedOperationsDisconnectedOperation' {
    It 'List1' {
        $result = Get-AzDisconnectedOperationsDisconnectedOperation

        $result | Should -Not -BeNull

        foreach ($disconnectedOperations in $result) {
            $disconnectedOperations | Should -Not -BeNullOrEmpty
            $disconnectedOperations.Id | Should -Not -BeNullOrEmpty
        }
    }

    It 'Get' {
        $result = Get-AzDisconnectedOperationsDisconnectedOperation -Name $env.Name -ResourceGroupName $env.ResourceGroupName

        $result | Should -Not -BeNullOrEmpty
        $result.BillingModel | Should -Be "Capacity"
        $result.ConnectionIntent | Should -Be "Disconnected"
        $result.Name | Should -Be $env.Name
        $result.ResourceGroupName | Should -Be $env.ResourceGroupName
        $result.Type | Should -Be "Microsoft.Edge/disconnectedOperations"

    }

    It 'List' {
        $result = Get-AzDisconnectedOperationsDisconnectedOperation -ResourceGroupName $env.ResourceGroupName

        foreach ($resource in $result){
            $resource.BillingModel | Should -Be "Capacity"
            $resource.ConnectionIntent | Should -Be "Disconnected"
            $resource.ResourceGroupName | Should -Be $env.ResourceGroupName
            $resource.Type | Should -Be "Microsoft.Edge/disconnectedOperations"
        }
    }

    It 'GetViaIdentity' {
        $disconnectedOperationInputObject = @{
            "Name" = $env.Name;
            "ResourceGroupName" = $env.ResourceGroupName;
            "SubscriptionId" = $env.SubscriptionId;
        }
        $result = Get-AzDisconnectedOperationsDisconnectedOperation -InputObject $disconnectedOperationInputObject
        $result | Should -Not -BeNullOrEmpty
        $result.BillingModel | Should -Be "Capacity"
        $result.ConnectionIntent | Should -Be "Disconnected"
        $result.Name | Should -Be $env.Name
        $result.ResourceGroupName | Should -Be $env.ResourceGroupName
        $result.Type | Should -Be "Microsoft.Edge/disconnectedOperations"
    }
}
