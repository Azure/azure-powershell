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
#####################