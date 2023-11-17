if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzAutomanageConfigProfile'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzAutomanageConfigProfile.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzAutomanageConfigProfile' {
    It 'Delete' {
        { 
            $confprof = @{
                "Antimalware/Enable"='false';
                "Backup/Enable"='false';
                "VMInsights/Enable"= 'true';
                "AzureSecurityCenter/Enable"='true';
                "UpdateManagement/Enable"='true';
                "ChangeTrackingAndInventory/Enable"='true';
                "GuestConfiguration/Enable"='true';
                "LogAnalytics/Enable"='true';
                "BootDiagnostics/Enable"='true'
            }
            New-AzAutomanageConfigProfile -ResourceGroupName automangerg -Name confpro-pwsh01 -Location eastus -Configuration $confprof
            Remove-AzAutomanageConfigProfile -ResourceGroupName automangerg -Name confpro-pwsh01
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        { 
            $confprof = @{
                "Antimalware/Enable"='false';
                "Backup/Enable"='false';
                "VMInsights/Enable"= 'true';
                "AzureSecurityCenter/Enable"='true';
                "UpdateManagement/Enable"='true';
                "ChangeTrackingAndInventory/Enable"='true';
                "GuestConfiguration/Enable"='true';
                "LogAnalytics/Enable"='true';
                "BootDiagnostics/Enable"='true'
            }
            $obj = New-AzAutomanageConfigProfile -ResourceGroupName automangerg -Name confpro-pwsh01 -Location eastus -Configuration $confprof
            Remove-AzAutomanageConfigProfile -InputObject $obj
        } | Should -Not -Throw
    }
}
