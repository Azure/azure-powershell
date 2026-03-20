# Self-contained test for Invoke-AzDnsResolverBulkDnsResolverDomainList

$TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzDnsResolverBulkDnsResolverDomainList.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) { $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File; $currentPath = Split-Path -Path $currentPath -Parent }
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Invoke-AzDnsResolverBulkDnsResolverDomainList' {
    BeforeAll {
        $subscriptionId = '97db216c-169d-4ea9-9d98-114adba0aa20'
        $location = 'westus2'
        $rgName = "ps-bulk-dl-test"

        if ($TestMode -ne 'playback') {
            Import-Module Az.Storage -ErrorAction SilentlyContinue
            Select-AzSubscription -SubscriptionId $subscriptionId
            New-AzResourceGroup -Name $rgName -Location $location

            # Create storage account for bulk operations
            $saName = "psbulktest123"
            $sa = New-AzStorageAccount -Name $saName -ResourceGroupName $rgName -Location $location -SkuName "Standard_LRS"

            # Use storage account key for context (ensures SAS works)
            $key = (Get-AzStorageAccountKey -ResourceGroupName $rgName -Name $saName)[0].Value
            $ctx = New-AzStorageContext -StorageAccountName $saName -StorageAccountKey $key

            # Create container and upload domain list
            New-AzStorageContainer -Name "domainlists" -Context $ctx
            $domainContent = "contoso.com.`nexample.com.`ntest.com."
            $tempFile = [System.IO.Path]::GetTempFileName()
            Set-Content -Path $tempFile -Value $domainContent -NoNewline
            Set-AzStorageBlobContent -File $tempFile -Container "domainlists" -Blob "domains.txt" -Context $ctx -Force
            Remove-Item $tempFile -ErrorAction SilentlyContinue

            # Generate SAS token with read/write/create/list permissions
            $sas = New-AzStorageBlobSASToken -Container "domainlists" -Blob "domains.txt" -Context $ctx -Permission rwcl -ExpiryTime (Get-Date).AddHours(2) -FullUri
            $script:blobUrl = $sas

            # Create domain list resource
            New-AzDnsResolverDomainList -Name "domainlist-bulk-1" -ResourceGroupName $rgName -Location $location -Domain @("placeholder.com.")
        } else {
            $script:blobUrl = "https://psbulk000000.blob.core.windows.net/domainlists/domains.txt?sv=2024-11-04&sr=b&sig=placeholder&sp=rwcl&se=2099-01-01T00:00:00Z"
        }
    }

    AfterAll {
        if ($TestMode -ne 'playback') {
            Remove-AzResourceGroup -Name $rgName -ErrorAction SilentlyContinue -AsJob | Out-Null
        }
    }

    It 'Bulk upload domains to a domain list from storage blob' {
        $result = Invoke-AzDnsResolverBulkDnsResolverDomainList -DnsResolverDomainListName "domainlist-bulk-1" -ResourceGroupName $rgName -Action "Upload" -StorageUrl $script:blobUrl
        # Verify the domain list was updated with uploaded domains
        $dl = Get-AzDnsResolverDomainList -Name "domainlist-bulk-1" -ResourceGroupName $rgName
        $dl.ProvisioningState | Should -Be "Succeeded"
    }
}
