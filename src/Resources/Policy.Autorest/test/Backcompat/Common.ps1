# optional target testname
param ($TargetTestName)

<#
.SYNOPSIS
Gets valid resource group name
#>
function Get-ResourceGroupName
{
    return getAssetName
}

#>
function New-ResourceGroup($Name, $Location, [switch]$Force)
{
    Az.Resources\New-AzResourceGroup -Name $name -Location $Location -Force:$Force
}

function Get-ResourceGroup($Name, $Location)
{
    Az.Resources\Get-AzResourceGroup @PSBoundParameters
}

function Remove-ResourceGroup($Name, $Location, [switch]$Force)
{
    Az.Resources\Remove-AzResourceGroup @PSBoundParameters
}

<#
.SYNOPSIS
Gets valid resource name
#>
function Get-ResourceName
{
    return getAssetName
}

Write-Host -ForegroundColor DarkGreen "Loading current.ps1 with TestName=[$($TestName)] and TargetTestName=[$($TargetTestName)]"

# The below initialization is only peformed following these rules:
#   if $TargetTestName is provided, we will set up the test environment for that named test if
#      the current test ($TestName) matces the named target test or
#      there is no current test, which means all tests are being performed
#   if $TargetTestName is not provided, we only load the functions and don't set up the environment
if ($TargetTestName -and (!$TestName -or ($TestName -eq $TargetTestName))) {
    try {
        # -----------------------------------------------+
        # setup ceremony for autorest Pester environment |
        # -----------------------------------------------+
        Write-Host -ForegroundColor Magenta "Setting up environment for [$TargetTestName]"
        $currentDir = Get-Item $PSScriptRoot

        # dot-source load the environment file
        $loadEnvPath = Join-Path $currentDir 'loadEnv.ps1'
        if (-Not (Test-Path -Path $loadEnvPath)) {
            $loadEnvPath = Join-Path $currentDir.Parent 'loadEnv.ps1'
        }
# this breaks the test environment, had to remove it
#        . ($loadEnvPath)

        # set up the recording file path
        $TestRecordingFile = Join-Path $currentDir "$($TargetTestName).Recording.json"

        # find and dot-source load the mocking code
        $currentPath = $currentDir
        while(-not $mockingPath) {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = $currentPath.Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName

        # load the comment test framework functions
        . (Join-Path $PSScriptRoot 'TestFxCommon.ps1')
        . (Join-Path $PSScriptRoot 'TestFxAssert.ps1')

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
        $onlyDefinitionOrSetDefinition = 'Only one of PolicyDefinition or PolicySetDefinition can be specified, not both.'
        $policyAssignmentNotFound = '[PolicyAssignmentNotFound] : '
        $policySetDefinitionNotFound = '[PolicySetDefinitionNotFound] : '
        $policyDefinitionNotFound = '[PolicyDefinitionNotFound] : '
        $policyAssignmentMissingLocation  = 'Location needs to be specified if a managed identity is to be assigned to the policy assignment.'
        $policyAssignmentMissingIdentityId  = 'A user assigned identity id needs to be specified if the identity type is ''UserAssigned''.'
        $policyExemptionNotFound = '[PolicyExemptionNotFound] : '
        $invalidRequestContent = '[InvalidRequestContent] : The request content was invalid and could not be deserialized: '
        $policyDefinitionParameter = "PolicyDefinition or PolicySetDefinition must be provided."
        $missingSubscription = '[MissingSubscription] : The request did not have a subscription or a valid tenant level resource provider.'
        $undefinedPolicyParameter = '[UndefinedPolicyParameter] : The policy assignment'
        $invalidPolicyRule = '[InvalidPolicyRule] : Failed to parse policy rule: '
        $authorizationFailed = '[AuthorizationFailed] : '
        $allSwitchNotSupported = 'The -IncludeDescendent switch is not supported for management group scopes.'
        $httpMethodNotSupported = "HttpMethodNotSupported : The http method 'DELETE' is not supported for a resource collection."
        $parameterNullOrEmpty = '. The argument is null or empty. Provide an argument that is not null or empty, and then try the command again.'
        $invalidParameterValue = 'Cannot validate argument on parameter'
        $invalidPolicyDefinitionReference = 'InvalidPolicyDefinitionReference'
        $invalidPolicySetDefinitionRequest = "[InvalidCreatePolicySetDefinitionRequest] : The policy set definition 'someName' create request is invalid. At least one policy definition must be referenced."
        $testFilesFolder = "$PSScriptRoot\..\ScenarioTests"
        $subscriptionId = $subscriptionId = (Get-AzContext).Subscription.Id
    }
    catch {
        Write-Host -ForegroundColor Red "Failed setting up environment for [$TargetTestName]: [$_]"
        throw
    }
}
