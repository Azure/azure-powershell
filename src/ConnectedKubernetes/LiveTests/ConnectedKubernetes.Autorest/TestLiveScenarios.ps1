Invoke-LiveTestScenario -Name "Test ConnectedKubernetes" -Description "Test AzConnectedKubernetes" -Platform "Linux" -ScenarioScript `
{
    param ($rg)
    $rgName = $rg.ResourceGroupName
    $ckName = New-LiveTestResourceName
    wget https://get.helm.sh/helm-v3.6.3-linux-amd64.tar.gz -q
    tar -zxvf helm-v3.6.3-linux-amd64.tar.gz
    sudo cp linux-amd64/helm /usr/local/bin/
    helm version
    minikube start 2>&1 > minikube_output.txt
    $ckLocation = "westus"
    $actual = New-AzConnectedKubernetes -ClusterName $ckName -ResourceGroupName $rgName -Location $ckLocation
    Assert-AreEqual $ckName $actual.Name
    Assert-AreEqual $ckLocation $actual.Location

    $actual = Get-AzConnectedKubernetes -ResourceGroupName $rgName
    Assert-True { $actual.Count -ge 1 }

    $actual = Get-AzConnectedKubernetes -ResourceGroupName $rgName -ClusterName $ckName
    Assert-AreEqual $ckName $actual.Name

    $tag = @{'key'='1'}
    $null = Update-AzConnectedKubernetes -ClusterName $ckName -ResourceGroupName $rgName -Tag $tag
    $actual = Get-AzConnectedKubernetes -ResourceGroupName $rgName -ClusterName $ckName
    Assert-AreEqual $actual.Tag["key"] "1"

    Remove-AzConnectedKubernetes -ResourceGroupName $rgName -Name $ckName
    $GetServiceList = Get-AzConnectedKubernetes -ResourceGroupName $rgName
    Assert-False { $GetServiceList.Name -contains $rgName}
}
