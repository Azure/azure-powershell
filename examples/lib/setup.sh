#!/bin/bash

# Login
echo "Executing Login..."
export CmdletSessionId=1010
azure account add --username $azureuser --password $azurepassword