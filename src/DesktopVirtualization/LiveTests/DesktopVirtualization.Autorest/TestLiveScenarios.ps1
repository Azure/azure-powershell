Invoke-LiveTestScenario -Name "Create a Windows virtual desktop" -Description "Test creating a Windows virtual desktop" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $location = "westus"
    $poolName = New-LiveTestResourceName
    $poolFriName = New-LiveTestRandomName -Option AllLetters
    $groupName = New-LiveTestResourceName
    $groupFriName = New-LiveTestRandomName -Option AllLetters
    $appName = New-LiveTestResourceName
    $appFriName = New-LiveTestRandomName -Option AllLetters

    $pool = New-AzWvdHostPool -ResourceGroupName $rgName -Name $poolName -Location $location -FriendlyName $poolFriName -HostPoolType 'Pooled' -LoadBalancerType 'DepthFirst' -PreferredAppGroupType 'RailApplications' -ExpirationTime (Get-Date).ToUniversalTime().AddDays(1) -MaxSessionLimit 5
    New-AzWvdApplicationGroup -ResourceGroupName $rgName -Name $groupName -Location $location -FriendlyName $groupFriName -HostPoolArmPath $pool.Id -ApplicationGroupType 'RemoteApp'
    New-AzWvdApplication -ResourceGroupName $rgName -Name $appName -GroupName $groupName -FriendlyName $appFriName -FilePath "C:\Windows\System32\mspaint.exe" -IconIndex 0 -IconPath "C:\Windows\System32\mspaint.exe" -CommandLineSetting Allow -ShowInPortal:$true

    $actual = Get-AzWvdApplication -Name $appName -ResourceGroupName $rgName -GroupName $groupName
    Assert-NotNull $actual
    Assert-AreEqual "$groupName/$appName" $actual.Name
    Assert-AreEqual $appFriName $actual.FriendlyName
    Assert-True { $actual.FilePath -like "*mspaint*" }
}

Invoke-LiveTestScenario -Name "Update a Windows virtual desktop" -Description "Test updating an existing Windows virtual desktop" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $location = "westus"
    $poolName = New-LiveTestResourceName
    $poolFriName = New-LiveTestRandomName -Option AllLetters
    $groupName = New-LiveTestResourceName
    $groupFriName = New-LiveTestRandomName -Option AllLetters
    $appName = New-LiveTestResourceName
    $appFriName = New-LiveTestRandomName -Option AllLetters
    $appFriNameNew = New-LiveTestRandomName -Option AllLetters -MaxLength 9

    $pool = New-AzWvdHostPool -ResourceGroupName $rgName -Name $poolName -Location $location -FriendlyName $poolFriName -HostPoolType 'Pooled' -LoadBalancerType 'DepthFirst' -PreferredAppGroupType 'RailApplications' -ExpirationTime (Get-Date).ToUniversalTime().AddDays(1) -MaxSessionLimit 5
    New-AzWvdApplicationGroup -ResourceGroupName $rgName -Name $groupName -Location $location -FriendlyName $groupFriName -HostPoolArmPath $pool.Id -ApplicationGroupType 'RemoteApp'
    New-AzWvdApplication -ResourceGroupName $rgName -Name $appName -GroupName $groupName -FriendlyName $appFriName -FilePath "C:\Windows\System32\mspaint.exe" -IconIndex 0 -IconPath "C:\Windows\System32\mspaint.exe" -CommandLineSetting Allow -ShowInPortal:$true

    $app = Get-AzWvdApplication -Name $appName -ResourceGroupName $rgName -GroupName $groupName
    $app | Update-AzWvdApplication -FilePath 'C:\Windows\System32\WindowsPowerShell\v1. 0\powershell.exe'

    Update-AzWvdApplication -Name $appName -ResourceGroupName $rgName -GroupName $groupName -FriendlyName $appFriNameNew

    $actual = Get-AzWvdApplication -Name $appName -ResourceGroupName $rgName -GroupName $groupName
    Assert-NotNull $actual
    Assert-AreEqual "$groupName/$appName" $actual.Name
    Assert-AreEqual $appFriNameNew $actual.FriendlyName
    Assert-True { $actual.FilePath -like "*powershell*" }
}

Invoke-LiveTestScenario -Name "Delete a Windows virtual desktop" -Description "Test deleting a Windows virtual desktop" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $location = "westus"
    $poolName = New-LiveTestResourceName
    $poolFriName = New-LiveTestRandomName -Option AllLetters
    $groupName = New-LiveTestResourceName
    $groupFriName = New-LiveTestRandomName -Option AllLetters
    $appName = New-LiveTestResourceName
    $appFriName = New-LiveTestRandomName -Option AllLetters

    $pool = New-AzWvdHostPool -ResourceGroupName $rgName -Name $poolName -Location $location -FriendlyName $poolFriName -HostPoolType 'Pooled' -LoadBalancerType 'DepthFirst' -PreferredAppGroupType 'RailApplications' -ExpirationTime (Get-Date).ToUniversalTime().AddDays(1) -MaxSessionLimit 5
    New-AzWvdApplicationGroup -ResourceGroupName $rgName -Name $groupName -Location $location -FriendlyName $groupFriName -HostPoolArmPath $pool.Id -ApplicationGroupType 'RemoteApp'
    New-AzWvdApplication -ResourceGroupName $rgName -Name $appName -GroupName $groupName -FriendlyName $appFriName -FilePath "C:\Windows\System32\mspaint.exe" -IconIndex 0 -IconPath "C:\Windows\System32\mspaint.exe" -CommandLineSetting Allow -ShowInPortal:$true
    Remove-AzWvdApplication -ResourceGroupName $rgName -Name $appName -GroupName $groupName

    $actual = Get-AzWvdApplication -Name $appName -ResourceGroupName $rgName -GroupName $groupName -ErrorAction SilentlyContinue
    Assert-Null $actual
}
