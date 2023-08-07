namespace NaturalForum.Services.Data.Interfaces
{
    using Web.ViewModels.Animal;
    public interface IAnimalService
    {
        Task<IEnumerable<AnimalViewModel>> AllAnimalsAsync();

        Task<AnimalDetailsViewModel> GetAnimalDetailsAsync(int id);

        Task<bool> AnimalExistsByIdAsync(int id);

        Task CreateAnimalAsync(AnimalFormViewModel model);

        Task DeleteAnimalAsync(int id);

        Task<AnimalEditViewModel> GetAnimalForEditAsync(int articleId);

        Task EditAnimalAsync(AnimalEditViewModel model);
    }
}
