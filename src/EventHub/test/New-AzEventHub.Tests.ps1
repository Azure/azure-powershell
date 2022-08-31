if(($null -eq $TestName) -or ($TestName -contains 'New-AzEventHub'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzEventHub.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzEventHub' {
    It 'CreateExpanded' -skip {
        # Create EventHub without capture
        $eventhub = New-AzEventHub -Name eventhub -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -MessageRetentionInDays 6 -PartitionCount 5
        $eventhub.Name | Should -Be "eventhub"
        $eventhub.ResourceGroupName | Should -Be $env.resourceGroup
        $eventhub.MessageRetentionInDays | Should -Be 6
        $eventhub.PartitionCount | Should -Be 5

        $env.Add("eventHub2", $eventhub.Name)

        # Create EventHub with capture enabled 
        $eventhub = New-AzEventHub -Name eventhubcapture -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -ArchiveNameFormat {Namespace}/{EventHub}/{PartitionId}/{Year}/{Month}/{Day}/{Hour}/{Minute}/{Second} -BlobContainer $env.blobContainer -CaptureEnabled -DestinationName EventHubArchive.AzureBlockBlob -Encoding Avro -IntervalInSeconds 600 -SizeLimitInBytes 11000000 -SkipEmptyArchive -StorageAccountResourceId $env.storageAccountId
        $eventhub.Name | Should -Be "eventhubcapture"
        $eventhub.ResourceGroupName | Should -Be $env.resourceGroup
        $eventhub.MessageRetentionInDays | Should -Be 1
        $eventhub.PartitionCount | Should -Be 1
        $eventhub.ArchiveNameFormat | Should -Be "{Namespace}/{EventHub}/{PartitionId}/{Year}/{Month}/{Day}/{Hour}/{Minute}/{Second}"
        $eventhub.BlobContainer | Should -Be $env.blobContainer
        $eventhub.CaptureEnabled | Should -Be $true
        $eventhub.SkipEmptyArchive | Should -Be $true
        $eventhub.DestinationName | Should -Be "EventHubArchive.AzureBlockBlob"
        $eventhub.Encoding | Should -Be "Avro"
        $eventhub.IntervalInSeconds | Should -Be 600
        $eventhub.SizeLimitInBytes | Should -Be 11000000
        $eventhub.StorageAccountResourceId | Should -Be $eventhub.StorageAccountResourceId

        $env.Add("eventHub3", $eventhub.Name)
    }
}
