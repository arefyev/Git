using Microsoft.Practices.Unity;
using System.Collections.Generic;

namespace ADV.Data
{
    public sealed class DataContext
    {
        #region - Variables -
        IRepository _repository;
        #endregion

        #region - Contructors -
        public DataContext(IRepository repository)
        {
            _repository = repository;
        }
        #endregion

        #region - Methods -
        public static IEnumerable<ProjectDto> ListProjects(string lang)
        {
            var dev = Configuration.Instance.Container.Resolve<DataContext>();
            return dev._repository.ListProjects(lang);
        }
        #endregion
    }
}
