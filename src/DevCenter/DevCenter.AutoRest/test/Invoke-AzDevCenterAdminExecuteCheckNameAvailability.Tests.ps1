if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzDevCenterAdminExecuteCheckNameAvailability'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzDevCenterAdminExecuteCheckNameAvailability.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzDevCenterAdminExecuteCheckNameAvailability' {
    It 'ExecuteExpanded' {
        $avail = Invoke-AzDevCenterAdminExecuteCheckNameAvailability -Name $env.devCenterName -Type "Microsoft.devcenter/devcenters"
        $avail.Message | Should -Be "Failed to create the DevCenter as the name is already in use. DevCenter names must be unique within the tenant. Retry the operation with a different DevCenter name"

        $unusedName =  $env.devCenterName + "11"
        $avail = Invoke-AzDevCenterAdminExecuteCheckNameAvailability -Name $unusedName -Type "Microsoft.devcenter/devcenters"
        $avail.NameAvailable | Should -Be "True"
    }
}
