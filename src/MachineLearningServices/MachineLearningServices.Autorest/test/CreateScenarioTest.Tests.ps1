if(($null -eq $TestName) -or ($TestName -contains 'CreateScenarioTest'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'CreateScenarioTest.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'CreateScenarioTest' {
    It 'CUScenarioWorkspace' {
        {
            New-AzMLWorkspace -ResourceGroupName $env.TestGroupName -Name $env.mainWorkspace -Location $env.region -KeyVaultId $env.KeyVaultID -StorageAccountId $env.StorageAccountID -ApplicationInsightId $env.InsightsID1 -IdentityType 'SystemAssigned' -Kind 'Default' -Tag @{'key1' = 'value1'}
            Update-AzMLWorkspace -ResourceGroupName $env.TestGroupName -Name $env.mainWorkspace -Tag @{'key2' = 'value2'}
        } | Should -Not -Throw
    }

    It 'CreateHubWorkspace' {
        {
            New-AzMLWorkspace -ResourceGroupName $env.TestGroupName -Name $env.hubWorkspace -Location $env.region -KeyVaultId $env.KeyVaultID -StorageAccountId $env.StorageAccountID -IdentityType 'SystemAssigned' -Kind 'Hub' -Tag @{'key3' = 'value3'}
        } | Should -Not -Throw
    }

    It 'CreateProjectWorkspace' {
        {
            $Hub = Get-AzMLWorkspace -ResourceGroupName $env.TestGroupName -Name $env.hubWorkspace
            New-AzMLWorkspace -ResourceGroupName $env.TestGroupName -Name $env.projWorkspace -Location $env.region  -IdentityType 'SystemAssigned' -Kind 'Project' -HubResourceId $Hub.Id
        } | Should -Not -Throw
    }

    It 'CreateDataContainer' {
        { 
            New-AzMLWorkspaceDataContainer -ResourceGroupName $env.TestGroupName -WorkspaceName $env.mainWorkspace -Name $env.datacontainer -DataType 'uri_file'
        } | Should -Not -Throw
    }

    It 'CreateDataStore' {
        { 
            $accountKey = New-AzMLWorkspaceDatastoreKeyCredentialObject -Key "xxxxxxxxxxxxxxxxxxxxxxxx"
            $datastoreBlob = New-AzMLWorkspaceDatastoreBlobObject -AccountName $env.ManualStorageAccount -ContainerName $env.storageContainer -Endpoint "core.windows.net" -Protocol "https" -ServiceDataAccessAuthIdentity 'None' -Credentials $accountKey
            New-AzMLWorkspaceDatastore -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeWorkspace -Name $env.datastoreName -Datastore $datastoreBlob
         } | Should -Not -Throw
    }

    It 'CreateDataVersion' {
        { 
            New-AzMLWorkspaceDataVersion -ResourceGroupName $env.TestGroupName -WorkspaceName $env.mainWorkspace -Name iris-data -Version 1 -DataType 'uri_file' -DataUri "https://azuremlexamples.blob.core.windows.net/datasets/iris.csv"
        } | Should -Not -Throw
    }

    It 'CreateComputerWorkspaceCodeVersion' {
        {
            $codeURL = "https://"+$env.ManualStorageAccount+".blob.core.windows.net/"+$env.storageContainer+"/"+$env.codestore
            New-AzMLWorkspaceCodeVersion -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeWorkspace -Name $env.codename -Version 1 -CodeUri $codeURL
        } | Should -Not -Throw
    }

    It 'CreateBatchCluster' {
        {
            $batchcluster = New-AzMLWorkspaceAmlComputeObject -OSType 'Linux' -VMSize "STANDARD_DS3_V2" -ScaleMaxNodeCount 1 -ScaleMinNodeCount 0 -RemoteLoginPortPublicAccess 'NotSpecified' -EnableNodePublicIP $true
            New-AzMLWorkspaceCompute -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeWorkspace -Name $env.batchClusterName -Location eastus -Compute $batchcluster
        } | Should -Not -Throw
    }

    It 'CreateComputeInstance' {
        {
            $computeinstance = New-AzMLWorkspaceComputeInstanceObject -VMSize "STANDARD_DS3_V2" -EnableNodePublicIP $true
            New-AzMLWorkspaceCompute -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeWorkspace -Name $env.computeinstance -Location eastus -Compute $computeinstance -IdentityType 'SystemAssigned'
        } | Should -Not -Throw
    }

    It 'CreateModelContainer' {
        {
            New-AzMLWorkspaceModelContainer -ResourceGroupName $env.TestGroupName -WorkspaceName $env.mainWorkspace -Name modelcontainerpwsh01 -Description "code container for test."
        } | Should -Not -Throw
    }
 
    It 'CreateModel' {
        {
            #format: ^(azureml://subscriptions/([^/?]+)/resourceGroups/([^/?]+)/workspaces/([^/?]+)/datastores/([^/?]+)/paths/(.+)|azureml://jobs/([^/]+)/outputs/([^/]+)(.*)|runs:/([^/?]+)/(.+)|azureml://datasets/([^/]+)|https://(?<account>.+?)\\.blob\\.core\\.(?<domain>.+?)\\/(?<path>.+?))$
            $modelURL = "azureml://subscriptions/"+$env.subscriptionId+"/resourceGroups/"+$env.DataGroupName+"/workspaces/"+$env.computeWorkspace+"/datastores/"+$env.codedatastoreName+"/paths/"+$env.codestore
            New-AzMLWorkspaceModelVersion -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeWorkspace -Name heart-classifier-batch -Version 1 -ModelType "mlflow_model" -ModelUri $modelURL
        } | Should -Not -Throw
    }
    
    It 'CreateWorkspaceBatchEndpoint' {
        {
            New-AzMLWorkspaceBatchEndpoint -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeWorkspace -Name $env.batchEndpoint -AuthMode 'AADToken' -Location $env.region
        } | Should -Not -Throw
    }
    It 'CreateWorkspaceBatchEndpointDeployment' {
        {
            $srciptFile = "batch_driver.py"
            $environment = New-AzMLWorkspaceEnvironmentVersion -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeWorkspace -Name batchenv1 -Version 1 -Image "mcr.microsoft.com/azureml/openmpi4.1.0-ubuntu20.04"
            $codeid = (Get-AzMLWorkspaceCodeVersion -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeWorkspace -Name $env.codename -Version 1).Id
            $vmid = (Get-AzMLWorkspaceCompute -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeWorkspace -Name $env.batchClusterName).Id
            $modelobject = New-AzMLWorkspaceIdAssetReferenceObject -AssetId (Get-AzMLWorkspaceModelVersion -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeWorkspace -Name heart-classifier-batch -Version 1).Id -ReferenceType 'Id'
            New-AzMLWorkspaceBatchDeployment -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeWorkspace -EndpointName $env.batchEndpoint -Name $env.batchDeployment -Location $env.region -CodeScoringScript $srciptFile -EnvironmentId $environment.Id -Compute $vmid -CodeId $codeid -Model $modelobject
        } | Should -Not -Throw
    }

    It 'CreateComputeCommandJob' {
        {
            $compute = Get-AzMLWorkspaceCompute -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeWorkspace -Name $env.computeinstance
            $environment = New-AzMLWorkspaceEnvironmentVersion -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeWorkspace -Name commandjobenv1 -Version 1 -Image "library/python:latest"
            $commandJob = New-AzMLWorkspaceCommandJobObject -Command 'echo "hello powershell 02"' -ComputeId $compute.Id -EnvironmentId $environment.Id -DisplayName 'commandJob02' -ExperimentName 'commandjobexperiment'
            New-AzMLWorkspaceJob -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeWorkspace -Name $env.commandJob02 -Job $commandJob
        } | Should -Not -Throw
    }

    It 'CreateMainCommandJob' {
        {
            $computeinstance = New-AzMLWorkspaceComputeInstanceObject -VMSize "STANDARD_DS3_V2" -EnableNodePublicIP $true
            $compute = New-AzMLWorkspaceCompute -ResourceGroupName $env.TestGroupName -WorkspaceName $env.mainWorkspace -Name commandjobcompute -Location eastus -Compute $computeinstance
            $environment = New-AzMLWorkspaceEnvironmentVersion -ResourceGroupName $env.TestGroupName -WorkspaceName $env.mainWorkspace -Name commandjobenv1 -Version 1 -Image "library/python:latest"
            $commandJob = New-AzMLWorkspaceCommandJobObject -Command 'echo "hello powershell 01"' -ComputeId $compute.Id -EnvironmentId $environment.Id -DisplayName 'commandJob01' -ExperimentName 'jobexperiment'
            New-AzMLWorkspaceJob -ResourceGroupName $env.TestGroupName -WorkspaceName $env.mainWorkspace -Name $env.commandJob01 -Job $commandJob
        } | Should -Not -Throw
    }

    It 'CreateComponentContainer' {
        {          
            New-AzMLWorkspaceComponentContainer -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeWorkspace -Name $env.componentName -IsArchived:$false
        }  | Should -Not -Throw
    }

    It 'CreateComponent' {
        {
            $codeid = (Get-AzMLWorkspaceCodeVersion -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeWorkspace -Name $env.codename -Version 1).Id
            $codestring = "azureml:$codeid"
            $environment = (Get-AzMLWorkspaceEnvironmentVersion -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeWorkspace -Name commandjobenv1 -Version 1).Id
            $environmentstring = "azureml:$environment"
            $componentHash = @{
            "name"= "train_data_component";
            "version"= "1";
            "display_name"= "train_data";
            "is_deterministic"= "True";
            "type"= "command";
            "code"= $codestring;
            "environment"= $environmentstring;
            "command"= "python train.py"
            }
            New-AzMLWorkspaceComponentVersion -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeWorkspace -Name $env.componentName -Version 1 -ComponentSpec $componentHash
        } | Should -Not -Throw
        
    }

    It 'CreateWorkspaceConnection' {
        { 
            New-AzMLWorkspaceConnection -ResourceGroupName $env.TestGroupName -WorkspaceName $env.mainWorkspace -Name 'test01' -AuthType 'None' -Category 'ContainerRegistry' -Target "www.facebook.com"
        } | Should -Not -Throw
    }
}
