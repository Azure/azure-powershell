if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzDevCenterAdminExecuteCheckScopedNameAvailability'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzDevCenterAdminExecuteCheckScopedNameAvailability.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzDevCenterAdminExecuteCheckScopedNameAvailability' {
    It 'ExecuteExpanded' {
        $avail = Invoke-AzDevCenterAdminExecuteCheckScopedNameAvailability -Name $env.devCenterCatalogWithSyncError -Type "Microsoft.DevCenter/projects/catalogs" -Scope "/subscriptions/306bbddd-068b-4efc-a779-50342af2547a/resourceGroups/ibiza-testing/providers/Microsoft.DevCenter/projects/test-ibiza-project" -SubscriptionId $env.SubscriptionId2
        $avail.Message | Should -Be "Project catalog names must be unique within the project and its associated devcenter. Retry the operation with a different Catalog name."

        $unusedName =  $env.devCenterCatalogWithSyncError + "11"
        $avail = Invoke-AzDevCenterAdminExecuteCheckScopedNameAvailability -Name $unusedName -Type "Microsoft.DevCenter/projects/catalogs" -Scope "/subscriptions/306bbddd-068b-4efc-a779-50342af2547a/resourceGroups/ibiza-testing/providers/Microsoft.DevCenter/projects/test-ibiza-project" -SubscriptionId $env.SubscriptionId2
        $avail.NameAvailable | Should -Be "True"
    }
}
