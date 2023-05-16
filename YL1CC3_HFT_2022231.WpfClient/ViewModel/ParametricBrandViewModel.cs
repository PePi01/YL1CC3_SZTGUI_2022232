using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using YL1CC3_HFT_2022231.Models;

namespace YL1CC3_HFT_2022231.WpfClient.ViewModel
{
    public class ParametricBrandViewModel : ObservableRecipient
    {
        private ObservableCollection<ParametricBrand> data;
        public ObservableCollection<ParametricBrand> Data
        {
            get { return data; }
            set
            {
                SetProperty(ref data, value);
                OnPropertyChanged();
            }
        }

        public RestCollection<Brand> Brands { get; set; }
        public ICommand Display { get; set; }

        private int num = 1;

        public int Num
        {
            get { return num; }
            set
            {
                if (value!=default)
                {
                    SetProperty(ref num, value);
                    OnPropertyChanged();
                }
                (Display as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        //ez nem kell
        private string szam = null;

        public string Szam
        {
            get { return szam; }
            set
            {
                if (value!=null)
                {
                    
                    SetProperty(ref szam, value);
                    Num = int.Parse(Szam);
                    OnPropertyChanged();
                }
                (Display as RelayCommand).NotifyCanExecuteChanged();
            }
        }
        //---
        private ObservableCollection<ParametricBrand> malac;

        public ObservableCollection<ParametricBrand> Malac
        {
            get { return malac; }
            set { SetProperty(ref malac, value);
                OnPropertyChanged();
            }
        }
        public ParametricBrandViewModel()
        {
            if (!IsInDesignMode)
            {
                Brands = new RestCollection<Brand>("http://localhost:10237/", "Brand");

                //a malacos mukodik  jol
                Display = new RelayCommand(() =>
                {
                    
                      //Data = new ObservableCollection<ParametricBrand>( new RestCollection<ParametricBrand>("http://localhost:10237/", $"ParametricBrand?num={Num}"));
                    Malac = new ObservableCollection<ParametricBrand>(new RestService("http://localhost:10237/").Get<ParametricBrand>($"ParametricBrand?num={Num}"));
                    
                    //ez nem kell
                    //malac.CollectionChanged+=(sender, args)=> { OnPropertyChanged(); };
                      


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
