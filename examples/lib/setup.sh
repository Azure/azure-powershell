#!/bin/bash
# Login
login() {
	echo "Executing Login..."
    export CmdletSessionId=1010
    azure account add --username $azureuser --password $azurepassword

}

export -f login 