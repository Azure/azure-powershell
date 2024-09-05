if(($null -eq $TestName) -or ($TestName -contains 'CreateScenarioTestOnlineEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'CreateScenarioTestOnlineEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'CreateScenarioTestOnlineEndpoint' {
    It 'CreateWorkspaceOnlineEndpoint' {
        {
            New-AzMLWorkspaceOnlineEndpoint -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeWorkspace -Name $env.onlineEndpoint -Location eastus -AuthMode 'AADToken' -IdentityType 'SystemAssigned'
        } | Should -Not -Throw
    }

    It 'CreateOnlineWorkspaceCodeVersion' {
        {
            $codeURL = "https://"+$env.ManualStorageAccount+".blob.core.windows.net/"+$env.onlinestorageContainer+"/"+$env.OnlineStore
            New-AzMLWorkspaceCodeVersion -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeWorkspace -Name $env.scorecodename -Version 1 -CodeUri $codeURL
        } | Should -Not -Throw
    }
 
    It 'CreateModel' {
        {
            #format: ^(azureml://subscriptions/([^/?]+)/resourceGroups/([^/?]+)/workspaces/([^/?]+)/datastores/([^/?]+)/paths/(.+)|azureml://jobs/([^/]+)/outputs/([^/]+)(.*)|runs:/([^/?]+)/(.+)|azureml://datasets/([^/]+)|https://(?<account>.+?)\\.blob\\.core\\.(?<domain>.+?)\\/(?<path>.+?))$
            $modelURL = "azureml://subscriptions/"+$env.subscriptionId+"/resourceGroups/"+$env.DataGroupName+"/workspaces/"+$env.computeWorkspace+"/datastores/"+$env.codedatastoreName+"/paths/"+$env.OnlineStore
            New-AzMLWorkspaceModelVersion -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeWorkspace -Name work-online-model -Version 1 -ModelType "mlflow_model" -ModelUri $modelURL
        } | Should -Not -Throw
    }

    # It 'CreateCondaEnvironment' {
    #     {
    #         $condastring = "channels:\\r\\n- conda-forge\\r\\ndependencies:\\r\\n- python=3.8.5\\r\\n- numpy\\r\\n- joblib\\r\\n- pip\\r\\n- pip:\\r\\n - mlflow\\r\\n - cloudpickle==1.6.0\\r\\n - scikit-learn==1.1.2\\r\\n - xgboost==1.3.3\\r\\n - azureml-inference-server-http\\r\\nname: mlflow-env\"
    #         New-AzMLWorkspaceEnvironmentVersion -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeWorkspace -Name "openmpi4_1_0-ubuntu22_04" -Version 1 -Image "mcr.microsoft.com/azureml/openmpi4.1.0-ubuntu22.04:latest" -CondaFile $condastring
    #     } | Should -Not -Throw
    # }

    It 'CreateWorkspaceOnlineEndpointDeployment' {
        {
            $codeidOnline = (Get-AzMLWorkspaceCodeVersion -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeWorkspace -Name $env.scorecodename -Version 1).Id
            $envOnline = Get-AzMLWorkspaceEnvironmentVersion -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeWorkspace -Name "openmpi4_1_0-ubuntu22_04" -Version 1
            $modelOnline = Get-AzMLWorkspaceModelVersion -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeWorkspace -Name work-online-model -Version 1
            
            New-AzMLWorkspaceOnlineDeployment -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeWorkspace -EndpointName $env.onlineEndpoint -Name $env.onlineDeployment -Location $env.region -EndpointComputeType 'Managed' -CodeId $codeidOnline -CodeScoringScript "score.py" -EnvironmentId $envOnline.Id -Model $modelOnline.Id -InstanceType "Standard_F4s_v2" -SkuName "Default" -SkuCapacity 3
        } | Should -Not -Throw
    }

    It 'UpdateWorkspaceOnlineEndpoint' {
        { 
            Update-AzMLWorkspaceOnlineEndpoint -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeWorkspace -Name $env.onlineEndpoint -Tag @{'key'='value'}
        } | Should -Not -Throw
    }
}
