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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Clients
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class DoctorClient : Window
    {
        public DoctorClient()
        {
            InitializeComponent();
            GetPatient();
        }

        public void GetPatient()
        {
            using (var client = new HttpClient())
            {
                var result = client.GetAsync("http://localhost:61111/api/patient").Result;
                if (result.IsSuccessStatusCode)
                {
                    var content = result.Content.ReadAsStringAsync().Result;
                    var PatientList = JsonConvert.DeserializeObject<IList<Patient>>(content);

                    Patients.ItemsSource = PatientList;
                }
                else
                {
                    MessageBox.Show("Failed to get patients! " + result.StatusCode);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Patients_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            using (var client = new HttpClient())
            {
                var result = client.GetAsync("http://localhost:61111/api/patient").Result;
                if (result.IsSuccessStatusCode)
                {
                    var content = result.Content.ReadAsStringAsync().Result;
                    var PatientList = JsonConvert.DeserializeObject<IList<Patient>>(content);

                    if (Patients.SelectedIndex != -1)
                    {
                        Patient currentPatient = PatientList.ElementAt(PatientList.Count() - 1 - Patients.SelectedIndex);
                        Address.Text = ("Adress: " + currentPatient.Address);
                        TajNumber.Text = ("Taj Number: " + currentPatient.TajNumber);
                        Complaint.Text = ("Complaint: " + currentPatient.Complaint);
                    }
                }
                else
                {
                    MessageBox.Show("Failed to get patients! " + result.StatusCode);
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (var client = new HttpClient())
            {
                Patient currentPatient = (Patient) Patients.SelectedItem;
                var json = JsonConvert.SerializeObject(currentPatient);
                Console.WriteLine(json);
                var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
                Console.WriteLine(content);

                var result = client.PostAsync("http://localhost:61111/api/patient", content).Result;
                if (!result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Fail! " + result.StatusCode);
                }
                else
                {
                    MessageBox.Show("Patient deleted succesfully.");
                    GetPatient();
                }
            }
        }
    }
}
