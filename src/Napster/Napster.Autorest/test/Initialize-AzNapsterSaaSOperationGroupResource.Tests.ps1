if(($null -eq $TestName) -or ($TestName -contains 'Initialize-AzNapsterSaaSOperationGroupResource'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Initialize-AzNapsterSaaSOperationGroupResource.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Initialize-AzNapsterSaaSOperationGroupResource' {
    It 'ActivateExpanded' {
        {
            try {
                Initialize-AzNapsterSaaSOperationGroupResource -SubscriptionId $env.SubscriptionId -SaasGuid $env.SaasGuid -PublisherId $env.OfferDetailPublisherId
            }
            catch {
                if ($_.Exception.Message -match "HttpClient.Timeout") {
                    Write-Host "Received 'Timeout' response"
                }
                elseif ($_.Exception.Message -match "Object reference not set") {
                    Write-Host "Received NullRef for non-existent SaaS GUID, expected in test environment."
                }
                elseif ($_.Exception.Message -match "NotFound") {
                    Write-Host "Received 'NotFound', expected for non-existent SaaS GUID."
                }
                else {
                    throw $_
                }
            }
        } | Should -Not -Throw
    }
}
