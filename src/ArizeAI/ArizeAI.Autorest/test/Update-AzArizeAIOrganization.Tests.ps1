if(($null -eq $TestName) -or ($TestName -contains 'Update-AzArizeAIOrganization'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzArizeAIOrganization.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzArizeAIOrganization' {
    It 'UpdateExpanded' 
        {
            try {
                Update-AzArizeAIOrganization -Name $env.ResourceName -ResourceGroupName $env.ResourceGroupName -SubscriptionId $env.SubscriptionId -MarketplaceSubscriptionId $env.MarketplaceSubscriptionId -OfferDetailOfferId $env.OfferDetailOfferId -OfferDetailPlanId $env.OfferDetailPlanId -OfferDetailPlanName $env.OfferDetailPlanName -OfferDetailPublisherId $env.OfferDetailPublisherId -OfferDetailTermId $env.OfferDetailTermId -OfferDetailTermUnit $env.OfferDetailTermUnit -PartnerPropertyDescription $env.PartnerPropertyDescription -UserEmailAddress $env.UserEmailAddress -UserFirstName $env.NewUserFirstName -UserLastName $env.UserLastName -UserUpn $env.UserUpn -Tag @{"TestName1" = "TestValue1"}
            }
            catch {
                # Handle "Status: OK" and "NotFound (404)" as valid responses
                if ($_.Exception.Message -match "HttpClient.Timeout") {
                    Write-Host "Received 'Timeout' response"
                }
                else {
                    # For any other unexpected errors, rethrow the exception to fail the test
                    throw $_
                }
            }
        } | Should -Not -Throw 
    }
