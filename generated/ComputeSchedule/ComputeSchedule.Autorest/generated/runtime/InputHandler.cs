/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;

namespace Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Runtime.Cmdlets
{
    public abstract class InputHandler
    {
        protected InputHandler NextHandler = null;

        public void SetNextHandler(InputHandler nextHandler)
        {
            this.NextHandler = nextHandler;
        }

        public abstract void Process(Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Runtime.IContext context);
    }
}