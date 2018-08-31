using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Comments.Facebook.Model.NotUsed
{
    [Table("LeftMenu")]
    public class LeftMenu
    {
        [Key]
        public int Id { get; set; }

        public string action { get; set; }

        public string controller { get; set; }

        public string imageClass { get; set; }

        public string imageurl { get; set; }

        public bool? isParent { get; set; }

        public string Name { get; set; }

        public short parentId { get; set; }

        public string routvalue { get; set; }

        public bool? status { get; set; }
    }
}