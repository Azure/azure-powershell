if(($null -eq $TestName) -or `
   ($TestName -contains 'New-AzMonitorHealthModelAuthenticationSetting') -or `
   ($TestName -contains 'New-AzMonitorHealthModelManagedIdentityAuthenticationSettingPropertiesObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMonitorHealthModelAuthenticationSetting.Recording.json'
  $currentPath = $PSScriptRoot
  $mockingPath = $null
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzMonitorHealthModelAuthenticationSetting' {
    It 'CreateExpanded' {
        {
            $property = New-AzMonitorHealthModelManagedIdentityAuthenticationSettingPropertiesObject -ManagedIdentityName 'SystemAssigned' -DisplayName 'Create auth'
            $result = New-AzMonitorHealthModelAuthenticationSetting -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -Name $env.AuthenticationSettingCreateName -Property $property
            $result | Should -Not -BeNullOrEmpty
            $result.Name | Should -Be $env.AuthenticationSettingCreateName
        } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

}

Describe 'New-AzMonitorHealthModelManagedIdentityAuthenticationSettingPropertiesObject' {
    It '__AllParameterSets' {
        $property = New-AzMonitorHealthModelManagedIdentityAuthenticationSettingPropertiesObject -ManagedIdentityName 'SystemAssigned' -DisplayName 'Managed identity'
        $property.ManagedIdentityName | Should -Be 'SystemAssigned'
        $property.DisplayName | Should -Be 'Managed identity'
    }

}
