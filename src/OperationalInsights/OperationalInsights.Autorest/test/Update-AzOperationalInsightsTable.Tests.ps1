if(($null -eq $TestName) -or ($TestName -contains 'Update-AzOperationalInsightsTable'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzOperationalInsightsTable.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzOperationalInsightsTable' {
    BeforeAll { 
        $rgName = "dabenham-dev"
        $wsName = "dabenham-PSH2"
        $tableName = "dabenhamKuku1_CL"
        $existingTable = Get-AzOperationalInsightsTable -ResourceGroupName $rgName -WorkspaceName $wsName -TableName $tableName
        $currentRetention = $existingTable.RetentionInDay
    }

    It 'UpdateExpanded' {
        $updatedTable = Update-AzOperationalInsightsTable -ResourceGroupName $rgName -WorkspaceName $wsName -Name $tableName -RetentionInDay ($currentRetention + 1)
        $updatedTable.RetentionInDay | Should Be ($currentRetention +1)
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
