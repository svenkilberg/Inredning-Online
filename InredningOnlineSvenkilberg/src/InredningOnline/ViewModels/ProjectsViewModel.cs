using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InredningOnline.ViewModels
{
    public class ProjectsViewModel
    {
        public IProjectRepository ProjectRepository { get; set; }
        public IProductRepository ProductRepository { get; set; }
        
    }
}
