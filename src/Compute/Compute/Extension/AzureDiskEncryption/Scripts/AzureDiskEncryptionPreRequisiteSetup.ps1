#Requires -Module Az.Resources
#Requires -Module Az.KeyVault

Param(
  [Parameter(Mandatory = $true, 
             HelpMessage="Name of the resource group to which the KeyVault belongs to.  A new resource group with this name will be created if one doesn't exist")]
  [ValidateNotNullOrEmpty()]
  [string]$resourceGroupName,

  [Parameter(Mandatory = $true,
             HelpMessage="Name of the KeyVault in which encryption keys are to be placed. A new vault with this name will be created if one doesn't exist")]
  [ValidateNotNullOrEmpty()]
  [string]$keyVaultName,

  [Parameter(Mandatory = $true,
             HelpMessage="Location of the KeyVault. Important note: Make sure the KeyVault and VMs to be encrypted are in the same region / location.")]
  [ValidateNotNullOrEmpty()]
  [string]$location,

  [Parameter(Mandatory = $true,
             HelpMessage="Identifier of the Azure subscription to be used")]
  [ValidateNotNullOrEmpty()]
  [string]$subscriptionId,

  [Parameter(Mandatory = $false,
             HelpMessage="Name of the AAD application that will be used to write secrets to KeyVault. A new application with this name will be created if one doesn't exist. If this app already exists, pass aadClientSecret parameter to the script")]
  [ValidateNotNullOrEmpty()]
  [string]$aadAppName,

  [Parameter(Mandatory = $false,
             HelpMessage="Client secret of the AAD application that was created earlier")]
  [ValidateNotNullOrEmpty()]
  [string]$aadClientSecret,

  [Parameter(Mandatory = $false,
             HelpMessage="Name of optional key encryption key in KeyVault. A new key with this name will be created if one doesn't exist")]
  [ValidateNotNullOrEmpty()]
  [string]$keyEncryptionKeyName

)

$VerbosePreference = "Continue"
$ErrorActionPreference = "Stop"

########################################################################################################################
# Section1:  Log-in to Azure and select appropriate subscription. 
########################################################################################################################

    Select-AzSubscription -SubscriptionId $subscriptionId;

####################################################################################################################################
# Section2:  Create AAD app if encryption is enabled using AAD. Fill in $aadClientSecret variable if AAD app was already created.
####################################################################################################################################

    if($aadAppName)
    {
        # Check if AAD app with $aadAppName was already created
        $SvcPrincipals = (Get-AzADServicePrincipal -SearchString $aadAppName);
        if(-not $SvcPrincipals)
        {
            # Create a new AD application if not created before
            $identifierUri = [string]::Format("http://localhost:8080/{0}",[Guid]::NewGuid().ToString("N"));
            $defaultHomePage = 'http://contoso.com';
            $now = [System.DateTime]::Now;
            $oneYearFromNow = $now.AddYears(1);
            $aadClientSecret = [Guid]::NewGuid().ToString();
            Write-Host "Creating new AAD application ($aadAppName)";

	    $secureAadClientSecret = ConvertTo-SecureString -String $aadClientSecret -AsPlainText -Force;
	    $ADApp = New-AzADApplication -DisplayName $aadAppName -HomePage $defaultHomePage -IdentifierUris $identifierUri  -StartDate $now -EndDate $oneYearFromNow -Password $secureAadClientSecret;

            $servicePrincipal = New-AzADServicePrincipal -ApplicationId $ADApp.ApplicationId;
            $SvcPrincipals = (Get-AzADServicePrincipal -SearchString $aadAppName);
            if(-not $SvcPrincipals)
            {
                # AAD app wasn't created 
                Write-Error "Failed to create AAD app $aadAppName. Please log in to Azure using Connect-AzAccount and try again";
                return;
            }
            $aadClientID = $servicePrincipal.ApplicationId;
            Write-Host "Created a new AAD Application ($aadAppName) with ID: $aadClientID ";
        }
        else
        {
            if(-not $aadClientSecret)
            {
                $aadClientSecret = Read-Host -Prompt "Aad application ($aadAppName) was already created, input corresponding aadClientSecret and hit ENTER. It can be retrieved from https://manage.windowsazure.com portal" ;
            }
            if(-not $aadClientSecret)
            {
                Write-Error "Aad application ($aadAppName) was already created. Re-run the script by supplying aadClientSecret parameter with corresponding secret from https://manage.windowsazure.com portal";
                return;
            }
            $aadClientID = $SvcPrincipals[0].ApplicationId;
        }
    }

