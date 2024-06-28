function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}

function Get-SubscriptionId {
    $script = Resolve-Path "$PSScriptRoot/../utils/Get-SubscriptionIdTestSafe.ps1"
    return . $script
}

<#
.SYNOPSIS
Create a name of the requested length that is the same across multiple runs of the same test,
but [most likely] unique within the test and across all other tests.
#>
$symbolTable = @{}
function Get-RandomName
{
    param([string] $Prefix='ps', $MaxLength=64)

    $i = 0
    while ($true) {
        $symbol = $prefix + $TargetTestName + '{0:D2}' -f ++$i
        if ($symbol.Length -gt $MaxLength) {
            $symbol = ($prefix + ('{0:D2}' -f $i) + (Get-MD5Hash -text $TargetTestName -maxlength 6) + $TargetTestName).Substring(0, $MaxLength)
        }

        if (!$symbolTable[$symbol]) {
            $symbolTable[$symbol] = $true
            break;
        }
    }

    return $symbol
}

<#
.SYNOPSIS
Creates a resource name
#>
function Get-ResourceName
{
    param ([int]$MaxLength = 64)

    return Get-RandomName -MaxLength $MaxLength
}

<#
.SYNOPSIS
Creates a resource group name
#>
function Get-ResourceGroupName
{
    return Get-RandomName -Prefix 'rg'
}

<#
.SYNOPSIS
Hashes the given string using MD5 then truncates to the given maximum length
#>
function Get-MD5Hash([string]$text, [int]$maxLength = 32)
{
    $hasher = New-Object 'System.Security.Cryptography.MD5CryptoServiceProvider'
    $toHash = [System.Text.Encoding]::UTF8.GetBytes($text)
    $hashedBytes = $hasher.ComputeHash($toHash)

    foreach ($byte in $hashedBytes) {
        $result += "{0:X2}" -f $byte
        if ($result.Length -ge $maxLength) {
            break;
        }
    }

    return $result.Substring(0, $maxLength);
}

<#
.SYNOPSIS
Creates a new resource group with the given name in the given location and waits until it is provisioned.
#>
function New-ResourceGroup
{
    [CmdletBinding()]
    param(
        [Parameter(Mandatory, ValueFromPipelineByPropertyName)]
        [Alias('ResourceGroupName')]
        [string] $Name,

        [Parameter(Mandatory, ValueFromPipelineByPropertyName)]
        [string]$Location
    )

    begin {
        $subscriptionId = Get-SubscriptionId
        $uri = "https://management.azure.com/subscriptions/$subscriptionId/resourceGroups"

        if ($Name) {
            $uri += "/$Name"
        }

        $uri += "?api-version=2023-07-01"
        #Write-Host -ForegroundColor Yellow "Uri: [$uri]"
    }

    process {
        $response = Invoke-AzRestMethod -Uri $uri -Method PUT -Payload "{ ""location"": ""$Location"" }"
        if ($response.StatusCode -eq 201 -or ($response.StatusCode -eq 200)) {
            $result = Get-ResourceGroup -Name $Name
            while ($result.ProvisioningState -ne 'Succeeded' -and $result.ProvisioningState -ne 'Failed' -and $result.ProvisioningState -ne 'Canceled') {
                Start-Sleep -Seconds 1
                $result = Get-ResourceGroup -Name $Name
            }

            return $result
        }
        else {
            throw ($response.Content | ConvertFrom-Json -Depth 100).error.message
        }
    }
}

