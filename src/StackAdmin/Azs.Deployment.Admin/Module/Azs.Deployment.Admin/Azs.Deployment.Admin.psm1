#-----------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
#-----------------------------------------------------------------------

# This module contains PowerShell commands providing an access to Deployment Provider functions.

<#
.SYNOPSIS
    Retrieves Resource Manager access token.
#>
function Get-AzsResourceManagerAccessToken {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)]
        [object] $context
    )

    $profile = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureRmProfileProvider]::Instance.Profile

    $profileClient = [Microsoft.Azure.Commands.ResourceManager.Common.RMProfileClient]::new($profile)

    $token = $profileClient.AcquireAccessToken($context.Subscription.TenantId)

    return $token.AccessToken
}

<#
.SYNOPSIS
    Send a request to Azure Stack Resource Manager.
#>
function Invoke-AzsResourceManager {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)]
        [ValidateSet('GET', 'PUT', 'POST', 'DELETE', 'HEAD', 'OPTIONS', 'TRACE')]
        [string] $Method,

        [Parameter(Mandatory = $true)]
        [ValidateNotNull()]
        [Uri] $Uri,

        [Parameter(Mandatory = $false)]
        [object] $Body = $null,

        [Parameter(Mandatory = $false)]
        [string] $AccessToken = "",

        [Parameter(Mandatory = $false)]
        [switch] $ThrowOnError
    )

    function Resolve-RequestUri {
        param (
            [string] $resourceManagerUrl,
            [Uri] $uri
        )

        if ($uri.IsAbsoluteUri) {
            return $uri
        }

        return [uri]::new([uri]::new($resourceManagerUrl), $Uri)
    }

    function Resolve-RequestContent {
        param (
            [object] $body
        )

        if ($null -eq $body) {
            return [NullString]::Value
        }

        if ($body -is [string]) {
            return $Body.ToString()
        }

        return ($body | ConvertTo-Json -Depth 99 -Compress)
    }

    function Resolve-AccessToken {
        param(
            [object] $context,
            [string] $accessToken
        )

        if (-not [string]::IsNullOrEmpty($accessToken)) {
            return $accessToken
        }

        return Get-AzsResourceManagerAccessToken -Context $context
    }

    function Get-HeaderValue {
        param (
            [System.Net.Http.Headers.HttpHeaders] $headers,
            [string] $name
        )

        [System.Collections.Generic.IEnumerable[string]] $values = $null

        if (-not $headers.TryGetValues($name, [ref] $values)) {
            return [NullString]::Value
        }

        return [System.Linq.Enumerable]::FirstOrDefault($values)
    }

    function Trace-HttpRequestMessage {
        param (
            [System.Net.Http.HttpRequestMessage] $request,
            [string] $content
        )

        Write-Verbose "$($request.Method) $($request.RequestUri) with $($content.Length)-char payload" -Verbose

        $sb = [System.Text.StringBuilder]::new()
        $sb.AppendLine("$($request.Method) $($request.RequestUri) HTTP/$($request.Version)") | Out-Null

        DumpHttpMessageHeaders $sb $request.Headers

        if (-not [string]::IsNullOrEmpty($content)) {
            $sb.AppendLine() | Out-Null
            $sb.Append($content) | Out-Null
        }

        Write-Debug $sb.ToString()
    }

    function Trace-HttpResponseMessage {
        param (
            [System.Net.Http.HttpResponseMessage] $response,
            [string] $content
        )

        Write-Verbose "Received $($content.Length)-char response, StatusCode = $($response.StatusCode)" -Verbose

        $sb = [System.Text.StringBuilder]::new()
        $sb.AppendLine("HTTP/$($response.Version) $([int]$response.StatusCode) $($response.ReasonPhrase)") | Out-Null

        DumpHttpMessageHeaders -Sb $sb -Headers $response.Headers

        if (-not [string]::IsNullOrEmpty($content)) {
            $sb.AppendLine() | Out-Null
            $sb.Append($content) | Out-Null
        }

        Write-Debug $sb.ToString()
    }

    function DumpHttpMessageHeaders {
        param (
            [System.Text.StringBuilder] $sb,
            [System.Net.Http.Headers.HttpHeaders] $headers
        )

        if ($null -ne $headers) {
            foreach ($header in $headers) {
                $sb.Append($header.Key) | Out-Null
                $sb.Append(": ") | Out-Null

                if ($header.Key -eq 'Authorization') {
                    $sb.AppendLine('HIDDEN') | Out-Null
                }
                else {
                    $sb.AppendLine($header.Value -join " ") | Out-Null
                }
            }
        }
    }

    #-----------------------------------------------------------------------

    $ctx = Get-AzureRmContext

    if ($null -eq $ctx.Environment) {
        throw 'AzureRm Context is not set.'
    }

    $Uri = Resolve-RequestUri -ResourceManagerUrl $ctx.Environment.ResourceManagerUrl -Uri $Uri

    [string] $requestContent = Resolve-RequestContent -Body $Body

    $AccessToken = Resolve-AccessToken -Context $ctx -AccessToken $AccessToken

    [System.Net.Http.HttpRequestMessage] $request = $null
    [System.Net.Http.HttpResponseMessage] $response = $null

    try {
        $request = [System.Net.Http.HttpRequestMessage]::new()
        $request.Method = [System.Net.Http.HttpMethod]::new($Method)
        $request.RequestUri = $Uri
        $request.Headers.Authorization = [System.Net.Http.Headers.AuthenticationHeaderValue]::new('Bearer', $AccessToken)

        if ($null -ne $requestContent) {
            $request.Content = [System.Net.Http.StringContent]::new($requestContent, [System.Text.Encoding]::UTF8, 'application/json')
        }

        Trace-HttpRequestMessage -Request $request -Content $requestContent

        $task = $HttpClient.SendAsync($request, [System.Net.Http.HttpCompletionOption]::ResponseContentRead)
        $response = $task.Result

        $task = $response.Content.ReadAsStringAsync()
        [string] $responseContent = $task.Result

        if ([string]::IsNullOrEmpty($responseContent)) {
            $responseContent = [NullString]::Value
        }

        Trace-HttpResponseMessage -Response $response -Content $responseContent

        $result = [psobject]::new()
        $result | Add-Member -MemberType NoteProperty -Name 'StatusCode' -Value $response.StatusCode
        $result | Add-Member -MemberType NoteProperty -Name 'AsyncOperationStatusUri' -Value (Get-HeaderValue -Headers $response.Headers -Name 'Azure-AsyncOperation')
        $result | Add-Member -MemberType NoteProperty -Name 'LocationUri' -Value (Get-HeaderValue -Headers $response.Headers -Name 'Location')
        $result | Add-Member -MemberType NoteProperty -Name 'Content' -Value $responseContent

        if ($ThrowOnError) {
            EnsureSuccessStatusCode -Response $result
        }

        return $result
    }
    catch [System.AggregateException] {
        throw $_.Exception.InnerException.Message
    }
    finally {
        if ($null -ne $request) {
            $request.Dispose()
        }

        if ($null -ne $response) {
            $response.Dispose()
        }
    }
}

