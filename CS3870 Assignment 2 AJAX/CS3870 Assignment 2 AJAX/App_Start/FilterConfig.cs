using System.Web;
using System.Web.Mvc;

namespace CS3870_Assignment_2_AJAX
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
