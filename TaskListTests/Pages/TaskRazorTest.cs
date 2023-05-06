using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Bunit;

namespace TaskListTests.Pages
{
    public class TaskRazorTest : TestContext
    {
        [Fact]
        public void Button_Add_Must_Show() 
        {
            var cut = RenderComponent<TaskListFrontEnd.Pages.Task>();
            cut.Find("input").MarkupMatches("<input type=\"text\" id=\"inputTexto\" autocomplete=\"off\" placeholder=\"Type to add new task\" maxlength=80 class=\"input-task\"/>");
        }
        [Fact]
        public void ButtonPlus_Must_Show()
        {
            var cut = RenderComponent<TaskListFrontEnd.Pages.Task>();
            cut.Find("button").MarkupMatches("<button class=\"plus-button\"><span class=\"plus-container\"><img class=\"plus-image\" src=/Resources/Images/plus-square.svg /></span></button>");
        }
        [Fact]
        public void Avatar_Must_Show()
        {
            var cut = RenderComponent<TaskListFrontEnd.Pages.Task>();
            cut.FindAll("img").FirstOrDefault(x => x.Id =="avatar").MarkupMatches("<img id=\"avatar\" class=\"avatar\" src=\"Resources/Images/avatar.png\"/>");
        }
        [Fact]
        public void ButtonCancel_Must_Show()
        {
            var cut = RenderComponent<TaskListFrontEnd.Pages.Task>();
            cut.FindAll("button").FirstOrDefault(x => x.Id == "cancel").MarkupMatches("<button id=\"cancel\" class=\"cancel-button none-display\"><span>Cancel</span></button>");
        }
        [Fact]
        public void ButtonOK_Must_Show()
        {
            var cut = RenderComponent<TaskListFrontEnd.Pages.Task>();
            cut.FindAll("button").FirstOrDefault(x => x.Id == "buttonOK").MarkupMatches("<button id=\"buttonOK\" class=\"ok-button none-display-button\"><span class=\"none-display\">OK</span></button>");
        }
    }
}
