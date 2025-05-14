if(($null -eq $TestName) -or ($TestName -contains 'New-AzDataTransferConnection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDataTransferConnection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDataTransferConnection' {
    It 'CreateNewConnection' {
        {
            # Create a new connection
            New-AzDataTransferConnection -Location $env:Location -PipelineName $env:PipelineName -Direction $env:Direction -FlowType $env:FlowType -ResourceGroupName $env:ResourceGroupName -Justification $env:Justification -RemoteSubscriptionId $env:RemoteSubscriptionId -RequirementId $env:RequirementId -Name $env:ConnectionName -PrimaryContact $env:PrimaryContact -Confirm:$false | Should -BeNullOrEmpty

            # Verify the connection is created
            $createdConnection = Get-AzDataTransferConnection -ResourceGroupName $env:ResourceGroupName -Name $env:ConnectionName
            $createdConnection | Should -Not -BeNullOrEmpty
            $createdConnection.Name | Should -Be $env:ConnectionName
        } | Should -Not -Throw
    }

    It 'CreateExistingConnection' {
        {
            # Ensure the connection already exists
            New-AzDataTransferConnection -Location $env:Location -PipelineName $env:PipelineName -Direction $env:Direction -FlowType $env:FlowType -ResourceGroupName $env:ResourceGroupName -Justification $env:Justification -RemoteSubscriptionId $env:RemoteSubscriptionId -RequirementId $env:RequirementId -Name $env:ConnectionName -PrimaryContact $env:PrimaryContact -Confirm:$false | Should -BeNullOrEmpty

            # Attempt to create the same connection again
            New-AzDataTransferConnection -Location $env:Location -PipelineName $env:PipelineName -Direction $env:Direction -FlowType $env:FlowType -ResourceGroupName $env:ResourceGroupName -Justification $env:Justification -RemoteSubscriptionId $env:RemoteSubscriptionId -RequirementId $env:RequirementId -Name $env:ConnectionName -PrimaryContact $env:PrimaryContact -Confirm:$false | Should -BeNullOrEmpty

            # Verify the connection still exists and no duplicate is created
            $existingConnection = Get-AzDataTransferConnection -ResourceGroupName $env:ResourceGroupName -Name $env:ConnectionName
            $existingConnection | Should -Not -BeNullOrEmpty
            $existingConnection.Name | Should -Be $env:ConnectionName
        } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