<#
.SYNOPSIS
    Waits for Azure Stack Resource Manager asynchronous operation to complete (Azure-AsyncOperation header style).

.NOTES
    Track asynchronous Azure operations
    https://docs.microsoft.com/en-us/azure/azure-resource-manager/resource-manager-async-operations
#>
function Wait-AzsAsyncOperation {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)]
        [string] $OperationName,

        [Parameter(Mandatory = $true)]
        [ValidateNotNull()]
        [Uri] $AsyncOperationStatusUri,

        [Parameter(Mandatory = $false)]
        [string] $AccessToken = ""
    )

    Write-Verbose "${OperationName}: Wait for asynchronous operation to complete." -Verbose

    $stopwatch = [System.Diagnostics.Stopwatch]::StartNew()

    while ($true) {
        $response = Invoke-AzsResourceManager -Method GET -Uri $AsyncOperationStatusUri -AccessToken $AccessToken -Verbose

        EnsureSuccessStatusCode -Response $response

        $operationResult = $response.Content | ConvertFrom-Json

        if (IsOperationResultTerminalState $operationResult.status) {
            if ($operationResult.status -eq 'Succeeded') {
                return $true
            }

            return $false
        }

        Write-Verbose "${OperationName}: Sleeping for 5 seconds, waiting time: $($stopwatch.Elapsed)"

        Start-Sleep -Seconds 5
    }
}

