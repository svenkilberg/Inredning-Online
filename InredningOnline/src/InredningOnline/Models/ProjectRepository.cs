using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InredningOnline.Models
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProjectRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // Add usernames to this array to give them purchaser rights.
        // The application does not use roles from Identity Framework.
        // This is used in the view to list all projects and other information
        // that is special to purchasers.
        public IEnumerable<string> UsersThatArePurchasers => new string[] { "ingrid@ballong.se" };
        

        public IEnumerable<Project> AllProjects
        {
            get
            {
                return _appDbContext.Projects;
            }
        }        

        public IEnumerable<Project> GetProjectsByOwner(string userName)
        {
            // If the username is part of the purchasers list all projects are returned.
            // For other users only the projects that have that user set as owner is returned.
            if (UsersThatArePurchasers.FirstOrDefault(u => u == userName) != null)
            {
                return _appDbContext.Projects;
            }

            return _appDbContext.Projects.Where(p => p.ProjectOwner == userName);
        }

        public double GetAverageCostAllProjects()
        {            
            // The total cost of all projects are divided by the total number of projects.
            return Math.Round((GetTotalCostAllProjects() / AllProjects.ToList().Count()), 2);
        }

        public double GetProjectTotalCost(int projectId)
        {   
            // Calculates the total cost of one singel project

            var totalProjectCost = 0.0;

            // Retrieves all products that have the specified project id and adds price of each of them
            // to a total sum.
            foreach (var product in _appDbContext.Products.Where(p => p.ProjectId == projectId))
            {
                totalProjectCost += product.ProductTotalPrice;
            }

            // Retrieves the project from database
            var projectFromDb = _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == projectId);

            // Updates the field for total cost.
            projectFromDb.ProjectTotalPrice = totalProjectCost;

            // Stores the project back to database.
            SaveProjectToDataBase(projectFromDb);

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

        public void SaveProjectToDataBase(Project project)
        {
            if (_appDbContext.Projects.AsNoTracking().FirstOrDefault(p => p.ProjectId == project.ProjectId) != null) // Check if project with same id exists in the database.
            {
                _appDbContext.Projects.Update(project); // Updates the exisitng project.
            }
            else
            {
                _appDbContext.Projects.Add(project); // Add a new project.
            }

            _appDbContext.SaveChanges();
        }        

        public void DeleteProjectInDataBase(int projektId)
        {
            var projectInDatabase = _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == projektId);

            _appDbContext.Projects.Remove(projectInDatabase);

            _appDbContext.SaveChanges();
        }

        
    }
}
