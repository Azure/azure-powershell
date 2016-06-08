Param(
	[parameter(Mandatory=$true)]
    [ValidateNotNullOrEmpty()]
    [string]
    $User,
    [parameter(Mandatory=$true)]
    [ValidateNotNullOrEmpty()]
    [string]
    $Password,
    [parameter(Mandatory=$true)]
    [ValidateNotNullOrEmpty()]
    [string]
    $ManageUrl
)

$metadataFile = "$PWD\ServerDataService.csdl"
$clientModelClassFile = "$PWD\ServerContextInternal.cs"
$clientModelNamespace = "Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Server";
$clientModelBaseContext = "ServerContextInternal";

######## Import Server module from the build
Import-Module ..\..\..\..\..\..\Package\Debug\AzureServiceManagement\AzureServiceManagement.psd1

######## Create a new Server data service context
Write-Host "Connecting to management service at $ManageUrl"
$passwordSecure = $Password | ConvertTo-SecureString -asPlainText -Force
$credential = new-object System.Management.Automation.PSCredential($User, $passwordSecure)

$context = New-AzureSqlDatabaseServerContext -ManageUrl $ManageUrl -Credential $Credential 

######## Update Server model $metadata to build from
Write-Host "Retrieving model metadata from $ManageUrl"
$metadataDoc = $context.RetrieveMetadata()
if ($metadataDoc -eq $null)
{
	Write-Error "$ManageUrl could not be accessed to retrieve metadata."
	Write-Error "Please check credentials and the Url."
	exit
}

Write-Host "Updating checked-in model metadata at $metadataFile"
$metadataDoc.Save($metadataFile)

$filteredDoc=[Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Common.DataConnectionUtility]::FilterMetadataDocument($metadataDoc);
$metadataHash=[Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Common.DataConnectionUtility]::GetDocumentHash($filteredDoc)

######## Use DataSvcUtil to generate the model client class
Write-Host "Generating model class file at $clientModelClassFile"
$Framework35Path=[System.IO.Path]::Combine($env:FrameworkDir, $env:Framework35Version)
$DataSvcUtil=[System.IO.Path]::Combine($Framework35Path, "DataSvcUtil.exe")
& $DataSvcUtil /in:"$metadataFile" /out:"$clientModelClassFile"
if ($lastexitcode -eq 1)
{
	Write-Error "MODEL GENERATION ERROR: DataSvcUtil did not run properly. Command line:s"
	Write-Error "$DataSvcUtil /in:`"$metadataFile`" /out:`"$clientModelClassFile`""
	exit
}

######## Replace the default namespace and make the class abstract
$newClassFile = Get-Content $clientModelClassFile |
	ForEach-Object { $_ -replace "^(namespace )(.*)","`$1$clientModelNamespace"} |
	ForEach-Object { $_ -replace "(public )(partial class $clientModelBaseContext)","`$1abstract `$2"}
$newClassFile | Set-Content "$clientModelClassFile"

$metadataHashDeclaration="namespace $clientModelNamespace
{
    public abstract partial class $clientModelBaseContext
    {
        public readonly string[] metadataHashes = new string[]{ 
            `"$metadataHash`",
            `"0333AB7076A926BF53F07C1786F11C052DEB791B`",
            `"F903DB500E018B00ECB1E355BC55F73B7342FC76`",
            `"5A2ABE58F30C9EF4B4F49853CD5FE28BA9FEBCD9`",
            `"68BA8B4EB74E0C5A91D0A734B742001018A9F9D2`",
            `"80A53B80FCD9616E6EEBDCAA3482E30A159C0E1F`",
            `"3070BEE06139E0754E2F022E56E9798BF8A57F30`"};
    }
}"
$metadataHashDeclaration | Add-Content "$clientModelClassFile"
