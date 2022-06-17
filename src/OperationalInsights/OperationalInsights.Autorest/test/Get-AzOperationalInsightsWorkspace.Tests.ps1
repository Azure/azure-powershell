if(($null -eq $TestName) -or ($TestName -contains 'Get-AzOperationalInsightsWorkspace'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzOperationalInsightsWorkspace.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzOperationalInsightsWorkspace' {

    BeforeAll { 
        $rgName = "dabenham-dev"
        $wsName = "dabenham-PSH2"
    }

    It 'List' {
        $workspaces = Get-AzOperationalInsightsWorkspace
        Write-Host -ForegroundColor Yellow "Get-AzOperationalInsightsWorkspace List rturned with: $($workspaces.Count) results"
        $workspaces.Count | Should BeGreaterThan 0
    }

    It 'Get' {
        $singleWorkspace = Get-AzOperationalInsightsWorkspace -ResourceGroupName $rgName -Name $wsName
        Write-Host -ForegroundColor Yellow "Get-AzOperationalInsightsWorkspace Get for rg:${rgName}, workspaces:${wsName} returned with: $($singleWorkspace.Count) results"
        $singleWorkspace.Count | Should BeGreaterThan 0
    }

    It 'List1' {
        $workspaces = Get-AzOperationalInsightsWorkspace -ResourceGroupName $rgName
        Write-Host -ForegroundColor Yellow "Get-AzOperationalInsightsWorkspace List1 for rg:${rgName} returned with: $($workspaces.Count) results"
        $workspaces.Count | Should BeGreaterThan 0
    }

    It 'GetViaIdentity' -skip {        
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
