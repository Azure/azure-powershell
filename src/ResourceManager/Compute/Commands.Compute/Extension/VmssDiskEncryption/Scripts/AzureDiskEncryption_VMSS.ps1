Param(
  [Parameter(Mandatory = $false,
             HelpMessage="Identifier of the Azure subscription to be used. Default subscription will be used if not specified.")]
  [ValidateNotNullOrEmpty()]
  [string]$subscriptionId,

  [Parameter(Mandatory = $true, 
             HelpMessage="Name of the resource group to which the KeyVault belongs to.  A new resource group with this name will be created if one doesn't exist")]
  [ValidateNotNullOrEmpty()]
  [string]$resourceGroupName,

  [Parameter(Mandatory = $true,
             HelpMessage="Location of the KeyVault. Important note: Make sure the KeyVault and VMSS to be encrypted are in the same location.")]
  [ValidateNotNullOrEmpty()]
  [string]$location,

  [Parameter(Mandatory = $true,
             HelpMessage="Name of the KeyVault in which encryption keys are to be placed. A new vault with this name will be created if one doesn't exist")]
  [ValidateNotNullOrEmpty()]
  [string]$keyVaultName,

  [Parameter(Mandatory = $false,
             HelpMessage="Name of optional key encryption key in KeyVault. A new key with this name will be created if one doesn't exist")]
  [ValidateNotNullOrEmpty()]
  [string]$keyEncryptionKeyName,

  [Parameter(Mandatory = $false,
             HelpMessage="Name of the VMSS to be encrypted")]
  [ValidateNotNullOrEmpty()]
  [string]$VmssName
)

$VerbosePreference = "Continue";
$ErrorActionPreference = “Stop”;

########################################################################################################################
# Section1:  Log-in to Azure and select appropriate subscription. 
########################################################################################################################

    #Write-Host 'Please log into Azure now' -foregroundcolor Green;
    #Login-AzureRmAccount -ErrorAction "Stop" 1> $null;

    if($subscriptionId)
    {
        Select-AzureRmSubscription -SubscriptionId $subscriptionId;
    }

    $vmssDiskEncryptionFeature = Get-AzureRmProviderFeature  -FeatureName "UnifiedDiskEncryption" -ProviderNamespace "Microsoft.Compute";
    if($vmssDiskEncryptionFeature -and $vmssDiskEncryptionFeature.RegistrationState -eq 'Registered')
    {
        Write-Host "AzureDiskEncryption-VMSS feature is enabled for subscription :  $subscriptionId";
    } 
    else
    {
        Write-Host "Enabling UnifiedDiskEncryption AzureDiskEncryption-VMSS feature for subscription :  ($subscriptionId)";
        #Opt-in to AzureDiskEncryption VMSS preview
        Register-AzureRmProviderFeature -FeatureName "UnifiedDiskEncryption" -ProviderNamespace "Microsoft.Compute";
        $vmssDiskEncryptionFeature = Get-AzureRmProviderFeature  -FeatureName "UnifiedDiskEncryption" -ProviderNamespace "Microsoft.Compute";
        for($i = 1; i<6; i++)
        {
            if($vmssDiskEncryptionFeature -and $vmssDiskEncryptionFeature.RegistrationState -eq 'Registered')
            {
                Write-Host "AzureDiskEncryption-VMSS feature is enabled for subscription :  ($subscriptionId)";
                break;
            }  
            else
            {
                Write-Host "Sleeping 10 seconds to actiavate AzureDiskEncryption-VMSS feature . Retry count :  ($i)";
                Start-Sleep -Seconds 10;
            }         
        }
        if(!$vmssDiskEncryptionFeature -or $vmssDiskEncryptionFeature.RegistrationState -ne 'Registered')
        {
            Write-Error "AzureDiskEncryption-VMSS feature is NOT enabled . Please retry after sometime";
        } 
    }

