using System;
using Xunit;

namespace InredningOnline.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void ProjectRepositoryGetProjectTotalCostTest()
        {
            // Send the projectId to GetTotalProjectCost.
            // Assert that the total project cost is the same as the total cost of the products with same product id.
            // See MockProductRepository AllProducts.

            // Arrange

            MockProjectRepository mockProjectRepository = new MockProjectRepository();

            var projectIdToGet = 1;
            var project1TotalCost = 400;
            var project2TotalCost = 2200;


            // Act

            var totalProjectCost = mockProjectRepository.GetProjectTotalCost(projectIdToGet);

            // Asert

            Assert.Equal(project1TotalCost, totalProjectCost);
        }

        [Fact]
        public void ProjectRepositoryGetTotalCostAllProjectsTest()
        {
            // Get the total cost of all projects.
            // Assert that the return is the same as the sum of all projects.
            // See MockProjectRepository and MockProductRepository.

            // Arange
            MockProjectRepository mockProjectRepository = new MockProjectRepository();

            var totalCostAllProjects = 2600;

            // Act

            var totalProjectCostAllProjects = mockProjectRepository.GetTotalCostAllProjects();

            // Asert

            Assert.Equal(totalCostAllProjects, totalProjectCostAllProjects);
        }

        [Fact]
        public void ProjectRepositoryGetAverageCostAllProjectsTest()
        {
            // Arrange

            // Get the average cost of all projects.
            // Assert that the return is the same as the sum of all projects.
            // See MockProjectRepository and MockProductRepository

            MockProjectRepository mockProjectRepository = new MockProjectRepository();

            var project1TotalCost = 400.0;
            var project2TotalCost = 2200.0;

            // Act

            var avarageProjectCostAllProjects = mockProjectRepository.GetAverageCostAllProjects();

            // Assert

            Assert.Equal((project1TotalCost + project2TotalCost) / 2, avarageProjectCostAllProjects); 

        }        
    }
}
