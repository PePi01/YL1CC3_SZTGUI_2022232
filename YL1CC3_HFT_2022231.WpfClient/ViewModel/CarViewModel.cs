using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YL1CC3_HFT_2022231.Logic;
using YL1CC3_HFT_2022231.Models;

namespace YL1CC3_HFT_2022231.WpfClient.ViewModel
{
    public class CarViewModel : ObservableRecipient
    {
        public ICarLogic logic;
        public RestCollection<Car> Cars { get; set; }
        public ICommand CreateCarCmd { get; set; }
        public ICommand DeleteCarCmd { get; set; }
        public ICommand UpdateCarCmd { get; set; }

        private Car selectedCar;

        public Car SelectedCar
        {
            get { return selectedCar; }
            set { SetProperty( ref selectedCar, value) }
        }

        public CarViewModel()
        {
            Cars = new RestCollection<Car>("http://localhost:10237/", "car");
            CreateCarCmd = new RelayCommand(() =>
              {
                  Cars.Add(new Car()
                  {
                      Model = "babakaka",
                  });
              });
        }
    }
}
