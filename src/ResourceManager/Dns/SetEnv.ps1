Param(
    [parameter(Mandatory=$true)]
    [string] $SubscriptionId,
    [parameter(Mandatory=$true)]
    [string] $ServicePrincipal ,
    [parameter(Mandatory=$false)]
    [string] $ServicePrincipalSecret,
    [parameter(Mandatory=$false)]
    [string] $TenantId = "24c154bb-0619-4338-b30a-6aad6370ee14",
    [parameter(Mandatory=$false)]
    [string] $Environment = "Prod" # Prod for arm prod , DOGFOOD for DOGFOOD
)

$env:AZURE_TEST_MODE="Record";
$str = "HttpRecorderMode=Record;SubscriptionId="+$SubscriptionId+";Environment="+$Environment+";ServicePrincipal="+$ServicePrincipal+";Password="+$ServicePrincipalSecret+";ServicePrincipalSecret="+$ServicePrincipalSecret ;
if ($Environment -ine "Prod")
{
    $str+= ";AADTenant="+$TenantId;
}

$env:TEST_CSM_ORGID_AUTHENTICATION=$str;

