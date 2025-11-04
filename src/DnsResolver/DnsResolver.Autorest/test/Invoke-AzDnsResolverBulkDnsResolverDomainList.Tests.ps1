if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzDnsResolverBulkDnsResolverDomainList'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzDnsResolverBulkDnsResolverDomainList.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzDnsResolverBulkDnsResolverDomainList' {
    It 'Uploads to the domain list (skipped due to requiring sas token credentials in command)' -skip {
        # ARRANGE
        $dnsResolverDomainListName = "psdnsresolverdomainlistbulkname0j0cdzg";
        $domainList = New-AzDnsResolverDomainList -Name $dnsResolverDomainListName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $location

        # ACT
        Invoke-AzDnsResolverBulkDnsResolverDomainList -ResourceGroupName $RESOURCE_GROUP_NAME -DnsResolverDomainListName $dnsResolverDomainListName -Action "Upload" -StorageUrl https://exampleStorageAccount.blob.core.windows.net/exampleContainerName/exampleFileName.txt?sp=r&st=2025-05-16T03:54:40Z&se=2025-05-16T11:54:40Z&spr=https&sv=2024-11-04&sr=b&sig={exampleSasToken}
    }

    It 'Downloads the domains to the storage url (skipped due to requiring sas token credentials in command)' -skip {
        # ARRANGE
        $dnsResolverDomainListName = "psdnsresolverdomainlistbulkname0j0bihd";
        $domainList = New-AzDnsResolverDomainList -Name $dnsResolverDomainListName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $location

        # ACT
        Invoke-AzDnsResolverBulkDnsResolverDomainList -ResourceGroupName $RESOURCE_GROUP_NAME -DnsResolverDomainListName $dnsResolverDomainListName -Action "Upload" -StorageUrl https://exampleStorageAccount.blob.core.windows.net/exampleContainerName/exampleFileName.txt?sp=r&st=2025-05-16T03:54:40Z&se=2025-05-16T11:54:40Z&spr=https&sv=2024-11-04&sr=b&sig={exampleSasToken}
    
        # UNDO
        Start-Sleep -Seconds 5
        Remove-AzDnsResolverDomainList -Name $dnsResolverDomainListName -ResourceGroupName $RESOURCE_GROUP_NAME
    }
}
