<# 
READ ME:
This script finds Windows and Linux Virtual Machine Scale Sets encrypted with single pass ADE in all resource groups present in a subscription. 
INPUT: 
Enter the subscription ID of the subscription. DO NOT remove hyphens. Example: 759532d8-9991-4d04-878f-xxxxxxxxxxxx
OUTPUT: 
A .csv file with file name "<SubscriptionId>__AdeVMSSInfo.csv" is created in the same working directory. 
Note: If the ADE_Version field = "Not Available" in the output, it means that the VM is encrypted but the extension version couldn't be found. Please check the version manually for these VMSS.
#>

$ErrorActionPreference = "Continue"
$SubscriptionId = Read-Host("Enter Subscription ID")
$setSubscriptionContext = Set-AzContext -SubscriptionId $SubscriptionId

if($setSubscriptionContext -ne $null)
{
    $getAllVMSSInSubscription = Get-AzVmss
    $outputContent = @()

    foreach ($vmssobject in $getAllVMSSInSubscription)
    {
        $vmssModel = Get-AzVmss -ResourceGroupName $vmssobject.ResourceGroupName -VMScaleSetName $vmssobject.Name
        if ($vmssModel.VirtualMachineProfile.OsProfile.WindowsConfiguration -eq $null) 
        { 
            $vmss_OS = "Linux" 
        }
        else 
        {
            $vmss_OS = "Windows" 
        }

        $isVMSSADEEncrypted = $false
        $adeVersion = ""

        #find if VMSS has ADE extension installed        
        $vmssExtensions = $vmssObject.VirtualMachineProfile.ExtensionProfile.Extensions
        foreach ($extension in $vmssExtensions)
        {
            if ($extension.Type -like "azurediskencryption*")
            {
                $isVMSSADEEncrypted = $true
                break;            
            }            
        }

        #find ADE extension version if VMSS has ADE installed. 
        if ($isVMSSADEEncrypted)
        {
            $vmssInstanceView = Get-AzVmssVM -ResourceGroupName $vmssobject.ResourceGroupName -VMScaleSetName $vmssobject.Name -InstanceView
            $vmssInstanceId = $vmssInstanceView[0].InstanceId
            $vmssVMInstanceView = Get-AzVmssVM -ResourceGroupName $vmssobject.ResourceGroupName -VMScaleSetName $vmssobject.Name -InstanceView -InstanceId $vmssInstanceId

            $vmssExtensions = $vmssVMInstanceView.Extensions
            foreach ($extension in $vmssExtensions)
            {
                if ($extension.Type -like "Microsoft.Azure.Security.Azurediskencryption*")
                {
                    $adeVersion = $extension.TypeHandlerVersion
                    break;            
                }            
            }

            #Prepare output content for single pass VMSS            
            if ((($vmss_OS -eq "Windows") -and ($adeVersion -like "2.*")) -or (($vmss_OS -eq "Linux") -and ($adeVersion -like "1.*")))
            {            
                $results = @{
                VMSSName = $vmssobject.Name
                ResourceGroupName = $vmssobject.ResourceGroupName
                VMSS_OS = $vmss_OS
                ADE_Version = $adeVersion        
                }
                $outputContent += New-Object PSObject -Property $results
                Write-Host "Added details for encrypted VMSS" $vmssobject.Name
            }
            elseif ([string]::IsNullOrEmpty($adeVersion))
            {
                $results = @{
                VMSSName = $vmssobject.Name
                ResourceGroupName = $vmssobject.ResourceGroupName
                VMSS_OS = $vmss_OS
                ADE_Version = "Not Available"        
                }
                $outputContent += New-Object PSObject -Property $results
                Write-Host "Added details for encrypted VMSS. ADE version = Not available" $vmssobject.Name
            }                         
        }                      
    }

    #Write to output file
    $filePath = ".\" + $SubscriptionId + "_AdeVMSSInfo.csv"
    $outputContent | export-csv -Path $filePath -NoTypeInformation
}