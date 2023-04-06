Invoke-LiveTestScenario -Name "Test ConnectedKubernetes" -Description "Test New-AzConnectedKubernetes" -Platform "Windows" -ScenarioScript `
{
    param ($rg)
    $rgName = $rg.ResourceGroupName
    $ckName = New-LiveTestResourceName
    kind create cluster --name $ckName
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
