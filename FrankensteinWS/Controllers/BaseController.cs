using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FrankensteinWS.Controllers
{
    public class BaseController : ApiController
    {
       protected FrankensteinEntities db = new FrankensteinEntities();

           

       /// <summary>
       /// creates an <see cref="HttpResponseException"/> with a response code of 400
       /// and places the reason in the reason header and the body.
       /// </summary>
       /// <param name="reason">Explanation text for the client.</param>
       /// <returns>A new HttpResponseException</returns>
       protected HttpResponseException BadRequest(string reason)
       {
           return CreateHttpResponseException(reason, HttpStatusCode.BadRequest);
       }

       /// <summary>
       /// creates an <see cref="HttpResponseException"/> with a response code of 404
       /// and places the reason in the reason header and the body.
       /// </summary>
       /// <param name="reason">Explanation text for the client.</param>
       /// <returns>A new HttpResponseException</returns>
       protected HttpResponseException NotFound(string reason)
       {
           return CreateHttpResponseException(reason, HttpStatusCode.NotFound);
       }

       protected HttpResponseException BadCredential(string reason)
       {
           return CreateHttpResponseException(reason, HttpStatusCode.Forbidden);
       }


       protected HttpResponseException StockUpdated(string reason)
       {
           return CreateHttpResponseException(reason, HttpStatusCode.OK);
       }

       protected HttpResponseException UsernameTaken(string reason)
       {
           return CreateHttpResponseException(reason, HttpStatusCode.Conflict);
       }
       /// <summary>
       /// Creates an <see cref="HttpResponseException"/> to be thrown by the api.
       /// </summary>
       /// <param name="reason">Explanation text, also added to the body.</param>
       /// <param name="code">The HTTP status code.</param>
       /// <returns>A new <see cref="HttpResponseException"/></returns>
       private static HttpResponseException CreateHttpResponseException(string reason, HttpStatusCode code)
       {
           var response = new HttpResponseMessage
           {
               StatusCode = code,
               ReasonPhrase = reason,
               Content = new StringContent(reason)
           };
           throw new HttpResponseException(response);
       }
    }
}
