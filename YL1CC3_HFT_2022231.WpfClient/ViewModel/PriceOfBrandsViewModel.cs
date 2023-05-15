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
    public class PriceOfBrandsViewModel : ObservableRecipient
    {
        public RestCollection<PriceOfBrands> Data { get; set; }
        

        private Rent selectedRent;

        public Rent SelectedRent
        {
            get { return selectedRent; }
            set
            {
                if (value != null)
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
                
            }
        }
        public PriceOfBrandsViewModel()
        {
            if (!IsInDesignMode)
            {
                Data = new RestCollection<PriceOfBrands>("http://localhost:10237/", "PriceOfBrands");
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
