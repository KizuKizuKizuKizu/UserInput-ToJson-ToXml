using Newtonsoft.Json.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInputJsonToXml
{
    public partial class Form1 : Form
    {
        private string _lastJson;
        private string _lastXml;


        private static readonly HttpClient httpClient = new HttpClient();

        public Form1()
        {
            InitializeComponent();
            progressBar1.Visible = false;
        }


        private async void Submit_btn_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;
            txtResponse.Visible = true;
            txtResponse.Text = "Sending request...";
            try
            {
                var json = new JObject(new JProperty("customer", new JObject(new JProperty("name", txtCustomerName.Text))),
                    new JProperty("order", new JObject(new JProperty("orderId", textOrderId.Text),
                    new JProperty("amount", txtAmount.Text))),
                    new JProperty("shipping",
                    new JObject(new JProperty("city", txtShippingCity.Text))));

                _lastJson = json.ToString();

                progressBar1.Value = 40; //progressbar


                var content = new StringContent(_lastJson, Encoding.UTF8, "application/json");

                string functionUrl = "http://localhost:7215/api/JsonToXmlFunction";
                progressBar1.Value = 70; //progressbar
                var response = await httpClient.PostAsync(functionUrl, content);
                _lastXml = await response.Content.ReadAsStringAsync();
                progressBar1.Value = 100; //progressbar
                txtResponse.Visible = true;
                txtResponse.Select(0, 0);
                txtResponse.Text = _lastXml;
            }
            catch (Exception ex)
            {
                txtResponse.Text = "Error: " + ex.Message;
            }
            finally
            {
                progressBar1.Visible = false;
            }
        }

        private void ShowJson_btn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_lastJson))
            {
                txtResponse.Text = _lastJson;

            }
        }

        private void ShowXml_btn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_lastXml))
            {
                txtResponse.Text = _lastXml;

            }
        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