function EnsureSuccessStatusCode {
    param(
        [Parameter(Mandatory = $true)]
        [psobject] $Response
    )

    if (-not (IsSuccessStatusCode -StatusCode $Response.StatusCode)) {
        Write-Verbose "HTTP error: $($Response.StatusCode)" -Verbose
        Write-Verbose $Response.Content -Verbose

        throw "HTTP error: $($Response.StatusCode)"
    }
}

function IsOperationResultTerminalState {
    param (
        [Parameter(Mandatory = $true)]
        [string] $Value
    )

    return $Value -in @('Canceled', 'Failed', 'Succeeded')
}

function IsSuccessStatusCode {
    param(
        [Parameter(Mandatory = $true)]
        [System.Net.HttpStatusCode] $StatusCode
    )

    return [int]$StatusCode -ge 200 -and [int]$StatusCode -le 299
}

#-----------------------------------------------------------------------

<#
.SYNOPSIS
    Lists file containers or gets a file container properties.
#>
function Get-AzsFileContainer {
    [CmdletBinding()]
    param(
        [Parameter()]
        [ValidateNotNullOrEmpty()]
        [string] $FileContainerId = $null,

        [Parameter()]
        [ValidateSet('2019-01-01', '2018-07-01')]
        [string] $ApiVersion = '2019-01-01',

        [Parameter()]
        [switch] $AsJson
    )

    $subscriptionId = (Get-AzureRmContext).Subscription.Id

    if ([string]::IsNullOrEmpty($FileContainerId)) {
        $requestUri = "/subscriptions/$subscriptionId/providers/Microsoft.Deployment.Admin/locations/global/fileContainers?api-version=$ApiVersion"
    }
    else {
        $requestUri = "/subscriptions/$subscriptionId/providers/Microsoft.Deployment.Admin/locations/global/fileContainers/$($FileContainerId)?api-version=$ApiVersion"
    }

    $response = Invoke-AzsResourceManager -Method GET -Uri $requestUri -Verbose

    if ($response.StatusCode -eq [System.Net.HttpStatusCode]::NotFound) {
        return $null
    }

    EnsureSuccessStatusCode -Response $response

    if ($AsJson) {
        return $response.Content | ConvertFrom-Json | ConvertTo-Json -Depth 99
    }

    return $response.Content | ConvertFrom-Json
}

<#
.SYNOPSIS
    Creates a new file container.
#>
function New-AzsFileContainer {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)]
        [string] $FileContainerId,

        [Parameter(Mandatory = $true)]
        [Uri] $SourceUri,

        [Parameter()]
        [ValidateSet('None', 'Unzip')]
        [string] $PostCopyAction = 'None',

        [Parameter()]
        [ValidateSet('2019-01-01', '2018-07-01')]
        [string] $ApiVersion = '2019-01-01'
    )

    Write-Verbose "Create a new file container, fileContainerId = '$FileContainerId', sourceUri = '$SourceUri', postCopyAction = '$PostCopyAction'." -Verbose

    $subscriptionId = (Get-AzureRmContext).Subscription.Id
    $requestUri = "/subscriptions/$subscriptionId/providers/Microsoft.Deployment.Admin/locations/global/fileContainers/$($FileContainerId)?api-version=$ApiVersion"

    $body = @{
        properties = @{
            sourceUri      = $SourceUri
            postCopyAction = $PostCopyAction
        }
    }

    $response = Invoke-AzsResourceManager -Method PUT -Uri $requestUri -Body $body -ThrowOnError -Verbose

    if (-not [string]::IsNullOrEmpty($response.AsyncOperationStatusUri)) {
        if (-not (Wait-AzsAsyncOperation -OperationName 'New-AzsFileContainer' -AsyncOperationStatusUri $response.AsyncOperationStatusUri -Verbose)) {
            throw 'Unable to create file container.'
        }
    }
}

