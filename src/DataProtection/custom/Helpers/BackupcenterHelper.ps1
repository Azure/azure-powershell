function AddFilterToQuery {
	param(
		[Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Query,

		[Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $FilterKey,

		[Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String[]]
        $FilterValues
	)
	
	process{
		$updatedQuery = $Query
		$filterValueJoin = $FilterValues | Join-String -Separator "','"
		$updatedQuery += " | where " + $FilterKey + " in~ ('" + $filterValueJoin + "')"
		return $updatedQuery
	}
}