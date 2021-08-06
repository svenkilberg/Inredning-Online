using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InredningOnline
{
    public interface IProjectRepository
    {        
        IEnumerable<Project> AllProjects { get; }

        IEnumerable<string> UsersThatArePurchasers { get; } // Usernames stored in this list are filtered out to as users with purchaser rights.
        IEnumerable<Project> GetProjectsByOwner(string userName);
        double GetProjectTotalCost(int projectId);

        double GetTotalCostAllProjects();

        double GetAverageCostAllProjects();       

        void SaveProjectToDataBase(Project project);

        //void UpdateProjectToDataBase(Project project);

        void DeleteProjectInDataBase(int projectId);
    }
}
