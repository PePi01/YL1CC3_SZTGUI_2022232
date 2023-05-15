using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using YL1CC3_HFT_2022231.Models;

namespace YL1CC3_HFT_2022231.WpfClient.ViewModel
{
    public class RentFrequencyViewModel
    {
        //RentFrequency
        public RestCollection<RentFrequency> Data { get; set; }


        public RentFrequencyViewModel()
        {
            if (!IsInDesignMode)
            {
                Data = new RestCollection<RentFrequency>("http://localhost:10237/", "RentFrequency");
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
