using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinSample
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void btnBrowse(object sender, EventArgs e)
        {
            try
            {
                if (Device.RuntimePlatform == Device.Android)
                {
                    FileData filedata = new FileData();
                    if (CrossFilePicker.Current != null)
                        filedata = await CrossFilePicker.Current.PickFile();

                    lblPdfName.Text = filedata.FileName;
                    if (filedata != null)
                    {
                        string URL = await DependencyService.Get<ISaveFile>().SaveFile(filedata.FileName, filedata.DataArray);
                        PdfDocView.Uri = URL;
                    }
                }

                else if (Device.RuntimePlatform == Device.iOS)
                {

                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex);

            }

        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (this.Width > 0)
            {
                pdfStack.HeightRequest = this.Height - MainStack.Height;
                pdfStack.WidthRequest = this.Width;
                PdfDocView.HeightRequest = this.Height - pdfStack.Height;
                PdfDocView.WidthRequest = this.Width;
            }
        }
    }
}
