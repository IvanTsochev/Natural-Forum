namespace NaturalForum.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using NaturalForum.Services.Data.Interfaces;
    using NaturalForum.Web.ViewModels.Animal;

    using static Common.NotificationMessagesConstants;

    public class AnimalController : BaseAdminController
    {
        private readonly IAnimalService animalService;

        public AnimalController(IAnimalService animalService)
        {
            this.animalService = animalService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            AnimalFormViewModel viewModel = new AnimalFormViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AnimalFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = "Error! Try again!";
                return View(model);
            }

            try
            {
                await this.animalService.CreateAnimalAsync(model);

                TempData[InformationMessage] = "Animal was added successfully!";
                return RedirectToAction("All", "Animal", new { area = "" });
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Error while creating an entity!";

                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await this.animalService.DeleteAnimalAsync(id);

                TempData[InformationMessage] = "Animal was deleted successfully!";
                return RedirectToAction("All", "Animal", new { area = "" });
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Error while deleting!";

                return RedirectToAction("All", "Animal", new { area = "" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                AnimalEditViewModel viewModel = await this.animalService
                .GetAnimalForEditAsync(id);

                return View(viewModel);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Error while loading!";
                return RedirectToAction("All", "Animal", new { area = "" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AnimalEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = "Error! Try again!";
                return View(model);
            }

            try
            {
                await this.animalService.EditAnimalAsync(model);

                TempData[InformationMessage] = "Animal was edited successfully!";
                return RedirectToAction("Details", "Animal", new { id = model.Id, area = "" });
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Error while editing!";

                return RedirectToAction("All", "Animal", new { area = "" });
            }
        }
    }
}
