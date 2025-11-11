/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

namespace Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Runtime
{

    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using GetEventData = System.Func<EventData>;
    using static Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Runtime.Extensions;

    /// <summary>
    /// The IContext Interface defines the communication mechanism for input customization.
    /// </summary>
    /// <remarks>
    /// In the context, we will have client, pipeline, PSBoundParamters, default EventListener, Cancellation.
    /// </remarks>
    public interface IContext
    {
        System.Management.Automation.InvocationInfo InvocationInformation { get; set; }
        System.Threading.CancellationTokenSource CancellationTokenSource { get; set; }
        System.Collections.Generic.IDictionary<String, Object> ExtensibleParameters { get; }
        HttpPipeline Pipeline { get; set; }
        Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.ComputeSchedule Client { get; }
    }
}
