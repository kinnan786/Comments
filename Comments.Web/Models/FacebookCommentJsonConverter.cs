using System;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Comments.Web.Models
{
    public class FacebookCommentJsonConverter : JsonConverter
    {
        private static long _index;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            try
            {
                var guid = (FacebookCommentViewModel)value;

                _index += 1;
                var obj = new JObject
                {
                    {"$id", _index},
                    {"AttachmentType", guid.AttachmentType},
                    {"CommentAttachmentUrl", guid.CommentAttachmentUrl},
                    {"CommentId", guid.CommentId},
                    {"CreatedOn", guid.CreatedOn},
                    {"FromId", guid.FromId},
                    {"Frompic", guid.Frompic},
                    {"Likes", guid.Likes},
                    {"Replies", guid.Replies},
                    {"Message", IsUnicodeConversionPossible(guid.Message) ? guid.Message : ""},
                    {"FromName", IsUnicodeConversionPossible(guid.FromName) ? guid.FromName : ""}
                };


                serializer.Serialize(writer, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool IsUnicodeConversionPossible(string unistring)
        {
            var utf8 = Encoding.GetEncoding(
                "utf-8",
                new EncoderExceptionFallback(),
                new DecoderExceptionFallback());

            var encodedBytes = new byte[utf8.GetMaxByteCount(unistring.Length)];

            try
            {
                utf8.GetBytes(unistring, 0, unistring.Length,
                    encodedBytes, 0);
                return true;
            }
            catch (EncoderFallbackException)
            {
                return false;
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            try
            {
                return objectType == typeof(FacebookCommentViewModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}