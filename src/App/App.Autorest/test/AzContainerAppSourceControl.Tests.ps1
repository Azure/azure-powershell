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
            $AzureClientSecret = ConvertTo-SecureString -String "1234" -Force -AsPlainText
            $RegistryPassword = ConvertTo-SecureString -String "1234" -Force -AsPlainText
            $GithubAccessToken = ConvertTo-SecureString -String "1234" -Force -AsPlainText

            New-AzContainerAppSourceControl -ContainerAppName $env.containerApp1 -ResourceGroupName $env.resourceGroupManaged -Name current -AzureClientId "UserObjectId" -AzureClientSecret $AzureClientSecret -AzureKind "feaderated" -AzureTenantId "UserDirectoryID" -Branch "main" -GithubContextPath "./" -GithubAccessToken $GithubAccessToken -GithubConfigurationImage $env.containerApp1 -RegistryPassword $RegistryPassword -RegistryUrl $evn.containerRegistry1+".azurecr.io" -RegistryUserName $env.containerRegistry1 -RepoUrl "https://github.com/lijinpei2008/ghatest"
        } | Should -Not -Throw
    }
}
