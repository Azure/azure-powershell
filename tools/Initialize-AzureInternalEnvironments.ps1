$AzureStack="AzureStack"

#$AadTenantId = "4993704a-4e53-4e79-95dd-5f1747eb7554"
$AadTenantDirectoryDomain = "waptestad.onmicrosoft.com"
$ApplicationId  = "https://pt-test04.api.waptestad.onmicrosoft.com" 
$AzureStackMachineName = "pt-test04"

Add-AzureRmEnvironment -Name $AzureStack `
    -ActiveDirectoryEndpoint ("https://login.windows.net/$AadTenantDirectoryDomain/") `
    -ActiveDirectoryServiceEndpointResourceId $ApplicationId `
    -ResourceManagerEndpoint ("https://"+$AzureStackMachineName+":30005/") `
    -GalleryEndpoint ("https://"+$AzureStackMachineName+":30016/") `
    -GraphEndpoint "https://graph.windows.net/"


#Add-AzureRmEnvironment -Name $AzureStack `
#    -PublishSettingsFileUrl 'https://auxnext.windows.azure-test.net/publishsettings/index' `
#    -ServiceEndpoint 'https://managementnext.rdfetest.dnsdemo4.com/' `
#    -ManagementPortalUrl 'https://auxnext.windows.azure-test.net/' `
#    -ActiveDirectoryEndpoint 'https://login.windows-ppe.net/' `
#    -ActiveDirectoryServiceEndpointResourceId 'https://management.core.windows.net/' `
#    -ResourceManagerEndpoint 'https://api-next.resources.windows-int.net/' `
#    -GalleryEndpoint 'https://next.gallery.azure-test.net/' `
#    -GraphEndpoint 'https://graph.ppe.windows.net/'


