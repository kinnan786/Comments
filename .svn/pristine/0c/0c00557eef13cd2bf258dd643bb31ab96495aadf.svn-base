using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using Comments.Facebook;
using Comments.Facebook.Model;
using FacebookPost = Comments.Facebook.Model.FacebookPost;

namespace Comments.Console
{
    internal class Program
    {
        public static List<FacebookComment> GetAllFacebookPostComments(
            string postId = "146505212039213_2464275336928844", string accesstoken =
                "EAACEdEose0cBACdtZB9WceN0NZAXJy6ZAERvZAIFWYEL2cZCFPdZBAS7OaZAEF2lx6lp4cNZB987c9rNhrSyZAdFZAj7eTamfSPROPZBy0XWnhJaZBoUKZBVUwgFAkd3wOIK7myy3hjEyGg0ZBuobdnobsiGfpJZBxm5ztRwqSXonyFtoxxTQZDZD")
        {
            var lstFacebookComments = new List<FacebookComment>();
            var facebookCommentserror = new FacebookError();

            var graphapi = new GraphApi(accesstoken);
            var graphapiurl = graphapi.PostComments(postId);

            var res = new GraphApiResponse();
            var response = res.GetResponse(graphapiurl);

            var serializer = new JavaScriptSerializer();

            try
            {
                var facebookCommentsDataset = serializer.Deserialize<FacebookComments>(response);

                if (facebookCommentsDataset.data == null)
                {
                    facebookCommentserror = serializer.Deserialize<FacebookError>(response);

                    if (facebookCommentserror.error != null)
                    {
                        // Login status or access token has expired, been revoked, or is otherwise invalid. Handle expired access tokens.
                        // Access token has expired
                        if (facebookCommentserror.error.code == "190" &&
                            facebookCommentserror.error.error_subcode == "463")
                        {
                            //Get new Access Token
                        }
                    }
                }
                else
                {
                    string next = null;
                    do
                    {
                        if (facebookCommentsDataset.data != null)
                        {
                            lstFacebookComments.AddRange(facebookCommentsDataset.data);
                        }

                        if (facebookCommentsDataset.paging != null)
                        {
                            if (!string.IsNullOrEmpty(facebookCommentsDataset.paging.next))
                            {
                                next = facebookCommentsDataset.paging.next;
                                response = res.GetResponse(next);
                                facebookCommentsDataset = serializer.Deserialize<FacebookComments>(response);
                                if (facebookCommentsDataset.data == null)
                                {
                                    facebookCommentserror = serializer.Deserialize<FacebookError>(response);

                                    if (facebookCommentserror.error != null)
                                    {
                                        // Login status or access token has expired, been revoked, or is otherwise invalid. Handle expired access tokens.
                                        // Access token has expired
                                        if (facebookCommentserror.error.code == "190" &&
                                            facebookCommentserror.error.error_subcode == "463")
                                        {
                                            //Get new Access Token
                                            //than start from where left off
                                        }
                                    }
                                    break;
                                }
                            }
                            else
                            {
                                next = null;
                            }
                        }
                    } while (next != null);
                }
                return lstFacebookComments;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static FacebookPost GetFacebookPost(string postId = "146505212039213_2464275336928844",
            string accesstoken =
                "EAACEdEose0cBACdtZB9WceN0NZAXJy6ZAERvZAIFWYEL2cZCFPdZBAS7OaZAEF2lx6lp4cNZB987c9rNhrSyZAdFZAj7eTamfSPROPZBy0XWnhJaZBoUKZBVUwgFAkd3wOIK7myy3hjEyGg0ZBuobdnobsiGfpJZBxm5ztRwqSXonyFtoxxTQZDZD")
        {
            try
            {
                var facebookpost = new FacebookPost();
                var facebookCommentserror = new FacebookError();

                var graphapi = new GraphApi(accesstoken);
                var graphapiurl = graphapi.PostsUrl(postId);

                var res = new GraphApiResponse();
                var response = res.GetResponse(graphapiurl);

                var serializer = new JavaScriptSerializer();
                facebookpost = serializer.Deserialize<FacebookPost>(response);

                if (facebookpost == null)
                {
                    facebookCommentserror = serializer.Deserialize<FacebookError>(response);

                    if (facebookCommentserror.error != null)
                    {
                        // Login status or access token has expired, been revoked, or is otherwise invalid. Handle expired access tokens.
                        // Access token has expired
                        if (facebookCommentserror.error.code == "190" &&
                            facebookCommentserror.error.error_subcode == "463")
                        {
                            //Get new Access Token
                        }
                    }
                }
                return facebookpost;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static FacebookReactions GetFacebookPostReactions(string postId = "146505212039213_2464275336928844",
            string accesstoken =
                "EAACEdEose0cBACdtZB9WceN0NZAXJy6ZAERvZAIFWYEL2cZCFPdZBAS7OaZAEF2lx6lp4cNZB987c9rNhrSyZAdFZAj7eTamfSPROPZBy0XWnhJaZBoUKZBVUwgFAkd3wOIK7myy3hjEyGg0ZBuobdnobsiGfpJZBxm5ztRwqSXonyFtoxxTQZDZD")
        {
            try
            {
                var facebookpostreactions = new FacebookReactions();
                var facebookCommentserror = new FacebookError();

                var graphapi = new GraphApi(accesstoken);
                var graphapiurl = graphapi.PostsReactionsUrl(postId);

                var res = new GraphApiResponse();
                var response = res.GetResponse(graphapiurl);

                var serializer = new JavaScriptSerializer();
                facebookpostreactions = serializer.Deserialize<FacebookReactions>(response);

                if (facebookpostreactions == null)
                {
                    facebookCommentserror = serializer.Deserialize<FacebookError>(response);

                    if (facebookCommentserror.error != null)
                    {
                        // Login status or access token has expired, been revoked, or is otherwise invalid. Handle expired access tokens.
                        // Access token has expired
                        if (facebookCommentserror.error.code == "190" &&
                            facebookCommentserror.error.error_subcode == "463")
                        {
                            //Get new Access Token
                        }
                    }
                }
                return facebookpostreactions;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private static void Main(string[] args)
        {
            // GetAllFacebookPostComments();

            var text = "😂😂😂";
            string unicodeString = "This string contains the unicode character Pi (\u03a0\u03a0\u03a0)";

            // Create two different encodings.
            Encoding ascii = Encoding.ASCII;
            Encoding unicode = Encoding.Unicode;

            // Convert the string into a byte array.
            byte[] unicodeBytes = unicode.GetBytes(unicodeString);

            // Perform the conversion from one encoding to the other.
            byte[] asciiBytes = Encoding.Convert(unicode, ascii, unicodeBytes);

            // Convert the new byte[] into a char[] and then into a string.
            char[] asciiChars = new char[ascii.GetCharCount(asciiBytes, 0, asciiBytes.Length)];
            ascii.GetChars(asciiBytes, 0, asciiBytes.Length, asciiChars, 0);
            string asciiString = new string(asciiChars);

            // Display the strings created before and after the conversion.
            System.Console.WriteLine("Original string: {0}", unicodeString);
            System.Console.WriteLine("Ascii converted string: {0}", asciiString);

        }


        private static void Analyze(List<FacebookComment> lstFacebookComments)
        {
            var Total_Comments = lstFacebookComments.Count;
            var Mostliked_comments = lstFacebookComments.OrderByDescending(q => q.like_count).ToList();
            var mostRepliedcomment = lstFacebookComments.OrderByDescending(q => q.comment_count).ToList();
            var mostrecentcomments = lstFacebookComments.OrderByDescending(q => q.created_time).ToList();
            var mostoldcomments = lstFacebookComments.OrderBy(q => q.created_time).ToList();
        }
    }
}