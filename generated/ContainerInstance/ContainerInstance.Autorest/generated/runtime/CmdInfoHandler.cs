/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
﻿using System;
using System.Management.Automation;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime
{
    using NextDelegate = Func<HttpRequestMessage, CancellationToken, Action, Func<string, CancellationToken, Func<EventArgs>, Task>, Task<HttpResponseMessage>>;
    using SignalDelegate = Func<string, CancellationToken, Func<EventArgs>, Task>;

    public class CmdInfoHandler
    {
        private readonly string processRecordId;
        private readonly string parameterSetName;
        private readonly InvocationInfo invocationInfo;

        public CmdInfoHandler(string processRecordId, InvocationInfo invocationInfo, string parameterSetName)
        {
            this.processRecordId = processRecordId;
            this.parameterSetName = parameterSetName;
            this.invocationInfo = invocationInfo;
        }

        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken token, Action cancel, SignalDelegate signal, NextDelegate next)
        {
            request.Headers.Add("x-ms-client-request-id", processRecordId);
            request.Headers.Add("CommandName", invocationInfo?.InvocationName);
            request.Headers.Add("FullCommandName", invocationInfo?.MyCommand?.Name);
            request.Headers.Add("ParameterSetName", parameterSetName);

            // continue with pipeline.
            return next(request, token, cancel, signal);
        }
    }
}