# Before proceeding to Section3, make sure $aadClientID  and $aadClientSecret have valid values
########################################################################################################################
# Section3:  Create KeyVault or setup existing keyVault
########################################################################################################################

    Try
    {
        $resGroup = Get-AzResourceGroup -Name $resourceGroupName -ErrorAction SilentlyContinue;
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
        $resGroup = New-AzResourceGroup -Name $resourceGroupName -Location $location;
        Write-Host "Created a new resource group named $resourceGroupName to place keyVault";
    }
    
    Try
    {
        $keyVault = Get-AzKeyVault -VaultName $keyVaultName -ErrorAction SilentlyContinue;
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
        $keyVault = New-AzKeyVault -VaultName $keyVaultName -ResourceGroupName $resourceGroupName -Sku Standard -Location $location;
        Write-Host "Created a new KeyVault named $keyVaultName to store encryption keys";
    }

    if($aadAppName)
    {
        # Specify privileges to the vault for the AAD application - https://msdn.microsoft.com/en-us/library/mt603625.aspx
        Set-AzKeyVaultAccessPolicy -VaultName $keyVaultName -ServicePrincipalName $aadClientID -PermissionsToKeys wrapKey -PermissionsToSecrets set;
    }

    Set-AzKeyVaultAccessPolicy -VaultName $keyVaultName -EnabledForDiskEncryption;

    # Enable soft delete on KeyVault to not lose encryption secrets
    Write-Host "Enabling Soft Delete on KeyVault $keyVaultName";
    $resource = Get-AzResource -ResourceId $keyVault.ResourceId;
    $resource.Properties | Add-Member -MemberType "NoteProperty" -Name "enableSoftDelete" -Value "true" -Force;
    Set-AzResource -resourceid $resource.ResourceId -Properties $resource.Properties -Force;

    # Enable ARM resource lock on KeyVault to prevent accidental key vault deletion
    Write-Host "Adding resource lock on  KeyVault $keyVaultName";
    $lockNotes = "KeyVault may contain AzureDiskEncryption secrets required to boot encrypted VMs";
    New-AzResourceLock -LockLevel CanNotDelete -LockName "LockKeyVault" -ResourceName $resource.Name -ResourceType $resource.ResourceType -ResourceGroupName $resource.ResourceGroupName -LockNotes $lockNotes -Force;

    $diskEncryptionKeyVaultUrl = $keyVault.VaultUri;
	$keyVaultResourceId = $keyVault.ResourceId;

    if($keyEncryptionKeyName)
    {
        Try
        {
            $kek = Get-AzKeyVaultKey -VaultName $keyVaultName -Name $keyEncryptionKeyName -ErrorAction SilentlyContinue;
        }
        Catch [Microsoft.Azure.KeyVault.KeyVaultClientException]
        {
            Write-Host "Couldn't find key encryption key named : $keyEncryptionKeyName in Key Vault: $keyVaultName";
            $kek = $null;
        } 

        if(-not $kek)
        {
            Write-Host "Creating new key encryption key named:$keyEncryptionKeyName in Key Vault: $keyVaultName";
            $kek = Add-AzKeyVaultKey -VaultName $keyVaultName -Name $keyEncryptionKeyName -Destination Software -ErrorAction SilentlyContinue;
            Write-Host "Created  key encryption key named:$keyEncryptionKeyName in Key Vault: $keyVaultName";
        }

        $keyEncryptionKeyUrl = $kek.Key.Kid;
    }   

