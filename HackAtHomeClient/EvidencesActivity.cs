using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using HackAtHome.Entities;
using HackAtHome.SAL;
using HackAtHome.CustomAdapters;

namespace HackAtHomeClient
{
    [Activity(Label = "Hack@Home", Icon = "@drawable/iconAndroid", Theme = "@android:style/Theme.Holo")]
    public class EvidencesActivity : Activity
    {
        TextView TextViewUserFullName;
        ListView ListViewEvidences;
        EvidencesFragment DataEvidence;
        List<Evidence> ListaEvidencias;

        String FullName;
        String Token;
        String EvidenceID;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Evidences);

            ListViewEvidences = FindViewById<ListView>(Resource.Id.listView1);

            TextViewUserFullName = FindViewById<TextView>(Resource.Id.textViewUserFullName);

            FullName = Intent.GetStringExtra("FullName") ?? "---";
            Token = Intent.GetStringExtra("Token");

            TextViewUserFullName.Text = FullName;
            ListadoEvidenciasAsync();

            ListViewEvidences.ItemClick += clickList;           
        }

        private void clickList(object sender, AdapterView.ItemClickEventArgs e)
        {
            var ActivityIntent = new Android.Content.Intent(this, typeof(DetailEvidenceActivity));
            ActivityIntent.PutExtra("FullName", FullName);
            ActivityIntent.PutExtra("Token", Token);
            EvidenceID = ListaEvidencias[e.Position].EvidenceID.ToString();
            ActivityIntent.PutExtra("EvidenceID", EvidenceID);
            StartActivity(ActivityIntent);
        }

        public async void ListadoEvidenciasAsync()
        {                       
            ServiceClient data = new ServiceClient();
            ListaEvidencias = await data.GetEvidencesAsync(Token);
            ListViewEvidences.Adapter = new EvidencesAdapter(this, ListaEvidencias, Resource.Layout.EvidencesItem, Resource.Id.evidenceTitle, Resource.Id.evidenceStatus);
                        
            /*
            var ListEvidences = FindViewById<ListView>(Resource.Id.listView1);

            DataEvidence = (EvidencesFragment)this.FragmentManager.FindFragmentByTag("DataEvidence");

            if (DataEvidence == null)
            {
                DataEvidence = new EvidencesFragment();
                var FragmentTransaction = this.FragmentManager.BeginTransaction();
                FragmentTransaction.Add(DataEvidence, "DataEvidence");
                FragmentTransaction.Commit();

                ServiceClient data = new ServiceClient();
                ListaEvidencias = await data.GetEvidencesAsync(Intent.GetStringExtra("Token"));
            }
            //else {
            //    ListaEvidencias = DataEvidence.ListaEvidencias;
            //}

            if (instance != null)
            {
               // Counter = bundle.GetInt("CounterValue", 0);
              //  Android.Util.Log.Debug("Lab11Log", "Activity A - Recovered Instance State");
            }


            ListEvidences.Adapter = new EvidencesAdapter(this, ListaEvidencias, Resource.Layout.EvidencesItem, Resource.Id.evidenceTitle, Resource.Id.evidenceStatus);
            */
        }

       
    }
}