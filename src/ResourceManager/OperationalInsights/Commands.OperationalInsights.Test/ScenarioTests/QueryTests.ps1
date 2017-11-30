function Test-SimpleQuery
{
    $wsId = "DEMO_WORKSPACE"
    $query = "union * | take 10"

    $results = Invoke-AzureRmOperationalInsightsQuery -WorkspaceId $wsId -Query $query -UseDemoKey
}

function Test-SimpleQueryWithTimespan
{
    $wsId = "DEMO_WORKSPACE"
    $query = "union * | take 10"
    $timespan = (New-Timespan -Hours 1)

    $results = Invoke-AzureRmOperationalInsightsQuery -WorkspaceId $wsId -Query $query -Timespan $timespan -UseDemoKey
}

function Test-ExceptionWithSyntaxError
{
    $wsId = "DEMO_WORKSPACE"
    $query = "union * | foobar"

    Assert-ThrowsContains { Invoke-AzureRmOperationalInsightsQuery -WorkspaceId $wsId -Query $query -UseDemoKey } "BadRequest"
}

function Test-ExceptionWithShortWait
{
    $wsId = "DEMO_WORKSPACE"
    $query = "union *"
    $timespan = (New-Timespan -Hours 24)
    $wait = 1;

    Assert-ThrowsContains { $results = Invoke-AzureRmOperationalInsightsQuery -WorkspaceId $wsId -Query $query -Timespan $timespan -Wait $wait -UseDemoKey } "GatewayTimeout"
}