### Example 1: Add an extension to existing cloud service
```powershell
# Create RDP extension object
PS C:\> $rdpExtension = New-AzCloudServiceRemoteDesktopExtensionObject -Name "RDPExtension" -Credential $credential -Expiration $expiration -TypeHandlerVersion "1.2.1"
# Get existing cloud service
PS C:\> $cloudService = Get-AzCloudService -ResourceGroup "ContosOrg" -CloudServiceName "ContosoCS"
# Add RDP extension to existing cloud service extension object
PS C:\> $cloudService.ExtensionProfileExtension = $cloudService.ExtensionProfileExtension + $rdpExtension
# Updaet cloud service
PS C:\> $cloudService | Update-AzCloudService
```
Above set of commands adds a RDP extension to already existing cloud service named named ContosoCS that belongs to the resource group named ContosOrg.
