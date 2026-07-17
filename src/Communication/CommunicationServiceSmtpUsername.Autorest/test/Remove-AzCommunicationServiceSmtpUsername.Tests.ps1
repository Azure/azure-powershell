if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzCommunicationServiceSmtpUsername'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzCommunicationServiceSmtpUsername.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzCommunicationServiceSmtpUsername' {
    It 'Delete' {
        $newSmtpUsername = "smtpusername-test" + $env.rstr1
        $newUsername = "username-test" + $env.rstr1

        $NewCommunicationServiceSmtpUsernameInstance = New-AzCommunicationServiceSmtpUsername -SmtpUsername $newSmtpUsername -CommunicationServiceName $env.persistentACSResourceName -ResourceGroupName $env.resourceGroup -EntraApplicationId $env.entraApplicationId -TenantId $env.tenantId -Username $newUsername

        Remove-AzCommunicationServiceSmtpUsername -SmtpUsername $newSmtpUsername -CommunicationServiceName $env.persistentACSResourceName -ResourceGroupName $env.resourceGroup

        $serviceList = Get-AzCommunicationServiceSmtpUsername -CommunicationServiceName $env.persistentACSResourceName -ResourceGroupName $env.resourceGroup
        $serviceList.Name | Should -Not -Contain $newSmtpUsername
    }

    It 'DeleteViaIdentityCommunicationService' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        $newSmtpUsername = "smtpusername-test" + $env.rstr2
        $newUsername = "username-test" + $env.rstr2

        $NewCommunicationServiceSmtpUsernameInstance = New-AzCommunicationServiceSmtpUsername -SmtpUsername $newSmtpUsername -CommunicationServiceName $env.persistentACSResourceName -ResourceGroupName $env.resourceGroup -EntraApplicationId $env.entraApplicationId -TenantId $env.tenantId -Username $newUsername

        Remove-AzCommunicationServiceSmtpUsername -InputObject $NewCommunicationServiceSmtpUsernameInstance

        $serviceList = Get-AzCommunicationServiceSmtpUsername -CommunicationServiceName $env.persistentACSResourceName -ResourceGroupName $env.resourceGroup
        $serviceList.Name | Should -Not -Contain $newSmtpUsername
    }
}
