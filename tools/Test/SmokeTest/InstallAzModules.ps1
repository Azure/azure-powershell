$gallery = '$(GALLERY_NAME)'
if( $gallery -eq 'PSGallery' ){
    Write-Host "Setting $(GALLERY_NAME) Trusted..."
    Set-PSRepository -Name $(GALLERY_NAME) -InstallationPolicy Trusted
}

if( $gallery -eq 'TestGallery' ){
    Write-Host "Registering $(GALLERY_NAME)..."
    Register-PSRepository -Name $(GALLERY_NAME) -SourceLocation 'https://www.poshtestgallery.com/api/v2' -PackageManagementProvider NuGet -InstallationPolicy Trusted
}    

Write-Host "Installing Az..."
Install-Module -Name Az -Repository $(GALLERY_NAME) -Scope CurrentUser -AllowClobber -Force 
      
# Check version
Import-Module -MinimumVersion '2.6.0' -Name 'Az' -Force -Scope 'Global'
$azVersion = (get-module Az).Version

# Check Az
Get-Module -Name Az.* -ListAvailable

if(!$azVersion){
    throw "No Az is installed"
}