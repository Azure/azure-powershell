using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using SignalDelegate = global::System.Func<string, global::System.Threading.CancellationToken, global::System.Func<global::System.EventArgs>, global::System.Threading.Tasks.Task>;
using NextDelegate = global::System.Func<global::System.Net.Http.HttpRequestMessage, global::System.Threading.CancellationToken, global::System.Action, global::System.Func<string, global::System.Threading.CancellationToken, global::System.Func<global::System.EventArgs>, global::System.Threading.Tasks.Task>, global::System.Threading.Tasks.Task<global::System.Net.Http.HttpResponseMessage>>;

namespace Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration
{
    internal class HMACAuthPolicy : IAuthPolicy
    {
        private IDictionary<string, object> _extensibleParameters;
        public HMACAuthPolicy(IDictionary<string, object> extensibleParameters)
        {
            _extensibleParameters = extensibleParameters;
        }

        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken token, Action cancel, SignalDelegate signal, NextDelegate next)
        {
            if (token.IsCancellationRequested)
            {
                cancel();
            }

            //TODO: Please replace the following statement with real logic for authorizing request
            throw new NotImplementedException("Please replace real logic for authorizing request");

            //how to get secret first?
            //string id = _extensibleParameters["id"] as string;
            //byte[] secret = _extensibleParameters["secret"] as byte[];
            //request.Sign(id, secret);

#pragma warning disable CS0162 // Unreachable code detected
            return await next(request, token, cancel, signal);
#pragma warning restore CS0162 // Unreachable code detected

        }
    }


    //static class HttpRequestMessageExtensions
    //{
    //    public static HttpRequestMessage Sign(this HttpRequestMessage request, string credential, byte[] secret)
    //    {
    //        string host = request.RequestUri.Authority;
    //        string verb = request.Method.ToString().ToUpper();
    //        DateTimeOffset utcNow = DateTimeOffset.UtcNow;
    //        string contentHash = Convert.ToBase64String(request.Content.ComputeSha256Hash());

    //        //
    //        // SignedHeaders
    //        string signedHeaders = "date;host;x-ms-content-sha256"; // Semicolon separated header names

    //        //
    //        // String-To-Sign
    //        var stringToSign = $"{verb}\n{request.RequestUri.PathAndQuery}\n{utcNow.ToString("r")};{host};{contentHash}";

    //        //
    //        // Signature
    //        string signature;

    //        using (var hmac = new HMACSHA256(secret))
    //        {
    //            signature = Convert.ToBase64String(hmac.ComputeHash(Encoding.ASCII.GetBytes(stringToSign)));
    //        }

    //        //
    //        // Add headers
    //        request.Headers.Date = utcNow;
    //        request.Headers.Add("x-ms-content-sha256", contentHash);
    //        request.Headers.Authorization = new AuthenticationHeaderValue("HMAC-SHA256", $"Credential={credential}&SignedHeaders={signedHeaders}&Signature={signature}");

    //        return request;
    //    }
    //}

    //static class HttpContentExtensions
    //{
    //    public static byte[] ComputeSha256Hash(this HttpContent content)
    //    {
    //        using (var stream = new MemoryStream())
    //        {
    //            if (content != null)
    //            {
    //                content.CopyToAsync(stream).Wait();
    //                stream.Seek(0, SeekOrigin.Begin);
    //            }

    //            using (var alg = SHA256.Create())
    //            {
    //                return alg.ComputeHash(stream.ToArray());
    //            }
    //        }
    //    }
    //}
}
