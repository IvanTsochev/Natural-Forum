namespace NaturalForum.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using Services.Data.Interfaces;
    using Web.ViewModels.Animal;

    using static Common.NotificationMessagesConstants;
    using static Common.GeneralApplicationConstants;

    public class AnimalController : Controller
    {
        private readonly IAnimalService animalService;
        private readonly IMemoryCache memoryCache;

        public AnimalController(IAnimalService animalService
            ,IMemoryCache memoryCache)
        {
            this.animalService = animalService;
            this.memoryCache = memoryCache;

        }

        public async Task<IActionResult> All()
        {
            IEnumerable<AnimalViewModel> animals = this.memoryCache
                .Get<IEnumerable<AnimalViewModel>>(AnimalCacheKey);

            if (animals == null)
            {
                animals = await this.animalService
                    .AllAnimalsAsync();

                MemoryCacheEntryOptions cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(WikiCacheDurationMinutes));

                this.memoryCache.Set(AnimalCacheKey, animals, cacheOptions);
            }

            return View(animals);
        }

        public async Task<IActionResult> Details(int id)
        {
            bool animalExist = await this.animalService
                .AnimalExistsByIdAsync(id);

            if (!animalExist)
            {
                TempData[ErrorMessage] = "We do not found this animal! Try again, later!";

                return RedirectToAction("All", "Animal");
            }

            AnimalDetailsViewModel viewModel = 
                await this.animalService.GetAnimalDetailsAsync(id);

            return View(viewModel);
        }
    }
}
