Invoke-LiveTestScenario -Name "Create public DNS zone" -Description "Test creating a public DNS zone" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $r5l = New-LiveTestRandomName -Option AllLetters -MaxLength 5
    $zoneName = "$r5l.public.contoso.com"

    New-AzDnsZone -ResourceGroupName $rgName -Name $zoneName -ZoneType Public

    $actual = Get-AzDnsZone -ResourceGroupName $rgName -Name $zoneName
    Assert-NotNull $actual
    Assert-AreEqual $rgName $actual.ResourceGroupName
    Assert-AreEqual $zoneName $actual.Name
    Assert-AreEqual "Public" $actual.ZoneType
}

Invoke-LiveTestScenario -Name "Update DNS zone" -Description "Test updating an existing public DNS zone" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $r5l = New-LiveTestRandomName -Option AllLetters -MaxLength 5
    $zoneName = "$r5l.public.contoso.com"

    New-AzDnsZone -ResourceGroupName $rgName -Name $zoneName -ZoneType Public
    Set-AzDnsZone -ResourceGroupName $rgName -Name $zoneName -Tag @{ "Severity" = "Medium" }

    $actual = Get-AzDnsZone -ResourceGroupName $rgName -Name $zoneName
    Assert-NotNull $actual
    Assert-AreEqual $rgName $actual.ResourceGroupName
    Assert-AreEqual $zoneName $actual.Name
    Assert-AreEqual "Public" $actual.ZoneType
    Assert-AreEqual 1 $actual.Tags.Keys.Count
    Assert-AreEqual "Severity" $actual.Tags.Keys[0]
    Assert-AreEqual 1 $actual.Tags.Values.Count
    Assert-AreEqual "Medium" $actual.Tags.Values[0]

    $actual.Tags = @{ "Impact" = "Low" }
    Set-AzDnsZone -Zone $actual

    $actual = Get-AzDnsZone -ResourceGroupName $rgName -Name $zoneName
    Assert-NotNull $actual
    Assert-AreEqual $rgName $actual.ResourceGroupName
    Assert-AreEqual $zoneName $actual.Name
    Assert-AreEqual "Public" $actual.ZoneType
    Assert-AreEqual 1 $actual.Tags.Keys.Count
    Assert-AreEqual "Impact" $actual.Tags.Keys[0]
    Assert-AreEqual 1 $actual.Tags.Values.Count
    Assert-AreEqual "Low" $actual.Tags.Values[0]
}

Invoke-LiveTestScenario -Name "Remove DNS zone" -Description "Test removing a public DNS zone" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $r5l = New-LiveTestRandomName -Option AllLetters -MaxLength 5
    $zoneName = "$r5l.public.contoso.com"

    New-AzDnsZone -ResourceGroupName $rgName -Name $zoneName -ZoneType Public
    Remove-AzDnsZone -ResourceGroupName $rgName -Name $zoneName -Confirm:$false

    $actual = Get-AzDnsZone -ResourceGroupName $rgName -Name $zoneName -ErrorAction SilentlyContinue
    Assert-Null $actual
}
