# optional target testname
param ($TargetTestName)

# override test data file folder path for tests in the backcompat directory
$testFilesFolder = (Join-Path $PSScriptRoot '..' 'ScenarioTests')

# override the recording file path for tests in the backcompat directory
$TestRecordingFile = Join-Path $PSScriptRoot "$($TargetTestName).Recording.json"

# load the comment test framework functions
. (Join-Path $PSScriptRoot '..' 'Common.ps1') -TargetTestName $TargetTestName

# load legacy assertion library
. (Join-Path $PSScriptRoot 'TestFxCommon.ps1')
. (Join-Path $PSScriptRoot 'TestFxAssert.ps1')
