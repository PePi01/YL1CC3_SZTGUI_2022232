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
    public class BrandViewModel : ObservableRecipient
    {
        public RestCollection<Brand> Brands { get; set; }
        public RestCollection<Car> Cars { get; set; }
        public ICommand CreateBrandCmd { get; set; }
        public ICommand DeleteBrandCmd { get; set; }
        public ICommand UpdateBrandCmd { get; set; }

        private Brand selectedBrand;

        public Brand SelectedBrand
        {
            get { return selectedBrand; }
            set
            {
                if (value != null)
                {
                    selectedBrand = new Brand()
                    {
                        Name=value.Name,
                        Id=value.Id,
                    };

                    OnPropertyChanged();
                }
                (UpdateBrandCmd as RelayCommand).NotifyCanExecuteChanged();
                (DeleteBrandCmd as RelayCommand).NotifyCanExecuteChanged();
                (CreateBrandCmd as RelayCommand).NotifyCanExecuteChanged();
            }
        }
        public BrandViewModel()
        {
            if (!IsInDesignMode)
            {
                Brands = new RestCollection<Brand>("http://localhost:10237/", "brand", "hub");
                Cars = new RestCollection<Car>("http://localhost:10237/", "car", "hub");

                CreateBrandCmd = new RelayCommand(() =>
                {
                    Brands.Add(new Brand()
                    {
                        Name = SelectedBrand.Name,

                    });
                });
                /*,() =>
                {
                    return default; //SelectedBrand != null;
                });*/

                DeleteBrandCmd = new RelayCommand(() =>
                {
                    Brands.Delete(SelectedBrand.Id);
                },
                () =>
                {
                    return SelectedBrand != null;
                }
                );

                UpdateBrandCmd = new RelayCommand(() =>
                {

                    Brands.Update(SelectedBrand);

                },
                () =>
                {
                    return SelectedBrand != null;
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
