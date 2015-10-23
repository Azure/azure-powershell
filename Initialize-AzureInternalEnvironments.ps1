#######################
$dogfood = "dogfood"
$current = "current"
$next    = "next"

function Has-Environment($name)
{
    $environments = Get-AzureRmEnvironment
    foreach ($environment in $environments)
    {
        if ($environment.EnvironmentName -eq $name) { return $true }
    }

    return $false
}

if (-not (Has-Environment $dogfood))
{
  Add-AzureRmEnvironment -Name $dogfood `
    -PublishSettingsFileUrl 'https://windows.azure-test.net/publishsettings/index' `
    -ServiceEndpoint 'https://management-preview.core.windows-int.net/' `
    -ManagementPortalUrl 'https://windows.azure-test.net/' `
    -ActiveDirectoryEndpoint 'https://login.windows-ppe.net/' `
    -ActiveDirectoryServiceEndpointResourceId 'https://management.core.windows.net/' `
    -ResourceManagerEndpoint 'https://api-dogfood.resources.windows-int.net/' `
    -GalleryEndpoint 'https://df.gallery.azure-test.net/' `
    -GraphEndpoint 'https://graph.ppe.windows.net/'
}
if (-not (Has-Environment $current))
{
  Add-AzureRmEnvironment -Name $current `
    -PublishSettingsFileUrl 'https://auxcurrent.windows.azure-test.net/publishsettings/index' `
    -ServiceEndpoint 'https://management.rdfetest.dnsdemo4.com/' `
    -ManagementPortalUrl 'https://auxcurrent.windows.azure-test.net/' `
    -ActiveDirectoryEndpoint 'https://login.windows-ppe.net/' `
    -ActiveDirectoryServiceEndpointResourceId 'https://management.core.windows.net/' `
    -ResourceManagerEndpoint 'https://api-current.resources.windows-int.net/' `
    -GalleryEndpoint 'https://current.gallery.azure-test.net/' `
    -GraphEndpoint 'https://graph.ppe.windows.net/'
}
if (-not (Has-Environment $next))
{
  Add-AzureRmEnvironment -Name $next `
    -PublishSettingsFileUrl 'https://auxnext.windows.azure-test.net/publishsettings/index' `
    -ServiceEndpoint 'https://managementnext.rdfetest.dnsdemo4.com/' `
    -ManagementPortalUrl 'https://auxnext.windows.azure-test.net/' `
    -ActiveDirectoryEndpoint 'https://login.windows-ppe.net/' `
    -ActiveDirectoryServiceEndpointResourceId 'https://management.core.windows.net/' `
    -ResourceManagerEndpoint 'https://api-next.resources.windows-int.net/' `
    -GalleryEndpoint 'https://next.gallery.azure-test.net/' `
    -GraphEndpoint 'https://graph.ppe.windows.net/'
}
#####################