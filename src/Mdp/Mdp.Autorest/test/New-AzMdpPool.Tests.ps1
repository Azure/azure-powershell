if(($null -eq $TestName) -or ($TestName -contains 'New-AzMdpPool'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMdpPool.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzMdpPool' {
    It 'Create' {
        $pool = &New-AzMdpPool -Name $env.MdpPoolNameNew -Location $env.Location -ResourceGroupName $env.ResourceGroup `
                -DevCenterProjectResourceId "/subscriptions/$($env.SubscriptionId)/resourceGroups/example/providers/Microsoft.DevCenter/projects/contoso-proj" `
                -AgentProfile '{"kind": "stateless"}' `
                -MaximumConcurrency 1 `
                -OrganizationProfile '{"kind": "AzureDevOps","organizations": [{"url": "https://dev.azure.com/managed-org-demo","projects": null,"parallelism": 1}],"permissionProfile": {"kind": "CreatorOnly"}}' `
                -FabricProfile '{"kind": "Vmss", "sku": {"name": "Standard_DS12_v2"}, "storageProfile": { "osDiskStorageAccountType": "Standard","dataDisks": []},"images": [{"resourceId": "/Subscriptions/21af6cf1-77ad-42cd-ad19-e193de033071/Providers/Microsoft.Compute/Locations/eastus2/Publishers/canonical/ArtifactTypes/VMImage/Offers/0001-com-ubuntu-server-focal/Skus/20_04-lts-gen2/versions/latest","buffer": "*"}]}'
        $pool.Name | Should -Be $env.MdpPoolNameNew
        $pool.MaximumConcurrency | Should -Be 1
        $pool.ProvisioningState | Should -Be "Succeeded"
    }
}
