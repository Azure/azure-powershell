function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}
function Start-TestSleep {
    [CmdletBinding(DefaultParameterSetName = 'SleepBySeconds')]
    param(
        [parameter(Mandatory = $true, Position = 0, ParameterSetName = 'SleepBySeconds')]
        [ValidateRange(0.0, 2147483.0)]
        [double] $Seconds,

        [parameter(Mandatory = $true, ParameterSetName = 'SleepByMilliseconds')]
        [ValidateRange('NonNegative')]
        [Alias('ms')]
        [int] $Milliseconds
    )

    if ($TestMode -ne 'playback') {
        switch ($PSCmdlet.ParameterSetName) {
            'SleepBySeconds' {
                Start-Sleep -Seconds $Seconds
            }
            'SleepByMilliseconds' {
                Start-Sleep -Milliseconds $Milliseconds
            }
        }
    }
}

$env = @{}
if ($UsePreviousConfigForRecord) {
    $previousEnv = Get-Content (Join-Path $PSScriptRoot 'env.json') | ConvertFrom-Json
    $previousEnv.psobject.properties | Foreach-Object { $env[$_.Name] = $_.Value }
}
# Add script method called AddWithCache to $env, when useCache is set true, it will try to get the value from the $env first.
# example: $val = $env.AddWithCache('key', $val, $true)
$env | Add-Member -Type ScriptMethod -Value { param( [string]$key, [object]$val, [bool]$useCache) if ($this.Contains($key) -and $useCache) { return $this[$key] } else { $this[$key] = $val; return $val } } -Name 'AddWithCache'
function setupEnv() {
    Write-Host "Utils.ps1: setupEnv()"
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id

    Write-Host "SubscriptionId $($env.SubscriptionId)"
    # For any resources you created for test, you should add it to $env here.

    # Install Az.Resources, Az.KeyVault and Az.CustomLocation modules in case they are not installed.

    # Fetch Secrets from KeyVault
    Write-Host "Fetch Secrets from KeyVault"

    $applianceId = (Get-AzKeyVaultSecret -VaultName "AzPwshCliTestVault" -Name "ApplianceId0809" -AsPlainText)
    $clusterExtensionId = (Get-AzKeyVaultSecret -VaultName "AzPwshCliTestVault" -Name "clusterExtensionId-0809" -AsPlainText)
    $vmmServerFqdn = (Get-AzKeyVaultSecret -VaultName "AzPwshCliTestVault" -Name "vmmServerFqdn0809" -AsPlainText)
    $vmmServerUsername = (Get-AzKeyVaultSecret -VaultName "AzPwshCliTestVault" -Name "vmmServerUsername" -AsPlainText)
    $vmmServerPassword = (Get-AzKeyVaultSecret -VaultName "AzPwshCliTestVault" -Name "vmmServerPassword" -AsPlainText)
    $guestUsername = (Get-AzKeyVaultSecret -VaultName "AzPwshCliTestVault" -Name "guestUsername" -AsPlainText)
    $guestPassword = (Get-AzKeyVaultSecret -VaultName "AzPwshCliTestVault" -Name "guestPassword" -AsPlainText)
    $cloudUuid = (Get-AzKeyVaultSecret -VaultName "AzPwshCliTestVault" -Name "cloudUuid" -AsPlainText)
    $vmTemplateUuid = (Get-AzKeyVaultSecret -VaultName "AzPwshCliTestVault" -Name "vmTemplateUuid" -AsPlainText)
    $vmNetworkUuid = (Get-AzKeyVaultSecret -VaultName "AzPwshCliTestVault" -Name "vmNetworkUuid" -AsPlainText)
    $vmNetwork2Uuid = (Get-AzKeyVaultSecret -VaultName "AzPwshCliTestVault" -Name "vmNetworkLn562Uuid" -AsPlainText)
    
    write-Host "applianceId: $applianceId"
    write-Host "clusterExtensionId: $clusterExtensionId"
    write-Host "vmmServerFqdn: $vmmServerFqdn"
    write-Host "vmmServerUsername: $vmmServerUsername"
    write-Host "vmmServerPassword: $vmmServerPassword"
    write-Host "guestUsername: $guestUsername"
    write-Host "guestPassword: $guestPassword"
    write-Host "cloudUuid: $cloudUuid"
    write-Host "vmTemplateUuid: $vmTemplateUuid"
    write-Host "vmNetworkUuid: $vmNetworkUuid"
    write-Host "vmNetwork2Uuid: $vmNetwork2Uuid"
    
    # Initialize env variables for VMM operations
    Write-Host "Initialize env variables for VMM operations"

    $env.Add("location", "eastus2euap")
    $env.Add("VmmServerName", "az-pwsh-test-vmm")
    $env.Add("FQDN", $vmmServerFqdn)
    $env.Add("Port", 8100)
    $env.Add("ServerUsername", $vmmServerUsername)
    $env.Add("ServerPassword", $vmmServerPassword)
    $env.Add("CloudName", "az-pwsh-test-cloud")
    $env.Add("CloudUuid", $cloudUuid)
    $env.Add("VmTemplateName", "az-pwsh-test-vm-template")
    $env.Add("VmTemplateUuid", $vmTemplateUuid)
    $env.Add("VirtualNetworkName", "az-pwsh-test-vnet")
    $env.Add("VirtualNetworkUuid", $vmNetworkUuid)
    $env.Add("VirtualNetwork2Name", "Ln562")
    $env.Add("VirtualNetwork2Uuid", $vmNetwork2Uuid)
    $env.Add("AvailabilitySetName", "az-pwsh-test-avset")
    $env.Add("VmName", "az-pwsh-test-vm")
    $env.Add("VmNameVmTest", "az-pwsh-test-vm-1")
    $env.Add("DiskName", "disk_1")
    $env.Add("NicName", "nic_1")
    $env.Add("CheckpointName", "az-pwsh-test-checkpoint")
    $env.Add("CheckpointDescription", "az-pwsh-test-checkpoint-description")
    $env.Add("GuestUsername", $guestUsername)
    $env.Add("GuestPassword", $guestPassword)
    $env.Add("ExtensionName", "RunCommand")
    $env.Add("ExtensionType", "CustomScriptExtension")
    $env.Add("Publisher", "Microsoft.Compute")
    $env.Add("CommandWhoami", '{"commandToExecute": "whoami"}')
    $env.Add("CommandSysroot", '{"commandToExecute": "echo %SYSTEMROOT%"}')
    
    # Create ResourceGroups
    Write-Host "Create ResourceGroups"

    $env.Add("ResourceGroupVmTest", "az-pwsh-test-rg-01")
    $env.Add("ResourceGroupEnableInvTest", "az-pwsh-test-rg-02")
    $env.Add("ResourceGroupVmmTest", "az-pwsh-test-rg-03")

    New-AzResourceGroup -Name $env.ResourceGroupVmTest -Location $env.location
    New-AzResourceGroup -Name $env.ResourceGroupEnableInvTest -Location $env.location
    New-AzResourceGroup -Name $env.ResourceGroupVmmTest -Location $env.location

    # Deploy CustomLocation in ResourceGroupVmTest, ResourceGroupEnableInvTest and ResourceGroupVmmTest ResourceGroups
    Write-Host "Deploy CustomLocation in ResourceGroups"

    $customLocation1 = "az-pwsh-test-cl-01"
    $customLocation2 = "az-pwsh-test-cl-02"
    $customLocation3 = "az-pwsh-test-cl-03"

    $env.Add("customLocation1", $customLocation1)
    $env.Add("customLocation2", $customLocation2)
    $env.Add("customLocation3", $customLocation3)

    $CustomLocationVmTest = (New-AzCustomLocation -Name $customLocation1 -ResourceGroupName $env.ResourceGroupVmTest -ClusterExtensionId $clusterExtensionId -HostResourceId $applianceId -Location $env.location -Namespace $customLocation1).Id  
    Write-Host "CustomLocationVmTest: $CustomLocationVmTest"
    $CustomLocationEnableInvTest = (New-AzCustomLocation -Name $customLocation2 -ResourceGroupName $env.ResourceGroupEnableInvTest -ClusterExtensionId $clusterExtensionId -HostResourceId $applianceId -Location $env.location -Namespace $customLocation2).Id
    Write-Host "CustomLocationEnableInvTest: $CustomLocationEnableInvTest"
    $CustomLocationVmmTest = (New-AzCustomLocation -Name $customLocation3 -ResourceGroupName $env.ResourceGroupVmmTest -ClusterExtensionId $clusterExtensionId -HostResourceId $applianceId -Location $env.location -Namespace $customLocation3).Id
    Write-Host "CustomLocationVmmTest: $CustomLocationVmmTest"

    $env.Add("ExtendedLocationType", "customLocation")
    $env.Add("CustomLocationVmTest", $CustomLocationVmTest)
    $env.Add("CustomLocationEnableInvTest", $CustomLocationEnableInvTest)
    $env.Add("CustomLocationVmmTest", $CustomLocationVmmTest)

    # Onboard VMMServer for VM Test and EnableInventory Test
    Write-Host "Onboard VMMServer for VMTest and EnableInvTest"

    $securePassword = ConvertTo-SecureString -String $env.ServerPassword -AsPlainText -Force            
    $vmmServerVmTest = (New-AzScVmmServer -Name $env.VmmServerName -ResourceGroupName $env.ResourceGroupVmTest -Location $env.location -CustomLocationId $env.CustomLocationVmTest -FQDN $env.FQDN -Port $env.Port -Username $env.ServerUsername -Password $securePassword).Id
    Write-Host "VmmServerVmTest: $vmmServerVmTest"
    $vmmServerEnableInvTest = (New-AzScVmmServer -Name $env.VmmServerName -ResourceGroupName $env.ResourceGroupEnableInvTest -Location $env.location -CustomLocationId $env.CustomLocationEnableInvTest -FQDN $env.FQDN -Port $env.Port -Username $env.ServerUsername -Password $securePassword).Id
    Write-Host "VmmServerEnableInvTest: $vmmServerEnableInvTest"

    $env.Add("VmmServerVmTestId", $vmmServerVmTest)
    $env.Add("VmmServerEnableInvTestId", $vmmServerEnableInvTest)

    # AvailabilitySet for VM Test
    Write-Host "AvailabilitySet for VM Test"

    $avsetIdVmTest = (New-AzScVmmAvailabilitySet -Name $env.AvailabilitySetName -AvailabilitySetName $env.AvailabilitySetName -ResourceGroupName $env.ResourceGroupVmTest -VmmServerName $env.VmmServerName -Location $env.location).Id
    Write-Host "AvailabilitySetIdVmTest: $avsetIdVmTest"
    $env.Add("AvailabilitySetIdVmTest", $avsetIdVmTest)
    
    # VMNetwork for VM Test
    Write-Host "VMNetwork for VM Test"

    $vmNetworkIdVmTest = (New-AzScVmmVirtualNetwork -Name $env.VirtualNetworkName -ResourceGroupName $env.ResourceGroupVmTest -VmmServerName $env.VmmServerName -InventoryUuid $env.VirtualNetworkUuid -Location $env.location).Id
    Write-Host "vmNetworkIdVmTest: $vmNetworkIdVmTest"
    $vmTemplateIdVmTest = (New-AzScVmmVMTemplate -Name $env.VmTemplateName -ResourceGroupName $env.ResourceGroupVmTest -VmmServerName $env.VmmServerName -InventoryUuid $env.VmTemplateUuid -Location $env.location).Id
    Write-Host "vmTemplateIdVmTest: $vmTemplateIdVmTest"
    $cloudIdVmTest = (New-AzScVmmCloud -Name $env.CloudName -ResourceGroupName $env.ResourceGroupVmTest -VmmServerName $env.VmmServerName -InventoryUuid $env.CloudUuid -Location $env.location).Id
    Write-Host "cloudIdVmTest: $cloudIdVmTest"

    $env.Add("vmNetworkIdVmTest", $vmNetworkIdVmTest)
    $env.Add("vmTemplateIdVmTest", $vmTemplateIdVmTest)
    $env.Add("cloudIdVmTest", $cloudIdVmTest)

    # Additional VMNetwork for VM Test
    Write-Host "Additional VMNetwork for VM Test"

    $vmNetwork2IdVmTest = (New-AzScVmmVirtualNetwork -Name $env.VirtualNetwork2Name -ResourceGroupName $env.ResourceGroupVmTest -VmmServerName $env.VmmServerName -InventoryUuid $env.VirtualNetwork2Uuid -Location $env.location).Id
    Write-Host "vmNetwork2IdVmTest: $vmNetwork2IdVmTest"
    $env.Add("vmNetwork2IdVmTest", $vmNetwork2IdVmTest)

    $guestSecurePassword = ConvertTo-SecureString -String $env.GuestPassword -AsPlainText -Force
    $vmNameObj = New-AzScVmmVM -Name $env.VmName -ResourceGroupName $env.ResourceGroupVmTest -VmmServerName $env.VmmServerName -CloudName $env.CloudName -TemplateName $env.VmTemplateName -CpuCount 4 -MemoryMb 4096 -AdminPassword $guestSecurePassword -Generation 2 -Location $env.location       
    $vmNameObj = Get-AzScVmmVM -Name $env.VmName -ResourceGroupName $env.ResourceGroupVmTest
    $vmNameInvId = $vmNameObj.InfrastructureProfileInventoryItemId
    $vmNameUuid = $vmNameObj.InfrastructureProfileUuid
    if ($vmNameUuid -eq "") {
        Start-TestSleep -Seconds 30
        $vmObj = Get-AzScVmmVM -Name $env.VmName -ResourceGroupName $env.ResourceGroupVmTest
        $vmNameUuid = $vmObj.InfrastructureProfileUuid
    }
    if ($vmNameInvId -eq "") {
        Start-TestSleep -Seconds 30
        $vmObj = Get-AzScVmmVM -Name $env.VmName -ResourceGroupName $env.ResourceGroupVmTest
        $vmNameInvId = $vmObj.InfrastructureProfileInventoryItemId
    }
    
    if ([string]::IsNullOrEmpty($vmNameInvId)) { throw "vmNameInvId is empty" }
    if ([string]::IsNullOrEmpty($vmNameUuid)) { throw "vmNameUuid is empty" }

    Write-Host "vmNameInvId: $vmNameInvId"
    $env.Add("vmNameInvId", $vmNameInvId)
    Write-Host "vmNameUuid: $vmNameUuid"
    $env.Add("vmNameUuid", $vmNameUuid)

    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)

    Write-Host "Utils.ps1: setupEnv() completed"
}
function cleanupEnv() {
    Write-Host "Utils.ps1: cleanupEnv()"
    # Clean up all resources created for test
    Remove-AzScVmmVirtualNetwork -Name $env.VirtualNetworkName -ResourceGroupName $env.ResourceGroupVmTest 
    Remove-AzScVmmVMTemplate -Name $env.VmTemplateName -ResourceGroupName $env.ResourceGroupVmTest 
    Remove-AzScVmmCloud -Name $env.CloudName -ResourceGroupName $env.ResourceGroupVmTest 
    Remove-AzScVmmVirtualNetwork -Name $env.VirtualNetwork2Name -ResourceGroupName $env.ResourceGroupVmTest
    Remove-AzScVmmAvailabilitySet -Name $env.AvailabilitySetName -ResourceGroupName $env.ResourceGroupVmTest
    Remove-AzScVmmVM -Name $env.VmName -ResourceGroupName $env.ResourceGroupVmTest -DeleteFromHost -DeleteMachine
    Remove-AzScVmmServer -Name $env.VmmServerName -ResourceGroupName $env.ResourceGroupVmTest
    Remove-AzScVmmServer -Name $env.VmmServerName -ResourceGroupName $env.ResourceGroupEnableInvTest
    Remove-AzCustomLocation -Name $env.customLocation1 -ResourceGroupName $env.ResourceGroupVmTest
    Remove-AzCustomLocation -Name $env.customLocation2 -ResourceGroupName $env.ResourceGroupEnableInvTest
    Remove-AzCustomLocation -Name $env.customLocation3 -ResourceGroupName $env.ResourceGroupVmmTest
    Remove-AzResourceGroup -Name $env.ResourceGroupVmTest
    Remove-AzResourceGroup -Name $env.ResourceGroupEnableInvTest
    Remove-AzResourceGroup -Name $env.ResourceGroupVmmTest

    Write-Host "Utils.ps1: cleanupEnv() completed"
}