<#
.SYNOPSIS
Returns the existing resource group with the given name ($null if it doesn't exist)
#>
function Get-ResourceGroup
{
    [CmdletBinding()]
    param(
        [Parameter(ValueFromPipelineByPropertyName)]
        [Alias('ResourceGroupName')]
        $Name
    )

    begin {
        $subscriptionId = Get-SubscriptionId
        $uri = "https://management.azure.com/subscriptions/$subscriptionId/resourceGroups"

        if ($Name) {
            $uri += "/$Name"
        }

        $uri += "?api-version=2023-07-01"
    }

    process {
        $response = Invoke-AzRestMethod -Uri $uri -Method GET
        if ($response.StatusCode -eq 200) {
            if ($Name) {
                $result = $response.Content | ConvertFrom-Json -Depth 100
                return New-Object -TypeName 'PSObject' -Property @{
                    ResourceGroupName = $result.name;
                    Location = $result.location;
                    ProvisioningState = $result.properties.provisioningstate;
                    Tags = if ($result.tags) { $result.tags } else { $null }
                    ResourceId = $result.id
                }
            }
            else {
                $list = ($response.Content | ConvertFrom-Json -Depth 100).value
                foreach ($item in $list) {
                    $result = New-Object -TypeName 'PSObject' -Property @{
                        ResourceGroupName = $item.name;
                        Location = $item.location;
                        ProvisioningState = $item.properties.provisioningstate;
                        Tags = if ($item.tags) { $item.tags } else { $null }
                        ResourceId = $item.id
                    }
                    Write-Output $result
                }
            }
        }
        else {
            return $null
        }
    }
}

<#
.SYNOPSIS
Deletes the existing resource group with the given name and waits for it to be removed
#>
function Remove-ResourceGroup
{
    [CmdletBinding()]
    param(
        [Parameter(Mandatory, ValueFromPipelineByPropertyName)]
        [Alias('ResourceGroupName')]
        $Name
    )

    begin {
        $subscriptionId = Get-SubscriptionId
        $base = "https://management.azure.com/subscriptions/$subscriptionId/resourceGroups"
        $names = @()
    }

    process {
        $uri = $base
        if ($Name) {
            $uri += "/$Name"
        }

        $uri += "?api-version=2023-07-01"
        #Write-Host -ForegroundColor Yellow "Uri: [$uri]"

        $response = Invoke-AzRestMethod -Uri $uri -Method DELETE
        if (($response.StatusCode -eq 202) -or ($response.StatusCode -eq 200)) {
            $names += $Name
        }
        elseif ($response.StatusCode -eq 404) {
            Write-Output $true
        }
        else {
            $message = "Status: $($response.StatusCode): " + ($response.Content | ConvertFrom-Json -Depth 100).error.message
            throw $message
        }
    }

    end {
        foreach ($n in $names) {
            $tries = 0
            $result = Get-ResourceGroup -Name $n
            if ($result -and ($result.ProvisioningState -ne 'Deleting')) {
                throw "Delete operation for resource group [$n] failed to start (provisioningState is [$result.ProvisioningState]"
            }

            while ($result -and ($result.ProvisioningState -eq 'Deleting') -and (++$tries -le 500)) {
                Start-Sleep -Seconds 1
                $result = Get-ResourceGroup -Name $n
            }

            if ($result) {
                throw "Delete operation for resource group [$n] failed to complete within 500 seconds"
            }

            Write-Output ($null -eq $result)
        }
    }
}

$env = @{}
if ($UsePreviousConfigForRecord) {
    $previousEnv = Get-Content (Join-Path $PSScriptRoot 'env.json') | ConvertFrom-Json
    $previousEnv.psobject.properties | Foreach-Object { $env[$_.Name] = $_.Value }
}
# Add script method called AddWithCache to $env, when useCache is set true, it will try to get the value from the $env first.
# example: $val = $env.AddWithCache('key', $val, $true)
$env | Add-Member -Type ScriptMethod -Value { param( [string]$key, [object]$val, [bool]$useCache) if ($this.Contains($key) -and $useCache) { return $this[$key] } else { $this[$key] = $val; return $val } } -Name 'AddWithCache'
function setupEnv() {
    Write-Host -ForegroundColor Magenta "Setting up globals"
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = Get-SubscriptionId
    $env.Tenant = (Get-AzContext).Tenant.Id
    # For any resources you created for test, you should add it to $env here.

    # ----------------------------------------------------+
    # set up common variables used in policy legacy tests |
    # ----------------------------------------------------+
    $env['rgName'] = Get-ResourceGroupName
    $rg = New-ResourceGroup -Name $env.rgName -Location "west us"
    $env['rgScope'] = $rg.ResourceId
    $env['location'] = $rg.Location

    $env['userAssignedIdentityName'] = "test-user-msi"
    $userAssignedIdentity = New-AzUserAssignedIdentity -ResourceGroupName $env.rgName -Name $env.userAssignedIdentityName -Location $env.location
    $env['userAssignedIdentityId'] = $userAssignedIdentity.Id

    $env['managementGroup'] = 'AzGovPerfTest'
    $env['managementGroupScope'] = '/providers/Microsoft.Management/managementGroups/AzGovPerfTest'
    $env['description'] = 'Unit test junk: sorry for littering. Please delete me!'
    $env['updatedDescription'] = "Updated $description"
    $env['metadataName'] = 'testName'
    $env['metadataValue'] = 'testValue'
    $env['metadata'] = "{'$($env.metadataName)':'$($env.metadataValue)'}"
    $env['enforcementModeDefault'] = 'Default'
    $env['enforcementModeDoNotEnforce'] = 'DoNotEnforce'

    $env['updatedMetadataName'] = 'newTestName'
    $env['updatedMetadataValue'] = 'newTestValue'
    $env['updatedMetadata'] = "{'$($env.metadataName)':'$($env.metadataValue)', '$($env.updatedMetadataName)': '$($env.updatedMetadataValue)'}"

    $env['parameterDisplayName'] = 'List of locations'
    $env['parameterDescription'] = 'An array of permitted locations for resources.'
    $env['parameterDefinition'] = "{ 'listOfAllowedLocations': { 'type': 'array', 'metadata': { 'description': '$($env.parameterDescription)', 'strongType': 'location', 'displayName': '$($env.parameterDisplayName)' } } }"
    $env['fullParameterDefinition'] = "{ 'listOfAllowedLocations': { 'type': 'array', 'metadata': { 'description': '$($env.parameterDescription)', 'strongType': 'location', 'displayName': '$($env.parameterDisplayName)' } }, 'effectParam': { 'type': 'string', 'defaultValue': 'deny' } }"

    # values used by parameter combination tests
    $env['someName'] = 'someName'
    $env['someScope'] = 'someScope'
    $env['someId'] = 'someId'
    $env['someIdentityId'] = 'someIdentityId'
    $env['someManagementGroup'] = 'someManagementGroup'
    $env['someJsonSnippet'] = "{ 'someThing': 'someOtherThing' }"
    $env['someJsonArray'] = "[$($env.someJsonSnippet)]"
    $env['somePolicyDefinition'] = 'somePolicyDefinition'
    $env['somePolicySetDefinition'] = 'somePolicySetDefinition'
    $env['somePolicyParameter'] = 'somePolicyParameter'
    $env['someParameterObject'] = "{'parm1': 'a', 'parm2': 'b' }"
    $env['someDisplayName'] = 'Some display name'

    # exception strings
    $env['parameterSetError'] = 'Parameter set cannot be resolved using the specified named parameters.'
    $env['parameterNullError'] = '. The argument is null. Provide a valid value for the argument, and then try running the command again.'
    $env['missingParameters'] = 'Cannot process command because of one or more missing mandatory parameters:'
    $env['missingAnArgument'] = 'Missing an argument for parameter '
    $env['onlyManagementGroupOrSubscription'] = 'Only ManagementGroupName or SubscriptionId can be provided, not both.'
    $env['onlyDefinitionOrSetDefinition'] = 'Only one of -PolicyDefinition or -PolicySetDefinition can be specified, not both.'
    $env['policyAssignmentNotFound'] = '[PolicyAssignmentNotFound] : '
    $env['policySetDefinitionNotFound'] = '[PolicySetDefinitionNotFound] : '
    $env['policyDefinitionNotFound'] = '[PolicyDefinitionNotFound] : '
    $env['policyAssignmentMissingLocation']  = 'Location needs to be specified if a managed identity is to be assigned to the policy assignment.'
    $env['policyAssignmentMissingIdentityId']  = 'A user assigned identity id needs to be specified if the identity type is ''UserAssigned''.'
    $env['policyExemptionNotFound'] = '[PolicyExemptionNotFound] : '
    $env['invalidRequestContent'] = '[InvalidRequestContent] : The request content was invalid and could not be deserialized: '
    $env['policyDefinitionParameter'] = 'One of PolicyDefinition or PolicySetDefinition must be provided.'
    $env['missingSubscription'] = '[MissingSubscription] : The request did not have a subscription or a valid tenant level resource provider.'
    $env['undefinedPolicyParameter'] = '[UndefinedPolicyParameter] : The policy assignment'
    $env['invalidPolicyRule'] = '[InvalidPolicyRule] : Failed to parse policy rule: '
    $env['authorizationFailed'] = '[AuthorizationFailed] : '
    $env['allSwitchNotSupported'] = 'The IncludeDescendent switch is not supported for management group scopes.'
    $env['httpMethodNotSupported'] = "HttpMethodNotSupported : The http method 'DELETE' is not supported for a resource collection."
    $env['nonInteractiveMode'] = 'PowerShell is in NonInteractive mode. Read and Prompt functionality is not available.'
    $env['parameterNullOrEmpty'] = '. The argument is null or empty. Provide an argument that is not null or empty, and then try the command again.'
    $env['invalidParameterValue'] = 'Cannot validate argument on parameter'
    $env['invalidPolicyDefinitionReference'] = 'InvalidPolicyDefinitionReference'
    $env['invalidPolicySetDefinitionRequest'] = "[InvalidCreatePolicySetDefinitionRequest] : The policy set definition 'someName' create request is invalid. At least one policy definition must be referenced."
    $env['multiplePolicyDefinitionParams'] = "Cannot bind parameter because parameter 'PolicyDefinition' is specified more than once"
    $env['versionRequiresNameOrId'] = 'Version is only allowed if Name or Id  are provided.'
    $env['listVersionsRequiresNameOrId'] = 'ListVersions is only allowed if Name or Id  are provided.'

    # create a couple of test objects
    $env['customSubDefName'] = Get-ResourceName
    $env['customSubDefinition'] = New-AzPolicyDefinition -Name $env.customSubDefName -Policy '{ "if": { "field": "location", "equals": "westus" }, "then": { "effect": "audit" } }'
    $env['customSubSetDefName'] = Get-ResourceName
    $env['customSubSetDefinition'] = New-AzPolicySetDefinition -Name $env.customSubSetDefName -PolicyDefinition ("[{""policyDefinitionId"":""" + $($env.customSubDefinition).Id + """}]")
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }

    Write-Host -ForegroundColor Magenta Writing environment file $envFile with $env.Count entries
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env -Depth 100)
}
function cleanupEnv() {

    Write-Host -ForegroundColor Magenta "Cleaning up globals"
    # Clean resources you create for testing
    $null = Remove-AzPolicySetDefinition -Name $env.customSubSetDefName -Confirm:$false
    $null = Remove-AzPolicyDefinition -Name $env.customSubDefName -Confirm:$false
    $null = Remove-AzUserAssignedIdentity -ResourceGroupName $env.rgName -Name $env.userAssignedIdentityName
    $null = Remove-ResourceGroup -Name $env.rgName
    Write-Host -ForegroundColor Magenta "Finished cleaning up globals"
}