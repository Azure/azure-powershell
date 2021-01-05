function Test-GetAksVersion {

    $version = Get-AzAksVersion -Location westus

    Assert-AreEqual 8 $version.Count
    Assert-AreEqual 0 ($version | Where-Object { $_.OrchestratorType -ne 'Kubernetes'}).Count

    $chosenVersion = $version | Where-Object { $_.OrchestratorVersion -eq '1.15.12'}
    Assert-AreEqual '1.15.12'  $chosenVersion.OrchestratorVersion
    Assert-AreEqual 2 $chosenVersion.Upgrades.Count
    Assert-AreEqual '1.16.10' $chosenVersion.Upgrades[0].OrchestratorVersion
}
