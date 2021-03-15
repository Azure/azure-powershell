using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

using Azure.Core;

using Microsoft.Azure.Commands.Profile.Utilities;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    internal class ClaimsChallengeHandler : DelegatingHandler, ICloneable
    {
        //TODO: TokenCredential may not support CAE: SP; MSI(?)
        private IClaimsChallengeProcessor ClaimsChallengeProcessor { get; set; }

        public ClaimsChallengeHandler(IClaimsChallengeProcessor claimsChallengeProcessor)
        {
            ClaimsChallengeProcessor = claimsChallengeProcessor;
        }


        public ClaimsChallengeHandler(IClaimsChallengeProcessor claimsChallengeProcessor, HttpMessageHandler innerHandler):base(innerHandler)
        {
            ClaimsChallengeProcessor = claimsChallengeProcessor;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);
            if (response.StatusCode == HttpStatusCode.Unauthorized && response.Headers.WwwAuthenticate?.Count > 0)
            {
                //TODO: catch exception if authentication failed?

                if (await OnChallengeAsync(request, response, cancellationToken, true))
                {
                    return await base.SendAsync(request, cancellationToken);
                }
            }
            return response;
        }

        public object Clone()
        {
            return new ClaimsChallengeHandler(ClaimsChallengeProcessor);
        }
        /// <summary>
        /// Executed in the event a 401 response with a WWW-Authenticate authentication challenge header is received after the initial request.
        /// </summary>
        /// <remarks>This implementation handles common authentication challenges such as claims challenges. Service client libraries may derive from this and extend to handle service specific authentication challenges.</remarks>
        /// <param name="message">The HttpMessage to be authenticated.</param>
        /// <param name="async">Specifies if the method is being called in an asynchronous context</param>
        /// <returns>A boolean indicated whether the request should be retried</returns>
        protected virtual async Task<bool> OnChallengeAsync(HttpRequestMessage requestMessage, HttpResponseMessage responseMessage, CancellationToken cancellationToken, bool async)
        {
            var claimsChallenge = ClaimsChallengeUtilities.GetClaimsChallenge(responseMessage);

            if (!string.IsNullOrEmpty(claimsChallenge))
            {
                return await ClaimsChallengeProcessor.OnClaimsChallenageAsync(requestMessage, claimsChallenge, ClaimsChallengeUtilities.GetErrorMessage(responseMessage), cancellationToken);
            }

            return false;
        }


        //TODO: Copy from Azure.Identity, do we really need it?

        //private class AccessTokenCache
        //{
        //    private readonly object _syncObj = new object();
        //    private readonly TokenCredential _credential;
        //    private readonly TimeSpan _tokenRefreshOffset;
        //    private readonly TimeSpan _tokenRefreshRetryDelay;

        //    private TokenRequestContext? _currentContext;
        //    private TaskCompletionSource<HeaderValueInfo> _infoTcs;
        //    private TaskCompletionSource<HeaderValueInfo> _backgroundUpdateTcs;
        //    public AccessTokenCache(TokenCredential credential, TimeSpan tokenRefreshOffset, TimeSpan tokenRefreshRetryDelay, string[] initialScopes)
        //    {
        //        _credential = credential;
        //        _tokenRefreshOffset = tokenRefreshOffset;
        //        _tokenRefreshRetryDelay = tokenRefreshRetryDelay;
        //        _currentContext = new TokenRequestContext(initialScopes);
        //    }

        //    public async ValueTask<string> GetHeaderValueAsync(HttpMessage message, TokenRequestContext context, bool async)
        //    {
        //        bool getTokenFromCredential;
        //        TaskCompletionSource<HeaderValueInfo> headerValueTcs;
        //        TaskCompletionSource<HeaderValueInfo> backgroundUpdateTcs;
        //        (headerValueTcs, backgroundUpdateTcs, getTokenFromCredential) = GetTaskCompletionSources(context);

        //        if (getTokenFromCredential)
        //        {
        //            if (backgroundUpdateTcs != null)
        //            {
        //                HeaderValueInfo info = headerValueTcs.Task.EnsureCompleted();
        //                _ = Task.Run(() => GetHeaderValueFromCredentialInBackgroundAsync(backgroundUpdateTcs, info, context, async));
        //                return info.HeaderValue;
        //            }

        //            try
        //            {
        //                HeaderValueInfo info = await GetHeaderValueFromCredentialAsync(context, async, message.CancellationToken);
        //                headerValueTcs.SetResult(info);
        //            }
        //            catch (OperationCanceledException)
        //            {
        //                headerValueTcs.SetCanceled();
        //                throw;
        //            }
        //            catch (Exception exception)
        //            {
        //                headerValueTcs.SetException(exception);
        //                throw;
        //            }
        //        }

        //        var headerValueTask = headerValueTcs.Task;
        //        if (!headerValueTask.IsCompleted)
        //        {
        //            if (async)
        //            {
        //                await headerValueTask.AwaitWithCancellation(message.CancellationToken);
        //            }
        //            else
        //            {
        //                try
        //                {
        //                    headerValueTask.Wait(message.CancellationToken);
        //                }
        //                catch (AggregateException) { } // ignore exception here to rethrow it with EnsureCompleted
        //            }
        //        }

        //        return headerValueTcs.Task.EnsureCompleted().HeaderValue;
        //    }

        //    private (TaskCompletionSource<HeaderValueInfo> tcs, TaskCompletionSource<HeaderValueInfo> backgroundUpdateTcs, bool getTokenFromCredential) GetTaskCompletionSources(TokenRequestContext context)
        //    {
        //        lock (_syncObj)
        //        {
        //            // Initial state. GetTaskCompletionSources has been called for the first time
        //            if (_infoTcs == null || RequestRequiresNewToken(context))
        //            {
        //                _currentContext = context;
        //                _infoTcs = new TaskCompletionSource<HeaderValueInfo>(TaskCreationOptions.RunContinuationsAsynchronously);
        //                _backgroundUpdateTcs = default;
        //                return (_infoTcs, _backgroundUpdateTcs, true);
        //            }

        //            // Getting new access token is in progress, wait for it
        //            if (!_infoTcs.Task.IsCompleted)
        //            {
        //                _backgroundUpdateTcs = default;
        //                return (_infoTcs, _backgroundUpdateTcs, false);
        //            }

        //            DateTimeOffset now = DateTimeOffset.UtcNow;
        //            // Access token has been successfully acquired in background and it is not expired yet, use it instead of current one
        //            if (_backgroundUpdateTcs != null && _backgroundUpdateTcs.Task.Status == TaskStatus.RanToCompletion && _backgroundUpdateTcs.Task.Result.ExpiresOn > now)
        //            {
        //                _infoTcs = _backgroundUpdateTcs;
        //                _backgroundUpdateTcs = default;
        //            }

        //            // Attempt to get access token has failed or it has already expired. Need to get a new one
        //            if (_infoTcs.Task.Status != TaskStatus.RanToCompletion || now >= _infoTcs.Task.Result.ExpiresOn)
        //            {
        //                _infoTcs = new TaskCompletionSource<HeaderValueInfo>(TaskCreationOptions.RunContinuationsAsynchronously);
        //                return (_infoTcs, default, true);
        //            }

        //            // Access token is still valid but is about to expire, try to get it in background
        //            if (now >= _infoTcs.Task.Result.RefreshOn && _backgroundUpdateTcs == null)
        //            {
        //                _backgroundUpdateTcs = new TaskCompletionSource<HeaderValueInfo>(TaskCreationOptions.RunContinuationsAsynchronously);
        //                return (_infoTcs, _backgroundUpdateTcs, true);
        //            }

        //            // Access token is valid, use it
        //            return (_infoTcs, default, false);
        //        }
        //    }

        //    // must be called under lock (_syncObj)
        //    private bool RequestRequiresNewToken(TokenRequestContext context)
        //    {
        //        if (_currentContext == null)
        //        {
        //            return true;
        //        }

        //        if (context.Scopes != null)
        //        {
        //            for (int i = 0; i < context.Scopes.Length; i++)
        //            {
        //                if (context.Scopes[i] != _currentContext.Value.Scopes?[i])
        //                {
        //                    return true;
        //                }
        //            }
        //        }

        //        if ((context.ClaimsChallenge != null) && (context.ClaimsChallenge != _currentContext.Value.ClaimsChallenge))
        //        {
        //            return true;
        //        }

        //        return false;
        //    }

        //    private async ValueTask GetHeaderValueFromCredentialInBackgroundAsync(TaskCompletionSource<HeaderValueInfo> backgroundUpdateTcs, HeaderValueInfo info, TokenRequestContext context, bool async)
        //    {
        //        var cts = new CancellationTokenSource(_tokenRefreshRetryDelay);
        //        try
        //        {
        //            HeaderValueInfo newInfo = await GetHeaderValueFromCredentialAsync(context, async, cts.Token);
        //            backgroundUpdateTcs.SetResult(newInfo);
        //        }
        //        catch (OperationCanceledException) when (cts.IsCancellationRequested)
        //        {
        //            //backgroundUpdateTcs.SetResult(new HeaderValueInfo(info.HeaderValue, info.ExpiresOn, DateTimeOffset.UtcNow));
        //            //AzureCoreEventSource.Singleton.BackgroundRefreshFailed(context.ParentRequestId ?? string.Empty, oce.ToString());
        //        }
        //        catch (Exception)
        //        {
        //            //backgroundUpdateTcs.SetResult(new HeaderValueInfo(info.HeaderValue, info.ExpiresOn, DateTimeOffset.UtcNow + _tokenRefreshRetryDelay));
        //            //AzureCoreEventSource.Singleton.BackgroundRefreshFailed(context.ParentRequestId ?? string.Empty, e.ToString());
        //        }
        //        finally
        //        {
        //            cts.Dispose();
        //        }
        //    }

        //    private async ValueTask<HeaderValueInfo> GetHeaderValueFromCredentialAsync(TokenRequestContext context, bool async, CancellationToken cancellationToken)
        //    {
        //        AccessToken token = async
        //            ? await _credential.GetTokenAsync(context, cancellationToken).ConfigureAwait(false)
        //            : _credential.GetToken(context, cancellationToken);

        //        return new HeaderValueInfo("Bearer " + token.Token, token.ExpiresOn, token.ExpiresOn - _tokenRefreshOffset);
        //    }

        //    private readonly struct HeaderValueInfo
        //    {
        //        public string HeaderValue { get; }
        //        public DateTimeOffset ExpiresOn { get; }
        //        public DateTimeOffset RefreshOn { get; }

        //        public HeaderValueInfo(string headerValue, DateTimeOffset expiresOn, DateTimeOffset refreshOn)
        //        {
        //            HeaderValue = headerValue;
        //            ExpiresOn = expiresOn;
        //            RefreshOn = refreshOn;
        //        }
        //    }
        //}

    }
}
