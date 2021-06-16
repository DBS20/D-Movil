using AppStarbucks.Models;
using AppStarbucks.Services;
using AppStarbucks.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace AppStarbucks.ViewModels
{
    public class BranchOfficeViewModel : BaseViewModel
    {
        public Command LoadBOfficeCommand { get; set; }


        public List<BranchOfficeModel> branchoffice;

        public List<BranchOfficeModel> BranchOffice { get => branchoffice; set => SetProperty(ref branchoffice, value); }

        public BranchOfficeViewModel()
        {
            BranchOffice = new List<BranchOfficeModel>();
            LoadBOfficeCommand = new Command(LoadBOfficeAction);

            LoadBOfficeAction();
        }


        private async void LoadBOfficeAction()
        {
            try
            {
                Debug.WriteLine("Ejecutando carga de Sucursales...");

                IsBusy = true;
                BranchOffice.Clear();


                ResponseModel response = await new ApiService().GetDataAsync("BOffice");
                if (response != null)
                {
                    if (response.IsSucces)
                    {

                        BranchOffice = JsonConvert.DeserializeObject<List<BranchOfficeModel>>(response.Result.ToString());
                    }
                    else
                    {
                        Debug.WriteLine($"RESPONSE: Se generó un error al consultar las Sucursales:{response.Result}");
                    }
                }
                else
                {
                    Debug.WriteLine($"Se generó un NULL al consultar WebApi -BOffice-");
                }

            }
            catch (Exception exc)
            {
                Debug.WriteLine($"EXC: Se generó un error al consultar las Sucursales:{exc.Message}");
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
