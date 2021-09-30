if(($null -eq $TestName) -or ($TestName -contains 'Add-AzPurviewAccountRootCollectionAdmin'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Add-AzPurviewAccountRootCollectionAdmin.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Add-AzPurviewAccountRootCollectionAdmin' {
    It 'AddExpanded' {
        { Add-AzPurviewAccountRootCollectionAdmin -AccountName $env.accountName -ResourceGroupName $env.resourceGroupName -ObjectId $env.objectId } | Should -Not -Throw
    }

    It 'AddViaIdentityExpanded' {
        $got = Get-AzPurviewAccount -Name $env.accountName -ResourceGroupName $env.resourceGroupName
        { Add-AzPurviewAccountRootCollectionAdmin -InputObject $got -ObjectId $env.objectId } | Should -Not -Throw
    }
}
