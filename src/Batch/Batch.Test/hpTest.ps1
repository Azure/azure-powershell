$env:AZURE_BATCH_ACCOUNT = "hoppeeastasia2"
$env:AZURE_BATCH_ACCESS_KEY = "ZVi5FP4oWbSzPBQeyBwXiYFvXxWICXvdgSHWLr7CP55efHqT/GVgQn/y4KyDGFi6Ov6zzyEDb2lN+ABaOXdtbA=="
$env:AZURE_BATCH_ENDPOINT = "https://hoppeeastasia2.eastasia.batch.azure.com"
$env:AZURE_BATCH_RESOURCE_GROUP = "123"
$env:TEST_CSM_ORGID_AUTHENTICATION="SubscriptionId=21abd678-18c5-4660-9fdd-8c5ba6b6fe1f;BaseUri=https://management.azure.com/;AADAuthEndpoint=https://login.microsoftonline.com/;ServicePrincipal=93f784ca-6071-4330-a35b-cd6b0cdda7d3;ServicePrincipalSecret=YNO8Q~dULpAa.lw6vU~DzEkJ09zf2Ydp0ZMQ8ax9;AADTenant=72f988bf-86f1-41af-91ab-2d7cd011db47"
# $env:AZURE_TEST_MODE="Playback"
$env:AZURE_TEST_MODE="Record"

dotnet test > out3.log