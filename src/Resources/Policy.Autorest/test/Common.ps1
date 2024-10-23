# optional target testname
param ($TargetTestName)

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

        # set up test data file folder path
        if (!$testFilesFolder) {
            $testFilesFolder = (Join-Path $PSScriptRoot 'ScenarioTests')
        }

        # set up the recording file path
        if (!$TestRecordingFile) {
            $TestRecordingFile = Join-Path $currentDir "$($TargetTestName).Recording.json"
        }

        # find and dot-source load the mocking code
        $currentPath = $currentDir
        while(-not $mockingPath) {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = $currentPath.Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName

        # ----------------------------------------------------------+
        # populate the variables used commonly across all the tests |
        # ----------------------------------------------------------+
        $subscriptionId = $env.SubscriptionId
        $managementGroup = $env.managementGroup
        $managementGroupScope = $env.managementGroupScope
        $description = $env.description
        $updatedDescription = $env.updatedDescription
        $metadataName = $env.metadataName
        $metadataValue = $env.metadataValue
        $metadata = $env.metadata | ConvertFrom-Json -Depth 100
        $enforcementModeDefault = $env.enforcementModeDefault
        $enforcementModeDoNotEnforce = $env.enforcementModeDoNotEnforce

        $updatedMetadataName = $env.updatedMetadataName
        $updatedMetadataValue = $env.updatedMetadataValue
        $updatedMetadata = $env.updatedMetadata | ConvertFrom-Json -Depth 100

        $parameterDisplayName = $env.parameterDisplayName
        $parameterDescription = $env.parameterDescription
        $parameterDefinition = $env.parameterDefinition
        $fullParameterDefinition = $env.fullParameterDefinition

        # values used by parameter combination tests
        $someName = $env.someName
        $someScope = $env.someScope
        $someId = $env.someId
        $someIdentityId = $env.someIdentityId
        $someManagementGroup = $env.someManagementGroup
        $someJsonSnippet = $env.someJsonSnippet
        $someJsonArray = $env.someJsonArray
        $somePolicyDefinition = $env.somePolicyDefinition
        $somePolicySetDefinition = $env.somePolicySetDefinition
        $somePolicyParameter = $env.somePolicyParameter
        $someParameterObject = $env.someParameterObject | ConvertFrom-Json -Depth 100 -AsHashtable
        $someDisplayName = $env.someDisplayName

        # exception strings
        $parameterSetError = $env.parameterSetError
        $parameterNullError = $env.parameterNullError
        $missingParameters = $env.missingParameters
        $missingAnArgument = $env.missingAnArgument
        $onlyManagementGroupOrSubscription = $env.onlyManagementGroupOrSubscription
        $policyAssignmentNotFound = $env.policyAssignmentNotFound
        $policySetDefinitionNotFound = $env.policySetDefinitionNotFound
        $policyDefinitionNotFound = $env.policyDefinitionNotFound
        $policyAssignmentMissingLocation = $env.policyAssignmentMissingLocation
        $policyAssignmentMissingIdentityId = $env.policyAssignmentMissingIdentityId
        $policyExemptionNotFound = $env.policyExemptionNotFound
        $invalidRequestContent = $env.invalidRequestContent
        $policyDefinitionParameter = $env.policyDefinitionParameter
        $missingSubscription = $env.missingSubscription
        $undefinedPolicyParameter = $env.undefinedPolicyParameter
        $invalidPolicyRule = $env.invalidPolicyRule
        $authorizationFailed = $env.authorizationFailed
        $allSwitchNotSupported = $env.allSwitchNotSupported
        $httpMethodNotSupported = $env.httpMethodNotSupported
        $nonInteractiveMode = $env.nonInteractiveMode
        $parameterNullOrEmpty = $env.parameterNullOrEmpty
        $invalidParameterValue = $env.invalidParameterValue
        $invalidPolicyDefinitionReference = $env.invalidPolicyDefinitionReference
        $invalidPolicySetDefinitionRequest = $env.invalidPolicySetDefinitionRequest
        $multiplePolicyDefinitionParams = $env.multiplePolicyDefinitionParams
        $versionRequiresNameOrId = $env.versionRequiresNameOrId
        $listVersionsRequiresNameOrId = $env.listVersionsRequiresNameOrId
        $disallowedByPolicy = $env.disallowedByPolicy
    }
    catch {
        Write-Host -ForegroundColor Red "Failed setting up environment for [$TargetTestName]: [$_]"
        throw
    }
}
