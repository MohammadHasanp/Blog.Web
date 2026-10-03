using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text.Encodings.Web;

namespace Blog.Web.TagHelpers
{
    public class OpenModal:TagHelper
    {
        public string url { get; set; }
        public string Title { get; set; }
        public string Class { get; set; } = "btn btn-info";
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName="button";
            output.Attributes.Add("Onclick", $"OpenModal('{url}','defult_model','{Title}')");
            output.Attributes.Add("Class",Class);
            base.Process(context, output);
        }
    }
}
