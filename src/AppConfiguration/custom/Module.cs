using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime;

using SignalDelegate = global::System.Func<string, global::System.Threading.CancellationToken, global::System.Func<global::System.EventArgs>, global::System.Threading.Tasks.Task>;
using NextDelegate = global::System.Func<global::System.Net.Http.HttpRequestMessage, global::System.Threading.CancellationToken, global::System.Action, global::System.Func<string, global::System.Threading.CancellationToken, global::System.Func<global::System.EventArgs>, global::System.Threading.Tasks.Task>, global::System.Threading.Tasks.Task<global::System.Net.Http.HttpResponseMessage>>;
using SendAsyncStepDelegate = System.Func<System.Net.Http.HttpRequestMessage, System.Threading.CancellationToken, System.Action, System.Func<string, System.Threading.CancellationToken, System.Func<System.EventArgs>, System.Threading.Tasks.Task>, System.Func<System.Net.Http.HttpRequestMessage, System.Threading.CancellationToken, System.Action, System.Func<string, System.Threading.CancellationToken, System.Func<System.EventArgs>, System.Threading.Tasks.Task>, System.Threading.Tasks.Task<System.Net.Http.HttpResponseMessage>>, System.Threading.Tasks.Task<System.Net.Http.HttpResponseMessage>>;
using TokenAudienceConverterDelegate = global::System.Func<Microsoft.Azure.Commands.Common.Authentication.Abstractions.IAzureEnvironment,
                                                           Microsoft.Azure.Commands.Common.Authentication.Abstractions.IAzureEnvironment,
                                                           global::System.Uri, string>;
using System.Security.Cryptography;
using System.IO;
using System.Net.Http.Headers;
using System.Diagnostics;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration
{
    //eriwan:auth2
    partial class Module
    {
        /// <summary>
        /// User may implement this partial method to use customized auth logic for the request
        /// </summary>
        /// <param name="extensibleParameters"></param>
        /// <param name="authDelegate"></param>
        partial void CustomizeAuthenticationHandler(IDictionary<string, object> extensibleParameters, ref SendAsyncStepDelegate authDelegate)
        {
            authDelegate = new HMACAuthPolicy(extensibleParameters).SendAsync;
        }

        /// <summary>
        /// User may implement this partial method to get customized token audience for AAD
        /// </summary>
        /// <param name="tokenAudienceConverter"></param>
        partial void CustomizeTokenAudienceConverter(ref TokenAudienceConverterDelegate tokenAudienceConverter)
        {
            //tokenAudienceConverter = new AppConfigTokenAudienceConverter().Convert;
        }
    }
}