<#
.SYNOPSIS
    Removes an existing file container.
#>
function Remove-AzsFileContainer {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)]
        [string] $FileContainerId,

        [Parameter()]
        [ValidateSet('2019-01-01', '2018-07-01')]
        [string] $ApiVersion = '2019-01-01'
    )

    Write-Verbose "Remove the file container, fileContainerId = '$FileContainerId'." -Verbose

    $subscriptionId = (Get-AzureRmContext).Subscription.Id
    $requestUri = "/subscriptions/$subscriptionId/providers/Microsoft.Deployment.Admin/locations/global/fileContainers/$($FileContainerId)?api-version=$ApiVersion"

    Invoke-AzsResourceManager -Method DELETE -Uri $requestUri -ThrowOnError -Verbose | Out-Null
}

# Product Packages

<#
.SYNOPSIS
    Lists product packages or gets a product package properties.
#>
function Get-AzsProductPackage {
    [CmdletBinding()]
    param(
        [Parameter()]
        [ValidateNotNullOrEmpty()]
        [string] $PackageId = $null,

        [Parameter()]
        [ValidateSet('2019-01-01', '2018-07-01')]
        [string] $ApiVersion = '2019-01-01',

        [Parameter()]
        [switch] $AsJson
    )

    $subscriptionId = (Get-AzureRmContext).Subscription.Id

    if ([string]::IsNullOrEmpty($PackageId)) {
        $requestUri = "/subscriptions/$subscriptionId/providers/Microsoft.Deployment.Admin/locations/global/productPackages?api-version=$ApiVersion"
    }
    else {
        $requestUri = "/subscriptions/$subscriptionId/providers/Microsoft.Deployment.Admin/locations/global/productPackages/$($PackageId)?api-version=$ApiVersion"
    }

    $response = Invoke-AzsResourceManager -Method GET -Uri $requestUri -Verbose

    if ($response.StatusCode -eq [System.Net.HttpStatusCode]::NotFound) {
        return $null
    }

    EnsureSuccessStatusCode -Response $response

    if ($AsJson) {
        return $response.Content | ConvertFrom-Json | ConvertTo-Json -Depth 99
    }

    return $response.Content | ConvertFrom-Json
}

<#
.SYNOPSIS
    Create a new product package.
#>
function New-AzsProductPackage {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)]
        [string] $PackageId,

        [Parameter(Mandatory = $true)]
        [string] $FileContainerId,

        [Parameter()]
        [ValidateSet('2019-01-01', '2018-07-01')]
        [string] $ApiVersion = '2019-01-01'
    )

    Write-Verbose "Create a new product package, packageId = '$PackageId', fileContainerId = '$FileContainerId'." -Verbose

    $subscriptionId = (Get-AzureRmContext).Subscription.Id
    $requestUri = "/subscriptions/$subscriptionId/providers/Microsoft.Deployment.Admin/locations/global/productPackages/$($PackageId)?api-version=$ApiVersion"

    if ($ApiVersion -eq '2019-01-01') {
        $body = @{
            properties = @{
                fileContainerId = $FileContainerId
            }
        }
    }
    else {
        $body = @{
            properties = @{
                productManifestId = $FileContainerId
            }
        }
    }

    $response = Invoke-AzsResourceManager -Method PUT -Uri $requestUri -Body $body -ThrowOnError -Verbose

    if (-not [string]::IsNullOrEmpty($response.AsyncOperationStatusUri)) {
        if (-not (Wait-AzsAsyncOperation -OperationName 'New-AzsProductPackage' -AsyncOperationStatusUri $response.AsyncOperationStatusUri -Verbose)) {
            throw 'Unable to create product package.'
        }
    }
}

<#
.SYNOPSIS
    Removes an existing product package.
