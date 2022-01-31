if(($null -eq $TestName) -or ($TestName -contains 'New-AzOperationalInsightsTable'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzOperationalInsightsTable.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzOperationalInsightsTable' {
    BeforeAll { 
        $rgName = "dabenham-dev"
        $wsName = "dabenham-PSH2"
        $tableName = "danielKukuTest_CL"
    }
    It 'CreateExpanded' {
        $col1 = New-AzOperationalInsightsTableColumnObject -Name 'SourceSystem' -Description 'Type of agent the data was collected from. Possible values are OpsManager (Windows agent) or Linux.' -Type 'string'
        $col2 = New-AzOperationalInsightsTableColumnObject -Name 'TimeGenerated' -Description 'Date and time the record was created.' -Type 'datetime'
        $schemaColumns = ($col1, $col2)

        $table = New-AzOperationalInsightsTable -ResourceGroupName $rgName -WorkspaceName $wsName -Name $tableName -RetentionInDay 33 -TotalRetentionInDay 55 -SchemaName $tableName -SchemaColumn $schemaColumns
        $table.RetentionInDay | Should Be 33
        $table.TotalRetentionInDay | Should Be 55
    }
}
