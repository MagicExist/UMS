using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Core;
using UMS.Models;

namespace UMS.ViewModels
{
    internal class AdminHomeVM : ObservableObjects
    {

        List<Request> _requests= new List<Request>();

        public List<Request> Requests 
        {
            get { return _requests; }
            set { _requests = value; OnpropertyChanged(); }
        
        }

        public AdminHomeVM()
        {
            _requests.Add(new Request("2023/10/11", "Problemas con mi Horario", "Kevin Rogers", "Pendiente"));
            _requests.Add(new Request("2023/09/23", "No veo mis clases", "Kevin Rogers", "Solucionada"));
            _requests.Add(new Request("2023/09/15", "Hay un error con la hora de una de mis asignaturas", "Kevin Rogers", "Pendiente"));
            _requests.Add(new Request("2023/08/10", "no me aparece la informacion de la clase", "Kevin Rogers", "Solucionada"));
        }
    }
}
