using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using provider.faculdade.site.WCFUtils;

namespace provider.faculdade.site.Helpers
{
    public class Utils
    {
        public Utils()
        {

        }

        public static bool ValidarCPF(string cpf)
        {
            WCFUtils.ServiceClient proxy = new ServiceClient();
            return proxy.ValidarCpf(cpf);
        }
    }
}