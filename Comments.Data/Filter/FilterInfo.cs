namespace Comments.Data.Filter
{
    public enum FilterOperations
    {
        Eq,
        Neq,
        Gt,
        Gte,
        Lt,
        Lte,
        StartsWith,
        EndsWith,
        Contains,
        DoesNotContain
    }

    public enum LogicalOperations
    {
        And,
        Or
    }

    public class FilterInfo
    {
        public string Field { get; set; }
        public FilterOperations Operator { get; set; }
        public string Value { get; set; }

        public static FilterOperations ParseOperator(string theOperator)
        {
            switch (theOperator)
            {
                //equal ==
                case "eq":
                case "==":
                case "isequalto":
                case "equals":
                case "equalto":
                case "equal":
                    return FilterOperations.Eq;
                //not equal !=
                case "neq":
                case "!=":
                case "isnotequalto":
                case "notequals":
                case "notequalto":
                case "notequal":
                case "ne":
                    return FilterOperations.Neq;
                // Greater
                case "gt":
                case ">":
                case "isgreaterthan":
                case "greaterthan":
                case "greater":
                    return FilterOperations.Gt;
                // Greater or equal
                case "gte":
                case ">=":
                case "isgreaterthanorequalto":
                case "greaterthanequal":
                case "ge":
                    return FilterOperations.Gte;
                // Less
                case "lt":
                case "<":
                case "islessthan":
                case "lessthan":
                case "less":
                    return FilterOperations.Lt;
                // Less or equal
                case "lte":
                case "<=":
                case "islessthanorequalto":
                case "lessthanequal":
                case "le":
                    return FilterOperations.Lte;
                case "startswith":
                    return FilterOperations.StartsWith;

                case "endswith":
                    return FilterOperations.EndsWith;
                //string.Contains()
                case "contains":
                    return FilterOperations.Contains;
                case "doesnotcontain":
                    return FilterOperations.DoesNotContain;
                default:
                    return FilterOperations.Contains;
            }
        }
    }
}