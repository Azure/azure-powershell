# optional target testname
param ($TargetTestName)

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
        $subscriptionId = (Get-AzContext).Subscription.Id
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
        $subscriptionId = (Get-AzContext).Subscription.Id
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
        $subscriptionId = (Get-AzContext).Subscription.Id
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
            throw ($response.Content | ConvertFrom-Json -Depth 100).error.message
        }
    }

    end {
        foreach ($n in $names) {
            $tries = 0
            $result = Get-ResourceGroup -Name $n
            if ($result -and ($result.ProvisioningState -ne 'Deleting')) {
                throw 'Delete operation for resource group $n failed to start'
            }

            while ($result -and ($result.ProvisioningState -eq 'Deleting') -and (++$tries -le 500)) {
                Start-Sleep -Seconds 1
                $result = Get-ResourceGroup -Name $n
            }

            if ($result) {
                throw 'Delete operation for resource group $n failed to complete within 500 seconds'
            }

            Write-Output ($null -eq $result)
        }
    }
}

Write-Host -ForegroundColor DarkGreen "Loading Current.ps1 with TestName=[$($TestName)] and TargetTestName=[$($TargetTestName)]"

# The below initialization is only peformed following these rules:
#   if $TargetTestName is provided, we will set up the test environment for that named test if
#      the current test ($TestName) matches the named target test or
#      there is no current test, which means all tests are being performed
#   if $TargetTestName is not provided, we only load the functions and don't set up the environment
if ($TargetTestName -and (!$TestName -or ($TestName -eq $TargetTestName))) {
    try {
        # -----------------------------------------------+
        # setup ceremony for autorest Pester environment |
        # -----------------------------------------------+
        Write-Host -ForegroundColor Magenta "Setting up environment for [$($TargetTestName)]"
        $currentDir = Get-Item $PSScriptRoot

        # dot-source load the environment file
        $loadEnvPath = Join-Path $currentDir 'loadEnv.ps1'
        if (-Not (Test-Path -Path $loadEnvPath)) {
            $loadEnvPath = Join-Path $currentDir.Parent 'loadEnv.ps1'
        }

        # load tenant and subscription the test will run under
        . ($loadEnvPath)

        # set up the recording file path
        $TestRecordingFile = Join-Path $currentDir "$($TargetTestName).Recording.json"

        # find and dot-source load the mocking code
        $currentPath = $currentDir
        while(-not $mockingPath) {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = $currentPath.Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName

        # ----------------------------------------------------+
        # set up common variables used in policy legacy tests |
        # ----------------------------------------------------+
        $managementGroup = 'AzGovPerfTest'
        $managementGroupScope = '/providers/Microsoft.Management/managementGroups/AzGovPerfTest'
        $description = 'Unit test junk: sorry for littering. Please delete me!'
        $updatedDescription = "Updated $description"
        $metadataName = 'testName'
        $metadataValue = 'testValue'
        $metadata = "{'$metadataName':'$metadataValue'}"
        $enforcementModeDefault = 'Default'
        $enforcementModeDoNotEnforce = 'DoNotEnforce'

        $updatedMetadataName = 'newTestName'
        $updatedMetadataValue = 'newTestValue'
        $updatedMetadata = "{'$metadataName':'$metadataValue', '$updatedMetadataName': '$updatedMetadataValue'}"

        $parameterDisplayName = 'List of locations'
        $parameterDescription = 'An array of permitted locations for resources.'
        $parameterDefinition = "{ 'listOfAllowedLocations': { 'type': 'array', 'metadata': { 'description': '$parameterDescription', 'strongType': 'location', 'displayName': '$parameterDisplayName' } } }"
        $fullParameterDefinition = "{ 'listOfAllowedLocations': { 'type': 'array', 'metadata': { 'description': '$parameterDescription', 'strongType': 'location', 'displayName': '$parameterDisplayName' } }, 'effectParam': { 'type': 'string', 'defaultValue': 'deny' } }"

        # values used by parameter combination tests
        $someName = 'someName'
        $someScope = 'someScope'
        $someId = 'someId'
        $someIdentityId = 'someIdentityId'
        $someManagementGroup = 'someManagementGroup'
        $someJsonSnippet = "{ 'someThing': 'someOtherThing' }"
        $someJsonArray = "[$someJsonSnippet]"
        $somePolicyDefinition = 'somePolicyDefinition'
        $somePolicySetDefinition = 'somePolicySetDefinition'
        $somePolicyParameter = 'somePolicyParameter'
        $someParameterObject = @{'parm1'='a'; 'parm2'='b' }
        $someDisplayName = "Some display name"

        # exception strings
        $parameterSetError = 'Parameter set cannot be resolved using the specified named parameters.'
        $parameterNullError = '. The argument is null. Provide a valid value for the argument, and then try running the command again.'
        $missingParameters = 'Cannot process command because of one or more missing mandatory parameters:'
        $missingAnArgument = 'Missing an argument for parameter '
        $onlyManagementGroupOrSubscription = 'Only -ManagementGroupName or -SubscriptionId can be provided, not both.'
        $onlyDefinitionOrSetDefinition = 'Only one of -PolicyDefinition or -PolicySetDefinition can be specified, not both.'
        $policyAssignmentNotFound = '[PolicyAssignmentNotFound] : '
        $policySetDefinitionNotFound = '[PolicySetDefinitionNotFound] : '
        $policyDefinitionNotFound = '[PolicyDefinitionNotFound] : '
        $policyAssignmentMissingLocation  = 'Location needs to be specified if a managed identity is to be assigned to the policy assignment.'
        $policyAssignmentMissingIdentityId  = 'A user assigned identity id needs to be specified if the identity type is ''UserAssigned''.'
        $policyExemptionNotFound = '[PolicyExemptionNotFound] : '
        $invalidRequestContent = '[InvalidRequestContent] : The request content was invalid and could not be deserialized: '
        $policyDefinitionParameter = 'One of -PolicyDefinition or -PolicySetDefinition must be provided.'
        $missingSubscription = '[MissingSubscription] : The request did not have a subscription or a valid tenant level resource provider.'
        $undefinedPolicyParameter = '[UndefinedPolicyParameter] : The policy assignment'
        $invalidPolicyRule = '[InvalidPolicyRule] : Failed to parse policy rule: '
        $authorizationFailed = '[AuthorizationFailed] : '
        $allSwitchNotSupported = 'The -IncludeDescendent switch is not supported for management group scopes.'
        $httpMethodNotSupported = "HttpMethodNotSupported : The http method 'DELETE' is not supported for a resource collection."
        $nonInteractiveMode = 'PowerShell is in NonInteractive mode. Read and Prompt functionality is not available.'
        $parameterNullOrEmpty = '. The argument is null or empty. Provide an argument that is not null or empty, and then try the command again.'
        $invalidParameterValue = 'Cannot validate argument on parameter'
        $invalidPolicyDefinitionReference = 'InvalidPolicyDefinitionReference'
        $invalidPolicySetDefinitionRequest = "[InvalidCreatePolicySetDefinitionRequest] : The policy set definition 'someName' create request is invalid. At least one policy definition must be referenced."
        $testFilesFolder = "$PSScriptRoot\ScenarioTests"
        $subscriptionId = $subscriptionId = $env.SubscriptionId
    }
    catch {
        Write-Host -ForegroundColor Red "Failed setting up environment for [$TargetTestName]: [$_]"
        throw
    }
}
