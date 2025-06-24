if(($null -eq $TestName) -or ($TestName -contains 'Update-AzCommunicationServiceSmtpUsername'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzCommunicationServiceSmtpUsername.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzCommunicationServiceSmtpUsername' {
    It 'UpdateExpanded' {
        $updatedEntraApplicationId = "9ebe5d8a-7461-4805-8c91-82ad752bf155"

        $UpdateAzCommunicationServiceSmtpUsername = Update-AzCommunicationServiceSmtpUsername -SmtpUsername $env.smtpUsernameResource -CommunicationServiceName $env.persistentACSResourceName -ResourceGroupName $env.resourceGroup -EntraApplicationId $updatedEntraApplicationId
        $UpdateAzCommunicationServiceSmtpUsername.EntraApplicationId | Should -Be $updatedEntraApplicationId
    }

    It 'UpdateViaIdentityCommunicationServiceExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

   It 'UpdateViaIdentityExpanded' {
        $updatedEntraApplicationId = "9ebe5d8a-7461-4805-8c91-82ad752bf155"

        $GetCommunicationServiceSmtpUsernameInstance = Get-AzCommunicationServiceSmtpUsername -SmtpUsername $env.smtpUsernameResource -CommunicationServiceName $env.persistentACSResourceName -ResourceGroupName $env.resourceGroup 

        $UpdateAzCommunicationServiceSmtpUsername = Update-AzCommunicationServiceSmtpUsername -InputObject $GetCommunicationServiceSmtpUsernameInstance -EntraApplicationId $updatedEntraApplicationId
        $UpdateAzCommunicationServiceSmtpUsername.EntraApplicationId | Should -Be $updatedEntraApplicationId
    }
}
