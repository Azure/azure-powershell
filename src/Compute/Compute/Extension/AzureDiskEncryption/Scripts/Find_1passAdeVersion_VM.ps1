<#
READ ME:
This script finds Windows and Linux Virtual Machines encrypted with single pass ADE in all resource groups present in a subscription. 
INPUT: 
Enter the subscription ID of the subscription. DO NOT remove hyphens. Example: 759532d8-9991-4d04-878f-xxxxxxxxxxxx
OUTPUT: 
A .csv file with file name "<SubscriptionId>_AdeVMInfo.csv" is created in the same working directory.
Note: If the ADE_Version field = "Not Available" in the output, it means that the VM is encrypted but the extension version couldn't be found. Please check the version manually for these VMs.
#>

$ErrorActionPreference = "Continue"
$SubscriptionId = Read-Host("Enter Subscription ID")
$setSubscriptionContext = Set-AzContext -SubscriptionId $SubscriptionId

if($setSubscriptionContext -ne $null)
{
    $getAllVMInSubscription = Get-AzVM
    $outputContent = @()

    foreach ($vmobject in $getAllVMInSubscription)
    {
        $vm_OS = ""
        if ($vmobject.OSProfile.WindowsConfiguration -eq $null) 
        { 
            $vm_OS = "Linux" 
        }
        else 
        {
            $vm_OS = "Windows" 
        }
    
        $vmInstanceView = Get-AzVM -ResourceGroupName $vmobject.ResourceGroupName -Name $vmobject.Name -Status    

        $isVMADEEncrypted = $false
        $isStoppedVM = $false
        $adeVersion = ""

        #Find ADE extension version if ADE extension is installed                 
        $vmExtensions = $vmInstanceView.Extensions
        foreach ($extension in $vmExtensions)
        {
            if ($extension.Name -like "azurediskencryption*")
            {
                $adeVersion = $extension.TypeHandlerVersion
                $isVMADEEncrypted = $true
                break;            
            }            
        }

        #Look for encryption settings on disks. This applies to VMs that are in deallocated state
        #Extension version information is unavailable for stopped VMs
        if ($isVMADEEncrypted -eq $false)
        {
            $disks = $vmInstanceView.Disks
            foreach ($diskObject in $disks)
            {
                if ($diskObject.EncryptionSettings -ne $null)
                {
                    $isStoppedEncryptedVM = $true
                    break;
                }
            }
        }        

        if ($isVMADEEncrypted)
        {        
            #Prepare output content for single pass VMs            
            if ((($vm_OS -eq "Windows") -and ($adeVersion -like "2.*")) -or (($vm_OS -eq "Linux") -and ($adeVersion -like "1.*")))
            {            
                $results = @{
                VMName = $vmobject.Name
                ResourceGroupName = $vmobject.ResourceGroupName
                VM_OS = $vm_OS
                ADE_Version = $adeVersion                        
                }
                $outputContent += New-Object PSObject -Property $results
                Write-Host "Added details for encrypted VM " $vmobject.Name
            }               
        }
        elseif ($isStoppedEncryptedVM)
        {
            $results = @{
                VMName = $vmobject.Name
                ResourceGroupName = $vmobject.ResourceGroupName
                VM_OS = $vm_OS
                ADE_Version = "Not Available"                        
                }
                $outputContent += New-Object PSObject -Property $results
                Write-Host "Added details for encrypted VM. ADE version = Not available " $vmobject.Name
        }                      
   }

    #Write to output file
    $filePath = ".\" + $SubscriptionId + "_AdeVMInfo.csv"
    $outputContent | export-csv -Path $filePath -NoTypeInformation
}