#>
function Remove-AzsProductPackage {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)]
        [string] $PackageId,

        [Parameter()]
        [ValidateSet('2019-01-01', '2018-07-01')]
        [string] $ApiVersion = '2019-01-01'
    )

    Write-Verbose "Remove the product package, packageId = '$PackageId'." -Verbose

    $subscriptionId = (Get-AzureRmContext).Subscription.Id
    $requestUri = "/subscriptions/$subscriptionId/providers/Microsoft.Deployment.Admin/locations/global/productPackages/$($PackageId)?api-version=$ApiVersion"

    Invoke-AzsResourceManager -Method DELETE -Uri $requestUri -ThrowOnError -Verbose | Out-Null
}

#-----------------------------------------------------------------------

<#
.SYNOPSIS
    Lists product deployments or gets a product deployment properties.
#>
function Get-AzsProductDeployment {
    [CmdletBinding()]
    param(
        [Parameter()]
        [ValidateNotNullOrEmpty()]
        [string] $ProductId = $null,

        [Parameter()]
        [switch] $AsJson
    )

    $subscriptionId = (Get-AzureRmContext).Subscription.Id

    if ([string]::IsNullOrEmpty($ProductId)) {
        $requestUri = "/subscriptions/$subscriptionId/providers/Microsoft.Deployment.Admin/locations/global/productDeployments?api-version=2019-01-01"
    }
    else {
        $requestUri = "/subscriptions/$subscriptionId/providers/Microsoft.Deployment.Admin/locations/global/productDeployments/$($ProductId)?api-version=2019-01-01"
    }

    $response = Invoke-AzsResourceManager -Method GET -Uri $requestUri -Verbose

    if ($response.StatusCode -eq [System.Net.HttpStatusCode]::NotFound) {
        return $null
    }

    EnsureSuccessStatusCode -Response $response

    if ($AsJson) {
        return $response.Content | ConvertFrom-Json | ConvertTo-Json -Depth 99
    }

    return $response.Content | ConvertFrom-Json
}

<#
.SYNOPSIS
    Invokes 'bootstrap product' action.
#>
function Invoke-AzsProductBootstrapAction {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)]
        [string] $ProductId,

        [Parameter(Mandatory = $true)]
        [string] $Version
    )

    $subscriptionId = (Get-AzureRmContext).Subscription.Id
    $requestUri = "/subscriptions/$subscriptionId/providers/Microsoft.Deployment.Admin/locations/global/productDeployments/$ProductId/bootstrap?api-version=2019-01-01"

    $body = @{
        version = $Version
    }

    $response = Invoke-AzsResourceManager -Method POST -Uri $requestUri -Body $body -ThrowOnError -Verbose

    if (-not (Wait-AzsAsyncOperation -OperationName 'Invoke-AzsProductBootstrapAction' -AsyncOperationStatusUri $response.AsyncOperationStatusUri -Verbose)) {
        throw "Unable to complete bootstrap operation."
    }
}

<#
.SYNOPSIS
    Invokes 'deploy product' action.
#>
function Invoke-AzsProductDeployAction {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)]
        [string] $ProductId,

        [Parameter(Mandatory = $true)]
        [string] $Version,

        [Parameter(Mandatory = $true)]
        [psobject] $Parameters
    )

    $subscriptionId = (Get-AzureRmContext).Subscription.Id
    $requestUri = "/subscriptions/$subscriptionId/providers/Microsoft.Deployment.Admin/locations/global/productDeployments/$ProductId/deploy?api-version=2019-01-01"

    $body = @{
        version    = $Version
        parameters = $Parameters
    }

    $response = Invoke-AzsResourceManager -Method POST -Uri $requestUri -Body $body -ThrowOnError -Verbose

    if (-not (Wait-AzsAsyncOperation -OperationName 'Invoke-AzsProductDeployAction' -AsyncOperationStatusUri $response.AsyncOperationStatusUri -Verbose)) {
        throw "Unable to complete deploy operation."
    }
}

<#
.SYNOPSIS
    Invokes 'execute runner' action.
