try{
    Write-Host "Re-generating SDK under Generated folder for security..."
    autorest --use:@microsoft.azure/autorest.csharp@2.3.90
    autorest README.md --version=v2
}catch{
    Write-Host -foregroundcolor Red "An error occurred: $_"
    Write-Error 'Unexpected error.' -ErrorAction Stop
}