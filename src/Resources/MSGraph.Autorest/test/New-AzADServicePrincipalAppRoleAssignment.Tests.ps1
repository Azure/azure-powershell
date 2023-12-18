if(($null -eq $TestName) -or ($TestName -contains 'New-AzADServicePrincipalAppRoleAssignment'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzADServicePrincipalAppRoleAssignment.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzADServicePrincipalAppRoleAssignment' {
    It 'ObjectIdWithResourceIdParameterSet' -skip {
        $appRa = New-AzADServicePrincipalAppRoleAssignment -ServicePrincipalId $env.spId1 -ResourceId $env.resourceId1 -AppRoleId $env.appRoleId
        $appRa.AppRoleId | Should -Be $env.appRoleId
    }

    It 'ObjectIdWithResourceDisplayNameParameterSet' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SPNWithResourceIdParameterSet' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SPNWithResourceDisplayNameParameterSet' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