#>
function Invoke-AzsProductExecuteRunnerAction {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)]
        [string] $ProductId,

        [Parameter(Mandatory = $true)]
        [psobject] $Parameters
    )

    $subscriptionId = (Get-AzureRmContext).Subscription.Id
    $requestUri = "/subscriptions/$subscriptionId/providers/Microsoft.Deployment.Admin/locations/global/productDeployments/$ProductId/executeRunner?api-version=2019-01-01"

    $body = $parameters

    $response = Invoke-AzsResourceManager -Method POST -Uri $requestUri -Body $body -ThrowOnError -Verbose

    if (-not [string]::IsNullOrEmpty($response.AsyncOperationStatusUri)) {
        if (-not (Wait-AzsAsyncOperation -OperationName 'Invoke-AzsProductExecuteRunnerAction' -AsyncOperationStatusUri $response.AsyncOperationStatusUri -Verbose)) {
            throw "Unable to complete execute runner operation."
        }
    }
}

<#
.SYNOPSIS
    Invokes 'remove product' action.
#>
function Invoke-AzsProductRemoveAction {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)]
        [string] $ProductId
    )

    $subscriptionId = (Get-AzureRmContext).Subscription.Id
    $requestUri = "/subscriptions/$subscriptionId/providers/Microsoft.Deployment.Admin/locations/global/productDeployments/$ProductId/remove?api-version=2019-01-01"

    $response = Invoke-AzsResourceManager -Method POST -Uri $requestUri -ThrowOnError -Verbose

    if (-not [string]::IsNullOrEmpty($response.AsyncOperationStatusUri)) {
        if (-not (Wait-AzsAsyncOperation -OperationName 'Invoke-AzsProductRemoveAction' -AsyncOperationStatusUri $response.AsyncOperationStatusUri -Verbose)) {
            throw "Unable to complete remove operation."
        }
    }
}

<#
.SYNOPSIS
    Invokes 'rotate secrets' action.
#>
function Invoke-AzsProductRotateSecretsAction {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)]
        [string] $ProductId
    )

    $subscriptionId = (Get-AzureRmContext).Subscription.Id
    $requestUri = "/subscriptions/$subscriptionId/providers/Microsoft.Deployment.Admin/locations/global/productDeployments/$ProductId/rotateSecrets?api-version=2019-01-01"

    $response = Invoke-AzsResourceManager -Method POST -Uri $requestUri -ThrowOnError -Verbose

    if (-not [string]::IsNullOrEmpty($response.AsyncOperationStatusUri)) {
        if (-not (Wait-AzsAsyncOperation -OperationName 'Invoke-AzsProductRotateSecretsAction' -AsyncOperationStatusUri $response.AsyncOperationStatusUri -Verbose)) {
            throw "Unable to complete rotate secrets operation."
        }
    }
}

<#
.SYNOPSIS
    Unlock the product subscription.
#>
function Unlock-AzsProductSubscription {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)]
        [string] $ProductId,

        [Parameter()]
        [timespan] $Duration = [timespan]::Zero
    )

    $subscriptionId = (Get-AzureRmContext).Subscription.Id
    $requestUri = "/subscriptions/$subscriptionId/providers/Microsoft.Deployment.Admin/locations/global/productDeployments/$ProductId/unlock?api-version=2019-01-01"

    if ($Duration -eq [timespan]::Zero) {
        $Duration = [timespan]::FromDays(7)
    }

    $body = @{
        duration = [System.Xml.XmlConvert]::ToString($Duration)
    }

    Invoke-AzsResourceManager -Method POST -Uri $requestUri -Body $body -ThrowOnError -Verbose | Out-Null
}

<#
.SYNOPSIS
    Locks the product subscription.
#>
function Lock-AzsProductSubscription {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)]
        [string] $ProductId
    )

    $subscriptionId = (Get-AzureRmContext).Subscription.Id
    $requestUri = "/subscriptions/$subscriptionId/providers/Microsoft.Deployment.Admin/locations/global/productDeployments/$ProductId/lock?api-version=2019-01-01"

    Invoke-AzsResourceManager -Method POST -Uri $requestUri -Body $body -ThrowOnError -Verbose | Out-Null
}

#-----------------------------------------------------------------------

<#
.SYNOPSIS
    Lists product secrets or gets a product secret properties.
