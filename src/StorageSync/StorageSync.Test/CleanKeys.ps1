# Define the directory and file pattern
$directory = "."
$filePattern = "*Test*.json"

# Define a regex pattern to match the specific pattern for Storage Account keys ending with ==
$pattern = '\\\"value\\\":\s\\\"(?<SAKey>[a-zA-Z0-9+/=]{86}==)\\\",'
# Iterate over all files in the directory matching the pattern
Get-ChildItem -Path $directory -Filter $filePattern -Recurse | ForEach-Object {
	# Initialize a hash set to store unique matched keys
	$storageAccountKeys = [System.Collections.Generic.HashSet[string]]::new()

    $fileContent = Get-Content -Path $_.FullName -Raw
    Write-Output $_.FullName
    # Find all matches in the file content
    $matches = [regex]::Matches($fileContent, $pattern)

    $shouldContinue = $false 
    # Extract and store the keys
    foreach ($match in $matches) {
        $storageAccountKeys.Add($match.Groups["SAKey"].Value) | Out-Null
		$shouldContinue = $true		
    }
	# Print each unique matched key
	foreach ($key in $storageAccountKeys) {
    Write-Output $key
	}
	if($shouldContinue)
	{
		# Replace all matches in the file content with *REDACTED*
		$modifiedContent = [regex]::Replace($fileContent, $pattern, '\"value\": \"*REDACTED*\",')

		# Save the modified content back to the file
		Set-Content -Path $_.FullName -Value $modifiedContent -Force
	}
}

# Print a message indicating completion
Write-Output "All keys have been replaced with *REDACTED* in the specified files."

