function Set-AzureStackEnvironment
{
    [CmdletBinding(DefaultParameterSetName="WindowsAuth")]
    param
    (
        [Parameter(Mandatory=$true)]
        [String] $AzureStackMachineName,

        [Parameter(Mandatory=$true)]
        [String] $ArmEndpoint,

        [Parameter(Mandatory=$true)]
        [String] $GalleryEndpoint,

        [Parameter(Mandatory=$false, ParameterSetName="WindowsAuth")]
        [String] $WindowsAuthEndpoint,

        [Parameter(Mandatory=$true, ParameterSetName="AadEnvironment")]
        [String] $AadTenantId,

        [Parameter(Mandatory=$true, ParameterSetName="AadEnvironment")]
        [String] $AadApplicationId,

        [Parameter(Mandatory=$false, ParameterSetName="AadEnvironment")]
        [String] $AadGraphUri  = "https://graph.windows.net/",

        [Parameter(Mandatory=$false, ParameterSetName="AadEnvironment")]
        [String] $AadLoginUri  = "https://login.windows.net/"

    )

    ValidateUri -Uri $ArmEndpoint
    ValidateUri -Uri $GalleryEndpoint
    ValidateUri -Uri $AadGraphUri
    ValidateUri -Uri $AadLoginUri

    if (-not $WindowsAuthEndpoint)
    {
        $WindowsAuthEndpoint = "https://{0}:12998" -f $AzureStackMachineName
    }

    $isAad = $PSCmdlet.ParameterSetName -eq "AadEnvironment"
    $azStackPowershellGuid = "0a7bdc5c-7b57-40be-9939-d4c5fc7cd417"
    $adminSubscription = Get-AzureRmSubscription -SubscriptionName "Default Provider Subscription" 
    $adminSubscriptionId = $adminSubscription.SubscriptionId
    Set-AzureRmContext -SubscriptionId $adminSubscriptionId
    $location =  "redmond"

    $global:AzureStackConfig = [PSCustomObject]@{
                    AzureStackMachineName = $AzureStackMachineName
                    ApiVersion = "1.0"
                    ArmLocation = $location
                    Token = $token
                    SubscriptionId = $adminSubscriptionId
                    AdminUri = $ArmEndpoint
                    IsAad = $isAad
                    AadTenantId = $AadTenantId
                    AzStackPsAadAppGuid = $azStackPowershellGuid
                    AadApplicationId = $AadApplicationId
                    AadLoginUri = $AadLoginUri
                    WindowsAuthEndpoint = $WindowsAuthEndpoint
                 }

    Write-Verbose "Environment Context set for $AzureStackMachineName"
}

function ValidateUri
{
    param
    (
        [Parameter(Mandatory=$true)]
        [String] $Uri
    )

    if (($uri -as [System.URI]) -eq $null)
    {
        throw "$uri is not a valid URI"
    }

    if (-not $uri.EndsWith("/"))
    {
        throw "$uri does not ends with /"
    }
}

function Get-EnvironmentSpecificToken
{
    param
    (
        [Parameter(Mandatory=$true)]
        [PSCredential] $Credential
    )

    if ($Global:AzureStackConfig.IsAAD)
    {
        $authEndPoint="$($Global:AzureStackConfig.AadLoginUri)$($Global:AzureStackConfig.AadTenantId)/oauth2"
        return Get-AzureStackToken -Authority $authEndPoint -AadTenantId $Global:AzureStackConfig.AadTenantId -Resource $Global:AzureStackConfig.AadApplicationId -ClientId $Global:AzureStackConfig.AzStackPsAadAppGuid -Credential $Credential -Verbose
    }

    return Get-AzureStackToken -Authority $Global:AzureStackConfig.WindowsAuthEndpoint -Credential $Credential -ErrorAction Stop
}

function Set-AzureStackWithAadEnvironment
{
    param
    (
        [Parameter(Mandatory=$true)]
        [String] $AzureStackMachineName,

        [Parameter(Mandatory=$true)]
        [String] $ArmEndpoint,

        [Parameter(Mandatory=$true)]
        [String] $GalleryEndpoint,

        [Parameter(Mandatory=$false)]
        [String] $AadGraphUri,

        [Parameter(Mandatory=$true)]
        [String] $AadLoginUri,

        [Parameter(Mandatory=$true)]
        [String] $AadTenantId,

        [Parameter(Mandatory=$true)]
        [String] $AadApplicationId,

        [Parameter(Mandatory=$true)]
        [PSCredential] $Credential
    )

    $Global:ErrorActionPreference='SilentlyContinue'
    Remove-AzureRmEnvironment -Name $AzureStackMachineName -Force -ErrorAction SilentlyContinue
    $Global:ErrorActionPreference='Stop'

    Add-AzureRmEnvironment -Name $AzureStackMachineName `
        -ActiveDirectoryEndpoint ("$AadLoginUri$AadTenantId/") `
        -ActiveDirectoryServiceEndpointResourceId $AadApplicationId `
        -ResourceManagerEndpoint ($ArmEndpoint) `
        -GalleryEndpoint ($GalleryEndpoint) `
        -GraphEndpoint $AadGraphUri

    $environment = Get-AzureRmEnvironment -Name $AzureStackMachineName
    Login-AzureRmAccount -Environment $environment -Credential $Credential

    Get-AzureRmSubscription -SubscriptionName "Default Provider Subscription" | Set-AzureRmContext
}

function Get-DefaultLocation
{
    param
    (
        [Parameter(Mandatory=$true)]
        [String] $AdminUri,

        [Parameter(Mandatory=$true)]
        [String] $SubscriptionId,

        [Parameter(Mandatory=$true)]
        [String] $Token
    )

    # TODO: always returning the first region, change if needed
    if ($Global:AzureStackConfig.IsAAD)
    {
        $locations = Get-AzureRMManagedLocation -SubscriptionId $SubscriptionId -ApiVersion "1.0"
    }
    else
    {
        $locations = Get-AzureRMManagedLocation -SubscriptionId $SubscriptionId -Token $Token -AdminUri $AdminUri -ApiVersion "1.0"
    }
    return $locations[0].Name
}
