if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzOperationalInsightsTable'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzOperationalInsightsTable.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzOperationalInsightsTable' {
           
    BeforeAll { 
        $rgName = "dabenham-dev"
        $wsName = "dabenham-PSH2"
        $tableName = "danielKukuTest2_CL"

        # Create a test table
        $col1 = New-AzOperationalInsightsTableColumnObject -Name 'SourceSystem' -Description 'Type of agent the data was collected from. Possible values are OpsManager (Windows agent) or Linux.' -Type 'string'
        $col2 = New-AzOperationalInsightsTableColumnObject -Name 'TimeGenerated' -Description 'Date and time the record was created.' -Type 'datetime'
        $schemaColumns = ($col1, $col2)

        Write-Host -ForegroundColor Yellow "Creating a test table: $($tableName), to test delete flow:"
        $table = New-AzOperationalInsightsTable -ResourceGroupName $rgName -WorkspaceName $wsName -Name $tableName -RetentionInDay 33 -TotalRetentionInDay 55 -SchemaName $tableName -SchemaColumn $schemaColumns
        Write-Host -ForegroundColor Yellow "Test table: $($tableName), was created"
    }

    It 'Delete' {
        Write-Host -ForegroundColor Yellow "Deleting a test table: $($tableName)"
        Remove-AzOperationalInsightsTable -ResourceGroupName $rgName -Name $tableName -WorkspaceName $wsName
        Write-Host -ForegroundColor Yellow "Finished deleting a test table: $($tableName)"
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
