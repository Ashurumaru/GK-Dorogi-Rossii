using CorporatePortal.WPF.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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

namespace CorporatePortal.WPF.Views
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DashboardView : Window
    {
        private readonly HttpClient _httpClient;
        /// <summary>
        /// 
        ///
        /// </summary>
        /// <param name="login"></param>
        public DashboardView()
        {
            InitializeComponent();
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44397/api/")
            };
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            LoadProjects();

        }
        private async void LoadProjects()
        {
            List<Project> проекты = await GetПроектыAsync();
            if (проекты != null)
            {
                myListBox.ItemsSource = проекты;
            }
            else
            {
                MessageBox.Show("Ошибка при загрузке проектов.");
            }
        }
        public async Task<List<Project>> GetПроектыAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("Проекты");
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Project>>(data);
            }
            return null;
        }

        public async Task<bool> DeleteПроектAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"Проекты/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
