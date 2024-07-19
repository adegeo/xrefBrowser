namespace xrefBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Download downloadForm = new();
            downloadForm.ShowDialog();

            if (downloadForm.DialogResult == DialogResult.Cancel)
            {
                Close();
            }

            else
            {
                // Prep Data
                DataContext = downloadForm.ViewModel;
            }
        }

        private void Form1_DataContextChanged(object sender, EventArgs e)
        {
            mainFormBindingSource.DataSource = DataContext;
        }
    }
}
