if(($null -eq $TestName) -or ($TestName -contains 'New-AzMarketplacePrivateStoreCollectionOfferMultiContext'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMarketplacePrivateStoreCollectionOfferMultiContext.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

$private1 = @{
    context = "1f58b5dd-313c-42ed-84fc-f1e351bba7fb"
    planId = "plan1"
}
$private2 = @{
    context = "ab3de7bc-7a6e-4e9f-a34a-f6922df453e4"
    planId = "plan2"
}
$private3 = @{
    context = "a260d38c-96cf-492d-a340-404d0c4b3ad6"
    planId = "plan3"
}
$private = @($private1, $private2, $private3)

$public1 = @{
    context = "a260d38c-96cf-492d-a340-404d0c4b3ad6"
    planId = "pro-100k","pro-300k"
}
$public = @($public1)

Describe 'New-AzMarketplacePrivateStoreCollectionOfferMultiContext' {
    It 'OfferExpanded' {
	    $res = New-AzMarketplacePrivateStoreCollectionOfferMultiContext -CollectionId fdb889a1-cf3e-49f0-95b8-2bb012fa01f1 -PrivateStoreId a260d38c-96cf-492d-a340-404d0c4b3ad6  -OfferId test_test_pmc2pc1.vm_4plans_privatestoretesting -PlansContext $private
        $res | Should -Not -Be $null
        $res.name | Should -Be 'test_test_pmc2pc1.vm_4plans_privatestoretesting'
        $res.specificPlanIdsLimitation.Count | Should -Be 3

        $res = New-AzMarketplacePrivateStoreCollectionOfferMultiContext -CollectionId fdb889a1-cf3e-49f0-95b8-2bb012fa01f1 -PrivateStoreId a260d38c-96cf-492d-a340-404d0c4b3ad6  -OfferId sendgrid.tsg-saas-offer -PlansContext $public
        $res | Should -Not -Be $null
        $res.name | Should -Be 'sendgrid.tsg-saas-offer'
        $res.specificPlanIdsLimitation.Count | Should -Be 2
    }
}
