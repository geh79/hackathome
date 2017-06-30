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
        EvidencesFragment DataEvidence;
        List<Evidence> ListaEvidencias;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Evidences);

            TextViewUserFullName = FindViewById<TextView>(Resource.Id.textViewUserFullName);            
            TextViewUserFullName.Text = Intent.GetStringExtra("FullName") ?? "---";
            ListadoEvidenciasAsync();
        }

        public async void ListadoEvidenciasAsync()
        {
            
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
            else {
                ListaEvidencias = DataEvidence.ListaEvidencias;
            }

            ListEvidences.Adapter = new EvidencesAdapter(this, ListaEvidencias, Resource.Layout.EvidencesItem, Resource.Id.evidenceTitle, Resource.Id.evidenceStatus);
        }

       
    }
}