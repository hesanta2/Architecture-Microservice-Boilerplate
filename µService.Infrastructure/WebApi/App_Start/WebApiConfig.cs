﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;

namespace µService.Infrastructure.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            //http://www.strathweb.com/2013/06/supporting-only-json-in-asp-net-web-api-the-right-way/
            var jsonFormatter = new JsonMediaTypeFormatter();
            config.Services.Replace(typeof(IContentNegotiator), new JsonContentNegotiator(jsonFormatter));
        }

        internal class JsonContentNegotiator : IContentNegotiator
        {
            private readonly JsonMediaTypeFormatter _jsonFormatter;

            public JsonContentNegotiator(JsonMediaTypeFormatter formatter)
            {
                _jsonFormatter = formatter;
                _jsonFormatter.SerializerSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
                _jsonFormatter.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;
            }

            public ContentNegotiationResult Negotiate(
                    Type type,
                    HttpRequestMessage request,
                    IEnumerable<MediaTypeFormatter> formatters)
            {
                return new ContentNegotiationResult(
                    _jsonFormatter,
                    new MediaTypeHeaderValue("application/json"));
            }
        }
    }
}
