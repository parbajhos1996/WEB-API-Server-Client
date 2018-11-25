using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Clients
{
    /// <summary>
    /// Interaction logic for AssistentClient.xaml
    /// </summary>
    public partial class AssistentClient : Window
    {
        public AssistentClient()
        {
            InitializeComponent();
        }

        private void AddPatientClick(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(FirstName.Text) ||
                String.IsNullOrEmpty(LastName.Text) ||
                String.IsNullOrEmpty(Address.Text) ||
                String.IsNullOrEmpty(TajNumber.Text) ||
                String.IsNullOrEmpty(Complaint.Text))
            {
                MessageBox.Show("Incomplete patient.");
                return;
            }

            if (TajNumber.Text.Length != 8)
            {
                MessageBox.Show("Wrong Taj Number.");
                return;
            }

            using (var client = new HttpClient())
            {
                var patient = new Patient
                {
                    FirstName = FirstName.Text,
                    LastName = LastName.Text,
                    Address = Address.Text,
                    TajNumber = TajNumber.Text,
                    Complaint = Complaint.Text
                };

                var json = JsonConvert.SerializeObject(patient);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var result = client.PostAsync("http://localhost:61111/api/patient", content).Result;
                if (!result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Fail! " + result.StatusCode);
                }
                else
                {
                    MessageBox.Show("Patient added successfully.");
                    FirstName.Text = "";
                    LastName.Text = "";
                    Address.Text = "";
                    TajNumber.Text = "";
                    Complaint.Text = "";
                    JSONFileSave.Write(patient);
                    App.doctorClient.GetPatient();
                }
            }
        }
    }
}
