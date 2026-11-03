if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzMonitorHealthModelAuthenticationSetting'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzMonitorHealthModelAuthenticationSetting.Recording.json'
  $currentPath = $PSScriptRoot
  $mockingPath = $null
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzMonitorHealthModelAuthenticationSetting' {
    It 'Delete' {
        {
            $property = New-AzMonitorHealthModelManagedIdentityAuthenticationSettingPropertiesObject -ManagedIdentityName 'SystemAssigned' -DisplayName 'Delete auth'
            New-AzMonitorHealthModelAuthenticationSetting -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -Name $env.AuthenticationSettingDeleteName -Property $property | Out-Null
            $deleted = Remove-AzMonitorHealthModelAuthenticationSetting -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -Name $env.AuthenticationSettingDeleteName -PassThru
            $deleted | Should -BeTrue
            { Get-AzMonitorHealthModelAuthenticationSetting -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -Name $env.AuthenticationSettingDeleteName -ErrorAction Stop } | Should -Throw
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentityHealthmodel' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

}
