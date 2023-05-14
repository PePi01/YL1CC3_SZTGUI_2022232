using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using YL1CC3_HFT_2022231.Models;

namespace YL1CC3_HFT_2022231.WpfClient.ViewModel
{
    public class CarViewModel : ObservableRecipient
    {
        public RestCollection<Car> Cars { get; set; }
        public RestCollection<Brand> Brands { get; set; }
        public ICommand CreateCarCmd { get; set; }
        public ICommand DeleteCarCmd { get; set; }
        public ICommand UpdateCarCmd { get; set; }

        private Car selectedCar;

        public Car SelectedCar
        {
            get { return selectedCar; }
            set
            {
                //SetProperty(ref selectedCar, value);
                if (value!=null)
                {
                    selectedCar = new Car()
                    {
                        Model = value.Model,
                        Id = value.Id
                    };
                    OnPropertyChanged();
                }
                (DeleteCarCmd as RelayCommand).NotifyCanExecuteChanged();
            }
        }
        private int brandSelection;

        public int BrandSelection
        {
            get { return brandSelection; }
            set
            {
                SetProperty(ref brandSelection,value);
                (UpdateCarCmd as RelayCommand).NotifyCanExecuteChanged();
            }
        }



        public CarViewModel()
        {
            if (!IsInDesignMode)
            {
                Cars = new RestCollection<Car>("http://localhost:10237/", "car");
                Brands = new RestCollection<Brand>("http://localhost:10237/", "brand");

                CreateCarCmd = new RelayCommand(() =>
                {
                    Cars.Add(new Car()
                    {
                        Model = "babakaka",
                    });
                });

                DeleteCarCmd = new RelayCommand(() =>
                  {
                      Cars.Delete(SelectedCar.Id);
                  },
                () =>
                {
                    return SelectedCar != null;
                }
                );

                UpdateCarCmd = new RelayCommand(() =>
                {
                    SelectedCar.BrandId = BrandSelection;
                    Cars.Update(SelectedCar);
                    ;
                });
                
            }
        }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }


    }
}
