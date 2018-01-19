Write-Output "JobId:$($PsPrivateMetaData.JobId.Guid)"
$VerbosePreference = 'Continue'
LoginWithConnection %LOGIN-PARAMS%

%TEST-LIST%
TestRunner $testList %LOGIN-PARAMS%

Write-Verbose 'Resolve-AzureRmError Information'
Write-Verbose '--------------------------------'
Resolve-AzureRmError | Out-String | Write-Verbose