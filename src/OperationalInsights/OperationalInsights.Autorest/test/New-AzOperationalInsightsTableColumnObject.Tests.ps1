if(($null -eq $TestName) -or ($TestName -contains 'New-AzOperationalInsightsTableColumnObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzOperationalInsightsTableColumnObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzOperationalInsightsTableColumnObject' {
    It '__AllParameterSets' { 
        $col1 = New-AzOperationalInsightsTableColumnObject -Name 'SourceSystem' -Description 'Type of agent the data was collected from. Possible values are OpsManager (Windows agent) or Linux.' -Type 'string'
        $col2 = New-AzOperationalInsightsTableColumnObject -Name 'TimeGenerated' -Description 'Date and time the record was created.' -Type 'datetime'
        Write-Host -ForegroundColor Yellow "New-AzOperationalInsightsTableColumnObject returned with: $($col1) and $($col2)"
    }
}
