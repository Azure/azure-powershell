# Script to preprocess REST API spec files
# 1. Remove all "x-ms-examples" sections from paths and x-ms-paths
# 2. Replace references to common-types/resource-management/v3/types.json and common-types/v1/common.json

Get-ChildItem -Path . -Filter *.json -Recurse | ForEach-Object {
    $filePath = $_.FullName
    Write-Host "Processing $filePath"
    
    # First read the file as text to perform string replacements for $ref paths
    $content = Get-Content $filePath -Raw
    
    # Replace references to types.json
    $content = $content -replace '"\$ref"\s*:\s*"../../../../../../common-types/resource-management/v3/types.json', '"$ref": "./types.json'
    
    # Replace references to common.json
    $content = $content -replace '"\$ref"\s*:\s*"../../../common-types/v1/common.json', '"$ref": "./common.json'
    
    # Convert to JSON for structured manipulation
    $json = $content | ConvertFrom-Json
    
    # Remove x-ms-examples sections from paths
    if ($json.paths) {
        foreach ($pathKey in $json.paths.PSObject.Properties.Name) {
            $pathObj = $json.paths.$pathKey
            foreach ($methodKey in $pathObj.PSObject.Properties.Name) {
                $methodObj = $pathObj.$methodKey
                if ($methodObj.PSObject.Properties['x-ms-examples']) {
                    $methodObj.PSObject.Properties.Remove('x-ms-examples')
                }
            }
        }
    }

    # Remove x-ms-examples sections from x-ms-paths
    if ($json.'x-ms-paths') {
        foreach ($pathKey in $json.'x-ms-paths'.PSObject.Properties.Name) {
            $pathObj = $json.'x-ms-paths'.$pathKey
            foreach ($methodKey in $pathObj.PSObject.Properties.Name) {
                $methodObj = $pathObj.$methodKey
                if ($methodObj.PSObject.Properties['x-ms-examples']) {
                    $methodObj.PSObject.Properties.Remove('x-ms-examples')
                }
            }
        }
    }
    
    # Save the modified JSON back to the file
    $json | ConvertTo-Json -Depth 100 | Set-Content $filePath
    Write-Host "Completed processing $filePath"
}

Write-Host "All files have been preprocessed successfully."
