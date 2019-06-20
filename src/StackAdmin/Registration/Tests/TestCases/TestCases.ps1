function TestListRegistrations
{
    $ResourceGroupName = "AzsGroup"
    $RegistrationName = "TestRegistration"

    $Registrations = Get-AzureRmAzureStackRegistration -ResourceGroupName $ResourceGroupName
    Assert-NotNull $Registrations
    Assert-AreEqual $RegistrationName $Registrations[0].Name
}

function TestGetRegistration
{
    $ResourceGroupName = "AzsGroup"
    $RegistrationName = "TestRegistration"

    $Registration = Get-AzureRmAzureStackRegistration -ResourceGroupName $ResourceGroupName -Name $RegistrationName
    Assert-NotNull $Registration
    Assert-AreEqual $RegistrationName $Registration.Name
}

function TestGetActivationKey
{
    $ResourceGroupName = "AzsGroup"

    $Registration = Get-AzureRmAzureStackRegistration -ResourceGroupName $ResourceGroupName -Name $RegistrationName
    $ActivationKey = Get-AzureRmAzureStackActivationKey -ResourceGroupName $ResourceGroupName -Name $Registration.Name
    Assert-NotNull $ActivationKey
}

function TestCreateUpdateAndDeleteRegistration
{
    $ResourceGroupName = "AzsGroup"
    $RegistrationName = "TestRegistration"
    $RegistrationToken = "eyJjbG91ZElkIjoiY2xvdWQxIiwib2JqZWN0SWQiOiJjZmNhZWYxNS1iYjI3LTRiNmUtOTc1Mi1jMzMyNTMyYTg4MDIiLCJiaWxsaW5nTW9kZWwiOiJEZXZlbG9wbWVudCIsImhhcmR3YXJlSW5mbyI6W3sibmFtZSI6ImJmYmQ4MmE5NzQ2YTQ3MGNhNTc4NGQ0ODJmNzE1MDRiIiwidXVpZCI6IjU3MDBmZWExLWRkNWMtNGI0Yy05YjRhLWRkZjY0MzY3OWIxYSIsIm51bUNvcmVzIjotMTE5MTgyMjEyMywiYmlvcyI6WyJjZWUwMzhhMDAyNWE0MmJlYjQ3NjM3M2ZjMzM0ZjU4NyIsIjBlOTRlYTk5NzQ4NTRjYTI5N2Q0NGJmNWI4NGEwN2Q3Il0sIm5pYyI6WyIxNGIzNDdlYjUwNjU0ZDM1YTdkYTY2Y2YxMTI1YjExMiIsIjU1YjM4ZTMwMmU0NDQzY2RhZjA4NWFkZWU3MjU0YTQ2Il0sImNwdSI6WyJhMjhlZTM3ZmUxMTU0ZmZkOTQ1YWNkZjI2YmYzM2ZmNyIsImFhYTE4ODU2MzlmMjQ3NjdhZTg4NWI4OTVmODUzYmExIl0sImRpc2siOlsiYWRiOTFhM2Q1ZTg2NDQyNGI1ZWViNWJjM2FkOTY0MjEiLCJkODUzNDBiNWYzMTI0ZDEzYjQwMGJkMWZhYWU0MTA2YSJdLCJtZW1vcnkiOlsiZDIyYzdmODJhMGM5NGMwNGI2ODdlMjgzZDRiNmVmMTIiLCJlOTFjNTExODgzN2I0ZTM2OTY2ODQyMzdlY2ViMjk0ZiJdfV0sInJlZ2lvbk5hbWVzIjpbInVzd2VzdCIsInVzZWFzdCJdLCJhZ3JlZW1lbnROdW1iZXIiOiJhZ3JlZW1lbnQxIiwidXNhZ2VSZXBvcnRpbmdFbmFibGVkIjp0cnVlLCJtYXJrZXRwbGFjZVN5bmRpY2F0aW9uRW5hYmxlZCI6dHJ1ZSwiaXNzdWVyIjoiaXNzdWVyMSIsInZlcnNpb24iOiIxLjAifQ=="

    $Registration = New-AzureRmAzureStackRegistration -ResourceGroupName $ResourceGroupName -Name $RegistrationName -RegistrationToken $RegistrationToken
    Assert-NotNull $Registration

    $Registration = Set-AzureRmAzureStackRegistration -ResourceGroupName $ResourceGroupName -Name $RegistrationName -RegistrationToken $RegistrationToken
    Assert-NotNull $Registration

    Remove-AzureRmAzureStackRegistration -ResourceGroupName $ResourceGroupName -Name $RegistrationName -Force

    Remove-AzureRmAzureStackRegistration -ResourceGroupName $ResourceGroupName -Name $RegistrationName -Force

    Assert-ThrowsContains { Get-AzureRmAzureStackRegistration -ResourceGroupName $ResourceGroupName -Name $RegistrationName } "NotFound"
}

