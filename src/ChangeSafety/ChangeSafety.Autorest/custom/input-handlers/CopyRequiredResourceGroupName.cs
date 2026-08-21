// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the Apache License, Version 2.0.

namespace Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Runtime.Cmdlets
{
    public class CopyRequiredResourceGroupName : InputHandler
    {
        public override void Process(Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Runtime.IContext context)
        {
            var boundParameters = context.InvocationInformation.BoundParameters;
            boundParameters["InternalResourceGroupName"] = boundParameters["ResourceGroupName"];
            NextHandler?.Process(context);
        }
    }
}