using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Text.RegularExpressions;

namespace QBNsite.Helper
{

    public class Helper
    {
        private readonly IWebAssemblyHostEnvironment _env;
        public Helper(IWebAssemblyHostEnvironment hostEnvironment)
        {
            _env = hostEnvironment;
        }

        public string homePath => _env.IsDevelopment() ? "" : "/QuocBaoNguyen/";

        public string StripHtml(string input)
        {

            return Regex.Replace(input, "<.*?>", string.Empty);
        }
    }
    public class CardInfo
    {
        public string id = "card id";
        public string Title = "Card Title";
    }

}
