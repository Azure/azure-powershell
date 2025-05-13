if(($null -eq $TestName) -or ($TestName -contains 'Get-AzCommunicationServiceSmtpUsername'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzCommunicationServiceSmtpUsername.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzCommunicationServiceSmtpUsername' {
    It 'List' {
        $services = Get-AzCommunicationServiceSmtpUsername -CommunicationServiceName $env.persistentACSResourceName -ResourceGroupName $env.resourceGroup
        $services.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $service = Get-AzCommunicationServiceSmtpUsername -SmtpUsername $env.smtpUsernameResource -CommunicationServiceName $env.persistentACSResourceName -ResourceGroupName $env.resourceGroup
        $service.Name | Should -Be $env.smtpUsernameResource
    }

    It 'GetViaIdentityCommunicationService' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        $GetCommunicationServiceSmtpUsernameInstance = Get-AzCommunicationServiceSmtpUsername -SmtpUsername $env.smtpUsernameResource -CommunicationServiceName $env.persistentACSResourceName -ResourceGroupName $env.resourceGroup

        $GetAzCommunicationServiceSmtpUsernameInstance = Get-AzCommunicationServiceSmtpUsername -InputObject $GetCommunicationServiceSmtpUsernameInstance
        $GetAzCommunicationServiceSmtpUsernameInstance.Name | Should -Be $env.smtpUsernameResource
    }
}
