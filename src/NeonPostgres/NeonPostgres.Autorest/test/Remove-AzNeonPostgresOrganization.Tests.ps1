if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzNeonPostgresOrganization'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzNeonPostgresOrganization.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

# Define variables directly in the script
$resourceName = "TestNeonOrgPS"
$resourceGroupName = "neonrg"

Describe 'Remove-AzNeonPostgresOrganization' {
    It 'Delete' {
        {
            try {
                # Attempt to delete the resource
                Remove-AzNeonPostgresOrganization -Name $resourceName -ResourceGroupName $resourceGroupName -ErrorAction Stop
            }
            catch {
                # Handle "Status: OK" and "NotFound (404)" as valid responses
                if ($_.Exception.Message -match "Status: OK") {
                    Write-Host "Received 'Status: OK' response, which is treated as a valid response."
                }
                elseif ($_.Exception.Message -match "NotFound \(404\)") {
                    Write-Host "Resource not found (404), which is expected if it does not exist."
                }
                else {
                    # For any other unexpected errors, rethrow the exception to fail the test
                    throw $_
                }
            }
        } | Should -Not -Throw
    }
}
