namespace NaturalForum.Services.Data.Interfaces
{
    using NaturalForum.Web.ViewModels.Animal;
    public interface IAnimalService
    {
        Task<IEnumerable<AnimalViewModel>> AllAnimalsAsync();
    }
}