function TestListProducts
{
    $ResourceGroupName = "AzsGroup"
    $RegistrationName = "TestRegistration"

    $Products = Get-AzureRmAzureStackProduct -ResourceGroupName $ResourceGroupName -RegistrationName $RegistrationName

    Assert-NotNull $Products
}

function TestGetProduct
{
    $ResourceGroupName = "AzsGroup"
    $RegistrationName = "TestRegistration"

    $Products = Get-AzureRmAzureStackProduct -ResourceGroupName $ResourceGroupName -RegistrationName $RegistrationName

    foreach ($product in $Products)
    {
        $productName = $product.Name.Replace("$RegistrationName/", "")
        $productResult = Get-AzureRmAzureStackProduct -ResourceGroupName $ResourceGroupName -RegistrationName $RegistrationName -ProductName $productName
        Assert-NotNull $productResult
    }
}

function TestGetProductDetails
{
    $ResourceGroupName = "AzsGroup"
    $RegistrationName = "TestRegistration"

    $Products = Get-AzureRmAzureStackProduct -ResourceGroupName $ResourceGroupName -RegistrationName $RegistrationName

    foreach ($product in $Products)
    {
        $productName = $product.Name.Replace("$RegistrationName/", "")
        $productDetails = Get-AzureRmAzureStackProductDetails -ResourceGroupName $ResourceGroupName -RegistrationName $RegistrationName -ProductName $productName
        Assert-NotNull $productDetails
    }
}

function TestListCustomerSubscriptions
{
    $ResourceGroupName = "AzsGroup"
    $RegistrationName = "TestRegistration"

    $Subscriptions = Get-AzureRmAzureStackCustomerSubscription -ResourceGroupName $ResourceGroupName -RegistrationName $RegistrationName
    Assert-NotNull $Subscriptions
}

function TestGetCustomerSubscription
{
    $ResourceGroupName = "AzsGroup"
    $RegistrationName = "TestRegistration"
    $UserSubscriptionName = "TestSubscription"

    $Subscription = Get-AzureRmAzureStackCustomerSubscription -ResourceGroupName $ResourceGroupName -RegistrationName $RegistrationName -CustomerSubscriptionName $UserSubscriptionName
    Assert-NotNull $Subscription
}

function TestCreateAndDeleteCustomerSubscription
{
    $ResourceGroupName = "AzsGroup"
    $RegistrationName = "TestRegistration"
    $UserSubscriptionName = "TestSubscription"
    $AzureTenantId = "72f988bf-86f1-41af-91ab-2d7cd011db47"

    $Subscription = New-AzureRmAzureStackCustomerSubscription -ResourceGroupName $ResourceGroupName -RegistrationName $RegistrationName -CustomerSubscriptionName $UserSubscriptionName -TenantId $AzureTenantId
    Assert-NotNull $Subscription

    Remove-AzureRmAzureStackCustomerSubscription -ResourceGroupName $ResourceGroupName -RegistrationName $RegistrationName -CustomerSubscriptionName $UserSubscriptionName -Force
}