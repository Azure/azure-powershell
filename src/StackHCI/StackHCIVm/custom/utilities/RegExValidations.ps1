$vnetRegex = "(?i)^/?subscriptions/(?<subscriptionId>[0-9a-f]{8}-([0-9a-f]{4}-){3}[0-9a-f]{12})/resourceGroups/(?<resourceGroupName>[-\w\._\(\)]{1,90})/providers/Microsoft.AzureStackHCI/virtualnetworks/(?<virtualNetworkName>[a-zA-Z0-9][-._a-zA-Z0-9]{0,62}[_a-zA-Z0-9])$"
$galImageRegex = "(?i)^/?subscriptions/(?<subscriptionId>[0-9a-f]{8}-([0-9a-f]{4}-){3}[0-9a-f]{12})/resourceGroups/(?<resourceGroupName>[-\w\._\(\)]{1,90})/providers/Microsoft.AzureStackHCI/galleryimages/(?<imageName>[a-zA-Z0-9][-._a-zA-Z0-9]{0,78}[a-zA-Z0-9])$"
$marketplaceGalImageRegex = "(?i)^/?subscriptions/(?<subscriptionId>[0-9a-f]{8}-([0-9a-f]{4}-){3}[0-9a-f]{12})/resourceGroups/(?<resourceGroupName>[-\w\._\(\)]{1,90})/providers/Microsoft.AzureStackHCI/marketplacegalleryimages/(?<imageName>[a-zA-Z0-9][-._a-zA-Z0-9]{0,78}[a-zA-Z0-9])$"
$vhdRegex = "(?i)^/?subscriptions/(?<subscriptionId>[0-9a-f]{8}-([0-9a-f]{4}-){3}[0-9a-f]{12})/resourceGroups/(?<resourceGroupName>[-\w\._\(\)]{1,90})/providers/Microsoft.AzureStackHCI/virtualharddisks/(?<vhdName>[-_a-zA-Z0-9]{1,80})$"
$nicRegex = "(?i)^/?subscriptions/(?<subscriptionId>[0-9a-f]{8}-([0-9a-f]{4}-){3}[0-9a-f]{12})/resourceGroups/(?<resourceGroupName>[-\w\._\(\)]{1,90})/providers/Microsoft.AzureStackHCI/networkinterfaces/(?<nicName>[a-zA-Z0-9][-._a-zA-Z0-9]{0,78}[_a-zA-Z0-9])$"
$vmRegex =  "(?i)^/?subscriptions/(?<subscriptionId>[0-9a-f]{8}-([0-9a-f]{4}-){3}[0-9a-f]{12})/resourceGroups/(?<resourceGroupName>[-\w\._\(\)]{1,90})/providers/Microsoft.AzureStackHCI/virtualmachines/(?<vmName>[a-zA-Z0-9][-._a-zA-Z0-9]{0,62}[a-zA-Z0-9])$"
$storagePathRegex = "(?i)^/?subscriptions/(?<subscriptionId>[0-9a-f]{8}-([0-9a-f]{4}-){3}[0-9a-f]{12})/resourceGroups/(?<resourceGroupName>[-\w\._\(\)]{1,90})/providers/Microsoft.AzureStackHCI/storagecontainers/(?<storagePathName>[a-zA-Z0-9][-._a-zA-Z0-9]{0,78}[_a-zA-Z0-9])$"
$customLocationRegex =  "(?i)^/?subscriptions/(?<subscriptionId>[0-9a-f]{8}-([0-9a-f]{4}-){3}[0-9a-f]{12})/resourceGroups/(?<resourceGroupName>[-\w\._\(\)]{1,90})/providers/Microsoft.ExtendedLocation/customLocations/(?<customLocation>[a-zA-Z0-9][-_a-zA-Z0-9]{0,61}[a-zA-Z0-9])$"

$imageNameRegex = "^[a-zA-Z0-9]$|^[a-zA-Z0-9][-._a-zA-Z0-9]{0,78}[a-zA-Z0-9]$"
$nicNameRegex = "^[a-zA-Z0-9]$|^[a-zA-Z0-9][-._a-zA-Z0-9]{0,78}[_a-zA-Z0-9]$"
$storagePathNameRegex = "^[a-zA-Z0-9]$|^[a-zA-Z0-9][-._a-zA-Z0-9]{0,78}[_a-zA-Z0-9]$"
$vhdNameRegex = "^[-_a-zA-Z0-9]{1,80}$"
$vmNameRegex =  "^[a-zA-Z0-9]$|^[a-zA-Z0-9][-._a-zA-Z0-9]{0,62}[a-zA-Z0-9]$"
$vnetNameRegex = "^[a-zA-Z0-9]$|^[a-zA-Z0-9][-._a-zA-Z0-9]{0,62}[_a-zA-Z0-9]$"
$subnetNameRegex = "^[a-zA-Z0-9]$|^[a-zA-Z0-9][-._a-zA-Z0-9]{0,78}[_a-zA-Z0-9]$"

$ipv4Regex = "^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$"
$cidrRegex = "^([0-9]{1,3}\.){3}[0-9]{1,3}\/\b(([0-9]|[1-2][0-9]|3[0-2]))?$"
$macAddressRegex = "^([0-9A-Fa-f]{2}[:-]){5}([0-9A-Fa-f]{2})|([0-9a-fA-F]{4}\\.[0-9a-fA-F]{4}\\.[0-9a-fA-F]{4})$"

$allDigitsRegex = "^[0-9]$"
$invalidCharactersComputerName =  "[`~!@#$%^&*()=+_\[\]\{\}\\|;:.'`"<>/?]"


$urnRegex = "(?i)^(?<publisher>[-._a-zA-Z0-9]+):(?<offer>[-._a-zA-Z0-9]+):(?<sku>[-._a-zA-Z0-9]+):(?<version>[-._a-zA-Z0-9]+)$"
