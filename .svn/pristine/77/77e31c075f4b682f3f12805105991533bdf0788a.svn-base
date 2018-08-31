using System.ComponentModel;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Comments.Data.Filter;
using Comments.Facebook;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Comments.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional }
                );

            var json = config.Formatters.JsonFormatter;
            //json.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
            // this line make sure the child objects can be returned
            json.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            //json.SerializerSettings.ContractResolver = new AllPropertiesResolver();
            json.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
            json.SerializerSettings.DateParseHandling = DateParseHandling.DateTime;
            json.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
            //json.SerializerSettings.Converters.Add(new IsoDateTimeConverter());
            //json.SerializerSettings.Converters.Add(new TimeSpanConverter());
            json.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            //json.SerializerSettings.TypeNameHandling = TypeNameHandling.Objects;
            //json.SerializerSettings.TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple;

            json.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
            json.SupportedEncodings.Add(Encoding.UTF8);

            //json.SupportedEncodings.RemoveAt(0);

            //json.SupportedEncodings.Add(Encoding.GetEncoding("utf-16", new EncoderReplacementFallback("?"), new DecoderReplacementFallback("?")));
            //json.SupportedEncodings.Add(Encoding.GetEncoding("us-ascii", EncoderFallback.ReplacementFallback, DecoderFallback.ReplacementFallback));
            //json.SupportedEncodings.Add(Encoding.GetEncoding("utf-32BE", EncoderFallback.ReplacementFallback, DecoderFallback.ReplacementFallback));
            //json.SupportedEncodings.Add(Encoding.GetEncoding("utf-32", EncoderFallback.ReplacementFallback, DecoderFallback.ReplacementFallback));
            //json.SupportedEncodings.Add(Encoding.GetEncoding("utf-7", EncoderFallback.ReplacementFallback, DecoderFallback.ReplacementFallback));
            //json.SupportedEncodings.Add(Encoding.GetEncoding("utf-8", EncoderFallback.ReplacementFallback, DecoderFallback.ReplacementFallback));
            //json.SupportedEncodings.Add(Encoding.GetEncoding("gb2312", EncoderFallback.ReplacementFallback, DecoderFallback.ReplacementFallback));
            //json.SupportedEncodings.Add(Encoding.GetEncoding("unicodeFFFE", EncoderFallback.ReplacementFallback, DecoderFallback.ReplacementFallback));
            //json.SupportedEncodings.Add(Encoding.GetEncoding("Windows-1252", EncoderFallback.ReplacementFallback, DecoderFallback.ReplacementFallback));
            //json.SupportedEncodings.Add(Encoding.GetEncoding("x-mac-korean", EncoderFallback.ReplacementFallback, DecoderFallback.ReplacementFallback));
            //json.SupportedEncodings.Add(Encoding.GetEncoding("x-mac-chinesesimp", EncoderFallback.ReplacementFallback, DecoderFallback.ReplacementFallback));
            //json.SupportedEncodings.Add(Encoding.GetEncoding("x-cp20936", EncoderFallback.ReplacementFallback, DecoderFallback.ReplacementFallback));
            //json.SupportedEncodings.Add(Encoding.GetEncoding("x-cp20949", EncoderFallback.ReplacementFallback, DecoderFallback.ReplacementFallback));
            //json.SupportedEncodings.Add(Encoding.GetEncoding("iso-8859-1", EncoderFallback.ReplacementFallback, DecoderFallback.ReplacementFallback));
            //json.SupportedEncodings.Add(Encoding.GetEncoding("iso-8859-8", EncoderFallback.ReplacementFallback, DecoderFallback.ReplacementFallback));
            //json.SupportedEncodings.Add(Encoding.GetEncoding("iso-8859-8-i", EncoderFallback.ReplacementFallback, DecoderFallback.ReplacementFallback));
            //json.SupportedEncodings.Add(Encoding.GetEncoding("iso-2022-jp", EncoderFallback.ReplacementFallback, DecoderFallback.ReplacementFallback));
            //json.SupportedEncodings.Add(Encoding.GetEncoding("csISO2022JP", EncoderFallback.ReplacementFallback, DecoderFallback.ReplacementFallback));
            //json.SupportedEncodings.Add(Encoding.GetEncoding("iso-2022-jp", EncoderFallback.ReplacementFallback, DecoderFallback.ReplacementFallback));
            //json.SupportedEncodings.Add(Encoding.GetEncoding("iso-2022-kr", EncoderFallback.ReplacementFallback, DecoderFallback.ReplacementFallback));
            //json.SupportedEncodings.Add(Encoding.GetEncoding("x-cp50227", EncoderFallback.ReplacementFallback, DecoderFallback.ReplacementFallback));
            //json.SupportedEncodings.Add(Encoding.GetEncoding("euc-jp", EncoderFallback.ReplacementFallback, DecoderFallback.ReplacementFallback));
            //json.SupportedEncodings.Add(Encoding.GetEncoding("EUC-CN", EncoderFallback.ReplacementFallback, DecoderFallback.ReplacementFallback));
            //json.SupportedEncodings.Add(Encoding.GetEncoding("euc-kr", EncoderFallback.ReplacementFallback, DecoderFallback.ReplacementFallback));
            //json.SupportedEncodings.Add(Encoding.GetEncoding("hz-gb-2312", EncoderFallback.ReplacementFallback, DecoderFallback.ReplacementFallback));
            //json.SupportedEncodings.Add(Encoding.GetEncoding("GB18030", EncoderFallback.ReplacementFallback, DecoderFallback.ReplacementFallback));
            //json.SupportedEncodings.Add(Encoding.GetEncoding("x-iscii-de", EncoderFallback.ReplacementFallback, DecoderFallback.ReplacementFallback));
            //json.SupportedEncodings.Add(Encoding.GetEncoding("x-iscii-be", EncoderFallback.ReplacementFallback, DecoderFallback.ReplacementFallback));
            //json.SupportedEncodings.Add(Encoding.GetEncoding("x-iscii-ta", EncoderFallback.ReplacementFallback, DecoderFallback.ReplacementFallback));
            //json.SupportedEncodings.Add(Encoding.GetEncoding("x-iscii-te", EncoderFallback.ReplacementFallback, DecoderFallback.ReplacementFallback));
            //json.SupportedEncodings.Add(Encoding.GetEncoding("x-iscii-as", EncoderFallback.ReplacementFallback, DecoderFallback.ReplacementFallback));
            //json.SupportedEncodings.Add(Encoding.GetEncoding("x-iscii-or", EncoderFallback.ReplacementFallback, DecoderFallback.ReplacementFallback));
            //json.SupportedEncodings.Add(Encoding.GetEncoding("x-iscii-ka", EncoderFallback.ReplacementFallback, DecoderFallback.ReplacementFallback));
            //json.SupportedEncodings.Add(Encoding.GetEncoding("x-iscii-ma", EncoderFallback.ReplacementFallback, DecoderFallback.ReplacementFallback));
            //json.SupportedEncodings.Add(Encoding.GetEncoding("x-iscii-gu", EncoderFallback.ReplacementFallback, DecoderFallback.ReplacementFallback));
            //json.SupportedEncodings.Add(Encoding.GetEncoding("x-iscii-pa", EncoderFallback.ReplacementFallback, DecoderFallback.ReplacementFallback));

            //json.SerializerSettings.Converters.Add(new testUnicodeConverter());
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            // config.Services.Replace(typeof(IExceptionHandler), new UnicodeFilters());


        }
    }
}