########################################################################################################################
# Section2:  Create ResourceGroup and KeyVault if they don't exist
########################################################################################################################

    #Check if given ResourceGroup exists
    Try
    {
        $resGroup = Get-AzureRmResourceGroup -Name $resourceGroupName -ErrorAction SilentlyContinue;
    }
    Catch [System.ArgumentException]
    {
        Write-Host "Couldn't find resource group:  ($resourceGroupName)";
        $resGroup = $null;
    }
    
    #Create a new resource group if it doesn't exist
    if (-not $resGroup)
    {
        Write-Host "Creating new resource group:  ($resourceGroupName)";
        $resGroup = New-AzureRmResourceGroup -Name $resourceGroupName -Location $location;
        Write-Host "Created a new resource group named $resourceGroupName to place keyVault";
    }
    
    #Check if given KeyVault exists
    Try
    {
        $keyVault = Get-AzureRmKeyVault -VaultName $keyVaultName -ErrorAction SilentlyContinue;
    }
    Catch [System.ArgumentException]
    {
        Write-Host "Couldn't find Key Vault: $keyVaultName";
        $keyVault = $null;
    }
    
    #Create a new vault if vault doesn't exist
    if (-not $keyVault)
    {
        Write-Host "Creating new key vault:  ($keyVaultName)";
        $keyVault = New-AzureRmKeyVault -VaultName $keyVaultName -ResourceGroupName $resourceGroupName -Sku Standard -Location $location;
        Write-Host "Created a new KeyVault named $keyVaultName to store encryption keys";
    }

    #Set EnabledForDiskEncryption accesspolicy on KeyVault for AzureDiskEncrypiton to perform set secret, get secret, wrap key and unwrap key operations
    Set-AzureRmKeyVaultAccessPolicy -VaultName $keyVaultName -EnabledForDiskEncryption;
    
    $diskEncryptionKeyVaultUrl = $keyVault.VaultUri;
	$keyVaultResourceId = $keyVault.ResourceId;

    Write-Host "DiskEncryptionKeyVaultUrl:$diskEncryptionKeyVaultUrl" -foregroundcolor Green;
    Write-Host "DiskEncryptionKeyVaultId:$keyVaultResourceId" -foregroundcolor Green;
    
    if($keyEncryptionKeyName)
    {
        #Check if given KeyEncryptionKey exists
        Try
        {
            $kek = Get-AzureKeyVaultKey -VaultName $keyVaultName -Name $keyEncryptionKeyName -ErrorAction SilentlyContinue;
        }
        Catch [Microsoft.Azure.KeyVault.KeyVaultClientException]
        {
            Write-Host "Couldn't find key encryption key named : $keyEncryptionKeyName in Key Vault: $keyVaultName";
            $kek = $null;
        } 

        if(-not $kek)
        {
            Write-Host "Creating new key encryption key named:$keyEncryptionKeyName in Key Vault: $keyVaultName";
            $kek = Add-AzureKeyVaultKey -VaultName $keyVaultName -Name $keyEncryptionKeyName -Destination Software -ErrorAction SilentlyContinue;
            Write-Host "Created  key encryption key named:$keyEncryptionKeyName in Key Vault: $keyVaultName";
        }

        $keyEncryptionKeyUrl = $kek.Key.Kid;
        Write-Host "keyEncryptionKeyUrl:$keyEncryptionKeyUrl" -foregroundcolor Green;
        Write-Host "KeyEncryptionKeyVaultId:$keyVaultResourceId" -foregroundcolor Green;
    }   


########################################################################################################################
# Section3:  EnableEncryption on VMSS using specified KeyVault and KeyEncryptionKey 
########################################################################################################################

    if($VmssName)
    {
        Write-Host "EnablingEncryption on scale set:$VmssName";

        #Use KEK is specified
        if($keyEncryptionKeyName)
        { 
            #ExtensionName parameter is required until PROD extension is rolled out       
            Set-AzureRmVmssDiskEncryptionExtension -ResourceGroupName $resourceGroupName `
                                                   -VMScaleSetName $VmssName `
                                                   -DiskEncryptionKeyVaultUrl $diskEncryptionKeyVaultUrl `
                                                   -DiskEncryptionKeyVaultId $keyVaultResourceId `
                                                   -KeyEncryptionKeyUrl $keyEncryptionKeyUrl `
                                                   -KeyEncryptionKeyVaultId $keyVaultResourceId `
                                                   -Force;
        }
        else
        {
            Set-AzureRmVmssDiskEncryptionExtension -ResourceGroupName $resourceGroupName `
                                                   -VMScaleSetName $VmssName `
                                                   -DiskEncryptionKeyVaultUrl $diskEncryptionKeyVaultUrl `
                                                   -DiskEncryptionKeyVaultId $keyVaultResourceId `
                                                   -Force;
        }

        #If the upgrade policy is manual, Update VMSS instances to enable encryption on them
        $vmss = Get-AzureRmVmss -ResourceGroupName $resourceGroupName -VMScaleSetName $VmssName;
        if($vmss.UpgradePolicy.Mode -eq 'Manual')
        {
            #Deploy AzureDiskEncryption extension updates to all instances
            Update-AzureRmVmssInstance -ResourceGroupName $resourceGroupName -VMScaleSetName $VmssName -InstanceId "*";
        }

        #show encryption status of VMSS instances
        Get-AzureRmVmssVmDiskEncryption -ResourceGroupName $resourceGroupName -VMScaleSetName $VmssName | fc;
    }
