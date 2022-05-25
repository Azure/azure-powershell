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
            $mypwd = ConvertTo-SecureString -String "1234" -Force -AsPlainText
            New-AzContainerAppSourceControl -ContainerAppName $env.containerAppName -ResourceGroupName $env.resourceGroup -SourceControlName current -RepoUrl https://github.com/lijinpei2008/ghatest -Branch master -RegistryInfoRegistryUrl $env.registryUrl -RegistryInfoRegistryUserName $env.acrName -RegistryInfoRegistryPassword $env.containerRegistryCredential -GithubActionConfigurationContextPath "./Dockerfile" -GithubActionConfigurationImage "image/tag" -AzureCredentialsClientId $env.Tenant -AzureCredentialsClientSecret $mypwd -AzureCredentialsTenantId $env.Tenant -GithubActionConfigurationOS Linux
        } | Should -Not -Throw
    }

    It 'List' -skip {
        {} | Should -Not -Throw
    }

    It 'Delete' -skip {
        {} | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        {} | Should -Not -Throw
    }
}
