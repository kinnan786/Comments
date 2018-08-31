namespace Comments.Data.Filter
{
    public class SearchParams
    {
        public bool Search { get; set; }
        public string Filters { get; set; }
        public int Nd { get; set; }
        public int Page { get; set; }
        public int Rows { get; set; }
        public string SearchField { get; set; }
        public string SearchOper { get; set; }
        public string SearchString { get; set; }
        public string Sidx { get; set; }
        public string Sord { get; set; }
        public string Oper { get; set; }
    }
}