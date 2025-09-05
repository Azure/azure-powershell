if(($null -eq $TestName) -or ($TestName -contains 'Get-AzRoleEligibleChildResource'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzRoleEligibleChildResource.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzRoleEligibleChildResource' {
    It 'Get' {
        { 
            $scope = "/subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d/"
            $childResources = Get-AzRoleEligibleChildResource -Scope $scope
        } | Should -Not -Throw
    }

    It 'Get with filter' {
        $scope = "/providers/Microsoft.Management/managementGroups/MG-1/"
        { 
            $scope = "/providers/Microsoft.Management/managementGroups/MG-1/"
            $childResources = Get-AzRoleEligibleChildResource -Scope $scope -Filter "resoureType eq 'resourcegroup'"
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
