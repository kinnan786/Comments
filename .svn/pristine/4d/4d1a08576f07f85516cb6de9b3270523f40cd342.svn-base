using System.Web;
using Comments.Data.Uow;

namespace Comments.Web.DbContext
{
    public class WebUow : Uow
    {
        public static Uow Instance
        {
            get
            {
                var current = (Uow)HttpContext.Current.Items["Uow"]; //one Uow per Request
                if (current == null)
                {
                    HttpContext.Current.Items["Uow"] = current = new Uow();
                }
                return current;
            }
        }
    }
}