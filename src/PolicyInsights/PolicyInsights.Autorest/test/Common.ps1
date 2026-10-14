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
            $testFilesFolder = (Join-Path $PSScriptRoot 'TestSetupFiles')
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

    }
    catch {
        Write-Host -ForegroundColor Red "Failed setting up environment for [$TargetTestName]: [$_]"
        throw
    }
}