#>
function Get-AzsProductSecret {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)]
        [string] $PackageId,

        [Parameter()]
        [ValidateNotNullOrEmpty()]
        [string] $SecretName = $null,

        [Parameter()]
        [switch] $AsJson
    )

    $subscriptionId = (Get-AzureRmContext).Subscription.Id

    if ([string]::IsNullOrEmpty($SecretName)) {
        $requestUri = "/subscriptions/$subscriptionId/providers/Microsoft.Deployment.Admin/locations/global/productPackages/$($PackageId)/secrets?api-version=2019-01-01"
    }
    else {
        $requestUri = "/subscriptions/$subscriptionId/providers/Microsoft.Deployment.Admin/locations/global/productPackages/$($PackageId)/secrets/$($SecretName)?api-version=2019-01-01"
    }

    $response = Invoke-AzsResourceManager -Method GET -Uri $requestUri -Verbose

    if ($response.StatusCode -eq [System.Net.HttpStatusCode]::NotFound) {
        return $null
    }

    EnsureSuccessStatusCode -Response $response

    if ($AsJson) {
        return $response.Content | ConvertFrom-Json | ConvertTo-Json -Depth 99
    }

    return $response.Content | ConvertFrom-Json
}

<#
.SYNOPSIS
    Sets product secret value.
#>
function Set-AzsProductSecret {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)]
        [string] $PackageId,

        [Parameter(Mandatory = $true)]
        [string] $SecretName,

        [Parameter(Mandatory = $true, ParameterSetName = 'AdHoc')]
        [securestring] $Value,

        [Parameter(Mandatory = $true, ParameterSetName = 'Certificate')]
        [string] $PfxFileName,

        [Parameter(Mandatory = $true, ParameterSetName = 'Certificate')]
        [securestring] $PfxPassword,

        [Parameter(Mandatory = $true, ParameterSetName = 'Password')]
        [securestring] $Password,

        [Parameter(Mandatory = $true, ParameterSetName = 'SymmetricKey')]
        [securestring] $Key,

        [Parameter()]
        [switch] $Force
    )

    function ConvertFrom-SecureString {
        param(
            [Parameter(Mandatory = $true)]
            [securestring] $Value
        )

        return [System.Net.NetworkCredential]::new('', $Value).Password
    }

    if ($PSCmdlet.ParameterSetName -eq 'AdHoc') {
        $body = @{
            value = (ConvertFrom-SecureString -Value $Value)
        }
    }
    elseif ($PSCmdlet.ParameterSetName -eq 'Certificate') {
        $body = @{
            data     = [System.Convert]::ToBase64String((Get-Content $PfxFileName -Encoding Byte))
            password = (ConvertFrom-SecureString -Value $PfxPassword)
        }
    }
    elseif ($PSCmdlet.ParameterSetName -eq 'Password') {
        $body = @{
            password = (ConvertFrom-SecureString -Value $Password)
        }
    }
    elseif ($PSCmdlet.ParameterSetName -eq 'SymmetricKey') {
        $body = @{
            key = (ConvertFrom-SecureString -Value $Key)
        }
    }

    if ($Force.ToBool()) {
        Write-Verbose 'Importing secret...' -Verbose
        $action = 'import'
    }
    else {
        Write-Verbose 'Validating secret...' -Verbose
        $action = 'validate'
    }

    $subscriptionId = (Get-AzureRmContext).Subscription.Id
    $requestUri = "/subscriptions/$subscriptionId/providers/Microsoft.Deployment.Admin/locations/global/productPackages/$PackageId/secrets/$SecretName/$($action)?api-version=2019-01-01"

    Invoke-AzsResourceManager -Method POST -Uri $requestUri -Body $body -ThrowOnError -Verbose | Out-Null
}

#-----------------------------------------------------------------------

<#
.SYNOPSIS
#>
function Get-AzsActionPlan {
    [CmdletBinding()]
    param(
        [Parameter()]
        [ValidateNotNullOrEmpty()]
        [string] $PlanId = $null,

        [Parameter()]
        [switch] $AsJson
    )

    $subscriptionId = (Get-AzureRmContext).Subscription.Id

    if ([string]::IsNullOrEmpty($PlanId)) {
        $requestUri = "/subscriptions/$subscriptionId/providers/Microsoft.Deployment.Admin/locations/global/actionplans?api-version=2019-01-01"
    }
    else {
        $requestUri = "/subscriptions/$subscriptionId/providers/Microsoft.Deployment.Admin/locations/global/actionplans/$($PlanId)?api-version=2019-01-01"
    }

    $response = Invoke-AzsResourceManager -Method GET -Uri $requestUri -ThrowOnError -Verbose

    if ($AsJson) {
        return $response.Content | ConvertFrom-Json | ConvertTo-Json -Depth 99
    }

    return $response.Content | ConvertFrom-Json
}

