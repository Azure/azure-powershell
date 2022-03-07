if(($null -eq $TestName) -or ($TestName -contains 'Get-AzOperationalInsightsTable'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzOperationalInsightsTable.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzOperationalInsightsTable' {
        
    BeforeAll { 
        $rgName = "dabenham-dev"
        $wsName = "dabenham-PSH2"
        $tableName = "dabenhamKuku1_CL"
    }

    It 'List' {
        $allTablesForWs = Get-AzOperationalInsightsTable -ResourceGroupName $rgName -WorkspaceName $wsName  
        Write-Host -ForegroundColor Yellow "Get-AzOperationalInsightsTable List returned with: $($allTablesForWs.Count) results"
        $allTablesForWs.Count | Should BeGreaterThan 0
    }

    It 'Get' {
        $table = Get-AzOperationalInsightsTable -ResourceGroupName $rgName -WorkspaceName $wsName -TableName $tableName
        Write-Host -ForegroundColor Yellow "Get-AzOperationalInsightsTable Get returned with: $($table.Count) results"
        $table.Count | Should BeGreaterThan 0
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
