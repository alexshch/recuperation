using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecuperationGui.Model
{
    internal class ApplicationModel
    {
        private static ApplicationModel _instance;
        private AppConfig _config;
        private ApplicationModel(AppConfig config)
        {
            _config = config;
        }

        public static ApplicationModel GetAplicationModel()
        {
            return _instance ?? (_instance = new ApplicationModel(new AppConfig()));
        }
    }
}
