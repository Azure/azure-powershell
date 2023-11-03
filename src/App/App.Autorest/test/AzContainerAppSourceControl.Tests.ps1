if(($null -eq $TestName) -or ($TestName -contains 'AzContainerAppSourceControl'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzContainerAppSourceControl.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzContainerAppSourceControl' {
    It 'CreateExpanded' -skip {
        {
            # Contains confidential information, please run it locally
            # $mypwd = ConvertTo-SecureString -String "1234" -Force -AsPlainText
            # $registryUrl = (Get-AzContainerRegistry -ResourceGroupName $env.resourceGroup -Name $env.acrName).LoginServer
            # $containerRegistryCredential = (Get-AzContainerRegistryCredential -ResourceGroupName $env.resourceGroup -Name $env.acrName).Password
            # $storageAccountKey = (Get-AzStorageAccountKey -ResourceGroupName $env.resourceGroup -AccountName $env.storageAccount).Value[0]

            # New-AzContainerAppSourceControl -ContainerAppName $env.containerAppName -ResourceGroupName $env.resourceGroup -SourceControlName current -RepoUrl https://github.com/yourgithub -Branch master -RegistryInfoRegistryUrl $registryUrl -RegistryInfoRegistryUserName $env.acrName -RegistryInfoRegistryPassword $containerRegistryCredential -GithubActionConfigurationContextPath "./Dockerfile" -GithubActionConfigurationImage "image/tag" -AzureCredentialsClientId $env.Tenant -AzureCredentialsClientSecret $mypwd -AzureCredentialsTenantId $env.Tenant -GithubActionConfigurationOS Linux
        } | Should -Not -Throw
    }
}
