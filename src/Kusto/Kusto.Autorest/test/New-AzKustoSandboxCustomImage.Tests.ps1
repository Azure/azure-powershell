if(($null -eq $TestName) -or ($TestName -contains 'New-AzKustoSandboxCustomImage'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzKustoSandboxCustomImage.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzKustoSandboxCustomImage' {
    It 'CreateExpanded' {
        #Note Sandbox custom image is only supported on hyper threading clusters, currently the cluster that is used for following tests is using a hyper threading SKU
        $clusterName = $env.kustoFollowerClusterName
        $resourceGroupName = $env.resourceGroupName
        $subscriptionId = $env.subscriptionId
        $sandboxCustomImageName = "testimage"
        $languageVersion = "3.9.7"
        $requirementsFileContent = "Pillow"

        New-AzKustoSandboxCustomImage -ClusterName $clusterName -Name $sandboxCustomImageName -ResourceGroupName $resourceGroupName -SubscriptionId $subscriptionId -LanguageVersion $languageVersion -RequirementsFileContent $requirementsFileContent
        
        Remove-AzKustoSandboxCustomImage -ClusterName $clusterName -Name $sandboxCustomImageName -ResourceGroupName $resourceGroupName
    }

    It 'Create' {
        $clusterName = $env.kustoFollowerClusterName
        $resourceGroupName = $env.resourceGroupName
        $sandboxCustomImageName = "testimage"
        $sandboxCustomImageParameter = @{
            LanguageVersion = "3.9.7"
            RequirementsFileContent = "Pillow"
        }
        
        New-AzKustoSandboxCustomImage -ClusterName $clusterName -Name $sandboxCustomImageName -ResourceGroupName $resourceGroupName -Parameter $sandboxCustomImageParameter

        Remove-AzKustoSandboxCustomImage -ClusterName $clusterName -Name $sandboxCustomImageName -ResourceGroupName $resourceGroupName
    }
}
