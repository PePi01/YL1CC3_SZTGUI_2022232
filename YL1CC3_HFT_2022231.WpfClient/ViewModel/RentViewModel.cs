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
    public class RentViewModel : ObservableRecipient
    {
        public RestCollection<Rent> Rents { get; set; }
        public RestCollection<Car> Cars { get; set; }
        public ICommand CreateRentCmd { get; set; }
        public ICommand DeleteRentCmd { get; set; }
        public ICommand UpdateRentCmd { get; set; }

        private Rent selectedRent;

        public Rent SelectedRent
        {
            get { return selectedRent; }
            set
            {
                if (value!=null)
                {
                    selectedRent = new Rent()
                    {
                        CarId = value.CarId,
                        Id = value.Id,
                        End = value.End,
                        Start = value.Start,
                    };
                    
                    OnPropertyChanged();
                }
                (UpdateRentCmd as RelayCommand).NotifyCanExecuteChanged();
                (DeleteRentCmd as RelayCommand).NotifyCanExecuteChanged();
                (CreateRentCmd as RelayCommand).NotifyCanExecuteChanged();
            }
        }
        public RentViewModel()
        {
            if (!IsInDesignMode)
            {
                Rents = new RestCollection<Rent>("http://localhost:10237/", "rent", "hub");
                Cars = new RestCollection<Car>("http://localhost:10237/", "car", "hub");

                CreateRentCmd = new RelayCommand(() =>
                {
                    Rents.Add(new Rent()
                    {
                        CarId = selectedRent.CarId,
                        End = selectedRent.End,
                        Start = selectedRent.Start,

                    });
                });
                /*,() =>
                {
                    return default; //SelectedRent != null;
                });*/

                DeleteRentCmd = new RelayCommand(() =>
                {
                    Rents.Delete(SelectedRent.Id);
                },
                () =>
                {
                    return SelectedRent != null;
                }
                );

                UpdateRentCmd = new RelayCommand(() =>
                {

                    Rents.Update(SelectedRent);

                },
                () =>
                {
                    return SelectedRent != null;
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
