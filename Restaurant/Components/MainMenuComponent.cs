using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Components
{
    public class MainMenuComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult<IViewComponentResult>(View("Menu"));
        }
    }
}
