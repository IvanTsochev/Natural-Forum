namespace NaturalForum.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using NaturalForum.Services.Data.Interfaces;
    using NaturalForum.Web.ViewModels.Animal;

    using static Common.NotificationMessagesConstants;

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
            bool animalExist = await this.animalService
                .AnimalExistsByIdAsync(id);

            if (!animalExist)
            {
                TempData[ErrorMessage] = "There was an erro!";

                return RedirectToAction("All", "Animal");
            }

            AnimalDetailsViewModel viewModel = 
                await this.animalService.GetAnimalDetailsAsync(id);

            return View(viewModel);
        }
    }
}
