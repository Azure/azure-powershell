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

using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Commands.Test.MediaServices
{
    internal class FakeHttpContent : HttpContent
    {
        private readonly string _content;

        public FakeHttpContent(string content)
        {
            _content = content;
        }

        public FakeHttpContent() : this("")
        {
        }

        protected override Task SerializeToStreamAsync(Stream stream, TransportContext context)
        {
            byte[] bytes = new UTF8Encoding().GetBytes(_content);
            return Task.Factory.StartNew(() => stream.Write(bytes, 0, bytes.Length));
        }

        protected override bool TryComputeLength(out long length)
        {
            length = _content.Length;
            return true;
        }
    }
}