using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;
using Comments.Facebook.Model;
using Comments.Web.Models;

namespace Comments.Web.Controllers.WebApi.Facebook
{
    public class CommentsController : ApiController
    {
        public List<FacebookCommentViewModel> Get(int order, string search = "", string startDate = "",
            string endDate = "")
        {
            try
            {
                Debugger.Launch();
                var comments = (List<FacebookComment>)HttpContext.Current.Session["facebookcomment"];

                List<FacebookComment> commentsSorted;

                if (comments == null || comments.Count < 1)
                    return new List<FacebookCommentViewModel>();

                if (true)
                {
                    comments = comments.Where(q => q.message_tags.Length == 0).ToList();
                }

                if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
                {
                    var fromDateTime = DateTime.Parse(startDate);
                    var toDateTime = DateTime.Parse(endDate).Date + new TimeSpan(23, 59, 59);

                    comments = comments.Where(q => q.created_time >= fromDateTime && q.created_time <= toDateTime).ToList();
                }
                else
                    return new List<FacebookCommentViewModel>();


                if (!string.IsNullOrEmpty(search))
                {
                    var tempComments = new List<FacebookComment>();

                    foreach (var facebookComment in comments)
                    {
                        if (!string.IsNullOrWhiteSpace(facebookComment.message.ToLower()) ||
                            facebookComment.message.ToLower() != "")
                        {
                            var flag = facebookComment.message.ToLower().Contains(search.ToLower());
                            if (flag)
                            {
                                tempComments.Add(facebookComment);
                            }
                        }
                        //if (facebookComment.comments != null)
                        //{
                        //    if (facebookComment.comments.data != null)
                        //    {
                        //        var replies =
                        //            facebookComment.comments.data.Count(
                        //                q => search.ToLower().Contains(q.message.ToLower()) && q.attachment == null);

                        //        if (replies > 0)
                        //        {
                        //            if (!tempComments.Contains(facebookComment))
                        //                tempComments.Add(facebookComment);
                        //        }
                        //    }
                        //}
                    }
                    comments = tempComments;
                }


                switch (order)
                {
                    case 1:
                        commentsSorted = comments.OrderByDescending(q => q.like_count).ToList();
                        break;
                    case 2:
                        commentsSorted = comments.OrderByDescending(q => q.comment_count).ToList();
                        break;
                    case 3:
                        commentsSorted = comments.OrderByDescending(q => q.created_time).ToList();
                        break;
                    case 4:
                        commentsSorted = comments.OrderBy(q => q.created_time).ToList();
                        break;
                    default:
                        commentsSorted = comments.OrderByDescending(q => q.like_count).ToList();
                        break;
                }

                var lstcommentViewModel = new List<FacebookCommentViewModel>();

                if (commentsSorted != null)
                {
                    foreach (var mostLikedComment in commentsSorted)
                    {
                        var commentViewModel = new FacebookCommentViewModel
                        {
                            CommentId = mostLikedComment.id,
                            Message = mostLikedComment.message,
                            FromName = mostLikedComment.from.name,
                            FromId = mostLikedComment.from.id,
                            CreatedOn = mostLikedComment.created_time,
                            Frompic = mostLikedComment.from.picture.data.url,
                            Likes = mostLikedComment.like_count
                        };

                        //begin messagetags 

                        if (mostLikedComment.message_tags != null)
                        {
                            var lsttuple = new List<Tuple<int, int, string>>();

                            foreach (var messageTag in mostLikedComment.message_tags)
                            {
                                var link = "<a href='http://www.facebook.com/" + messageTag.id + "' target='blank'>" +
                                           messageTag.name + "</a>";

                                var tuple = new Tuple<int, int, string>(Convert.ToInt32(messageTag.length),
                                    Convert.ToInt32(messageTag.offset), link);

                                lsttuple.Add(tuple);
                            }

                            for (var i = 0; i < lsttuple.Count; i++)
                            {
                                var length = Convert.ToInt32(lsttuple[i].Item1);
                                var newoffset = 0;

                                // count all the previuse tagged offset
                                for (var j = i - 1; j >= 0; j--)
                                {
                                    //add the length of the new link minus the length of the previuse tag
                                    newoffset += lsttuple[j].Item3.Length - lsttuple[j].Item1;
                                }

                                //also add the current message tag offset
                                newoffset += Convert.ToInt32(lsttuple[i].Item2);


                                //incase users has tagged same user/page multiple times the below logic will fail
                                if (newoffset < commentViewModel.Message.Length)
                                {
                                    var foundtag = commentViewModel.Message.Substring(newoffset, length);
                                    commentViewModel.Message = commentViewModel.Message.Replace(foundtag,
                                        lsttuple[i].Item3);
                                }
                            }
                        }

                        //end messagetags 


                        if (mostLikedComment.comments != null)
                        {
                            if (mostLikedComment.comments.data != null)
                            {
                                commentViewModel.Replies = mostLikedComment.comments.data.Length;
                            }
                        }

                        if (mostLikedComment.attachment != null)
                        {
                            commentViewModel.CommentAttachmentUrl = mostLikedComment.attachment.media.image.src;
                            commentViewModel.AttachmentType = mostLikedComment.attachment.type;
                        }


                        lstcommentViewModel.Add(commentViewModel);
                    }
                }

                return lstcommentViewModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}