if(($null -eq $TestName) -or ($TestName -contains 'New-AzCommunicationServiceSmtpUsername'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzCommunicationServiceSmtpUsername.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzCommunicationServiceSmtpUsername' {
   It 'CreateExpanded' {
        $NewAzCommunicationServiceSmtpUsername = New-AzCommunicationServiceSmtpUsername -SmtpUsername $env.smtpUsernameResource -CommunicationServiceName $env.persistentACSResourceName -ResourceGroupName $env.resourceGroup -EntraApplicationId $env.entraApplicationId -TenantId $env.tenantId -Username $env.username
        $NewAzCommunicationServiceSmtpUsername.Name | Should -Be $env.smtpUsernameResource
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