########################################################################################################################
# Section3:  Displays values that should be used while enabling encryption. Please note these down
########################################################################################################################
    Write-Host "Please note down below details that will be needed to enable encryption on your VMs " -foregroundcolor Green;
    if($aadAppName)
    {
        Write-Host "`t aadClientID: $aadClientID" -foregroundcolor Green;
        Write-Host "`t aadClientSecret: $aadClientSecret" -foregroundcolor Green;
    }
    Write-Host "`t DiskEncryptionKeyVaultUrl: $diskEncryptionKeyVaultUrl" -foregroundcolor Green;
    Write-Host "`t DiskEncryptionKeyVaultId: $keyVaultResourceId" -foregroundcolor Green;
    if($keyEncryptionKeyName)
    {
        Write-Host "`t KeyEncryptionKeyURL: $keyEncryptionKeyUrl" -foregroundcolor Green;
        Write-Host "`t KeyEncryptionKeyVaultId: $keyVaultResourceId" -foregroundcolor Green;
    }
    Write-Host "Please Press [Enter] after saving values displayed above. They are needed to enable encryption using Set-AzVmDiskEncryptionExtension cmdlet" -foregroundcolor Green;
    Read-Host;

########################################################################################################################
# To encrypt one VM in given resource group of the logged in subscritpion, assign $vmName and uncomment below section
########################################################################################################################
#$vmName = "Your VM Name";
#$allVMs = Get-AzVm -ResourceGroupName $resourceGroupName -Name $vmName;

########################################################################################################################
# To encrypt all the VMs in the given resource group of the logged in subscription uncomment below section
########################################################################################################################
#$allVMs = Get-AzVm -ResourceGroupName $resourceGroupName;

########################################################################################################################
# To encrypt all the VMs in the all the resource groups of the logged in subscription, uncomment below section
########################################################################################################################
#$allVMs = Get-AzVm;

########################################################################################################################
# Loop through the selected list of VMs and enable encryption
########################################################################################################################

foreach($vm in $allVMs)
{
    if($vm.Location.replace(' ','').ToLower() -ne $keyVault.Location.replace(' ','').ToLower())
    {
        Write-Error "To enable AzureDiskEncryption, VM and KeyVault must belong to same subscription and same region. vm Location:  $($vm.Location.ToLower()) , keyVault Location: $($keyVault.Location.ToLower())";
        return;
    }

    Write-Host "Encrypting VM: $($vm.Name) in ResourceGroup: $($vm.ResourceGroupName) " -foregroundcolor Green;
    if($aadAppName)
    {
        if(-not $kek)
        {
            Set-AzVMDiskEncryptionExtension -ResourceGroupName $vm.ResourceGroupName -VMName $vm.Name -AadClientID $aadClientID -AadClientSecret $aadClientSecret -DiskEncryptionKeyVaultUrl $diskEncryptionKeyVaultUrl -DiskEncryptionKeyVaultId $keyVaultResourceId -VolumeType 'All';
        }
        else
        {
            Set-AzVMDiskEncryptionExtension -ResourceGroupName $vm.ResourceGroupName -VMName $vm.Name -AadClientID $aadClientID -AadClientSecret $aadClientSecret -DiskEncryptionKeyVaultUrl $diskEncryptionKeyVaultUrl -DiskEncryptionKeyVaultId $keyVaultResourceId -KeyEncryptionKeyUrl $keyEncryptionKeyUrl -KeyEncryptionKeyVaultId $keyVaultResourceId -VolumeType 'All';
        }
    }
    else
    {
        if(-not $kek)
        {
            Set-AzVMDiskEncryptionExtension -ResourceGroupName $vm.ResourceGroupName -VMName $vm.Name -DiskEncryptionKeyVaultUrl $diskEncryptionKeyVaultUrl -DiskEncryptionKeyVaultId $keyVaultResourceId -VolumeType 'All';
        }
        else
        {
            Set-AzVMDiskEncryptionExtension -ResourceGroupName $vm.ResourceGroupName -VMName $vm.Name -DiskEncryptionKeyVaultUrl $diskEncryptionKeyVaultUrl -DiskEncryptionKeyVaultId $keyVaultResourceId -KeyEncryptionKeyUrl $keyEncryptionKeyUrl -KeyEncryptionKeyVaultId $keyVaultResourceId -VolumeType 'All';
        }
    }
    # Show encryption status of the VM
    Get-AzVmDiskEncryptionStatus -ResourceGroupName $vm.ResourceGroupName -VMName $vm.Name;
}
