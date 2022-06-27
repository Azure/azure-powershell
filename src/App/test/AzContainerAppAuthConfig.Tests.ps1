if(($null -eq $TestName) -or ($TestName -contains 'AzContainerAppAuthConfig'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzContainerAppAuthConfig.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzContainerAppAuthConfig' {
    It 'CreateExpanded' {
        {
            $identity = New-AzContainerAppIdentityProviderObject -RegistrationAppId "xxxx@xx.com" -RegistrationAppSecretSettingName "facebook-secret"
            $config = New-AzContainerAppAuthConfig -AuthConfigName current -ContainerAppName $env.containerAppName -ResourceGroupName $env.resourceGroup -PlatformEnabled -GlobalValidationUnauthenticatedClientAction 'AllowAnonymous' -IdentityProvider $identity
            $config.Name | Should -Be "current"
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzContainerAppAuthConfig -AuthConfigName current -ContainerAppName $env.containerAppName -ResourceGroupName $env.resourceGroup
            $config.Name | Should -Be "current"
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzContainerAppAuthConfig -AuthConfigName current -ContainerAppName $env.containerAppName -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }
}
