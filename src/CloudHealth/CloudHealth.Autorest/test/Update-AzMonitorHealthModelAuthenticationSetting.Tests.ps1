if(($null -eq $TestName) -or ($TestName -contains 'Update-AzMonitorHealthModelAuthenticationSetting'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzMonitorHealthModelAuthenticationSetting.Recording.json'
  $currentPath = $PSScriptRoot
  $mockingPath = $null
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzMonitorHealthModelAuthenticationSetting' {
    It 'UpdateExpanded' {
        {
            $property = New-AzMonitorHealthModelManagedIdentityAuthenticationSettingPropertiesObject -ManagedIdentityName 'SystemAssigned' -DisplayName 'Updated auth setting'
            $result = Update-AzMonitorHealthModelAuthenticationSetting -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -Name $env.AuthenticationSettingName -Property $property
            $result | Should -Not -BeNullOrEmpty
            $result.Name | Should -Be $env.AuthenticationSettingName
            ($result | ConvertTo-Json -Depth 20) | Should -Match 'Updated auth setting'
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityHealthmodelExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

}
