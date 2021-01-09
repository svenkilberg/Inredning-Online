using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InredningOnline
{
    public class MockProjectRepository : IProjectRepository
    {
        // This MockProjectRepository is used by the testing framework.

        private readonly IProductRepository _productRepository = new MockProductRepository();
        

        // This collection is used by the unit tests.
        public IEnumerable<Project> AllProjects => 
            new List<Project>
            {
                new Project
                {
                    ProjectId = 1,
                    ProjectOwner = "kalle@ballong.se",
                    ProjectName = "Nya kontoret"                    
                },
                
                new Project
                {
                    ProjectId = 2,
                    ProjectOwner = "anka@ballong.se",
                    ProjectName = "Matsalen"
                }
            };

        // Add usernames to this array to give them purchaser rights.
        // The application does not use roles from Identity Framework.
        // This is used in the view to list all projects and other information
        // that is special to purchasers.
        public IEnumerable<string> UsersThatArePurchasers => new string[] { "ingrid@ballong.se" };

        public IEnumerable<Project> GetProjectsByOwner(string userName)
        {
            // If the username is part of the purchasers list all projects are returned.
            // For other users only the projects that have that user set as owner is returned.
            if (UsersThatArePurchasers.FirstOrDefault(u => u == userName) != null)
            {
                return AllProjects;
            }

            return AllProjects.Where(p => p.ProjectOwner == userName);
        }

        public double GetAverageCostAllProjects()
        {
            AllProjects.ToList();

            return GetTotalCostAllProjects() / AllProjects.Count();
        }

        public double GetProjectTotalCost(int projectId)
        {            
            var totalProjectCost = 0.0;

            // Retrieves all products that have the specified project id and adds price of each of them
            // to a total sum.
            foreach (var product in _productRepository.AllProducts.Where(p => p.ProjectId == projectId))
            {
                totalProjectCost += product.ProductTotalPrice;
            }

            // Retrieves the project from database. (From collection in this case)
            var projectFromDb = AllProjects.FirstOrDefault(p => p.ProjectId == projectId);

            // Updates the field for total cost.
            projectFromDb.ProjectTotalPrice = totalProjectCost;            

            return totalProjectCost;
        }

        public double GetTotalCostAllProjects()
        {
            // Calulates the total cost of all projects.

            var totalCostAllProjects = 0.0;

            // Retrieves all projects using the AllProjects field.
            // Adds the total cost for all projects using the individual total cost by
            // the GetProjectTotalCost method.
            foreach (var project in AllProjects)
            {
                totalCostAllProjects += GetProjectTotalCost(project.ProjectId);
            }

            return Math.Round(totalCostAllProjects, 2);
        }      

        public void SaveProjectToDataBase(int ProjectId)
        {
            throw new NotImplementedException();
        }

        public void SaveProjectToDataBase(Project project)
        {
            throw new NotImplementedException();
        }        

        public void DeleteProjectInDataBase(int projectId)
        {
            throw new NotImplementedException();
        }

        
    }
}
