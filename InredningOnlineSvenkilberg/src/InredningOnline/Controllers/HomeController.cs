using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using InredningOnline.Models;
using InredningOnline.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace InredningOnline.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProjectRepository _projectRepository;
        private readonly IProductRepository _productRepository;       

        public HomeController(ILogger<HomeController> logger, IProjectRepository projectRepository, IProductRepository productRepository)
        {
            _logger = logger;
            _projectRepository = projectRepository;
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize]
        public IActionResult Projects()
        {
            return View(new ProjectsViewModel
            {
                ProjectRepository = _projectRepository,
                ProductRepository = _productRepository
            });
        }

        public IActionResult CreateProject()
        {
            return View();
        }

        
        public IActionResult EditProject(int projectId)
        {            
            // Returns the project with projectId.
            return View(_projectRepository.AllProjects.FirstOrDefault(p => p.ProjectId == projectId));
            
        }

        [HttpPost]
        public IActionResult SaveProject(Project project)
        {
            
            if (ModelState.IsValid)
            {
                _projectRepository.SaveProjectToDataBase(project);
            }
            return RedirectToAction("Projects");
        }        

        public IActionResult DeleteProject(int projectId)
        {
            if (ModelState.IsValid)
            {
                _projectRepository.DeleteProjectInDataBase(projectId);
            }

            return RedirectToAction("Projects");

        }

        public IActionResult CreateProduct(int projectId)
        {
                return View(new CreateProductViewModel
                {                    
                    ProjectId = projectId
                }); ;
        }

        public IActionResult EditProduct(int productId)
        {

            return View(_productRepository.AllProducts.FirstOrDefault(p => p.ProductId == productId));

        }

        [HttpPost]
        public IActionResult SaveProductInProject(int projectId, Product product)
        {
            // Sets the ProjectId property of the product to make it belong
            // to that project.
            product.ProjectId = projectId;

            if(ModelState.IsValid)
            {
                _productRepository.SaveProductToDataBase(product);
            }
            
            return RedirectToAction("Projects");
        }

        [HttpPost]
        public IActionResult SaveProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _productRepository.SaveProductToDataBase(product);
            }
            return RedirectToAction("Projects");
        }

        public IActionResult DeleteProduct(int productId)
        {
            if (ModelState.IsValid)
            {
                _productRepository.DeleteProductInDataBase(productId);
            }

            return RedirectToAction("Projects");

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