<#
.SYNOPSIS
#>
function Get-AzsActionPlanOperation {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)]
        [string] $PlanId,

        [Parameter()]
        [ValidateNotNullOrEmpty()]
        [string] $OperationId = $null,

        [Parameter()]
        [switch] $AsJson
    )

    $subscriptionId = (Get-AzureRmContext).Subscription.Id

    if ([string]::IsNullOrEmpty($OperationId)) {
        $requestUri = "/subscriptions/$subscriptionId/providers/Microsoft.Deployment.Admin/locations/global/actionplans/$PlanId/operations?api-version=2019-01-01"
    }
    else {
        $requestUri = "/subscriptions/$subscriptionId/providers/Microsoft.Deployment.Admin/locations/global/actionplans/$PlanId/operations/$($OperationId)?api-version=2019-01-01"
    }

    $response = Invoke-AzsResourceManager -Method GET -Uri $requestUri -ThrowOnError -Verbose

    if ($AsJson) {
        return $response.Content | ConvertFrom-Json | ConvertTo-Json -Depth 99
    }

    return $response.Content | ConvertFrom-Json
}

<#
.SYNOPSIS
#>
function Get-AzsActionPlanAttempt {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)]
        [string] $PlanId,

        [Parameter(Mandatory = $true)]
        [string] $OperationId,

        [Parameter()]
        [int] $AttemptNo,

        [Parameter()]
        [switch] $AsJson
    )

    $subscriptionId = (Get-AzureRmContext).Subscription.Id

    if ($AttemptNo -eq 0) {
        $requestUri = "/subscriptions/$subscriptionId/providers/Microsoft.Deployment.Admin/locations/global/actionplans/$PlanId/operations/$OperationId/attempts?api-version=2019-01-01"
    }
    else {
        $requestUri = "/subscriptions/$subscriptionId/providers/Microsoft.Deployment.Admin/locations/global/actionplans/$PlanId/operations/$OperationId/attempts/$($AttemptNo)?api-version=2019-01-01"
    }

    $response = Invoke-AzsResourceManager -Method GET -Uri $requestUri -ThrowOnError -Verbose

    if ($AsJson) {
        return $response.Content | ConvertFrom-Json | ConvertTo-Json -Depth 99
    }

    return $response.Content | ConvertFrom-Json
}

#-----------------------------------------------------------------------

$ErrorActionPreference = 'Stop'

[System.Reflection.Assembly]::LoadWithPartialName('System.Net.Http') | Out-Null
[System.Net.Http.HttpClient] $HttpClient = [System.Net.Http.HttpClient]::new()

$functions = @(
    'Get-AzsResourceManagerAccessToken'
    'Invoke-AzsResourceManager'
    'Wait-AzsAsyncOperation'
    'Get-AzsFileContainer'
    'New-AzsFileContainer'
    'Remove-AzsFileContainer'
    'Get-AzsProductPackage'
    'New-AzsProductPackage'
    'Remove-AzsProductPackage'
    'Get-AzsProductDeployment'
    'Invoke-AzsProductBootstrapAction'
    'Invoke-AzsProductDeployAction'
    'Invoke-AzsProductExecuteRunnerAction'
    'Invoke-AzsProductRemoveAction'
    'Invoke-AzsProductRotateSecretsAction'
    'Unlock-AzsProductSubscription'
    'Lock-AzsProductSubscription'
    'Get-AzsProductSecret'
    'Set-AzsProductSecret'
    'Get-AzsActionPlan'
    'Get-AzsActionPlanOperation'
    'Get-AzsActionPlanAttempt'
)
Export-ModuleMember -Function $functions
