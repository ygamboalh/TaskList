using Microsoft.AspNetCore.Components;

namespace TaskListFrontEnd.Helpers
{
    public class ComponentDiv : ComponentBase
    {
        public string DivId = "div";
        [Parameter] public bool ShowDiv { get; set; }

        string DisplayStyle => ShowDiv ? "block" : "none";

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        void ToggleDiv()
        {
            ShowDiv = !ShowDiv;
        }
    }
}
