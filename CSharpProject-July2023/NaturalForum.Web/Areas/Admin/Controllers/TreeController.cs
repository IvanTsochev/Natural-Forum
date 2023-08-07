namespace NaturalForum.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using NaturalForum.Services.Data.Interfaces;
    using NaturalForum.Web.ViewModels.Tree;
    using static NaturalForum.Common.NotificationMessagesConstants;

    public class TreeController : BaseAdminController
    {
        private readonly ITreeService treeService;

        public TreeController(ITreeService treeService)
        {
            this.treeService = treeService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            TreeFormViewModel viewModel = new TreeFormViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TreeFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = "Error! Try again!";
                return View(model);
            }

            try
            {
                await this.treeService.CreateTreeAsync(model);

                TempData[InformationMessage] = "Tree was added successfully!";
                return RedirectToAction("All", "Tree", new { area = "" });
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
                await this.treeService.DeleteTreeAsync(id);

                TempData[InformationMessage] = "Tree was deleted successfully!";
                return RedirectToAction("All", "Tree", new { area = "" });
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Error while deleting!";

                return RedirectToAction("All", "Tree", new { area = "" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                TreeEditViewModel viewModel = await this.treeService
                .GetTreeForEditAsync(id);

                return View(viewModel);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Error while loading!";
                return RedirectToAction("All", "Tree", new { area = "" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TreeEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = "Error! Try again!";
                return View(model);
            }

            try
            {
                await this.treeService.EditTreeAsync(model);

                TempData[InformationMessage] = "Tree was edited successfully!";
                return RedirectToAction("Details", "Tree", new { id = model.Id, area = "" });
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Error while editing!";

                return RedirectToAction("All", "Tree", new { area = "" });
            }
        }
    }
}
