namespace NaturalForum.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using NaturalForum.Services.Data.Interfaces;
    using NaturalForum.Web.ViewModels.Animal;

    public class AnimalController : Controller
    {
        private readonly IAnimalService animalService;

        public AnimalController(IAnimalService animalService)
        {
            this.animalService = animalService;
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<AnimalViewModel> viewModel = 
                await this.animalService.AllAnimalsAsync();

            return View(viewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            AnimalDetailsViewModel viewModel = 
                await this.animalService.GetAnimalDetailsAsync(id);

            return View(viewModel);
        }
    }
}
