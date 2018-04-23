If you need an Azure Virtual Machine with all the [prerequisites](https://github.com/Azure/azure-powershell/blob/preview/documentation/development-docs/azure-powershell-developer-guide.md#prerequisites) installed and ready to build and test Powershell Azure - follow the steps below. 

# Copy the PowerShell Azure VHD blob to your subscription and create a VM from it.

1. Make sure that you have the version 4.5.0 or above of the AzureRM.Compute PowerShell module. Run the following command to install it. This version has the "easy VM create" cmdlet that we are going to use in the script below to create a VM.
    ```PowerShell
    Install-Module AzureRM.Compute --MinimumVersion  4.5.0
    ```
2. Email azdevxps@microsoft.com to obtain a VHD SAS URI, and assign that unique URI to the variable below.
    ```PowerShell
    $VhdSasUri = <vhd-sas-uri-requested-from-us>
    ```
3. Create some variables. **_Before setting the ```$Location``` variable - make sure your subscription supports virtual machine creation in the location._**
   ```PowerShell
    $SubscriptionId = <subscription-id>
    $ResourceGroupName = <resource-group-name>
    #Make sure your subscription supports virtual machine creation in the location.
    $Location = <location>

    $Random_5_digits = Get-Random -SetSeed (Get-Date).Second | ForEach-Object {$_.ToString().Substring(5)}
    $StorageAccountName = "poshazureenv" + $Random_5_digits
    $StorageContainerName = "vhds"

    $VhdFileName = "ps-azure-env.vhd"
    $ImageName = "ps-azure-env-image"
    $VmName = "ps-azure-env"
    $VMSize= "Standard_D4s_v3"

    $VmLogin = <login>
    $VmPassword = <password>

    $ErrorActionPreference = "Stop"
    $VmCredential = New-Object -TypeName System.Management.Automation.PSCredential -ArgumentList $VmLogin, $(ConvertTo-SecureString -String $VmPassword -AsPlainText -Force)
   ```
4. Sign in to your Azure account.
    ```PowerShell
    Connect-AzureRmAccount
    ```
5. Execute the Powershell script. The script essentially does the following:
    1. Checks if a **resource group** with the name ```$ResourceGroupName``` exists if not - creates it for you.
    2. Checks if a **storage account**  with the name ```$StorageAccountName``` exists if not - creates it for you.
    3. Checks if a **storage account container** with the name ```$StorageAccountName``` exists if not - creates it for you.
    4. Copies a **VHD** from the location ```$VhdSasUri``` to you storage account container.
    5. Creates an **image** form the VHD with the ```$ImageName``` name.
    5. Creates a **VM** from the image with the ```$VmName``` name.
    ```PowerShell    
    function SelectSubscription() {
        Write-Host "==> SelectSubscription"
        $null = Select-AzureRmSubscription -SubscriptionId $SubscriptionId    
    }

    function CreateResourceGroupIfNone() {
        Write-Host "==> CreateResourceGroupIfNone"
        $null = Get-AzureRmResourceGroup -Name $ResourceGroupName -ErrorVariable rgNotPresent -ErrorAction SilentlyContinue 
        if ($rgNotPresent) {
            $null = New-AzureRmResourceGroup -Name $ResourceGroupName -Location $Location
            Write-Host "`tCreated resource group $ResourceGroupName" -ForegroundColor Yellow
        }
    }

    function CreateStorageIfNone() {
        Write-Host "==> CreateStorageIfNone"
        
        # Storage Account
        Write-Host "`tStorage Account"
        try {
            $sa = Get-AzureRmStorageAccount -StorageAccountName $StorageAccountName -ResourceGroupName $ResourceGroupName
        } catch {
            if ($_ -like "*was not found*") {
                $sa = New-AzureRmStorageAccount -ResourceGroupName $ResourceGroupName -Name $StorageAccountName -Location $Location -SkuName Standard_LRS 
                Write-Host "`tCreated storage account $StorageAccountName." -ForegroundColor Yellow
            } else {
                throw $_.Exception
            }
        }

        $script:StorageAccountContext = $sa.Context

        # Storage Container
        Write-Host "`tStorage Container"
        try {
            $sc = Get-AzureStorageContainer -Name $StorageContainerName -Context $StorageAccountContext
        } catch {
            if ($_ -like "*Can not find the container*") {
                $sc = New-AzureStorageContainer -Name $StorageContainerName -Context $StorageAccountContext  
                Write-Host "`tCreated storage container $StorageContainerName." -ForegroundColor Yellow
            } else {
                throw $_.Exception
            }
        }
    }

    function CopyVhdBlob() {
        Write-Host "==> Start-AzureStorageBlobCopy"
        $null = Start-AzureStorageBlobCopy -AbsoluteUri $VhdSasUri -DestContainer $StorageContainerName -DestContext $StorageAccountContext -DestBlob $VhdFileName
        $Time = [System.Diagnostics.Stopwatch]::StartNew()
        Write-Host "==> Polling Azure Storage Blob Copy State..."
        $null = Get-AzureStorageBlobCopyState -Blob $VhdFileName -Container $StorageContainerName -Context $StorageAccountContext -WaitForComplete    
        $CurrentTime = $Time.Elapsed
        $Elapsed = $([string]::Format("{0:d2}:{1:d2}:{2:d2}", $CurrentTime.hours, $CurrentTime.minutes, $CurrentTime.seconds))
        Write-Host "`tVHD blob has been copied. Time: $Elapsed" -ForegroundColor Yellow
    }

    function CreateImageFromVhd() {
        Write-Host "==> CreateImageFromVhd"
        $Blob = Get-AzureStorageBlob -Context $StorageAccountContext -Container $StorageContainerName -Blob $VhdFileName
        $BlobUri = $Blob.ICloudBlob.Uri.AbsoluteUri

        $ImageConfig = New-AzureRmImageConfig -Location $Location
        $ImageConfig = Set-AzureRmImageOsDisk -Image $ImageConfig -OsType Windows -OsState Generalized -BlobUri $BlobUri
        $script:Image = New-AzureRmImage -ImageName $ImageName -ResourceGroupName $ResourceGroupName -Image $ImageConfig
    }

    function CreateVmFromImage() {
        Write-Host "==> CreateVmFromImage"
        New-AzureRmVm -Name $VmName -Location $Location -ResourceGroupName $ResourceGroupName -ImageName $Image.Id -Credential $VmCredential -Size $VmSize
    }

    SelectSubscription
    CreateResourceGroupIfNone
    CreateStorageIfNone
    CopyVhdBlob
    CreateImageFromVhd
    CreateVmFromImage

    Write-Host "==> All done."
    ```

# Github Settings and Repository Setup
You will need to set up the GitHub configuration so that commits appear with your GitHub name.
```
git config --global user.email "<Your email on GitHub>"
```
```
git config --global user.name "<Your name>"
```
Next, you will need to follow the steps [here](https://github.com/Azure/azure-powershell/wiki/Azure-Powershell-Developer-Guide#environment-setup) to set up your local fork of Azure/azure-powershell.

# Building and Running Tests
This image has been set up to build and run tests immediately. To build the project, run msbuild build.proj in the Developer Command Prompt for VS2015. Once this has completed, you can open your module in Visual Studio and start development there. To record tests, follow the instructions [here](https://github.com/Azure/azure-powershell/wiki/Azure-Powershell-Developer-Guide#recordingrunning-tests).
