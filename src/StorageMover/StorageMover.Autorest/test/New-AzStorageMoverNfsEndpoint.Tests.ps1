if(($null -eq $TestName) -or ($TestName -contains 'New-AzStorageMoverNfsEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStorageMoverNfsEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzStorageMoverNfsEndpoint' {
    It 'CreateExpanded' {
        $endpointName = "testNfsEndpoint" + $env.RandomString
        $description = "Nfs endpoint description"
        $nfsVersion = "NFSv3"
        $endpointHost = "10.0.0.1"
        $export = "/"
        $nfsEndpoint = New-AzStorageMoverNfsEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -Host $endpointHost -Export $export -NfsVersion $nfsVersion -Description $description 
        $nfsEndpoint.Name | Should -Be $endpointName
        $nfsEndpoint.Property.endpointType | Should -Be "NfsMount"
        $nfsEndpoint.Property.host | Should -Be $endpointHost 
        $nfsEndpoint.Property.export | Should -Be $export

        $nfsEndpoint = Get-AzStorageMoverEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName
        $nfsEndpoint.Name | Should -Be $endpointName
        $nfsEndpoint.Property.endpointType | Should -Be "NfsMount"
        $nfsEndpoint.Property.host | Should -Be $endpointHost 
        $nfsEndpoint.Property.export | Should -Be $export
    }

    It 'CreateExpandedFsxEfs' {
        $endpointName = "nfsfsx"
        $nfsEndpoint = New-AzStorageMoverNfsEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.EndpointStoMoverName -Host "10.0.0.5" -Export "/export" -SourceType FSX-EFS -EndpointKind Source
        $nfsEndpoint.Property.endpointType | Should -Be "NfsMount"
        $nfsEndpoint.Property.EndpointKind | Should -Be "Source"

        $nfsEndpoint = Get-AzStorageMoverEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.EndpointStoMoverName
        $nfsEndpoint.Property.ProvisioningState | Should -Be "Succeeded"
    }

}

Describe 'New-AzStorageMoverNfsEndpoint RequestContract' -Tag @('PythonParity', 'Offline') {
    It 'CreateExpandedSourceTypeRequest' {
        $capture = Invoke-StorageMoverTestRequest -Response @{ properties = @{ endpointType = 'NfsMount' } } -Command {
            param($pipeline)
            New-AzStorageMoverNfsEndpoint -Name 'nfsfsxo' -SubscriptionId $env.SubscriptionId -ResourceGroupName 'rg' -StorageMoverName 'mover' -Host '10.0.0.5' -Export '/export' -NfsVersion NFSv4_1 -SourceType FSX-EFS -HttpPipelinePrepend $pipeline
        }
        $capture.Requests[0].Method | Should -Be 'PUT'
        $request = ($capture.Requests[0].Content | ConvertFrom-Json).properties
        $request.nfsVersion | Should -Be "NFSv4_1"
        $request.sourceType | Should -Be "FSX-EFS"
        $request.PSObject.Properties.Name | Should -Not -Contain "endpointKind"
    }
}

Describe 'New-AzStorageMoverNfsEndpoint PythonParity' -Tag 'PythonParity' {
    It 'RejectTargetEndpointKind' {
        $context = $null
        try {
            $context = New-StorageMoverTestContext -Name 'sm-nfs-target-validation'
            Invoke-StorageMoverTestFailure -Command {
                New-AzStorageMoverNfsEndpoint @context -Name 'invalid' -Host '10.0.0.1' -Export '/' -EndpointKind Target -ErrorAction Stop
            }
        } finally {
            Remove-StorageMoverTestContext -Context $context
        }
    }
}