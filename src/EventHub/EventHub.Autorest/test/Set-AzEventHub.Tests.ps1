if(($null -eq $TestName) -or ($TestName -contains 'Set-AzEventHub'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzEventHub.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Set-AzEventHub' {
    It 'SetExpanded'  {
        $eventhub = Set-AzEventHub -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.eventHub2 -ArchiveNameFormat "{Namespace}/{EventHub}/{PartitionId}/{Year}/{Month}/{Day}/{Hour}/{Minute}/{Second}" -BlobContainer $env.blobContainer -CaptureEnabled -DestinationName EventHubArchive.AzureBlockBlob -Encoding Avro -IntervalInSeconds 600 -SizeLimitInBytes 11000000 -SkipEmptyArchive -StorageAccountResourceId $env.storageAccountId
        $eventhub.PartitionCount | Should -Be 5
        $eventhub.ArchiveNameFormat | Should -Be "{Namespace}/{EventHub}/{PartitionId}/{Year}/{Month}/{Day}/{Hour}/{Minute}/{Second}"
        $eventhub.BlobContainer | Should -Be $env.blobContainer
        $eventhub.CaptureEnabled | Should -Be $true
        $eventhub.SkipEmptyArchive | Should -Be $true
        $eventhub.DestinationName | Should -Be "EventHubArchive.AzureBlockBlob"
        $eventhub.Encoding | Should -Be "Avro"
        $eventhub.IntervalInSeconds | Should -Be 600
        $eventhub.SizeLimitInBytes | Should -Be 11000000
        $eventhub.StorageAccountResourceId | Should -Be $eventhub.StorageAccountResourceId

        $eventhub = Set-AzEventHub -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.eventHub3 -RetentionTimeInHour 90
        $eventhub.RetentionTimeInHour | Should -Be 90
        $eventhub.PartitionCount | Should -Be 4
        $eventhub.ArchiveNameFormat | Should -Be "{Namespace}/{EventHub}/{PartitionId}/{Year}/{Month}/{Day}/{Hour}/{Minute}/{Second}"
        $eventhub.BlobContainer | Should -Be $env.blobContainer
        $eventhub.CaptureEnabled | Should -Be $true
        $eventhub.SkipEmptyArchive | Should -Be $true
        $eventhub.DestinationName | Should -Be "EventHubArchive.AzureBlockBlob"
        $eventhub.Encoding | Should -Be "Avro"
        $eventhub.IntervalInSeconds | Should -Be 600
        $eventhub.SizeLimitInBytes | Should -Be 11000000
        $eventhub.StorageAccountResourceId | Should -Be $eventhub.StorageAccountResourceId

        # Create EventHub with MSI Capture Enabled
        $eventhub = New-AzEventHub -Name $env.eventHub5 -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespaceV1
        $eventhub = Set-AzEventHub -Name $env.eventHub5 -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespaceV1 -ArchiveNameFormat "{Namespace}/{EventHub}/{PartitionId}/{Year}/{Month}/{Day}/{Hour}/{Minute}/{Second}" -BlobContainer $env.blobContainer -CaptureEnabled -DestinationName EventHubArchive.AzureBlockBlob -Encoding Avro -IntervalInSeconds 600 -SizeLimitInBytes 11000000 -SkipEmptyArchive -StorageAccountResourceId $env.storageAccountId -IdentityType UserAssigned -UserAssignedIdentityId $env.msi2
        $eventhub.Name | Should -Be $env.eventHub5
        $eventhub.ResourceGroupName | Should -Be $env.resourceGroup
        $eventhub.PartitionCount | Should -Be 4
        $eventhub.ArchiveNameFormat | Should -Be "{Namespace}/{EventHub}/{PartitionId}/{Year}/{Month}/{Day}/{Hour}/{Minute}/{Second}"
        $eventhub.BlobContainer | Should -Be $env.blobContainer
        $eventhub.CaptureEnabled | Should -Be $true
        $eventhub.SkipEmptyArchive | Should -Be $true
        $eventhub.DestinationName | Should -Be "EventHubArchive.AzureBlockBlob"
        $eventhub.Encoding | Should -Be "Avro"
        $eventhub.IntervalInSeconds | Should -Be 600
        $eventhub.SizeLimitInBytes | Should -Be 11000000
        $eventhub.StorageAccountResourceId | Should -Be $eventhub.StorageAccountResourceId
        $eventhub.IdentityType | Should -Be $eventhub.IdentityType
        $eventhub.UserAssignedIdentityId | Should -be $eventhub.UserAssignedIdentityId
    }

    It 'SetViaIdentityExpanded'  {
        $eventhub = New-AzEventHub -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name eventhub

        { Set-AzEventHub -InputObject $eventhub -ErrorAction Stop } | Should -Throw 'Please specify the property you want to update on the -InputObject'

        $eventhub = Set-AzEventHub -InputObject $eventhub -ArchiveNameFormat "{Namespace}/{EventHub}/{PartitionId}/{Year}/{Month}/{Day}/{Hour}/{Minute}/{Second}" -BlobContainer $env.blobContainer -CaptureEnabled -DestinationName EventHubArchive.AzureBlockBlob -Encoding Avro -IntervalInSeconds 600 -SizeLimitInBytes 11000000 -SkipEmptyArchive -StorageAccountResourceId $env.storageAccountId
        $eventhub.PartitionCount | Should -Be 4
        $eventhub.ArchiveNameFormat | Should -Be "{Namespace}/{EventHub}/{PartitionId}/{Year}/{Month}/{Day}/{Hour}/{Minute}/{Second}"
        $eventhub.BlobContainer | Should -Be $env.blobContainer
        $eventhub.CaptureEnabled | Should -Be $true
        $eventhub.SkipEmptyArchive | Should -Be $true
        $eventhub.DestinationName | Should -Be "EventHubArchive.AzureBlockBlob"
        $eventhub.Encoding | Should -Be "Avro"
        $eventhub.IntervalInSeconds | Should -Be 600
        $eventhub.SizeLimitInBytes | Should -Be 11000000
        $eventhub.StorageAccountResourceId | Should -Be $eventhub.StorageAccountResourceId

        $eventhub = Set-AzEventHub -InputObject $eventhub.Id -CaptureEnabled:$false
        $eventhub.PartitionCount | Should -Be 4
        $eventhub.ArchiveNameFormat | Should -Be "{Namespace}/{EventHub}/{PartitionId}/{Year}/{Month}/{Day}/{Hour}/{Minute}/{Second}"
        $eventhub.BlobContainer | Should -Be $env.blobContainer
        $eventhub.CaptureEnabled | Should -Be $false
        $eventhub.SkipEmptyArchive | Should -Be $true
        $eventhub.DestinationName | Should -Be "EventHubArchive.AzureBlockBlob"
        $eventhub.Encoding | Should -Be "Avro"
        $eventhub.IntervalInSeconds | Should -Be 600
        $eventhub.SizeLimitInBytes | Should -Be 11000000
        $eventhub.StorageAccountResourceId | Should -Be $eventhub.StorageAccountResourceId

        $eventhub = Set-AzEventHub -InputObject $eventhub.Id -PartitionCount 8
        $eventhub.PartitionCount | Should -Be 8
        $eventhub.ArchiveNameFormat | Should -Be "{Namespace}/{EventHub}/{PartitionId}/{Year}/{Month}/{Day}/{Hour}/{Minute}/{Second}"
        $eventhub.BlobContainer | Should -Be $env.blobContainer
        $eventhub.CaptureEnabled | Should -Be $false
        $eventhub.SkipEmptyArchive | Should -Be $true
        $eventhub.DestinationName | Should -Be "EventHubArchive.AzureBlockBlob"
        $eventhub.Encoding | Should -Be "Avro"
        $eventhub.IntervalInSeconds | Should -Be 600
        $eventhub.SizeLimitInBytes | Should -Be 11000000
        $eventhub.StorageAccountResourceId | Should -Be $eventhub.StorageAccountResourceId
    }
}
