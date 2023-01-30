using PizzeriaApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace PizzeriaApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddProductPage : ContentPage
    {
<<<<<<< HEAD
=======
        Product Product { get; set; }
>>>>>>> 9b0d7ac0fde05132254ad8940dedee9afd1a46a6
        public AddProductPage(Product product)
        {
            InitializeComponent();
            BindingContext = new AddProductPageViewModel(Navigation);
            if (product !=null)
            {
               ((AddProductPageViewModel)BindingContext).Product = product;

            }
            
        }
        public AddProductPage()
        {
            InitializeComponent();
            BindingContext =  new AddProductPageViewModel(Navigation);
        }

<<<<<<< HEAD
=======
        //private async void Button_AddPhoto_Clicked(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var pickImage = await FilePicker.PickAsync(new PickOptions()
        //        {
        //            FileTypes = FilePickerFileType.Images,
        //            PickerTitle = "Оберіть фото"
        //        }) ;
        //        if (pickImage != null)
        //        {
        //            var stream = await pickImage.OpenReadAsync() ;
                    
        //            imgFile.Source = ImageSource.FromStream(() => stream);
        //            fileName.Text = pickImage.FileName;

                    ////////add file to resourses/drawable
                    ////File.WriteAllBytes(Path.Combine("C:\\Users\\Лесик\\source\\repos\\PizzeriaApp\\PizzeriaApp\\PizzeriaApp.Android\\Resources\\drawable\\",fileName.Text), imageBytes);
                    //var directory = Path.Combine(FileSystem.AppDataDirectory, "images");
                    //if (!Directory.Exists(directory))
                    //{
                    //    Directory.CreateDirectory(directory);
                    //}

                    //var fileFullPath = Path.Combine(directory, fileName.Text);

                    //// Create a FileStream object to write a stream to a file
                    //using (FileStream fileStream = System.IO.File.Create(fileFullPath, (int)stream.Length))
                    //{
                    //    // Fill the bytes[] array with the stream data
                    //    byte[] bytesInStream = new byte[stream.Length];
                    //    stream.Read(bytesInStream, 0, (int)bytesInStream.Length);

                    //    // Use FileStream object to write to the specified file
                    //    fileStream.Write(bytesInStream, 0, bytesInStream.Length);
                    //}

        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}
>>>>>>> 9b0d7ac0fde05132254ad8940dedee9afd1a46a6

    }
}