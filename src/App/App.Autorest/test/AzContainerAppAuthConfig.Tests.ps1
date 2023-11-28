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
            $identity = New-AzContainerAppIdentityProviderObject -RegistrationAppId "xxxxxx@xxx.com" -RegistrationAppSecretSettingName redis-config
            $config = New-AzContainerAppAuthConfig -Name current -ContainerAppName $env.containerApp2 -ResourceGroupName $env.resourceGroupConnected -PlatformEnabled -GlobalValidationUnauthenticatedClientAction 'AllowAnonymous' -IdentityProvider $identity
            $config.Name | Should -Be "current"
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzContainerAppAuthConfig -Name current -ContainerAppName $env.containerApp2 -ResourceGroupName $env.resourceGroupConnected
            $config.Name | Should -Be "current"
        } | Should -Not -Throw
    }

    It 'AuthTokenGet' {
        {
            $config = Get-AzContainerAppAuthToken -ContainerAppName $env.containerApp2 -ResourceGroupName $env.resourceGroupConnected
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzContainerAppAuthConfig -AuthConfigName current -ContainerAppName $env.containerApp2 -ResourceGroupName $env.resourceGroupConnected
        } | Should -Not -Throw
    }
}
