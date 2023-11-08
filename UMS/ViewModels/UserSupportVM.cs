﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UMS.Core;
using UMS.Models;

namespace UMS.ViewModels
{
    internal class UserSupportVM : ObservableObjects
    {

		List<Request> requests= new List<Request>();
        public List<Request> Requests
		{
			get
			{
				return requests;
			}
			set 
			{
				requests = value;
				OnpropertyChanged();
			} 
		}

        private Visibility _listRequestVisibility;
		public Visibility ListRequestVisibility
        {
			get { return _listRequestVisibility; }
			set 
			{
                _listRequestVisibility = value;
				OnpropertyChanged();
			}
		}

		private Visibility _newRequestVisibility;
		public Visibility NewRequestVisibility
		{
			get { return _newRequestVisibility; }
			set 
			{
                _newRequestVisibility = value; 
				OnpropertyChanged();
			}
		}

		public RelayCommand newRequest { get; set; }
		public RelayCommand cancelRequest { get; set; }
		public RelayCommand sendRequest { get; set; }
        

        public UserSupportVM()
		{
			NewRequestVisibility= Visibility.Collapsed;
			newRequest = new RelayCommand(MakeRequest);
			cancelRequest = new RelayCommand(CancelRequest);
			sendRequest = new RelayCommand(SendRequest);


			Requests.Add(new Request("2023/10/11","Problemas con mi Horario","Kevin Rogers","Pendiente"));
			Requests.Add(new Request("2023/09/23", "No veo mis clases", "Kevin Rogers", "Solucionada")); 
			Requests.Add(new Request("2023/09/15", "Hay un error con la hora de una de mis asignaturas", "Kevin Rogers", "Pendiente"));
			Requests.Add(new Request("2023/08/10", "no me aparece la informacion de la clase", "Kevin Rogers", "Solucionada"));
            Requests.Add(new Request("2023/10/11", "Problemas con mi Horario", "Kevin Rogers", "Pendiente"));
            Requests.Add(new Request("2023/09/23", "No veo mis clases", "Kevin Rogers", "Solucionada"));
            Requests.Add(new Request("2023/09/15", "Hay un error con la hora de una de mis asignaturas", "Kevin Rogers", "Pendiente"));
            Requests.Add(new Request("2023/08/10", "no me aparece la informacion de la clase", "Kevin Rogers", "Solucionada"));
            Requests.Add(new Request("2023/10/11", "Problemas con mi Horario", "Kevin Rogers", "Pendiente"));
            Requests.Add(new Request("2023/09/23", "No veo mis clases", "Kevin Rogers", "Solucionada"));
            Requests.Add(new Request("2023/09/15", "Hay un error con la hora de una de mis asignaturas", "Kevin Rogers", "Pendiente"));
            Requests.Add(new Request("2023/08/10", "no me aparece la informacion de la clase", "Kevin Rogers", "Solucionada"));
            Requests.Add(new Request("2023/10/11", "Problemas con mi Horario", "Kevin Rogers", "Pendiente"));
            Requests.Add(new Request("2023/09/23", "No veo mis clases", "Kevin Rogers", "Solucionada"));
            Requests.Add(new Request("2023/09/15", "Hay un error con la hora de una de mis asignaturas", "Kevin Rogers", "Pendiente"));
            Requests.Add(new Request("2023/08/10", "no me aparece la informacion de la clase", "Kevin Rogers", "Solucionada"));


        }

		private void MakeRequest(object parameter) 
		{ 
			ListRequestVisibility= Visibility.Collapsed;
			NewRequestVisibility= Visibility.Visible;
		}

        private void CancelRequest(object parameter)
        {
            ListRequestVisibility = Visibility.Visible;
            NewRequestVisibility = Visibility.Collapsed;
        }

        private void SendRequest(object parameter)
        {

            // The register is saved to the database and the list of requests is updated.

            ListRequestVisibility = Visibility.Visible;
            NewRequestVisibility = Visibility.Collapsed;
        }


    }
}