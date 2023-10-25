if(($null -eq $TestName) -or ($TestName -contains 'Get-AzKustoSandboxCustomImage'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzKustoSandboxCustomImage.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzKustoSandboxCustomImage' {
    It 'List' {
        $clusterName = $env.kustoFollowerClusterName
        $resourceGroupName = $env.resourceGroupName
        $subscriptionId = $env.subscriptionId
        $sandboxCustomImageName = "testimage"
        $languageVersion = "3.9.7"
        $requirementsFileContent = "Pillow"

        New-AzKustoSandboxCustomImage -ClusterName $clusterName -Name $sandboxCustomImageName -ResourceGroupName $resourceGroupName -SubscriptionId $subscriptionId -LanguageVersion $languageVersion -RequirementsFileContent $requirementsFileContent

        [array]$sandboxImages = Get-AzKustoSandboxCustomImage -ClusterName $clusterName -ResourceGroupName $resourceGroupName

        Remove-AzKustoSandboxCustomImage -ClusterName $clusterName -Name $sandboxCustomImageName -ResourceGroupName $resourceGroupName
        
        #TODO add validation
    }

    It 'Get' {
        $clusterName = $env.kustoFollowerClusterName
        $resourceGroupName = $env.resourceGroupName
        $subscriptionId = $env.subscriptionId
        $sandboxCustomImageName = "testimage"
        $languageVersion = "3.9.7"
        $requirementsFileContent = "Pillow"

        New-AzKustoSandboxCustomImage -ClusterName $clusterName -Name $sandboxCustomImageName -ResourceGroupName $resourceGroupName -SubscriptionId $subscriptionId -LanguageVersion $languageVersion -RequirementsFileContent $requirementsFileContent

        $sandboxImage = Get-AzKustoSandboxCustomImage -ClusterName $clusterName -Name $sandboxCustomImageName -ResourceGroupName $resourceGroupName
        
        Remove-AzKustoSandboxCustomImage -ClusterName $clusterName -Name $sandboxCustomImageName -ResourceGroupName $resourceGroupName

        #TODO add validation
    }

    It 'GetViaIdentity' {
        $clusterName = $env.kustoFollowerClusterName
        $resourceGroupName = $env.resourceGroupName
        $subscriptionId = $env.subscriptionId
        $sandboxCustomImageName = "testimage"
        $languageVersion = "3.9.7"
        $requirementsFileContent = "Pillow"

        New-AzKustoSandboxCustomImage -ClusterName $clusterName -Name $sandboxCustomImageName -ResourceGroupName $resourceGroupName -SubscriptionId $subscriptionId -LanguageVersion $languageVersion -RequirementsFileContent $requirementsFileContent

        $sandboxImage = Get-AzKustoSandboxCustomImage -ClusterName $clusterName -Name $sandboxCustomImageName -ResourceGroupName $resourceGroupName
        $sandboxImage = Get-AzKustoSandboxCustomImage -InputObject $sandboxImage

        Remove-AzKustoSandboxCustomImage -ClusterName $clusterName -Name $sandboxCustomImageName -ResourceGroupName $resourceGroupName

        #TODO add validation
    }
}
