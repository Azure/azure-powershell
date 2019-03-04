// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Extensibility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    public class CustomWebUi : ICustomWebUi
    {
        private TcpListener _listener;
        private Action<string> _promptAction;

        private const string CloseWindowSuccessHtml = @"<html>
  <head><title>Authentication Complete</title></head>
  <body>
    Authentication complete. You can return to the application. Feel free to close this browser tab.
  </body>
</html>";

        public CustomWebUi(TcpListener listener, Action<string> promptAction)
        {
            _listener = listener;
            _promptAction = promptAction;
        }

        /// <summary>
        ///     Method called by MSAL.NET to delegate the authentication code Web with with the STS
        /// </summary>
        /// <param name="authorizationUri">
        ///     URI computed by MSAL.NET that will let the UI extension
        ///     navigate to the STS authorization endpoint in order to sign-in the user and have them consent
        /// </param>
        /// <param name="redirectUri">
        ///     The redirect Uri that was configured. The auth code will be appended to this redirect uri and the browser
        ///     will redirect to it.
        /// </param>
        /// <returns>
        ///     The URI returned back from the STS authorization endpoint. This URI contains a code=CODE
        ///     parameters that MSAL.NET will extract and redeem.
        /// </returns>
        /// <remarks>
        ///     The authorizationUri is crafted to leverage PKCE in order to protect the token from a man
        ///     in the middle attack. Only MSAL.NET can redeem the code.
        ///
        ///     In the event of cancellation, the implementer should return OperationCanceledException.
        ///     In the event of failure, the implementer should throw MsalCustomWebUiFailedException.
        /// </remarks>
        public async Task<Uri> AcquireAuthorizationCodeAsync(Uri authorizationUri, Uri redirectUri)
        {
            if (!OpenBrowser(authorizationUri.ToString()))
            {
                Console.WriteLine("Unable to launch a browser for authorization code login. Reverting to device code login.");
            }

            TcpListener listener = new TcpListener(IPAddress.Loopback, redirectUri.Port);
            listener.Start();
            using (TcpClient client = await listener.AcceptTcpClientAsync().ConfigureAwait(false))
            {
                string httpRequest = await GetTcpResponseAsync(client).ConfigureAwait(false);
                string uri = ExtractUriFromHttpRequest(httpRequest, redirectUri.Port);
                await WriteResponseAsync(client.GetStream()).ConfigureAwait(false);
                return await Task.Run(() => { return new Uri(uri); });
            }
        }

        // No universal call in .NET Core to open browser -- see below issue for more details
        // https://github.com/dotnet/corefx/issues/10361
        private bool OpenBrowser(string url)
        {
            try
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw new PlatformNotSupportedException(RuntimeInformation.OSDescription);
                }
            }
            catch (MsalCustomWebUiFailedException ex)
            {
                _promptAction(ex.ToString());
                throw ex;
            }
            catch (MsalServiceException ex)
            {
                _promptAction(ex.ToString());
                throw ex;
            }

            return true;
        }

        private static async Task<string> GetTcpResponseAsync(TcpClient client)
        {
            NetworkStream networkStream = client.GetStream();

            byte[] readBuffer = new byte[1024];
            StringBuilder stringBuilder = new StringBuilder();
            int numberOfBytesRead = 0;

            // Incoming message may be larger than the buffer size.
            do
            {
                numberOfBytesRead = await networkStream.ReadAsync(readBuffer, 0, readBuffer.Length).ConfigureAwait(false);

                string s = Encoding.ASCII.GetString(readBuffer, 0, numberOfBytesRead);
                stringBuilder.Append(s);

            }
            while (networkStream.DataAvailable);

            return stringBuilder.ToString();
        }

        private string ExtractUriFromHttpRequest(string httpRequest, int port)
        {
            string regexp = @"GET \/\?(.*) HTTP";
            string getQuery = null;
            Regex r1 = new Regex(regexp);
            Match match = r1.Match(httpRequest);
            if (!match.Success)
            {
                throw new InvalidOperationException("Not a GET query");// TODO: exceptions
            }

            getQuery = match.Groups[1].Value;
            UriBuilder uriBuilder = new UriBuilder();
            uriBuilder.Query = getQuery;
            uriBuilder.Port = port;
            Uri u = uriBuilder.Uri;

            return uriBuilder.ToString();
        }

        private async Task WriteResponseAsync(NetworkStream stream)
        {
            string fullResponse = $"HTTP/1.1 200 OK\r\n\r\n{CloseWindowSuccessHtml}";
            var response = Encoding.ASCII.GetBytes(fullResponse);
            await stream.WriteAsync(response, 0, response.Length).ConfigureAwait(false);
            await stream.FlushAsync().ConfigureAwait(false);
        }
    }
}
