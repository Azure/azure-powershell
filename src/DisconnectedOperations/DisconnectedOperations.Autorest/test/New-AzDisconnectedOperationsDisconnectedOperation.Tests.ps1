if(($null -eq $TestName) -or ($TestName -contains 'New-AzDisconnectedOperationsDisconnectedOperation'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDisconnectedOperationsDisconnectedOperation.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDisconnectedOperationsDisconnectedOperation' {
    It 'CreateExpanded' {
        $result = New-AzDisconnectedOperationsDisconnectedOperation -Name $env.NewResource -ResourceGroupName $env.ResourceGroupName -Location $env.Location -ConnectionIntent 'Disconnected' -Tag @{}

        $result | Should -Not -BeNullOrEmpty
        $result.BillingModel | Should -Be "Capacity"
        $result.ConnectionIntent | Should -Be "Disconnected"
        $result.Name | Should -Be $env.NewResource
        $result.ResourceGroupName | Should -Be $env.ResourceGroupName
        $result.Type | Should -Be "Microsoft.Edge/disconnectedOperations"
        $result.Location | Should -Be $env.Location

        Remove-AzDisconnectedOperationsDisconnectedOperation -Name $env.NewResource -ResourceGroupName $env.ResourceGroupName
    }

    It 'CreateViaJsonFilePath' {
        $result = New-AzDisconnectedOperationsDisconnectedOperation -Name $env.NewResource -ResourceGroupName $env.ResourceGroupName -JsonFilePath (Join-Path $PSScriptRoot './jsonFiles/CreateDisconnectedOperations.json')

        $result | Should -Not -BeNullOrEmpty
        $result.BillingModel | Should -Be "Capacity"
        $result.ConnectionIntent | Should -Be "Disconnected"
        $result.Name | Should -Be $env.NewResource
        $result.ResourceGroupName | Should -Be $env.ResourceGroupName

        Remove-AzDisconnectedOperationsDisconnectedOperation -Name $env.NewResource -ResourceGroupName $env.ResourceGroupName
    }

    It 'CreateViaJsonString' {
        $result = New-AzDisconnectedOperationsDisconnectedOperation -Name $env.NewResource -ResourceGroupName $env.ResourceGroupName -JsonString '{"properties":{"connectionIntent":"Disconnected","billingModel":"Capacity"},"tags":{},"location":"westus3"}'

        $result | Should -Not -BeNullOrEmpty
        $result.BillingModel | Should -Be "Capacity"
        $result.ConnectionIntent | Should -Be "Disconnected"
        $result.Name | Should -Be $env.NewResource
        $result.ResourceGroupName | Should -Be $env.ResourceGroupName
        $result.Type | Should -Be "Microsoft.Edge/disconnectedOperations"
        $result.Location | Should -Be "westus3"

        Remove-AzDisconnectedOperationsDisconnectedOperation -Name $env.NewResource -ResourceGroupName $env.ResourceGroupName
    }
}
