using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace ProductSoat.Handlers
{
    public class AuthorizationHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var auth = request.Headers.Authorization;

            if (auth != null)
            {
                var parameters = auth.Parameter.Split(':');
                if (auth.Scheme == "Basic" && parameters.Length == 2 && parameters[0] == "leila" && parameters[1] == "123")
                {
                    var response = await base.SendAsync(request, cancellationToken);
                    return response;
                }
            }
            return new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
        }
    }
}