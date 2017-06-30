using Android.App;
using Android.Widget;
using Android.OS;
using HackAtHome.SAL;
using HackAtHome.Entities;

namespace HackAtHomeClient
{
    [Activity(Label = "Hack@Home", MainLauncher = true, Icon = "@drawable/iconAndroid", Theme = "@android:style/Theme.Holo")]
    public class MainActivity : Activity
    {
        EditText EditTextEMail;
        EditText EditTextPassword;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            EditTextEMail = FindViewById<EditText>(Resource.Id.editTextEmail);
            EditTextPassword = FindViewById<EditText>(Resource.Id.editTextPassword);

            EditTextEMail.Text = "germaneherrera@gmail.com";
            EditTextPassword.Text = "samuel25";

            FindViewById<Button>(Resource.Id.buttonValidar).Click += (sender, e) =>
            {
                ValidarAsync();               
            };
            
        }

        public async void ValidarAsync()
        {            
            ServiceClient validar = new ServiceClient();
            ResultInfo resultado = await validar.AutenticateAsync(EditTextEMail.Text, EditTextPassword.Text);

            if (resultado.Status == Status.Success)
            {
                var ActivityIntent = new Android.Content.Intent(this, typeof(EvidencesActivity));
                ActivityIntent.PutExtra("FullName", resultado.FullName);
                ActivityIntent.PutExtra("Token", resultado.Token);
                StartActivity(ActivityIntent);
            }
            else {
                MensajeValidacion("Se produjo un error en la validación de las credenciales");
            }
        }

        public void MensajeValidacion(string mensaje)
        {          
            Android.App.AlertDialog.Builder Bulider = new AlertDialog.Builder(this);
            AlertDialog Alert = Bulider.Create();
            Alert.SetTitle("Resultado de la verificación");
            Alert.SetIcon(Resource.Drawable.Icon);
            Alert.SetMessage(mensaje);
            Alert.SetButton("Ok", (s, ev) => { });
            Alert.Show();
        }
    }
}

