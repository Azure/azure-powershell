#########################################################################################
#
# Copyright (c) Microsoft Corporation. All rights reserved.
#
# Licensed under the MIT license.
#
# PSSwaggerUtility Module
#
#########################################################################################


function New-PSSwaggerClientTracingInternal {
	[CmdletBinding()]
	param()
	
	$null
}

function Register-PSSwaggerClientTracingInternal {
	[CmdletBinding()]
	param(
		[object]$TracerObject
	)
}

function Unregister-PSSwaggerClientTracingInternal {
	[CmdletBinding()]
	param(
		[object]$TracerObject
	)
}

Export-ModuleMember -Function *
