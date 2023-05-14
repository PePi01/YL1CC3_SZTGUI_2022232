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
                        
                        Price=value.Price,
                        BrandId=value.BrandId,
                        Model = value.Model,
                        Id = value.Id
                    };
                    OnPropertyChanged();
                }
                (UpdateCarCmd as RelayCommand).NotifyCanExecuteChanged();
                (DeleteCarCmd as RelayCommand).NotifyCanExecuteChanged();
                (CreateCarCmd as RelayCommand).NotifyCanExecuteChanged();
            }
        }
     



        public CarViewModel()
        {
            if (!IsInDesignMode)
            {
                Cars = new RestCollection<Car>("http://localhost:10237/", "car", "hub");
                Brands = new RestCollection<Brand>("http://localhost:10237/", "brand", "hub");

                CreateCarCmd = new RelayCommand(() =>
                {
                    Cars.Add(new Car()
                    {
                        Model = SelectedCar.Model,
                        BrandId = SelectedCar.BrandId,
                        Price = SelectedCar.Price,

                    });
                }
                ,() =>
                {
                    return SelectedCar != null;
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

                    Cars.Update(SelectedCar);
                    
                },
                ()=>
                {
                    return SelectedCar != null;
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
