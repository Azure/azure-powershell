#
# ChefExtensionTests.ps1
#

<#
.SYNOPSIS
Test the usage of the Set virtual machine chef extension command
#>
function Test-SetChefExtensionBasic
{
    $rgname = Get-ComputeTestResourceName
    $loc = Get-ComputeVMLocation

    try
    {
        # Create Virtual Machine
        $vm = Create-VirtualMachine -rgname $rgname -loc $loc
        $vmname = $vm.Name
		$version = "1210.12"
		$client_rb = ".\Templates\client.rb";
		$validationPemFile = ".\Templates\tstorgnztn-validator.pem";

		# Set Chef extension
        Set-AzureRmVMChefExtension -ResourceGroupName $rgname -VMName $vmname -TypeHandlerVersion $version -ClientRb $client.rb -ValidationPem $validationPemFile -Windows
		$extension = Get-AzureRmVMExtension -ResourceGroupName $rgname -VMName $vmname -Name ChefClient        

        Assert-NotNull $extension
        Assert-AreEqual $extension.Publisher 'Chef.Bootstrap.WindowsAzure'
        Assert-AreEqual $extension.ExtensionType 'ChefClient'
        Assert-AreEqual $extension.Name 'ChefClient'
        $settings = $extension.PublicSettings | ConvertFrom-Json
        Assert-AreEqual $settings.autoUpdateClient "false"
		Assert-AreEqual $settings.deleteChefConfig "false"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
