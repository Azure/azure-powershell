if(($null -eq $TestName) -or ($TestName -contains 'Update-AzDisconnectedOperationsDisconnectedOperation'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDisconnectedOperationsDisconnectedOperation.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDisconnectedOperationsDisconnectedOperation' {
    It 'UpdateExpanded' {
        $result = Update-AzDisconnectedOperationsDisconnectedOperation -Name $env.Name -ResourceGroupName $env.ResourceGroupName -RegistrationStatus $env.RegistrationStatusRegistered

        $result | Should -Not -BeNullOrEmpty
        $result.RegistrationStatus | Should -Be "Registered"
        $result.Name | Should -Be $env.Name
        $result.ResourceGroupName | Should -Be $env.ResourceGroupName
        $result.Type | Should -Be "Microsoft.Edge/disconnectedOperations"

        Update-AzDisconnectedOperationsDisconnectedOperation -Name $env.Name -ResourceGroupName $env.ResourceGroupName -RegistrationStatus $env.RegistrationStatusUnregistered

    }

    It 'UpdateViaJsonString' {
        $result = Update-AzDisconnectedOperationsDisconnectedOperation -Name $env.Name -ResourceGroupName $env.ResourceGroupName -JsonString '{"properties":{"registrationStatus": "Registered"}}'

        $result | Should -Not -BeNullOrEmpty
        $result.RegistrationStatus | Should -Be "Registered"
        $result.Name | Should -Be $env.Name
        $result.ResourceGroupName | Should -Be $env.ResourceGroupName
        $result.Type | Should -Be "Microsoft.Edge/disconnectedOperations"

        Update-AzDisconnectedOperationsDisconnectedOperation -Name $env.Name -ResourceGroupName $env.ResourceGroupName -RegistrationStatus $env.RegistrationStatusUnregistered
    }

    It 'UpdateViaJsonFilePath' {
        $result = Update-AzDisconnectedOperationsDisconnectedOperation -Name $env.Name -ResourceGroupName $env.ResourceGroupName -JsonFilePath (Join-Path $PSScriptRoot './jsonFiles/UpdateDisconnectedOperations.json')

        $result | Should -Not -BeNullOrEmpty
        $result.RegistrationStatus | Should -Be "Registered"
        $result.Name | Should -Be $env.Name
        $result.ResourceGroupName | Should -Be $env.ResourceGroupName
        $result.Type | Should -Be "Microsoft.Edge/disconnectedOperations"

        Update-AzDisconnectedOperationsDisconnectedOperation -Name $env.Name -ResourceGroupName $env.ResourceGroupName -RegistrationStatus $env.RegistrationStatusUnregistered
    }

    It 'UpdateViaIdentityExpanded' {
        $disconnectedOperationInputObject = @{
            "Name" = $env.Name;
            "ResourceGroupName" = $env.ResourceGroupName;
            "SubscriptionId" = $env.SubscriptionId;
        }

        $result = Update-AzDisconnectedOperationsDisconnectedOperation -InputObject $disconnectedOperationInputObject -RegistrationStatus $env.RegistrationStatusRegistered

        $result | Should -Not -BeNullOrEmpty
        $result.RegistrationStatus | Should -Be "Registered"
        $result.Name | Should -Be $env.Name
        $result.ResourceGroupName | Should -Be $env.ResourceGroupName
        $result.Type | Should -Be "Microsoft.Edge/disconnectedOperations"

        Update-AzDisconnectedOperationsDisconnectedOperation -Name $env.Name -ResourceGroupName $env.ResourceGroupName -RegistrationStatus $env.RegistrationStatusUnregistered
    }
}
