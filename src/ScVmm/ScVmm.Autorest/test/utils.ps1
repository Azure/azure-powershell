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
    # Install-Module -Name Az.Resources -Force
    # Install-Module -Name Az.KeyVault -Force
    # Install-Module -Name Az.CustomLocation -Force

    # Fetch Secrets from KeyVault
    Write-Host "Fetch Secrets from KeyVault"

    # $applianceId = (Get-AzKeyVaultSecret -VaultName "AzPwshCliTestVault" -Name "ApplianceId0809" -AsPlainText)
    $applianceId = "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourcegroups/hsurana-rg/providers/microsoft.resourceconnector/appliances/hsurana-appl-0809"
    # $clusterExtensionId = (Get-AzKeyVaultSecret -VaultName "AzPwshCliTestVault" -Name "clusterExtensionId-0809" -AsPlainText)
    $clusterExtensionId = "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/hsurana-RG/providers/Microsoft.ResourceConnector/appliances/hsurana-Appl-0809/providers/Microsoft.KubernetesConfiguration/extensions/azure-vmmoperator"
    # $vmmServerFqdn = (Get-AzKeyVaultSecret -VaultName "AzPwshCliTestVault" -Name "vmmServerFqdn0809" -AsPlainText)
    $vmmServerFqdn = "vmmnebdev0809.cdm.lab"
    # $vmmServerUsername = (Get-AzKeyVaultSecret -VaultName "AzPwshCliTestVault" -Name "vmmServerUsername" -AsPlainText)
    $vmmServerUsername = "cdmlab\cdmlabuser"
    # $vmmServerPassword = (Get-AzKeyVaultSecret -VaultName "AzPwshCliTestVault" -Name "vmmServerPassword" -AsPlainText)
    $vmmServerPassword = "!!123abc"
    # $guestUsername = (Get-AzKeyVaultSecret -VaultName "AzPwshCliTestVault" -Name "guestUsername" -AsPlainText)
    $guestUsername = "Administrator"
    # $guestPassword = (Get-AzKeyVaultSecret -VaultName "AzPwshCliTestVault" -Name "guestPassword" -AsPlainText)
    $guestPassword = $vmmServerPassword
    # $cloudUuid = (Get-AzKeyVaultSecret -VaultName "AzPwshCliTestVault" -Name "cloudUuid" -AsPlainText)
    $cloudUuid = "9065ad46-ef59-4a45-8a7f-87acd060c9b1"
    # $vmTemplateUuid = (Get-AzKeyVaultSecret -VaultName "AzPwshCliTestVault" -Name "vmTemplateUuid" -AsPlainText)
    $vmTemplateUuid = "46d3f760-182f-4022-b9fb-3538711ab68b"
    # $vmNetworkUuid = (Get-AzKeyVaultSecret -VaultName "AzPwshCliTestVault" -Name "vmNetworkUuid" -AsPlainText)
    $vmNetworkUuid = "b1bffb6d-10a2-44ee-ae00-3b127262aaf7"
    # $vmNetwork2Uuid = (Get-AzKeyVaultSecret -VaultName "AzPwshCliTestVault" -Name "vmNetworkLn562Uuid" -AsPlainText)
    $vmNetwork2Uuid = "deabb973-5764-4b7b-86ed-41558bc2967c"

    # $vmmSecurePassword = ConvertTo-SecureString $vmmServerPassword -AsPlainText -Force
    # $guestSecurePassword = ConvertTo-SecureString $guestPassword -AsPlainText -Force

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

    # New-AzResourceGroup -Name $env.ResourceGroupVmTest -Location $env.location
    # New-AzResourceGroup -Name $env.ResourceGroupEnableInvTest -Location $env.location
    # New-AzResourceGroup -Name $env.ResourceGroupVmmTest -Location $env.location

    # Deploy CustomLocation in ResourceGroupVmTest, ResourceGroupEnableInvTest and ResourceGroupVmmTest ResourceGroups
    Write-Host "Deploy CustomLocation in ResourceGroups"

    $customLocation1 = "az-pwsh-test-cl-01"
    $customLocation2 = "az-pwsh-test-cl-02"
    $customLocation3 = "az-pwsh-test-cl-03"

    $env.Add("customLocation1", $customLocation1)
    $env.Add("customLocation2", $customLocation2)
    $env.Add("customLocation3", $customLocation3)

    # $CustomLocationVmTest = (New-AzCustomLocation -Name $customLocation1 -ResourceGroupName $env.ResourceGroupVmTest -ClusterExtensionId $clusterExtensionId -HostResourceId $applianceId -Location $env.location -Namespace $customLocation1).Id  
    $CustomLocationVmTest = "/subscriptions/9e7d5c01-90ea-4969-bdbf-a4517cd82ccd/resourcegroups/az-pwsh-test-rg-01/providers/microsoft.extendedlocation/customlocations/az-pwsh-test-cl-01"
    Write-Host "CustomLocationVmTest: $CustomLocationVmTest"
    # $CustomLocationEnableInvTest = (New-AzCustomLocation -Name $customLocation2 -ResourceGroupName $env.ResourceGroupEnableInvTest -ClusterExtensionId $clusterExtensionId -HostResourceId $applianceId -Location $env.location -Namespace $customLocation2).Id
    $CustomLocationEnableInvTest = "/subscriptions/9e7d5c01-90ea-4969-bdbf-a4517cd82ccd/resourcegroups/az-pwsh-test-rg-02/providers/microsoft.extendedlocation/customlocations/az-pwsh-test-cl-02"
    Write-Host "CustomLocationEnableInvTest: $CustomLocationEnableInvTest"
    # $CustomLocationVmmTest = (New-AzCustomLocation -Name $customLocation3 -ResourceGroupName $env.ResourceGroupVmmTest -ClusterExtensionId $clusterExtensionId -HostResourceId $applianceId -Location $env.location -Namespace $customLocation3).Id
    $CustomLocationVmmTest = "/subscriptions/9e7d5c01-90ea-4969-bdbf-a4517cd82ccd/resourcegroups/az-pwsh-test-rg-03/providers/microsoft.extendedlocation/customlocations/az-pwsh-test-cl-03"
    Write-Host "CustomLocationVmmTest: $CustomLocationVmmTest"

    $env.Add("ExtendedLocationType", "customLocation")
    $env.Add("CustomLocationVmTest", $CustomLocationVmTest)
    $env.Add("CustomLocationEnableInvTest", $CustomLocationEnableInvTest)
    $env.Add("CustomLocationVmmTest", $CustomLocationVmmTest)

    # Onboard VMMServer for VM Test and EnableInventory Test
    Write-Host "Onboard VMMServer for VMTest and EnableInvTest"

    # $vmmServerVmTest = (New-AzScVmmServer -Name $env.VmmServerName -ResourceGroupName $env.ResourceGroupVmTest -Location $env.location -CustomLocationId $env.CustomLocationVmTest -FQDN $env.FQDN -Port $env.Port -CredentialsUsername $env.ServerUsername -CredentialsPassword $env.ServerPassword).Id
    $vmmServerVmTest = "/subscriptions/9e7d5c01-90ea-4969-bdbf-a4517cd82ccd/resourceGroups/az-pwsh-test-rg-01/providers/Microsoft.ScVmm/vmmServers/az-pwsh-test-vmm"
    # $vmmServerEnableInvTest = (New-AzScVmmServer -Name $env.VmmServerName -ResourceGroupName $env.ResourceGroupEnableInvTest -Location $env.location -CustomLocationId $env.CustomLocationEnableInvTest -FQDN $env.FQDN -Port $env.Port -CredentialsUsername $env.ServerUsername -CredentialsPassword $env.ServerPassword).Id
    $vmmServerEnableInvTest = "/subscriptions/9e7d5c01-90ea-4969-bdbf-a4517cd82ccd/resourceGroups/az-pwsh-test-rg-02/providers/Microsoft.ScVmm/vmmServers/az-pwsh-test-vmm"

    Write-Host "VmmServerVmTest: $vmmServerVmTest"
    Write-Host "VmmServerEnableInvTest: $vmmServerEnableInvTest"

    $env.Add("VmmServerVmTestId", $vmmServerVmTest)
    $env.Add("VmmServerEnableInvTestId", $vmmServerEnableInvTest)

    # AvailabilitySet for VM Test
    Write-Host "AvailabilitySet for VM Test"

    # $avsetIdVmTest = (New-AzScVmmAvailabilitySet -Name $env.AvailabilitySetName -ResourceGroupName $env.ResourceGroupVmTest -VmmServerName $env.VmmServerName -Location $env.location).Id
    $avsetIdVmTest = "/subscriptions/9e7d5c01-90ea-4969-bdbf-a4517cd82ccd/resourceGroups/az-pwsh-test-rg-01/providers/Microsoft.ScVmm/availabilitySets/az-pwsh-test-avset"
    
    Write-Host "AvailabilitySetIdVmTest: $avsetIdVmTest"
    $env.Add("AvailabilitySetIdVmTest", $avsetIdVmTest)
    
    # VMNetwork for VM Test
    Write-Host "VMNetwork for VM Test"

    # $vmNetworkIdVmTest = (New-AzScVmmVirtualNetwork -Name $env.VirtualNetworkName -ResourceGroupName $env.ResourceGroupVmTest -VmmServerName $env.VmmServerName -InventoryUuid $env.VirtualNetworkUuid -Location $env.location).Id
    # $vmTemplateIdVmTest = (New-AzScVmmVMTemplate -Name $env.VmTemplateName -ResourceGroupName $env.ResourceGroupVmTest -VmmServerName $env.VmmServerName -InventoryUuid $env.VmTemplateUuid -Location $env.location).Id
    # $cloudIdVmTest = (New-AzScVmmCloud -Name $env.CloudName -ResourceGroupName $env.ResourceGroupVmTest -VmmServerName $env.VmmServerName -InventoryUuid $env.CloudUuid -Location $env.location).Id

    $vmNetworkIdVmTest = "/subscriptions/9e7d5c01-90ea-4969-bdbf-a4517cd82ccd/resourceGroups/az-pwsh-test-rg-01/providers/Microsoft.ScVmm/virtualNetworks/az-pwsh-test-vnet"
    $vmTemplateIdVmTest = "/subscriptions/9e7d5c01-90ea-4969-bdbf-a4517cd82ccd/resourceGroups/az-pwsh-test-rg-01/providers/Microsoft.ScVmm/vmTemplates/az-pwsh-test-vm-template"
    $cloudIdVmTest = "/subscriptions/9e7d5c01-90ea-4969-bdbf-a4517cd82ccd/resourceGroups/az-pwsh-test-rg-01/providers/Microsoft.ScVmm/clouds/az-pwsh-test-cloud"

    Write-Host "vmNetworkIdVmTest: $vmNetworkIdVmTest"
    Write-Host "vmTemplateIdVmTest: $vmTemplateIdVmTest"
    Write-Host "cloudIdVmTest: $cloudIdVmTest"

    $env.Add("vmNetworkIdVmTest", $vmNetworkIdVmTest)
    $env.Add("vmTemplateIdVmTest", $vmTemplateIdVmTest)
    $env.Add("cloudIdVmTest", $cloudIdVmTest)

    # Additional VMNetwork for VM Test
    Write-Host "Additional VMNetwork for VM Test"

    # $vmNetwork2IdVmTest = (New-AzScVmmVirtualNetwork -Name $env.VirtualNetwork2Name -ResourceGroupName $env.ResourceGroupVmTest -VmmServerName $env.VmmServerName -InventoryUuid $env.VirtualNetwork2Uuid -Location $env.location).Id
    $vmNetwork2IdVmTest = "/subscriptions/9e7d5c01-90ea-4969-bdbf-a4517cd82ccd/resourceGroups/az-pwsh-test-rg-01/providers/Microsoft.ScVmm/virtualNetworks/Ln562"
    Write-Host "vmNetwork2IdVmTest: $vmNetwork2IdVmTest"
    $env.Add("vmNetwork2IdVmTest", $vmNetwork2IdVmTest)

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
    # Remove-AzScVmmVirtualNetwork -Name $env.VirtualNetworkName -ResourceGroupName $env.ResourceGroupVmTest 
    # Remove-AzScVmmVMTemplate -Name $env.VmTemplateName -ResourceGroupName $env.ResourceGroupVmTest 
    # Remove-AzScVmmCloud -Name $env.CloudName -ResourceGroupName $env.ResourceGroupVmTest 
    # Remove-AzScVmmVirtualNetwork -Name $env.VirtualNetwork2Name -ResourceGroupName $env.ResourceGroupVmTest
    # Remove-AzScVmmAvailabilitySet -Name $env.AvailabilitySetName -ResourceGroupName $env.ResourceGroupVmTest
    # Remove-AzScVmmServer -Name $env.VmmServerName -ResourceGroupName $env.ResourceGroupVmTest
    # Remove-AzScVmmServer -Name $env.VmmServerName -ResourceGroupName $env.ResourceGroupEnableInvTest
    # Remove-AzCustomLocation -Name $env.customLocation1 -ResourceGroupName $env.ResourceGroupVmTest
    # Remove-AzCustomLocation -Name $env.customLocation2 -ResourceGroupName $env.ResourceGroupEnableInvTest
    # Remove-AzCustomLocation -Name $env.customLocation3 -ResourceGroupName $env.ResourceGroupVmmTest
    # Remove-AzResourceGroup -Name $env.ResourceGroupVmTest
    # Remove-AzResourceGroup -Name $env.ResourceGroupEnableInvTest
    # Remove-AzResourceGroup -Name $env.ResourceGroupVmmTest

    Write-Host "Utils.ps1: cleanupEnv() completed"
}

