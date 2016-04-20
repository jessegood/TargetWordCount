using Sdl.Desktop.IntegrationApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TargetWordCount
{
    public class MyCustomBatchTaskSettingsControl : UserControl, ISettingsAware<MyCustomBatchTaskSettings>
    {
        public MyCustomBatchTaskSettings Settings { get; set; }
    }
}
