if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzNapsterLatestOrganizationLinkedSaaS'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzNapsterLatestOrganizationLinkedSaaS.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzNapsterLatestOrganizationLinkedSaaS' {
    It 'Latest' {
        {
            try {
                Invoke-AzNapsterLatestOrganizationLinkedSaaS -Organizationname $env.ResourceName -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId
            }
            catch {
                if ($_.Exception.Message -match "HttpClient.Timeout") {
                    Write-Host "Received 'Timeout' response"
                }
                elseif ($_.Exception.Message -match "NotFound \(404\)" -or $_.Exception.Message -match "ResourceNotFound") {
                    Write-Host "Resource not found (404), which is expected if no SaaS is linked yet."
                }
                else {
                    throw $_
                }
            }
        } | Should -Not -Throw
    }
}
